USE [Estate]
GO
/****** Object:  Table [dbo].[EsateLoging]    Script Date: 11/28/2020 6:58:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EsateLoging](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[LogDate] [datetime] NULL,
	[Userid] [int] NULL,
	[LogTable] [nvarchar](100) NULL,
	[LogExeption] [nvarchar](50) NULL,
	[LogTableId] [int] NULL,
 CONSTRAINT [PK_EsateLoging] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estate]    Script Date: 11/28/2020 6:58:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estate](
	[EstateId] [int] IDENTITY(1,1) NOT NULL,
	[EstateNumber] [nvarchar](50) NULL,
	[EstateName] [nvarchar](100) NULL,
	[Area] [float] NULL,
	[Address] [nvarchar](300) NULL,
	[Orientedstate] [tinyint] NULL,
	[Comment] [ntext] NULL,
	[OwnerId] [int] NULL,
	[IsDeleted] [bit] NULL,
	[CreateUser] [int] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Estate] PRIMARY KEY CLUSTERED 
(
	[EstateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Owner]    Script Date: 11/28/2020 6:58:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Owner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](100) NULL,
	[PhoneNumber] [nvarchar](100) NULL,
 CONSTRAINT [PK_Owner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Estate] ADD  CONSTRAINT [DF_Estate_Orientedstate]  DEFAULT ((0)) FOR [Orientedstate]
GO
ALTER TABLE [dbo].[Estate] ADD  CONSTRAINT [DF_Estate_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
