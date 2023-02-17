using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagement.Migrations
{
    public partial class initial_create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpAuditLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    ServiceName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MethodName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Parameters = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReturnValue = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExecutionTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ExecutionDuration = table.Column<int>(type: "int", nullable: false),
                    ClientIpAddress = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BrowserInfo = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExceptionMessage = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Exception = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImpersonatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    ImpersonatorTenantId = table.Column<int>(type: "int", nullable: true),
                    CustomData = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpAuditLogs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpBackgroundJobs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    JobType = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JobArgs = table.Column<string>(type: "text", maxLength: 1048576, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TryCount = table.Column<short>(type: "smallint", nullable: false),
                    NextTryTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastTryTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsAbandoned = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Priority = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpBackgroundJobs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpDynamicProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PropertyName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InputType = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Permission = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpDynamicProperties", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpEditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEditions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpEntityChangeSets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BrowserInfo = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientIpAddress = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ExtensionData = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImpersonatorTenantId = table.Column<int>(type: "int", nullable: true),
                    ImpersonatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    Reason = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityChangeSets", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Icon = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDisabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpLanguages", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpLanguageTexts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    LanguageName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Source = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Key = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "text", maxLength: 67108864, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpLanguageTexts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NotificationName = table.Column<string>(type: "varchar(96)", maxLength: 96, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Data = table.Column<string>(type: "text", maxLength: 1048576, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataTypeName = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntityTypeName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntityTypeAssemblyQualifiedName = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntityId = table.Column<string>(type: "varchar(96)", maxLength: 96, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Severity = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    UserIds = table.Column<string>(type: "text", maxLength: 131072, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExcludedUserIds = table.Column<string>(type: "text", maxLength: 131072, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenantIds = table.Column<string>(type: "text", maxLength: 131072, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpNotifications", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpNotificationSubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    NotificationName = table.Column<string>(type: "varchar(96)", maxLength: 96, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntityTypeName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntityTypeAssemblyQualifiedName = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntityId = table.Column<string>(type: "varchar(96)", maxLength: 96, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpNotificationSubscriptions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpOrganizationUnitRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    OrganizationUnitId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpOrganizationUnitRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpOrganizationUnits",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    Code = table.Column<string>(type: "varchar(95)", maxLength: 95, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpOrganizationUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpOrganizationUnits_AbpOrganizationUnits_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AbpOrganizationUnits",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpTenantNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    NotificationName = table.Column<string>(type: "varchar(96)", maxLength: 96, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Data = table.Column<string>(type: "text", maxLength: 1048576, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataTypeName = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntityTypeName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntityTypeAssemblyQualifiedName = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntityId = table.Column<string>(type: "varchar(96)", maxLength: 96, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Severity = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpTenantNotifications", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUserAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    UserLinkId = table.Column<long>(type: "bigint", nullable: true),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailAddress = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserAccounts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUserLoginAttempts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    TenancyName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    UserNameOrEmailAddress = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientIpAddress = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BrowserInfo = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Result = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserLoginAttempts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUserNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TenantNotificationId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    State = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserNotifications", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUserOrganizationUnits",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationUnitId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserOrganizationUnits", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AuthenticationSource = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    EmailAddress = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmationCode = table.Column<string>(type: "varchar(328)", maxLength: 328, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordResetCode = table.Column<string>(type: "varchar(328)", maxLength: 328, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LockoutEndDateUtc = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    IsLockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsPhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SecurityStamp = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsTwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmailAddress = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpUsers_AbpUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbpUsers_AbpUsers_DeleterUserId",
                        column: x => x.DeleterUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbpUsers_AbpUsers_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpWebhookEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WebhookName = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Data = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpWebhookEvents", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpWebhookSubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    WebhookUri = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Secret = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Webhooks = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Headers = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpWebhookSubscriptions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Additionaldetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameOfIndividualsOnTitle = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameOfIndividualsCoBorrowerOnTitle = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Additionaldetails", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "admin_loanstatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin_loanstatus", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Admindisclosures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admindisclosures", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AdminLoanprograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LoanProgram = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminLoanprograms", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AdminUserenableddevices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DeviceId = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BioMetricData = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsEnabled = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUserenableddevices", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Assettypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assettypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Borrowertypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowertypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CitizenshipTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CitizenshipType1 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitizenshipTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Consentdetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AgreeEconsent = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CoborrowerAgreeEconsent = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CoborrowerFirstName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CoborrowerLastName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CoborrowerEmail = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consentdetails", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CountryName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Creditauthagreements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AgreeCreditAuthAgreement = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creditauthagreements", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CreditTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreditType1 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DeclarationCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DeclarationCategory1 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclarationCategories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DemographicInfoSources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemographicInfoSources", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsLiveWithFamilySelectRent = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Rent = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    OtherHousingExpenses = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    FirstMortgage = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    SecondMortgage = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    HazardInsurance = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    RealEstateTaxes = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    MortgageInsurance = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    HomeOwnersAssociation = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FinancialAccountTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FinancialAccountType1 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialAccountTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FinancialAssetsTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FinancialCreditType = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialAssetsTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FinancialLaibilitiesTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FinancialLaibilitiesType1 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialLaibilitiesTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FinancialOtherLaibilitiesTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FinancialOtherLaibilitiesType1 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialOtherLaibilitiesTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FinancialPropertyIntendedOccupancies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FinancialPropertyIntendedOccupancy1 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialPropertyIntendedOccupancies", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FinancialPropertyStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FinancialPropertyStatus1 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialPropertyStatuses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Homebuyings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PropertyType = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyUse = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstTimeHomeBuying = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    PlanToPurchase = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyLocated = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PurchasePrice = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    DownPayment = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    CurrentlyEmployed = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HouseHoldIncome = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProofOfincome = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    MilitarySevice = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    BankruptcyPastThreeYears = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    ForeclosurePastTwoYears = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    LateMortgagePayments = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RateCredit = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailAddress = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RefferedBy = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homebuyings", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HousingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HousingType1 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HousingTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IncomeSources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IncomeSource1 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeSources", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Incomesources1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomesources1", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IncomeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IncomeType1 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LeadApplicationDetailPurchasings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Stage = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsWorkingWithEzalready = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    WorkingOfficerName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NewHomeAddress = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NewHomeUnit = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NewHomeCity = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NewHomeStateId = table.Column<int>(type: "int", nullable: false),
                    NewHomeZipCode = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContractClosingDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ContractType = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EstimatedHomePrice = table.Column<float>(type: "float", nullable: true),
                    DownPaymentAmount = table.Column<float>(type: "float", nullable: true),
                    DownPaymentPercentage = table.Column<float>(type: "float", nullable: true),
                    EstimatedAnnualTax = table.Column<float>(type: "float", nullable: true),
                    EstimatedAnnualHomeInsurance = table.Column<float>(type: "float", nullable: true),
                    CreditScore = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyLegalFirstName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyMiddleInitial = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyLegalLastName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyPhoneNumber = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyEmailAddress = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeOfHome = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MonthlyHoadues = table.Column<float>(type: "float", nullable: true),
                    TypeOfNewHome = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsMilitaryMember = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    CurrentMilitaryStatus = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MilitaryBranch = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsEtsdateinYear = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    Etsdate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsValoanPreviously = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    WhoLivingInHome = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalLegalFirstName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalMiddleInitial = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalLegalLastName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalPhoneNumber = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalEmailAddress = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalPassword = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsSomeOneRefer = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    IsApplyOwn = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    MaritialStatus = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumberOfDependents = table.Column<int>(type: "int", nullable: true),
                    CurrentAddress = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentUnit = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentCity = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentStateId = table.Column<int>(type: "int", nullable: false),
                    CurrentZipCode = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentStartLivingDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CurrentReantingType = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EstimatedMonthlyExpenses = table.Column<float>(type: "float", nullable: true),
                    IsEmployementHistory = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    IsOtherSourceOfIncome = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    Sex = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ethnicity = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Race = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CitizenshipId = table.Column<int>(type: "int", nullable: false),
                    IsCertify = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    IsReadEconsent = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    IsReadThirdPartyConsent = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    SocialSecurityNumber = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConformSsn = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadApplicationDetailPurchasings", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LeadApplicationDetailRefinancings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsWorkingWithEzalready = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    WorkingOfficerName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ObjectiveReason = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyAddress = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyUnit = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyCity = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyZip = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyStateId = table.Column<int>(type: "int", nullable: false),
                    PropertyCountryId = table.Column<int>(type: "int", nullable: false),
                    PropertyEstimatedValue = table.Column<float>(type: "float", nullable: true),
                    PropertyLoanBalance = table.Column<float>(type: "float", nullable: true),
                    PropertCashOutAmount = table.Column<float>(type: "float", nullable: true),
                    NewLoanEstimateAmount = table.Column<float>(type: "float", nullable: true),
                    CreditScore = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeOfHome = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MonthlyHoadues = table.Column<float>(type: "float", nullable: true),
                    YearHomePurchased = table.Column<float>(type: "float", nullable: true),
                    OrignalPurchasedPrice = table.Column<float>(type: "float", nullable: true),
                    EstimatedAnnualTax = table.Column<float>(type: "float", nullable: true),
                    EstimatedAnnualHomeInsurance = table.Column<float>(type: "float", nullable: true),
                    CurrentlyUsingHomeAs = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsMilitaryMember = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    CurrentMilitaryStatus = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MilitaryBranch = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsEtsdateinYear = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    Etsdate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsValoanPreviously = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    WhoLivingInHome = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyLegalFirstName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyMiddleInitial = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyLegalLastName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyPhoneNumber = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyEmailAddress = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyPassword = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsSomeoneRefer = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    RefferedBy = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsApplyOwn = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    IsLegalSpouse = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    MaritialStatus = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumberOfDependents = table.Column<int>(type: "int", nullable: true),
                    FirstDependantAge = table.Column<int>(type: "int", nullable: true),
                    IsCurrentlyLivingOnRefinancingProperty = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    CurrentAddress = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentUnit = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentCity = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentStateId = table.Column<int>(type: "int", nullable: false),
                    CurrentZipCode = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentStartLivingDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CurrentReantingType = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EstimatedMonthlyExpenses = table.Column<float>(type: "float", nullable: true),
                    PersonalLegalFirstName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalMiddleInitial = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalLegalLastName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalPhoneNumber = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalEmailAddress = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalPassword = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAddressSameAsPrimaryBorrower = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    PersonalAddress = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalUnit = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalCity = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalStateId = table.Column<int>(type: "int", nullable: false),
                    PersonalZipCode = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalStartLivingDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PersonalReantingType = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsEmployementHistory = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    IsCoBorrowerHaveShareIncome = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    Sex = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ethnicity = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Race = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CitizenshipId = table.Column<int>(type: "int", nullable: false),
                    IsCertify = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    IsReadEconsent = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    IsReadThirdPartyConsent = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    SocialSecurityNumber = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConformSsn = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadApplicationDetailRefinancings", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LeadApplicationQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Question = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadApplicationQuestions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LeadApplicationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationType = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadApplicationTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LeadAssetsDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LeadApplicationDetailPurchasingId = table.Column<int>(type: "int", nullable: false),
                    LeadApplicationDetailRefinancingId = table.Column<int>(type: "int", nullable: true),
                    AssetTypeId = table.Column<int>(type: "int", nullable: false),
                    LeadApplicationTypeId = table.Column<int>(type: "int", nullable: false),
                    FinancialInstitution = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Balance = table.Column<float>(type: "float", nullable: true),
                    OwnerTypeId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadAssetsDetails", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LeadAssetsTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AssetsType = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadAssetsTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LeadEmployementDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmployeeTypeId = table.Column<int>(type: "int", nullable: false),
                    LeadApplicationDetailPurchasingId = table.Column<int>(type: "int", nullable: true),
                    LeadApplicationDetailRefinancingId = table.Column<int>(type: "int", nullable: true),
                    LeadApplicationTypeId = table.Column<int>(type: "int", nullable: false),
                    EmployerName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmployementAddress = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmployementSuite = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmployementCity = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmployementTaxeId = table.Column<int>(type: "int", nullable: false),
                    EmployementZip = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmployerPhoneNumber = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsCurrentJob = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    EstimatedStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    JobTitle = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EstimatedAnnualBaseSalary = table.Column<float>(type: "float", nullable: true),
                    EstimatedAnnualBonus = table.Column<float>(type: "float", nullable: true),
                    EstimatedAnnualCommission = table.Column<float>(type: "float", nullable: true),
                    EstimatedAnnualOvertime = table.Column<float>(type: "float", nullable: true),
                    IsCoBorrower = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadEmployementDetails", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LeadEmployementTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmployementType = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadEmployementTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LeadIncomeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IncomeType = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadIncomeTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LeadOwnerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OwnerType = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadOwnerTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LeadQuestionAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LeadApplicationDetailPurchasingId = table.Column<int>(type: "int", nullable: false),
                    LeadApplicationDetailRefinancingId = table.Column<int>(type: "int", nullable: true),
                    LeadApplicationTypeId = table.Column<int>(type: "int", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    IsYes = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadQuestionAnswers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LeadRefinancingIncomeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LeadApplicationDetailRefinancingId = table.Column<int>(type: "int", nullable: true),
                    LeadApplicationTypeId = table.Column<int>(type: "int", nullable: true),
                    IncomeTypeId = table.Column<int>(type: "int", nullable: false),
                    MonthlyAmount = table.Column<float>(type: "float", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadRefinancingIncomeDetails", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LeadTaxesTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TaxesType = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadTaxesTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LoanAndPropertyInformationGifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationPersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    LoanPropertyGiftTypeId4d1 = table.Column<int>(type: "int", nullable: true),
                    Deposited4d2 = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    Source4d3 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value4d4 = table.Column<float>(type: "float", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanAndPropertyInformationGifts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LoanAndPropertyInformationOtherMortageLoans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationPersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    CreditorName4b1 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LienType4b2 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MonthlyPayment4b3 = table.Column<float>(type: "float", nullable: true),
                    LoanAmount4b4 = table.Column<float>(type: "float", nullable: true),
                    CreditAmount4b5 = table.Column<float>(type: "float", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanAndPropertyInformationOtherMortageLoans", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LoanAndPropertyInformationRentalIncomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationPersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    ExpectedMonthlyIncome4c1 = table.Column<float>(type: "float", nullable: true),
                    LenderExpectedMonthlyIncome4c2 = table.Column<float>(type: "float", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanAndPropertyInformationRentalIncomes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LoanAndPropertyInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationPersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    LoanAmount4a1 = table.Column<float>(type: "float", nullable: true),
                    LoanPurpose4a2 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyStreet4a31 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyUnitNo4a32 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyZip4a35 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CountryId4a36 = table.Column<int>(type: "int", nullable: false),
                    StateId4a34 = table.Column<int>(type: "int", nullable: false),
                    CityId4a33 = table.Column<int>(type: "int", nullable: false),
                    PropertyNumberUnits4a4 = table.Column<int>(type: "int", nullable: true),
                    PropertyValue4a5 = table.Column<float>(type: "float", nullable: true),
                    LoanPropertyOccupancyId4a6 = table.Column<int>(type: "int", nullable: true),
                    FhaSecondaryResidance4a61 = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    IsMixedUseProperty4a7 = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    IsManufacturedHome4a8 = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanAndPropertyInformations", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Loandetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsWorkingWithOfficer = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    LoanOfficerId = table.Column<int>(type: "int", nullable: true),
                    ReferredBy = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PurposeOfLoan = table.Column<int>(type: "int", nullable: true),
                    EstimatedValue = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    CurrentLoanAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    RequestedLoanAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    EstimatedPurchasePrice = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    DownPaymentAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    DownPaymentPercentage = table.Column<double>(type: "double", nullable: true),
                    SourceOfDownPayment = table.Column<int>(type: "int", nullable: true),
                    GiftAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    GiftExplanation = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HaveSecondMortgage = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    SecondMortgageAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    PayLoanWithNewLoan = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    RefinancingCurrentHome = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    YearAcquired = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OriginalPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    PropertyTypeId = table.Column<int>(type: "int", nullable: true),
                    PropertyUseId = table.Column<int>(type: "int", nullable: true),
                    StartedLookingForNewHome = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loandetails", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LoanOriginatorInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationPersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    OrganizationName91 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address92 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrganizationNmlsrId93 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrganizationStateLicence94 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OriginatorName95 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OriginatorNmlsrId96 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OriginatorStateLicense97 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email98 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone99 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date910 = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanOriginatorInformations", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LoanPropertyGiftTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LoanPropertyGiftType1 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanPropertyGiftTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LoanPropertyOccupancies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LoanPropertyOccupancy1 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanPropertyOccupancies", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MaritialStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MaritialStatus1 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritialStatuses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MilitaryServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationPersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    ServedInForces7a1 = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    CurrentlyServing7a2 = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    DateOfServiceExpiration7a3 = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Retired7a2 = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    NonActivatedMember7a2 = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    SurvivingSpouse7a21 = table.Column<ulong>(type: "bigint unsigned", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryServices", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MortageLoanOnProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationFinancialRealEstateId = table.Column<int>(type: "int", nullable: true),
                    CreditorName3a9 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountNumber3a10 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MonthlyMortagePayment3a11 = table.Column<float>(type: "float", nullable: true),
                    UnpaidBalance3a12 = table.Column<float>(type: "float", nullable: true),
                    PaidOff3a13 = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    MortageLoanTypesId3a14 = table.Column<int>(type: "int", nullable: false),
                    CreditLimit3a15 = table.Column<float>(type: "float", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MortageLoanOnProperties", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MortageLoanTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MortageLoanTypesId = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MortageLoanTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Refinancehomebuyings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PropertyLocated = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyType = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyUse = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WantRefinance = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HomePrice = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Owe = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    CashBorrow = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Fhaloan = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MilitarySevice = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    ProofOfincome = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CurrentlyEmployed = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BankruptcyPastThreeYears = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    ForeclosurePastTwoYears = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    LateMortgagePayments = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentEmployed = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HouseHoldIncome = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RateCredit = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailAddress = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RefferedBy = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refinancehomebuyings", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sitesettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PageIdentifier = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PageName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PageSetting = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sitesettings", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_application",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_application", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpDynamicEntityProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EntityFullName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DynamicPropertyId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpDynamicEntityProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpDynamicEntityProperties_AbpDynamicProperties_DynamicPrope~",
                        column: x => x.DynamicPropertyId,
                        principalTable: "AbpDynamicProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpDynamicPropertyValues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    DynamicPropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpDynamicPropertyValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpDynamicPropertyValues_AbpDynamicProperties_DynamicPropert~",
                        column: x => x.DynamicPropertyId,
                        principalTable: "AbpDynamicProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpFeatures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Discriminator = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EditionId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpFeatures_AbpEditions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "AbpEditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpEntityChanges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ChangeTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ChangeType = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    EntityChangeSetId = table.Column<long>(type: "bigint", nullable: false),
                    EntityId = table.Column<string>(type: "varchar(48)", maxLength: 48, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntityTypeFullName = table.Column<string>(type: "varchar(192)", maxLength: 192, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpEntityChanges_AbpEntityChangeSets_EntityChangeSetId",
                        column: x => x.EntityChangeSetId,
                        principalTable: "AbpEntityChangeSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(5000)", maxLength: 5000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsStatic = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDefault = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NormalizedName = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpRoles_AbpUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbpRoles_AbpUsers_DeleterUserId",
                        column: x => x.DeleterUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbpRoles_AbpUsers_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpSettings_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpTenants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    TenancyName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConnectionString = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EditionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpTenants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpTenants_AbpEditions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "AbpEditions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbpTenants_AbpUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbpTenants_AbpUsers_DeleterUserId",
                        column: x => x.DeleterUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbpTenants_AbpUsers_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUserClaims",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpUserClaims_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUserLogins",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpUserLogins_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUserRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpUserRoles_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUserTokens",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExpireDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpUserTokens_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpWebhookSendAttempts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WebhookEventId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WebhookSubscriptionId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Response = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ResponseStatusCode = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpWebhookSendAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpWebhookSendAttempts_AbpWebhookEvents_WebhookEventId",
                        column: x => x.WebhookEventId,
                        principalTable: "AbpWebhookEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Borrowers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleInitial = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Suffix = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SocialSecurityNumber = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MaritalStatusId = table.Column<int>(type: "int", nullable: true),
                    NumberOfDependents = table.Column<int>(type: "int", nullable: true),
                    CellPhone = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HomePhone = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BorrowerTypeId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Borrowers_Borrowertypes_BorrowerTypeId",
                        column: x => x.BorrowerTypeId,
                        principalTable: "Borrowertypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CountryStates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    StateName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryStates_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LoanNoIdentifierB1B3 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AgencyCaseNoB2 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreditTypeId = table.Column<int>(type: "int", nullable: false),
                    TotalBorrowers1a6 = table.Column<int>(type: "int", nullable: true),
                    Initials = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_CreditTypes_CreditTypeId",
                        column: x => x.CreditTypeId,
                        principalTable: "CreditTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DeclarationQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DeclarationCategoryId = table.Column<int>(type: "int", nullable: true),
                    ParentQuestionId = table.Column<int>(type: "int", nullable: true),
                    Question = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclarationQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeclarationQuestions_DeclarationCategories_DeclarationCatego~",
                        column: x => x.DeclarationCategoryId,
                        principalTable: "DeclarationCategories",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_personal_information",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BorrowerType = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Suffix = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SocialSecurityNumber = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dob = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Citizenship = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MarritalStatus = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dependents = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApplyingFor = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalBorrowers = table.Column<int>(type: "int", nullable: true),
                    YourInitials = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MortgageApplicationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_personal_information", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urla_personal_information_urla_application_MortgageApplicati~",
                        column: x => x.MortgageApplicationId,
                        principalTable: "urla_application",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpDynamicEntityPropertyValues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntityId = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DynamicEntityPropertyId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpDynamicEntityPropertyValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpDynamicEntityPropertyValues_AbpDynamicEntityProperties_Dy~",
                        column: x => x.DynamicEntityPropertyId,
                        principalTable: "AbpDynamicEntityProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpEntityPropertyChanges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EntityChangeId = table.Column<long>(type: "bigint", nullable: false),
                    NewValue = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OriginalValue = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyName = table.Column<string>(type: "varchar(96)", maxLength: 96, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyTypeFullName = table.Column<string>(type: "varchar(192)", maxLength: 192, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    NewValueHash = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OriginalValueHash = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityPropertyChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpEntityPropertyChanges_AbpEntityChanges_EntityChangeId",
                        column: x => x.EntityChangeId,
                        principalTable: "AbpEntityChanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpPermissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsGranted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpPermissions_AbpRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AbpRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbpPermissions_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpRoleClaims",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpRoleClaims_AbpRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AbpRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Personaldetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsApplyingWithCoBorrower = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    UseIncomeOfPersonOtherThanBorrower = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    AgreePrivacyPolicy = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    BorrowerId = table.Column<long>(type: "bigint", nullable: true),
                    CoBorrowerId = table.Column<long>(type: "bigint", nullable: true),
                    IsMailingAddressSameAsResidential = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CoBorrowerIsMailingAddressSameAsResidential = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CoBorrowerResidentialAddressSameAsBorrowerResidential = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personaldetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personaldetails_Borrowers_BorrowerId",
                        column: x => x.BorrowerId,
                        principalTable: "Borrowers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Personaldetails_Borrowers_CoBorrowerId",
                        column: x => x.CoBorrowerId,
                        principalTable: "Borrowers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StateId1 = table.Column<long>(type: "bigint", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_CountryStates_StateId1",
                        column: x => x.StateId1,
                        principalTable: "CountryStates",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AdminLoandetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LoanApplicationId = table.Column<int>(type: "int", nullable: false),
                    LoanNo = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MortageConsultant = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NmlsId = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BorrowerName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyAddress = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoanProgramId = table.Column<int>(type: "int", nullable: false),
                    LoanAmount = table.Column<float>(type: "float", nullable: true),
                    LoanPurpose = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InterestRate = table.Column<float>(type: "float", nullable: true),
                    ApplicationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RateLockDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RateLockExpirationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminLoandetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminLoandetails_AdminLoanprograms_LoanProgramId",
                        column: x => x.LoanProgramId,
                        principalTable: "AdminLoanprograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminLoandetails_Applications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_agreements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsAgreeAgreement = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_agreements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urla_agreements_urla_personal_information_PersonalInformatio~",
                        column: x => x.PersonalInformationId,
                        principalTable: "urla_personal_information",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_alternate_names",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Suffix = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_alternate_names", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urla_alternate_names_urla_personal_information_PersonalInfor~",
                        column: x => x.PersonalInformationId,
                        principalTable: "urla_personal_information",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_contact_information",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HomePhone = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CellPhone = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkPhone = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ext = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_contact_information", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urla_contact_information_urla_personal_information_PersonalI~",
                        column: x => x.PersonalInformationId,
                        principalTable: "urla_personal_information",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_declaration_questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DeclarationQuestionId = table.Column<int>(type: "int", nullable: true),
                    Answer = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_declaration_questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urla_declaration_questions_DeclarationQuestions_DeclarationQ~",
                        column: x => x.DeclarationQuestionId,
                        principalTable: "DeclarationQuestions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_urla_declaration_questions_urla_personal_information_Persona~",
                        column: x => x.PersonalInformationId,
                        principalTable: "urla_personal_information",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_demographic_information",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsHispanicOrLatino = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsMexican = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsPuertoRican = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsCuban = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsOtherHispanicOrLatino = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Origin = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsNotHispanicOrLatino = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CanNotProvideEthnicInfo = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsAmericanIndianOrAlaskaNative = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    NameOfEnrolledOrPrincipalTribe = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAsian = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsAsianIndian = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsChinese = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsFilipino = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsJapanese = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsKorean = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsVietnamese = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsOtherAsian = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    OtherAsianRace = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsBlackOrAfricanAmerican = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsNativeHawaiianOrOtherPacificIslander = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsNativeHawaiian = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsGuamanianOrChamorro = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsSamoan = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsOtherPacificIslander = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    OtherPacificIslanderRace = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsWhite = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CanNotProvideRaceInfo = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsMale = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsFemale = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CanNotProvideSexInfo = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    DemographicInfoSource = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_demographic_information", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urla_demographic_information_urla_personal_information_Perso~",
                        column: x => x.PersonalInformationId,
                        principalTable: "urla_personal_information",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_dempgraphic_info_by_financial_institutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsEthnicityByObservation = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsGenderByObservation = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsRaceByObservation = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_dempgraphic_info_by_financial_institutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urla_dempgraphic_info_by_financial_institutions_urla_persona~",
                        column: x => x.PersonalInformationId,
                        principalTable: "urla_personal_information",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_financial_assets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AccountTypeId = table.Column<int>(type: "int", nullable: true),
                    FinancialInstitution = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountNumber = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CashMarketValue = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_financial_assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urla_financial_assets_FinancialAccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "FinancialAccountTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_urla_financial_assets_urla_personal_information_PersonalInfo~",
                        column: x => x.PersonalInformationId,
                        principalTable: "urla_personal_information",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_financial_liabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FinancialLaibilitiesTypeId = table.Column<int>(type: "int", nullable: true),
                    AccountNumber = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UnpaidBalance = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    IsPaidBeforeClosing = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    MonthlyPayment = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_financial_liabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urla_financial_liabilities_FinancialLaibilitiesTypes_Financi~",
                        column: x => x.FinancialLaibilitiesTypeId,
                        principalTable: "FinancialLaibilitiesTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_urla_financial_liabilities_urla_personal_information_Persona~",
                        column: x => x.PersonalInformationId,
                        principalTable: "urla_personal_information",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_financial_other_assets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FinancialAssetsTypeId = table.Column<int>(type: "int", nullable: true),
                    CashMarketValue = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_financial_other_assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urla_financial_other_assets_FinancialAssetsTypes_FinancialAs~",
                        column: x => x.FinancialAssetsTypeId,
                        principalTable: "FinancialAssetsTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_urla_financial_other_assets_urla_personal_information_Person~",
                        column: x => x.PersonalInformationId,
                        principalTable: "urla_personal_information",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_financial_other_liabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FinancialOtherLaibilitiesTypeId = table.Column<int>(type: "int", nullable: true),
                    MonthlyPayment = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_financial_other_liabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urla_financial_other_liabilities_FinancialOtherLaibilitiesTy~",
                        column: x => x.FinancialOtherLaibilitiesTypeId,
                        principalTable: "FinancialOtherLaibilitiesTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_urla_financial_other_liabilities_urla_personal_information_P~",
                        column: x => x.PersonalInformationId,
                        principalTable: "urla_personal_information",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_income_sources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MonthlyIncome = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    IncomeSourceId = table.Column<int>(type: "int", nullable: true),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_income_sources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urla_income_sources_IncomeSources_IncomeSourceId",
                        column: x => x.IncomeSourceId,
                        principalTable: "IncomeSources",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_urla_income_sources_urla_personal_information_PersonalInform~",
                        column: x => x.PersonalInformationId,
                        principalTable: "urla_personal_information",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_loan_originator_informations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    OrganizationName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrganizationNmlsrId = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrganizationStateLicenceId = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OriginatorName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OriginatorNmlsrId = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OriginatorStateLicenseId = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_loan_originator_informations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urla_loan_originator_informations_urla_personal_information_~",
                        column: x => x.PersonalInformationId,
                        principalTable: "urla_personal_information",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_loan_property_gifts_or_grants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    AssetTypeId = table.Column<int>(type: "int", nullable: true),
                    AssetTypeId1 = table.Column<long>(type: "bigint", nullable: true),
                    IsDeposited = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Source = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MarketValue = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_loan_property_gifts_or_grants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urla_loan_property_gifts_or_grants_Assettypes_AssetTypeId1",
                        column: x => x.AssetTypeId1,
                        principalTable: "Assettypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_urla_loan_property_gifts_or_grants_urla_personal_information~",
                        column: x => x.PersonalInformationId,
                        principalTable: "urla_personal_information",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_loan_property_information",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    LoanAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    LoanPurpose = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Occupancy = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsManufacturedHome = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsMixedUseProperty = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_loan_property_information", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urla_loan_property_information_urla_personal_information_Per~",
                        column: x => x.PersonalInformationId,
                        principalTable: "urla_personal_information",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_loan_property_other_new_mortgage_loans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    CreditorName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LienType = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MonthlyPayment = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    LoanAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CreditLimit = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_loan_property_other_new_mortgage_loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urla_loan_property_other_new_mortgage_loans_urla_personal_in~",
                        column: x => x.PersonalInformationId,
                        principalTable: "urla_personal_information",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_loan_property_rental_incomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    MonthlyRentalIncome = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    NetMonthlyRentalIncome = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_loan_property_rental_incomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urla_loan_property_rental_incomes_urla_personal_information_~",
                        column: x => x.PersonalInformationId,
                        principalTable: "urla_personal_information",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_military_services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    IsServeUSForces = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsCurrentlyServing = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    ProjectedExpirationServiceDate = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsCurrentlyRetired = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsNonActivatedMember = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsSurvivingSpouse = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_military_services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urla_military_services_urla_personal_information_PersonalInf~",
                        column: x => x.PersonalInformationId,
                        principalTable: "urla_personal_information",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_other_borrowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Suffix = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_other_borrowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urla_other_borrowers_urla_personal_information_PersonalInfor~",
                        column: x => x.PersonalInformationId,
                        principalTable: "urla_personal_information",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AddressType = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressLine1 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressLine2 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: true),
                    Years = table.Column<int>(type: "int", nullable: true),
                    Months = table.Column<int>(type: "int", nullable: true),
                    PersonalDetailId = table.Column<long>(type: "bigint", nullable: false),
                    BorrowerTypeId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Borrowertypes_BorrowerTypeId",
                        column: x => x.BorrowerTypeId,
                        principalTable: "Borrowertypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Personaldetails_PersonalDetailId",
                        column: x => x.PersonalDetailId,
                        principalTable: "Personaldetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Loanapplications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LoanDetailId = table.Column<long>(type: "bigint", nullable: true),
                    AdditionalDetailId = table.Column<long>(type: "bigint", nullable: true),
                    PersonalDetailId = table.Column<long>(type: "bigint", nullable: true),
                    CreditAuthAgreementId = table.Column<long>(type: "bigint", nullable: true),
                    ConsentDetailId = table.Column<long>(type: "bigint", nullable: true),
                    ExpenseId = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loanapplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loanapplications_Additionaldetails_AdditionalDetailId",
                        column: x => x.AdditionalDetailId,
                        principalTable: "Additionaldetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loanapplications_Consentdetails_ConsentDetailId",
                        column: x => x.ConsentDetailId,
                        principalTable: "Consentdetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loanapplications_Creditauthagreements_CreditAuthAgreementId",
                        column: x => x.CreditAuthAgreementId,
                        principalTable: "Creditauthagreements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loanapplications_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loanapplications_Loandetails_LoanDetailId",
                        column: x => x.LoanDetailId,
                        principalTable: "Loandetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loanapplications_Personaldetails_PersonalDetailId",
                        column: x => x.PersonalDetailId,
                        principalTable: "Personaldetails",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApplicationPersonalInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    FirstName1a1 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleName1a2 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName1a3 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Suffix1a4 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AlternateFirstName1a21 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AlternateMiddleName1a22 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AlternateLastName1a23 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AlternateSuffix1a24 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ssn1a3 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dob1a4 = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CitizenshipTypeId1a5 = table.Column<int>(type: "int", nullable: false),
                    MaritialStatusId1a7 = table.Column<int>(type: "int", nullable: false),
                    Dependents1a8 = table.Column<int>(type: "int", nullable: true),
                    Ages1a81 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HomePhone1a9 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CellPhone1a10 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkPhone1a11 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ext1a111 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email1a12 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentStreet1a131 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentUnit1a132 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentZip1a135 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentCountryId1a136 = table.Column<int>(type: "int", nullable: false),
                    CurrentStateId1a134 = table.Column<int>(type: "int", nullable: false),
                    CurrentCityId1a133 = table.Column<int>(type: "int", nullable: false),
                    CurrentYears1a14 = table.Column<int>(type: "int", nullable: true),
                    CurrentMonths1a15 = table.Column<int>(type: "int", nullable: true),
                    CurrentHousingTypeId1a141 = table.Column<int>(type: "int", nullable: false),
                    CurrentRent1a142 = table.Column<float>(type: "float", nullable: true),
                    FormerStreet1a151 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FormerUnit1a152 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FormerZip1a155 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FormerCountryId1a156 = table.Column<int>(type: "int", nullable: false),
                    FormerStateId1a154 = table.Column<int>(type: "int", nullable: false),
                    FormerCityId1a153 = table.Column<int>(type: "int", nullable: false),
                    FormerYears1a16 = table.Column<int>(type: "int", nullable: true),
                    FormerMonths1a161 = table.Column<int>(type: "int", nullable: true),
                    FormerHousingTypeId1a161 = table.Column<int>(type: "int", nullable: false),
                    FormerRent1a162 = table.Column<float>(type: "float", nullable: true),
                    MailingStreet1a171 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MailingUnit1a172 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MailingZip1a175 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MailingCountryId1a176 = table.Column<int>(type: "int", nullable: false),
                    MailingStateId1a174 = table.Column<int>(type: "int", nullable: false),
                    MailingCityId1a173 = table.Column<int>(type: "int", nullable: false),
                    CitizenshipTypeId1a5NavigationId = table.Column<int>(type: "int", nullable: true),
                    CurrentCityId1a133NavigationId = table.Column<int>(type: "int", nullable: true),
                    CurrentCountryId1a136NavigationId = table.Column<int>(type: "int", nullable: true),
                    CurrentHousingTypeId1a141NavigationId = table.Column<int>(type: "int", nullable: true),
                    CurrentStateId1a134NavigationId = table.Column<long>(type: "bigint", nullable: true),
                    FormerCityId1a153NavigationId = table.Column<int>(type: "int", nullable: true),
                    FormerCountryId1a156NavigationId = table.Column<int>(type: "int", nullable: true),
                    FormerHousingTypeId1a161NavigationId = table.Column<int>(type: "int", nullable: true),
                    FormerStateId1a154NavigationId = table.Column<long>(type: "bigint", nullable: true),
                    MailingCityId1a173NavigationId = table.Column<int>(type: "int", nullable: true),
                    MailingCountryId1a176NavigationId = table.Column<int>(type: "int", nullable: true),
                    MailingStateId1a174NavigationId = table.Column<long>(type: "bigint", nullable: true),
                    MaritialStatusId1a7NavigationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationPersonalInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationPersonalInformations_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationPersonalInformations_Cities_CurrentCityId1a133Nav~",
                        column: x => x.CurrentCityId1a133NavigationId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationPersonalInformations_Cities_FormerCityId1a153Navi~",
                        column: x => x.FormerCityId1a153NavigationId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationPersonalInformations_Cities_MailingCityId1a173Nav~",
                        column: x => x.MailingCityId1a173NavigationId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationPersonalInformations_CitizenshipTypes_Citizenship~",
                        column: x => x.CitizenshipTypeId1a5NavigationId,
                        principalTable: "CitizenshipTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationPersonalInformations_Countries_CurrentCountryId1a~",
                        column: x => x.CurrentCountryId1a136NavigationId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationPersonalInformations_Countries_FormerCountryId1a1~",
                        column: x => x.FormerCountryId1a156NavigationId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationPersonalInformations_Countries_MailingCountryId1a~",
                        column: x => x.MailingCountryId1a176NavigationId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationPersonalInformations_CountryStates_CurrentStateId~",
                        column: x => x.CurrentStateId1a134NavigationId,
                        principalTable: "CountryStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationPersonalInformations_CountryStates_FormerStateId1~",
                        column: x => x.FormerStateId1a154NavigationId,
                        principalTable: "CountryStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationPersonalInformations_CountryStates_MailingStateId~",
                        column: x => x.MailingStateId1a174NavigationId,
                        principalTable: "CountryStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationPersonalInformations_HousingTypes_CurrentHousingT~",
                        column: x => x.CurrentHousingTypeId1a141NavigationId,
                        principalTable: "HousingTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationPersonalInformations_HousingTypes_FormerHousingTy~",
                        column: x => x.FormerHousingTypeId1a161NavigationId,
                        principalTable: "HousingTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationPersonalInformations_MaritialStatuses_MaritialSta~",
                        column: x => x.MaritialStatusId1a7NavigationId,
                        principalTable: "MaritialStatuses",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unit = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    StateId1 = table.Column<long>(type: "bigint", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    Zip = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Year = table.Column<int>(type: "int", nullable: true),
                    Month = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HousingType = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rent = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    AddressType = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urla_addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_urla_addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_urla_addresses_CountryStates_StateId1",
                        column: x => x.StateId1,
                        principalTable: "CountryStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_urla_addresses_urla_personal_information_PersonalInformation~",
                        column: x => x.PersonalInformationId,
                        principalTable: "urla_personal_information",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_employment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmploymentType = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Street = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unit = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    StateId1 = table.Column<long>(type: "bigint", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    Zip = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OwnershipShare = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    MonthlyIncome = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    WorkingYears = table.Column<int>(type: "int", nullable: true),
                    WorkingMonths = table.Column<int>(type: "int", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsEmployedBySomeone = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsSelfEmployed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsOwnershipLessThan25 = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_employment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urla_employment_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_urla_employment_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_urla_employment_CountryStates_StateId1",
                        column: x => x.StateId1,
                        principalTable: "CountryStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_urla_employment_urla_personal_information_PersonalInformatio~",
                        column: x => x.PersonalInformationId,
                        principalTable: "urla_personal_information",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_loan_property_addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    StateId1 = table.Column<long>(type: "bigint", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    Zip = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumberOfUnits = table.Column<int>(type: "int", nullable: true),
                    PropertyValue = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_loan_property_addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urla_loan_property_addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_urla_loan_property_addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_urla_loan_property_addresses_CountryStates_StateId1",
                        column: x => x.StateId1,
                        principalTable: "CountryStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_urla_loan_property_addresses_urla_personal_information_Perso~",
                        column: x => x.PersonalInformationId,
                        principalTable: "urla_personal_information",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_property_financial_informations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FinancialInformationType = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unit = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    StateId1 = table.Column<long>(type: "bigint", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    Zip = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyValue = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    IntendedOccupancy = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MonthlyInsurance = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    MonthlyRentalIncome = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    NetMonthlyRentalIncome = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_property_financial_informations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urla_property_financial_informations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_urla_property_financial_informations_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_urla_property_financial_informations_CountryStates_StateId1",
                        column: x => x.StateId1,
                        principalTable: "CountryStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_urla_property_financial_informations_urla_personal_informati~",
                        column: x => x.PersonalInformationId,
                        principalTable: "urla_personal_information",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AdminLoanapplicationdocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LoanId = table.Column<int>(type: "int", nullable: false),
                    DisclosureId = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DocumentPath = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminLoanapplicationdocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminLoanapplicationdocuments_Admindisclosures_DisclosureId",
                        column: x => x.DisclosureId,
                        principalTable: "Admindisclosures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminLoanapplicationdocuments_AdminLoandetails_LoanId",
                        column: x => x.LoanId,
                        principalTable: "AdminLoandetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AdminLoansummarystatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LoanId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminLoansummarystatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminLoansummarystatuses_admin_loanstatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "admin_loanstatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminLoansummarystatuses_AdminLoandetails_LoanId",
                        column: x => x.LoanId,
                        principalTable: "AdminLoandetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Additionalincomes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    IncomeSourceId = table.Column<int>(type: "int", nullable: true),
                    BorrowerTypeId = table.Column<int>(type: "int", nullable: true),
                    LoanApplicationId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Additionalincomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Additionalincomes_Borrowertypes_BorrowerTypeId",
                        column: x => x.BorrowerTypeId,
                        principalTable: "Borrowertypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Additionalincomes_Incomesources1_IncomeSourceId",
                        column: x => x.IncomeSourceId,
                        principalTable: "Incomesources1",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Additionalincomes_Loanapplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "Loanapplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Borroweremploymentinformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmployersName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmployersAddress1 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmployersAddress2 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsSelfEmployed = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    BorrowerTypeId = table.Column<int>(type: "int", nullable: false),
                    LoanApplicationId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borroweremploymentinformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Borroweremploymentinformations_Borrowertypes_BorrowerTypeId",
                        column: x => x.BorrowerTypeId,
                        principalTable: "Borrowertypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Borroweremploymentinformations_Loanapplications_LoanApplicat~",
                        column: x => x.LoanApplicationId,
                        principalTable: "Loanapplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Borrowermonthlyincomes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Base = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Overtime = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Bonuses = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Commissions = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Dividends = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    BorrowerTypeId = table.Column<int>(type: "int", nullable: false),
                    LoanApplicationId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowermonthlyincomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Borrowermonthlyincomes_Borrowertypes_BorrowerTypeId",
                        column: x => x.BorrowerTypeId,
                        principalTable: "Borrowertypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Borrowermonthlyincomes_Loanapplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "Loanapplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Declarationborroweredemographicsinformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsHispanicOrLatino = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsMexican = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsPuertoRican = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsCuban = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsOtherHispanicOrLatino = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Origin = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsNotHispanicOrLatino = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CanNotProvideEthnic = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsAmericanIndianOrAlaskaNative = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    NameOfEnrolledOrPrincipalTribe = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAsian = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsAsianIndian = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsChinese = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsFilipino = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsJapanese = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsKorean = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsVietnamese = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsOtherAsian = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsBlackOrAfricanAmerican = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsNativeHawaiianOrOtherPacificIslander = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsNativeHawaiian = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsGuamanianOrChamorro = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsSamoan = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsOtherPacificIslander = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    EnterRace = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsWhite = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CanNotProvideRace = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsMale = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsFemale = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CanNotProvideSex = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    BorrowerTypeId = table.Column<int>(type: "int", nullable: false),
                    LoanApplicationId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Declarationborroweredemographicsinformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Declarationborroweredemographicsinformations_Borrowertypes_B~",
                        column: x => x.BorrowerTypeId,
                        principalTable: "Borrowertypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Declarationborroweredemographicsinformations_Loanapplication~",
                        column: x => x.LoanApplicationId,
                        principalTable: "Loanapplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Declarations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsOutstandingJudgmentsAgainstYou = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsDeclaredBankrupt = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsPropertyForeClosedUponOrGivenTitle = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsPartyToLawsuit = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsObligatedOnAnyLoanWhichResultedForeclosure = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsPresentlyDelinquent = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsObligatedToPayAlimonyChildSupport = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsAnyPartOfTheDownPayment = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsCoMakerOrEndorser = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsUscitizen = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsPermanentResidentSlien = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsIntendToOccupyThePropertyAsYourPrimary = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsOwnershipInterestInPropertyInTheLastThreeYears = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    DeclarationsSection = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoanApplicationId = table.Column<long>(type: "bigint", nullable: false),
                    BorrowerTypeId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Declarations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Declarations_Borrowertypes_BorrowerTypeId",
                        column: x => x.BorrowerTypeId,
                        principalTable: "Borrowertypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Declarations_Loanapplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "Loanapplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Manualassetentries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AssetTypeId = table.Column<long>(type: "bigint", nullable: false),
                    AccountNumber = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CashValue = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address2 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    ZipCode = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BankName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyStatus = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyIsUsedAs = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyType = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PresentMarketValue = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    OutstandingMortgageBalance = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    MonthlyMortgagePayment = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    PurchasePrice = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    GrossRentalIncome = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    TaxesInsuranceAndOther = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    LoanApplicationId = table.Column<long>(type: "bigint", nullable: false),
                    BorrowerTypeId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manualassetentries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manualassetentries_Assettypes_AssetTypeId",
                        column: x => x.AssetTypeId,
                        principalTable: "Assettypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manualassetentries_Borrowertypes_BorrowerTypeId",
                        column: x => x.BorrowerTypeId,
                        principalTable: "Borrowertypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manualassetentries_Loanapplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "Loanapplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manualassetentries_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApplicationAdditionalEmployementDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationPersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    EmployerBusinessName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Street = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unit = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Zip = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    PositionTitle = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    WorkingYears = table.Column<int>(type: "int", nullable: true),
                    WorkingMonths = table.Column<int>(type: "int", nullable: true),
                    IsEmployedBySomeone = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    IsSelfEmployed = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    IsOwnershipLessThan25 = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    MonthlyIncome = table.Column<float>(type: "float", nullable: true),
                    StateId1 = table.Column<long>(type: "bigint", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationAdditionalEmployementDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationAdditionalEmployementDetails_ApplicationPersonalI~",
                        column: x => x.ApplicationPersonalInformationId,
                        principalTable: "ApplicationPersonalInformations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationAdditionalEmployementDetails_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationAdditionalEmployementDetails_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationAdditionalEmployementDetails_CountryStates_StateI~",
                        column: x => x.StateId1,
                        principalTable: "CountryStates",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApplicationDeclarationQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationPersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    DeclarationQuestionId = table.Column<int>(type: "int", nullable: true),
                    YesNo = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    Description5a = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationDeclarationQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationDeclarationQuestions_ApplicationPersonalInformati~",
                        column: x => x.ApplicationPersonalInformationId,
                        principalTable: "ApplicationPersonalInformations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationDeclarationQuestions_DeclarationQuestions_Declara~",
                        column: x => x.DeclarationQuestionId,
                        principalTable: "DeclarationQuestions",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApplicationEmployementDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationPersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    EmployerBusinessName1b2 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone1b3 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Street1b41 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unit1b42 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Zip1b45 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CountryId1b46 = table.Column<int>(type: "int", nullable: false),
                    StateId1b44 = table.Column<int>(type: "int", nullable: false),
                    CityId1b43 = table.Column<int>(type: "int", nullable: false),
                    PositionTitle1b5 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate1b6 = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    WorkingYears1b7 = table.Column<int>(type: "int", nullable: true),
                    WorkingMonths = table.Column<int>(type: "int", nullable: true),
                    IsEmployedBySomeone1b8 = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    IsSelfEmployed1b9 = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    IsOwnershipLessThan251b91 = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    MonthlyIncome1b92 = table.Column<float>(type: "float", nullable: true),
                    CityId1b43NavigationId = table.Column<int>(type: "int", nullable: true),
                    CountryId1b46NavigationId = table.Column<int>(type: "int", nullable: true),
                    StateId1b44NavigationId = table.Column<long>(type: "bigint", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationEmployementDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationEmployementDetails_ApplicationPersonalInformation~",
                        column: x => x.ApplicationPersonalInformationId,
                        principalTable: "ApplicationPersonalInformations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationEmployementDetails_Cities_CityId1b43NavigationId",
                        column: x => x.CityId1b43NavigationId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationEmployementDetails_Countries_CountryId1b46Navigat~",
                        column: x => x.CountryId1b46NavigationId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationEmployementDetails_CountryStates_StateId1b44Navig~",
                        column: x => x.StateId1b44NavigationId,
                        principalTable: "CountryStates",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApplicationFinancialAssets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationPersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    FinancialAccountTypeId2a1 = table.Column<int>(type: "int", nullable: false),
                    FinancialInstitution2a2 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountNumber2a3 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value2a4 = table.Column<float>(type: "float", nullable: true),
                    FinancialAccountTypeId2a1NavigationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationFinancialAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationFinancialAssets_ApplicationPersonalInformations_A~",
                        column: x => x.ApplicationPersonalInformationId,
                        principalTable: "ApplicationPersonalInformations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationFinancialAssets_FinancialAccountTypes_FinancialAc~",
                        column: x => x.FinancialAccountTypeId2a1NavigationId,
                        principalTable: "FinancialAccountTypes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApplicationFinancialLaibilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationPersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    FinancialLaibilitiesType2c1 = table.Column<int>(type: "int", nullable: false),
                    CompanyName2c2 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountNumber2c3 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UnpaidBalance2c4 = table.Column<float>(type: "float", nullable: true),
                    PaidOff2c5 = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    MonthlyValue2c6 = table.Column<float>(type: "float", nullable: true),
                    FinancialLaibilitiesType2c1NavigationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationFinancialLaibilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationFinancialLaibilities_ApplicationPersonalInformati~",
                        column: x => x.ApplicationPersonalInformationId,
                        principalTable: "ApplicationPersonalInformations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationFinancialLaibilities_FinancialLaibilitiesTypes_Fi~",
                        column: x => x.FinancialLaibilitiesType2c1NavigationId,
                        principalTable: "FinancialLaibilitiesTypes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApplicationFinancialOtherAssets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationPersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    FinancialAssetsTypesId2b1 = table.Column<int>(type: "int", nullable: false),
                    Value2b2 = table.Column<float>(type: "float", nullable: true),
                    FinancialAssetsTypesId2b1NavigationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationFinancialOtherAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationFinancialOtherAssets_ApplicationPersonalInformati~",
                        column: x => x.ApplicationPersonalInformationId,
                        principalTable: "ApplicationPersonalInformations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationFinancialOtherAssets_FinancialAssetsTypes_Financi~",
                        column: x => x.FinancialAssetsTypesId2b1NavigationId,
                        principalTable: "FinancialAssetsTypes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApplicationFinancialOtherLaibilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationPersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    FinancialOtherLaibilitiesTypeId2d1 = table.Column<int>(type: "int", nullable: false),
                    MonthlyPayment2d2 = table.Column<float>(type: "float", nullable: true),
                    FinancialOtherLaibilitiesTypeId2d1NavigationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationFinancialOtherLaibilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationFinancialOtherLaibilities_ApplicationPersonalInfo~",
                        column: x => x.ApplicationPersonalInformationId,
                        principalTable: "ApplicationPersonalInformations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationFinancialOtherLaibilities_FinancialOtherLaibiliti~",
                        column: x => x.FinancialOtherLaibilitiesTypeId2d1NavigationId,
                        principalTable: "FinancialOtherLaibilitiesTypes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApplicationFinancialRealEstates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationPersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    Street3a21 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UnitNo3a22 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Zip3a25 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CountryId3a26 = table.Column<int>(type: "int", nullable: false),
                    StateId3a24 = table.Column<int>(type: "int", nullable: false),
                    CityId3a23 = table.Column<int>(type: "int", nullable: false),
                    PropertyValue3a3 = table.Column<float>(type: "float", nullable: true),
                    FinancialPropertyStatusId3a4 = table.Column<int>(type: "int", nullable: false),
                    FinancialPropertyIntendedOccupancyId3a5 = table.Column<int>(type: "int", nullable: false),
                    MonthlyMortagePayment3a6 = table.Column<float>(type: "float", nullable: true),
                    MonthlyRentalIncome3a7 = table.Column<float>(type: "float", nullable: true),
                    NetMonthlyRentalIncome3a8 = table.Column<float>(type: "float", nullable: true),
                    CityId3a23NavigationId = table.Column<int>(type: "int", nullable: true),
                    CountryId3a26NavigationId = table.Column<int>(type: "int", nullable: true),
                    FinancialPropertyIntendedOccupancyId3a5NavigationId = table.Column<int>(type: "int", nullable: true),
                    FinancialPropertyStatusId3a4NavigationId = table.Column<int>(type: "int", nullable: true),
                    StateId3a24NavigationId = table.Column<long>(type: "bigint", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationFinancialRealEstates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationFinancialRealEstates_ApplicationPersonalInformati~",
                        column: x => x.ApplicationPersonalInformationId,
                        principalTable: "ApplicationPersonalInformations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationFinancialRealEstates_Cities_CityId3a23NavigationId",
                        column: x => x.CityId3a23NavigationId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationFinancialRealEstates_Countries_CountryId3a26Navig~",
                        column: x => x.CountryId3a26NavigationId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationFinancialRealEstates_CountryStates_StateId3a24Nav~",
                        column: x => x.StateId3a24NavigationId,
                        principalTable: "CountryStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationFinancialRealEstates_FinancialPropertyIntendedOcc~",
                        column: x => x.FinancialPropertyIntendedOccupancyId3a5NavigationId,
                        principalTable: "FinancialPropertyIntendedOccupancies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationFinancialRealEstates_FinancialPropertyStatuses_Fi~",
                        column: x => x.FinancialPropertyStatusId3a4NavigationId,
                        principalTable: "FinancialPropertyStatuses",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApplicationIncomeSources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationPersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    IncomeSourceId1e1 = table.Column<int>(type: "int", nullable: false),
                    Amount1e2 = table.Column<float>(type: "float", nullable: true),
                    IncomeSourceId1e1NavigationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationIncomeSources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationIncomeSources_ApplicationPersonalInformations_App~",
                        column: x => x.ApplicationPersonalInformationId,
                        principalTable: "ApplicationPersonalInformations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationIncomeSources_IncomeSources_IncomeSourceId1e1Navi~",
                        column: x => x.IncomeSourceId1e1NavigationId,
                        principalTable: "IncomeSources",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApplicationPreviousEmployementDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationPersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    EmployerBusinessName1d2 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Street1d31 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unit1d32 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Zip1d35 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CountryId1d36 = table.Column<int>(type: "int", nullable: false),
                    StateId1d34 = table.Column<int>(type: "int", nullable: false),
                    CityId1d33 = table.Column<int>(type: "int", nullable: false),
                    PositionTitle1d4 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate1d5 = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EndDate1d6 = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsSelfEmployed1d7 = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    GrossMonthlyIncome1d8 = table.Column<float>(type: "float", nullable: true),
                    CityId1d33NavigationId = table.Column<int>(type: "int", nullable: true),
                    CountryId1d36NavigationId = table.Column<int>(type: "int", nullable: true),
                    StateId1d34NavigationId = table.Column<long>(type: "bigint", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationPreviousEmployementDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationPreviousEmployementDetails_ApplicationPersonalInf~",
                        column: x => x.ApplicationPersonalInformationId,
                        principalTable: "ApplicationPersonalInformations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationPreviousEmployementDetails_Cities_CityId1d33Navig~",
                        column: x => x.CityId1d33NavigationId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationPreviousEmployementDetails_Countries_CountryId1d3~",
                        column: x => x.CountryId1d36NavigationId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationPreviousEmployementDetails_CountryStates_StateId1~",
                        column: x => x.StateId1d34NavigationId,
                        principalTable: "CountryStates",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DemographicInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationPersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    Ethnicity81 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender82 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Race83 = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsEthnicityByObservation84 = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    IsGenderByObservation85 = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    IsRaceByObservation86 = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    DemographicInfoSourceId87 = table.Column<int>(type: "int", nullable: true),
                    DemographicInfoSourceId87NavigationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemographicInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DemographicInformations_ApplicationPersonalInformations_Appl~",
                        column: x => x.ApplicationPersonalInformationId,
                        principalTable: "ApplicationPersonalInformations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DemographicInformations_DemographicInfoSources_DemographicIn~",
                        column: x => x.DemographicInfoSourceId87NavigationId,
                        principalTable: "DemographicInfoSources",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_employment_income",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BaseIncome = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Overtime = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Bonus = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    MilitaryEntitlements = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Other = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    EmploymentDetailId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_employment_income", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urla_employment_income_urla_employment_EmploymentDetailId",
                        column: x => x.EmploymentDetailId,
                        principalTable: "urla_employment",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urla_property_mortgage_loan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreditorName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountNumber = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MonthlyMortagagePayment = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    UnpaidBalance = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreditLimit = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    IsPaidBeforeClosing = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    MortgagePropertyFinancialInformationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urla_property_mortgage_loan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urla_property_mortgage_loan_urla_property_financial_informat~",
                        column: x => x.MortgagePropertyFinancialInformationId,
                        principalTable: "urla_property_financial_informations",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Stockandbonds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountNumber = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ManualAssetEntryId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stockandbonds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stockandbonds_Manualassetentries_ManualAssetEntryId",
                        column: x => x.ManualAssetEntryId,
                        principalTable: "Manualassetentries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApplicationAdditionalEmployementIncomeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationAdditionalEmployementDetails = table.Column<int>(type: "int", nullable: false),
                    IncomeTypeId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<float>(type: "float", nullable: true),
                    ApplicationAdditionalEmployementDetailsNavigationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationAdditionalEmployementIncomeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationAdditionalEmployementIncomeDetails_ApplicationAdd~",
                        column: x => x.ApplicationAdditionalEmployementDetailsNavigationId,
                        principalTable: "ApplicationAdditionalEmployementDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationAdditionalEmployementIncomeDetails_IncomeTypes_In~",
                        column: x => x.IncomeTypeId,
                        principalTable: "IncomeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApplicationEmployementIncomeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationEmployementDetailsId = table.Column<int>(type: "int", nullable: false),
                    IncomeTypeId1b101 = table.Column<int>(type: "int", nullable: false),
                    Amount1b10 = table.Column<float>(type: "float", nullable: true),
                    IncomeTypeId1b101NavigationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationEmployementIncomeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationEmployementIncomeDetails_ApplicationEmployementDe~",
                        column: x => x.ApplicationEmployementDetailsId,
                        principalTable: "ApplicationEmployementDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationEmployementIncomeDetails_IncomeTypes_IncomeTypeId~",
                        column: x => x.IncomeTypeId1b101NavigationId,
                        principalTable: "IncomeTypes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Assettypes",
                columns: new[] { "Id", "CreationTime", "CreatorUserId", "DeleterUserId", "DeletionTime", "IsDeleted", "LastModificationTime", "LastModifierUserId", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 2, 17, 20, 27, 51, 640, DateTimeKind.Local).AddTicks(9759), null, null, null, false, null, null, "Cash deposit on sales contract" },
                    { 2L, new DateTime(2023, 2, 17, 20, 27, 51, 640, DateTimeKind.Local).AddTicks(9775), null, null, null, false, null, null, "Certificate of Deposit" },
                    { 3L, new DateTime(2023, 2, 17, 20, 27, 51, 640, DateTimeKind.Local).AddTicks(9777), null, null, null, false, null, null, "Checking Account" },
                    { 4L, new DateTime(2023, 2, 17, 20, 27, 51, 640, DateTimeKind.Local).AddTicks(9778), null, null, null, false, null, null, "Gifts" },
                    { 5L, new DateTime(2023, 2, 17, 20, 27, 51, 640, DateTimeKind.Local).AddTicks(9779), null, null, null, false, null, null, "Gift of equity" },
                    { 6L, new DateTime(2023, 2, 17, 20, 27, 51, 640, DateTimeKind.Local).AddTicks(9781), null, null, null, false, null, null, "Money Market Fund" },
                    { 7L, new DateTime(2023, 2, 17, 20, 27, 51, 640, DateTimeKind.Local).AddTicks(9782), null, null, null, false, null, null, "Mutual Funds" },
                    { 8L, new DateTime(2023, 2, 17, 20, 27, 51, 640, DateTimeKind.Local).AddTicks(9783), null, null, null, false, null, null, "Net Proceeds from Real Estate Funds" },
                    { 9L, new DateTime(2023, 2, 17, 20, 27, 51, 640, DateTimeKind.Local).AddTicks(9792), null, null, null, false, null, null, "Real Estate Owned" },
                    { 10L, new DateTime(2023, 2, 17, 20, 27, 51, 640, DateTimeKind.Local).AddTicks(9794), null, null, null, false, null, null, "Retirement Funds" },
                    { 11L, new DateTime(2023, 2, 17, 20, 27, 51, 640, DateTimeKind.Local).AddTicks(9795), null, null, null, false, null, null, "Savings Account" },
                    { 12L, new DateTime(2023, 2, 17, 20, 27, 51, 640, DateTimeKind.Local).AddTicks(9796), null, null, null, false, null, null, "Stocks & Bonds" },
                    { 13L, new DateTime(2023, 2, 17, 20, 27, 51, 640, DateTimeKind.Local).AddTicks(9797), null, null, null, false, null, null, "Trust Account" }
                });

            migrationBuilder.InsertData(
                table: "Borrowertypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Borrower" },
                    { 2, "Co-Borrower" },
                    { 3, "Both" }
                });

            migrationBuilder.InsertData(
                table: "IncomeSources",
                columns: new[] { "Id", "CreationTime", "CreatorUserId", "DeleterUserId", "DeletionTime", "IncomeSource1", "IsDeleted", "LastModificationTime", "LastModifierUserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 17, 20, 27, 51, 641, DateTimeKind.Local).AddTicks(27), null, null, null, "Accessory Unit Income", false, null, null },
                    { 2, new DateTime(2023, 2, 17, 20, 27, 51, 641, DateTimeKind.Local).AddTicks(32), null, null, null, "Alimony/Child Support", false, null, null },
                    { 3, new DateTime(2023, 2, 17, 20, 27, 51, 641, DateTimeKind.Local).AddTicks(33), null, null, null, "Automobile/Expense Account", false, null, null },
                    { 4, new DateTime(2023, 2, 17, 20, 27, 51, 641, DateTimeKind.Local).AddTicks(34), null, null, null, "Boarder Income", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Sitesettings",
                columns: new[] { "Id", "CreationTime", "CreatorUserId", "DeleterUserId", "DeletionTime", "IsDeleted", "LastModificationTime", "LastModifierUserId", "PageIdentifier", "PageName", "PageSetting" },
                values: new object[] { 1, new DateTime(2023, 2, 17, 20, 27, 51, 641, DateTimeKind.Local).AddTicks(71), null, null, null, false, null, null, "app/home", "Home page", "{\"MainCarousels\":[{\"FilePath\":\"assets/img/house.png\",\"Header\":\"Best California Home Loans\",\"SubHeader\":\"Better Rate then banks, Better customer services\"}],\"FirstBlog\":{\"FilePath\":\"assets/img/house.png\",\"Header\":\"GET A NO-HASSLE LOAN FOR UP TO $697,650\",\"SubHeader\":\"Fast Closing FHA Loans\",\"Description\":\"Take Advantage of our FHA Elite Rates starting at\"},\"SecondBlog\":{\"FilePath\":\"assets/img/living-room.png\",\"Header\":\"Conventional Jombo Rate\",\"SubHeader\":\"GET A NO-HASSLE LOAN FOR UP TO $697,650\",\"Description\":\"Save cash with a low-rate conventional loan up to\"},\"ThirdBlog\":{\"FilePath\":\"assets/img/money.png\",\"Header\":\"Tap Into Your Equity\",\"SubHeader\":\"\",\"Description\":\"We offer unique programs that let you refinance up\"},\"ForthBlog\":{\"FilePath\":\"assets/img/new-home.png\",\"Header\":\"Purchase Your Dream Home\",\"SubHeader\":\"\",\"Description\":\"Your dream home may no longer be a dream\"},\"VideoSection\":{\"FilePath\":\"assets/img/Image 16.png\",\"Header\":\"Know about\",\"SubHeader\":\"YOUR INDEPENDENT MORTGAGE BROKER IN CALIFORNIA\",\"Description\":\"To make sure all borrowers get the best mortgage rate and loan program with excellent customer service and satisfaction.\"},\"KnowAboutHeader\":\"Tips For Getting A Home Mortgage In California\",\"ChecklistMainHeader\":\"How To Apply For Your Loan\",\"Checklist\":{\"Checklist1\":\"Calculate Loan Rate\",\"Checklist2\":\"Speak With An Expert\",\"Checklist3\":\"Benefit Of Preapproval\",\"Checklist4\":\"Get A Free Quote\"},\"SloganImage\":\"assets/img/finance.png\",\"Slogan\":\"Work With A High-Tech Mortgage Loan Broker\",\"SloganChecklist\":\"Our easy-to-use online tools streamline the mortgage process.\\nGet mortgage estimates, instant rate quotes, and access to our online calculators.\\nLoan applications can be done entirely online(or via fax) on our secure portal.\\nReceive updates about your application – as well as helpful mortgage news – on your phone, tablet or laptop\",\"Testimonials\":[{\"Comment\":\"Thank you for all your help in making the mortgage process go smoothly! my husband and i could n't have done it without you.\",\"Author\":\"Anne Davidson (San Francisco, CA)\"}]}" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogs_TenantId_ExecutionDuration",
                table: "AbpAuditLogs",
                columns: new[] { "TenantId", "ExecutionDuration" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogs_TenantId_ExecutionTime",
                table: "AbpAuditLogs",
                columns: new[] { "TenantId", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogs_TenantId_UserId",
                table: "AbpAuditLogs",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpBackgroundJobs_IsAbandoned_NextTryTime",
                table: "AbpBackgroundJobs",
                columns: new[] { "IsAbandoned", "NextTryTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpDynamicEntityProperties_DynamicPropertyId",
                table: "AbpDynamicEntityProperties",
                column: "DynamicPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpDynamicEntityProperties_EntityFullName_DynamicPropertyId_~",
                table: "AbpDynamicEntityProperties",
                columns: new[] { "EntityFullName", "DynamicPropertyId", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpDynamicEntityPropertyValues_DynamicEntityPropertyId",
                table: "AbpDynamicEntityPropertyValues",
                column: "DynamicEntityPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpDynamicProperties_PropertyName_TenantId",
                table: "AbpDynamicProperties",
                columns: new[] { "PropertyName", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpDynamicPropertyValues_DynamicPropertyId",
                table: "AbpDynamicPropertyValues",
                column: "DynamicPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChanges_EntityChangeSetId",
                table: "AbpEntityChanges",
                column: "EntityChangeSetId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChanges_EntityTypeFullName_EntityId",
                table: "AbpEntityChanges",
                columns: new[] { "EntityTypeFullName", "EntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChangeSets_TenantId_CreationTime",
                table: "AbpEntityChangeSets",
                columns: new[] { "TenantId", "CreationTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChangeSets_TenantId_Reason",
                table: "AbpEntityChangeSets",
                columns: new[] { "TenantId", "Reason" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChangeSets_TenantId_UserId",
                table: "AbpEntityChangeSets",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityPropertyChanges_EntityChangeId",
                table: "AbpEntityPropertyChanges",
                column: "EntityChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpFeatures_EditionId_Name",
                table: "AbpFeatures",
                columns: new[] { "EditionId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpFeatures_TenantId_Name",
                table: "AbpFeatures",
                columns: new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpLanguages_TenantId_Name",
                table: "AbpLanguages",
                columns: new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpLanguageTexts_TenantId_Source_LanguageName_Key",
                table: "AbpLanguageTexts",
                columns: new[] { "TenantId", "Source", "LanguageName", "Key" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpNotificationSubscriptions_NotificationName_EntityTypeName~",
                table: "AbpNotificationSubscriptions",
                columns: new[] { "NotificationName", "EntityTypeName", "EntityId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpNotificationSubscriptions_TenantId_NotificationName_Entit~",
                table: "AbpNotificationSubscriptions",
                columns: new[] { "TenantId", "NotificationName", "EntityTypeName", "EntityId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnitRoles_TenantId_OrganizationUnitId",
                table: "AbpOrganizationUnitRoles",
                columns: new[] { "TenantId", "OrganizationUnitId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnitRoles_TenantId_RoleId",
                table: "AbpOrganizationUnitRoles",
                columns: new[] { "TenantId", "RoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnits_ParentId",
                table: "AbpOrganizationUnits",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnits_TenantId_Code",
                table: "AbpOrganizationUnits",
                columns: new[] { "TenantId", "Code" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpPermissions_RoleId",
                table: "AbpPermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpPermissions_TenantId_Name",
                table: "AbpPermissions",
                columns: new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpPermissions_UserId",
                table: "AbpPermissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoleClaims_RoleId",
                table: "AbpRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoleClaims_TenantId_ClaimType",
                table: "AbpRoleClaims",
                columns: new[] { "TenantId", "ClaimType" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoles_CreatorUserId",
                table: "AbpRoles",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoles_DeleterUserId",
                table: "AbpRoles",
                column: "DeleterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoles_LastModifierUserId",
                table: "AbpRoles",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoles_TenantId_NormalizedName",
                table: "AbpRoles",
                columns: new[] { "TenantId", "NormalizedName" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpSettings_TenantId_Name_UserId",
                table: "AbpSettings",
                columns: new[] { "TenantId", "Name", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpSettings_UserId",
                table: "AbpSettings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenantNotifications_TenantId",
                table: "AbpTenantNotifications",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_CreatorUserId",
                table: "AbpTenants",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_DeleterUserId",
                table: "AbpTenants",
                column: "DeleterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_EditionId",
                table: "AbpTenants",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_LastModifierUserId",
                table: "AbpTenants",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_TenancyName",
                table: "AbpTenants",
                column: "TenancyName");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserAccounts_EmailAddress",
                table: "AbpUserAccounts",
                column: "EmailAddress");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserAccounts_TenantId_EmailAddress",
                table: "AbpUserAccounts",
                columns: new[] { "TenantId", "EmailAddress" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserAccounts_TenantId_UserId",
                table: "AbpUserAccounts",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserAccounts_TenantId_UserName",
                table: "AbpUserAccounts",
                columns: new[] { "TenantId", "UserName" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserAccounts_UserName",
                table: "AbpUserAccounts",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserClaims_TenantId_ClaimType",
                table: "AbpUserClaims",
                columns: new[] { "TenantId", "ClaimType" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserClaims_UserId",
                table: "AbpUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserLoginAttempts_TenancyName_UserNameOrEmailAddress_Resu~",
                table: "AbpUserLoginAttempts",
                columns: new[] { "TenancyName", "UserNameOrEmailAddress", "Result" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserLoginAttempts_UserId_TenantId",
                table: "AbpUserLoginAttempts",
                columns: new[] { "UserId", "TenantId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserLogins_ProviderKey_TenantId",
                table: "AbpUserLogins",
                columns: new[] { "ProviderKey", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserLogins_TenantId_LoginProvider_ProviderKey",
                table: "AbpUserLogins",
                columns: new[] { "TenantId", "LoginProvider", "ProviderKey" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserLogins_TenantId_UserId",
                table: "AbpUserLogins",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserLogins_UserId",
                table: "AbpUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserNotifications_UserId_State_CreationTime",
                table: "AbpUserNotifications",
                columns: new[] { "UserId", "State", "CreationTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserOrganizationUnits_TenantId_OrganizationUnitId",
                table: "AbpUserOrganizationUnits",
                columns: new[] { "TenantId", "OrganizationUnitId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserOrganizationUnits_TenantId_UserId",
                table: "AbpUserOrganizationUnits",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserRoles_TenantId_RoleId",
                table: "AbpUserRoles",
                columns: new[] { "TenantId", "RoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserRoles_TenantId_UserId",
                table: "AbpUserRoles",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserRoles_UserId",
                table: "AbpUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_CreatorUserId",
                table: "AbpUsers",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_DeleterUserId",
                table: "AbpUsers",
                column: "DeleterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_LastModifierUserId",
                table: "AbpUsers",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_TenantId_NormalizedEmailAddress",
                table: "AbpUsers",
                columns: new[] { "TenantId", "NormalizedEmailAddress" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_TenantId_NormalizedUserName",
                table: "AbpUsers",
                columns: new[] { "TenantId", "NormalizedUserName" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserTokens_TenantId_UserId",
                table: "AbpUserTokens",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserTokens_UserId",
                table: "AbpUserTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpWebhookSendAttempts_WebhookEventId",
                table: "AbpWebhookSendAttempts",
                column: "WebhookEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Additionalincomes_BorrowerTypeId",
                table: "Additionalincomes",
                column: "BorrowerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Additionalincomes_IncomeSourceId",
                table: "Additionalincomes",
                column: "IncomeSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Additionalincomes_LoanApplicationId",
                table: "Additionalincomes",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_BorrowerTypeId",
                table: "Addresses",
                column: "BorrowerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PersonalDetailId",
                table: "Addresses",
                column: "PersonalDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StateId",
                table: "Addresses",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminLoanapplicationdocuments_DisclosureId",
                table: "AdminLoanapplicationdocuments",
                column: "DisclosureId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminLoanapplicationdocuments_LoanId",
                table: "AdminLoanapplicationdocuments",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminLoandetails_LoanApplicationId",
                table: "AdminLoandetails",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminLoandetails_LoanProgramId",
                table: "AdminLoandetails",
                column: "LoanProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminLoansummarystatuses_LoanId",
                table: "AdminLoansummarystatuses",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminLoansummarystatuses_StatusId",
                table: "AdminLoansummarystatuses",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationAdditionalEmployementDetails_ApplicationPersonalI~",
                table: "ApplicationAdditionalEmployementDetails",
                column: "ApplicationPersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationAdditionalEmployementDetails_CityId",
                table: "ApplicationAdditionalEmployementDetails",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationAdditionalEmployementDetails_CountryId",
                table: "ApplicationAdditionalEmployementDetails",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationAdditionalEmployementDetails_StateId1",
                table: "ApplicationAdditionalEmployementDetails",
                column: "StateId1");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationAdditionalEmployementIncomeDetails_ApplicationAdd~",
                table: "ApplicationAdditionalEmployementIncomeDetails",
                column: "ApplicationAdditionalEmployementDetailsNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationAdditionalEmployementIncomeDetails_IncomeTypeId",
                table: "ApplicationAdditionalEmployementIncomeDetails",
                column: "IncomeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDeclarationQuestions_ApplicationPersonalInformati~",
                table: "ApplicationDeclarationQuestions",
                column: "ApplicationPersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDeclarationQuestions_DeclarationQuestionId",
                table: "ApplicationDeclarationQuestions",
                column: "DeclarationQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationEmployementDetails_ApplicationPersonalInformation~",
                table: "ApplicationEmployementDetails",
                column: "ApplicationPersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationEmployementDetails_CityId1b43NavigationId",
                table: "ApplicationEmployementDetails",
                column: "CityId1b43NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationEmployementDetails_CountryId1b46NavigationId",
                table: "ApplicationEmployementDetails",
                column: "CountryId1b46NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationEmployementDetails_StateId1b44NavigationId",
                table: "ApplicationEmployementDetails",
                column: "StateId1b44NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationEmployementIncomeDetails_ApplicationEmployementDe~",
                table: "ApplicationEmployementIncomeDetails",
                column: "ApplicationEmployementDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationEmployementIncomeDetails_IncomeTypeId1b101Navigat~",
                table: "ApplicationEmployementIncomeDetails",
                column: "IncomeTypeId1b101NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFinancialAssets_ApplicationPersonalInformationId",
                table: "ApplicationFinancialAssets",
                column: "ApplicationPersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFinancialAssets_FinancialAccountTypeId2a1Navigati~",
                table: "ApplicationFinancialAssets",
                column: "FinancialAccountTypeId2a1NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFinancialLaibilities_ApplicationPersonalInformati~",
                table: "ApplicationFinancialLaibilities",
                column: "ApplicationPersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFinancialLaibilities_FinancialLaibilitiesType2c1N~",
                table: "ApplicationFinancialLaibilities",
                column: "FinancialLaibilitiesType2c1NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFinancialOtherAssets_ApplicationPersonalInformati~",
                table: "ApplicationFinancialOtherAssets",
                column: "ApplicationPersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFinancialOtherAssets_FinancialAssetsTypesId2b1Nav~",
                table: "ApplicationFinancialOtherAssets",
                column: "FinancialAssetsTypesId2b1NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFinancialOtherLaibilities_ApplicationPersonalInfo~",
                table: "ApplicationFinancialOtherLaibilities",
                column: "ApplicationPersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFinancialOtherLaibilities_FinancialOtherLaibiliti~",
                table: "ApplicationFinancialOtherLaibilities",
                column: "FinancialOtherLaibilitiesTypeId2d1NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFinancialRealEstates_ApplicationPersonalInformati~",
                table: "ApplicationFinancialRealEstates",
                column: "ApplicationPersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFinancialRealEstates_CityId3a23NavigationId",
                table: "ApplicationFinancialRealEstates",
                column: "CityId3a23NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFinancialRealEstates_CountryId3a26NavigationId",
                table: "ApplicationFinancialRealEstates",
                column: "CountryId3a26NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFinancialRealEstates_FinancialPropertyIntendedOcc~",
                table: "ApplicationFinancialRealEstates",
                column: "FinancialPropertyIntendedOccupancyId3a5NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFinancialRealEstates_FinancialPropertyStatusId3a4~",
                table: "ApplicationFinancialRealEstates",
                column: "FinancialPropertyStatusId3a4NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFinancialRealEstates_StateId3a24NavigationId",
                table: "ApplicationFinancialRealEstates",
                column: "StateId3a24NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationIncomeSources_ApplicationPersonalInformationId",
                table: "ApplicationIncomeSources",
                column: "ApplicationPersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationIncomeSources_IncomeSourceId1e1NavigationId",
                table: "ApplicationIncomeSources",
                column: "IncomeSourceId1e1NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPersonalInformations_ApplicationId",
                table: "ApplicationPersonalInformations",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPersonalInformations_CitizenshipTypeId1a5Navigati~",
                table: "ApplicationPersonalInformations",
                column: "CitizenshipTypeId1a5NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPersonalInformations_CurrentCityId1a133Navigation~",
                table: "ApplicationPersonalInformations",
                column: "CurrentCityId1a133NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPersonalInformations_CurrentCountryId1a136Navigat~",
                table: "ApplicationPersonalInformations",
                column: "CurrentCountryId1a136NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPersonalInformations_CurrentHousingTypeId1a141Nav~",
                table: "ApplicationPersonalInformations",
                column: "CurrentHousingTypeId1a141NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPersonalInformations_CurrentStateId1a134Navigatio~",
                table: "ApplicationPersonalInformations",
                column: "CurrentStateId1a134NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPersonalInformations_FormerCityId1a153NavigationId",
                table: "ApplicationPersonalInformations",
                column: "FormerCityId1a153NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPersonalInformations_FormerCountryId1a156Navigati~",
                table: "ApplicationPersonalInformations",
                column: "FormerCountryId1a156NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPersonalInformations_FormerHousingTypeId1a161Navi~",
                table: "ApplicationPersonalInformations",
                column: "FormerHousingTypeId1a161NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPersonalInformations_FormerStateId1a154Navigation~",
                table: "ApplicationPersonalInformations",
                column: "FormerStateId1a154NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPersonalInformations_MailingCityId1a173Navigation~",
                table: "ApplicationPersonalInformations",
                column: "MailingCityId1a173NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPersonalInformations_MailingCountryId1a176Navigat~",
                table: "ApplicationPersonalInformations",
                column: "MailingCountryId1a176NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPersonalInformations_MailingStateId1a174Navigatio~",
                table: "ApplicationPersonalInformations",
                column: "MailingStateId1a174NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPersonalInformations_MaritialStatusId1a7Navigatio~",
                table: "ApplicationPersonalInformations",
                column: "MaritialStatusId1a7NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPreviousEmployementDetails_ApplicationPersonalInf~",
                table: "ApplicationPreviousEmployementDetails",
                column: "ApplicationPersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPreviousEmployementDetails_CityId1d33NavigationId",
                table: "ApplicationPreviousEmployementDetails",
                column: "CityId1d33NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPreviousEmployementDetails_CountryId1d36Navigatio~",
                table: "ApplicationPreviousEmployementDetails",
                column: "CountryId1d36NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPreviousEmployementDetails_StateId1d34NavigationId",
                table: "ApplicationPreviousEmployementDetails",
                column: "StateId1d34NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CreditTypeId",
                table: "Applications",
                column: "CreditTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Borroweremploymentinformations_BorrowerTypeId",
                table: "Borroweremploymentinformations",
                column: "BorrowerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Borroweremploymentinformations_LoanApplicationId",
                table: "Borroweremploymentinformations",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowermonthlyincomes_BorrowerTypeId",
                table: "Borrowermonthlyincomes",
                column: "BorrowerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowermonthlyincomes_LoanApplicationId",
                table: "Borrowermonthlyincomes",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowers_BorrowerTypeId",
                table: "Borrowers",
                column: "BorrowerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId1",
                table: "Cities",
                column: "StateId1");

            migrationBuilder.CreateIndex(
                name: "IX_CountryStates_CountryId",
                table: "CountryStates",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Declarationborroweredemographicsinformations_BorrowerTypeId",
                table: "Declarationborroweredemographicsinformations",
                column: "BorrowerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Declarationborroweredemographicsinformations_LoanApplication~",
                table: "Declarationborroweredemographicsinformations",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationQuestions_DeclarationCategoryId",
                table: "DeclarationQuestions",
                column: "DeclarationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Declarations_BorrowerTypeId",
                table: "Declarations",
                column: "BorrowerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Declarations_LoanApplicationId",
                table: "Declarations",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_DemographicInformations_ApplicationPersonalInformationId",
                table: "DemographicInformations",
                column: "ApplicationPersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_DemographicInformations_DemographicInfoSourceId87NavigationId",
                table: "DemographicInformations",
                column: "DemographicInfoSourceId87NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loanapplications_AdditionalDetailId",
                table: "Loanapplications",
                column: "AdditionalDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Loanapplications_ConsentDetailId",
                table: "Loanapplications",
                column: "ConsentDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Loanapplications_CreditAuthAgreementId",
                table: "Loanapplications",
                column: "CreditAuthAgreementId");

            migrationBuilder.CreateIndex(
                name: "IX_Loanapplications_ExpenseId",
                table: "Loanapplications",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Loanapplications_LoanDetailId",
                table: "Loanapplications",
                column: "LoanDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Loanapplications_PersonalDetailId",
                table: "Loanapplications",
                column: "PersonalDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manualassetentries_AssetTypeId",
                table: "Manualassetentries",
                column: "AssetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Manualassetentries_BorrowerTypeId",
                table: "Manualassetentries",
                column: "BorrowerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Manualassetentries_LoanApplicationId",
                table: "Manualassetentries",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Manualassetentries_StateId",
                table: "Manualassetentries",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Personaldetails_BorrowerId",
                table: "Personaldetails",
                column: "BorrowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Personaldetails_CoBorrowerId",
                table: "Personaldetails",
                column: "CoBorrowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Stockandbonds_ManualAssetEntryId",
                table: "Stockandbonds",
                column: "ManualAssetEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_addresses_CityId",
                table: "urla_addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_addresses_CountryId",
                table: "urla_addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_addresses_PersonalInformationId",
                table: "urla_addresses",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_addresses_StateId1",
                table: "urla_addresses",
                column: "StateId1");

            migrationBuilder.CreateIndex(
                name: "IX_urla_agreements_PersonalInformationId",
                table: "urla_agreements",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_alternate_names_PersonalInformationId",
                table: "urla_alternate_names",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_contact_information_PersonalInformationId",
                table: "urla_contact_information",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_declaration_questions_DeclarationQuestionId",
                table: "urla_declaration_questions",
                column: "DeclarationQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_declaration_questions_PersonalInformationId",
                table: "urla_declaration_questions",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_demographic_information_PersonalInformationId",
                table: "urla_demographic_information",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_dempgraphic_info_by_financial_institutions_PersonalInfo~",
                table: "urla_dempgraphic_info_by_financial_institutions",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_employment_CityId",
                table: "urla_employment",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_employment_CountryId",
                table: "urla_employment",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_employment_PersonalInformationId",
                table: "urla_employment",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_employment_StateId1",
                table: "urla_employment",
                column: "StateId1");

            migrationBuilder.CreateIndex(
                name: "IX_urla_employment_income_EmploymentDetailId",
                table: "urla_employment_income",
                column: "EmploymentDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_financial_assets_AccountTypeId",
                table: "urla_financial_assets",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_financial_assets_PersonalInformationId",
                table: "urla_financial_assets",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_financial_liabilities_FinancialLaibilitiesTypeId",
                table: "urla_financial_liabilities",
                column: "FinancialLaibilitiesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_financial_liabilities_PersonalInformationId",
                table: "urla_financial_liabilities",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_financial_other_assets_FinancialAssetsTypeId",
                table: "urla_financial_other_assets",
                column: "FinancialAssetsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_financial_other_assets_PersonalInformationId",
                table: "urla_financial_other_assets",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_financial_other_liabilities_FinancialOtherLaibilitiesTy~",
                table: "urla_financial_other_liabilities",
                column: "FinancialOtherLaibilitiesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_financial_other_liabilities_PersonalInformationId",
                table: "urla_financial_other_liabilities",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_income_sources_IncomeSourceId",
                table: "urla_income_sources",
                column: "IncomeSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_income_sources_PersonalInformationId",
                table: "urla_income_sources",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_loan_originator_informations_PersonalInformationId",
                table: "urla_loan_originator_informations",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_loan_property_addresses_CityId",
                table: "urla_loan_property_addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_loan_property_addresses_CountryId",
                table: "urla_loan_property_addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_loan_property_addresses_PersonalInformationId",
                table: "urla_loan_property_addresses",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_loan_property_addresses_StateId1",
                table: "urla_loan_property_addresses",
                column: "StateId1");

            migrationBuilder.CreateIndex(
                name: "IX_urla_loan_property_gifts_or_grants_AssetTypeId1",
                table: "urla_loan_property_gifts_or_grants",
                column: "AssetTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_urla_loan_property_gifts_or_grants_PersonalInformationId",
                table: "urla_loan_property_gifts_or_grants",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_loan_property_information_PersonalInformationId",
                table: "urla_loan_property_information",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_loan_property_other_new_mortgage_loans_PersonalInformat~",
                table: "urla_loan_property_other_new_mortgage_loans",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_loan_property_rental_incomes_PersonalInformationId",
                table: "urla_loan_property_rental_incomes",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_military_services_PersonalInformationId",
                table: "urla_military_services",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_other_borrowers_PersonalInformationId",
                table: "urla_other_borrowers",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_personal_information_MortgageApplicationId",
                table: "urla_personal_information",
                column: "MortgageApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_property_financial_informations_CityId",
                table: "urla_property_financial_informations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_property_financial_informations_CountryId",
                table: "urla_property_financial_informations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_property_financial_informations_PersonalInformationId",
                table: "urla_property_financial_informations",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_urla_property_financial_informations_StateId1",
                table: "urla_property_financial_informations",
                column: "StateId1");

            migrationBuilder.CreateIndex(
                name: "IX_urla_property_mortgage_loan_MortgagePropertyFinancialInforma~",
                table: "urla_property_mortgage_loan",
                column: "MortgagePropertyFinancialInformationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpAuditLogs");

            migrationBuilder.DropTable(
                name: "AbpBackgroundJobs");

            migrationBuilder.DropTable(
                name: "AbpDynamicEntityPropertyValues");

            migrationBuilder.DropTable(
                name: "AbpDynamicPropertyValues");

            migrationBuilder.DropTable(
                name: "AbpEntityPropertyChanges");

            migrationBuilder.DropTable(
                name: "AbpFeatures");

            migrationBuilder.DropTable(
                name: "AbpLanguages");

            migrationBuilder.DropTable(
                name: "AbpLanguageTexts");

            migrationBuilder.DropTable(
                name: "AbpNotifications");

            migrationBuilder.DropTable(
                name: "AbpNotificationSubscriptions");

            migrationBuilder.DropTable(
                name: "AbpOrganizationUnitRoles");

            migrationBuilder.DropTable(
                name: "AbpOrganizationUnits");

            migrationBuilder.DropTable(
                name: "AbpPermissions");

            migrationBuilder.DropTable(
                name: "AbpRoleClaims");

            migrationBuilder.DropTable(
                name: "AbpSettings");

            migrationBuilder.DropTable(
                name: "AbpTenantNotifications");

            migrationBuilder.DropTable(
                name: "AbpTenants");

            migrationBuilder.DropTable(
                name: "AbpUserAccounts");

            migrationBuilder.DropTable(
                name: "AbpUserClaims");

            migrationBuilder.DropTable(
                name: "AbpUserLoginAttempts");

            migrationBuilder.DropTable(
                name: "AbpUserLogins");

            migrationBuilder.DropTable(
                name: "AbpUserNotifications");

            migrationBuilder.DropTable(
                name: "AbpUserOrganizationUnits");

            migrationBuilder.DropTable(
                name: "AbpUserRoles");

            migrationBuilder.DropTable(
                name: "AbpUserTokens");

            migrationBuilder.DropTable(
                name: "AbpWebhookSendAttempts");

            migrationBuilder.DropTable(
                name: "AbpWebhookSubscriptions");

            migrationBuilder.DropTable(
                name: "Additionalincomes");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AdminLoanapplicationdocuments");

            migrationBuilder.DropTable(
                name: "AdminLoansummarystatuses");

            migrationBuilder.DropTable(
                name: "AdminUserenableddevices");

            migrationBuilder.DropTable(
                name: "ApplicationAdditionalEmployementIncomeDetails");

            migrationBuilder.DropTable(
                name: "ApplicationDeclarationQuestions");

            migrationBuilder.DropTable(
                name: "ApplicationEmployementIncomeDetails");

            migrationBuilder.DropTable(
                name: "ApplicationFinancialAssets");

            migrationBuilder.DropTable(
                name: "ApplicationFinancialLaibilities");

            migrationBuilder.DropTable(
                name: "ApplicationFinancialOtherAssets");

            migrationBuilder.DropTable(
                name: "ApplicationFinancialOtherLaibilities");

            migrationBuilder.DropTable(
                name: "ApplicationFinancialRealEstates");

            migrationBuilder.DropTable(
                name: "ApplicationIncomeSources");

            migrationBuilder.DropTable(
                name: "ApplicationPreviousEmployementDetails");

            migrationBuilder.DropTable(
                name: "Borroweremploymentinformations");

            migrationBuilder.DropTable(
                name: "Borrowermonthlyincomes");

            migrationBuilder.DropTable(
                name: "Declarationborroweredemographicsinformations");

            migrationBuilder.DropTable(
                name: "Declarations");

            migrationBuilder.DropTable(
                name: "DemographicInformations");

            migrationBuilder.DropTable(
                name: "Homebuyings");

            migrationBuilder.DropTable(
                name: "LeadApplicationDetailPurchasings");

            migrationBuilder.DropTable(
                name: "LeadApplicationDetailRefinancings");

            migrationBuilder.DropTable(
                name: "LeadApplicationQuestions");

            migrationBuilder.DropTable(
                name: "LeadApplicationTypes");

            migrationBuilder.DropTable(
                name: "LeadAssetsDetails");

            migrationBuilder.DropTable(
                name: "LeadAssetsTypes");

            migrationBuilder.DropTable(
                name: "LeadEmployementDetails");

            migrationBuilder.DropTable(
                name: "LeadEmployementTypes");

            migrationBuilder.DropTable(
                name: "LeadIncomeTypes");

            migrationBuilder.DropTable(
                name: "LeadOwnerTypes");

            migrationBuilder.DropTable(
                name: "LeadQuestionAnswers");

            migrationBuilder.DropTable(
                name: "LeadRefinancingIncomeDetails");

            migrationBuilder.DropTable(
                name: "LeadTaxesTypes");

            migrationBuilder.DropTable(
                name: "LoanAndPropertyInformationGifts");

            migrationBuilder.DropTable(
                name: "LoanAndPropertyInformationOtherMortageLoans");

            migrationBuilder.DropTable(
                name: "LoanAndPropertyInformationRentalIncomes");

            migrationBuilder.DropTable(
                name: "LoanAndPropertyInformations");

            migrationBuilder.DropTable(
                name: "LoanOriginatorInformations");

            migrationBuilder.DropTable(
                name: "LoanPropertyGiftTypes");

            migrationBuilder.DropTable(
                name: "LoanPropertyOccupancies");

            migrationBuilder.DropTable(
                name: "MilitaryServices");

            migrationBuilder.DropTable(
                name: "MortageLoanOnProperties");

            migrationBuilder.DropTable(
                name: "MortageLoanTypes");

            migrationBuilder.DropTable(
                name: "Refinancehomebuyings");

            migrationBuilder.DropTable(
                name: "Sitesettings");

            migrationBuilder.DropTable(
                name: "Stockandbonds");

            migrationBuilder.DropTable(
                name: "urla_addresses");

            migrationBuilder.DropTable(
                name: "urla_agreements");

            migrationBuilder.DropTable(
                name: "urla_alternate_names");

            migrationBuilder.DropTable(
                name: "urla_contact_information");

            migrationBuilder.DropTable(
                name: "urla_declaration_questions");

            migrationBuilder.DropTable(
                name: "urla_demographic_information");

            migrationBuilder.DropTable(
                name: "urla_dempgraphic_info_by_financial_institutions");

            migrationBuilder.DropTable(
                name: "urla_employment_income");

            migrationBuilder.DropTable(
                name: "urla_financial_assets");

            migrationBuilder.DropTable(
                name: "urla_financial_liabilities");

            migrationBuilder.DropTable(
                name: "urla_financial_other_assets");

            migrationBuilder.DropTable(
                name: "urla_financial_other_liabilities");

            migrationBuilder.DropTable(
                name: "urla_income_sources");

            migrationBuilder.DropTable(
                name: "urla_loan_originator_informations");

            migrationBuilder.DropTable(
                name: "urla_loan_property_addresses");

            migrationBuilder.DropTable(
                name: "urla_loan_property_gifts_or_grants");

            migrationBuilder.DropTable(
                name: "urla_loan_property_information");

            migrationBuilder.DropTable(
                name: "urla_loan_property_other_new_mortgage_loans");

            migrationBuilder.DropTable(
                name: "urla_loan_property_rental_incomes");

            migrationBuilder.DropTable(
                name: "urla_military_services");

            migrationBuilder.DropTable(
                name: "urla_other_borrowers");

            migrationBuilder.DropTable(
                name: "urla_property_mortgage_loan");

            migrationBuilder.DropTable(
                name: "AbpDynamicEntityProperties");

            migrationBuilder.DropTable(
                name: "AbpEntityChanges");

            migrationBuilder.DropTable(
                name: "AbpRoles");

            migrationBuilder.DropTable(
                name: "AbpEditions");

            migrationBuilder.DropTable(
                name: "AbpWebhookEvents");

            migrationBuilder.DropTable(
                name: "Incomesources1");

            migrationBuilder.DropTable(
                name: "Admindisclosures");

            migrationBuilder.DropTable(
                name: "admin_loanstatus");

            migrationBuilder.DropTable(
                name: "AdminLoandetails");

            migrationBuilder.DropTable(
                name: "ApplicationAdditionalEmployementDetails");

            migrationBuilder.DropTable(
                name: "ApplicationEmployementDetails");

            migrationBuilder.DropTable(
                name: "IncomeTypes");

            migrationBuilder.DropTable(
                name: "FinancialPropertyIntendedOccupancies");

            migrationBuilder.DropTable(
                name: "FinancialPropertyStatuses");

            migrationBuilder.DropTable(
                name: "DemographicInfoSources");

            migrationBuilder.DropTable(
                name: "Manualassetentries");

            migrationBuilder.DropTable(
                name: "DeclarationQuestions");

            migrationBuilder.DropTable(
                name: "urla_employment");

            migrationBuilder.DropTable(
                name: "FinancialAccountTypes");

            migrationBuilder.DropTable(
                name: "FinancialLaibilitiesTypes");

            migrationBuilder.DropTable(
                name: "FinancialAssetsTypes");

            migrationBuilder.DropTable(
                name: "FinancialOtherLaibilitiesTypes");

            migrationBuilder.DropTable(
                name: "IncomeSources");

            migrationBuilder.DropTable(
                name: "urla_property_financial_informations");

            migrationBuilder.DropTable(
                name: "AbpDynamicProperties");

            migrationBuilder.DropTable(
                name: "AbpEntityChangeSets");

            migrationBuilder.DropTable(
                name: "AbpUsers");

            migrationBuilder.DropTable(
                name: "AdminLoanprograms");

            migrationBuilder.DropTable(
                name: "ApplicationPersonalInformations");

            migrationBuilder.DropTable(
                name: "Assettypes");

            migrationBuilder.DropTable(
                name: "Loanapplications");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "DeclarationCategories");

            migrationBuilder.DropTable(
                name: "urla_personal_information");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "CitizenshipTypes");

            migrationBuilder.DropTable(
                name: "HousingTypes");

            migrationBuilder.DropTable(
                name: "MaritialStatuses");

            migrationBuilder.DropTable(
                name: "Additionaldetails");

            migrationBuilder.DropTable(
                name: "Consentdetails");

            migrationBuilder.DropTable(
                name: "Creditauthagreements");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Loandetails");

            migrationBuilder.DropTable(
                name: "Personaldetails");

            migrationBuilder.DropTable(
                name: "urla_application");

            migrationBuilder.DropTable(
                name: "CreditTypes");

            migrationBuilder.DropTable(
                name: "CountryStates");

            migrationBuilder.DropTable(
                name: "Borrowers");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Borrowertypes");
        }
    }
}
