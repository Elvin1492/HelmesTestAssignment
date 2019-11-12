USE [SectorApp]
GO
/****** Object:  Table [dbo].[AppUsers]    Script Date: 11/12/2019 6:25:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AppUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sectors]    Script Date: 11/12/2019 6:25:20 PM ******/
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
/****** Object:  Table [dbo].[UsersSectors]    Script Date: 11/12/2019 6:25:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersSectors](
	[Id] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[SectorId] [int] NOT NULL,
 CONSTRAINT [PK_UsersSectors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AppUsers] ON 

INSERT [dbo].[AppUsers] ([Id], [Name]) VALUES (1, N'Elvin')
SET IDENTITY_INSERT [dbo].[AppUsers] OFF
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
