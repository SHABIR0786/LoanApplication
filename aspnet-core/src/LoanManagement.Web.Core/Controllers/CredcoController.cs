using Abp.Runtime.Validation;
using LoanManagement.CoreLogicModels.JointRequest;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LoanManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CredcoController : LoanManagementControllerBase
    {
        private readonly ILoanAppService _loanAppService;

        public CredcoController(
            ILoanAppService loanAppService
        )
        {
            _loanAppService = loanAppService;
        }

        public async Task Main(List<BorrowerJsonDto> models)
        {
            try
            {
                var xml = CreateJointRequest(models);
                System.IO.File.WriteAllText("request.xml", xml);
                var handler = new HttpClientHandler
                {
                    ClientCertificateOptions = ClientCertificateOption.Manual,
                    SslProtocols = SslProtocols.Tls12
                };
                handler.ClientCertificates.Add(new X509Certificate2("file.pfx", "Credco287909"));
                var client = new HttpClient(handler);

                var httpContent = new StringContent(xml, Encoding.UTF8, "application/xml");

                var response = await client.PostAsync("https://beta.credcoconnect.com/cc/listener", httpContent);

                var responseContent = await response.Content.ReadAsStringAsync();

                System.IO.File.WriteAllText("response.xml", responseContent);
            }
            catch (Exception ex)
            {
                if (ex.Message == "No such host is known.")
                {
                    System.Console.WriteLine("Region lock issue");
                }
                else
                {

                }

                throw;
            }
        }

        public static string CreateJointRequest(List<BorrowerJsonDto> Model)
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
                        _Value = "Optional - Notes, 72 char max"
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
                                BORROWER = Model.Select(i => new Borrower
                                {
                                    _FirstName = i._FirstName,
                                    _LastName = i._LastName,
                                    _MiddleName = i._MiddleName,
                                    _NameSuffix = i._NameSuffix,
                                    _PrintPositionType = i._PrintPositionType,
                                    _RESIDENCE =new Residence{
                                        _City = i._RESIDENCE._City,
                                        _PostalCode = i._RESIDENCE._PostalCode,
                                        _State =i._RESIDENCE._State,
                                        _StreetAddress = i._RESIDENCE._StreetAddress,
                                        BorrowerResidencyType = i._RESIDENCE.BorrowerResidencyType,
                                    }
                                })
                                .ToList()
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

            return GetXml(reqGroup);
        }

        public static string GetXml<T>(T obj) where T : class
        {
            var xsSubmit = new XmlSerializer(typeof(T));

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    //Create our own namespaces for the output
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

                    //Add an empty namespace and empty value
                    ns.Add("", "");
                    xsSubmit.Serialize(writer, obj, ns);
                    return sww.ToString();
                }
            }
        }
    }
}
