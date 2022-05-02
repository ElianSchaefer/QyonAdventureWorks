USE [qyon_db]
GO

/****** Object:  Table [dbo].[Competidores]    Script Date: 01/05/2022 19:52:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Competidores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NOT NULL,
	[Sexo] [nvarchar](1) NOT NULL,
	[TemperaturaCorporal] [decimal](18, 2) NOT NULL,
	[Peso] [decimal](18, 2) NOT NULL,
	[Altura] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Competidores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

