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
                    CoBorrowerIsMailingAddressSameAsResidential = input.CoBorrowerIsMailingAddressSameAsResidential
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
                            BorrowerTypeId = (int)Enums.BorrowerType.Borrower,
                        });
                    }

                if (input.CoBorrowerPreviousAddresses != null && input.CoBorrowerPreviousAddresses.Any())
                    foreach (var address in input.CoBorrowerPreviousAddresses)
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
                            BorrowerTypeId = (int)Enums.BorrowerType.CoBorrower,
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
                        BorrowerTypeId = (int)Enums.BorrowerType.Borrower,
                    });

                if (input.CoBorrowerMailingAddress != null)
                    personalDetail.Addresses.Add(new Address
                    {
                        AddressLine1 = input.CoBorrowerMailingAddress.AddressLine1,
                        AddressLine2 = input.CoBorrowerMailingAddress.AddressLine2,
                        AddressType = Enums.AddressType.Mailing.ToString(),
                        City = input.CoBorrowerMailingAddress.City,
                        Months = input.CoBorrowerMailingAddress.Months,
                        StateId = input.CoBorrowerMailingAddress.StateId,
                        Years = input.CoBorrowerMailingAddress.Years,
                        ZipCode = input.CoBorrowerMailingAddress.ZipCode,
                        BorrowerTypeId = (int)Enums.BorrowerType.CoBorrower,
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
                        BorrowerTypeId = (int)Enums.BorrowerType.Borrower,
                    });

                if (input.CoBorrowerResidentialAddress != null)
                    personalDetail.Addresses.Add(new Address
                    {
                        AddressLine1 = input.CoBorrowerResidentialAddress.AddressLine1,
                        AddressLine2 = input.CoBorrowerResidentialAddress.AddressLine2,
                        AddressType = Enums.AddressType.Residential.ToString(),
                        City = input.CoBorrowerResidentialAddress.City,
                        Months = input.CoBorrowerResidentialAddress.Months,
                        StateId = input.CoBorrowerResidentialAddress.StateId,
                        Years = input.CoBorrowerResidentialAddress.Years,
                        ZipCode = input.CoBorrowerResidentialAddress.ZipCode,
                        BorrowerTypeId = (int)Enums.BorrowerType.CoBorrower,
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
                        if (!address.Id.HasValue || address.Id.Value == default)
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
                                BorrowerTypeId = (int)Enums.BorrowerType.Borrower,
                            };
                            personalDetail.Addresses.Add(newAddress);
                            newAddresses.Add(newAddress);
                        }
                    }

                if (input.CoBorrowerPreviousAddresses != null && input.CoBorrowerPreviousAddresses.Any())
                    foreach (var address in input.PreviousAddresses)
                    {
                        if (!address.Id.HasValue || address.Id.Value == default)
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
                                BorrowerTypeId = (int)Enums.BorrowerType.CoBorrower,
                            };
                            personalDetail.Addresses.Add(newAddress);
                            newAddresses.Add(newAddress);
                        }
                    }

                if (input.MailingAddress != null && (!input.ResidentialAddress.Id.HasValue || input.ResidentialAddress.Id.Value == default))
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
                        BorrowerTypeId = (int)Enums.BorrowerType.Borrower,
                    };
                    personalDetail.Addresses.Add(address);
                    newAddresses.Add(address);
                }

                if (input.CoBorrowerMailingAddress != null && (!input.ResidentialAddress.Id.HasValue || input.ResidentialAddress.Id.Value == default))
                {
                    var address = new Address
                    {
                        AddressLine1 = input.CoBorrowerMailingAddress.AddressLine1,
                        AddressLine2 = input.CoBorrowerMailingAddress.AddressLine2,
                        AddressType = Enums.AddressType.Mailing.ToString(),
                        City = input.CoBorrowerMailingAddress.City,
                        Months = input.CoBorrowerMailingAddress.Months,
                        StateId = input.CoBorrowerMailingAddress.StateId,
                        Years = input.CoBorrowerMailingAddress.Years,
                        ZipCode = input.CoBorrowerMailingAddress.ZipCode,
                        BorrowerTypeId = (int)Enums.BorrowerType.CoBorrower,
                    };
                    personalDetail.Addresses.Add(address);
                    newAddresses.Add(address);
                }

                if (input.ResidentialAddress != null && (!input.ResidentialAddress.Id.HasValue || input.ResidentialAddress.Id.Value == default))
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
                        BorrowerTypeId = (int)Enums.BorrowerType.Borrower,
                    };
                    personalDetail.Addresses.Add(address);
                    newAddresses.Add(address);
                }

                if (input.CoBorrowerResidentialAddress != null && (!input.ResidentialAddress.Id.HasValue || input.ResidentialAddress.Id.Value == default))
                {
                    var address = new Address
                    {
                        AddressLine1 = input.CoBorrowerResidentialAddress.AddressLine1,
                        AddressLine2 = input.CoBorrowerResidentialAddress.AddressLine2,
                        AddressType = Enums.AddressType.Residential.ToString(),
                        City = input.CoBorrowerResidentialAddress.City,
                        Months = input.CoBorrowerResidentialAddress.Months,
                        StateId = input.CoBorrowerResidentialAddress.StateId,
                        Years = input.CoBorrowerResidentialAddress.Years,
                        ZipCode = input.CoBorrowerResidentialAddress.ZipCode,
                        BorrowerTypeId = (int)Enums.BorrowerType.CoBorrower,
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

            if (input.CoBorrowerPreviousAddresses != null && input.CoBorrowerPreviousAddresses.Any())
                foreach (var address in input.CoBorrowerPreviousAddresses)
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

            if (input.CoBorrowerMailingAddress != null && input.CoBorrowerMailingAddress.Id != default)
                await _addressRepository.UpdateAsync(input.MailingAddress.Id.Value, dbAddress =>
                {
                    dbAddress.AddressLine1 = input.CoBorrowerMailingAddress.AddressLine1;
                    dbAddress.AddressLine2 = input.CoBorrowerMailingAddress.AddressLine2;
                    dbAddress.City = input.CoBorrowerMailingAddress.City;
                    dbAddress.Months = input.CoBorrowerMailingAddress.Months;
                    dbAddress.StateId = input.CoBorrowerMailingAddress.StateId;
                    dbAddress.Years = input.CoBorrowerMailingAddress.Years;
                    dbAddress.ZipCode = input.CoBorrowerMailingAddress.ZipCode;

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

            if (input.CoBorrowerResidentialAddress != null && input.CoBorrowerResidentialAddress.Id != default)
                await _addressRepository.UpdateAsync(input.ResidentialAddress.Id.Value, dbAddress =>
                {
                    dbAddress.AddressLine1 = input.CoBorrowerResidentialAddress.AddressLine1;
                    dbAddress.AddressLine2 = input.CoBorrowerResidentialAddress.AddressLine2;
                    dbAddress.City = input.CoBorrowerResidentialAddress.City;
                    dbAddress.Months = input.CoBorrowerResidentialAddress.Months;
                    dbAddress.StateId = input.CoBorrowerResidentialAddress.StateId;
                    dbAddress.Years = input.CoBorrowerResidentialAddress.Years;
                    dbAddress.ZipCode = input.CoBorrowerResidentialAddress.ZipCode;

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
                    .Where(i => i.AddressType == Enums.AddressType.Previous.ToString() && i.BorrowerTypeId == (int)Enums.BorrowerType.Borrower)
                    .ToList();
                if (previousAddress.Any())
                    for (var index = 0; index < previousAddress.Count; index++)
                        input.PreviousAddresses[index].Id = previousAddress[index].Id;

                var coBorrowerPreviousAddresses = addresses
                   .Where(i => i.AddressType == Enums.AddressType.Previous.ToString() && i.BorrowerTypeId == (int)Enums.BorrowerType.CoBorrower)
                   .ToList();
                if (coBorrowerPreviousAddresses.Any())
                    for (var index = 0; index < coBorrowerPreviousAddresses.Count; index++)
                        input.CoBorrowerPreviousAddresses[index].Id = coBorrowerPreviousAddresses[index].Id;

                for (var index = 0; index < addresses.Count; index++)
                {
                    var address = addresses[index];
                    Enum.TryParse(address.AddressType, out Enums.AddressType addressType);
                    switch (addressType)
                    {
                        case Enums.AddressType.Residential:
                            if (address.BorrowerTypeId == (int)Enums.BorrowerType.Borrower)
                                input.ResidentialAddress.Id = address.Id;
                            else if (address.BorrowerTypeId == (int)Enums.BorrowerType.Borrower)
                                input.CoBorrowerResidentialAddress.Id = address.Id;
                            break;
                        case Enums.AddressType.Previous:
                            continue;
                        case Enums.AddressType.Mailing:
                            if (address.BorrowerTypeId == (int)Enums.BorrowerType.Borrower)
                                input.MailingAddress.Id = address.Id;
                            else if (address.BorrowerTypeId == (int)Enums.BorrowerType.Borrower)
                                input.CoBorrowerMailingAddress.Id = address.Id;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public string GetStateId(int stateId)
        {
            var StateList = new List<State>
            {
            };
            StateList.Add(new State { Id = 1, Name = "AL" });
            StateList.Add(new State { Id = 2, Name = "AK" });
            StateList.Add(new State { Id = 3, Name = "AS" });
            StateList.Add(new State { Id = 4, Name = "AZ" });
            StateList.Add(new State { Id = 5, Name = "AR" });
            StateList.Add(new State { Id = 6, Name = "CA" });
            StateList.Add(new State { Id = 7, Name = "CO" });
            StateList.Add(new State { Id = 8, Name = "CT" });
            StateList.Add(new State { Id = 9, Name = "DE" });
            StateList.Add(new State { Id = 10, Name = "DC" });
            StateList.Add(new State { Id = 11, Name = "FM" });
            StateList.Add(new State { Id = 12, Name = "FL" });
            StateList.Add(new State { Id = 13, Name = "GA" });
            StateList.Add(new State { Id = 14, Name = "GU" });
            StateList.Add(new State { Id = 15, Name = "HI" });
            StateList.Add(new State { Id = 16, Name = "ID" });
            StateList.Add(new State { Id = 17, Name = "IL" });
            StateList.Add(new State { Id = 18, Name = "IN" });
            StateList.Add(new State { Id = 19, Name = "IA" });
            StateList.Add(new State { Id = 20, Name = "KS" });
            StateList.Add(new State { Id = 21, Name = "KY" });
            StateList.Add(new State { Id = 22, Name = "LA" });
            StateList.Add(new State { Id = 23, Name = "ME" });
            StateList.Add(new State { Id = 24, Name = "MH" });
            StateList.Add(new State { Id = 25, Name = "MD" });
            StateList.Add(new State { Id = 26, Name = "MA" });
            StateList.Add(new State { Id = 27, Name = "MI" });
            StateList.Add(new State { Id = 28, Name = "MN" });
            StateList.Add(new State { Id = 29, Name = "MS" });
            StateList.Add(new State { Id = 30, Name = "MO" });
            StateList.Add(new State { Id = 31, Name = "MT" });
            StateList.Add(new State { Id = 32, Name = "NE" });
            StateList.Add(new State { Id = 33, Name = "NV" });
            StateList.Add(new State { Id = 34, Name = "NH" });
            StateList.Add(new State { Id = 35, Name = "NJ" });
            StateList.Add(new State { Id = 36, Name = "NM" });
            StateList.Add(new State { Id = 37, Name = "NY" });
            StateList.Add(new State { Id = 38, Name = "NC" });
            StateList.Add(new State { Id = 39, Name = "ND" });
            StateList.Add(new State { Id = 40, Name = "MP" });
            StateList.Add(new State { Id = 41, Name = "OH" });
            StateList.Add(new State { Id = 42, Name = "OK" });
            StateList.Add(new State { Id = 43, Name = "OR" });
            StateList.Add(new State { Id = 44, Name = "PW" });
            StateList.Add(new State { Id = 45, Name = "PA" });
            StateList.Add(new State { Id = 46, Name = "PR" });
            StateList.Add(new State { Id = 47, Name = "RI" });
            StateList.Add(new State { Id = 48, Name = "SC" });
            StateList.Add(new State { Id = 49, Name = "SD" });
            StateList.Add(new State { Id = 50, Name = "TN" });
            StateList.Add(new State { Id = 51, Name = "TX" });
            StateList.Add(new State { Id = 52, Name = "UT" });
            StateList.Add(new State { Id = 53, Name = "VT" });
            StateList.Add(new State { Id = 54, Name = "VI" });
            StateList.Add(new State { Id = 55, Name = "VA" });
            StateList.Add(new State { Id = 56, Name = "WA" });
            StateList.Add(new State { Id = 57, Name = "WV" });
            StateList.Add(new State { Id = 58, Name = "WI" });
            StateList.Add(new State { Id = 59, Name = "WY" });
            return StateList.Where(i => i.Id == stateId).Select(i => i.Name).Single();
        }
    }
}
