USE [master]
GO
/****** Object:  Database [CC]    Script Date: 4/25/2022 7:27:39 AM ******/
CREATE DATABASE [CC]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CC', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CC.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CC_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CC_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CC] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CC] SET ARITHABORT OFF 
GO
ALTER DATABASE [CC] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CC] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CC] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [CC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CC] SET RECOVERY FULL 
GO
ALTER DATABASE [CC] SET  MULTI_USER 
GO
ALTER DATABASE [CC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CC] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CC] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CC', N'ON'
GO
ALTER DATABASE [CC] SET QUERY_STORE = OFF
GO
USE [CC]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/25/2022 7:27:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 4/25/2022 7:27:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 4/25/2022 7:27:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 4/25/2022 7:27:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 4/25/2022 7:27:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 4/25/2022 7:27:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 4/25/2022 7:27:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Created] [datetime2](7) NOT NULL,
	[LastModified] [datetime2](7) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 4/25/2022 7:27:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Currencies]    Script Date: 4/25/2022 7:27:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currencies](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Sign] [nvarchar](100) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Currencies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[exchangeHistories]    Script Date: 4/25/2022 7:27:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[exchangeHistories](
	[Id] [uniqueidentifier] NOT NULL,
	[CurrencyId] [uniqueidentifier] NOT NULL,
	[ExchangeDate] [datetime2](7) NOT NULL,
	[Rate] [float] NOT NULL,
 CONSTRAINT [PK_exchangeHistories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220420121838_initialMigration', N'6.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220421131457_ChangeTypeOfExchangeAndAddIndex', N'6.0.4')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Created], [LastModified], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'f895f972-604f-4fe4-aec4-254be4f4a24b', N'ahmed', N'zakaria', CAST(N'2022-04-25T04:44:08.4783566' AS DateTime2), NULL, N'azakaria', N'AZAKARIA', N'a.zakaria@hotmail.com', N'A.ZAKARIA@HOTMAIL.COM', 0, N'AQAAAAEAACcQAAAAECp8k3m9gychttZkBEf4no/ZnTXhvE1uAjJIc8RMhvwu0e+cFHlxaxvbNaWvKj+HpA==', N'VQSDI4VLLBNXEE3DIUP7LCUSFFOVW52J', N'83976888-4bf3-4b33-8b7d-0300eaebdbcd', N'01270889098', 0, 0, NULL, 1, 0)
INSERT [dbo].[Currencies] ([Id], [Name], [Sign], [IsDeleted]) VALUES (N'e150d5c1-8bec-4bd1-91e6-16a984176d80', N'Egyptian Pound', N'LE', 0)
INSERT [dbo].[Currencies] ([Id], [Name], [Sign], [IsDeleted]) VALUES (N'9c37c1e5-5e1b-4f06-ad7c-16e7a10d212d', N'dollar', N'$', 0)
INSERT [dbo].[Currencies] ([Id], [Name], [Sign], [IsDeleted]) VALUES (N'a08b3a6f-f772-443f-b208-3288badf88a6', N' Chinese yuan', N'CNY', 1)
INSERT [dbo].[Currencies] ([Id], [Name], [Sign], [IsDeleted]) VALUES (N'336d37f4-35de-415d-8176-8803a6dbca68', N'Euro ', N'EUR', 0)
INSERT [dbo].[Currencies] ([Id], [Name], [Sign], [IsDeleted]) VALUES (N'c85bfb99-4796-45ce-9928-b557497c9fe7', N'Japanese yen', N'JPY', 0)
INSERT [dbo].[Currencies] ([Id], [Name], [Sign], [IsDeleted]) VALUES (N'9d17b136-0e66-49f1-971e-b6f2bc43152e', N'Saudi Arabian Riyal', N'SAR', 0)
INSERT [dbo].[Currencies] ([Id], [Name], [Sign], [IsDeleted]) VALUES (N'd893e6e7-4eed-401e-900c-d0b8bdae3b99', N'Emirati Dirhams', N'AED', 0)
INSERT [dbo].[Currencies] ([Id], [Name], [Sign], [IsDeleted]) VALUES (N'54a78cf3-a316-4fb4-b2fd-f4cabd5334e4', N'Pound sterling', N'GBP', 0)
INSERT [dbo].[exchangeHistories] ([Id], [CurrencyId], [ExchangeDate], [Rate]) VALUES (N'71df4f1a-6944-4b80-8e9e-15312918bfd3', N'e150d5c1-8bec-4bd1-91e6-16a984176d80', CAST(N'2022-04-22T08:15:37.6049066' AS DateTime2), 15.5)
INSERT [dbo].[exchangeHistories] ([Id], [CurrencyId], [ExchangeDate], [Rate]) VALUES (N'a54fb523-e564-4328-90f3-2ee7706ad5f0', N'9d17b136-0e66-49f1-971e-b6f2bc43152e', CAST(N'2022-04-21T16:27:40.1195060' AS DateTime2), 0.266667)
INSERT [dbo].[exchangeHistories] ([Id], [CurrencyId], [ExchangeDate], [Rate]) VALUES (N'7d37ef14-ee63-4fe6-b055-3f9615b4d037', N'9d17b136-0e66-49f1-971e-b6f2bc43152e', CAST(N'2022-04-22T08:13:31.3652323' AS DateTime2), 0.2663)
INSERT [dbo].[exchangeHistories] ([Id], [CurrencyId], [ExchangeDate], [Rate]) VALUES (N'2330a87c-b4ef-4a4f-9273-547d8ac149a6', N'9d17b136-0e66-49f1-971e-b6f2bc43152e', CAST(N'2022-04-22T07:53:17.0793421' AS DateTime2), 0.26666667)
INSERT [dbo].[exchangeHistories] ([Id], [CurrencyId], [ExchangeDate], [Rate]) VALUES (N'ac73f275-16ec-42bc-ba02-6a8e1559826d', N'336d37f4-35de-415d-8176-8803a6dbca68', CAST(N'2022-04-23T21:45:39.5015004' AS DateTime2), 0.93)
INSERT [dbo].[exchangeHistories] ([Id], [CurrencyId], [ExchangeDate], [Rate]) VALUES (N'e1e4fbb8-1c87-48e9-b90f-77b9c2523382', N'd893e6e7-4eed-401e-900c-d0b8bdae3b99', CAST(N'2022-04-25T07:23:31.2677150' AS DateTime2), 3.6725)
INSERT [dbo].[exchangeHistories] ([Id], [CurrencyId], [ExchangeDate], [Rate]) VALUES (N'6c2a0fcb-cc3f-43b1-96f1-8c6390ba175c', N'e150d5c1-8bec-4bd1-91e6-16a984176d80', CAST(N'2022-04-25T00:08:17.3170000' AS DateTime2), 18)
INSERT [dbo].[exchangeHistories] ([Id], [CurrencyId], [ExchangeDate], [Rate]) VALUES (N'c35a9188-bccc-4ef8-860b-97edd53a93ee', N'e150d5c1-8bec-4bd1-91e6-16a984176d80', CAST(N'2022-04-23T07:39:16.7762675' AS DateTime2), 15)
INSERT [dbo].[exchangeHistories] ([Id], [CurrencyId], [ExchangeDate], [Rate]) VALUES (N'03598e1b-fb47-4205-8618-9b9c32f514db', N'9d17b136-0e66-49f1-971e-b6f2bc43152e', CAST(N'2022-04-22T09:32:36.2572679' AS DateTime2), 3.75)
INSERT [dbo].[exchangeHistories] ([Id], [CurrencyId], [ExchangeDate], [Rate]) VALUES (N'098a63fa-4a5c-4ead-98cd-a97b685425d1', N'e150d5c1-8bec-4bd1-91e6-16a984176d80', CAST(N'2022-04-21T16:23:55.6178781' AS DateTime2), 17)
INSERT [dbo].[exchangeHistories] ([Id], [CurrencyId], [ExchangeDate], [Rate]) VALUES (N'd3ad9617-c247-4dba-a032-aa4007e8c215', N'c85bfb99-4796-45ce-9928-b557497c9fe7', CAST(N'2022-04-23T22:01:22.8564316' AS DateTime2), 128.47)
INSERT [dbo].[exchangeHistories] ([Id], [CurrencyId], [ExchangeDate], [Rate]) VALUES (N'4989eeb2-c981-47d2-befd-c3028998054f', N'e150d5c1-8bec-4bd1-91e6-16a984176d80', CAST(N'2022-04-24T09:30:38.7246757' AS DateTime2), 18.58)
INSERT [dbo].[exchangeHistories] ([Id], [CurrencyId], [ExchangeDate], [Rate]) VALUES (N'cc5710c8-1c1f-4daf-a816-d05a652c148f', N'54a78cf3-a316-4fb4-b2fd-f4cabd5334e4', CAST(N'2022-04-23T22:02:02.5542241' AS DateTime2), 0.78)
INSERT [dbo].[exchangeHistories] ([Id], [CurrencyId], [ExchangeDate], [Rate]) VALUES (N'498531c9-af8c-41a4-9530-d0cad1fa3674', N'9c37c1e5-5e1b-4f06-ad7c-16e7a10d212d', CAST(N'2022-04-19T14:50:39.9980887' AS DateTime2), 1)
INSERT [dbo].[exchangeHistories] ([Id], [CurrencyId], [ExchangeDate], [Rate]) VALUES (N'e4258a92-b401-4634-9233-dbd8054fa7b9', N'336d37f4-35de-415d-8176-8803a6dbca68', CAST(N'2022-04-24T21:45:39.5015004' AS DateTime2), 0.9)
INSERT [dbo].[exchangeHistories] ([Id], [CurrencyId], [ExchangeDate], [Rate]) VALUES (N'6731ccab-2a8b-46b1-a07e-e7f50b8b3c83', N'a08b3a6f-f772-443f-b208-3288badf88a6', CAST(N'2022-04-23T22:00:24.7883387' AS DateTime2), 6.53)
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 4/25/2022 7:27:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 4/25/2022 7:27:40 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 4/25/2022 7:27:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 4/25/2022 7:27:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 4/25/2022 7:27:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 4/25/2022 7:27:40 AM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 4/25/2022 7:27:40 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_exchangeHistories_CurrencyId]    Script Date: 4/25/2022 7:27:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_exchangeHistories_CurrencyId] ON [dbo].[exchangeHistories]
(
	[CurrencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_exchangeHistories_ExchangeDate]    Script Date: 4/25/2022 7:27:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_exchangeHistories_ExchangeDate] ON [dbo].[exchangeHistories]
(
	[ExchangeDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[exchangeHistories]  WITH CHECK ADD  CONSTRAINT [FK_exchangeHistories_Currencies_CurrencyId] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currencies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[exchangeHistories] CHECK CONSTRAINT [FK_exchangeHistories_Currencies_CurrencyId]
GO
USE [master]
GO
ALTER DATABASE [CC] SET  READ_WRITE 
GO
