using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagement.Migrations.Mortgagedb
{
    public partial class DbUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.CreateTable(
                name: "citizenship_types",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CITIZENSHIP_TYPE = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_citizenship_types", x => x.ID);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    COUNTRY_NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.ID);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "credit_types",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CREDIT_TYPE = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_credit_types", x => x.ID);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "declaration_categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DECLARATION_CATEGORY = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_declaration_categories", x => x.ID);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "demographic_info_sources",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VALUE = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_demographic_info_sources", x => x.ID);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "financial_account_types",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FINANCIAL_ACCOUNT_TYPE = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financial_account_types", x => x.ID);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "financial_assets_types",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FINANCIAL_CREDIT_TYPE = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financial_assets_types", x => x.ID);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "financial_laibilities_types",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FINANCIAL_LAIBILITIES_TYPE = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financial_laibilities_types", x => x.ID);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "financial_other_laibilities_types",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FINANCIAL_OTHER_LAIBILITIES_TYPE = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financial_other_laibilities_types", x => x.ID);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "financial_property_intended_occupancies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FINANCIAL_PROPERTY_INTENDED_OCCUPANCY = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financial_property_intended_occupancies", x => x.ID);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "financial_property_status",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FINANCIAL_PROPERTY_STATUS = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financial_property_status", x => x.ID);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "housing_types",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HOUSING_TYPE = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_housing_types", x => x.ID);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "income_sources",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    INCOME_SOURCE = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_income_sources", x => x.ID);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "income_types",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    INCOME_TYPE = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_income_types", x => x.ID);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "loan_property_gift_types",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LOAN_PROPERTY_GIFT_TYPE = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loan_property_gift_types", x => x.ID);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "loan_property_occupancies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LOAN_PROPERTY_OCCUPANCY = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loan_property_occupancies", x => x.ID);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "maritial_status",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MARITIAL_STATUS = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maritial_status", x => x.ID);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "mortage_loan_types",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MORTAGE_LOAN_TYPES_ID = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mortage_loan_types", x => x.ID);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "country_states",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    COUNTRY_ID = table.Column<int>(type: "int(11)", nullable: false),
                    STATE_NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country_states", x => x.ID);
                    table.ForeignKey(
                        name: "states_ibfk_1",
                        column: x => x.COUNTRY_ID,
                        principalTable: "countries",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "applications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DATE = table.Column<DateTime>(type: "datetime(3)", nullable: false),
                    LOANNO_IDENTIFIER_B1_B3 = table.Column<string>(name: "LOAN NO_IDENTIFIER_B1_B3", type: "varchar(15)", maxLength: 15, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    AGENCY_CASE_NO_B2 = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    CREDIT_TYPE_ID = table.Column<int>(type: "int(11)", nullable: false),
                    TOTAL_BORROWERS_1A6 = table.Column<int>(name: "TOTAL_BORROWERS_1A.6", type: "int(11)", nullable: true),
                    INITIALS = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applications", x => x.ID);
                    table.ForeignKey(
                        name: "applications_ibfk_1",
                        column: x => x.CREDIT_TYPE_ID,
                        principalTable: "credit_types",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "declaration_questions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DECLARATION_CATEGORY_ID = table.Column<int>(type: "int(11)", nullable: true),
                    PARENT_QUESTION_ID = table.Column<int>(type: "int(11)", nullable: true),
                    QUESTION = table.Column<string>(type: "varchar(9999)", maxLength: 9999, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    IS_ACTIVE = table.Column<ulong>(type: "bit(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_declaration_questions", x => x.ID);
                    table.ForeignKey(
                        name: "declaration_questions_ibfk_1",
                        column: x => x.DECLARATION_CATEGORY_ID,
                        principalTable: "declaration_categories",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    STATE_ID = table.Column<int>(type: "int(11)", nullable: false),
                    CITY_NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.ID);
                    table.ForeignKey(
                        name: "cities_ibfk_1",
                        column: x => x.STATE_ID,
                        principalTable: "country_states",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "application_personal_information",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    APPLICATION_ID = table.Column<int>(type: "int(11)", nullable: false),
                    FIRST_NAME_1A1 = table.Column<string>(name: "FIRST_NAME_1A.1", type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    MIDDLE_NAME_1A2 = table.Column<string>(name: "MIDDLE_NAME_1A.2", type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    LAST_NAME_1A3 = table.Column<string>(name: "LAST_NAME_1A.3", type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    SUFFIX_1A4 = table.Column<string>(name: "SUFFIX_1A.4", type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ALTERNATE_FIRST_NAME_1A21 = table.Column<string>(name: "ALTERNATE_FIRST_NAME_1A.2.1", type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ALTERNATE_MIDDLE_NAME_1A22 = table.Column<string>(name: "ALTERNATE_MIDDLE_NAME_1A.2.2", type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ALTERNATE_LAST_NAME_1A23 = table.Column<string>(name: "ALTERNATE_LAST_NAME_1A.2.3", type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ALTERNATE_SUFFIX_1A24 = table.Column<string>(name: "ALTERNATE_SUFFIX_1A.2.4", type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    SSN_1A3 = table.Column<string>(name: "SSN_1A.3", type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    DOB_1A4 = table.Column<DateTime>(name: "DOB_1A.4", type: "datetime", nullable: true),
                    CITIZENSHIP_TYPE_ID_1A5 = table.Column<int>(name: "CITIZENSHIP_TYPE_ID_1A.5", type: "int(11)", nullable: false),
                    MARITIAL_STATUS_ID_1A7 = table.Column<int>(name: "MARITIAL_STATUS_ID_1A.7", type: "int(11)", nullable: false),
                    DEPENDENTS_1A8 = table.Column<int>(name: "DEPENDENTS_1A.8", type: "int(11)", nullable: true),
                    AGES_1A81 = table.Column<string>(name: "AGES_1A.8.1", type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    HOME_PHONE_1A9 = table.Column<string>(name: "HOME_PHONE_1A.9", type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    CELL_PHONE_1A10 = table.Column<string>(name: "CELL_PHONE_1A.10", type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    WORK_PHONE_1A11 = table.Column<string>(name: "WORK_PHONE_1A.11", type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    EXT_1A111 = table.Column<string>(name: "EXT_1A.11.1", type: "varchar(5)", maxLength: 5, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    EMAIL_1A12 = table.Column<string>(name: "EMAIL_1A.12", type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    CURRENT_STREET_1A131 = table.Column<string>(name: "CURRENT_STREET_1A.13.1", type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    CURRENT_UNIT_1A132 = table.Column<string>(name: "CURRENT_UNIT_1A.13.2", type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    CURRENT_ZIP_1A135 = table.Column<string>(name: "CURRENT_ZIP_1A.13.5", type: "varchar(10)", maxLength: 10, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    CURRENT_COUNTRY_ID_1A136 = table.Column<int>(name: "CURRENT_COUNTRY_ID_1A.13.6", type: "int(11)", nullable: false),
                    CURRENT_STATE_ID_1A134 = table.Column<int>(name: "CURRENT_STATE_ID_1A.13.4", type: "int(11)", nullable: false),
                    CURRENT_CITY_ID_1A133 = table.Column<int>(name: "CURRENT_CITY_ID_1A.13.3", type: "int(11)", nullable: false),
                    CURRENT_YEARS_1A14 = table.Column<int>(name: "CURRENT_YEARS_1A.14", type: "int(11)", nullable: true),
                    CURRENT_MONTHS_1A15 = table.Column<int>(name: "CURRENT_MONTHS_1A.15", type: "int(11)", nullable: true),
                    CURRENT_HOUSING_TYPE_ID_1A141 = table.Column<int>(name: "CURRENT_HOUSING_TYPE_ID_1A.14.1", type: "int(11)", nullable: false),
                    CURRENT_RENT_1A142 = table.Column<float>(name: "CURRENT_RENT_1A.14.2", type: "float", nullable: true),
                    FORMER_STREET_1A151 = table.Column<string>(name: "FORMER_STREET_1A.15.1", type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    FORMER_UNIT_1A152 = table.Column<string>(name: "FORMER_UNIT_1A.15.2", type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    FORMER_ZIP_1A155 = table.Column<string>(name: "FORMER_ZIP_1A.15.5", type: "varchar(10)", maxLength: 10, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    FORMER_COUNTRY_ID_1A156 = table.Column<int>(name: "FORMER_COUNTRY_ID_1A.15.6", type: "int(11)", nullable: false),
                    FORMER_STATE_ID_1A154 = table.Column<int>(name: "FORMER_STATE_ID_1A.15.4", type: "int(11)", nullable: false),
                    FORMER_CITY_ID_1A153 = table.Column<int>(name: "FORMER_CITY_ID_1A.15.3", type: "int(11)", nullable: false),
                    FORMER_YEARS_1A16 = table.Column<int>(name: "FORMER_YEARS_1A.16", type: "int(11)", nullable: true),
                    FORMER_MONTHS_1A161 = table.Column<int>(name: "FORMER_MONTHS_1A.16.1", type: "int(11)", nullable: true),
                    FORMER_HOUSING_TYPE_ID_1A161 = table.Column<int>(name: "FORMER_HOUSING_TYPE_ID_1A.16.1", type: "int(11)", nullable: false),
                    FORMER_RENT_1A162 = table.Column<float>(name: "FORMER_RENT_1A.16.2", type: "float", nullable: true),
                    MAILING_STREET_1A171 = table.Column<string>(name: "MAILING_STREET_1A.17.1", type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    MAILING_UNIT_1A172 = table.Column<string>(name: "MAILING_UNIT_1A.17.2", type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    MAILING_ZIP_1A175 = table.Column<string>(name: "MAILING_ZIP_1A.17.5", type: "varchar(10)", maxLength: 10, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    MAILING_COUNTRY_ID_1A176 = table.Column<int>(name: "MAILING_COUNTRY_ID_1A.17.6", type: "int(11)", nullable: false),
                    MAILING_STATE_ID_1A174 = table.Column<int>(name: "MAILING_STATE_ID_1A.17.4", type: "int(11)", nullable: false),
                    MAILING_CITY_ID_1A173 = table.Column<int>(name: "MAILING_CITY_ID_1A.17.3", type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_application_personal_information", x => x.ID);
                    table.ForeignKey(
                        name: "application_personal_information_ibfk_1",
                        column: x => x.APPLICATION_ID,
                        principalTable: "applications",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_personal_information_ibfk_10",
                        column: x => x.FORMER_CITY_ID_1A153,
                        principalTable: "cities",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_personal_information_ibfk_11",
                        column: x => x.FORMER_HOUSING_TYPE_ID_1A161,
                        principalTable: "housing_types",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_personal_information_ibfk_12",
                        column: x => x.MAILING_COUNTRY_ID_1A176,
                        principalTable: "countries",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_personal_information_ibfk_13",
                        column: x => x.MAILING_STATE_ID_1A174,
                        principalTable: "country_states",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_personal_information_ibfk_14",
                        column: x => x.MAILING_CITY_ID_1A173,
                        principalTable: "cities",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_personal_information_ibfk_2",
                        column: x => x.CITIZENSHIP_TYPE_ID_1A5,
                        principalTable: "citizenship_types",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_personal_information_ibfk_3",
                        column: x => x.MARITIAL_STATUS_ID_1A7,
                        principalTable: "maritial_status",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_personal_information_ibfk_4",
                        column: x => x.CURRENT_COUNTRY_ID_1A136,
                        principalTable: "countries",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_personal_information_ibfk_5",
                        column: x => x.CURRENT_STATE_ID_1A134,
                        principalTable: "country_states",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_personal_information_ibfk_6",
                        column: x => x.CURRENT_CITY_ID_1A133,
                        principalTable: "cities",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_personal_information_ibfk_7",
                        column: x => x.CURRENT_HOUSING_TYPE_ID_1A141,
                        principalTable: "housing_types",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_personal_information_ibfk_8",
                        column: x => x.FORMER_COUNTRY_ID_1A156,
                        principalTable: "countries",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_personal_information_ibfk_9",
                        column: x => x.FORMER_STATE_ID_1A154,
                        principalTable: "country_states",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "application_additional_employement_details",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    APPLICATION_PERSONAL_INFORMATION_ID = table.Column<int>(type: "int(11)", nullable: true),
                    EMPLOYERBUSINESS_NAME = table.Column<string>(name: "EMPLOYER/BUSINESS_NAME", type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    PHONE = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    STREET = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    UNIT = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ZIP = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    COUNTRY_ID = table.Column<int>(type: "int(11)", nullable: false),
                    STATE_ID = table.Column<int>(type: "int(11)", nullable: false),
                    CITY_ID = table.Column<int>(type: "int(11)", nullable: false),
                    POSITION_TITLE = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    START_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    WORKING_YEARS = table.Column<int>(type: "int(11)", nullable: true),
                    WORKING_MONTHS = table.Column<int>(type: "int(11)", nullable: true),
                    IS_EMPLOYED_BY_SOMEONE = table.Column<ulong>(type: "bit(1)", nullable: true),
                    IS_SELF_EMPLOYED = table.Column<ulong>(type: "bit(1)", nullable: true),
                    IS_OWNERSHIP_LESS_THAN_25 = table.Column<ulong>(type: "bit(1)", nullable: true),
                    MONTHLY_INCOME = table.Column<float>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_application_additional_employement_details", x => x.ID);
                    table.ForeignKey(
                        name: "application_additional_employement_details_ibfk_1",
                        column: x => x.APPLICATION_PERSONAL_INFORMATION_ID,
                        principalTable: "application_personal_information",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_additional_employement_details_ibfk_2",
                        column: x => x.COUNTRY_ID,
                        principalTable: "countries",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_additional_employement_details_ibfk_3",
                        column: x => x.STATE_ID,
                        principalTable: "country_states",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_additional_employement_details_ibfk_4",
                        column: x => x.CITY_ID,
                        principalTable: "cities",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "application_declaration_questions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    APPLICATION_PERSONAL_INFORMATION_ID = table.Column<int>(type: "int(11)", nullable: true),
                    DECLARATION_QUESTION_ID = table.Column<int>(type: "int(11)", nullable: true),
                    YES_NO = table.Column<ulong>(type: "bit(1)", nullable: true),
                    DESCRIPTION_5A = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_application_declaration_questions", x => x.ID);
                    table.ForeignKey(
                        name: "application_declaration_questions_ibfk_1",
                        column: x => x.APPLICATION_PERSONAL_INFORMATION_ID,
                        principalTable: "application_personal_information",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_declaration_questions_ibfk_2",
                        column: x => x.DECLARATION_QUESTION_ID,
                        principalTable: "declaration_questions",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "application_employement_details",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    APPLICATION_PERSONAL_INFORMATION_ID = table.Column<int>(type: "int(11)", nullable: true),
                    EMPLOYERBUSINESS_NAME_1B2 = table.Column<string>(name: "EMPLOYER/BUSINESS_NAME_1B.2", type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    PHONE_1B3 = table.Column<string>(name: "PHONE_1B.3", type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    STREET_1B41 = table.Column<string>(name: "STREET_1B.4.1", type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    UNIT_1B42 = table.Column<string>(name: "UNIT_1B.4.2", type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ZIP_1B45 = table.Column<string>(name: "ZIP_1B.4.5", type: "varchar(10)", maxLength: 10, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    COUNTRY_ID_1B46 = table.Column<int>(name: "COUNTRY_ID_1B.4.6", type: "int(11)", nullable: false),
                    STATE_ID_1B44 = table.Column<int>(name: "STATE_ID_1B.4.4", type: "int(11)", nullable: false),
                    CITY_ID_1B43 = table.Column<int>(name: "CITY_ID_1B.4.3", type: "int(11)", nullable: false),
                    POSITION_TITLE_1B5 = table.Column<string>(name: "POSITION_TITLE_1B.5", type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    START_DATE_1B6 = table.Column<DateTime>(name: "START_DATE_1B.6", type: "datetime", nullable: true),
                    WORKING_YEARS_1B7 = table.Column<int>(name: "WORKING_YEARS_1B.7", type: "int(11)", nullable: true),
                    WORKING_MONTHS = table.Column<int>(type: "int(11)", nullable: true),
                    IS_EMPLOYED_BY_SOMEONE_1B8 = table.Column<ulong>(name: "IS_EMPLOYED_BY_SOMEONE_1B.8", type: "bit(1)", nullable: true),
                    IS_SELF_EMPLOYED_1B9 = table.Column<ulong>(name: "IS_SELF_EMPLOYED_1B.9", type: "bit(1)", nullable: true),
                    IS_OWNERSHIP_LESS_THAN_25_1B91 = table.Column<ulong>(name: "IS_OWNERSHIP_LESS_THAN_25_1B.9.1", type: "bit(1)", nullable: true),
                    MONTHLY_INCOME_1B92 = table.Column<float>(name: "MONTHLY_INCOME_1B.9.2", type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_application_employement_details", x => x.ID);
                    table.ForeignKey(
                        name: "application_employement_details_ibfk_1",
                        column: x => x.APPLICATION_PERSONAL_INFORMATION_ID,
                        principalTable: "application_personal_information",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_employement_details_ibfk_2",
                        column: x => x.COUNTRY_ID_1B46,
                        principalTable: "countries",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_employement_details_ibfk_3",
                        column: x => x.STATE_ID_1B44,
                        principalTable: "country_states",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_employement_details_ibfk_4",
                        column: x => x.CITY_ID_1B43,
                        principalTable: "cities",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "application_financial_assets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    APPLICATION_PERSONAL_INFORMATION_ID = table.Column<int>(type: "int(11)", nullable: true),
                    FINANCIAL_ACCOUNT_TYPE_ID_2A1 = table.Column<int>(name: "FINANCIAL_ACCOUNT_TYPE_ID_2A.1", type: "int(11)", nullable: false),
                    FINANCIAL_INSTITUTION_2A2 = table.Column<string>(name: "FINANCIAL_INSTITUTION_2A.2", type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ACCOUNT_NUMBER_2A3 = table.Column<string>(name: "ACCOUNT_NUMBER_2A.3", type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    VALUE_2A4 = table.Column<float>(name: "VALUE_2A.4", type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_application_financial_assets", x => x.ID);
                    table.ForeignKey(
                        name: "application_financial_assets_ibfk_1",
                        column: x => x.APPLICATION_PERSONAL_INFORMATION_ID,
                        principalTable: "application_personal_information",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_financial_assets_ibfk_2",
                        column: x => x.FINANCIAL_ACCOUNT_TYPE_ID_2A1,
                        principalTable: "financial_account_types",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "application_financial_laibilities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    APPLICATION_PERSONAL_INFORMATION_ID = table.Column<int>(type: "int(11)", nullable: true),
                    FINANCIAL_LAIBILITIES_TYPE_2C1 = table.Column<int>(name: "FINANCIAL_LAIBILITIES_TYPE_2C.1", type: "int(11)", nullable: false),
                    COMPANY_NAME_2C2 = table.Column<string>(name: "COMPANY_NAME_2C.2", type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ACCOUNT_NUMBER_2C3 = table.Column<string>(name: "ACCOUNT_NUMBER_2C.3", type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    UNPAID_BALANCE_2C4 = table.Column<float>(name: "UNPAID_BALANCE_2C.4", type: "float", nullable: true),
                    PAID_OFF_2C5 = table.Column<ulong>(name: "PAID_OFF_2C.5", type: "bit(1)", nullable: true),
                    MONTHLY_VALUE_2C6 = table.Column<float>(name: "MONTHLY_VALUE_2C.6", type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_application_financial_laibilities", x => x.ID);
                    table.ForeignKey(
                        name: "application_financial_laibilities_ibfk_1",
                        column: x => x.APPLICATION_PERSONAL_INFORMATION_ID,
                        principalTable: "application_personal_information",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_financial_laibilities_ibfk_2",
                        column: x => x.FINANCIAL_LAIBILITIES_TYPE_2C1,
                        principalTable: "financial_laibilities_types",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "application_financial_other_assets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    APPLICATION_PERSONAL_INFORMATION_ID = table.Column<int>(type: "int(11)", nullable: true),
                    FINANCIAL_ASSETS_TYPES_ID_2B1 = table.Column<int>(name: "FINANCIAL_ASSETS_TYPES_ID_2B.1", type: "int(11)", nullable: false),
                    VALUE_2B2 = table.Column<float>(name: "VALUE_2B.2", type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_application_financial_other_assets", x => x.ID);
                    table.ForeignKey(
                        name: "application_financial_other_assets_ibfk_1",
                        column: x => x.APPLICATION_PERSONAL_INFORMATION_ID,
                        principalTable: "application_personal_information",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_financial_other_assets_ibfk_2",
                        column: x => x.FINANCIAL_ASSETS_TYPES_ID_2B1,
                        principalTable: "financial_assets_types",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "application_financial_other_laibilities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    APPLICATION_PERSONAL_INFORMATION_ID = table.Column<int>(type: "int(11)", nullable: true),
                    FINANCIAL_OTHER_LAIBILITIES_TYPE_ID_2D1 = table.Column<int>(name: "FINANCIAL_OTHER_LAIBILITIES_TYPE_ID_2D.1", type: "int(11)", nullable: false),
                    MONTHLY_PAYMENT_2D2 = table.Column<float>(name: "MONTHLY_PAYMENT_2D.2", type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_application_financial_other_laibilities", x => x.ID);
                    table.ForeignKey(
                        name: "application_financial_other_laibilities_ibfk_1",
                        column: x => x.APPLICATION_PERSONAL_INFORMATION_ID,
                        principalTable: "application_personal_information",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_financial_other_laibilities_ibfk_2",
                        column: x => x.FINANCIAL_OTHER_LAIBILITIES_TYPE_ID_2D1,
                        principalTable: "financial_other_laibilities_types",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "application_financial_real_estate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    APPLICATION_PERSONAL_INFORMATION_ID = table.Column<int>(type: "int(11)", nullable: true),
                    STREET_3A21 = table.Column<string>(name: "STREET_3A.2.1", type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    UNIT_NO_3A22 = table.Column<string>(name: "UNIT_NO_3A.2.2", type: "varchar(10)", maxLength: 10, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ZIP_3A25 = table.Column<string>(name: "ZIP_3A.2.5", type: "varchar(10)", maxLength: 10, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    COUNTRY_ID_3A26 = table.Column<int>(name: "COUNTRY_ID_3A.2.6", type: "int(11)", nullable: false),
                    STATE_ID_3A24 = table.Column<int>(name: "STATE_ID_3A.2.4", type: "int(11)", nullable: false),
                    CITY_ID_3A23 = table.Column<int>(name: "CITY_ID_3A.2.3", type: "int(11)", nullable: false),
                    PROPERTY_VALUE_3A3 = table.Column<float>(name: "PROPERTY_VALUE_3A.3", type: "float", nullable: true),
                    FINANCIAL_PROPERTY_STATUS_ID_3A4 = table.Column<int>(name: "FINANCIAL_PROPERTY_STATUS_ID_3A.4", type: "int(11)", nullable: false),
                    FINANCIAL_PROPERTY_INTENDED_OCCUPANCY_ID_3A5 = table.Column<int>(name: "FINANCIAL_PROPERTY_INTENDED_OCCUPANCY_ID_3A.5", type: "int(11)", nullable: false),
                    MONTHLY_MORTAGE_PAYMENT_3A6 = table.Column<float>(name: "MONTHLY_MORTAGE_PAYMENT_3A.6", type: "float", nullable: true),
                    MONTHLY_RENTAL_INCOME_3A7 = table.Column<float>(name: "MONTHLY_RENTAL_INCOME_3A.7", type: "float", nullable: true),
                    NET_MONTHLY_RENTAL_INCOME_3A8 = table.Column<float>(name: "NET_MONTHLY_RENTAL_INCOME_3A.8", type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_application_financial_real_estate", x => x.ID);
                    table.ForeignKey(
                        name: "application_financial_real_estate_ibfk_1",
                        column: x => x.APPLICATION_PERSONAL_INFORMATION_ID,
                        principalTable: "application_personal_information",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_financial_real_estate_ibfk_2",
                        column: x => x.COUNTRY_ID_3A26,
                        principalTable: "countries",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_financial_real_estate_ibfk_3",
                        column: x => x.STATE_ID_3A24,
                        principalTable: "country_states",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_financial_real_estate_ibfk_4",
                        column: x => x.CITY_ID_3A23,
                        principalTable: "cities",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_financial_real_estate_ibfk_5",
                        column: x => x.FINANCIAL_PROPERTY_STATUS_ID_3A4,
                        principalTable: "financial_property_status",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_financial_real_estate_ibfk_6",
                        column: x => x.FINANCIAL_PROPERTY_INTENDED_OCCUPANCY_ID_3A5,
                        principalTable: "financial_property_intended_occupancies",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "application_income_sources",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    APPLICATION_PERSONAL_INFORMATION_ID = table.Column<int>(type: "int(11)", nullable: true),
                    INCOME_SOURCE_ID_1E1 = table.Column<int>(name: "INCOME_SOURCE_ID_1E.1", type: "int(11)", nullable: false),
                    AMOUNT_1E2 = table.Column<float>(name: "AMOUNT_1E.2", type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_application_income_sources", x => x.ID);
                    table.ForeignKey(
                        name: "application_income_sources_ibfk_1",
                        column: x => x.APPLICATION_PERSONAL_INFORMATION_ID,
                        principalTable: "application_personal_information",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_income_sources_ibfk_2",
                        column: x => x.INCOME_SOURCE_ID_1E1,
                        principalTable: "income_sources",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "application_previous_employement_details",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    APPLICATION_PERSONAL_INFORMATION_ID = table.Column<int>(type: "int(11)", nullable: true),
                    EMPLOYERBUSINESS_NAME_1D2 = table.Column<string>(name: "EMPLOYER/BUSINESS_NAME_1D.2", type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    STREET_1D31 = table.Column<string>(name: "STREET_1D.3.1", type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    UNIT_1D32 = table.Column<string>(name: "UNIT_1D.3.2", type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ZIP_1D35 = table.Column<string>(name: "ZIP_1D.3.5", type: "varchar(10)", maxLength: 10, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    COUNTRY_ID_1D36 = table.Column<int>(name: "COUNTRY_ID_1D.3.6", type: "int(11)", nullable: false),
                    STATE_ID_1D34 = table.Column<int>(name: "STATE_ID_1D.3.4", type: "int(11)", nullable: false),
                    CITY_ID_1D33 = table.Column<int>(name: "CITY_ID_1D.3.3", type: "int(11)", nullable: false),
                    POSITION_TITLE_1D4 = table.Column<string>(name: "POSITION_TITLE_1D.4", type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    START_DATE_1D5 = table.Column<DateTime>(name: "START_DATE_1D.5", type: "datetime", nullable: true),
                    END_DATE_1D6 = table.Column<DateTime>(name: "END_DATE_1D.6", type: "datetime", nullable: true),
                    IS_SELF_EMPLOYED_1D7 = table.Column<ulong>(name: "IS_SELF_EMPLOYED_1D.7", type: "bit(1)", nullable: true),
                    GROSS_MONTHLY_INCOME_1D8 = table.Column<float>(name: "GROSS_MONTHLY_INCOME_1D.8", type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_application_previous_employement_details", x => x.ID);
                    table.ForeignKey(
                        name: "application_previous_employement_details_ibfk_1",
                        column: x => x.APPLICATION_PERSONAL_INFORMATION_ID,
                        principalTable: "application_personal_information",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_previous_employement_details_ibfk_2",
                        column: x => x.COUNTRY_ID_1D36,
                        principalTable: "countries",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_previous_employement_details_ibfk_3",
                        column: x => x.STATE_ID_1D34,
                        principalTable: "country_states",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_previous_employement_details_ibfk_4",
                        column: x => x.CITY_ID_1D33,
                        principalTable: "cities",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "demographic_information",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    APPLICATION_PERSONAL_INFORMATION_ID = table.Column<int>(type: "int(11)", nullable: true),
                    ETHNICITY_81 = table.Column<string>(name: "ETHNICITY_8.1", type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    GENDER_82 = table.Column<string>(name: "GENDER_8.2", type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    RACE_83 = table.Column<string>(name: "RACE_8.3", type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    IS_ETHNICITY_BY_OBSERVATION_84 = table.Column<ulong>(name: "IS_ETHNICITY_BY_OBSERVATION_8.4", type: "bit(1)", nullable: true),
                    IS_GENDER_BY_OBSERVATION_85 = table.Column<ulong>(name: "IS_GENDER_BY_OBSERVATION_8.5", type: "bit(1)", nullable: true),
                    IS_RACE_BY_OBSERVATION_86 = table.Column<ulong>(name: "IS_RACE_BY_OBSERVATION_8.6", type: "bit(1)", nullable: true),
                    DEMOGRAPHIC_INFO_SOURCE_ID_87 = table.Column<int>(name: "DEMOGRAPHIC_INFO_SOURCE_ID_8.7", type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_demographic_information", x => x.ID);
                    table.ForeignKey(
                        name: "demographic_information_ibfk_1",
                        column: x => x.APPLICATION_PERSONAL_INFORMATION_ID,
                        principalTable: "application_personal_information",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "demographic_information_ibfk_2",
                        column: x => x.DEMOGRAPHIC_INFO_SOURCE_ID_87,
                        principalTable: "demographic_info_sources",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "loan_and_property_information",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    APPLICATION_PERSONAL_INFORMATION_ID = table.Column<int>(type: "int(11)", nullable: true),
                    LOAN_AMOUNT_4A1 = table.Column<float>(name: "LOAN_AMOUNT_4A.1", type: "float", nullable: true),
                    LOAN_PURPOSE_4A2 = table.Column<string>(name: "LOAN_PURPOSE_4A.2", type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    PROPERTY_STREET_4A31 = table.Column<string>(name: "PROPERTY_STREET_4A.3.1", type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    PROPERTY_UNIT_NO_4A32 = table.Column<string>(name: "PROPERTY_UNIT_NO_4A.3.2", type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    PROPERTY_ZIP_4A35 = table.Column<string>(name: "PROPERTY_ZIP_4A.3.5", type: "varchar(10)", maxLength: 10, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    COUNTRY_ID_4A36 = table.Column<int>(name: "COUNTRY_ID_4A.3.6", type: "int(11)", nullable: false),
                    STATE_ID_4A34 = table.Column<int>(name: "STATE_ID_4A.3.4", type: "int(11)", nullable: false),
                    CITY_ID_4A33 = table.Column<int>(name: "CITY_ID_4A.3.3", type: "int(11)", nullable: false),
                    PROPERTY_NUMBER_UNITS_4A4 = table.Column<int>(name: "PROPERTY_NUMBER_UNITS_4A.4", type: "int(11)", nullable: true),
                    PROPERTY_VALUE_4A5 = table.Column<float>(name: "PROPERTY_VALUE_4A.5", type: "float", nullable: true),
                    LOAN_PROPERTY_OCCUPANCY_ID_4A6 = table.Column<int>(name: "LOAN_PROPERTY_OCCUPANCY_ID_4A.6", type: "int(11)", nullable: true),
                    FHA_SECONDARY_RESIDANCE_4A61 = table.Column<ulong>(name: "FHA_SECONDARY_RESIDANCE_4A.6.1", type: "bit(1)", nullable: true),
                    IS_MIXED_USE_PROPERTY_4A7 = table.Column<ulong>(name: "IS_MIXED_USE_PROPERTY_4A.7", type: "bit(1)", nullable: true),
                    IS_MANUFACTURED_HOME_4A8 = table.Column<ulong>(name: "IS_MANUFACTURED_HOME_4A.8", type: "bit(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loan_and_property_information", x => x.ID);
                    table.ForeignKey(
                        name: "loan_and_property_information_ibfk_1",
                        column: x => x.APPLICATION_PERSONAL_INFORMATION_ID,
                        principalTable: "application_personal_information",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "loan_and_property_information_ibfk_2",
                        column: x => x.COUNTRY_ID_4A36,
                        principalTable: "countries",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "loan_and_property_information_ibfk_3",
                        column: x => x.STATE_ID_4A34,
                        principalTable: "country_states",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "loan_and_property_information_ibfk_4",
                        column: x => x.CITY_ID_4A33,
                        principalTable: "cities",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "loan_and_property_information_ibfk_5",
                        column: x => x.LOAN_PROPERTY_OCCUPANCY_ID_4A6,
                        principalTable: "loan_property_occupancies",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "loan_and_property_information_gifts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    APPLICATION_PERSONAL_INFORMATION_ID = table.Column<int>(type: "int(11)", nullable: true),
                    LOAN_PROPERTY_GIFT_TYPE_ID_4D1 = table.Column<int>(name: "LOAN_PROPERTY_GIFT_TYPE_ID_4D.1", type: "int(11)", nullable: true),
                    DEPOSITED_4D2 = table.Column<ulong>(name: "DEPOSITED_4D.2", type: "bit(1)", nullable: true),
                    SOURCE_4D3 = table.Column<string>(name: "SOURCE_4D.3", type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    VALUE_4D4 = table.Column<float>(name: "VALUE_4D.4", type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loan_and_property_information_gifts", x => x.ID);
                    table.ForeignKey(
                        name: "loan_and_property_information_gifts_ibfk_1",
                        column: x => x.APPLICATION_PERSONAL_INFORMATION_ID,
                        principalTable: "application_personal_information",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "loan_and_property_information_gifts_ibfk_2",
                        column: x => x.LOAN_PROPERTY_GIFT_TYPE_ID_4D1,
                        principalTable: "loan_property_gift_types",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "loan_and_property_information_other_mortage_loan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    APPLICATION_PERSONAL_INFORMATION_ID = table.Column<int>(type: "int(11)", nullable: true),
                    CREDITOR_NAME_4B1 = table.Column<string>(name: "CREDITOR_NAME_4B.1", type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    LIEN_TYPE_4B2 = table.Column<string>(name: "LIEN_TYPE_4B.2", type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    MONTHLY_PAYMENT_4B3 = table.Column<float>(name: "MONTHLY_PAYMENT_4B.3", type: "float", nullable: true),
                    LOAN_AMOUNT_4B4 = table.Column<float>(name: "LOAN_AMOUNT_4B.4", type: "float", nullable: true),
                    CREDIT_AMOUNT_4B5 = table.Column<float>(name: "CREDIT_AMOUNT_4B.5", type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loan_and_property_information_other_mortage_loan", x => x.ID);
                    table.ForeignKey(
                        name: "loan_and_property_information_other_mortage_loan_ibfk_1",
                        column: x => x.APPLICATION_PERSONAL_INFORMATION_ID,
                        principalTable: "application_personal_information",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "loan_and_property_information_rental_income",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    APPLICATION_PERSONAL_INFORMATION_ID = table.Column<int>(type: "int(11)", nullable: true),
                    EXPECTED_MONTHLY_INCOME_4C1 = table.Column<float>(name: "EXPECTED_MONTHLY_INCOME_4C.1", type: "float", nullable: true),
                    LENDER_EXPECTED_MONTHLY_INCOME_4C2 = table.Column<float>(name: "LENDER_EXPECTED_MONTHLY_INCOME_4C.2", type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loan_and_property_information_rental_income", x => x.ID);
                    table.ForeignKey(
                        name: "loan_and_property_information_rental_income_ibfk_1",
                        column: x => x.APPLICATION_PERSONAL_INFORMATION_ID,
                        principalTable: "application_personal_information",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "loan_originator_information",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    APPLICATION_PERSONAL_INFORMATION_ID = table.Column<int>(type: "int(11)", nullable: true),
                    ORGANIZATION_NAME_91 = table.Column<string>(name: "ORGANIZATION_NAME_9.1", type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ADDRESS_92 = table.Column<string>(name: "ADDRESS_9.2", type: "varchar(9999)", maxLength: 9999, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ORGANIZATION_NMLSR_ID_93 = table.Column<string>(name: "ORGANIZATION_NMLSR_ID_9.3", type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ORGANIZATION_STATE_LICENCE_94 = table.Column<string>(name: "ORGANIZATION_STATE_LICENCE_9.4", type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ORIGINATOR_NAME_95 = table.Column<string>(name: "ORIGINATOR_NAME_9.5", type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ORIGINATOR_NMLSR_ID_96 = table.Column<string>(name: "ORIGINATOR_NMLSR_ID_9.6", type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ORIGINATOR_STATE_LICENSE_97 = table.Column<string>(name: "ORIGINATOR_STATE_LICENSE_9.7", type: "varchar(25)", maxLength: 25, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    EMAIL_98 = table.Column<string>(name: "EMAIL_9.8", type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    PHONE_99 = table.Column<string>(name: "PHONE_9.9", type: "varchar(25)", maxLength: 25, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    DATE_910 = table.Column<DateTime>(name: "DATE_9.10", type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loan_originator_information", x => x.ID);
                    table.ForeignKey(
                        name: "loan_originator_information_ibfk_1",
                        column: x => x.APPLICATION_PERSONAL_INFORMATION_ID,
                        principalTable: "application_personal_information",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "military_service",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    APPLICATION_PERSONAL_INFORMATION_ID = table.Column<int>(type: "int(11)", nullable: true),
                    SERVED_IN_FORCES_7A1 = table.Column<ulong>(name: "SERVED_IN_FORCES_7A.1", type: "bit(1)", nullable: true),
                    CURRENTLY_SERVING_7A2 = table.Column<ulong>(name: "CURRENTLY_SERVING_7A.2", type: "bit(1)", nullable: true),
                    DATE_OF_SERVICE_EXPIRATION_7A3 = table.Column<DateTime>(name: "DATE_OF_SERVICE_EXPIRATION_7A.3", type: "datetime", nullable: true),
                    RETIRED_7A2 = table.Column<ulong>(name: "RETIRED_7A.2", type: "bit(1)", nullable: true),
                    NON_ACTIVATED_MEMBER_7A2 = table.Column<ulong>(name: "NON_ACTIVATED_MEMBER_7A.2", type: "bit(1)", nullable: true),
                    SURVIVING_SPOUSE_7A21 = table.Column<ulong>(name: "SURVIVING_SPOUSE_7A.2.1", type: "bit(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_military_service", x => x.ID);
                    table.ForeignKey(
                        name: "military_service_ibfk_1",
                        column: x => x.APPLICATION_PERSONAL_INFORMATION_ID,
                        principalTable: "application_personal_information",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "application_additional_employement_income_details",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    APPLICATION_ADDITIONAL_EMPLOYEMENT_DETAILS = table.Column<int>(type: "int(11)", nullable: false),
                    INCOME_TYPE_ID = table.Column<int>(type: "int(11)", nullable: false),
                    AMOUNT = table.Column<float>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_application_additional_employement_income_details", x => x.ID);
                    table.ForeignKey(
                        name: "application_additional_employement_income_details_ibfk_1",
                        column: x => x.APPLICATION_ADDITIONAL_EMPLOYEMENT_DETAILS,
                        principalTable: "application_additional_employement_details",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_additional_employement_income_details_ibfk_2",
                        column: x => x.INCOME_TYPE_ID,
                        principalTable: "income_types",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "application_employement_income_details",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    APPLICATION_EMPLOYEMENT_DETAILS_ID = table.Column<int>(type: "int(11)", nullable: false),
                    INCOME_TYPE_ID_1B101 = table.Column<int>(name: "INCOME_TYPE_ID_1B.10.1", type: "int(11)", nullable: false),
                    AMOUNT_1B10 = table.Column<float>(name: "AMOUNT_1B.10", type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_application_employement_income_details", x => x.ID);
                    table.ForeignKey(
                        name: "application_employement_income_details_ibfk_1",
                        column: x => x.APPLICATION_EMPLOYEMENT_DETAILS_ID,
                        principalTable: "application_employement_details",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "application_employement_income_details_ibfk_2",
                        column: x => x.INCOME_TYPE_ID_1B101,
                        principalTable: "income_types",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "mortage_loan_on_properties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    APPLICATION_FINANCIAL_REAL_ESTATE_ID = table.Column<int>(type: "int(11)", nullable: true),
                    CREDITOR_NAME_3A9 = table.Column<string>(name: "CREDITOR_NAME_3A.9", type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ACCOUNT_NUMBER_3A10 = table.Column<string>(name: "ACCOUNT_NUMBER_3A.10", type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    MONTHLY_MORTAGE_PAYMENT_3A11 = table.Column<float>(name: "MONTHLY_MORTAGE_PAYMENT_3A.11", type: "float", nullable: true),
                    UNPAID_BALANCE_3A12 = table.Column<float>(name: "UNPAID_BALANCE_3A.12", type: "float", nullable: true),
                    PAID_OFF_3A13 = table.Column<ulong>(name: "PAID_OFF_3A.13", type: "bit(1)", nullable: true),
                    MORTAGE_LOAN_TYPES_ID_3A14 = table.Column<int>(name: "MORTAGE_LOAN_TYPES_ID_3A.14", type: "int(11)", nullable: false),
                    CREDIT_LIMIT_3A15 = table.Column<float>(name: "CREDIT_LIMIT_3A.15", type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mortage_loan_on_properties", x => x.ID);
                    table.ForeignKey(
                        name: "mortage_loan_on_properties_ibfk_1",
                        column: x => x.APPLICATION_FINANCIAL_REAL_ESTATE_ID,
                        principalTable: "application_financial_real_estate",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "mortage_loan_on_properties_ibfk_2",
                        column: x => x.MORTAGE_LOAN_TYPES_ID_3A14,
                        principalTable: "mortage_loan_types",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateIndex(
                name: "APPLICATION_PERSONAL_INFORMATION_ID",
                table: "application_additional_employement_details",
                column: "APPLICATION_PERSONAL_INFORMATION_ID");

            migrationBuilder.CreateIndex(
                name: "CITY_ID",
                table: "application_additional_employement_details",
                column: "CITY_ID");

            migrationBuilder.CreateIndex(
                name: "COUNTRY_ID",
                table: "application_additional_employement_details",
                column: "COUNTRY_ID");

            migrationBuilder.CreateIndex(
                name: "STATE_ID",
                table: "application_additional_employement_details",
                column: "STATE_ID");

            migrationBuilder.CreateIndex(
                name: "APPLICATION_ADDITIONAL_EMPLOYEMENT_DETAILS",
                table: "application_additional_employement_income_details",
                column: "APPLICATION_ADDITIONAL_EMPLOYEMENT_DETAILS");

            migrationBuilder.CreateIndex(
                name: "INCOME_TYPE_ID",
                table: "application_additional_employement_income_details",
                column: "INCOME_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "APPLICATION_PERSONAL_INFORMATION_ID1",
                table: "application_declaration_questions",
                column: "APPLICATION_PERSONAL_INFORMATION_ID");

            migrationBuilder.CreateIndex(
                name: "DECLARATION_QUESTION_ID",
                table: "application_declaration_questions",
                column: "DECLARATION_QUESTION_ID");

            migrationBuilder.CreateIndex(
                name: "APPLICATION_PERSONAL_INFORMATION_ID2",
                table: "application_employement_details",
                column: "APPLICATION_PERSONAL_INFORMATION_ID");

            migrationBuilder.CreateIndex(
                name: "CITY_ID_1B.4.3",
                table: "application_employement_details",
                column: "CITY_ID_1B.4.3");

            migrationBuilder.CreateIndex(
                name: "COUNTRY_ID_1B.4.6",
                table: "application_employement_details",
                column: "COUNTRY_ID_1B.4.6");

            migrationBuilder.CreateIndex(
                name: "STATE_ID_1B.4.4",
                table: "application_employement_details",
                column: "STATE_ID_1B.4.4");

            migrationBuilder.CreateIndex(
                name: "APPLICATION_EMPLOYEMENT_DETAILS_ID",
                table: "application_employement_income_details",
                column: "APPLICATION_EMPLOYEMENT_DETAILS_ID");

            migrationBuilder.CreateIndex(
                name: "INCOME_TYPE_ID_1B.10.1",
                table: "application_employement_income_details",
                column: "INCOME_TYPE_ID_1B.10.1");

            migrationBuilder.CreateIndex(
                name: "APPLICATION_PERSONAL_INFORMATION_ID3",
                table: "application_financial_assets",
                column: "APPLICATION_PERSONAL_INFORMATION_ID");

            migrationBuilder.CreateIndex(
                name: "FINANCIAL_ACCOUNT_TYPE_ID_2A.1",
                table: "application_financial_assets",
                column: "FINANCIAL_ACCOUNT_TYPE_ID_2A.1");

            migrationBuilder.CreateIndex(
                name: "APPLICATION_PERSONAL_INFORMATION_ID4",
                table: "application_financial_laibilities",
                column: "APPLICATION_PERSONAL_INFORMATION_ID");

            migrationBuilder.CreateIndex(
                name: "FINANCIAL_LAIBILITIES_TYPE_2C.1",
                table: "application_financial_laibilities",
                column: "FINANCIAL_LAIBILITIES_TYPE_2C.1");

            migrationBuilder.CreateIndex(
                name: "APPLICATION_PERSONAL_INFORMATION_ID5",
                table: "application_financial_other_assets",
                column: "APPLICATION_PERSONAL_INFORMATION_ID");

            migrationBuilder.CreateIndex(
                name: "FINANCIAL_ASSETS_TYPES_ID_2B.1",
                table: "application_financial_other_assets",
                column: "FINANCIAL_ASSETS_TYPES_ID_2B.1");

            migrationBuilder.CreateIndex(
                name: "APPLICATION_PERSONAL_INFORMATION_ID6",
                table: "application_financial_other_laibilities",
                column: "APPLICATION_PERSONAL_INFORMATION_ID");

            migrationBuilder.CreateIndex(
                name: "FINANCIAL_OTHER_LAIBILITIES_TYPE_ID_2D.1",
                table: "application_financial_other_laibilities",
                column: "FINANCIAL_OTHER_LAIBILITIES_TYPE_ID_2D.1");

            migrationBuilder.CreateIndex(
                name: "APPLICATION_PERSONAL_INFORMATION_ID7",
                table: "application_financial_real_estate",
                column: "APPLICATION_PERSONAL_INFORMATION_ID");

            migrationBuilder.CreateIndex(
                name: "CITY_ID_3A.2.3",
                table: "application_financial_real_estate",
                column: "CITY_ID_3A.2.3");

            migrationBuilder.CreateIndex(
                name: "COUNTRY_ID_3A.2.6",
                table: "application_financial_real_estate",
                column: "COUNTRY_ID_3A.2.6");

            migrationBuilder.CreateIndex(
                name: "FINANCIAL_PROPERTY_INTENDED_OCCUPANCY_ID_3A.5",
                table: "application_financial_real_estate",
                column: "FINANCIAL_PROPERTY_INTENDED_OCCUPANCY_ID_3A.5");

            migrationBuilder.CreateIndex(
                name: "FINANCIAL_PROPERTY_STATUS_ID_3A.4",
                table: "application_financial_real_estate",
                column: "FINANCIAL_PROPERTY_STATUS_ID_3A.4");

            migrationBuilder.CreateIndex(
                name: "STATE_ID_3A.2.4",
                table: "application_financial_real_estate",
                column: "STATE_ID_3A.2.4");

            migrationBuilder.CreateIndex(
                name: "APPLICATION_PERSONAL_INFORMATION_ID8",
                table: "application_income_sources",
                column: "APPLICATION_PERSONAL_INFORMATION_ID");

            migrationBuilder.CreateIndex(
                name: "INCOME_SOURCE_ID_1E.1",
                table: "application_income_sources",
                column: "INCOME_SOURCE_ID_1E.1");

            migrationBuilder.CreateIndex(
                name: "APPLICATION_ID",
                table: "application_personal_information",
                column: "APPLICATION_ID");

            migrationBuilder.CreateIndex(
                name: "CITIZENSHIP_TYPE_ID_1A.5",
                table: "application_personal_information",
                column: "CITIZENSHIP_TYPE_ID_1A.5");

            migrationBuilder.CreateIndex(
                name: "CURRENT_CITY_ID_1A.13.3",
                table: "application_personal_information",
                column: "CURRENT_CITY_ID_1A.13.3");

            migrationBuilder.CreateIndex(
                name: "CURRENT_COUNTRY_ID_1A.13.6",
                table: "application_personal_information",
                column: "CURRENT_COUNTRY_ID_1A.13.6");

            migrationBuilder.CreateIndex(
                name: "CURRENT_HOUSING_TYPE_ID_1A.14.1",
                table: "application_personal_information",
                column: "CURRENT_HOUSING_TYPE_ID_1A.14.1");

            migrationBuilder.CreateIndex(
                name: "CURRENT_STATE_ID_1A.13.4",
                table: "application_personal_information",
                column: "CURRENT_STATE_ID_1A.13.4");

            migrationBuilder.CreateIndex(
                name: "FORMER_CITY_ID_1A.15.3",
                table: "application_personal_information",
                column: "FORMER_CITY_ID_1A.15.3");

            migrationBuilder.CreateIndex(
                name: "FORMER_COUNTRY_ID_1A.15.6",
                table: "application_personal_information",
                column: "FORMER_COUNTRY_ID_1A.15.6");

            migrationBuilder.CreateIndex(
                name: "FORMER_HOUSING_TYPE_ID_1A.16.1",
                table: "application_personal_information",
                column: "FORMER_HOUSING_TYPE_ID_1A.16.1");

            migrationBuilder.CreateIndex(
                name: "FORMER_STATE_ID_1A.15.4",
                table: "application_personal_information",
                column: "FORMER_STATE_ID_1A.15.4");

            migrationBuilder.CreateIndex(
                name: "MAILING_CITY_ID_1A.17.3",
                table: "application_personal_information",
                column: "MAILING_CITY_ID_1A.17.3");

            migrationBuilder.CreateIndex(
                name: "MAILING_COUNTRY_ID_1A.17.6",
                table: "application_personal_information",
                column: "MAILING_COUNTRY_ID_1A.17.6");

            migrationBuilder.CreateIndex(
                name: "MAILING_STATE_ID_1A.17.4",
                table: "application_personal_information",
                column: "MAILING_STATE_ID_1A.17.4");

            migrationBuilder.CreateIndex(
                name: "MARITIAL_STATUS_ID_1A.7",
                table: "application_personal_information",
                column: "MARITIAL_STATUS_ID_1A.7");

            migrationBuilder.CreateIndex(
                name: "APPLICATION_PERSONAL_INFORMATION_ID9",
                table: "application_previous_employement_details",
                column: "APPLICATION_PERSONAL_INFORMATION_ID");

            migrationBuilder.CreateIndex(
                name: "CITY_ID_1D.3.3",
                table: "application_previous_employement_details",
                column: "CITY_ID_1D.3.3");

            migrationBuilder.CreateIndex(
                name: "COUNTRY_ID_1D.3.6",
                table: "application_previous_employement_details",
                column: "COUNTRY_ID_1D.3.6");

            migrationBuilder.CreateIndex(
                name: "STATE_ID_1D.3.4",
                table: "application_previous_employement_details",
                column: "STATE_ID_1D.3.4");

            migrationBuilder.CreateIndex(
                name: "CREDIT_TYPE_ID",
                table: "applications",
                column: "CREDIT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "STATE_ID1",
                table: "cities",
                column: "STATE_ID");

            migrationBuilder.CreateIndex(
                name: "COUNTRY_NAME",
                table: "countries",
                column: "COUNTRY_NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "COUNTRY_ID1",
                table: "country_states",
                column: "COUNTRY_ID");

            migrationBuilder.CreateIndex(
                name: "DECLARATION_CATEGORY_ID",
                table: "declaration_questions",
                column: "DECLARATION_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "APPLICATION_PERSONAL_INFORMATION_ID10",
                table: "demographic_information",
                column: "APPLICATION_PERSONAL_INFORMATION_ID");

            migrationBuilder.CreateIndex(
                name: "DEMOGRAPHIC_INFO_SOURCE_ID_8.7",
                table: "demographic_information",
                column: "DEMOGRAPHIC_INFO_SOURCE_ID_8.7");

            migrationBuilder.CreateIndex(
                name: "APPLICATION_PERSONAL_INFORMATION_ID11",
                table: "loan_and_property_information",
                column: "APPLICATION_PERSONAL_INFORMATION_ID");

            migrationBuilder.CreateIndex(
                name: "CITY_ID_4A.3.3",
                table: "loan_and_property_information",
                column: "CITY_ID_4A.3.3");

            migrationBuilder.CreateIndex(
                name: "COUNTRY_ID_4A.3.6",
                table: "loan_and_property_information",
                column: "COUNTRY_ID_4A.3.6");

            migrationBuilder.CreateIndex(
                name: "LOAN_PROPERTY_OCCUPANCY_ID_4A.6",
                table: "loan_and_property_information",
                column: "LOAN_PROPERTY_OCCUPANCY_ID_4A.6");

            migrationBuilder.CreateIndex(
                name: "STATE_ID_4A.3.4",
                table: "loan_and_property_information",
                column: "STATE_ID_4A.3.4");

            migrationBuilder.CreateIndex(
                name: "APPLICATION_PERSONAL_INFORMATION_ID12",
                table: "loan_and_property_information_gifts",
                column: "APPLICATION_PERSONAL_INFORMATION_ID");

            migrationBuilder.CreateIndex(
                name: "LOAN_PROPERTY_GIFT_TYPE_ID_4D.1",
                table: "loan_and_property_information_gifts",
                column: "LOAN_PROPERTY_GIFT_TYPE_ID_4D.1");

            migrationBuilder.CreateIndex(
                name: "APPLICATION_PERSONAL_INFORMATION_ID13",
                table: "loan_and_property_information_other_mortage_loan",
                column: "APPLICATION_PERSONAL_INFORMATION_ID");

            migrationBuilder.CreateIndex(
                name: "APPLICATION_PERSONAL_INFORMATION_ID14",
                table: "loan_and_property_information_rental_income",
                column: "APPLICATION_PERSONAL_INFORMATION_ID");

            migrationBuilder.CreateIndex(
                name: "APPLICATION_PERSONAL_INFORMATION_ID15",
                table: "loan_originator_information",
                column: "APPLICATION_PERSONAL_INFORMATION_ID");

            migrationBuilder.CreateIndex(
                name: "APPLICATION_PERSONAL_INFORMATION_ID16",
                table: "military_service",
                column: "APPLICATION_PERSONAL_INFORMATION_ID");

            migrationBuilder.CreateIndex(
                name: "APPLICATION_FINANCIAL_REAL_ESTATE_ID",
                table: "mortage_loan_on_properties",
                column: "APPLICATION_FINANCIAL_REAL_ESTATE_ID");

            migrationBuilder.CreateIndex(
                name: "MORTAGE_LOAN_TYPES_ID_3A.14",
                table: "mortage_loan_on_properties",
                column: "MORTAGE_LOAN_TYPES_ID_3A.14");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "application_additional_employement_income_details");

            migrationBuilder.DropTable(
                name: "application_declaration_questions");

            migrationBuilder.DropTable(
                name: "application_employement_income_details");

            migrationBuilder.DropTable(
                name: "application_financial_assets");

            migrationBuilder.DropTable(
                name: "application_financial_laibilities");

            migrationBuilder.DropTable(
                name: "application_financial_other_assets");

            migrationBuilder.DropTable(
                name: "application_financial_other_laibilities");

            migrationBuilder.DropTable(
                name: "application_income_sources");

            migrationBuilder.DropTable(
                name: "application_previous_employement_details");

            migrationBuilder.DropTable(
                name: "demographic_information");

            migrationBuilder.DropTable(
                name: "loan_and_property_information");

            migrationBuilder.DropTable(
                name: "loan_and_property_information_gifts");

            migrationBuilder.DropTable(
                name: "loan_and_property_information_other_mortage_loan");

            migrationBuilder.DropTable(
                name: "loan_and_property_information_rental_income");

            migrationBuilder.DropTable(
                name: "loan_originator_information");

            migrationBuilder.DropTable(
                name: "military_service");

            migrationBuilder.DropTable(
                name: "mortage_loan_on_properties");

            migrationBuilder.DropTable(
                name: "application_additional_employement_details");

            migrationBuilder.DropTable(
                name: "declaration_questions");

            migrationBuilder.DropTable(
                name: "application_employement_details");

            migrationBuilder.DropTable(
                name: "income_types");

            migrationBuilder.DropTable(
                name: "financial_account_types");

            migrationBuilder.DropTable(
                name: "financial_laibilities_types");

            migrationBuilder.DropTable(
                name: "financial_assets_types");

            migrationBuilder.DropTable(
                name: "financial_other_laibilities_types");

            migrationBuilder.DropTable(
                name: "income_sources");

            migrationBuilder.DropTable(
                name: "demographic_info_sources");

            migrationBuilder.DropTable(
                name: "loan_property_occupancies");

            migrationBuilder.DropTable(
                name: "loan_property_gift_types");

            migrationBuilder.DropTable(
                name: "application_financial_real_estate");

            migrationBuilder.DropTable(
                name: "mortage_loan_types");

            migrationBuilder.DropTable(
                name: "declaration_categories");

            migrationBuilder.DropTable(
                name: "application_personal_information");

            migrationBuilder.DropTable(
                name: "financial_property_status");

            migrationBuilder.DropTable(
                name: "financial_property_intended_occupancies");

            migrationBuilder.DropTable(
                name: "applications");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "housing_types");

            migrationBuilder.DropTable(
                name: "citizenship_types");

            migrationBuilder.DropTable(
                name: "maritial_status");

            migrationBuilder.DropTable(
                name: "credit_types");

            migrationBuilder.DropTable(
                name: "country_states");

            migrationBuilder.DropTable(
                name: "countries");
        }
    }
}
