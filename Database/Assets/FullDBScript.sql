USE [master]
GO
/****** Object:  Database [MilitaryPersonnelAIS]    Script Date: Вт 29.04.25 11:18:26 ******/
CREATE DATABASE [MilitaryPersonnelAIS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MilitaryPersonnelAIS', FILENAME = N'D:\Programs\SQL Server 2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\MilitaryPersonnelAIS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MilitaryPersonnelAIS_log', FILENAME = N'D:\Programs\SQL Server 2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\MilitaryPersonnelAIS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MilitaryPersonnelAIS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET ARITHABORT OFF 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET  MULTI_USER 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET QUERY_STORE = OFF
GO
USE [MilitaryPersonnelAIS]
GO
/****** Object:  Table [dbo].[MilitaryUnits]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MilitaryUnits](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UnitName] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subdivisions]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subdivisions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubdivisionName] [nvarchar](255) NOT NULL,
	[MilitaryUnitId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceForms]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceForms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FormName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CivilProfessions]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CivilProfessions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfessionName] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MilitarySpecialties]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MilitarySpecialties](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SpecialtyName] [nvarchar](255) NOT NULL,
	[Code] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Educations]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Educations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EducationLevel] [nvarchar](255) NOT NULL,
	[Institution] [nvarchar](255) NULL,
	[Specialty] [nvarchar](255) NULL,
	[GraduationYear] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ranks]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ranks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RankName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Positions]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PositionName] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicemen]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicemen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[MiddleName] [nvarchar](100) NULL,
	[BirthDate] [date] NOT NULL,
	[CivilProfessionId] [int] NULL,
	[MilitarySpecialtyId] [int] NULL,
	[EducationId] [int] NULL,
	[PositionId] [int] NULL,
	[SubdivisionId] [int] NULL,
	[ServiceFormId] [int] NULL,
	[CharacterTraitId] [int] NULL,
	[ServiceAttitudeId] [int] NULL,
	[Address] [nvarchar](255) NULL,
	[Phone] [nvarchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[ServiceStatusId] [int] NULL,
	[FitnessCategoryId] [int] NULL,
	[IsOfficer] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RankAssignments]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RankAssignments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServicemanId] [int] NULL,
	[RankId] [int] NULL,
	[AssignmentDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_ServicemenDetails]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_ServicemenDetails] AS
SELECT 
    s.Id AS ServicemanId,
    s.FirstName,
    s.LastName,
    s.MiddleName,
    s.BirthDate,
    cp.ProfessionName AS CivilProfession,
    ms.SpecialtyName AS MilitarySpecialty,
    e.EducationLevel,
    r.RankName,
    p.PositionName,
    sf.FormName AS ServiceForm,
    sub.SubdivisionName,
    mu.UnitName AS MilitaryUnit
FROM Servicemen s
LEFT JOIN CivilProfessions cp ON s.CivilProfessionId = cp.Id
LEFT JOIN MilitarySpecialties ms ON s.MilitarySpecialtyId = ms.Id
LEFT JOIN Educations e ON s.EducationId = e.Id
LEFT JOIN RankAssignments ra ON ra.ServicemanId = s.Id
LEFT JOIN Ranks r ON ra.RankId = r.Id
LEFT JOIN Positions p ON s.PositionId = p.Id
LEFT JOIN ServiceForms sf ON s.ServiceFormId = sf.Id
LEFT JOIN Subdivisions sub ON s.SubdivisionId = sub.Id
LEFT JOIN MilitaryUnits mu ON sub.MilitaryUnitId = mu.Id;
GO
/****** Object:  Table [dbo].[Awards]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Awards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServicemanId] [int] NULL,
	[AwardName] [nvarchar](255) NULL,
	[AwardDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CharacterTraits]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CharacterTraits](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TraitName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactInfo]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServicemanId] [int] NULL,
	[Phone] [nvarchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[Address] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DischargeLog]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DischargeLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServicemanId] [int] NULL,
	[DischargeDate] [date] NULL,
	[DischargeReason] [nvarchar](255) NULL,
	[LogDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discharges]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discharges](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServicemanId] [int] NULL,
	[DischargeDate] [date] NOT NULL,
	[DischargeReason] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentAssignments]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentAssignments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocumentId] [int] NOT NULL,
	[AssigneeId] [int] NOT NULL,
	[AssignedDate] [datetime] NULL,
	[IsCompleted] [bit] NULL,
	[CompletedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentFlow]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentFlow](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[DocumentTypeId] [int] NOT NULL,
	[CreatedById] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[StatusId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documents]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServicemanId] [int] NULL,
	[DocumentType] [nvarchar](100) NULL,
	[DocumentNumber] [nvarchar](50) NULL,
	[IssueDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentStatuses]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentStatuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentTypes]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FamilyMembers]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamilyMembers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServicemanId] [int] NULL,
	[FullName] [nvarchar](255) NULL,
	[Relationship] [nvarchar](100) NULL,
	[BirthDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FitnessCategories]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FitnessCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LanguageSkills]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LanguageSkills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServicemanId] [int] NULL,
	[Language] [nvarchar](100) NULL,
	[ProficiencyLevel] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicalRecords]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalRecords](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServicemanId] [int] NULL,
	[MedicalCondition] [nvarchar](255) NULL,
	[RecordDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MobilizationListEntries]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MobilizationListEntries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MobilizationListId] [int] NULL,
	[ServicemanId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MobilizationLists]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MobilizationLists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ListName] [nvarchar](255) NOT NULL,
	[CreationDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationalReadiness]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationalReadiness](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServicemanId] [int] NULL,
	[ReadinessStatus] [nvarchar](255) NULL,
	[AssessmentDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PsychologicalProfiles]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PsychologicalProfiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServicemanId] [int] NULL,
	[ProfileDescription] [nvarchar](1000) NULL,
	[AssessmentDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Punishments]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Punishments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServicemanId] [int] NULL,
	[PunishmentDescription] [nvarchar](255) NULL,
	[PunishmentDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recruitments]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recruitments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServicemanId] [int] NULL,
	[RecruitmentDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resolutions]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resolutions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocumentId] [int] NOT NULL,
	[AuthorId] [int] NOT NULL,
	[ResolutionText] [nvarchar](max) NOT NULL,
	[ResolutionDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceAttitudes]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceAttitudes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AttitudeDescription] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceHistory]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServicemanId] [int] NULL,
	[PositionId] [int] NULL,
	[SubdivisionId] [int] NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceStatuses]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceStatuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trainings]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServicemanId] [int] NULL,
	[TrainingName] [nvarchar](255) NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DischargeLog] ADD  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[DocumentAssignments] ADD  DEFAULT (getdate()) FOR [AssignedDate]
GO
ALTER TABLE [dbo].[DocumentAssignments] ADD  DEFAULT ((0)) FOR [IsCompleted]
GO
ALTER TABLE [dbo].[DocumentFlow] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[MobilizationLists] ADD  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[Resolutions] ADD  DEFAULT (getdate()) FOR [ResolutionDate]
GO
ALTER TABLE [dbo].[Servicemen] ADD  DEFAULT ((0)) FOR [IsOfficer]
GO
ALTER TABLE [dbo].[Awards]  WITH CHECK ADD FOREIGN KEY([ServicemanId])
REFERENCES [dbo].[Servicemen] ([Id])
GO
ALTER TABLE [dbo].[ContactInfo]  WITH CHECK ADD FOREIGN KEY([ServicemanId])
REFERENCES [dbo].[Servicemen] ([Id])
GO
ALTER TABLE [dbo].[Discharges]  WITH CHECK ADD FOREIGN KEY([ServicemanId])
REFERENCES [dbo].[Servicemen] ([Id])
GO
ALTER TABLE [dbo].[DocumentAssignments]  WITH CHECK ADD FOREIGN KEY([AssigneeId])
REFERENCES [dbo].[Servicemen] ([Id])
GO
ALTER TABLE [dbo].[DocumentAssignments]  WITH CHECK ADD FOREIGN KEY([DocumentId])
REFERENCES [dbo].[DocumentFlow] ([Id])
GO
ALTER TABLE [dbo].[DocumentFlow]  WITH CHECK ADD FOREIGN KEY([CreatedById])
REFERENCES [dbo].[Servicemen] ([Id])
GO
ALTER TABLE [dbo].[DocumentFlow]  WITH CHECK ADD FOREIGN KEY([DocumentTypeId])
REFERENCES [dbo].[DocumentTypes] ([Id])
GO
ALTER TABLE [dbo].[DocumentFlow]  WITH CHECK ADD FOREIGN KEY([StatusId])
REFERENCES [dbo].[DocumentStatuses] ([Id])
GO
ALTER TABLE [dbo].[Documents]  WITH CHECK ADD FOREIGN KEY([ServicemanId])
REFERENCES [dbo].[Servicemen] ([Id])
GO
ALTER TABLE [dbo].[FamilyMembers]  WITH CHECK ADD FOREIGN KEY([ServicemanId])
REFERENCES [dbo].[Servicemen] ([Id])
GO
ALTER TABLE [dbo].[LanguageSkills]  WITH CHECK ADD FOREIGN KEY([ServicemanId])
REFERENCES [dbo].[Servicemen] ([Id])
GO
ALTER TABLE [dbo].[MedicalRecords]  WITH CHECK ADD FOREIGN KEY([ServicemanId])
REFERENCES [dbo].[Servicemen] ([Id])
GO
ALTER TABLE [dbo].[MobilizationListEntries]  WITH CHECK ADD FOREIGN KEY([MobilizationListId])
REFERENCES [dbo].[MobilizationLists] ([Id])
GO
ALTER TABLE [dbo].[MobilizationListEntries]  WITH CHECK ADD FOREIGN KEY([ServicemanId])
REFERENCES [dbo].[Servicemen] ([Id])
GO
ALTER TABLE [dbo].[OperationalReadiness]  WITH CHECK ADD FOREIGN KEY([ServicemanId])
REFERENCES [dbo].[Servicemen] ([Id])
GO
ALTER TABLE [dbo].[PsychologicalProfiles]  WITH CHECK ADD FOREIGN KEY([ServicemanId])
REFERENCES [dbo].[Servicemen] ([Id])
GO
ALTER TABLE [dbo].[Punishments]  WITH CHECK ADD FOREIGN KEY([ServicemanId])
REFERENCES [dbo].[Servicemen] ([Id])
GO
ALTER TABLE [dbo].[RankAssignments]  WITH CHECK ADD FOREIGN KEY([RankId])
REFERENCES [dbo].[Ranks] ([Id])
GO
ALTER TABLE [dbo].[RankAssignments]  WITH CHECK ADD FOREIGN KEY([ServicemanId])
REFERENCES [dbo].[Servicemen] ([Id])
GO
ALTER TABLE [dbo].[Recruitments]  WITH CHECK ADD FOREIGN KEY([ServicemanId])
REFERENCES [dbo].[Servicemen] ([Id])
GO
ALTER TABLE [dbo].[Resolutions]  WITH CHECK ADD FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Servicemen] ([Id])
GO
ALTER TABLE [dbo].[Resolutions]  WITH CHECK ADD FOREIGN KEY([DocumentId])
REFERENCES [dbo].[DocumentFlow] ([Id])
GO
ALTER TABLE [dbo].[ServiceHistory]  WITH CHECK ADD FOREIGN KEY([PositionId])
REFERENCES [dbo].[Positions] ([Id])
GO
ALTER TABLE [dbo].[ServiceHistory]  WITH CHECK ADD FOREIGN KEY([ServicemanId])
REFERENCES [dbo].[Servicemen] ([Id])
GO
ALTER TABLE [dbo].[ServiceHistory]  WITH CHECK ADD FOREIGN KEY([SubdivisionId])
REFERENCES [dbo].[Subdivisions] ([Id])
GO
ALTER TABLE [dbo].[Servicemen]  WITH CHECK ADD FOREIGN KEY([CharacterTraitId])
REFERENCES [dbo].[CharacterTraits] ([Id])
GO
ALTER TABLE [dbo].[Servicemen]  WITH CHECK ADD FOREIGN KEY([CivilProfessionId])
REFERENCES [dbo].[CivilProfessions] ([Id])
GO
ALTER TABLE [dbo].[Servicemen]  WITH CHECK ADD FOREIGN KEY([EducationId])
REFERENCES [dbo].[Educations] ([Id])
GO
ALTER TABLE [dbo].[Servicemen]  WITH CHECK ADD FOREIGN KEY([FitnessCategoryId])
REFERENCES [dbo].[FitnessCategories] ([Id])
GO
ALTER TABLE [dbo].[Servicemen]  WITH CHECK ADD FOREIGN KEY([MilitarySpecialtyId])
REFERENCES [dbo].[MilitarySpecialties] ([Id])
GO
ALTER TABLE [dbo].[Servicemen]  WITH CHECK ADD FOREIGN KEY([PositionId])
REFERENCES [dbo].[Positions] ([Id])
GO
ALTER TABLE [dbo].[Servicemen]  WITH CHECK ADD FOREIGN KEY([ServiceFormId])
REFERENCES [dbo].[ServiceForms] ([Id])
GO
ALTER TABLE [dbo].[Servicemen]  WITH CHECK ADD FOREIGN KEY([ServiceAttitudeId])
REFERENCES [dbo].[ServiceAttitudes] ([Id])
GO
ALTER TABLE [dbo].[Servicemen]  WITH CHECK ADD FOREIGN KEY([ServiceStatusId])
REFERENCES [dbo].[ServiceStatuses] ([Id])
GO
ALTER TABLE [dbo].[Servicemen]  WITH CHECK ADD FOREIGN KEY([SubdivisionId])
REFERENCES [dbo].[Subdivisions] ([Id])
GO
ALTER TABLE [dbo].[Subdivisions]  WITH CHECK ADD FOREIGN KEY([MilitaryUnitId])
REFERENCES [dbo].[MilitaryUnits] ([Id])
GO
ALTER TABLE [dbo].[Trainings]  WITH CHECK ADD FOREIGN KEY([ServicemanId])
REFERENCES [dbo].[Servicemen] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[AddServiceman]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddServiceman]
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @MiddleName NVARCHAR(50),
    @BirthDate DATE,
    @CivilProfessionId INT,
    @MilitarySpecialtyId INT,
    @EducationId INT,
    @PositionId INT,
    @SubdivisionId INT,
    @ServiceFormId INT,
    @CharacterTraitId INT,
    @ServiceAttitudeId INT,
    @Address NVARCHAR(255),
    @Phone NVARCHAR(20),
    @Email NVARCHAR(100),
    @ServiceStatusId INT,
    @FitnessCategoryId INT,
    @IsOfficer BIT
AS
BEGIN
    INSERT INTO Servicemen (FirstName, LastName, MiddleName, BirthDate, CivilProfessionId, MilitarySpecialtyId, EducationId, PositionId, SubdivisionId, ServiceFormId, CharacterTraitId, ServiceAttitudeId, Address, Phone, Email, ServiceStatusId, FitnessCategoryId, IsOfficer)
    VALUES (@FirstName, @LastName, @MiddleName, @BirthDate, @CivilProfessionId, @MilitarySpecialtyId, @EducationId, @PositionId, @SubdivisionId, @ServiceFormId, @CharacterTraitId, @ServiceAttitudeId, @Address, @Phone, @Email, @ServiceStatusId, @FitnessCategoryId, @IsOfficer);
END;
GO
/****** Object:  StoredProcedure [dbo].[GetMobilizationListBySpecialty]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMobilizationListBySpecialty]
    @MilitarySpecialtyId INT
AS
BEGIN
    SELECT 
        s.Id,
        s.FirstName,
        s.LastName,
        ms.SpecialtyName,
        sub.SubdivisionName,
        mu.UnitName
    FROM Servicemen s
    INNER JOIN MilitarySpecialties ms ON s.MilitarySpecialtyId = ms.Id
    INNER JOIN Subdivisions sub ON s.SubdivisionId = sub.Id
    INNER JOIN MilitaryUnits mu ON sub.MilitaryUnitId = mu.Id
    WHERE s.MilitarySpecialtyId = @MilitarySpecialtyId;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetOfficersBySubdivision]    Script Date: Вт 29.04.25 11:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOfficersBySubdivision]
    @SubdivisionId INT
AS
BEGIN
    SELECT 
        s.Id,
        s.FirstName,
        s.LastName,
        r.RankName,
        p.PositionName
    FROM Servicemen s
    LEFT JOIN RankAssignments ra ON s.Id = ra.ServicemanId
    LEFT JOIN Ranks r ON ra.RankId = r.Id
    LEFT JOIN Positions p ON s.PositionId = p.Id
    WHERE s.SubdivisionId = @SubdivisionId AND s.IsOfficer = 1;
END;
GO
USE [master]
GO
ALTER DATABASE [MilitaryPersonnelAIS] SET  READ_WRITE 
GO
