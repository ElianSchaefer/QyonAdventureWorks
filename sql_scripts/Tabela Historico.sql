USE [qyon_db]
GO

/****** Object:  Table [dbo].[Historicos]    Script Date: 01/05/2022 19:52:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Historicos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompetidorId] [int] NOT NULL,
	[PistaId] [int] NOT NULL,
	[DataCorrida] [datetime2](7) NOT NULL,
	[TempoGasto] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Historicos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

