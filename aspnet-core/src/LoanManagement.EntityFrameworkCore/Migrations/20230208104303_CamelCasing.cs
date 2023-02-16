using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagement.Migrations
{
    public partial class CamelCasing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "zip",
                table: "MortgagePropertyFinancialInformations",
                newName: "Zip");

            migrationBuilder.RenameColumn(
                name: "unit",
                table: "MortgagePropertyFinancialInformations",
                newName: "Unit");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "MortgagePropertyFinancialInformations",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "MortgagePropertyFinancialInformations",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "propertyValue",
                table: "MortgagePropertyFinancialInformations",
                newName: "PropertyValue");

            migrationBuilder.RenameColumn(
                name: "netMonthlyRentalIncome",
                table: "MortgagePropertyFinancialInformations",
                newName: "NetMonthlyRentalIncome");

            migrationBuilder.RenameColumn(
                name: "monthlyRentalIncome",
                table: "MortgagePropertyFinancialInformations",
                newName: "MonthlyRentalIncome");

            migrationBuilder.RenameColumn(
                name: "monthlyInsurance",
                table: "MortgagePropertyFinancialInformations",
                newName: "MonthlyInsurance");

            migrationBuilder.RenameColumn(
                name: "intendedOccupancy",
                table: "MortgagePropertyFinancialInformations",
                newName: "IntendedOccupancy");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "MortgagePropertyFinancialInformations",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "MortgagePropertyFinancialInformations",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "zip",
                table: "MortgagePropertyAdditionalFinancialInformations",
                newName: "Zip");

            migrationBuilder.RenameColumn(
                name: "unit",
                table: "MortgagePropertyAdditionalFinancialInformations",
                newName: "Unit");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "MortgagePropertyAdditionalFinancialInformations",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "MortgagePropertyAdditionalFinancialInformations",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "propertyValue",
                table: "MortgagePropertyAdditionalFinancialInformations",
                newName: "PropertyValue");

            migrationBuilder.RenameColumn(
                name: "netMonthlyRentalIncome",
                table: "MortgagePropertyAdditionalFinancialInformations",
                newName: "NetMonthlyRentalIncome");

            migrationBuilder.RenameColumn(
                name: "monthlyRentalIncome",
                table: "MortgagePropertyAdditionalFinancialInformations",
                newName: "MonthlyRentalIncome");

            migrationBuilder.RenameColumn(
                name: "monthlyInsurance",
                table: "MortgagePropertyAdditionalFinancialInformations",
                newName: "MonthlyInsurance");

            migrationBuilder.RenameColumn(
                name: "intendedOccupancy",
                table: "MortgagePropertyAdditionalFinancialInformations",
                newName: "IntendedOccupancy");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "MortgagePropertyAdditionalFinancialInformations",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "MortgagePropertyAdditionalFinancialInformations",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "unpaidBalance",
                table: "MortgageLoanOnProperyFinancialInformations",
                newName: "UnpaidBalance");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "MortgageLoanOnProperyFinancialInformations",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "monthlyMortagagePayment",
                table: "MortgageLoanOnProperyFinancialInformations",
                newName: "MonthlyMortagagePayment");

            migrationBuilder.RenameColumn(
                name: "isApplied",
                table: "MortgageLoanOnProperyFinancialInformations",
                newName: "IsApplied");

            migrationBuilder.RenameColumn(
                name: "creditorName",
                table: "MortgageLoanOnProperyFinancialInformations",
                newName: "CreditorName");

            migrationBuilder.RenameColumn(
                name: "creditLimit",
                table: "MortgageLoanOnProperyFinancialInformations",
                newName: "CreditLimit");

            migrationBuilder.RenameColumn(
                name: "accountNumber",
                table: "MortgageLoanOnProperyFinancialInformations",
                newName: "AccountNumber");

            migrationBuilder.RenameColumn(
                name: "unpaidBalance",
                table: "MortgageLoanOnAdditionalPropertyFinancialInformations",
                newName: "UnpaidBalance");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "MortgageLoanOnAdditionalPropertyFinancialInformations",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "monthlyMortagagePayment",
                table: "MortgageLoanOnAdditionalPropertyFinancialInformations",
                newName: "MonthlyMortagagePayment");

            migrationBuilder.RenameColumn(
                name: "isApplied",
                table: "MortgageLoanOnAdditionalPropertyFinancialInformations",
                newName: "IsApplied");

            migrationBuilder.RenameColumn(
                name: "creditorName",
                table: "MortgageLoanOnAdditionalPropertyFinancialInformations",
                newName: "CreditorName");

            migrationBuilder.RenameColumn(
                name: "creditLimit",
                table: "MortgageLoanOnAdditionalPropertyFinancialInformations",
                newName: "CreditLimit");

            migrationBuilder.RenameColumn(
                name: "accountNumber",
                table: "MortgageLoanOnAdditionalPropertyFinancialInformations",
                newName: "AccountNumber");

            migrationBuilder.RenameColumn(
                name: "expense",
                table: "MortgageFinancialOtherLaibilitiesTypes",
                newName: "Expense");

            migrationBuilder.RenameColumn(
                name: "cashMarketValue",
                table: "MortgageFinancialOtherLaibilitiesTypes",
                newName: "CashMarketValue");

            migrationBuilder.RenameColumn(
                name: "unpaidBalance",
                table: "MortgageFinancialLaibilitiesTypes",
                newName: "UnpaidBalance");

            migrationBuilder.RenameColumn(
                name: "companyName",
                table: "MortgageFinancialLaibilitiesTypes",
                newName: "CompanyName");

            migrationBuilder.RenameColumn(
                name: "cashMarketValue",
                table: "MortgageFinancialLaibilitiesTypes",
                newName: "CashMarketValue");

            migrationBuilder.RenameColumn(
                name: "accountType",
                table: "MortgageFinancialLaibilitiesTypes",
                newName: "AccountType");

            migrationBuilder.RenameColumn(
                name: "accountNumber",
                table: "MortgageFinancialLaibilitiesTypes",
                newName: "AccountNumber");

            migrationBuilder.RenameColumn(
                name: "cashMarketValue",
                table: "MortgageFinancialCreditTypes",
                newName: "CashMarketValue");

            migrationBuilder.RenameColumn(
                name: "assetsCreditType",
                table: "MortgageFinancialCreditTypes",
                newName: "AssetsCreditType");

            migrationBuilder.RenameColumn(
                name: "financialInstitution",
                table: "MortgageFinancialAccountTypes",
                newName: "FinancialInstitution");

            migrationBuilder.RenameColumn(
                name: "cashMarketValue",
                table: "MortgageFinancialAccountTypes",
                newName: "CashMarketValue");

            migrationBuilder.RenameColumn(
                name: "accountType",
                table: "MortgageFinancialAccountTypes",
                newName: "AccountType");

            migrationBuilder.RenameColumn(
                name: "accountNumber",
                table: "MortgageFinancialAccountTypes",
                newName: "AccountNumber");

            migrationBuilder.RenameColumn(
                name: "yourIntials",
                table: "MortgageApplicationTypeOfCredits",
                newName: "YourIntials");

            migrationBuilder.RenameColumn(
                name: "totalBorrowers",
                table: "MortgageApplicationTypeOfCredits",
                newName: "TotalBorrowers");

            migrationBuilder.RenameColumn(
                name: "applyingFor",
                table: "MortgageApplicationTypeOfCredits",
                newName: "ApplyingFor");

            migrationBuilder.RenameColumn(
                name: "sourceType",
                table: "MortgageApplicationSources",
                newName: "SourceType");

            migrationBuilder.RenameColumn(
                name: "monthlyIncome",
                table: "MortgageApplicationSources",
                newName: "MonthlyIncome");

            migrationBuilder.RenameColumn(
                name: "yesNo",
                table: "MortgageApplicationQuestions",
                newName: "YesNo");

            migrationBuilder.RenameColumn(
                name: "question",
                table: "MortgageApplicationQuestions",
                newName: "Question");

            migrationBuilder.RenameColumn(
                name: "answer",
                table: "MortgageApplicationQuestions",
                newName: "Answer");

            migrationBuilder.RenameColumn(
                name: "zip",
                table: "MortgageApplicationPreviousEmploymentDetails",
                newName: "Zip");

            migrationBuilder.RenameColumn(
                name: "unit",
                table: "MortgageApplicationPreviousEmploymentDetails",
                newName: "Unit");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "MortgageApplicationPreviousEmploymentDetails",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "MortgageApplicationPreviousEmploymentDetails",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "MortgageApplicationPreviousEmploymentDetails",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "position",
                table: "MortgageApplicationPreviousEmploymentDetails",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "MortgageApplicationPreviousEmploymentDetails",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "monthlyIncome",
                table: "MortgageApplicationPreviousEmploymentDetails",
                newName: "MonthlyIncome");

            migrationBuilder.RenameColumn(
                name: "isSelfEmployed",
                table: "MortgageApplicationPreviousEmploymentDetails",
                newName: "IsSelfEmployed");

            migrationBuilder.RenameColumn(
                name: "endDate",
                table: "MortgageApplicationPreviousEmploymentDetails",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "MortgageApplicationPreviousEmploymentDetails",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "MortgageApplicationPreviousEmploymentDetails",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "suffix",
                table: "MortgageApplicationPersonalInformation",
                newName: "Suffix");

            migrationBuilder.RenameColumn(
                name: "socialSecurityNumber",
                table: "MortgageApplicationPersonalInformation",
                newName: "SocialSecurityNumber");

            migrationBuilder.RenameColumn(
                name: "middleName",
                table: "MortgageApplicationPersonalInformation",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "marritalStatus",
                table: "MortgageApplicationPersonalInformation",
                newName: "MarritalStatus");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "MortgageApplicationPersonalInformation",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "MortgageApplicationPersonalInformation",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "dob",
                table: "MortgageApplicationPersonalInformation",
                newName: "Dob");

            migrationBuilder.RenameColumn(
                name: "dependents",
                table: "MortgageApplicationPersonalInformation",
                newName: "Dependents");

            migrationBuilder.RenameColumn(
                name: "citizenship",
                table: "MortgageApplicationPersonalInformation",
                newName: "Citizenship");

            migrationBuilder.RenameColumn(
                name: "suffix",
                table: "MortgageApplicationOtherBorrowers",
                newName: "Suffix");

            migrationBuilder.RenameColumn(
                name: "middleName",
                table: "MortgageApplicationOtherBorrowers",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "MortgageApplicationOtherBorrowers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "MortgageApplicationOtherBorrowers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "MortgageApplicationOtherBorrowers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "projectedExpirationServiceDate",
                table: "MortgageApplicationMilitaryServices",
                newName: "ProjectedExpirationServiceDate");

            migrationBuilder.RenameColumn(
                name: "isSurvivingSpouse",
                table: "MortgageApplicationMilitaryServices",
                newName: "IsSurvivingSpouse");

            migrationBuilder.RenameColumn(
                name: "isServeUSForces",
                table: "MortgageApplicationMilitaryServices",
                newName: "IsServeUSForces");

            migrationBuilder.RenameColumn(
                name: "isNonActivatedMember",
                table: "MortgageApplicationMilitaryServices",
                newName: "IsNonActivatedMember");

            migrationBuilder.RenameColumn(
                name: "isCurrentlyServing",
                table: "MortgageApplicationMilitaryServices",
                newName: "IsCurrentlyServing");

            migrationBuilder.RenameColumn(
                name: "isCurrentlyRetired",
                table: "MortgageApplicationMilitaryServices",
                newName: "IsCurrentlyRetired");

            migrationBuilder.RenameColumn(
                name: "zip",
                table: "MortgageApplicationMailingAddresses",
                newName: "Zip");

            migrationBuilder.RenameColumn(
                name: "unit",
                table: "MortgageApplicationMailingAddresses",
                newName: "Unit");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "MortgageApplicationMailingAddresses",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "MortgageApplicationMailingAddresses",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "MortgageApplicationMailingAddresses",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "MortgageApplicationMailingAddresses",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "incomeType",
                table: "MortgageApplicationLoanPropertyRentalIncomes",
                newName: "IncomeType");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "MortgageApplicationLoanPropertyRentalIncomes",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "monthlyPayment",
                table: "MortgageApplicationLoanPropertyOtherNewMortgageLoans",
                newName: "MonthlyPayment");

            migrationBuilder.RenameColumn(
                name: "loanAmount",
                table: "MortgageApplicationLoanPropertyOtherNewMortgageLoans",
                newName: "LoanAmount");

            migrationBuilder.RenameColumn(
                name: "lienType",
                table: "MortgageApplicationLoanPropertyOtherNewMortgageLoans",
                newName: "LienType");

            migrationBuilder.RenameColumn(
                name: "creditorName",
                table: "MortgageApplicationLoanPropertyOtherNewMortgageLoans",
                newName: "CreditorName");

            migrationBuilder.RenameColumn(
                name: "creditLimit",
                table: "MortgageApplicationLoanPropertyOtherNewMortgageLoans",
                newName: "CreditLimit");

            migrationBuilder.RenameColumn(
                name: "occupancy",
                table: "MortgageApplicationLoanPropertyInformation",
                newName: "Occupancy");

            migrationBuilder.RenameColumn(
                name: "loanPurpose",
                table: "MortgageApplicationLoanPropertyInformation",
                newName: "LoanPurpose");

            migrationBuilder.RenameColumn(
                name: "loanAmount",
                table: "MortgageApplicationLoanPropertyInformation",
                newName: "LoanAmount");

            migrationBuilder.RenameColumn(
                name: "isMixedUseProperty",
                table: "MortgageApplicationLoanPropertyInformation",
                newName: "IsMixedUseProperty");

            migrationBuilder.RenameColumn(
                name: "isManufacturedHome",
                table: "MortgageApplicationLoanPropertyInformation",
                newName: "IsManufacturedHome");

            migrationBuilder.RenameColumn(
                name: "source",
                table: "MortgageApplicationLoanPropertyGiftsOrGrants",
                newName: "Source");

            migrationBuilder.RenameColumn(
                name: "marketValue",
                table: "MortgageApplicationLoanPropertyGiftsOrGrants",
                newName: "MarketValue");

            migrationBuilder.RenameColumn(
                name: "isDeposited",
                table: "MortgageApplicationLoanPropertyGiftsOrGrants",
                newName: "IsDeposited");

            migrationBuilder.RenameColumn(
                name: "assetType",
                table: "MortgageApplicationLoanPropertyGiftsOrGrants",
                newName: "AssetType");

            migrationBuilder.RenameColumn(
                name: "zip",
                table: "MortgageApplicationLoanPropertyAddresses",
                newName: "Zip");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "MortgageApplicationLoanPropertyAddresses",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "MortgageApplicationLoanPropertyAddresses",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "propertyValue",
                table: "MortgageApplicationLoanPropertyAddresses",
                newName: "PropertyValue");

            migrationBuilder.RenameColumn(
                name: "numberOfUnits",
                table: "MortgageApplicationLoanPropertyAddresses",
                newName: "NumberOfUnits");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "MortgageApplicationLoanPropertyAddresses",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "MortgageApplicationLoanPropertyAddresses",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "totalAmount",
                table: "MortgageApplicationIncomeSources",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "zip",
                table: "MortgageApplicationFormerAddresses",
                newName: "Zip");

            migrationBuilder.RenameColumn(
                name: "year",
                table: "MortgageApplicationFormerAddresses",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "unit",
                table: "MortgageApplicationFormerAddresses",
                newName: "Unit");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "MortgageApplicationFormerAddresses",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "MortgageApplicationFormerAddresses",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "rent",
                table: "MortgageApplicationFormerAddresses",
                newName: "Rent");

            migrationBuilder.RenameColumn(
                name: "month",
                table: "MortgageApplicationFormerAddresses",
                newName: "Month");

            migrationBuilder.RenameColumn(
                name: "housingType",
                table: "MortgageApplicationFormerAddresses",
                newName: "HousingType");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "MortgageApplicationFormerAddresses",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "MortgageApplicationFormerAddresses",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "total",
                table: "MortgageApplicationEmploymentIncomeDetails",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "overtime",
                table: "MortgageApplicationEmploymentIncomeDetails",
                newName: "Overtime");

            migrationBuilder.RenameColumn(
                name: "other",
                table: "MortgageApplicationEmploymentIncomeDetails",
                newName: "Other");

            migrationBuilder.RenameColumn(
                name: "militaryEntitlements",
                table: "MortgageApplicationEmploymentIncomeDetails",
                newName: "MilitaryEntitlements");

            migrationBuilder.RenameColumn(
                name: "commission",
                table: "MortgageApplicationEmploymentIncomeDetails",
                newName: "Commission");

            migrationBuilder.RenameColumn(
                name: "bonus",
                table: "MortgageApplicationEmploymentIncomeDetails",
                newName: "Bonus");

            migrationBuilder.RenameColumn(
                name: "baseIncome",
                table: "MortgageApplicationEmploymentIncomeDetails",
                newName: "BaseIncome");

            migrationBuilder.RenameColumn(
                name: "zip",
                table: "MortgageApplicationEmploymentDetails",
                newName: "Zip");

            migrationBuilder.RenameColumn(
                name: "workingYears",
                table: "MortgageApplicationEmploymentDetails",
                newName: "WorkingYears");

            migrationBuilder.RenameColumn(
                name: "workingMonths",
                table: "MortgageApplicationEmploymentDetails",
                newName: "WorkingMonths");

            migrationBuilder.RenameColumn(
                name: "unit",
                table: "MortgageApplicationEmploymentDetails",
                newName: "Unit");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "MortgageApplicationEmploymentDetails",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "MortgageApplicationEmploymentDetails",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "MortgageApplicationEmploymentDetails",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "position",
                table: "MortgageApplicationEmploymentDetails",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "MortgageApplicationEmploymentDetails",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "ownershipShare",
                table: "MortgageApplicationEmploymentDetails",
                newName: "OwnershipShare");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "MortgageApplicationEmploymentDetails",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "monthlyIncome",
                table: "MortgageApplicationEmploymentDetails",
                newName: "MonthlyIncome");

            migrationBuilder.RenameColumn(
                name: "isSelfEmployed",
                table: "MortgageApplicationEmploymentDetails",
                newName: "IsSelfEmployed");

            migrationBuilder.RenameColumn(
                name: "isOwnershipLessThan25",
                table: "MortgageApplicationEmploymentDetails",
                newName: "IsOwnershipLessThan25");

            migrationBuilder.RenameColumn(
                name: "isEmployedBySomeone",
                table: "MortgageApplicationEmploymentDetails",
                newName: "IsEmployedBySomeone");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "MortgageApplicationEmploymentDetails",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "MortgageApplicationEmploymentDetails",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "demographicInfoSource",
                table: "MortgageApplicationDemographicInformation",
                newName: "DemographicInfoSource");

            migrationBuilder.RenameColumn(
                name: "zip",
                table: "MortgageApplicationCurrentAddresses",
                newName: "Zip");

            migrationBuilder.RenameColumn(
                name: "year",
                table: "MortgageApplicationCurrentAddresses",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "unit",
                table: "MortgageApplicationCurrentAddresses",
                newName: "Unit");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "MortgageApplicationCurrentAddresses",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "MortgageApplicationCurrentAddresses",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "rent",
                table: "MortgageApplicationCurrentAddresses",
                newName: "Rent");

            migrationBuilder.RenameColumn(
                name: "month",
                table: "MortgageApplicationCurrentAddresses",
                newName: "Month");

            migrationBuilder.RenameColumn(
                name: "housingType",
                table: "MortgageApplicationCurrentAddresses",
                newName: "HousingType");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "MortgageApplicationCurrentAddresses",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "MortgageApplicationCurrentAddresses",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "workPhone",
                table: "MortgageApplicationContactInformation",
                newName: "WorkPhone");

            migrationBuilder.RenameColumn(
                name: "homePhone",
                table: "MortgageApplicationContactInformation",
                newName: "HomePhone");

            migrationBuilder.RenameColumn(
                name: "ext",
                table: "MortgageApplicationContactInformation",
                newName: "Ext");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "MortgageApplicationContactInformation",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "cellPhone",
                table: "MortgageApplicationContactInformation",
                newName: "CellPhone");

            migrationBuilder.RenameColumn(
                name: "suffix",
                table: "MortgageApplicationAlternateNames",
                newName: "Suffix");

            migrationBuilder.RenameColumn(
                name: "middleName",
                table: "MortgageApplicationAlternateNames",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "MortgageApplicationAlternateNames",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "MortgageApplicationAlternateNames",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "isAgreeAgreement",
                table: "MortgageApplicationAgreements",
                newName: "IsAgreeAgreement");

            migrationBuilder.RenameColumn(
                name: "total",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "overtime",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails",
                newName: "Overtime");

            migrationBuilder.RenameColumn(
                name: "others",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails",
                newName: "Others");

            migrationBuilder.RenameColumn(
                name: "militaryEntitlements",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails",
                newName: "MilitaryEntitlements");

            migrationBuilder.RenameColumn(
                name: "commission",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails",
                newName: "Commission");

            migrationBuilder.RenameColumn(
                name: "bonus",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails",
                newName: "Bonus");

            migrationBuilder.RenameColumn(
                name: "baseIncome",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails",
                newName: "BaseIncome");

            migrationBuilder.RenameColumn(
                name: "zip",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "Zip");

            migrationBuilder.RenameColumn(
                name: "workingYears",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "WorkingYears");

            migrationBuilder.RenameColumn(
                name: "workingMonths",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "WorkingMonths");

            migrationBuilder.RenameColumn(
                name: "unit",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "Unit");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "position",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "ownershipShare",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "OwnershipShare");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "monthlyIncome",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "MonthlyIncome");

            migrationBuilder.RenameColumn(
                name: "isSelfEmployed",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "IsSelfEmployed");

            migrationBuilder.RenameColumn(
                name: "isOwnershipLessThan25",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "IsOwnershipLessThan25");

            migrationBuilder.RenameColumn(
                name: "isEmployedBySomeone",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "IsEmployedBySomeone");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "totalAmount",
                table: "MortgageAppliactionFinancialLiabilities",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "totalAmount",
                table: "MortgageAppliactionFinancialCredits",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "totalAmount",
                table: "MortgageAppliactionFinancialAccounts",
                newName: "TotalAmount");

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 8, 16, 13, 2, 381, DateTimeKind.Local).AddTicks(2905));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 8, 16, 13, 2, 381, DateTimeKind.Local).AddTicks(2920));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 8, 16, 13, 2, 381, DateTimeKind.Local).AddTicks(2923));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 8, 16, 13, 2, 381, DateTimeKind.Local).AddTicks(2924));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 8, 16, 13, 2, 381, DateTimeKind.Local).AddTicks(2934));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 8, 16, 13, 2, 381, DateTimeKind.Local).AddTicks(2936));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 8, 16, 13, 2, 381, DateTimeKind.Local).AddTicks(2937));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 8, 16, 13, 2, 381, DateTimeKind.Local).AddTicks(2938));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 8, 16, 13, 2, 381, DateTimeKind.Local).AddTicks(2939));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 8, 16, 13, 2, 381, DateTimeKind.Local).AddTicks(2940));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 8, 16, 13, 2, 381, DateTimeKind.Local).AddTicks(2941));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 8, 16, 13, 2, 381, DateTimeKind.Local).AddTicks(2996));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 8, 16, 13, 2, 381, DateTimeKind.Local).AddTicks(2997));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 8, 16, 13, 2, 381, DateTimeKind.Local).AddTicks(3210));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 2, 8, 16, 13, 2, 381, DateTimeKind.Local).AddTicks(3214));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 2, 8, 16, 13, 2, 381, DateTimeKind.Local).AddTicks(3215));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2023, 2, 8, 16, 13, 2, 381, DateTimeKind.Local).AddTicks(3217));

            migrationBuilder.UpdateData(
                table: "Sitesettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 8, 16, 13, 2, 381, DateTimeKind.Local).AddTicks(3256));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "MortgagePropertyFinancialInformations",
                newName: "zip");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "MortgagePropertyFinancialInformations",
                newName: "unit");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "MortgagePropertyFinancialInformations",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "MortgagePropertyFinancialInformations",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "PropertyValue",
                table: "MortgagePropertyFinancialInformations",
                newName: "propertyValue");

            migrationBuilder.RenameColumn(
                name: "NetMonthlyRentalIncome",
                table: "MortgagePropertyFinancialInformations",
                newName: "netMonthlyRentalIncome");

            migrationBuilder.RenameColumn(
                name: "MonthlyRentalIncome",
                table: "MortgagePropertyFinancialInformations",
                newName: "monthlyRentalIncome");

            migrationBuilder.RenameColumn(
                name: "MonthlyInsurance",
                table: "MortgagePropertyFinancialInformations",
                newName: "monthlyInsurance");

            migrationBuilder.RenameColumn(
                name: "IntendedOccupancy",
                table: "MortgagePropertyFinancialInformations",
                newName: "intendedOccupancy");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "MortgagePropertyFinancialInformations",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "MortgagePropertyFinancialInformations",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "MortgagePropertyAdditionalFinancialInformations",
                newName: "zip");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "MortgagePropertyAdditionalFinancialInformations",
                newName: "unit");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "MortgagePropertyAdditionalFinancialInformations",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "MortgagePropertyAdditionalFinancialInformations",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "PropertyValue",
                table: "MortgagePropertyAdditionalFinancialInformations",
                newName: "propertyValue");

            migrationBuilder.RenameColumn(
                name: "NetMonthlyRentalIncome",
                table: "MortgagePropertyAdditionalFinancialInformations",
                newName: "netMonthlyRentalIncome");

            migrationBuilder.RenameColumn(
                name: "MonthlyRentalIncome",
                table: "MortgagePropertyAdditionalFinancialInformations",
                newName: "monthlyRentalIncome");

            migrationBuilder.RenameColumn(
                name: "MonthlyInsurance",
                table: "MortgagePropertyAdditionalFinancialInformations",
                newName: "monthlyInsurance");

            migrationBuilder.RenameColumn(
                name: "IntendedOccupancy",
                table: "MortgagePropertyAdditionalFinancialInformations",
                newName: "intendedOccupancy");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "MortgagePropertyAdditionalFinancialInformations",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "MortgagePropertyAdditionalFinancialInformations",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "UnpaidBalance",
                table: "MortgageLoanOnProperyFinancialInformations",
                newName: "unpaidBalance");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "MortgageLoanOnProperyFinancialInformations",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "MonthlyMortagagePayment",
                table: "MortgageLoanOnProperyFinancialInformations",
                newName: "monthlyMortagagePayment");

            migrationBuilder.RenameColumn(
                name: "IsApplied",
                table: "MortgageLoanOnProperyFinancialInformations",
                newName: "isApplied");

            migrationBuilder.RenameColumn(
                name: "CreditorName",
                table: "MortgageLoanOnProperyFinancialInformations",
                newName: "creditorName");

            migrationBuilder.RenameColumn(
                name: "CreditLimit",
                table: "MortgageLoanOnProperyFinancialInformations",
                newName: "creditLimit");

            migrationBuilder.RenameColumn(
                name: "AccountNumber",
                table: "MortgageLoanOnProperyFinancialInformations",
                newName: "accountNumber");

            migrationBuilder.RenameColumn(
                name: "UnpaidBalance",
                table: "MortgageLoanOnAdditionalPropertyFinancialInformations",
                newName: "unpaidBalance");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "MortgageLoanOnAdditionalPropertyFinancialInformations",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "MonthlyMortagagePayment",
                table: "MortgageLoanOnAdditionalPropertyFinancialInformations",
                newName: "monthlyMortagagePayment");

            migrationBuilder.RenameColumn(
                name: "IsApplied",
                table: "MortgageLoanOnAdditionalPropertyFinancialInformations",
                newName: "isApplied");

            migrationBuilder.RenameColumn(
                name: "CreditorName",
                table: "MortgageLoanOnAdditionalPropertyFinancialInformations",
                newName: "creditorName");

            migrationBuilder.RenameColumn(
                name: "CreditLimit",
                table: "MortgageLoanOnAdditionalPropertyFinancialInformations",
                newName: "creditLimit");

            migrationBuilder.RenameColumn(
                name: "AccountNumber",
                table: "MortgageLoanOnAdditionalPropertyFinancialInformations",
                newName: "accountNumber");

            migrationBuilder.RenameColumn(
                name: "Expense",
                table: "MortgageFinancialOtherLaibilitiesTypes",
                newName: "expense");

            migrationBuilder.RenameColumn(
                name: "CashMarketValue",
                table: "MortgageFinancialOtherLaibilitiesTypes",
                newName: "cashMarketValue");

            migrationBuilder.RenameColumn(
                name: "UnpaidBalance",
                table: "MortgageFinancialLaibilitiesTypes",
                newName: "unpaidBalance");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "MortgageFinancialLaibilitiesTypes",
                newName: "companyName");

            migrationBuilder.RenameColumn(
                name: "CashMarketValue",
                table: "MortgageFinancialLaibilitiesTypes",
                newName: "cashMarketValue");

            migrationBuilder.RenameColumn(
                name: "AccountType",
                table: "MortgageFinancialLaibilitiesTypes",
                newName: "accountType");

            migrationBuilder.RenameColumn(
                name: "AccountNumber",
                table: "MortgageFinancialLaibilitiesTypes",
                newName: "accountNumber");

            migrationBuilder.RenameColumn(
                name: "CashMarketValue",
                table: "MortgageFinancialCreditTypes",
                newName: "cashMarketValue");

            migrationBuilder.RenameColumn(
                name: "AssetsCreditType",
                table: "MortgageFinancialCreditTypes",
                newName: "assetsCreditType");

            migrationBuilder.RenameColumn(
                name: "FinancialInstitution",
                table: "MortgageFinancialAccountTypes",
                newName: "financialInstitution");

            migrationBuilder.RenameColumn(
                name: "CashMarketValue",
                table: "MortgageFinancialAccountTypes",
                newName: "cashMarketValue");

            migrationBuilder.RenameColumn(
                name: "AccountType",
                table: "MortgageFinancialAccountTypes",
                newName: "accountType");

            migrationBuilder.RenameColumn(
                name: "AccountNumber",
                table: "MortgageFinancialAccountTypes",
                newName: "accountNumber");

            migrationBuilder.RenameColumn(
                name: "YourIntials",
                table: "MortgageApplicationTypeOfCredits",
                newName: "yourIntials");

            migrationBuilder.RenameColumn(
                name: "TotalBorrowers",
                table: "MortgageApplicationTypeOfCredits",
                newName: "totalBorrowers");

            migrationBuilder.RenameColumn(
                name: "ApplyingFor",
                table: "MortgageApplicationTypeOfCredits",
                newName: "applyingFor");

            migrationBuilder.RenameColumn(
                name: "SourceType",
                table: "MortgageApplicationSources",
                newName: "sourceType");

            migrationBuilder.RenameColumn(
                name: "MonthlyIncome",
                table: "MortgageApplicationSources",
                newName: "monthlyIncome");

            migrationBuilder.RenameColumn(
                name: "YesNo",
                table: "MortgageApplicationQuestions",
                newName: "yesNo");

            migrationBuilder.RenameColumn(
                name: "Question",
                table: "MortgageApplicationQuestions",
                newName: "question");

            migrationBuilder.RenameColumn(
                name: "Answer",
                table: "MortgageApplicationQuestions",
                newName: "answer");

            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "MortgageApplicationPreviousEmploymentDetails",
                newName: "zip");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "MortgageApplicationPreviousEmploymentDetails",
                newName: "unit");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "MortgageApplicationPreviousEmploymentDetails",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "MortgageApplicationPreviousEmploymentDetails",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "MortgageApplicationPreviousEmploymentDetails",
                newName: "startDate");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "MortgageApplicationPreviousEmploymentDetails",
                newName: "position");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MortgageApplicationPreviousEmploymentDetails",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "MonthlyIncome",
                table: "MortgageApplicationPreviousEmploymentDetails",
                newName: "monthlyIncome");

            migrationBuilder.RenameColumn(
                name: "IsSelfEmployed",
                table: "MortgageApplicationPreviousEmploymentDetails",
                newName: "isSelfEmployed");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "MortgageApplicationPreviousEmploymentDetails",
                newName: "endDate");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "MortgageApplicationPreviousEmploymentDetails",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "MortgageApplicationPreviousEmploymentDetails",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Suffix",
                table: "MortgageApplicationPersonalInformation",
                newName: "suffix");

            migrationBuilder.RenameColumn(
                name: "SocialSecurityNumber",
                table: "MortgageApplicationPersonalInformation",
                newName: "socialSecurityNumber");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "MortgageApplicationPersonalInformation",
                newName: "middleName");

            migrationBuilder.RenameColumn(
                name: "MarritalStatus",
                table: "MortgageApplicationPersonalInformation",
                newName: "marritalStatus");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "MortgageApplicationPersonalInformation",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "MortgageApplicationPersonalInformation",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "Dob",
                table: "MortgageApplicationPersonalInformation",
                newName: "dob");

            migrationBuilder.RenameColumn(
                name: "Dependents",
                table: "MortgageApplicationPersonalInformation",
                newName: "dependents");

            migrationBuilder.RenameColumn(
                name: "Citizenship",
                table: "MortgageApplicationPersonalInformation",
                newName: "citizenship");

            migrationBuilder.RenameColumn(
                name: "Suffix",
                table: "MortgageApplicationOtherBorrowers",
                newName: "suffix");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "MortgageApplicationOtherBorrowers",
                newName: "middleName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "MortgageApplicationOtherBorrowers",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "MortgageApplicationOtherBorrowers",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "MortgageApplicationOtherBorrowers",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "ProjectedExpirationServiceDate",
                table: "MortgageApplicationMilitaryServices",
                newName: "projectedExpirationServiceDate");

            migrationBuilder.RenameColumn(
                name: "IsSurvivingSpouse",
                table: "MortgageApplicationMilitaryServices",
                newName: "isSurvivingSpouse");

            migrationBuilder.RenameColumn(
                name: "IsServeUSForces",
                table: "MortgageApplicationMilitaryServices",
                newName: "isServeUSForces");

            migrationBuilder.RenameColumn(
                name: "IsNonActivatedMember",
                table: "MortgageApplicationMilitaryServices",
                newName: "isNonActivatedMember");

            migrationBuilder.RenameColumn(
                name: "IsCurrentlyServing",
                table: "MortgageApplicationMilitaryServices",
                newName: "isCurrentlyServing");

            migrationBuilder.RenameColumn(
                name: "IsCurrentlyRetired",
                table: "MortgageApplicationMilitaryServices",
                newName: "isCurrentlyRetired");

            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "MortgageApplicationMailingAddresses",
                newName: "zip");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "MortgageApplicationMailingAddresses",
                newName: "unit");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "MortgageApplicationMailingAddresses",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "MortgageApplicationMailingAddresses",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "MortgageApplicationMailingAddresses",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "MortgageApplicationMailingAddresses",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "IncomeType",
                table: "MortgageApplicationLoanPropertyRentalIncomes",
                newName: "incomeType");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "MortgageApplicationLoanPropertyRentalIncomes",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "MonthlyPayment",
                table: "MortgageApplicationLoanPropertyOtherNewMortgageLoans",
                newName: "monthlyPayment");

            migrationBuilder.RenameColumn(
                name: "LoanAmount",
                table: "MortgageApplicationLoanPropertyOtherNewMortgageLoans",
                newName: "loanAmount");

            migrationBuilder.RenameColumn(
                name: "LienType",
                table: "MortgageApplicationLoanPropertyOtherNewMortgageLoans",
                newName: "lienType");

            migrationBuilder.RenameColumn(
                name: "CreditorName",
                table: "MortgageApplicationLoanPropertyOtherNewMortgageLoans",
                newName: "creditorName");

            migrationBuilder.RenameColumn(
                name: "CreditLimit",
                table: "MortgageApplicationLoanPropertyOtherNewMortgageLoans",
                newName: "creditLimit");

            migrationBuilder.RenameColumn(
                name: "Occupancy",
                table: "MortgageApplicationLoanPropertyInformation",
                newName: "occupancy");

            migrationBuilder.RenameColumn(
                name: "LoanPurpose",
                table: "MortgageApplicationLoanPropertyInformation",
                newName: "loanPurpose");

            migrationBuilder.RenameColumn(
                name: "LoanAmount",
                table: "MortgageApplicationLoanPropertyInformation",
                newName: "loanAmount");

            migrationBuilder.RenameColumn(
                name: "IsMixedUseProperty",
                table: "MortgageApplicationLoanPropertyInformation",
                newName: "isMixedUseProperty");

            migrationBuilder.RenameColumn(
                name: "IsManufacturedHome",
                table: "MortgageApplicationLoanPropertyInformation",
                newName: "isManufacturedHome");

            migrationBuilder.RenameColumn(
                name: "Source",
                table: "MortgageApplicationLoanPropertyGiftsOrGrants",
                newName: "source");

            migrationBuilder.RenameColumn(
                name: "MarketValue",
                table: "MortgageApplicationLoanPropertyGiftsOrGrants",
                newName: "marketValue");

            migrationBuilder.RenameColumn(
                name: "IsDeposited",
                table: "MortgageApplicationLoanPropertyGiftsOrGrants",
                newName: "isDeposited");

            migrationBuilder.RenameColumn(
                name: "AssetType",
                table: "MortgageApplicationLoanPropertyGiftsOrGrants",
                newName: "assetType");

            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "MortgageApplicationLoanPropertyAddresses",
                newName: "zip");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "MortgageApplicationLoanPropertyAddresses",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "MortgageApplicationLoanPropertyAddresses",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "PropertyValue",
                table: "MortgageApplicationLoanPropertyAddresses",
                newName: "propertyValue");

            migrationBuilder.RenameColumn(
                name: "NumberOfUnits",
                table: "MortgageApplicationLoanPropertyAddresses",
                newName: "numberOfUnits");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "MortgageApplicationLoanPropertyAddresses",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "MortgageApplicationLoanPropertyAddresses",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "MortgageApplicationIncomeSources",
                newName: "totalAmount");

            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "MortgageApplicationFormerAddresses",
                newName: "zip");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "MortgageApplicationFormerAddresses",
                newName: "year");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "MortgageApplicationFormerAddresses",
                newName: "unit");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "MortgageApplicationFormerAddresses",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "MortgageApplicationFormerAddresses",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "Rent",
                table: "MortgageApplicationFormerAddresses",
                newName: "rent");

            migrationBuilder.RenameColumn(
                name: "Month",
                table: "MortgageApplicationFormerAddresses",
                newName: "month");

            migrationBuilder.RenameColumn(
                name: "HousingType",
                table: "MortgageApplicationFormerAddresses",
                newName: "housingType");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "MortgageApplicationFormerAddresses",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "MortgageApplicationFormerAddresses",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "MortgageApplicationEmploymentIncomeDetails",
                newName: "total");

            migrationBuilder.RenameColumn(
                name: "Overtime",
                table: "MortgageApplicationEmploymentIncomeDetails",
                newName: "overtime");

            migrationBuilder.RenameColumn(
                name: "Other",
                table: "MortgageApplicationEmploymentIncomeDetails",
                newName: "other");

            migrationBuilder.RenameColumn(
                name: "MilitaryEntitlements",
                table: "MortgageApplicationEmploymentIncomeDetails",
                newName: "militaryEntitlements");

            migrationBuilder.RenameColumn(
                name: "Commission",
                table: "MortgageApplicationEmploymentIncomeDetails",
                newName: "commission");

            migrationBuilder.RenameColumn(
                name: "Bonus",
                table: "MortgageApplicationEmploymentIncomeDetails",
                newName: "bonus");

            migrationBuilder.RenameColumn(
                name: "BaseIncome",
                table: "MortgageApplicationEmploymentIncomeDetails",
                newName: "baseIncome");

            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "MortgageApplicationEmploymentDetails",
                newName: "zip");

            migrationBuilder.RenameColumn(
                name: "WorkingYears",
                table: "MortgageApplicationEmploymentDetails",
                newName: "workingYears");

            migrationBuilder.RenameColumn(
                name: "WorkingMonths",
                table: "MortgageApplicationEmploymentDetails",
                newName: "workingMonths");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "MortgageApplicationEmploymentDetails",
                newName: "unit");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "MortgageApplicationEmploymentDetails",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "MortgageApplicationEmploymentDetails",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "MortgageApplicationEmploymentDetails",
                newName: "startDate");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "MortgageApplicationEmploymentDetails",
                newName: "position");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "MortgageApplicationEmploymentDetails",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "OwnershipShare",
                table: "MortgageApplicationEmploymentDetails",
                newName: "ownershipShare");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MortgageApplicationEmploymentDetails",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "MonthlyIncome",
                table: "MortgageApplicationEmploymentDetails",
                newName: "monthlyIncome");

            migrationBuilder.RenameColumn(
                name: "IsSelfEmployed",
                table: "MortgageApplicationEmploymentDetails",
                newName: "isSelfEmployed");

            migrationBuilder.RenameColumn(
                name: "IsOwnershipLessThan25",
                table: "MortgageApplicationEmploymentDetails",
                newName: "isOwnershipLessThan25");

            migrationBuilder.RenameColumn(
                name: "IsEmployedBySomeone",
                table: "MortgageApplicationEmploymentDetails",
                newName: "isEmployedBySomeone");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "MortgageApplicationEmploymentDetails",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "MortgageApplicationEmploymentDetails",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "DemographicInfoSource",
                table: "MortgageApplicationDemographicInformation",
                newName: "demographicInfoSource");

            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "MortgageApplicationCurrentAddresses",
                newName: "zip");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "MortgageApplicationCurrentAddresses",
                newName: "year");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "MortgageApplicationCurrentAddresses",
                newName: "unit");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "MortgageApplicationCurrentAddresses",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "MortgageApplicationCurrentAddresses",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "Rent",
                table: "MortgageApplicationCurrentAddresses",
                newName: "rent");

            migrationBuilder.RenameColumn(
                name: "Month",
                table: "MortgageApplicationCurrentAddresses",
                newName: "month");

            migrationBuilder.RenameColumn(
                name: "HousingType",
                table: "MortgageApplicationCurrentAddresses",
                newName: "housingType");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "MortgageApplicationCurrentAddresses",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "MortgageApplicationCurrentAddresses",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "WorkPhone",
                table: "MortgageApplicationContactInformation",
                newName: "workPhone");

            migrationBuilder.RenameColumn(
                name: "HomePhone",
                table: "MortgageApplicationContactInformation",
                newName: "homePhone");

            migrationBuilder.RenameColumn(
                name: "Ext",
                table: "MortgageApplicationContactInformation",
                newName: "ext");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "MortgageApplicationContactInformation",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "CellPhone",
                table: "MortgageApplicationContactInformation",
                newName: "cellPhone");

            migrationBuilder.RenameColumn(
                name: "Suffix",
                table: "MortgageApplicationAlternateNames",
                newName: "suffix");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "MortgageApplicationAlternateNames",
                newName: "middleName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "MortgageApplicationAlternateNames",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "MortgageApplicationAlternateNames",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "IsAgreeAgreement",
                table: "MortgageApplicationAgreements",
                newName: "isAgreeAgreement");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails",
                newName: "total");

            migrationBuilder.RenameColumn(
                name: "Overtime",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails",
                newName: "overtime");

            migrationBuilder.RenameColumn(
                name: "Others",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails",
                newName: "others");

            migrationBuilder.RenameColumn(
                name: "MilitaryEntitlements",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails",
                newName: "militaryEntitlements");

            migrationBuilder.RenameColumn(
                name: "Commission",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails",
                newName: "commission");

            migrationBuilder.RenameColumn(
                name: "Bonus",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails",
                newName: "bonus");

            migrationBuilder.RenameColumn(
                name: "BaseIncome",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails",
                newName: "baseIncome");

            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "zip");

            migrationBuilder.RenameColumn(
                name: "WorkingYears",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "workingYears");

            migrationBuilder.RenameColumn(
                name: "WorkingMonths",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "workingMonths");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "unit");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "startDate");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "position");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "OwnershipShare",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "ownershipShare");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "MonthlyIncome",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "monthlyIncome");

            migrationBuilder.RenameColumn(
                name: "IsSelfEmployed",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "isSelfEmployed");

            migrationBuilder.RenameColumn(
                name: "IsOwnershipLessThan25",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "isOwnershipLessThan25");

            migrationBuilder.RenameColumn(
                name: "IsEmployedBySomeone",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "isEmployedBySomeone");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "MortgageAppliactionFinancialLiabilities",
                newName: "totalAmount");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "MortgageAppliactionFinancialCredits",
                newName: "totalAmount");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "MortgageAppliactionFinancialAccounts",
                newName: "totalAmount");

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 16, 7, 33, 200, DateTimeKind.Local).AddTicks(8247));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 16, 7, 33, 200, DateTimeKind.Local).AddTicks(8259));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 16, 7, 33, 200, DateTimeKind.Local).AddTicks(8260));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 16, 7, 33, 200, DateTimeKind.Local).AddTicks(8261));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 16, 7, 33, 200, DateTimeKind.Local).AddTicks(8262));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 16, 7, 33, 200, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 16, 7, 33, 200, DateTimeKind.Local).AddTicks(8264));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 16, 7, 33, 200, DateTimeKind.Local).AddTicks(8265));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 16, 7, 33, 200, DateTimeKind.Local).AddTicks(8281));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 16, 7, 33, 200, DateTimeKind.Local).AddTicks(8283));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 16, 7, 33, 200, DateTimeKind.Local).AddTicks(8284));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 16, 7, 33, 200, DateTimeKind.Local).AddTicks(8285));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 16, 7, 33, 200, DateTimeKind.Local).AddTicks(8286));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 16, 7, 33, 200, DateTimeKind.Local).AddTicks(8556));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 16, 7, 33, 200, DateTimeKind.Local).AddTicks(8560));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 16, 7, 33, 200, DateTimeKind.Local).AddTicks(8561));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 16, 7, 33, 200, DateTimeKind.Local).AddTicks(8562));

            migrationBuilder.UpdateData(
                table: "Sitesettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 16, 7, 33, 200, DateTimeKind.Local).AddTicks(8595));
        }
    }
}
