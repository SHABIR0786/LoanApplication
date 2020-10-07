using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Implementations
{
    public class PersonalDetailServices : AbpServiceBase, IPersonalDetailService
    {
        private readonly IRepository<PersonalDetail, long> _repository;
        private readonly IRepository<Borrower, long> _borrowerRepository;
        private readonly IRepository<Address, long> _addressRepository;

        public PersonalDetailServices(
            IRepository<PersonalDetail, long> repository,
            IRepository<Borrower, long> borrowerRepository,
            IRepository<Address, long> addressRepository)
        {
            _repository = repository;
            _borrowerRepository = borrowerRepository;
            _addressRepository = addressRepository;
        }

        public Task<PersonalInformationDto> GetAsync(EntityDto<long?> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<PersonalInformationDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonalInformationDto> CreateAsync(PersonalInformationDto input)
        {
            try
            {
                if (input.Borrower != null)
                {
                    var borrower = new Borrower
                    {
                        FirstName = input.Borrower.FirstName,
                        LastName = input.Borrower.LastName,
                        Suffix = input.Borrower.Suffix,
                        Email = input.Borrower.Email,
                        DateOfBirth = input.Borrower.DateOfBirth,
                        SocialSecurityNumber = input.Borrower.SocialSecurityNumber,
                        MaritalStatusId = input.Borrower.MaritalStatusId,
                        NumberOfDependents = input.Borrower.NumberOfDependents,
                        CellPhone = input.Borrower.CellPhone,
                        HomePhone = input.Borrower.HomePhone,
                        BorrowerTypeId = (int)Enums.BorrowerType.Borrower,
                        MiddleInitial = input.Borrower.MiddleInitial
                    };

                    input.Borrower.BorrowerTypeId = borrower.BorrowerTypeId;

                    await _borrowerRepository.InsertAsync(borrower);
                    await UnitOfWorkManager.Current.SaveChangesAsync();

                    input.Borrower.Id = borrower.Id;
                }

                if (input.CoBorrower != null)
                {
                    var borrower = new Borrower
                    {
                        FirstName = input.CoBorrower.FirstName,
                        LastName = input.CoBorrower.LastName,
                        Suffix = input.CoBorrower.Suffix,
                        Email = input.CoBorrower.Email,
                        DateOfBirth = input.CoBorrower.DateOfBirth,
                        SocialSecurityNumber = input.CoBorrower.SocialSecurityNumber,
                        MaritalStatusId = input.CoBorrower.MaritalStatusId,
                        NumberOfDependents = input.CoBorrower.NumberOfDependents,
                        CellPhone = input.CoBorrower.CellPhone,
                        HomePhone = input.CoBorrower.HomePhone,
                        BorrowerTypeId = (int)Enums.BorrowerType.CoBorrower,
                        MiddleInitial = input.CoBorrower.MiddleInitial
                    };

                    input.CoBorrower.BorrowerTypeId = borrower.BorrowerTypeId;

                    await _borrowerRepository.InsertAsync(borrower);
                    await UnitOfWorkManager.Current.SaveChangesAsync();

                    input.CoBorrower.Id = borrower.Id;
                }

                var personalDetail = new PersonalDetail
                {
                    IsApplyingWithCoBorrower = input.IsApplyingWithCoBorrower,
                    UseIncomeOfPersonOtherThanBorrower = input.UseIncomeOfPersonOtherThanBorrower,
                    AgreePrivacyPolicy = input.AgreePrivacyPolicy,
                    BorrowerId = input.CoBorrower?.Id,
                    CoBorrowerId = input.Borrower?.Id,
                    IsMailingAddressSameAsResidential = input.IsMailingAddressSameAsResidential,
                };

                if (input.PreviousAddresses != null && input.PreviousAddresses.Any())
                    foreach (var address in input.PreviousAddresses)
                    {
                        personalDetail.Addresses.Add(new Address
                        {
                            AddressLine1 = address.AddressLine1,
                            AddressLine2 = address.AddressLine2,
                            AddressType = Enums.AddressType.Previous.ToString(),
                            City = address.City,
                            Months = address.Months,
                            StateId = address.StateId,
                            Years = address.Years,
                            ZipCode = address.ZipCode,
                        });
                    }

                if (input.MailingAddress != null)
                    personalDetail.Addresses.Add(new Address
                    {
                        AddressLine1 = input.MailingAddress.AddressLine1,
                        AddressLine2 = input.MailingAddress.AddressLine2,
                        AddressType = Enums.AddressType.Mailing.ToString(),
                        City = input.MailingAddress.City,
                        Months = input.MailingAddress.Months,
                        StateId = input.MailingAddress.StateId,
                        Years = input.MailingAddress.Years,
                        ZipCode = input.MailingAddress.ZipCode,
                    });

                if (input.ResidentialAddress != null)
                    personalDetail.Addresses.Add(new Address
                    {
                        AddressLine1 = input.ResidentialAddress.AddressLine1,
                        AddressLine2 = input.ResidentialAddress.AddressLine2,
                        AddressType = Enums.AddressType.Residential.ToString(),
                        City = input.ResidentialAddress.City,
                        Months = input.ResidentialAddress.Months,
                        StateId = input.ResidentialAddress.StateId,
                        Years = input.ResidentialAddress.Years,
                        ZipCode = input.ResidentialAddress.ZipCode,
                    });

                await _repository.InsertAsync(personalDetail);
                await UnitOfWorkManager.Current.SaveChangesAsync();

                input.Id = personalDetail.Id;

                AssignAddressIds(personalDetail?.Addresses, input);

                return input;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<PersonalInformationDto> UpdateAsync(PersonalInformationDto input)
        {
            var newAddresses = new List<Address>();
            if (input.Borrower != null)
            {
                if (!input.Borrower.Id.HasValue || input.Borrower.Id.Value == default)
                {
                    var borrower = new Borrower
                    {
                        FirstName = input.Borrower.FirstName,
                        LastName = input.Borrower.LastName,
                        Suffix = input.Borrower.Suffix,
                        Email = input.Borrower.Email,
                        DateOfBirth = input.Borrower.DateOfBirth,
                        SocialSecurityNumber = input.Borrower.SocialSecurityNumber,
                        MaritalStatusId = input.Borrower.MaritalStatusId,
                        NumberOfDependents = input.Borrower.NumberOfDependents,
                        CellPhone = input.Borrower.CellPhone,
                        HomePhone = input.Borrower.HomePhone,
                        BorrowerTypeId = (int)Enums.BorrowerType.Borrower,
                        MiddleInitial = input.Borrower.MiddleInitial
                    };

                    await _borrowerRepository.InsertAsync(borrower);
                    await UnitOfWorkManager.Current.SaveChangesAsync();

                    input.Borrower.Id = borrower.Id;
                }
                else
                    await _borrowerRepository.UpdateAsync(input.Borrower.Id.Value, borrower =>
                    {
                        borrower.FirstName = input.Borrower.FirstName;
                        borrower.LastName = input.Borrower.LastName;
                        borrower.Suffix = input.Borrower.Suffix;
                        borrower.Email = input.Borrower.Email;
                        borrower.DateOfBirth = input.Borrower.DateOfBirth;
                        borrower.SocialSecurityNumber = input.Borrower.SocialSecurityNumber;
                        borrower.MaritalStatusId = input.Borrower.MaritalStatusId;
                        borrower.NumberOfDependents = input.Borrower.NumberOfDependents;
                        borrower.CellPhone = input.Borrower.CellPhone;
                        borrower.HomePhone = input.Borrower.HomePhone;
                        borrower.MiddleInitial = input.Borrower.MiddleInitial;

                        return Task.CompletedTask;
                    });
            }

            if (input.CoBorrower != null)
            {
                if (!input.CoBorrower.Id.HasValue || input.CoBorrower.Id.Value == default)
                {
                    var borrower = new Borrower
                    {
                        FirstName = input.CoBorrower.FirstName,
                        LastName = input.CoBorrower.LastName,
                        Suffix = input.CoBorrower.Suffix,
                        Email = input.CoBorrower.Email,
                        DateOfBirth = input.CoBorrower.DateOfBirth,
                        SocialSecurityNumber = input.CoBorrower.SocialSecurityNumber,
                        MaritalStatusId = input.CoBorrower.MaritalStatusId,
                        NumberOfDependents = input.CoBorrower.NumberOfDependents,
                        CellPhone = input.CoBorrower.CellPhone,
                        HomePhone = input.CoBorrower.HomePhone,
                        BorrowerTypeId = (int)Enums.BorrowerType.CoBorrower,
                        MiddleInitial = input.CoBorrower.MiddleInitial
                    };

                    await _borrowerRepository.InsertAsync(borrower);
                    await UnitOfWorkManager.Current.SaveChangesAsync();

                    input.CoBorrower.Id = borrower.Id;
                }
                else
                    await _borrowerRepository.UpdateAsync(input.CoBorrower.Id.Value, borrower =>
                    {
                        borrower.FirstName = input.CoBorrower.FirstName;
                        borrower.LastName = input.CoBorrower.LastName;
                        borrower.Suffix = input.CoBorrower.Suffix;
                        borrower.Email = input.CoBorrower.Email;
                        borrower.DateOfBirth = input.CoBorrower.DateOfBirth;
                        borrower.SocialSecurityNumber = input.CoBorrower.SocialSecurityNumber;
                        borrower.MaritalStatusId = input.CoBorrower.MaritalStatusId;
                        borrower.NumberOfDependents = input.CoBorrower.NumberOfDependents;
                        borrower.CellPhone = input.CoBorrower.CellPhone;
                        borrower.HomePhone = input.CoBorrower.HomePhone;
                        borrower.MiddleInitial = input.CoBorrower.MiddleInitial;

                        return Task.CompletedTask;
                    });
            }

            await _repository.UpdateAsync(input.Id.Value, personalDetail =>
            {
                personalDetail.IsApplyingWithCoBorrower = input.IsApplyingWithCoBorrower;
                personalDetail.UseIncomeOfPersonOtherThanBorrower = input.UseIncomeOfPersonOtherThanBorrower;
                personalDetail.AgreePrivacyPolicy = input.AgreePrivacyPolicy;
                personalDetail.BorrowerId = input.CoBorrower?.Id;
                personalDetail.CoBorrowerId = input.Borrower?.Id;
                personalDetail.IsMailingAddressSameAsResidential = input.IsMailingAddressSameAsResidential;

                if (input.PreviousAddresses != null && input.PreviousAddresses.Any())
                    foreach (var address in input.PreviousAddresses)
                    {
                        if (!address.Id.HasValue ||  address.Id.Value == default)
                        {
                            var newAddress = new Address
                            {
                                AddressLine1 = address.AddressLine1,
                                AddressLine2 = address.AddressLine2,
                                AddressType = Enums.AddressType.Previous.ToString(),
                                City = address.City,
                                Months = address.Months,
                                StateId = address.StateId,
                                Years = address.Years,
                                ZipCode = address.ZipCode,
                            };
                            personalDetail.Addresses.Add(newAddress);
                            newAddresses.Add(newAddress);
                        }
                    }

                if (input.MailingAddress != null && input.MailingAddress.Id.Value == default)
                {
                    var address = new Address
                    {
                        AddressLine1 = input.MailingAddress.AddressLine1,
                        AddressLine2 = input.MailingAddress.AddressLine2,
                        AddressType = Enums.AddressType.Mailing.ToString(),
                        City = input.MailingAddress.City,
                        Months = input.MailingAddress.Months,
                        StateId = input.MailingAddress.StateId,
                        Years = input.MailingAddress.Years,
                        ZipCode = input.MailingAddress.ZipCode,
                    };
                    personalDetail.Addresses.Add(address);
                    newAddresses.Add(address);
                }

                if (input.ResidentialAddress != null && input.ResidentialAddress.Id.Value == default)
                {
                    var address = new Address
                    {
                        AddressLine1 = input.ResidentialAddress.AddressLine1,
                        AddressLine2 = input.ResidentialAddress.AddressLine2,
                        AddressType = Enums.AddressType.Residential.ToString(),
                        City = input.ResidentialAddress.City,
                        Months = input.ResidentialAddress.Months,
                        StateId = input.ResidentialAddress.StateId,
                        Years = input.ResidentialAddress.Years,
                        ZipCode = input.ResidentialAddress.ZipCode,
                    };
                    personalDetail.Addresses.Add(address);
                    newAddresses.Add(address);
                }

                return Task.CompletedTask;
            });

            if (input.PreviousAddresses != null && input.PreviousAddresses.Any())
                foreach (var address in input.PreviousAddresses)
                {
                    if (address.Id != default)
                        await _addressRepository.UpdateAsync(address.Id.Value, dbAddress =>
                        {
                            dbAddress.AddressLine1 = address.AddressLine1;
                            dbAddress.AddressLine2 = address.AddressLine2;
                            dbAddress.City = address.City;
                            dbAddress.Months = address.Months;
                            dbAddress.StateId = address.StateId;
                            dbAddress.Years = address.Years;
                            dbAddress.ZipCode = address.ZipCode;

                            return Task.CompletedTask;
                        });
                }

            if (input.MailingAddress != null && input.MailingAddress.Id != default)
                await _addressRepository.UpdateAsync(input.MailingAddress.Id.Value, dbAddress =>
                {
                    dbAddress.AddressLine1 = input.MailingAddress.AddressLine1;
                    dbAddress.AddressLine2 = input.MailingAddress.AddressLine2;
                    dbAddress.City = input.MailingAddress.City;
                    dbAddress.Months = input.MailingAddress.Months;
                    dbAddress.StateId = input.MailingAddress.StateId;
                    dbAddress.Years = input.MailingAddress.Years;
                    dbAddress.ZipCode = input.MailingAddress.ZipCode;

                    return Task.CompletedTask;
                });

            if (input.ResidentialAddress != null && input.ResidentialAddress.Id != default)
                await _addressRepository.UpdateAsync(input.ResidentialAddress.Id.Value, dbAddress =>
                {
                    dbAddress.AddressLine1 = input.ResidentialAddress.AddressLine1;
                    dbAddress.AddressLine2 = input.ResidentialAddress.AddressLine2;
                    dbAddress.City = input.ResidentialAddress.City;
                    dbAddress.Months = input.ResidentialAddress.Months;
                    dbAddress.StateId = input.ResidentialAddress.StateId;
                    dbAddress.Years = input.ResidentialAddress.Years;
                    dbAddress.ZipCode = input.ResidentialAddress.ZipCode;

                    return Task.CompletedTask;
                });

            await UnitOfWorkManager.Current.SaveChangesAsync();

            AssignAddressIds(newAddresses, input);

            return input;
        }

        public Task DeleteAsync(EntityDto<long?> input)
        {
            throw new NotImplementedException();
        }

        private void AssignAddressIds(List<Address> addresses, PersonalInformationDto input)
        {
            if (addresses != null && addresses.Any())
            {
                var previousAddress = addresses
                    .Where(i => i.AddressType == Enums.AddressType.Previous.ToString())
                    .ToList();
                if (previousAddress.Any())
                    for (var index = 0; index < previousAddress.Count; index++)
                        input.PreviousAddresses[index].Id = previousAddress[index].Id;

                for (var index = 0; index < addresses.Count; index++)
                {
                    var address = addresses[index];
                    Enum.TryParse(address.AddressType, out Enums.AddressType addressType);
                    switch (addressType)
                    {
                        case Enums.AddressType.Residential:
                            input.ResidentialAddress.Id = address.Id;
                            break;
                        case Enums.AddressType.Previous:
                            continue;
                        case Enums.AddressType.Mailing:
                            input.MailingAddress.Id = address.Id;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
