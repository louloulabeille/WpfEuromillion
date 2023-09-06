USE [Euro]
GO

/****** Object:  Table [dbo].[Tirage]    Script Date: 31/08/2023 14:37:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tirage](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NumTirage] [int] NOT NULL,
	[DateTirage] [date] NOT NULL,
	[Boule1] [int] NOT NULL,
	[Boule2] [int] NOT NULL,
	[Boule3] [int] NOT NULL,
	[Boule4] [int] NOT NULL,
	[Boule5] [int] NOT NULL,
	[Etoile1] [int] NOT NULL,
	[Etoile2] [int] NOT NULL,
	[TCroissant] [nvarchar](14) NULL,
	[ECroissant] [nvarchar](3) NULL,
	[Gagnant] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Tirage] ADD  DEFAULT ((0)) FOR [Gagnant]
GO


