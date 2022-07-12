USE [EasyCrudTestDB]
GO

/****** Object:  Table [dbo].[clientes]    Script Date: 09/07/2022 15:43:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[clientes](
	[cliente_num] [int] NOT NULL primary key identity(1,1),
	[nombre] [varchar](100) NOT NULL,
	[apellido] [varchar](100) NOT NULL,
	[empresa] [varchar](100) NULL,
	[domicilio] [varchar](100) NULL,
	[ciudad] [varchar](100) NULL,
	[codPostal] [char](50) NULL,
	[telefono] [varchar](20) NULL,
	[estado] BIT NULL,
)
