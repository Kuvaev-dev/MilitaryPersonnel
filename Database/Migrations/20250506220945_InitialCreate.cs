using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterTraits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TraitName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Characte__3214EC07D4C6FF8D", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CivilProfessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessionName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CivilPro__3214EC077F9C80FE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DischargeLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicemanId = table.Column<int>(type: "int", nullable: true),
                    DischargeDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DischargeReason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LogDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Discharg__3214EC078EB882C8", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Document__3214EC07E89C3F9A", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Document__3214EC07CD20F36A", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationLevel = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Institution = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Specialty = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GraduationYear = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Educatio__3214EC07B1A6D7E0", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FitnessCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FitnessC__3214EC07EB94EAC7", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MilitarySpecialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialtyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Military__3214EC07CAA81010", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MilitaryUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Military__3214EC07012DC185", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MobilizationLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreationDate = table.Column<DateOnly>(type: "date", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Mobiliza__3214EC070B4DC6E3", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Position__3214EC07AC1015C1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RankName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ranks__3214EC0766BDA39B", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceAttitudes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttitudeDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ServiceA__3214EC07DA82ECE5", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ServiceF__3214EC07E60223CC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ServiceS__3214EC073F7CFCAD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subdivisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubdivisionName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MilitaryUnitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Subdivis__3214EC07374AB499", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Subdivisi__Milit__267ABA7A",
                        column: x => x.MilitaryUnitId,
                        principalTable: "MilitaryUnits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Servicemen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CivilProfessionId = table.Column<int>(type: "int", nullable: true),
                    MilitarySpecialtyId = table.Column<int>(type: "int", nullable: true),
                    EducationId = table.Column<int>(type: "int", nullable: true),
                    PositionId = table.Column<int>(type: "int", nullable: true),
                    SubdivisionId = table.Column<int>(type: "int", nullable: true),
                    ServiceFormId = table.Column<int>(type: "int", nullable: true),
                    CharacterTraitId = table.Column<int>(type: "int", nullable: true),
                    ServiceAttitudeId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ServiceStatusId = table.Column<int>(type: "int", nullable: true),
                    FitnessCategoryId = table.Column<int>(type: "int", nullable: true),
                    IsOfficer = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Servicem__3214EC076662FD23", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Serviceme__Chara__4222D4EF",
                        column: x => x.CharacterTraitId,
                        principalTable: "CharacterTraits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Serviceme__Civil__3C69FB99",
                        column: x => x.CivilProfessionId,
                        principalTable: "CivilProfessions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Serviceme__Educa__3E52440B",
                        column: x => x.EducationId,
                        principalTable: "Educations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Serviceme__Fitne__44FF419A",
                        column: x => x.FitnessCategoryId,
                        principalTable: "FitnessCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Serviceme__Milit__3D5E1FD2",
                        column: x => x.MilitarySpecialtyId,
                        principalTable: "MilitarySpecialties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Serviceme__Posit__3F466844",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Serviceme__Servi__412EB0B6",
                        column: x => x.ServiceFormId,
                        principalTable: "ServiceForms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Serviceme__Servi__4316F928",
                        column: x => x.ServiceAttitudeId,
                        principalTable: "ServiceAttitudes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Serviceme__Servi__440B1D61",
                        column: x => x.ServiceStatusId,
                        principalTable: "ServiceStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Serviceme__Subdi__403A8C7D",
                        column: x => x.SubdivisionId,
                        principalTable: "Subdivisions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Awards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicemanId = table.Column<int>(type: "int", nullable: true),
                    AwardName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AwardDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Awards__3214EC07881247D0", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Awards__Servicem__59FA5E80",
                        column: x => x.ServicemanId,
                        principalTable: "Servicemen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContactInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicemanId = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ContactI__3214EC07149FCB2F", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ContactIn__Servi__4CA06362",
                        column: x => x.ServicemanId,
                        principalTable: "Servicemen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Discharges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicemanId = table.Column<int>(type: "int", nullable: true),
                    DischargeDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DischargeReason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Discharg__3214EC0705A57DC8", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Discharge__Servi__778AC167",
                        column: x => x.ServicemanId,
                        principalTable: "Servicemen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DocumentFlow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    ServicemanId = table.Column<int>(type: "int", nullable: true),
                    MilitaryUnitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Document__3214EC07E1B26C88", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentFlow_MilitaryUnits",
                        column: x => x.MilitaryUnitId,
                        principalTable: "MilitaryUnits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentFlow_Servicemen",
                        column: x => x.ServicemanId,
                        principalTable: "Servicemen",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__DocumentF__Creat__08B54D69",
                        column: x => x.CreatedById,
                        principalTable: "Servicemen",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__DocumentF__Docum__07C12930",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__DocumentF__Statu__09A971A2",
                        column: x => x.StatusId,
                        principalTable: "DocumentStatuses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicemanId = table.Column<int>(type: "int", nullable: true),
                    DocumentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DocumentNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IssueDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Document__3214EC0771F975FB", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Documents__Servi__4F7CD00D",
                        column: x => x.ServicemanId,
                        principalTable: "Servicemen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FamilyMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicemanId = table.Column<int>(type: "int", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Relationship = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FamilyMe__3214EC07AB47F928", x => x.Id);
                    table.ForeignKey(
                        name: "FK__FamilyMem__Servi__5FB337D6",
                        column: x => x.ServicemanId,
                        principalTable: "Servicemen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LanguageSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicemanId = table.Column<int>(type: "int", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProficiencyLevel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Language__3214EC07AF825A04", x => x.Id);
                    table.ForeignKey(
                        name: "FK__LanguageS__Servi__68487DD7",
                        column: x => x.ServicemanId,
                        principalTable: "Servicemen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicemanId = table.Column<int>(type: "int", nullable: true),
                    MedicalCondition = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RecordDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MedicalR__3214EC0702719F01", x => x.Id);
                    table.ForeignKey(
                        name: "FK__MedicalRe__Servi__571DF1D5",
                        column: x => x.ServicemanId,
                        principalTable: "Servicemen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MobilizationListEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MobilizationListId = table.Column<int>(type: "int", nullable: true),
                    ServicemanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Mobiliza__3214EC07B7B39F81", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Mobilizat__Mobil__70DDC3D8",
                        column: x => x.MobilizationListId,
                        principalTable: "MobilizationLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Mobilizat__Servi__71D1E811",
                        column: x => x.ServicemanId,
                        principalTable: "Servicemen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OperationalReadiness",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicemanId = table.Column<int>(type: "int", nullable: true),
                    ReadinessStatus = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AssessmentDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Operatio__3214EC075219E08E", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Operation__Servi__6B24EA82",
                        column: x => x.ServicemanId,
                        principalTable: "Servicemen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PsychologicalProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicemanId = table.Column<int>(type: "int", nullable: true),
                    ProfileDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AssessmentDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Psycholo__3214EC07689799C3", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Psycholog__Servi__628FA481",
                        column: x => x.ServicemanId,
                        principalTable: "Servicemen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Punishments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicemanId = table.Column<int>(type: "int", nullable: true),
                    PunishmentDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PunishmentDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Punishme__3214EC07B1C352BD", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Punishmen__Servi__5CD6CB2B",
                        column: x => x.ServicemanId,
                        principalTable: "Servicemen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RankAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicemanId = table.Column<int>(type: "int", nullable: true),
                    RankId = table.Column<int>(type: "int", nullable: true),
                    AssignmentDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RankAssi__3214EC072558147C", x => x.Id);
                    table.ForeignKey(
                        name: "FK__RankAssig__RankI__49C3F6B7",
                        column: x => x.RankId,
                        principalTable: "Ranks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__RankAssig__Servi__48CFD27E",
                        column: x => x.ServicemanId,
                        principalTable: "Servicemen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Recruitments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicemanId = table.Column<int>(type: "int", nullable: true),
                    RecruitmentDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Recruitm__3214EC07D3EAAC26", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Recruitme__Servi__74AE54BC",
                        column: x => x.ServicemanId,
                        principalTable: "Servicemen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicemanId = table.Column<int>(type: "int", nullable: true),
                    PositionId = table.Column<int>(type: "int", nullable: true),
                    SubdivisionId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ServiceH__3214EC07FF563193", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ServiceHi__Posit__534D60F1",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__ServiceHi__Servi__52593CB8",
                        column: x => x.ServicemanId,
                        principalTable: "Servicemen",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__ServiceHi__Subdi__5441852A",
                        column: x => x.SubdivisionId,
                        principalTable: "Subdivisions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicemanId = table.Column<int>(type: "int", nullable: true),
                    TrainingName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Training__3214EC071F9F2F71", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Trainings__Servi__656C112C",
                        column: x => x.ServicemanId,
                        principalTable: "Servicemen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DocumentAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    AssigneeId = table.Column<int>(type: "int", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Document__3214EC073023A88A", x => x.Id);
                    table.ForeignKey(
                        name: "FK__DocumentA__Assig__0F624AF8",
                        column: x => x.AssigneeId,
                        principalTable: "Servicemen",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__DocumentA__Docum__0E6E26BF",
                        column: x => x.DocumentId,
                        principalTable: "DocumentFlow",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Resolutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    ResolutionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResolutionDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Resoluti__3214EC075C445D1B", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Resolutio__Autho__14270015",
                        column: x => x.AuthorId,
                        principalTable: "Servicemen",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Resolutio__Docum__1332DBDC",
                        column: x => x.DocumentId,
                        principalTable: "DocumentFlow",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_ServicemanId",
                table: "Awards",
                column: "ServicemanId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfo_ServicemanId",
                table: "ContactInfo",
                column: "ServicemanId");

            migrationBuilder.CreateIndex(
                name: "IX_Discharges_ServicemanId",
                table: "Discharges",
                column: "ServicemanId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentAssignments_AssigneeId",
                table: "DocumentAssignments",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentAssignments_DocumentId",
                table: "DocumentAssignments",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentFlow_CreatedById",
                table: "DocumentFlow",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentFlow_DocumentTypeId",
                table: "DocumentFlow",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentFlow_MilitaryUnitId",
                table: "DocumentFlow",
                column: "MilitaryUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentFlow_ServicemanId",
                table: "DocumentFlow",
                column: "ServicemanId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentFlow_StatusId",
                table: "DocumentFlow",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ServicemanId",
                table: "Documents",
                column: "ServicemanId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_ServicemanId",
                table: "FamilyMembers",
                column: "ServicemanId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageSkills_ServicemanId",
                table: "LanguageSkills",
                column: "ServicemanId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_ServicemanId",
                table: "MedicalRecords",
                column: "ServicemanId");

            migrationBuilder.CreateIndex(
                name: "IX_MobilizationListEntries_MobilizationListId",
                table: "MobilizationListEntries",
                column: "MobilizationListId");

            migrationBuilder.CreateIndex(
                name: "IX_MobilizationListEntries_ServicemanId",
                table: "MobilizationListEntries",
                column: "ServicemanId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationalReadiness_ServicemanId",
                table: "OperationalReadiness",
                column: "ServicemanId");

            migrationBuilder.CreateIndex(
                name: "IX_PsychologicalProfiles_ServicemanId",
                table: "PsychologicalProfiles",
                column: "ServicemanId");

            migrationBuilder.CreateIndex(
                name: "IX_Punishments_ServicemanId",
                table: "Punishments",
                column: "ServicemanId");

            migrationBuilder.CreateIndex(
                name: "IX_RankAssignments_RankId",
                table: "RankAssignments",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_RankAssignments_ServicemanId",
                table: "RankAssignments",
                column: "ServicemanId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitments_ServicemanId",
                table: "Recruitments",
                column: "ServicemanId");

            migrationBuilder.CreateIndex(
                name: "IX_Resolutions_AuthorId",
                table: "Resolutions",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Resolutions_DocumentId",
                table: "Resolutions",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistory_PositionId",
                table: "ServiceHistory",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistory_ServicemanId",
                table: "ServiceHistory",
                column: "ServicemanId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistory_SubdivisionId",
                table: "ServiceHistory",
                column: "SubdivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicemen_CharacterTraitId",
                table: "Servicemen",
                column: "CharacterTraitId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicemen_CivilProfessionId",
                table: "Servicemen",
                column: "CivilProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicemen_EducationId",
                table: "Servicemen",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicemen_FitnessCategoryId",
                table: "Servicemen",
                column: "FitnessCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicemen_MilitarySpecialtyId",
                table: "Servicemen",
                column: "MilitarySpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicemen_PositionId",
                table: "Servicemen",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicemen_ServiceAttitudeId",
                table: "Servicemen",
                column: "ServiceAttitudeId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicemen_ServiceFormId",
                table: "Servicemen",
                column: "ServiceFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicemen_ServiceStatusId",
                table: "Servicemen",
                column: "ServiceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicemen_SubdivisionId",
                table: "Servicemen",
                column: "SubdivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Subdivisions_MilitaryUnitId",
                table: "Subdivisions",
                column: "MilitaryUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_ServicemanId",
                table: "Trainings",
                column: "ServicemanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Awards");

            migrationBuilder.DropTable(
                name: "ContactInfo");

            migrationBuilder.DropTable(
                name: "DischargeLog");

            migrationBuilder.DropTable(
                name: "Discharges");

            migrationBuilder.DropTable(
                name: "DocumentAssignments");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "FamilyMembers");

            migrationBuilder.DropTable(
                name: "LanguageSkills");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "MobilizationListEntries");

            migrationBuilder.DropTable(
                name: "OperationalReadiness");

            migrationBuilder.DropTable(
                name: "PsychologicalProfiles");

            migrationBuilder.DropTable(
                name: "Punishments");

            migrationBuilder.DropTable(
                name: "RankAssignments");

            migrationBuilder.DropTable(
                name: "Recruitments");

            migrationBuilder.DropTable(
                name: "Resolutions");

            migrationBuilder.DropTable(
                name: "ServiceHistory");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MobilizationLists");

            migrationBuilder.DropTable(
                name: "Ranks");

            migrationBuilder.DropTable(
                name: "DocumentFlow");

            migrationBuilder.DropTable(
                name: "Servicemen");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.DropTable(
                name: "DocumentStatuses");

            migrationBuilder.DropTable(
                name: "CharacterTraits");

            migrationBuilder.DropTable(
                name: "CivilProfessions");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "FitnessCategories");

            migrationBuilder.DropTable(
                name: "MilitarySpecialties");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "ServiceForms");

            migrationBuilder.DropTable(
                name: "ServiceAttitudes");

            migrationBuilder.DropTable(
                name: "ServiceStatuses");

            migrationBuilder.DropTable(
                name: "Subdivisions");

            migrationBuilder.DropTable(
                name: "MilitaryUnits");
        }
    }
}
