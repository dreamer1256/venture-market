USE master
GO
/****** Object:  Database Venture_Market ******/
CREATE DATABASE Venture_Market
GO
ALTER DATABASE Venture_Market ADD FILEGROUP USERS
GO
ALTER DATABASE Venture_Market SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC Venture_Market.dbo.sp_fulltext_database @action = 'enable'
end
GO
ALTER DATABASE Venture_Market SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE Venture_Market SET ANSI_NULLS OFF 
GO
ALTER DATABASE Venture_Market SET ANSI_PADDING OFF 
GO
ALTER DATABASE Venture_Market SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE Venture_Market SET ARITHABORT OFF 
GO
ALTER DATABASE Venture_Market SET AUTO_CLOSE ON 
GO
ALTER DATABASE Venture_Market SET AUTO_SHRINK OFF 
GO
ALTER DATABASE Venture_Market SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE Venture_Market SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE Venture_Market SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE Venture_Market SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE Venture_Market SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE Venture_Market SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE Venture_Market SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE Venture_Market SET  ENABLE_BROKER 
GO
ALTER DATABASE Venture_Market SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE Venture_Market SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE Venture_Market SET TRUSTWORTHY OFF 
GO
ALTER DATABASE Venture_Market SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE Venture_Market SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE Venture_Market SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE Venture_Market SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE Venture_Market SET RECOVERY SIMPLE 
GO
ALTER DATABASE Venture_Market SET  MULTI_USER 
GO
ALTER DATABASE Venture_Market SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE Venture_Market SET DB_CHAINING OFF 
GO
ALTER DATABASE Venture_Market SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE Venture_Market SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE Venture_Market SET DELAYED_DURABILITY = DISABLED 
GO
USE Venture_Market
GO
/****** Object:  Table dbo.Users ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE dbo.Users(
	ID int IDENTITY(1,1) NOT NULL,
	Username nvarchar(45) NOT NULL,
	Email nvarchar(45) NOT NULL,
	Password nvarchar(45) NOT NULL,
	Accaunt_Pic nvarchar(max) NULL,
	FName nvarchar(45) NOT NULL,
	LName nvarchar(45) NOT NULL,
	RegDate date NOT NULL,
	LoggedDate datetime NOT NULL,
 	CONSTRAINT PK_Users PRIMARY KEY(ID) ,
 	CONSTRAINT UQ_Users_Username UNIQUE(Username),
 	CONSTRAINT UQ_Users_Email UNIQUE(Email) 
)
GO
/****** Object:  Table dbo.Role ******/
CREATE TABLE dbo.Role (
	ID int IDENTITY(1,1) NOT NULL,
	Role_Title nvarchar(45) NOT NULL,
	Role_Description nvarchar(max) NULL,
 	CONSTRAINT PK_Role PRIMARY KEY (ID),
 	CONSTRAINT UQ_Role_RoleTitle UNIQUE(Role_Title)
)
GO

/****** Object:  Table dbo.UserRole ******/
CREATE TABLE dbo.User_Role (  
	ID int IDENTITY(1,1) NOT NULL,
	UserId int NOT NULL,  
	RoleID int NOT NULL,
	CONSTRAINT FK_UserRole_User FOREIGN KEY (UserID) REFERENCES dbo.Users(ID)
    	ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT FK_UserRole_Role FOREIGN KEY (RoleID) REFERENCES dbo.Role(ID)
    	ON UPDATE CASCADE ON DELETE CASCADE
)
GO
/****** Object:  Table dbo.AngelInvestor ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE dbo.AngelInvestor(
	ID int IDENTITY(1,1) NOT NULL,
	UserID int NOT NULL,
	Investment_Experience nvarchar(max) NULL,
	Min_Amount decimal(10, 0) NULL,
	Max_amount decimal(10, 0) NULL,
	Geo_Inerests nvarchar(45) NULL,
	Phone nvarchar(45) NULL,
	Skype nvarchar(45) NULL,
	Twitter nvarchar(45) NULL,
 	CONSTRAINT PK_AngelInvestor PRIMARY KEY(ID) ,
 	CONSTRAINT FK_AngelInvestor_Users FOREIGN KEY(UserID) REFERENCES dbo.Users(ID)
 		ON UPDATE CASCADE ON DELETE CASCADE
)
GO
/****** Object:  Table dbo.Industry_Interests_List ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE dbo.Industry_Interests_List(
	ID int IDENTITY(1,1) NOT NULL,
	Title nvarchar(45) NULL,
 	CONSTRAINT PK_Industry_Interests_List PRIMARY KEY(ID) ,
 	CONSTRAINT UQ_IndustryInterestsList_Title UNIQUE(Title)
)
GO
/****** Object:  Table dbo.Angel_Interests ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE dbo.Angel_Interests(
	InterestID int NOT NULL,
	AngelID int NOT NULL,
	CONSTRAINT FK_AngelInterests_UserProfileAngel FOREIGN KEY(AngelID) REFERENCES dbo.AngelInvestor(ID)
		ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT FK_AngelInterests_IndustryInterestsList FOREIGN KEY(InterestID) REFERENCES dbo.Industry_Interests_List(ID)
    	ON UPDATE CASCADE ON DELETE CASCADE,
)
GO
/****** Object:  Table dbo.Business_Incubator ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE dbo.Business_Incubator(
	ID int IDENTITY(1,1) NOT NULL,
	Title nvarchar(255) NOT NULL,
	Number_Of_Seats int NULL,
	Address nvarchar(255) NULL,
	Website nvarchar(63) NULL,
 	CONSTRAINT PK_Business_Incubator PRIMARY KEY(ID) , 
 	CONSTRAINT UQ_BusinesIncubator_Title UNIQUE(Title)
 )
GO
/****** Object:  Table dbo.Development_Stage ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE dbo.Development_Stage(
	ID int IDENTITY(1,1) NOT NULL,
	Stage nvarchar(45) NOT NULL,
 	CONSTRAINT PK_Development_Stage PRIMARY KEY(ID)  
)
GO

/****** Object:  Table dbo.Startup ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE dbo.Startup(
	ID int IDENTITY(1,1) NOT NULL,
	Title nvarchar(45) NOT NULL,
	Description nvarchar(max) NULL,
	Business_Model nvarchar(255) NULL,
	Competitors int NULL,
	Marketing_Strategy nvarchar(255) NULL,
	Total_Investment decimal(10, 0) NULL,
	Website nvarchar(63) NULL,
	Foundation_Date date NULL,
	Twitter nvarchar(63) NULL,
	CEO nvarchar(45) NULL,
	IncubatorID int NULL,
	Development_StageID int NOT NULL,
 	CONSTRAINT PK_Startup PRIMARY KEY(ID) ,
 	CONSTRAINT FK_Startup_BusinessIncubator FOREIGN KEY(Development_StageID) REFERENCES dbo.Business_Incubator(ID)
 		ON UPDATE CASCADE ON DELETE CASCADE,
 	CONSTRAINT FK_Startup_DevelopmentStage FOREIGN KEY(IncubatorID) REFERENCES dbo.Development_Stage(ID)
 		ON UPDATE CASCADE ON DELETE SET NULL,
 	CONSTRAINT FK_Startup_Startup FOREIGN KEY(Competitors) REFERENCES dbo.Startup(ID)
 		ON UPDATE NO ACTION ON DELETE  NO ACTION,
 	CONSTRAINT UQ_Startap_Title UNIQUE (Title) 
) 
GO
/****** Object:  Table dbo.Investment_Company ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE dbo.Investment_Company(
	ID int IDENTITY(1,1) NOT NULL,
	Title nvarchar(255) NOT NULL,
	Description nvarchar(max) NULL,
	Website nvarchar(63) NULL,
	Foundation_Date date NULL,
	Office_Address nvarchar(255) NULL,
	CEO nvarchar(255) NULL,
 	CONSTRAINT PK_Investment_Company PRIMARY KEY(ID) ,
 	CONSTRAINT UQ_InvestmentCompany_Title UNIQUE(Title) 
)
GO
/****** Object:  Table dbo.Investment_Manager ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE dbo.Investment_Manager(
	ID int IDENTITY(1,1) NOT NULL,
	Investment_CompanyID int NULL,
	UserID int NOT NULL,
	Geo_Inerests nvarchar(45) NULL,
 	CONSTRAINT PK_Investment_Manager PRIMARY KEY(ID) ,
 	CONSTRAINT FK_InvestmentManager_Users FOREIGN KEY(UserID) REFERENCES dbo.Users(ID)
 		ON UPDATE CASCADE ON DELETE CASCADE,
 	CONSTRAINT FK_InvestmentManager_InvestmentCompany FOREIGN KEY(Investment_CompanyID) REFERENCES dbo.Investment_Company(ID)
 		ON UPDATE CASCADE ON DELETE SET NULL, 
)
GO
/****** Object:  Table dbo.Application ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE dbo.Application(
	ID int IDENTITY(1,1) NOT NULL,
	ManagerID int NULL,
	StartupID int NOT NULL,
	State nvarchar(45) NULL,
	Application_Round int NOT NULL,
	CreationDate datetime NOT NULL,
 	CONSTRAINT PK_Application PRIMARY KEY(ID),
 	CONSTRAINT FK_Application_InvestmentManager FOREIGN KEY(ManagerID) REFERENCES dbo.Investment_Manager(ID)
 		ON UPDATE CASCADE ON DELETE SET NULL,
 	CONSTRAINT FK_Application_Startup FOREIGN KEY(StartupID) REFERENCES dbo.Startup(ID)
 		ON UPDATE CASCADE ON DELETE CASCADE
)
GO
/****** Object:  Table dbo.Round_Of_Funding ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE dbo.Round_Of_Funding(
	ID int NOT NULL,
	StartupID int NOT NULL,
	Title nvarchar(45) NOT NULL,
	Total_Investment decimal(10, 0) NULL,
 	CONSTRAINT PK_Round_Of_Funding PRIMARY KEY(ID) ,
 	CONSTRAINT FK_RoundOfFunding_Startup FOREIGN KEY(StartupID) REFERENCES dbo.Startup(ID)
 		ON UPDATE CASCADE ON DELETE CASCADE
)
GO
/****** Object:  Table dbo.Round_Investor ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE dbo.Round_Investor(
	CompanyID int NULL,
	RoundID int NOT NULL,
	AngelID int NULL,
 	CONSTRAINT PK_Round_Investor PRIMARY KEY(RoundID) ,
 	CONSTRAINT FK_RoundInvestor_InvestmentCompany FOREIGN KEY(CompanyID) REFERENCES dbo.Investment_Company(ID)
 		ON UPDATE CASCADE ON DELETE SET NULL,
 	CONSTRAINT FK_RoundInvestor_RoundOfFunding FOREIGN KEY(RoundID) REFERENCES dbo.Round_Of_Funding(ID)
 		ON UPDATE CASCADE ON DELETE CASCADE,
 	CONSTRAINT FK_RoundInvestor_UserProfileAngel FOREIGN KEY(AngelID) REFERENCES dbo.AngelInvestor(ID)
 		ON UPDATE CASCADE ON DELETE SET NULL 
)
GO
/****** Object:  Table dbo.Startup_Members ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE dbo.Startup_Members(
	ID int IDENTITY(1,1) NOT NULL,
	StartupID int NOT NULL,
	UserID int NOT NULL,
	Address nvarchar(45) NULL,
	Is_CEO bit NOT NULL CONSTRAINT DF_StarupMembers_IsCEO DEFAULT((0)),
	Phone nvarchar(45) NULL,
	Skype nvarchar(45) NULL,
	Twitter nvarchar(45) NULL,
	About nvarchar(max) NULL,
 	CONSTRAINT PK_Startup_Members PRIMARY KEY(ID) ,
 	CONSTRAINT FK_StartupMembers_Startup FOREIGN KEY(StartupID) REFERENCES dbo.Startup(ID)
 		ON UPDATE CASCADE ON DELETE CASCADE,
 	CONSTRAINT FK_StartupMembers_Users FOREIGN KEY(UserID) REFERENCES dbo.Users(ID)
 		ON UPDATE CASCADE ON DELETE CASCADE 
)
GO

ALTER DATABASE Venture_Market SET  READ_WRITE 
GO
