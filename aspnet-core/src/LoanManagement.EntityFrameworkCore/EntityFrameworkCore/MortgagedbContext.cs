using System;
using System.Collections.Generic;
using Abp.Zero.EntityFrameworkCore;
using LoanManagement.Authorization.Roles;
using LoanManagement.Authorization.Users;
using LoanManagement.Entities.Models;
using LoanManagement.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LoanManagement.EntityFrameworkCore
{
    public partial class MortgagedbContext : DbContext
    {
        public MortgagedbContext(DbContextOptions<MortgagedbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Application> Applications { get; set; } = null!;
        public virtual DbSet<ApplicationAdditionalEmployementDetail> ApplicationAdditionalEmployementDetails { get; set; } = null!;
        public virtual DbSet<ApplicationAdditionalEmployementIncomeDetail> ApplicationAdditionalEmployementIncomeDetails { get; set; } = null!;
        public virtual DbSet<ApplicationDeclarationQuestion> ApplicationDeclarationQuestions { get; set; } = null!;
        public virtual DbSet<ApplicationEmployementDetail> ApplicationEmployementDetails { get; set; } = null!;
        public virtual DbSet<ApplicationEmployementIncomeDetail> ApplicationEmployementIncomeDetails { get; set; } = null!;
        public virtual DbSet<ApplicationFinancialAsset> ApplicationFinancialAssets { get; set; } = null!;
        public virtual DbSet<ApplicationFinancialLaibility> ApplicationFinancialLaibilities { get; set; } = null!;
        public virtual DbSet<ApplicationFinancialOtherAsset> ApplicationFinancialOtherAssets { get; set; } = null!;
        public virtual DbSet<ApplicationFinancialOtherLaibility> ApplicationFinancialOtherLaibilities { get; set; } = null!;
        public virtual DbSet<ApplicationFinancialRealEstate> ApplicationFinancialRealEstates { get; set; } = null!;
        public virtual DbSet<ApplicationIncomeSource> ApplicationIncomeSources { get; set; } = null!;
        public virtual DbSet<ApplicationPersonalInformation> ApplicationPersonalInformations { get; set; } = null!;
        public virtual DbSet<ApplicationPreviousEmployementDetail> ApplicationPreviousEmployementDetails { get; set; } = null!;
        public virtual DbSet<AdminDisclosure> AdminDisclosures { get; set; }
        public virtual DbSet<AdminLoanapplicationdocument> AdminLoanapplicationdocuments { get; set; }
        public virtual DbSet<AdminLoandetail> AdminLoandetails { get; set; }
        public virtual DbSet<AdminLoanprogram> AdminLoanprograms { get; set; }
        public virtual DbSet<AdminLoanstatus> AdminLoanstatuses { get; set; }
        public virtual DbSet<AdminLoansummarystatus> AdminLoansummarystatuses { get; set; }
        public virtual DbSet<AdminNotificationtype> AdminNotificationtypes { get; set; }
        public virtual DbSet<AdminUser> AdminUsers { get; set; }
        public virtual DbSet<AdminUserenableddevice> AdminUserenableddevices { get; set; }
        public virtual DbSet<AdminUsernotification> AdminUsernotifications { get; set; }
        public virtual DbSet<CitizenshipType> CitizenshipTypes { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<CreditType> CreditTypes { get; set; } = null!;
        public virtual DbSet<DeclarationCategory> DeclarationCategories { get; set; } = null!;
        public virtual DbSet<DeclarationQuestion> DeclarationQuestions { get; set; } = null!;
        public virtual DbSet<DemographicInfoSource> DemographicInfoSources { get; set; } = null!;
        public virtual DbSet<DemographicInformation> DemographicInformations { get; set; } = null!;
        public virtual DbSet<FinancialAccountType> FinancialAccountTypes { get; set; } = null!;
        public virtual DbSet<FinancialAssetsType> FinancialAssetsTypes { get; set; } = null!;
        public virtual DbSet<FinancialLaibilitiesType> FinancialLaibilitiesTypes { get; set; } = null!;
        public virtual DbSet<FinancialOtherLaibilitiesType> FinancialOtherLaibilitiesTypes { get; set; } = null!;
        public virtual DbSet<FinancialPropertyIntendedOccupancy> FinancialPropertyIntendedOccupancies { get; set; } = null!;
        public virtual DbSet<FinancialPropertyStatus> FinancialPropertyStatuses { get; set; } = null!;
        public virtual DbSet<HousingType> HousingTypes { get; set; } = null!;
        public virtual DbSet<IncomeSource> IncomeSources { get; set; } = null!;
        public virtual DbSet<IncomeType> IncomeTypes { get; set; } = null!;
        public virtual DbSet<LoanAndPropertyInformation> LoanAndPropertyInformations { get; set; } = null!;
        public virtual DbSet<LoanAndPropertyInformationGift> LoanAndPropertyInformationGifts { get; set; } = null!;
        public virtual DbSet<LoanAndPropertyInformationOtherMortageLoan> LoanAndPropertyInformationOtherMortageLoans { get; set; } = null!;
        public virtual DbSet<LoanAndPropertyInformationRentalIncome> LoanAndPropertyInformationRentalIncomes { get; set; } = null!;
        public virtual DbSet<LoanOriginatorInformation> LoanOriginatorInformations { get; set; } = null!;
        public virtual DbSet<LoanPropertyGiftType> LoanPropertyGiftTypes { get; set; } = null!;
        public virtual DbSet<LoanPropertyOccupancy> LoanPropertyOccupancies { get; set; } = null!;
        public virtual DbSet<MaritialStatus> MaritialStatuses { get; set; } = null!;
        public virtual DbSet<MilitaryService> MilitaryServices { get; set; } = null!;
        public virtual DbSet<MortageLoanOnProperty> MortageLoanOnProperties { get; set; } = null!;
        public virtual DbSet<MortageLoanType> MortageLoanTypes { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
        public virtual DbSet<LeadApplicationDetailPurchasing> LeadApplicationDetailPurchasings { get; set; }
        public virtual DbSet<LeadApplicationDetailRefinancing> LeadApplicationDetailRefinancings { get; set; }
        public virtual DbSet<LeadApplicationQuestion> LeadApplicationQuestions { get; set; }
        public virtual DbSet<LeadApplicationType> LeadApplicationTypes { get; set; }
        public virtual DbSet<LeadAssetsDetail> LeadAssetsDetails { get; set; }
        public virtual DbSet<LeadAssetsType> LeadAssetsTypes { get; set; }
        public virtual DbSet<LeadEmployementDetail> LeadEmployementDetails { get; set; }
        public virtual DbSet<LeadEmployementType> LeadEmployementTypes { get; set; }
        public virtual DbSet<LeadIncomeType> LeadIncomeTypes { get; set; }
        public virtual DbSet<LeadOwnerType> LeadOwnerTypes { get; set; }
        public virtual DbSet<LeadQuestionAnswer> LeadQuestionAnswers { get; set; }
        public virtual DbSet<LeadRefinancingIncomeDetail> LeadRefinancingIncomeDetails { get; set; }
        public virtual DbSet<LeadTaxesType> LeadTaxesTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("Server=127.0.0.1; Database=test30; Uid=root; Pwd=; Port=3306;default command timeout=360;", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.7.3-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Application>(entity =>
            {
                entity.ToTable("applications");

                entity.HasIndex(e => e.CreditTypeId, "CREDIT_TYPE_ID");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.AgencyCaseNoB2)
                    .HasMaxLength(15)
                    .HasColumnName("AGENCY_CASE_NO_B2")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.CreditTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("CREDIT_TYPE_ID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime(3)")
                    .HasColumnName("DATE");

                entity.Property(e => e.Initials)
                    .HasMaxLength(10)
                    .HasColumnName("INITIALS")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.LoanNoIdentifierB1B3)
                    .HasMaxLength(15)
                    .HasColumnName("LOAN NO_IDENTIFIER_B1_B3")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.TotalBorrowers1a6)
                    .HasColumnType("int(11)")
                    .HasColumnName("TOTAL_BORROWERS_1A.6");

                entity.HasOne(d => d.CreditType)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.CreditTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("applications_ibfk_1");
            });

            modelBuilder.Entity<ApplicationAdditionalEmployementDetail>(entity =>
            {
                entity.ToTable("application_additional_employement_details");

                entity.HasIndex(e => e.ApplicationPersonalInformationId, "APPLICATION_PERSONAL_INFORMATION_ID");

                entity.HasIndex(e => e.CityId, "CITY_ID");

                entity.HasIndex(e => e.CountryId, "COUNTRY_ID");

                entity.HasIndex(e => e.StateId, "STATE_ID");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.ApplicationPersonalInformationId)
                    .HasColumnType("int(11)")
                    .HasColumnName("APPLICATION_PERSONAL_INFORMATION_ID");

                entity.Property(e => e.CityId)
                    .HasColumnType("int(11)")
                    .HasColumnName("CITY_ID");

                entity.Property(e => e.CountryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("COUNTRY_ID");

                entity.Property(e => e.EmployerBusinessName)
                    .HasMaxLength(100)
                    .HasColumnName("EMPLOYER/BUSINESS_NAME")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.IsEmployedBySomeone)
                    .HasColumnType("bit(1)")
                    .HasColumnName("IS_EMPLOYED_BY_SOMEONE");

                entity.Property(e => e.IsOwnershipLessThan25)
                    .HasColumnType("bit(1)")
                    .HasColumnName("IS_OWNERSHIP_LESS_THAN_25");

                entity.Property(e => e.IsSelfEmployed)
                    .HasColumnType("bit(1)")
                    .HasColumnName("IS_SELF_EMPLOYED");

                entity.Property(e => e.MonthlyIncome).HasColumnName("MONTHLY_INCOME");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("PHONE")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PositionTitle)
                    .HasMaxLength(100)
                    .HasColumnName("POSITION_TITLE")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.StateId)
                    .HasColumnType("int(11)")
                    .HasColumnName("STATE_ID");

                entity.Property(e => e.Street)
                    .HasMaxLength(100)
                    .HasColumnName("STREET")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Unit)
                    .HasMaxLength(20)
                    .HasColumnName("UNIT")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.WorkingMonths)
                    .HasColumnType("int(11)")
                    .HasColumnName("WORKING_MONTHS");

                entity.Property(e => e.WorkingYears)
                    .HasColumnType("int(11)")
                    .HasColumnName("WORKING_YEARS");

                entity.Property(e => e.Zip)
                    .HasMaxLength(10)
                    .HasColumnName("ZIP")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.HasOne(d => d.ApplicationPersonalInformation)
                    .WithMany(p => p.ApplicationAdditionalEmployementDetails)
                    .HasForeignKey(d => d.ApplicationPersonalInformationId)
                    .HasConstraintName("application_additional_employement_details_ibfk_1");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.ApplicationAdditionalEmployementDetails)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_additional_employement_details_ibfk_4");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.ApplicationAdditionalEmployementDetails)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_additional_employement_details_ibfk_2");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.ApplicationAdditionalEmployementDetails)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_additional_employement_details_ibfk_3");
            });

            modelBuilder.Entity<ApplicationAdditionalEmployementIncomeDetail>(entity =>
            {
                entity.ToTable("application_additional_employement_income_details");

                entity.HasIndex(e => e.ApplicationAdditionalEmployementDetails, "APPLICATION_ADDITIONAL_EMPLOYEMENT_DETAILS");

                entity.HasIndex(e => e.IncomeTypeId, "INCOME_TYPE_ID");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnName("AMOUNT");

                entity.Property(e => e.ApplicationAdditionalEmployementDetails)
                    .HasColumnType("int(11)")
                    .HasColumnName("APPLICATION_ADDITIONAL_EMPLOYEMENT_DETAILS");

                entity.Property(e => e.IncomeTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("INCOME_TYPE_ID");

                entity.HasOne(d => d.ApplicationAdditionalEmployementDetailsNavigation)
                    .WithMany(p => p.ApplicationAdditionalEmployementIncomeDetails)
                    .HasForeignKey(d => d.ApplicationAdditionalEmployementDetails)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_additional_employement_income_details_ibfk_1");

                entity.HasOne(d => d.IncomeType)
                    .WithMany(p => p.ApplicationAdditionalEmployementIncomeDetails)
                    .HasForeignKey(d => d.IncomeTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_additional_employement_income_details_ibfk_2");
            });

            modelBuilder.Entity<ApplicationDeclarationQuestion>(entity =>
            {
                entity.ToTable("application_declaration_questions");

                entity.HasIndex(e => e.ApplicationPersonalInformationId, "APPLICATION_PERSONAL_INFORMATION_ID");

                entity.HasIndex(e => e.DeclarationQuestionId, "DECLARATION_QUESTION_ID");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.ApplicationPersonalInformationId)
                    .HasColumnType("int(11)")
                    .HasColumnName("APPLICATION_PERSONAL_INFORMATION_ID");

                entity.Property(e => e.DeclarationQuestionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("DECLARATION_QUESTION_ID");

                entity.Property(e => e.Description5a)
                    .HasMaxLength(500)
                    .HasColumnName("DESCRIPTION_5A")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.YesNo)
                    .HasColumnType("bit(1)")
                    .HasColumnName("YES_NO");

                entity.HasOne(d => d.ApplicationPersonalInformation)
                    .WithMany(p => p.ApplicationDeclarationQuestions)
                    .HasForeignKey(d => d.ApplicationPersonalInformationId)
                    .HasConstraintName("application_declaration_questions_ibfk_1");

                entity.HasOne(d => d.DeclarationQuestion)
                    .WithMany(p => p.ApplicationDeclarationQuestions)
                    .HasForeignKey(d => d.DeclarationQuestionId)
                    .HasConstraintName("application_declaration_questions_ibfk_2");
            });

            modelBuilder.Entity<ApplicationEmployementDetail>(entity =>
            {
                entity.ToTable("application_employement_details");

                entity.HasIndex(e => e.ApplicationPersonalInformationId, "APPLICATION_PERSONAL_INFORMATION_ID");

                entity.HasIndex(e => e.CityId1b43, "CITY_ID_1B.4.3");

                entity.HasIndex(e => e.CountryId1b46, "COUNTRY_ID_1B.4.6");

                entity.HasIndex(e => e.StateId1b44, "STATE_ID_1B.4.4");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.ApplicationPersonalInformationId)
                    .HasColumnType("int(11)")
                    .HasColumnName("APPLICATION_PERSONAL_INFORMATION_ID");

                entity.Property(e => e.CityId1b43)
                    .HasColumnType("int(11)")
                    .HasColumnName("CITY_ID_1B.4.3");

                entity.Property(e => e.CountryId1b46)
                    .HasColumnType("int(11)")
                    .HasColumnName("COUNTRY_ID_1B.4.6");

                entity.Property(e => e.EmployerBusinessName1b2)
                    .HasMaxLength(100)
                    .HasColumnName("EMPLOYER/BUSINESS_NAME_1B.2")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.IsEmployedBySomeone1b8)
                    .HasColumnType("bit(1)")
                    .HasColumnName("IS_EMPLOYED_BY_SOMEONE_1B.8");

                entity.Property(e => e.IsOwnershipLessThan251b91)
                    .HasColumnType("bit(1)")
                    .HasColumnName("IS_OWNERSHIP_LESS_THAN_25_1B.9.1");

                entity.Property(e => e.IsSelfEmployed1b9)
                    .HasColumnType("bit(1)")
                    .HasColumnName("IS_SELF_EMPLOYED_1B.9");

                entity.Property(e => e.MonthlyIncome1b92).HasColumnName("MONTHLY_INCOME_1B.9.2");

                entity.Property(e => e.Phone1b3)
                    .HasMaxLength(20)
                    .HasColumnName("PHONE_1B.3")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PositionTitle1b5)
                    .HasMaxLength(100)
                    .HasColumnName("POSITION_TITLE_1B.5")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.StartDate1b6)
                    .HasColumnType("datetime")
                    .HasColumnName("START_DATE_1B.6");

                entity.Property(e => e.StateId1b44)
                    .HasColumnType("int(11)")
                    .HasColumnName("STATE_ID_1B.4.4");

                entity.Property(e => e.Street1b41)
                    .HasMaxLength(100)
                    .HasColumnName("STREET_1B.4.1")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Unit1b42)
                    .HasMaxLength(20)
                    .HasColumnName("UNIT_1B.4.2")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.WorkingMonths)
                    .HasColumnType("int(11)")
                    .HasColumnName("WORKING_MONTHS");

                entity.Property(e => e.WorkingYears1b7)
                    .HasColumnType("int(11)")
                    .HasColumnName("WORKING_YEARS_1B.7");

                entity.Property(e => e.Zip1b45)
                    .HasMaxLength(10)
                    .HasColumnName("ZIP_1B.4.5")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.HasOne(d => d.ApplicationPersonalInformation)
                    .WithMany(p => p.ApplicationEmployementDetails)
                    .HasForeignKey(d => d.ApplicationPersonalInformationId)
                    .HasConstraintName("application_employement_details_ibfk_1");

                entity.HasOne(d => d.CityId1b43Navigation)
                    .WithMany(p => p.ApplicationEmployementDetails)
                    .HasForeignKey(d => d.CityId1b43)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_employement_details_ibfk_4");

                entity.HasOne(d => d.CountryId1b46Navigation)
                    .WithMany(p => p.ApplicationEmployementDetails)
                    .HasForeignKey(d => d.CountryId1b46)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_employement_details_ibfk_2");

                entity.HasOne(d => d.StateId1b44Navigation)
                    .WithMany(p => p.ApplicationEmployementDetails)
                    .HasForeignKey(d => d.StateId1b44)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_employement_details_ibfk_3");
            });

            modelBuilder.Entity<ApplicationEmployementIncomeDetail>(entity =>
            {
                entity.ToTable("application_employement_income_details");

                entity.HasIndex(e => e.ApplicationEmployementDetailsId, "APPLICATION_EMPLOYEMENT_DETAILS_ID");

                entity.HasIndex(e => e.IncomeTypeId1b101, "INCOME_TYPE_ID_1B.10.1");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Amount1b10).HasColumnName("AMOUNT_1B.10");

                entity.Property(e => e.ApplicationEmployementDetailsId)
                    .HasColumnType("int(11)")
                    .HasColumnName("APPLICATION_EMPLOYEMENT_DETAILS_ID");

                entity.Property(e => e.IncomeTypeId1b101)
                    .HasColumnType("int(11)")
                    .HasColumnName("INCOME_TYPE_ID_1B.10.1");

                entity.HasOne(d => d.ApplicationEmployementDetails)
                    .WithMany(p => p.ApplicationEmployementIncomeDetails)
                    .HasForeignKey(d => d.ApplicationEmployementDetailsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_employement_income_details_ibfk_1");

                entity.HasOne(d => d.IncomeTypeId1b101Navigation)
                    .WithMany(p => p.ApplicationEmployementIncomeDetails)
                    .HasForeignKey(d => d.IncomeTypeId1b101)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_employement_income_details_ibfk_2");
            });

            modelBuilder.Entity<ApplicationFinancialAsset>(entity =>
            {
                entity.ToTable("application_financial_assets");

                entity.HasIndex(e => e.ApplicationPersonalInformationId, "APPLICATION_PERSONAL_INFORMATION_ID");

                entity.HasIndex(e => e.FinancialAccountTypeId2a1, "FINANCIAL_ACCOUNT_TYPE_ID_2A.1");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.AccountNumber2a3)
                    .HasMaxLength(50)
                    .HasColumnName("ACCOUNT_NUMBER_2A.3")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.ApplicationPersonalInformationId)
                    .HasColumnType("int(11)")
                    .HasColumnName("APPLICATION_PERSONAL_INFORMATION_ID");

                entity.Property(e => e.FinancialAccountTypeId2a1)
                    .HasColumnType("int(11)")
                    .HasColumnName("FINANCIAL_ACCOUNT_TYPE_ID_2A.1");

                entity.Property(e => e.FinancialInstitution2a2)
                    .HasMaxLength(50)
                    .HasColumnName("FINANCIAL_INSTITUTION_2A.2")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Value2a4).HasColumnName("VALUE_2A.4");

                entity.HasOne(d => d.ApplicationPersonalInformation)
                    .WithMany(p => p.ApplicationFinancialAssets)
                    .HasForeignKey(d => d.ApplicationPersonalInformationId)
                    .HasConstraintName("application_financial_assets_ibfk_1");

                entity.HasOne(d => d.FinancialAccountTypeId2a1Navigation)
                    .WithMany(p => p.ApplicationFinancialAssets)
                    .HasForeignKey(d => d.FinancialAccountTypeId2a1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_financial_assets_ibfk_2");
            });

            modelBuilder.Entity<ApplicationFinancialLaibility>(entity =>
            {
                entity.ToTable("application_financial_laibilities");

                entity.HasIndex(e => e.ApplicationPersonalInformationId, "APPLICATION_PERSONAL_INFORMATION_ID");

                entity.HasIndex(e => e.FinancialLaibilitiesType2c1, "FINANCIAL_LAIBILITIES_TYPE_2C.1");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.AccountNumber2c3)
                    .HasMaxLength(50)
                    .HasColumnName("ACCOUNT_NUMBER_2C.3")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.ApplicationPersonalInformationId)
                    .HasColumnType("int(11)")
                    .HasColumnName("APPLICATION_PERSONAL_INFORMATION_ID");

                entity.Property(e => e.CompanyName2c2)
                    .HasMaxLength(50)
                    .HasColumnName("COMPANY_NAME_2C.2")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.FinancialLaibilitiesType2c1)
                    .HasColumnType("int(11)")
                    .HasColumnName("FINANCIAL_LAIBILITIES_TYPE_2C.1");

                entity.Property(e => e.MonthlyValue2c6).HasColumnName("MONTHLY_VALUE_2C.6");

                entity.Property(e => e.PaidOff2c5)
                    .HasColumnType("bit(1)")
                    .HasColumnName("PAID_OFF_2C.5");

                entity.Property(e => e.UnpaidBalance2c4).HasColumnName("UNPAID_BALANCE_2C.4");

                entity.HasOne(d => d.ApplicationPersonalInformation)
                    .WithMany(p => p.ApplicationFinancialLaibilities)
                    .HasForeignKey(d => d.ApplicationPersonalInformationId)
                    .HasConstraintName("application_financial_laibilities_ibfk_1");

                entity.HasOne(d => d.FinancialLaibilitiesType2c1Navigation)
                    .WithMany(p => p.ApplicationFinancialLaibilities)
                    .HasForeignKey(d => d.FinancialLaibilitiesType2c1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_financial_laibilities_ibfk_2");
            });

            modelBuilder.Entity<ApplicationFinancialOtherAsset>(entity =>
            {
                entity.ToTable("application_financial_other_assets");

                entity.HasIndex(e => e.ApplicationPersonalInformationId, "APPLICATION_PERSONAL_INFORMATION_ID");

                entity.HasIndex(e => e.FinancialAssetsTypesId2b1, "FINANCIAL_ASSETS_TYPES_ID_2B.1");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.ApplicationPersonalInformationId)
                    .HasColumnType("int(11)")
                    .HasColumnName("APPLICATION_PERSONAL_INFORMATION_ID");

                entity.Property(e => e.FinancialAssetsTypesId2b1)
                    .HasColumnType("int(11)")
                    .HasColumnName("FINANCIAL_ASSETS_TYPES_ID_2B.1");

                entity.Property(e => e.Value2b2).HasColumnName("VALUE_2B.2");

                entity.HasOne(d => d.ApplicationPersonalInformation)
                    .WithMany(p => p.ApplicationFinancialOtherAssets)
                    .HasForeignKey(d => d.ApplicationPersonalInformationId)
                    .HasConstraintName("application_financial_other_assets_ibfk_1");

                entity.HasOne(d => d.FinancialAssetsTypesId2b1Navigation)
                    .WithMany(p => p.ApplicationFinancialOtherAssets)
                    .HasForeignKey(d => d.FinancialAssetsTypesId2b1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_financial_other_assets_ibfk_2");
            });

            modelBuilder.Entity<ApplicationFinancialOtherLaibility>(entity =>
            {
                entity.ToTable("application_financial_other_laibilities");

                entity.HasIndex(e => e.ApplicationPersonalInformationId, "APPLICATION_PERSONAL_INFORMATION_ID");

                entity.HasIndex(e => e.FinancialOtherLaibilitiesTypeId2d1, "FINANCIAL_OTHER_LAIBILITIES_TYPE_ID_2D.1");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.ApplicationPersonalInformationId)
                    .HasColumnType("int(11)")
                    .HasColumnName("APPLICATION_PERSONAL_INFORMATION_ID");

                entity.Property(e => e.FinancialOtherLaibilitiesTypeId2d1)
                    .HasColumnType("int(11)")
                    .HasColumnName("FINANCIAL_OTHER_LAIBILITIES_TYPE_ID_2D.1");

                entity.Property(e => e.MonthlyPayment2d2).HasColumnName("MONTHLY_PAYMENT_2D.2");

                entity.HasOne(d => d.ApplicationPersonalInformation)
                    .WithMany(p => p.ApplicationFinancialOtherLaibilities)
                    .HasForeignKey(d => d.ApplicationPersonalInformationId)
                    .HasConstraintName("application_financial_other_laibilities_ibfk_1");

                entity.HasOne(d => d.FinancialOtherLaibilitiesTypeId2d1Navigation)
                    .WithMany(p => p.ApplicationFinancialOtherLaibilities)
                    .HasForeignKey(d => d.FinancialOtherLaibilitiesTypeId2d1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_financial_other_laibilities_ibfk_2");
            });

            modelBuilder.Entity<ApplicationFinancialRealEstate>(entity =>
            {
                entity.ToTable("application_financial_real_estate");

                entity.HasIndex(e => e.ApplicationPersonalInformationId, "APPLICATION_PERSONAL_INFORMATION_ID");

                entity.HasIndex(e => e.CityId3a23, "CITY_ID_3A.2.3");

                entity.HasIndex(e => e.CountryId3a26, "COUNTRY_ID_3A.2.6");

                entity.HasIndex(e => e.FinancialPropertyIntendedOccupancyId3a5, "FINANCIAL_PROPERTY_INTENDED_OCCUPANCY_ID_3A.5");

                entity.HasIndex(e => e.FinancialPropertyStatusId3a4, "FINANCIAL_PROPERTY_STATUS_ID_3A.4");

                entity.HasIndex(e => e.StateId3a24, "STATE_ID_3A.2.4");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.ApplicationPersonalInformationId)
                    .HasColumnType("int(11)")
                    .HasColumnName("APPLICATION_PERSONAL_INFORMATION_ID");

                entity.Property(e => e.CityId3a23)
                    .HasColumnType("int(11)")
                    .HasColumnName("CITY_ID_3A.2.3");

                entity.Property(e => e.CountryId3a26)
                    .HasColumnType("int(11)")
                    .HasColumnName("COUNTRY_ID_3A.2.6");

                entity.Property(e => e.FinancialPropertyIntendedOccupancyId3a5)
                    .HasColumnType("int(11)")
                    .HasColumnName("FINANCIAL_PROPERTY_INTENDED_OCCUPANCY_ID_3A.5");

                entity.Property(e => e.FinancialPropertyStatusId3a4)
                    .HasColumnType("int(11)")
                    .HasColumnName("FINANCIAL_PROPERTY_STATUS_ID_3A.4");

                entity.Property(e => e.MonthlyMortagePayment3a6).HasColumnName("MONTHLY_MORTAGE_PAYMENT_3A.6");

                entity.Property(e => e.MonthlyRentalIncome3a7).HasColumnName("MONTHLY_RENTAL_INCOME_3A.7");

                entity.Property(e => e.NetMonthlyRentalIncome3a8).HasColumnName("NET_MONTHLY_RENTAL_INCOME_3A.8");

                entity.Property(e => e.PropertyValue3a3).HasColumnName("PROPERTY_VALUE_3A.3");

                entity.Property(e => e.StateId3a24)
                    .HasColumnType("int(11)")
                    .HasColumnName("STATE_ID_3A.2.4");

                entity.Property(e => e.Street3a21)
                    .HasMaxLength(100)
                    .HasColumnName("STREET_3A.2.1")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.UnitNo3a22)
                    .HasMaxLength(10)
                    .HasColumnName("UNIT_NO_3A.2.2")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Zip3a25)
                    .HasMaxLength(10)
                    .HasColumnName("ZIP_3A.2.5")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.HasOne(d => d.ApplicationPersonalInformation)
                    .WithMany(p => p.ApplicationFinancialRealEstates)
                    .HasForeignKey(d => d.ApplicationPersonalInformationId)
                    .HasConstraintName("application_financial_real_estate_ibfk_1");

                entity.HasOne(d => d.CityId3a23Navigation)
                    .WithMany(p => p.ApplicationFinancialRealEstates)
                    .HasForeignKey(d => d.CityId3a23)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_financial_real_estate_ibfk_4");

                entity.HasOne(d => d.CountryId3a26Navigation)
                    .WithMany(p => p.ApplicationFinancialRealEstates)
                    .HasForeignKey(d => d.CountryId3a26)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_financial_real_estate_ibfk_2");

                entity.HasOne(d => d.FinancialPropertyIntendedOccupancyId3a5Navigation)
                    .WithMany(p => p.ApplicationFinancialRealEstates)
                    .HasForeignKey(d => d.FinancialPropertyIntendedOccupancyId3a5)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_financial_real_estate_ibfk_6");

                entity.HasOne(d => d.FinancialPropertyStatusId3a4Navigation)
                    .WithMany(p => p.ApplicationFinancialRealEstates)
                    .HasForeignKey(d => d.FinancialPropertyStatusId3a4)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_financial_real_estate_ibfk_5");

                entity.HasOne(d => d.StateId3a24Navigation)
                    .WithMany(p => p.ApplicationFinancialRealEstates)
                    .HasForeignKey(d => d.StateId3a24)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_financial_real_estate_ibfk_3");
            });

            modelBuilder.Entity<ApplicationIncomeSource>(entity =>
            {
                entity.ToTable("application_income_sources");

                entity.HasIndex(e => e.ApplicationPersonalInformationId, "APPLICATION_PERSONAL_INFORMATION_ID");

                entity.HasIndex(e => e.IncomeSourceId1e1, "INCOME_SOURCE_ID_1E.1");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Amount1e2).HasColumnName("AMOUNT_1E.2");

                entity.Property(e => e.ApplicationPersonalInformationId)
                    .HasColumnType("int(11)")
                    .HasColumnName("APPLICATION_PERSONAL_INFORMATION_ID");

                entity.Property(e => e.IncomeSourceId1e1)
                    .HasColumnType("int(11)")
                    .HasColumnName("INCOME_SOURCE_ID_1E.1");

                entity.HasOne(d => d.ApplicationPersonalInformation)
                    .WithMany(p => p.ApplicationIncomeSources)
                    .HasForeignKey(d => d.ApplicationPersonalInformationId)
                    .HasConstraintName("application_income_sources_ibfk_1");

                entity.HasOne(d => d.IncomeSourceId1e1Navigation)
                    .WithMany(p => p.ApplicationIncomeSources)
                    .HasForeignKey(d => d.IncomeSourceId1e1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_income_sources_ibfk_2");
            });

            modelBuilder.Entity<ApplicationPersonalInformation>(entity =>
            {
                entity.ToTable("application_personal_information");

                entity.HasIndex(e => e.ApplicationId, "APPLICATION_ID");

                entity.HasIndex(e => e.CitizenshipTypeId1a5, "CITIZENSHIP_TYPE_ID_1A.5");

                entity.HasIndex(e => e.CurrentCityId1a133, "CURRENT_CITY_ID_1A.13.3");

                entity.HasIndex(e => e.CurrentCountryId1a136, "CURRENT_COUNTRY_ID_1A.13.6");

                entity.HasIndex(e => e.CurrentHousingTypeId1a141, "CURRENT_HOUSING_TYPE_ID_1A.14.1");

                entity.HasIndex(e => e.CurrentStateId1a134, "CURRENT_STATE_ID_1A.13.4");

                entity.HasIndex(e => e.FormerCityId1a153, "FORMER_CITY_ID_1A.15.3");

                entity.HasIndex(e => e.FormerCountryId1a156, "FORMER_COUNTRY_ID_1A.15.6");

                entity.HasIndex(e => e.FormerHousingTypeId1a161, "FORMER_HOUSING_TYPE_ID_1A.16.1");

                entity.HasIndex(e => e.FormerStateId1a154, "FORMER_STATE_ID_1A.15.4");

                entity.HasIndex(e => e.MailingCityId1a173, "MAILING_CITY_ID_1A.17.3");

                entity.HasIndex(e => e.MailingCountryId1a176, "MAILING_COUNTRY_ID_1A.17.6");

                entity.HasIndex(e => e.MailingStateId1a174, "MAILING_STATE_ID_1A.17.4");

                entity.HasIndex(e => e.MaritialStatusId1a7, "MARITIAL_STATUS_ID_1A.7");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Ages1a81)
                    .HasMaxLength(50)
                    .HasColumnName("AGES_1A.8.1")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.AlternateFirstName1a21)
                    .HasMaxLength(200)
                    .HasColumnName("ALTERNATE_FIRST_NAME_1A.2.1")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.AlternateLastName1a23)
                    .HasMaxLength(200)
                    .HasColumnName("ALTERNATE_LAST_NAME_1A.2.3")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.AlternateMiddleName1a22)
                    .HasMaxLength(200)
                    .HasColumnName("ALTERNATE_MIDDLE_NAME_1A.2.2")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.AlternateSuffix1a24)
                    .HasMaxLength(200)
                    .HasColumnName("ALTERNATE_SUFFIX_1A.2.4")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.ApplicationId)
                    .HasColumnType("int(11)")
                    .HasColumnName("APPLICATION_ID");

                entity.Property(e => e.CellPhone1a10)
                    .HasMaxLength(20)
                    .HasColumnName("CELL_PHONE_1A.10")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.CitizenshipTypeId1a5)
                    .HasColumnType("int(11)")
                    .HasColumnName("CITIZENSHIP_TYPE_ID_1A.5");

                entity.Property(e => e.CurrentCityId1a133)
                    .HasColumnType("int(11)")
                    .HasColumnName("CURRENT_CITY_ID_1A.13.3");

                entity.Property(e => e.CurrentCountryId1a136)
                    .HasColumnType("int(11)")
                    .HasColumnName("CURRENT_COUNTRY_ID_1A.13.6");

                entity.Property(e => e.CurrentHousingTypeId1a141)
                    .HasColumnType("int(11)")
                    .HasColumnName("CURRENT_HOUSING_TYPE_ID_1A.14.1");

                entity.Property(e => e.CurrentMonths1a15)
                    .HasColumnType("int(11)")
                    .HasColumnName("CURRENT_MONTHS_1A.15");

                entity.Property(e => e.CurrentRent1a142).HasColumnName("CURRENT_RENT_1A.14.2");

                entity.Property(e => e.CurrentStateId1a134)
                    .HasColumnType("int(11)")
                    .HasColumnName("CURRENT_STATE_ID_1A.13.4");

                entity.Property(e => e.CurrentStreet1a131)
                    .HasMaxLength(100)
                    .HasColumnName("CURRENT_STREET_1A.13.1")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.CurrentUnit1a132)
                    .HasMaxLength(20)
                    .HasColumnName("CURRENT_UNIT_1A.13.2")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.CurrentYears1a14)
                    .HasColumnType("int(11)")
                    .HasColumnName("CURRENT_YEARS_1A.14");

                entity.Property(e => e.CurrentZip1a135)
                    .HasMaxLength(10)
                    .HasColumnName("CURRENT_ZIP_1A.13.5")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Dependents1a8)
                    .HasColumnType("int(11)")
                    .HasColumnName("DEPENDENTS_1A.8");

                entity.Property(e => e.Dob1a4)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB_1A.4");

                entity.Property(e => e.Email1a12)
                    .HasMaxLength(100)
                    .HasColumnName("EMAIL_1A.12")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Ext1a111)
                    .HasMaxLength(5)
                    .HasColumnName("EXT_1A.11.1")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.FirstName1a1)
                    .HasMaxLength(200)
                    .HasColumnName("FIRST_NAME_1A.1")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.FormerCityId1a153)
                    .HasColumnType("int(11)")
                    .HasColumnName("FORMER_CITY_ID_1A.15.3");

                entity.Property(e => e.FormerCountryId1a156)
                    .HasColumnType("int(11)")
                    .HasColumnName("FORMER_COUNTRY_ID_1A.15.6");

                entity.Property(e => e.FormerHousingTypeId1a161)
                    .HasColumnType("int(11)")
                    .HasColumnName("FORMER_HOUSING_TYPE_ID_1A.16.1");

                entity.Property(e => e.FormerMonths1a161)
                    .HasColumnType("int(11)")
                    .HasColumnName("FORMER_MONTHS_1A.16.1");

                entity.Property(e => e.FormerRent1a162).HasColumnName("FORMER_RENT_1A.16.2");

                entity.Property(e => e.FormerStateId1a154)
                    .HasColumnType("int(11)")
                    .HasColumnName("FORMER_STATE_ID_1A.15.4");

                entity.Property(e => e.FormerStreet1a151)
                    .HasMaxLength(100)
                    .HasColumnName("FORMER_STREET_1A.15.1")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.FormerUnit1a152)
                    .HasMaxLength(20)
                    .HasColumnName("FORMER_UNIT_1A.15.2")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.FormerYears1a16)
                    .HasColumnType("int(11)")
                    .HasColumnName("FORMER_YEARS_1A.16");

                entity.Property(e => e.FormerZip1a155)
                    .HasMaxLength(10)
                    .HasColumnName("FORMER_ZIP_1A.15.5")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.HomePhone1a9)
                    .HasMaxLength(20)
                    .HasColumnName("HOME_PHONE_1A.9")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.LastName1a3)
                    .HasMaxLength(200)
                    .HasColumnName("LAST_NAME_1A.3")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.MailingCityId1a173)
                    .HasColumnType("int(11)")
                    .HasColumnName("MAILING_CITY_ID_1A.17.3");

                entity.Property(e => e.MailingCountryId1a176)
                    .HasColumnType("int(11)")
                    .HasColumnName("MAILING_COUNTRY_ID_1A.17.6");

                entity.Property(e => e.MailingStateId1a174)
                    .HasColumnType("int(11)")
                    .HasColumnName("MAILING_STATE_ID_1A.17.4");

                entity.Property(e => e.MailingStreet1a171)
                    .HasMaxLength(100)
                    .HasColumnName("MAILING_STREET_1A.17.1")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.MailingUnit1a172)
                    .HasMaxLength(20)
                    .HasColumnName("MAILING_UNIT_1A.17.2")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.MailingZip1a175)
                    .HasMaxLength(10)
                    .HasColumnName("MAILING_ZIP_1A.17.5")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.MaritialStatusId1a7)
                    .HasColumnType("int(11)")
                    .HasColumnName("MARITIAL_STATUS_ID_1A.7");

                entity.Property(e => e.MiddleName1a2)
                    .HasMaxLength(200)
                    .HasColumnName("MIDDLE_NAME_1A.2")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Ssn1a3)
                    .HasMaxLength(50)
                    .HasColumnName("SSN_1A.3")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Suffix1a4)
                    .HasMaxLength(200)
                    .HasColumnName("SUFFIX_1A.4")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.WorkPhone1a11)
                    .HasMaxLength(20)
                    .HasColumnName("WORK_PHONE_1A.11")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.ApplicationPersonalInformations)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_personal_information_ibfk_1");

                entity.HasOne(d => d.CitizenshipTypeId1a5Navigation)
                    .WithMany(p => p.ApplicationPersonalInformations)
                    .HasForeignKey(d => d.CitizenshipTypeId1a5)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_personal_information_ibfk_2");

                entity.HasOne(d => d.CurrentCityId1a133Navigation)
                    .WithMany(p => p.ApplicationPersonalInformationCurrentCityId1a133Navigations)
                    .HasForeignKey(d => d.CurrentCityId1a133)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_personal_information_ibfk_6");

                entity.HasOne(d => d.CurrentCountryId1a136Navigation)
                    .WithMany(p => p.ApplicationPersonalInformationCurrentCountryId1a136Navigations)
                    .HasForeignKey(d => d.CurrentCountryId1a136)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_personal_information_ibfk_4");

                entity.HasOne(d => d.CurrentHousingTypeId1a141Navigation)
                    .WithMany(p => p.ApplicationPersonalInformationCurrentHousingTypeId1a141Navigations)
                    .HasForeignKey(d => d.CurrentHousingTypeId1a141)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_personal_information_ibfk_7");

                entity.HasOne(d => d.CurrentStateId1a134Navigation)
                    .WithMany(p => p.ApplicationPersonalInformationCurrentStateId1a134Navigations)
                    .HasForeignKey(d => d.CurrentStateId1a134)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_personal_information_ibfk_5");

                entity.HasOne(d => d.FormerCityId1a153Navigation)
                    .WithMany(p => p.ApplicationPersonalInformationFormerCityId1a153Navigations)
                    .HasForeignKey(d => d.FormerCityId1a153)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_personal_information_ibfk_10");

                entity.HasOne(d => d.FormerCountryId1a156Navigation)
                    .WithMany(p => p.ApplicationPersonalInformationFormerCountryId1a156Navigations)
                    .HasForeignKey(d => d.FormerCountryId1a156)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_personal_information_ibfk_8");

                entity.HasOne(d => d.FormerHousingTypeId1a161Navigation)
                    .WithMany(p => p.ApplicationPersonalInformationFormerHousingTypeId1a161Navigations)
                    .HasForeignKey(d => d.FormerHousingTypeId1a161)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_personal_information_ibfk_11");

                entity.HasOne(d => d.FormerStateId1a154Navigation)
                    .WithMany(p => p.ApplicationPersonalInformationFormerStateId1a154Navigations)
                    .HasForeignKey(d => d.FormerStateId1a154)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_personal_information_ibfk_9");

                entity.HasOne(d => d.MailingCityId1a173Navigation)
                    .WithMany(p => p.ApplicationPersonalInformationMailingCityId1a173Navigations)
                    .HasForeignKey(d => d.MailingCityId1a173)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_personal_information_ibfk_14");

                entity.HasOne(d => d.MailingCountryId1a176Navigation)
                    .WithMany(p => p.ApplicationPersonalInformationMailingCountryId1a176Navigations)
                    .HasForeignKey(d => d.MailingCountryId1a176)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_personal_information_ibfk_12");

                entity.HasOne(d => d.MailingStateId1a174Navigation)
                    .WithMany(p => p.ApplicationPersonalInformationMailingStateId1a174Navigations)
                    .HasForeignKey(d => d.MailingStateId1a174)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_personal_information_ibfk_13");

                entity.HasOne(d => d.MaritialStatusId1a7Navigation)
                    .WithMany(p => p.ApplicationPersonalInformations)
                    .HasForeignKey(d => d.MaritialStatusId1a7)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_personal_information_ibfk_3");
            });

            modelBuilder.Entity<ApplicationPreviousEmployementDetail>(entity =>
            {
                entity.ToTable("application_previous_employement_details");

                entity.HasIndex(e => e.ApplicationPersonalInformationId, "APPLICATION_PERSONAL_INFORMATION_ID");

                entity.HasIndex(e => e.CityId1d33, "CITY_ID_1D.3.3");

                entity.HasIndex(e => e.CountryId1d36, "COUNTRY_ID_1D.3.6");

                entity.HasIndex(e => e.StateId1d34, "STATE_ID_1D.3.4");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.ApplicationPersonalInformationId)
                    .HasColumnType("int(11)")
                    .HasColumnName("APPLICATION_PERSONAL_INFORMATION_ID");

                entity.Property(e => e.CityId1d33)
                    .HasColumnType("int(11)")
                    .HasColumnName("CITY_ID_1D.3.3");

                entity.Property(e => e.CountryId1d36)
                    .HasColumnType("int(11)")
                    .HasColumnName("COUNTRY_ID_1D.3.6");

                entity.Property(e => e.EmployerBusinessName1d2)
                    .HasMaxLength(100)
                    .HasColumnName("EMPLOYER/BUSINESS_NAME_1D.2")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.EndDate1d6)
                    .HasColumnType("datetime")
                    .HasColumnName("END_DATE_1D.6");

                entity.Property(e => e.GrossMonthlyIncome1d8).HasColumnName("GROSS_MONTHLY_INCOME_1D.8");

                entity.Property(e => e.IsSelfEmployed1d7)
                    .HasColumnType("bit(1)")
                    .HasColumnName("IS_SELF_EMPLOYED_1D.7");

                entity.Property(e => e.PositionTitle1d4)
                    .HasMaxLength(100)
                    .HasColumnName("POSITION_TITLE_1D.4")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.StartDate1d5)
                    .HasColumnType("datetime")
                    .HasColumnName("START_DATE_1D.5");

                entity.Property(e => e.StateId1d34)
                    .HasColumnType("int(11)")
                    .HasColumnName("STATE_ID_1D.3.4");

                entity.Property(e => e.Street1d31)
                    .HasMaxLength(100)
                    .HasColumnName("STREET_1D.3.1")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Unit1d32)
                    .HasMaxLength(20)
                    .HasColumnName("UNIT_1D.3.2")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Zip1d35)
                    .HasMaxLength(10)
                    .HasColumnName("ZIP_1D.3.5")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.HasOne(d => d.ApplicationPersonalInformation)
                    .WithMany(p => p.ApplicationPreviousEmployementDetails)
                    .HasForeignKey(d => d.ApplicationPersonalInformationId)
                    .HasConstraintName("application_previous_employement_details_ibfk_1");

                entity.HasOne(d => d.CityId1d33Navigation)
                    .WithMany(p => p.ApplicationPreviousEmployementDetails)
                    .HasForeignKey(d => d.CityId1d33)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_previous_employement_details_ibfk_4");

                entity.HasOne(d => d.CountryId1d36Navigation)
                    .WithMany(p => p.ApplicationPreviousEmployementDetails)
                    .HasForeignKey(d => d.CountryId1d36)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_previous_employement_details_ibfk_2");

                entity.HasOne(d => d.StateId1d34Navigation)
                    .WithMany(p => p.ApplicationPreviousEmployementDetails)
                    .HasForeignKey(d => d.StateId1d34)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_previous_employement_details_ibfk_3");
            });
            modelBuilder.Entity<AdminDisclosure>(entity =>
            {
                entity.ToTable("admin_disclosures");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<AdminLoanapplicationdocument>(entity =>
            {
                entity.ToTable("admin_loanapplicationdocuments");

                entity.HasIndex(e => e.DisclosureId, "DisclosureId");

                entity.HasIndex(e => e.LoanId, "LoanId");

                entity.HasIndex(e => e.UserId, "UserId");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.DisclosureId).HasColumnType("int(11)");

                entity.Property(e => e.DocumentPath)
                    .HasMaxLength(1000)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.LoanId).HasColumnType("int(11)");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.Disclosure)
                    .WithMany(p => p.AdminLoanapplicationdocuments)
                    .HasForeignKey(d => d.DisclosureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Admin_LoanApplicationDocuments_ibfk_2");

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.AdminLoanapplicationdocuments)
                    .HasForeignKey(d => d.LoanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Admin_LoanApplicationDocuments_ibfk_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AdminLoanapplicationdocuments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Admin_LoanApplicationDocuments_ibfk_3");
            });

            modelBuilder.Entity<AdminLoandetail>(entity =>
            {
                entity.ToTable("admin_loandetails");

                entity.HasIndex(e => e.LoanApplicationId, "LoanApplicationId");

                entity.HasIndex(e => e.LoanProgramId, "LoanProgramId");

                entity.HasIndex(e => e.UserId, "UserId");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.ApplicationDate).HasColumnType("datetime");

                entity.Property(e => e.BorrowerName)
                    .HasMaxLength(100)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.LoanApplicationId).HasColumnType("int(11)");

                entity.Property(e => e.LoanNo)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.LoanProgramId).HasColumnType("int(11)");

                entity.Property(e => e.LoanPurpose)
                    .HasMaxLength(500)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.MortageConsultant)
                    .HasMaxLength(100)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.NmlsId)
                    .HasMaxLength(100)
                    .HasColumnName("NMLS_ID")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PropertyAddress)
                    .HasMaxLength(500)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.RateLockDate).HasColumnType("datetime");

                entity.Property(e => e.RateLockExpirationDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.LoanApplication)
                    .WithMany(p => p.AdminLoandetails)
                    .HasForeignKey(d => d.LoanApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Admin_LoanDetails_ibfk_2");

                entity.HasOne(d => d.LoanProgram)
                    .WithMany(p => p.AdminLoandetails)
                    .HasForeignKey(d => d.LoanProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Admin_LoanDetails_ibfk_3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AdminLoandetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Admin_LoanDetails_ibfk_1");
            });

            modelBuilder.Entity<AdminLoanprogram>(entity =>
            {
                entity.ToTable("admin_loanprograms");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.LoanProgram)
                    .HasMaxLength(100)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<AdminLoanstatus>(entity =>
            {
                entity.ToTable("admin_loanstatus");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<AdminLoansummarystatus>(entity =>
            {
                entity.ToTable("admin_loansummarystatus");

                entity.HasIndex(e => e.LoanId, "LoanId");

                entity.HasIndex(e => e.StatusId, "StatusID");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.LoanId).HasColumnType("int(11)");

                entity.Property(e => e.StatusId)
                    .HasColumnType("int(11)")
                    .HasColumnName("StatusID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.AdminLoansummarystatuses)
                    .HasForeignKey(d => d.LoanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Admin_LoanSummaryStatus_ibfk_1");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.AdminLoansummarystatuses)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Admin_LoanSummaryStatus_ibfk_2");
            });

            modelBuilder.Entity<AdminNotificationtype>(entity =>
            {
                entity.ToTable("admin_notificationtypes");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<AdminUser>(entity =>
            {
                entity.ToTable("admin_users");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.IsActive).HasColumnType("bit(1)");

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<AdminUserenableddevice>(entity =>
            {
                entity.ToTable("admin_userenableddevices");

                entity.HasIndex(e => e.UserId, "UserId");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.BioMetricData)
                    .HasMaxLength(500)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.DeviceId)
                    .HasMaxLength(500)
                    .HasColumnName("DeviceID")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.IsEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AdminUserenableddevices)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserEnabledDevices_ibfk_1");
            });

            modelBuilder.Entity<AdminUsernotification>(entity =>
            {
                entity.ToTable("admin_usernotifications");

                entity.HasIndex(e => e.NotificationTypeId, "NotificationTypeId");

                entity.HasIndex(e => e.UserId, "UserId");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Content)
                    .HasMaxLength(500)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.IsSeen).HasColumnType("bit(1)");

                entity.Property(e => e.NotificationTypeId).HasColumnType("int(11)");

                entity.Property(e => e.Subject)
                    .HasMaxLength(100)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.NotificationType)
                    .WithMany(p => p.AdminUsernotifications)
                    .HasForeignKey(d => d.NotificationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Admin_UserNotifications_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AdminUsernotifications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Admin_UserNotifications_ibfk_1");
            });

            modelBuilder.Entity<CitizenshipType>(entity =>
            {
                entity.ToTable("citizenship_types");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.CitizenshipType1)
                    .HasMaxLength(100)
                    .HasColumnName("CITIZENSHIP_TYPE")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("cities");

                entity.HasIndex(e => e.StateId, "STATE_ID");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.CityName)
                    .HasMaxLength(100)
                    .HasColumnName("CITY_NAME")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.StateId)
                    .HasColumnType("int(11)")
                    .HasColumnName("STATE_ID");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cities_ibfk_1");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("countries");

                entity.HasIndex(e => e.CountryName, "COUNTRY_NAME")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(100)
                    .HasColumnName("COUNTRY_NAME")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<CreditType>(entity =>
            {
                entity.ToTable("credit_types");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.CreditType1)
                    .HasMaxLength(100)
                    .HasColumnName("CREDIT_TYPE")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<DeclarationCategory>(entity =>
            {
                entity.ToTable("declaration_categories");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.DeclarationCategory1)
                    .HasMaxLength(100)
                    .HasColumnName("DECLARATION_CATEGORY")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<DeclarationQuestion>(entity =>
            {
                entity.ToTable("declaration_questions");

                entity.HasIndex(e => e.DeclarationCategoryId, "DECLARATION_CATEGORY_ID");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.DeclarationCategoryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("DECLARATION_CATEGORY_ID");

                entity.Property(e => e.IsActive)
                    .HasColumnType("bit(1)")
                    .HasColumnName("IS_ACTIVE");

                entity.Property(e => e.ParentQuestionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("PARENT_QUESTION_ID");

                entity.Property(e => e.Question)
                    .HasMaxLength(9999)
                    .HasColumnName("QUESTION")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.HasOne(d => d.DeclarationCategory)
                    .WithMany(p => p.DeclarationQuestions)
                    .HasForeignKey(d => d.DeclarationCategoryId)
                    .HasConstraintName("declaration_questions_ibfk_1");
            });

            modelBuilder.Entity<DemographicInfoSource>(entity =>
            {
                entity.ToTable("demographic_info_sources");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Value)
                    .HasMaxLength(255)
                    .HasColumnName("VALUE")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<DemographicInformation>(entity =>
            {
                entity.ToTable("demographic_information");

                entity.HasIndex(e => e.ApplicationPersonalInformationId, "APPLICATION_PERSONAL_INFORMATION_ID");

                entity.HasIndex(e => e.DemographicInfoSourceId87, "DEMOGRAPHIC_INFO_SOURCE_ID_8.7");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.ApplicationPersonalInformationId)
                    .HasColumnType("int(11)")
                    .HasColumnName("APPLICATION_PERSONAL_INFORMATION_ID");

                entity.Property(e => e.DemographicInfoSourceId87)
                    .HasColumnType("int(11)")
                    .HasColumnName("DEMOGRAPHIC_INFO_SOURCE_ID_8.7");

                entity.Property(e => e.Ethnicity81)
                    .HasMaxLength(20)
                    .HasColumnName("ETHNICITY_8.1")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Gender82)
                    .HasMaxLength(20)
                    .HasColumnName("GENDER_8.2")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.IsEthnicityByObservation84)
                    .HasColumnType("bit(1)")
                    .HasColumnName("IS_ETHNICITY_BY_OBSERVATION_8.4");

                entity.Property(e => e.IsGenderByObservation85)
                    .HasColumnType("bit(1)")
                    .HasColumnName("IS_GENDER_BY_OBSERVATION_8.5");

                entity.Property(e => e.IsRaceByObservation86)
                    .HasColumnType("bit(1)")
                    .HasColumnName("IS_RACE_BY_OBSERVATION_8.6");

                entity.Property(e => e.Race83)
                    .HasMaxLength(20)
                    .HasColumnName("RACE_8.3")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.HasOne(d => d.ApplicationPersonalInformation)
                    .WithMany(p => p.DemographicInformations)
                    .HasForeignKey(d => d.ApplicationPersonalInformationId)
                    .HasConstraintName("demographic_information_ibfk_1");

                entity.HasOne(d => d.DemographicInfoSourceId87Navigation)
                    .WithMany(p => p.DemographicInformations)
                    .HasForeignKey(d => d.DemographicInfoSourceId87)
                    .HasConstraintName("demographic_information_ibfk_2");
            });

            modelBuilder.Entity<FinancialAccountType>(entity =>
            {
                entity.ToTable("financial_account_types");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.FinancialAccountType1)
                    .HasMaxLength(100)
                    .HasColumnName("FINANCIAL_ACCOUNT_TYPE")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<FinancialAssetsType>(entity =>
            {
                entity.ToTable("financial_assets_types");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.FinancialCreditType)
                    .HasMaxLength(100)
                    .HasColumnName("FINANCIAL_CREDIT_TYPE")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<FinancialLaibilitiesType>(entity =>
            {
                entity.ToTable("financial_laibilities_types");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.FinancialLaibilitiesType1)
                    .HasMaxLength(100)
                    .HasColumnName("FINANCIAL_LAIBILITIES_TYPE")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<FinancialOtherLaibilitiesType>(entity =>
            {
                entity.ToTable("financial_other_laibilities_types");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.FinancialOtherLaibilitiesType1)
                    .HasMaxLength(100)
                    .HasColumnName("FINANCIAL_OTHER_LAIBILITIES_TYPE")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<FinancialPropertyIntendedOccupancy>(entity =>
            {
                entity.ToTable("financial_property_intended_occupancies");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.FinancialPropertyIntendedOccupancy1)
                    .HasMaxLength(100)
                    .HasColumnName("FINANCIAL_PROPERTY_INTENDED_OCCUPANCY")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<FinancialPropertyStatus>(entity =>
            {
                entity.ToTable("financial_property_status");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.FinancialPropertyStatus1)
                    .HasMaxLength(100)
                    .HasColumnName("FINANCIAL_PROPERTY_STATUS")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<HousingType>(entity =>
            {
                entity.ToTable("housing_types");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.HousingType1)
                    .HasMaxLength(100)
                    .HasColumnName("HOUSING_TYPE")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<IncomeSource>(entity =>
            {
                entity.ToTable("income_sources");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.IncomeSource1)
                    .HasMaxLength(100)
                    .HasColumnName("INCOME_SOURCE")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<IncomeType>(entity =>
            {
                entity.ToTable("income_types");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.IncomeType1)
                    .HasMaxLength(100)
                    .HasColumnName("INCOME_TYPE")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<LoanAndPropertyInformation>(entity =>
            {
                entity.ToTable("loan_and_property_information");

                entity.HasIndex(e => e.ApplicationPersonalInformationId, "APPLICATION_PERSONAL_INFORMATION_ID");

                entity.HasIndex(e => e.CityId4a33, "CITY_ID_4A.3.3");

                entity.HasIndex(e => e.CountryId4a36, "COUNTRY_ID_4A.3.6");

                entity.HasIndex(e => e.LoanPropertyOccupancyId4a6, "LOAN_PROPERTY_OCCUPANCY_ID_4A.6");

                entity.HasIndex(e => e.StateId4a34, "STATE_ID_4A.3.4");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.ApplicationPersonalInformationId)
                    .HasColumnType("int(11)")
                    .HasColumnName("APPLICATION_PERSONAL_INFORMATION_ID");

                entity.Property(e => e.CityId4a33)
                    .HasColumnType("int(11)")
                    .HasColumnName("CITY_ID_4A.3.3");

                entity.Property(e => e.CountryId4a36)
                    .HasColumnType("int(11)")
                    .HasColumnName("COUNTRY_ID_4A.3.6");

                entity.Property(e => e.FhaSecondaryResidance4a61)
                    .HasColumnType("bit(1)")
                    .HasColumnName("FHA_SECONDARY_RESIDANCE_4A.6.1");

                entity.Property(e => e.IsManufacturedHome4a8)
                    .HasColumnType("bit(1)")
                    .HasColumnName("IS_MANUFACTURED_HOME_4A.8");

                entity.Property(e => e.IsMixedUseProperty4a7)
                    .HasColumnType("bit(1)")
                    .HasColumnName("IS_MIXED_USE_PROPERTY_4A.7");

                entity.Property(e => e.LoanAmount4a1).HasColumnName("LOAN_AMOUNT_4A.1");

                entity.Property(e => e.LoanPropertyOccupancyId4a6)
                    .HasColumnType("int(11)")
                    .HasColumnName("LOAN_PROPERTY_OCCUPANCY_ID_4A.6");

                entity.Property(e => e.LoanPurpose4a2)
                    .HasMaxLength(20)
                    .HasColumnName("LOAN_PURPOSE_4A.2")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PropertyNumberUnits4a4)
                    .HasColumnType("int(11)")
                    .HasColumnName("PROPERTY_NUMBER_UNITS_4A.4");

                entity.Property(e => e.PropertyStreet4a31)
                    .HasMaxLength(200)
                    .HasColumnName("PROPERTY_STREET_4A.3.1")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PropertyUnitNo4a32)
                    .HasMaxLength(20)
                    .HasColumnName("PROPERTY_UNIT_NO_4A.3.2")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PropertyValue4a5).HasColumnName("PROPERTY_VALUE_4A.5");

                entity.Property(e => e.PropertyZip4a35)
                    .HasMaxLength(10)
                    .HasColumnName("PROPERTY_ZIP_4A.3.5")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.StateId4a34)
                    .HasColumnType("int(11)")
                    .HasColumnName("STATE_ID_4A.3.4");

                entity.HasOne(d => d.ApplicationPersonalInformation)
                    .WithMany(p => p.LoanAndPropertyInformations)
                    .HasForeignKey(d => d.ApplicationPersonalInformationId)
                    .HasConstraintName("loan_and_property_information_ibfk_1");

                entity.HasOne(d => d.CityId4a33Navigation)
                    .WithMany(p => p.LoanAndPropertyInformations)
                    .HasForeignKey(d => d.CityId4a33)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("loan_and_property_information_ibfk_4");

                entity.HasOne(d => d.CountryId4a36Navigation)
                    .WithMany(p => p.LoanAndPropertyInformations)
                    .HasForeignKey(d => d.CountryId4a36)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("loan_and_property_information_ibfk_2");

                entity.HasOne(d => d.LoanPropertyOccupancyId4a6Navigation)
                    .WithMany(p => p.LoanAndPropertyInformations)
                    .HasForeignKey(d => d.LoanPropertyOccupancyId4a6)
                    .HasConstraintName("loan_and_property_information_ibfk_5");

                entity.HasOne(d => d.StateId4a34Navigation)
                    .WithMany(p => p.LoanAndPropertyInformations)
                    .HasForeignKey(d => d.StateId4a34)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("loan_and_property_information_ibfk_3");
            });

            modelBuilder.Entity<LoanAndPropertyInformationGift>(entity =>
            {
                entity.ToTable("loan_and_property_information_gifts");

                entity.HasIndex(e => e.ApplicationPersonalInformationId, "APPLICATION_PERSONAL_INFORMATION_ID");

                entity.HasIndex(e => e.LoanPropertyGiftTypeId4d1, "LOAN_PROPERTY_GIFT_TYPE_ID_4D.1");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.ApplicationPersonalInformationId)
                    .HasColumnType("int(11)")
                    .HasColumnName("APPLICATION_PERSONAL_INFORMATION_ID");

                entity.Property(e => e.Deposited4d2)
                    .HasColumnType("bit(1)")
                    .HasColumnName("DEPOSITED_4D.2");

                entity.Property(e => e.LoanPropertyGiftTypeId4d1)
                    .HasColumnType("int(11)")
                    .HasColumnName("LOAN_PROPERTY_GIFT_TYPE_ID_4D.1");

                entity.Property(e => e.Source4d3)
                    .HasMaxLength(50)
                    .HasColumnName("SOURCE_4D.3")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Value4d4).HasColumnName("VALUE_4D.4");

                entity.HasOne(d => d.ApplicationPersonalInformation)
                    .WithMany(p => p.LoanAndPropertyInformationGifts)
                    .HasForeignKey(d => d.ApplicationPersonalInformationId)
                    .HasConstraintName("loan_and_property_information_gifts_ibfk_1");

                entity.HasOne(d => d.LoanPropertyGiftTypeId4d1Navigation)
                    .WithMany(p => p.LoanAndPropertyInformationGifts)
                    .HasForeignKey(d => d.LoanPropertyGiftTypeId4d1)
                    .HasConstraintName("loan_and_property_information_gifts_ibfk_2");
            });

            modelBuilder.Entity<LoanAndPropertyInformationOtherMortageLoan>(entity =>
            {
                entity.ToTable("loan_and_property_information_other_mortage_loan");

                entity.HasIndex(e => e.ApplicationPersonalInformationId, "APPLICATION_PERSONAL_INFORMATION_ID");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.ApplicationPersonalInformationId)
                    .HasColumnType("int(11)")
                    .HasColumnName("APPLICATION_PERSONAL_INFORMATION_ID");

                entity.Property(e => e.CreditAmount4b5).HasColumnName("CREDIT_AMOUNT_4B.5");

                entity.Property(e => e.CreditorName4b1)
                    .HasMaxLength(100)
                    .HasColumnName("CREDITOR_NAME_4B.1")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.LienType4b2)
                    .HasMaxLength(50)
                    .HasColumnName("LIEN_TYPE_4B.2")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.LoanAmount4b4).HasColumnName("LOAN_AMOUNT_4B.4");

                entity.Property(e => e.MonthlyPayment4b3).HasColumnName("MONTHLY_PAYMENT_4B.3");

                entity.HasOne(d => d.ApplicationPersonalInformation)
                    .WithMany(p => p.LoanAndPropertyInformationOtherMortageLoans)
                    .HasForeignKey(d => d.ApplicationPersonalInformationId)
                    .HasConstraintName("loan_and_property_information_other_mortage_loan_ibfk_1");
            });

            modelBuilder.Entity<LoanAndPropertyInformationRentalIncome>(entity =>
            {
                entity.ToTable("loan_and_property_information_rental_income");

                entity.HasIndex(e => e.ApplicationPersonalInformationId, "APPLICATION_PERSONAL_INFORMATION_ID");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.ApplicationPersonalInformationId)
                    .HasColumnType("int(11)")
                    .HasColumnName("APPLICATION_PERSONAL_INFORMATION_ID");

                entity.Property(e => e.ExpectedMonthlyIncome4c1).HasColumnName("EXPECTED_MONTHLY_INCOME_4C.1");

                entity.Property(e => e.LenderExpectedMonthlyIncome4c2).HasColumnName("LENDER_EXPECTED_MONTHLY_INCOME_4C.2");

                entity.HasOne(d => d.ApplicationPersonalInformation)
                    .WithMany(p => p.LoanAndPropertyInformationRentalIncomes)
                    .HasForeignKey(d => d.ApplicationPersonalInformationId)
                    .HasConstraintName("loan_and_property_information_rental_income_ibfk_1");
            });

            modelBuilder.Entity<LoanOriginatorInformation>(entity =>
            {
                entity.ToTable("loan_originator_information");

                entity.HasIndex(e => e.ApplicationPersonalInformationId, "APPLICATION_PERSONAL_INFORMATION_ID");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Address92)
                    .HasMaxLength(9999)
                    .HasColumnName("ADDRESS_9.2")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.ApplicationPersonalInformationId)
                    .HasColumnType("int(11)")
                    .HasColumnName("APPLICATION_PERSONAL_INFORMATION_ID");

                entity.Property(e => e.Date910)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_9.10");

                entity.Property(e => e.Email98)
                    .HasMaxLength(100)
                    .HasColumnName("EMAIL_9.8")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.OrganizationName91)
                    .HasMaxLength(100)
                    .HasColumnName("ORGANIZATION_NAME_9.1")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.OrganizationNmlsrId93)
                    .HasMaxLength(50)
                    .HasColumnName("ORGANIZATION_NMLSR_ID_9.3")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.OrganizationStateLicence94)
                    .HasMaxLength(50)
                    .HasColumnName("ORGANIZATION_STATE_LICENCE_9.4")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.OriginatorName95)
                    .HasMaxLength(100)
                    .HasColumnName("ORIGINATOR_NAME_9.5")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.OriginatorNmlsrId96)
                    .HasMaxLength(30)
                    .HasColumnName("ORIGINATOR_NMLSR_ID_9.6")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.OriginatorStateLicense97)
                    .HasMaxLength(25)
                    .HasColumnName("ORIGINATOR_STATE_LICENSE_9.7")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Phone99)
                    .HasMaxLength(25)
                    .HasColumnName("PHONE_9.9")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.HasOne(d => d.ApplicationPersonalInformation)
                    .WithMany(p => p.LoanOriginatorInformations)
                    .HasForeignKey(d => d.ApplicationPersonalInformationId)
                    .HasConstraintName("loan_originator_information_ibfk_1");
            });

            modelBuilder.Entity<LoanPropertyGiftType>(entity =>
            {
                entity.ToTable("loan_property_gift_types");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.LoanPropertyGiftType1)
                    .HasMaxLength(100)
                    .HasColumnName("LOAN_PROPERTY_GIFT_TYPE")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<LoanPropertyOccupancy>(entity =>
            {
                entity.ToTable("loan_property_occupancies");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.LoanPropertyOccupancy1)
                    .HasMaxLength(100)
                    .HasColumnName("LOAN_PROPERTY_OCCUPANCY")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<MaritialStatus>(entity =>
            {
                entity.ToTable("maritial_status");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.MaritialStatus1)
                    .HasMaxLength(100)
                    .HasColumnName("MARITIAL_STATUS")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<MilitaryService>(entity =>
            {
                entity.ToTable("military_service");

                entity.HasIndex(e => e.ApplicationPersonalInformationId, "APPLICATION_PERSONAL_INFORMATION_ID");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.ApplicationPersonalInformationId)
                    .HasColumnType("int(11)")
                    .HasColumnName("APPLICATION_PERSONAL_INFORMATION_ID");

                entity.Property(e => e.CurrentlyServing7a2)
                    .HasColumnType("bit(1)")
                    .HasColumnName("CURRENTLY_SERVING_7A.2");

                entity.Property(e => e.DateOfServiceExpiration7a3)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_OF_SERVICE_EXPIRATION_7A.3");

                entity.Property(e => e.NonActivatedMember7a2)
                    .HasColumnType("bit(1)")
                    .HasColumnName("NON_ACTIVATED_MEMBER_7A.2");

                entity.Property(e => e.Retired7a2)
                    .HasColumnType("bit(1)")
                    .HasColumnName("RETIRED_7A.2");

                entity.Property(e => e.ServedInForces7a1)
                    .HasColumnType("bit(1)")
                    .HasColumnName("SERVED_IN_FORCES_7A.1");

                entity.Property(e => e.SurvivingSpouse7a21)
                    .HasColumnType("bit(1)")
                    .HasColumnName("SURVIVING_SPOUSE_7A.2.1");

                entity.HasOne(d => d.ApplicationPersonalInformation)
                    .WithMany(p => p.MilitaryServices)
                    .HasForeignKey(d => d.ApplicationPersonalInformationId)
                    .HasConstraintName("military_service_ibfk_1");
            });

            modelBuilder.Entity<MortageLoanOnProperty>(entity =>
            {
                entity.ToTable("mortage_loan_on_properties");

                entity.HasIndex(e => e.ApplicationFinancialRealEstateId, "APPLICATION_FINANCIAL_REAL_ESTATE_ID");

                entity.HasIndex(e => e.MortageLoanTypesId3a14, "MORTAGE_LOAN_TYPES_ID_3A.14");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.AccountNumber3a10)
                    .HasMaxLength(50)
                    .HasColumnName("ACCOUNT_NUMBER_3A.10")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.ApplicationFinancialRealEstateId)
                    .HasColumnType("int(11)")
                    .HasColumnName("APPLICATION_FINANCIAL_REAL_ESTATE_ID");

                entity.Property(e => e.CreditLimit3a15).HasColumnName("CREDIT_LIMIT_3A.15");

                entity.Property(e => e.CreditorName3a9)
                    .HasMaxLength(50)
                    .HasColumnName("CREDITOR_NAME_3A.9")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.MonthlyMortagePayment3a11).HasColumnName("MONTHLY_MORTAGE_PAYMENT_3A.11");

                entity.Property(e => e.MortageLoanTypesId3a14)
                    .HasColumnType("int(11)")
                    .HasColumnName("MORTAGE_LOAN_TYPES_ID_3A.14");

                entity.Property(e => e.PaidOff3a13)
                    .HasColumnType("bit(1)")
                    .HasColumnName("PAID_OFF_3A.13");

                entity.Property(e => e.UnpaidBalance3a12).HasColumnName("UNPAID_BALANCE_3A.12");

                entity.HasOne(d => d.ApplicationFinancialRealEstate)
                    .WithMany(p => p.MortageLoanOnProperties)
                    .HasForeignKey(d => d.ApplicationFinancialRealEstateId)
                    .HasConstraintName("mortage_loan_on_properties_ibfk_1");

                entity.HasOne(d => d.MortageLoanTypesId3a14Navigation)
                    .WithMany(p => p.MortageLoanOnProperties)
                    .HasForeignKey(d => d.MortageLoanTypesId3a14)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mortage_loan_on_properties_ibfk_2");
            });

            modelBuilder.Entity<MortageLoanType>(entity =>
            {
                entity.ToTable("mortage_loan_types");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.MortageLoanTypesId)
                    .HasMaxLength(100)
                    .HasColumnName("MORTAGE_LOAN_TYPES_ID")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("country_states");

                entity.HasIndex(e => e.CountryId, "COUNTRY_ID");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.CountryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("COUNTRY_ID");

                entity.Property(e => e.StateName)
                    .HasMaxLength(100)
                    .HasColumnName("STATE_NAME")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("states_ibfk_1");
            });


            modelBuilder.Entity<LeadApplicationDetailPurchasing>(entity =>
            {
                entity.ToTable("lead_application_detail_purchasing");

                entity.HasIndex(e => e.CitizenshipId, "CitizenshipId");

                entity.HasIndex(e => e.CurrentStateId, "CurrentStateId");

                entity.HasIndex(e => e.NewHomeStateId, "NewHomeStateId");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.CitizenshipId).HasColumnType("int(11)");

                entity.Property(e => e.ConformSsn)
                    .HasMaxLength(50)
                    .HasColumnName("ConformSSN")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.ContractClosingDate).HasColumnType("datetime");

                entity.Property(e => e.ContractType)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.CreditScore)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.CurrentAddress)
                    .HasMaxLength(500)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.CurrentCity)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.CurrentMilitaryStatus)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.CurrentReantingType)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.CurrentStartLivingDate).HasColumnType("datetime");

                entity.Property(e => e.CurrentStateId).HasColumnType("int(11)");

                entity.Property(e => e.CurrentUnit)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.CurrentZipCode)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Ethnicity)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Etsdate)
                    .HasColumnType("datetime")
                    .HasColumnName("ETSDate");

                entity.Property(e => e.IsApplyOwn).HasColumnType("bit(1)");

                entity.Property(e => e.IsCertify).HasColumnType("bit(1)");

                entity.Property(e => e.IsEmployementHistory).HasColumnType("bit(1)");

                entity.Property(e => e.IsEtsdateinYear)
                    .HasColumnType("bit(1)")
                    .HasColumnName("IsETSDateinYear");

                entity.Property(e => e.IsMilitaryMember).HasColumnType("bit(1)");

                entity.Property(e => e.IsOtherSourceOfIncome).HasColumnType("bit(1)");

                entity.Property(e => e.IsReadEconsent)
                    .HasColumnType("bit(1)")
                    .HasColumnName("IsReadEConsent");

                entity.Property(e => e.IsReadThirdPartyConsent).HasColumnType("bit(1)");

                entity.Property(e => e.IsSomeOneRefer).HasColumnType("bit(1)");

                entity.Property(e => e.IsValoanPreviously)
                    .HasColumnType("bit(1)")
                    .HasColumnName("IsVALoanPreviously");

                entity.Property(e => e.IsWorkingWithEzalready)
                    .HasColumnType("bit(1)")
                    .HasColumnName("IsWorkingWithEZAlready");

                entity.Property(e => e.MaritialStatus)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.MilitaryBranch)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.MonthlyHoadues).HasColumnName("MonthlyHOADues");

                entity.Property(e => e.NewHomeAddress)
                    .HasMaxLength(500)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.NewHomeCity)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.NewHomeStateId).HasColumnType("int(11)");

                entity.Property(e => e.NewHomeUnit)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.NewHomeZipCode)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.NumberOfDependents).HasColumnType("int(11)");

                entity.Property(e => e.PersonalEmailAddress)
                    .HasMaxLength(50)
                    .HasColumnName("Personal_EmailAddress")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PersonalLegalFirstName)
                    .HasMaxLength(50)
                    .HasColumnName("Personal_LegalFirstName")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PersonalLegalLastName)
                    .HasMaxLength(50)
                    .HasColumnName("Personal_LegalLastName")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PersonalMiddleInitial)
                    .HasMaxLength(50)
                    .HasColumnName("Personal_MiddleInitial")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PersonalPassword)
                    .HasMaxLength(250)
                    .HasColumnName("Personal_Password")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PersonalPhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("Personal_PhoneNumber")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PropertyEmailAddress)
                    .HasMaxLength(50)
                    .HasColumnName("Property_EmailAddress")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PropertyLegalFirstName)
                    .HasMaxLength(50)
                    .HasColumnName("Property_LegalFirstName")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PropertyLegalLastName)
                    .HasMaxLength(50)
                    .HasColumnName("Property_LegalLastName")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PropertyMiddleInitial)
                    .HasMaxLength(50)
                    .HasColumnName("Property_MiddleInitial")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PropertyPhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("Property_PhoneNumber")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Race)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Sex)
                    .HasMaxLength(10)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.SocialSecurityNumber)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Stage)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.TypeOfHome)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.TypeOfNewHome)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.WhoLivingInHome)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.WorkingOfficerName)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                //entity.HasOne(d => d.Citizenship)
                //    .WithMany(p => p.LeadApplicationDetailPurchasings)
                //    .HasForeignKey(d => d.CitizenshipId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("Lead_Application_Detail_Purchasing_ibfk_3");

                //entity.HasOne(d => d.CurrentState)
                //    .WithMany(p => p.LeadApplicationDetailPurchasingCurrentStates)
                //    .HasForeignKey(d => d.CurrentStateId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("Lead_Application_Detail_Purchasing_ibfk_2");

                //entity.HasOne(d => d.NewHomeState)
                //    .WithMany(p => p.LeadApplicationDetailPurchasingNewHomeStates)
                //    .HasForeignKey(d => d.NewHomeStateId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("Lead_Application_Detail_Purchasing_ibfk_1");
            });

            modelBuilder.Entity<LeadApplicationDetailRefinancing>(entity =>
            {
                entity.ToTable("lead_application_detail_refinancing");

                entity.HasIndex(e => e.CurrentStateId, "CurrentStateId");

                entity.HasIndex(e => e.PersonalStateId, "PersonalStateId");

                entity.HasIndex(e => e.PropertyCountryId, "PropertyCountryId");

                entity.HasIndex(e => e.PropertyStateId, "PropertyStateId");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.CitizenshipId).HasColumnType("int(11)");

                entity.Property(e => e.ConformSsn)
                    .HasMaxLength(50)
                    .HasColumnName("ConformSSN")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.CreditScore)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.CurrentAddress)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.CurrentCity)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.CurrentMilitaryStatus)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.CurrentReantingType)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.CurrentStartLivingDate).HasColumnType("datetime");

                entity.Property(e => e.CurrentStateId).HasColumnType("int(11)");

                entity.Property(e => e.CurrentUnit)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.CurrentZipCode)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.CurrentlyUsingHomeAs)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Ethnicity)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Etsdate)
                    .HasColumnType("datetime")
                    .HasColumnName("ETSDate");

                entity.Property(e => e.FirstDependantAge).HasColumnType("int(11)");

                entity.Property(e => e.IsAddressSameAsPrimaryBorrower).HasColumnType("bit(1)");

                entity.Property(e => e.IsApplyOwn).HasColumnType("bit(1)");

                entity.Property(e => e.IsCertify).HasColumnType("bit(1)");

                entity.Property(e => e.IsCoBorrowerHaveShareIncome).HasColumnType("bit(1)");

                entity.Property(e => e.IsCurrentlyLivingOnRefinancingProperty).HasColumnType("bit(1)");

                entity.Property(e => e.IsEmployementHistory).HasColumnType("bit(1)");

                entity.Property(e => e.IsEtsdateinYear)
                    .HasColumnType("bit(1)")
                    .HasColumnName("IsETSDateinYear");

                entity.Property(e => e.IsLegalSpouse).HasColumnType("bit(1)");

                entity.Property(e => e.IsMilitaryMember).HasColumnType("bit(1)");

                entity.Property(e => e.IsReadEconsent)
                    .HasColumnType("bit(1)")
                    .HasColumnName("IsReadEConsent");

                entity.Property(e => e.IsReadThirdPartyConsent).HasColumnType("bit(1)");

                entity.Property(e => e.IsSomeoneRefer).HasColumnType("bit(1)");

                entity.Property(e => e.IsValoanPreviously)
                    .HasColumnType("bit(1)")
                    .HasColumnName("IsVALoanPreviously");

                entity.Property(e => e.IsWorkingWithEzalready)
                    .HasColumnType("bit(1)")
                    .HasColumnName("IsWorkingWithEZAlready");

                entity.Property(e => e.MaritialStatus)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.MilitaryBranch)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.MonthlyHoadues).HasColumnName("MonthlyHOADues");

                entity.Property(e => e.NumberOfDependents).HasColumnType("int(11)");

                entity.Property(e => e.ObjectiveReason)
                    .HasMaxLength(500)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PersonalAddress)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PersonalCity)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PersonalEmailAddress)
                    .HasMaxLength(50)
                    .HasColumnName("Personal_EmailAddress")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PersonalLegalFirstName)
                    .HasMaxLength(50)
                    .HasColumnName("Personal_LegalFirstName")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PersonalLegalLastName)
                    .HasMaxLength(50)
                    .HasColumnName("Personal_LegalLastName")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PersonalMiddleInitial)
                    .HasMaxLength(50)
                    .HasColumnName("Personal_MiddleInitial")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PersonalPassword)
                    .HasMaxLength(50)
                    .HasColumnName("Personal_Password")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PersonalPhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("Personal_PhoneNumber")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PersonalReantingType)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PersonalStartLivingDate).HasColumnType("datetime");

                entity.Property(e => e.PersonalStateId).HasColumnType("int(11)");

                entity.Property(e => e.PersonalUnit)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PersonalZipCode)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PropertyAddress)
                    .HasMaxLength(500)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PropertyCity)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PropertyCountryId).HasColumnType("int(11)");

                entity.Property(e => e.PropertyEmailAddress)
                    .HasMaxLength(50)
                    .HasColumnName("Property_EmailAddress")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PropertyLegalFirstName)
                    .HasMaxLength(50)
                    .HasColumnName("Property_LegalFirstName")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PropertyLegalLastName)
                    .HasMaxLength(50)
                    .HasColumnName("Property_LegalLastName")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PropertyMiddleInitial)
                    .HasMaxLength(50)
                    .HasColumnName("Property_MiddleInitial")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PropertyPassword)
                    .HasMaxLength(50)
                    .HasColumnName("Property_Password")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PropertyPhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("Property_PhoneNumber")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PropertyStateId).HasColumnType("int(11)");

                entity.Property(e => e.PropertyUnit)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.PropertyZip)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Race)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.RefferedBy)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Sex)
                    .HasMaxLength(10)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.SocialSecurityNumber)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.TypeOfHome)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.WhoLivingInHome)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.WorkingOfficerName)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                //entity.HasOne(d => d.CurrentState)
                //    .WithMany(p => p.LeadApplicationDetailRefinancingCurrentStates)
                //    .HasForeignKey(d => d.CurrentStateId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("Lead_Application_Detail_Refinancing_ibfk_2");

                //entity.HasOne(d => d.PersonalState)
                //    .WithMany(p => p.LeadApplicationDetailRefinancingPersonalStates)
                //    .HasForeignKey(d => d.PersonalStateId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("Lead_Application_Detail_Refinancing_ibfk_3");

                //entity.HasOne(d => d.PropertyCountry)
                //    .WithMany(p => p.LeadApplicationDetailRefinancings)
                //    .HasForeignKey(d => d.PropertyCountryId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("Lead_Application_Detail_Refinancing_ibfk_4");

                //entity.HasOne(d => d.PropertyState)
                //    .WithMany(p => p.)
                //    .HasForeignKey(d => d.PropertyStateId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("Lead_Application_Detail_Refinancing_ibfk_1");
            });

            modelBuilder.Entity<LeadApplicationQuestion>(entity =>
            {
                entity.ToTable("lead_application_questions");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Question)
                    .HasMaxLength(500)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<LeadApplicationType>(entity =>
            {
                entity.ToTable("lead_application_types");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.ApplicationType)
                    .HasMaxLength(50)
                    .HasColumnName("Application_Type")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<LeadAssetsDetail>(entity =>
            {
                entity.ToTable("lead_assets_details");

                entity.HasIndex(e => e.AssetTypeId, "AssetTypeId");

                entity.HasIndex(e => e.LeadApplicationDetailPurchasingId, "Lead_Application_Detail_Purchasing_Id");

                entity.HasIndex(e => e.LeadApplicationDetailRefinancingId, "Lead_Application_Detail_Refinancing_Id");

                entity.HasIndex(e => e.LeadApplicationTypeId, "Lead_Application_Type_Id");

                entity.HasIndex(e => e.OwnerTypeId, "OwnerTypeId");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.AssetTypeId).HasColumnType("int(11)");

                entity.Property(e => e.FinancialInstitution)
                    .HasMaxLength(100)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.LeadApplicationDetailPurchasingId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Lead_Application_Detail_Purchasing_Id");

                entity.Property(e => e.LeadApplicationDetailRefinancingId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Lead_Application_Detail_Refinancing_Id");

                entity.Property(e => e.LeadApplicationTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Lead_Application_Type_Id");

                entity.Property(e => e.OwnerTypeId).HasColumnType("int(11)");

                entity.HasOne(d => d.AssetType)
                    .WithMany(p => p.LeadAssetsDetails)
                    .HasForeignKey(d => d.AssetTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Lead_Assets_Details_ibfk_1");

                entity.HasOne(d => d.LeadApplicationDetailPurchasing)
                    .WithMany(p => p.LeadAssetsDetails)
                    .HasForeignKey(d => d.LeadApplicationDetailPurchasingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Lead_Assets_Details_ibfk_3");

                entity.HasOne(d => d.LeadApplicationDetailRefinancing)
                    .WithMany(p => p.LeadAssetsDetails)
                    .HasForeignKey(d => d.LeadApplicationDetailRefinancingId)
                    .HasConstraintName("Lead_Assets_Details_ibfk_4");

                entity.HasOne(d => d.LeadApplicationType)
                    .WithMany(p => p.LeadAssetsDetails)
                    .HasForeignKey(d => d.LeadApplicationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Lead_Assets_Details_ibfk_2");

                entity.HasOne(d => d.OwnerType)
                    .WithMany(p => p.LeadAssetsDetails)
                    .HasForeignKey(d => d.OwnerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Lead_Assets_Details_ibfk_5");
            });

            modelBuilder.Entity<LeadAssetsType>(entity =>
            {
                entity.ToTable("lead_assets_types");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.AssetsType)
                    .HasMaxLength(50)
                    .HasColumnName("Assets_Type")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<LeadEmployementDetail>(entity =>
            {
                entity.ToTable("lead_employement_details");

                entity.HasIndex(e => e.EmployeeTypeId, "EmployeeTypeId");

                entity.HasIndex(e => e.EmployementTaxeId, "EmployementTaxeId");

                entity.HasIndex(e => e.LeadApplicationDetailPurchasingId, "Lead_Application_Detail_Purchasing_Id");

                entity.HasIndex(e => e.LeadApplicationDetailRefinancingId, "Lead_Application_Detail_Refinancing_Id");

                entity.HasIndex(e => e.LeadApplicationTypeId, "Lead_Application_Type_Id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.EmployeeTypeId).HasColumnType("int(11)");

                entity.Property(e => e.EmployementAddress)
                    .HasMaxLength(500)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.EmployementCity)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.EmployementSuite)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.EmployementTaxeId).HasColumnType("int(11)");

                entity.Property(e => e.EmployementZip)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.EmployerName)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.EmployerPhoneNumber)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.EstimatedStartDate).HasColumnType("datetime");

                entity.Property(e => e.IsCoBorrower).HasColumnType("bit(1)");

                entity.Property(e => e.IsCurrentJob).HasColumnType("bit(1)");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.LeadApplicationDetailPurchasingId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Lead_Application_Detail_Purchasing_Id");

                entity.Property(e => e.LeadApplicationDetailRefinancingId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Lead_Application_Detail_Refinancing_Id");

                entity.Property(e => e.LeadApplicationTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Lead_Application_Type_Id");

                entity.HasOne(d => d.EmployeeType)
                    .WithMany(p => p.LeadEmployementDetails)
                    .HasForeignKey(d => d.EmployeeTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Lead_Employement_Details_ibfk_1");

                entity.HasOne(d => d.EmployementTaxe)
                    .WithMany(p => p.LeadEmployementDetails)
                    .HasForeignKey(d => d.EmployementTaxeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Lead_Employement_Details_ibfk_2");

                entity.HasOne(d => d.LeadApplicationDetailPurchasing)
                    .WithMany(p => p.LeadEmployementDetails)
                    .HasForeignKey(d => d.LeadApplicationDetailPurchasingId)
                    .HasConstraintName("Lead_Employement_Details_ibfk_4");

                entity.HasOne(d => d.LeadApplicationDetailRefinancing)
                    .WithMany(p => p.LeadEmployementDetails)
                    .HasForeignKey(d => d.LeadApplicationDetailRefinancingId)
                    .HasConstraintName("Lead_Employement_Details_ibfk_5");

                entity.HasOne(d => d.LeadApplicationType)
                    .WithMany(p => p.LeadEmployementDetails)
                    .HasForeignKey(d => d.LeadApplicationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Lead_Employement_Details_ibfk_3");
            });

            modelBuilder.Entity<LeadEmployementType>(entity =>
            {
                entity.ToTable("lead_employement_types");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.EmployementType)
                    .HasMaxLength(50)
                    .HasColumnName("Employement_Type")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<LeadIncomeType>(entity =>
            {
                entity.ToTable("lead_income_types");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.IncomeType)
                    .HasMaxLength(50)
                    .HasColumnName("Income_Type")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<LeadOwnerType>(entity =>
            {
                entity.ToTable("lead_owner_types");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.OwnerType)
                    .HasMaxLength(50)
                    .HasColumnName("Owner_Type")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<LeadQuestionAnswer>(entity =>
            {
                entity.ToTable("lead_question_answers");

                entity.HasIndex(e => e.LeadApplicationDetailPurchasingId, "Lead_Application_Detail_Purchasing_Id");

                entity.HasIndex(e => e.LeadApplicationDetailRefinancingId, "Lead_Application_Detail_Refinancing_Id");

                entity.HasIndex(e => e.LeadApplicationTypeId, "Lead_Application_Type_Id");

                entity.HasIndex(e => e.QuestionId, "QuestionId");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.IsYes).HasColumnType("bit(1)");

                entity.Property(e => e.LeadApplicationDetailPurchasingId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Lead_Application_Detail_Purchasing_Id");

                entity.Property(e => e.LeadApplicationDetailRefinancingId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Lead_Application_Detail_Refinancing_Id");

                entity.Property(e => e.LeadApplicationTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Lead_Application_Type_Id");

                entity.Property(e => e.QuestionId).HasColumnType("int(11)");

                entity.HasOne(d => d.LeadApplicationDetailPurchasing)
                    .WithMany(p => p.LeadQuestionAnswers)
                    .HasForeignKey(d => d.LeadApplicationDetailPurchasingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Lead_Question_Answers_ibfk_3");

                entity.HasOne(d => d.LeadApplicationDetailRefinancing)
                    .WithMany(p => p.LeadQuestionAnswers)
                    .HasForeignKey(d => d.LeadApplicationDetailRefinancingId)
                    .HasConstraintName("Lead_Question_Answers_ibfk_4");

                entity.HasOne(d => d.LeadApplicationType)
                    .WithMany(p => p.LeadQuestionAnswers)
                    .HasForeignKey(d => d.LeadApplicationTypeId)
                    .HasConstraintName("Lead_Question_Answers_ibfk_2");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.LeadQuestionAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Lead_Question_Answers_ibfk_1");
            });

            modelBuilder.Entity<LeadRefinancingIncomeDetail>(entity =>
            {
                entity.ToTable("lead_refinancing_income_details");

                entity.HasIndex(e => e.IncomeTypeId, "IncomeTypeId");

                entity.HasIndex(e => e.LeadApplicationDetailRefinancingId, "Lead_Application_Detail_Refinancing_Id");

                entity.HasIndex(e => e.LeadApplicationTypeId, "Lead_Application_Type_Id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.IncomeTypeId).HasColumnType("int(11)");

                entity.Property(e => e.LeadApplicationDetailRefinancingId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Lead_Application_Detail_Refinancing_Id");

                entity.Property(e => e.LeadApplicationTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Lead_Application_Type_Id");

                entity.HasOne(d => d.IncomeType)
                    .WithMany(p => p.LeadRefinancingIncomeDetails)
                    .HasForeignKey(d => d.IncomeTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Lead_Refinancing_Income_Details_ibfk_1");

                entity.HasOne(d => d.LeadApplicationDetailRefinancing)
                    .WithMany(p => p.LeadRefinancingIncomeDetails)
                    .HasForeignKey(d => d.LeadApplicationDetailRefinancingId)
                    .HasConstraintName("Lead_Refinancing_Income_Details_ibfk_3");

                entity.HasOne(d => d.LeadApplicationType)
                    .WithMany(p => p.LeadRefinancingIncomeDetails)
                    .HasForeignKey(d => d.LeadApplicationTypeId)
                    .HasConstraintName("Lead_Refinancing_Income_Details_ibfk_2");
            });

            modelBuilder.Entity<LeadTaxesType>(entity =>
            {
                entity.ToTable("lead_taxes_types");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.TaxesType)
                    .HasMaxLength(50)
                    .HasColumnName("Taxes_Type")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
