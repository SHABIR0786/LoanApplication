using LoanManagement.CoreLogicModels.JointRequest;
using LoanManagement.Data;
using LoanManagement.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LoanManagement.CredcoServices
{
    public class CredcoApi : ICredcoApi
    {
        private readonly ILogger<CredcoApi> _logger;

        public CredcoApi(ILogger<CredcoApi> logger)
        {
            _logger = logger;
        }

        public async Task<LoanManagement.CoreLogicModels.JointResponse.ResponseGroup> GetCreditDataAsync(LoanApplicationDto input)
        {
            try
            {
                var xml = CreateJointRequest(input);

                File.WriteAllText("request.xml", xml);
                var handler = new HttpClientHandler
                {
                    ClientCertificateOptions = ClientCertificateOption.Manual,
                    SslProtocols = SslProtocols.Tls12
                };
                handler.ClientCertificates.Add(new X509Certificate2("file.pfx", "Credco287909"));
                var client = new HttpClient(handler);

                var httpContent = new StringContent(xml, Encoding.UTF8, "application/xml");

                var response = await client.PostAsync("https://beta.credcoconnect.com/cc/listener", httpContent);


                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(LoanManagement.CoreLogicModels.JointResponse.ResponseGroup));
                var data = (LoanManagement.CoreLogicModels.JointResponse.ResponseGroup)serializer.Deserialize(await response.Content.ReadAsStreamAsync());
                return data;
            }
            catch (Exception ex)
            {
                if (ex.Message == "No such host is known.")
                {
                    _logger.LogError("Region lock issue");
                }
                else
                {

                }

                throw;
            }
        }

        private static string CreateJointRequest(LoanApplicationDto input)
        {
            var reqGroup = new RequestGroup
            {
                MISMOVersionID = "2.3.1",
                RECEIVING_PARTY = new RecievingParty
                {
                    _Name = "Credit Bureau"
                },
                REQUEST = new Request
                {
                    KEY = new Key
                    {
                        _Name = "Notes",
                        _Value = ""
                    },
                    LoginAccountIdentifier = " 4003809",
                    LoginAccountPassword = "WNPBY5RZ",
                    REQUEST_DATA = new RequestData
                    {
                        CREDIT_REQUEST = new CreditRequest
                        {
                            CREDIT_REQUEST_DATA = new CreditRequestData
                            {
                                BorrowerID = "Borrower",
                                CreditRequestType = "Individual",
                                CreditReportIdentifier = "",
                                CREDIT_REPOSITORY_INCLUDED = new CreditRepositoryIncluded
                                {
                                    _EquifaxIndicator = "Y",
                                    _ExperianIndicator = "Y",
                                    _TransUnionIndicator = "Y"
                                }
                            },
                            LenderCaseIdentifier = "Optional - LoanNum",
                            LOAN_APPLICATION = new LoanApplication
                            {
                                BORROWER = new List<Borrower>
                                {
                                    new Borrower
                                    {
                                        _FirstName = "DAVID",
                                        _LastName = "DELINQUENT",
                                        _MiddleName = "",
                                        _NameSuffix ="",
                                        _PrintPositionType = "Borrower",
                                        _SSN ="000965850",
                                        _RESIDENCE = new Residence {
                                            _City ="PRESCOTT",
                                            _PostalCode = "86305",
                                            _State = "AZ",
                                            _StreetAddress ="1003 Enred Way",
                                            BorrowerResidencyType ="Current"
                                        }
                                    }
                                }
                            },
                            MISMOVersionID = "2.3.1",
                            RequestingPartyRequestedByName = "ezonlinemortgage",
                        }
                    }
                },
                REQUESTING_PARTY = new RequestingParty
                {
                    PREFERRED_RESPONSE = new List<PreferredResponse>
                    {
                        new PreferredResponse
                        {
                            Format = "XML",
                            VersionIdentifier = "2.3.1"
                        }
                    }
                },
                SUBMITTING_PARTY = new List<SubmittingParty>
                {
                    new SubmittingParty
                    {
                        _Identifier = "EOM",
                        _Name = "EZ Online Mortgage",
                        _City ="Valley Village",
                        _PostalCode = "91607",
                        _State ="CA",
                        _StreetAddress ="4804 Laurel Canyon Blvd #1199",
                    }
                }
            };

            var xmlBorrower = reqGroup.REQUEST.REQUEST_DATA.CREDIT_REQUEST.LOAN_APPLICATION.BORROWER;
            var borrower = input.PersonalInformation.Borrower;
            var borrowerAddress = input.PersonalInformation.ResidentialAddress;
            xmlBorrower.Add(new Borrower
            {
                _FirstName = borrower.FirstName,
                _LastName = borrower.LastName,
                _MiddleName = borrower.MiddleInitial,
                _NameSuffix = borrower.Suffix,
                _PrintPositionType = "Borrower",
                _SSN = borrower.SocialSecurityNumber,
                _RESIDENCE = new Residence
                {
                    _City = borrowerAddress.City,
                    _PostalCode = borrowerAddress.ZipCode.ToString(),
                    _State = StateData.GetStateById(borrowerAddress.StateId.Value),
                    _StreetAddress = borrowerAddress.AddressLine1,
                    BorrowerResidencyType = "Current"
                }
            });

            if (input.PersonalInformation.IsApplyingWithCoBorrower.HasValue &&
                input.PersonalInformation.IsApplyingWithCoBorrower.Value)
            {
                var cwBorrower = input.PersonalInformation.CoBorrower;
                var coBorrowerAddress = input.PersonalInformation.CoBorrowerResidentialAddress;
                xmlBorrower.Add(new Borrower
                {
                    _FirstName = cwBorrower.FirstName,
                    _LastName = cwBorrower.LastName,
                    _MiddleName = cwBorrower.MiddleInitial,
                    _NameSuffix = cwBorrower.Suffix,
                    _PrintPositionType = "Borrower",
                    _SSN = cwBorrower.SocialSecurityNumber,
                    _RESIDENCE = new Residence
                    {
                        _City = coBorrowerAddress.City,
                        _PostalCode = coBorrowerAddress.ZipCode.ToString(),
                        _State = StateData.GetStateById(coBorrowerAddress.StateId.Value),
                        _StreetAddress = coBorrowerAddress.AddressLine1,
                        BorrowerResidencyType = "Current"
                    }
                });
            }


            return GetXml(reqGroup);
        }

        private static string GetXml<T>(T obj) where T : class
        {
            var xsSubmit = new XmlSerializer(typeof(T));

            using var sww = new StringWriter();
            using var writer = XmlWriter.Create(sww);
            //Create our own namespaces for the output
            var ns = new XmlSerializerNamespaces();

            //Add an empty namespace and empty value
            ns.Add("", "");
            xsSubmit.Serialize(writer, obj, ns);
            return sww.ToString();
        }
    }
}
