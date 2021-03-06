USE [master]
GO
/****** Object:  Database [BoatRental]    Script Date: 2018-03-25 19:24:05 ******/
CREATE DATABASE [BoatRental]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BoatRental', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BoatRental.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BoatRental_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BoatRental_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BoatRental] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BoatRental].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BoatRental] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BoatRental] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BoatRental] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BoatRental] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BoatRental] SET ARITHABORT OFF 
GO
ALTER DATABASE [BoatRental] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BoatRental] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BoatRental] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BoatRental] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BoatRental] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BoatRental] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BoatRental] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BoatRental] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BoatRental] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BoatRental] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BoatRental] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BoatRental] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BoatRental] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BoatRental] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BoatRental] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BoatRental] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BoatRental] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BoatRental] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BoatRental] SET  MULTI_USER 
GO
ALTER DATABASE [BoatRental] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BoatRental] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BoatRental] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BoatRental] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BoatRental] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BoatRental] SET QUERY_STORE = OFF
GO
USE [BoatRental]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [BoatRental]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 2018-03-25 19:24:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Boats]    Script Date: 2018-03-25 19:24:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Boats](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BoatNumber] [int] NOT NULL,
	[BoatType] [int] NOT NULL,
	[Booked] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Boats] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 2018-03-25 19:24:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rentals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookingNumber] [int] NOT NULL,
	[BoatNumber] [int] NOT NULL,
	[PersonalNumber] [nvarchar](max) NULL,
	[DeliveryDate] [datetime] NOT NULL,
	[Cost] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.Rentals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201803241135131_Add-Migration -BoatRental-V1', N'BoatRental.DAL.Migrations.Configuration', 0x1F8B0800000000000400ED594B6FE33610BE17E87F10746A81AC95C7250DE45D64EDB8081A2746942CD0232D8D6DA214A58A5460FFB61EFA93FA173A14F5A028BFE3DD1645E18B349CF9389C19CE43FEEB8F3FFD4FCB98396F90099AF0BE7BD13B771DE06112513EEFBBB99C7DB8763F7DFCFE3BFF2E8A97CE978AEF4AF1A124177D7721657AE379225C404C442FA661968864267B61127B244ABCCBF3F39FBC8B0B0F10C2452CC7F19F732E690CC50BBE0E121E422A73C2C649044C94745C090A54E791C420521242DFFD9C10F90C5C12D61BDE3EB8CE2DA304B50880CD5C87709E482251C79B570181CC123E0F522410F6B24A01F96684092875BF69D8F73DC6F9A53A86D7085650612E64121F08787155DAC5B3C58FB2AE5BDB0D2D778716962B75EAC27ADA70AE636F7433609962B20DDBD39EE829EA99D35E3BAB0301E345FDCE9C41CE649E419F432E33C2CE9C493E6534FC05562FC96FC0FB3C67CC540F15C4B5160149932C492193AB6798954ADF47AEE3B5E53C5BB0163364F491EEB9BCBA749D47DC9C4C19D4DE378E1FC824839F8143462444132225645C614061BFCEEED65ECA308F793C856CD79EBB71947C85A2C2B9D7100F4643A3D756C0370684EF40F1BD2662B6C6918E83C3234953FE8FA5AD5EC3B47BAA703A05CE047D9370C2DA589857514FD71993E503F0B95CF45D7C749D115D4254514AFC574EB19AA090CCF29DDB0D8151AC45AB21DAAFDA4C3DBF60AD3858F71165A8E549A00689903508843456F13FC9F0A92C9BD7AE138444E1EDB2F1E66B96C756B2D657FF5E8C189937956BEF6BA710EB1472AA6B87FE8C20632BB4AC19576DEB8D41454BE553645D60EC7F212CC7D7F38EAD5BDC01A14C17AA92FF623BFFAF245C34CC975D5B6BAB76131AB61C92505E0335E6194ED51A2CD7154B6C2A4A738B32A2DBBA69EC00A4812A5CA771B991D93B07B385B53AEBC4AB14BC2EB0EA83354D94A7BBA8AADBF236B45BFE98A4297ACB68BF4A8A13E8DE6BF02138BC31893586178A35FD49AD6DBD13E65032076B555DC108463413122F31991275130651DC615BE7C60D56AE76343D651791C6F215B77AB623A6B86E854B2DF9C682233C548CCCC5F9A0D6A1ECCA3A6245E74B18C9D694A341C2F2986F2A69DBA4CDAA60A298F4C3D0748AB2B134F51024DDAEB47134AD8BE27B964D6DA7791DAF5945DF0E81BD02A4BA8DEF0891F2DA1E1E249B04BF5698B4FA10DB2BC6D23F157A765B6222DA6BFBA3B6BB0F13B3BDB23FA2D9829878267D7F34DD8598389AF28DAF48A7D0D82CF5EE75C1B10A8B5F26F9DDC37E27EB6B16D57C256F3452193F580909714F31F482DFD980513C6FC330269CCE4048DDC3B85894AEAD6F06FF9EF9DD1322627B0CF1DF7CF6A1CAA23BA79B77CF28C536EF1C9C8FC330C7E529DD8570E8A8FC5FF1D79AF1F45897BD1F65FD68CADF48162E48F6434C963F9A98C78E9F113ECBD38C9F474399E367F4B5C6CF754351B7E9DE3DEE6C9C7674EAC6134C133C8CD6B09C8FF61A84B6CC41EBA0EBE9E9C821A95BA37CCFFC6CED0F41D07903A13E62730855F26F402B9E7B3E4B2AA7E2B94C8D2A16CBE76390040386DC6692CE4828713904218AEF2EE5B47B87811FDDF3A75CA6B9BC1502E762D6FAC8E47BDBF72F26C1B6CEFE53AADEC4298E806A5215F34FFC734E5954EB3D5A13961B20540096290CB50AA44A65F3E663C263C2F7042ACD378414B84A802F10A70CC1C4130FC81B1CA3DBAB800798937055B51A9B41763BA26D767F48C93C23B128311A79F5578CA7FE8BF9F83760C5827FBD190000, N'6.2.0-61023')
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201803251217134_AutomaticMigration', N'BoatRental.DAL.Migrations.Configuration', 0x1F8B0800000000000400ED59CD6EE33610BE17E83B083AB540D6B293CB36907791B59322689C045176811E69696C13A54855A402FBD97AE823F5153A34F54BC9917FB2DBA2287C91C8998FC399E1703EF9AF3FFEF43FAE63E6BC402AA9E063773418BA0EF05044942FC76EA616EFDEBB1F3F7CFF9D7F1DC56BE74B2177A1E55093CBB1BB522AB9F43C19AE20267210D33015522CD42014B14722E19D0F873F79A3910708E12296E3F84F19573486ED0BBE4E040F2151196133110193F938CE045B54E79EC4201312C2D8FD24887A02AE081B4CAFEE5CE78A51825604C016AE4338178A28B4F1F2B38440A5822F830407087BDE2480720BC224E4B65F56E2FB6E6378AEB7E1558A0554984925E203014717B95F3C5BFD28EFBAA5DFD073D7E861B5D1BBDE7ACF38CE75EC852E272CD5420DC79A280CF4C899D31A3F2BF300D345FFCE9C49C65496C29843A652C2CE9CC76CCE68F80B6C9EC56FC0C73C63AC6E1DDA87738D011C7A4C4502A9DA3CC122B7F936721DAFA9E7D98AA55A4DC7ECE896AB8B73D7B9C7C5C99C4119FCDAEE032552F81938A44441F4489482946B0CD8BAAFB5BAB596F6CD7D16CF21ED5BB31F47EB17283A9B07D5E0C168E8F4D20BF8C680F01E14DFAB12E6D53432A970582299B7FF53A92F685874DF2A9BDE02E711632338614D2CACAA68A7EBCCC8FA0EF852ADC62E3EBACE0D5D43548CE4F89F39C5BB0495549AF52E370546F126DA4CD17FC562FAF9196F8A836D9F08A94A100869AC73F631C5A7FCA67BEF3A4148345E9F63761F8D2CB6EAAB39AEB7F286916575D91C7254346879F2DFF0C460282248D90643574F89A60F67A0035D8403455798B65F08CBF075D8F278433A2094991B26971FBD2EFF2B095795F079DBE3C6B7ED5284BD82229497409587A6733D07EBAE5B0EBB81DCE9324FC6A66D063B00554395AE5305BE56935B1BB3958D395DEA45F1EC4AAF726355F7E399F6A76893BC1D7D923F234982D1AAF54DF9881398A669F22E38BCA3880D8617CA8EC6A2B4B65C09CB1F598235AB0F62043734950A8F3299137D1E2651DC12EB0AE30E2F172BD62365D7FFCAF385B47EB63346779026A4967EE5C11BDC548CC2DBFD416943DE4EB5D4B62D2B6124EDB84926826531DF751BBDA65D2FE87594FAF86168A650D95866F41024D3683471CC581BC5F72C9FDA41F35A51B3EE6B3B05F64A90E2349E9022F9B13D3C4976297EAD3469B41076546A53FF54EAD91D451DD19EDB1FB5D938D4319B33FB239AEEA18E6446BE7152B7AE065BA45CBDBC22ACABC0CFCB723FAF6ED56923A29B26F142235DA3838D54100FB4C020F89D4D18C5FD560233C2E902A4325D878BF4F6DCA2E7FF1EAAEC4919B13DF8F237271A547BB4974A9C4C08B6CB9C48528FC3A853D339ED43389496FE57E2D5C1058F0DD9E928DD3C90BF90345C91F48798AC7FAC631ECBF5227C56A772BDE86B71BD2EEED1EE6DFB59C54E5261EA2DEE602E7033C6C29C86ECC5375EA11B5DD0254939928BB42F16DFAB7FD6F5A720E9B282D01F793984BA6257A085CC2D5F8822A8B8AFBA45858815F31928820943AE5245172454381D8294DB2F1339A9BCC66C8D6EF943A6924C5D4989F493353EC3F8DEEBEB6F0957D366FF21D16FF22DB68066529DF30FFC53465954DA7DD391963B207402E67507AD0A94AE3FCB8AB3DF0BBE2750EEBE2924C075D57A86386108261F78405EE018DB9072DFC192849BA23FD80DD21F88A6DBFD2925CB94C432C7A8F4F55F159EFEAFE2C3DF8737568EDD180000, N'6.2.0-61023')
SET IDENTITY_INSERT [dbo].[Boats] ON 

INSERT [dbo].[Boats] ([Id], [BoatNumber], [BoatType], [Booked]) VALUES (1, 101, 0, 0)
INSERT [dbo].[Boats] ([Id], [BoatNumber], [BoatType], [Booked]) VALUES (2, 102, 1, 0)
INSERT [dbo].[Boats] ([Id], [BoatNumber], [BoatType], [Booked]) VALUES (3, 103, 2, 0)
SET IDENTITY_INSERT [dbo].[Boats] OFF
USE [master]
GO
ALTER DATABASE [BoatRental] SET  READ_WRITE 
GO
