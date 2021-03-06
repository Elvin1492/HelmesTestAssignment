USE [master]
GO
/****** Object:  Database [SectorApp]    Script Date: 11/15/2019 10:45:23 AM ******/
CREATE DATABASE [SectorApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SectorApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SectorApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SectorApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SectorApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SectorApp] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SectorApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SectorApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SectorApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SectorApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SectorApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SectorApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [SectorApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SectorApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SectorApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SectorApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SectorApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SectorApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SectorApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SectorApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SectorApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SectorApp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SectorApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SectorApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SectorApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SectorApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SectorApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SectorApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SectorApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SectorApp] SET RECOVERY FULL 
GO
ALTER DATABASE [SectorApp] SET  MULTI_USER 
GO
ALTER DATABASE [SectorApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SectorApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SectorApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SectorApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SectorApp] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SectorApp', N'ON'
GO
ALTER DATABASE [SectorApp] SET QUERY_STORE = OFF
GO
USE [SectorApp]
GO
/****** Object:  Table [dbo].[AppUsers]    Script Date: 11/15/2019 10:45:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[TermsIsAccepted] [bit] NOT NULL,
 CONSTRAINT [PK_AppUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sectors]    Script Date: 11/15/2019 10:45:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sectors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ParentId] [int] NULL,
 CONSTRAINT [PK_Sectors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersSectors]    Script Date: 11/15/2019 10:45:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersSectors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[SectorId] [int] NOT NULL,
 CONSTRAINT [PK_UsersSectors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Sectors] ON 

INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (1, N'Manufacturing', NULL)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (2, N'Other', NULL)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (3, N'Service', NULL)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (4, N'Construction materials', 1)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (5, N'Electronics and Optics', 1)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (6, N'Food and Beverage', 1)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (7, N'Furniture', 1)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (8, N'Machinery', 1)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (9, N'Metalworking', 1)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (10, N'Plastic and Rubber', 1)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (11, N'Printing', 1)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (12, N'Textile and Clothing', 1)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (13, N'Wood', 1)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (14, N'Creative industries', 2)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (15, N'Energy technology', 2)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (16, N'Environment', 2)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (17, N'Business Services', 3)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (18, N'Engineering', 3)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (19, N'Information technology and Telecommunications', 3)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (20, N'Tourism', 3)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (21, N'Translation services', 3)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (22, N'Transport and Logistics', 3)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (23, N'Bakery & confectionery products', 6)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (24, N'Beverages', 6)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (25, N'Fush and fish products', 6)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (26, N'Meat & meat products', 6)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (27, N'Milk & dairy products', 6)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (28, N'Other', 6)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (29, N'Sweets & snack food', 6)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (30, N'Bathroom/sauna', 7)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (31, N'Bedroom', 7)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (32, N'Children room', 7)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (33, N'Kitchen', 7)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (34, N'Living room', 7)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (35, N'Office', 7)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (36, N'Other(Furniture)', 7)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (37, N'Outdoor', 7)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (38, N'Project furniture', 7)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (39, N'Machinery components', 8)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (40, N'Machinery equipment/tools', 8)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (41, N'Manufacture of machinery', 8)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (42, N'Maritime', 8)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (43, N'Metal structures', 8)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (44, N'Other', 8)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (45, N'Repair and maintenance service', 8)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (46, N'Construction of metal structures', 9)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (47, N'Houses and buildings', 9)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (48, N'Metal products', 9)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (49, N'Metal works', 9)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (50, N'Packaging', 10)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (51, N'Plastic goods', 10)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (52, N'Plastic precessing technology', 10)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (53, N'Plastic profiles', 10)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (54, N'Advertising', 11)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (55, N'Books/Periodicals printing', 11)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (56, N'Labelling and packaging printing', 11)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (57, N'Clothing', 12)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (58, N'Textile', 12)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (59, N'Other(wood)', 13)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (60, N'Wooden building meterials', 13)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (61, N'Wooden houses', 13)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (62, N'Data processing, Web portals, E-marketing', 19)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (63, N'Programming, Consultancy', 19)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (64, N'Software, Hardware', 19)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (65, N'Telecommunications', 19)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (70, N'Air', 22)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (71, N'Rail', 22)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (72, N'Road', 22)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (73, N'Water', 22)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (74, N'Aluminium and steel workboats', 42)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (75, N'Boat/Yacht building', 42)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (76, N'Ship repair and conversion', 42)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (77, N'CNC-machining', 49)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (78, N'Forgings, Fasteners', 49)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (79, N'Gas, Plasma, Laser cutting', 49)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (80, N'MIG, TIG, Aluminum welding', 49)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (81, N'Blowing', 52)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (82, N'Moulding', 52)
INSERT [dbo].[Sectors] ([Id], [Name], [ParentId]) VALUES (83, N'Plastic welding andd processing', 52)
SET IDENTITY_INSERT [dbo].[Sectors] OFF
ALTER TABLE [dbo].[Sectors]  WITH CHECK ADD  CONSTRAINT [FK_Sectors_Sectors] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Sectors] ([Id])
GO
ALTER TABLE [dbo].[Sectors] CHECK CONSTRAINT [FK_Sectors_Sectors]
GO
ALTER TABLE [dbo].[UsersSectors]  WITH CHECK ADD  CONSTRAINT [FK_UsersSectors_AppUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AppUsers] ([Id])
GO
ALTER TABLE [dbo].[UsersSectors] CHECK CONSTRAINT [FK_UsersSectors_AppUsers]
GO
ALTER TABLE [dbo].[UsersSectors]  WITH CHECK ADD  CONSTRAINT [FK_UsersSectors_Sectors] FOREIGN KEY([Id])
REFERENCES [dbo].[Sectors] ([Id])
GO
ALTER TABLE [dbo].[UsersSectors] CHECK CONSTRAINT [FK_UsersSectors_Sectors]
GO
USE [master]
GO
ALTER DATABASE [SectorApp] SET  READ_WRITE 
GO
