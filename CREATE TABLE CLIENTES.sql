USE [UADE_DB_1]
GO

/****** Object:  Table [dbo].[clientes]    Script Date: 09/07/2022 15:43:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[clientes](
	[cliente_num] [int] NOT NULL,
	[nombre] [varchar](15) NOT NULL,
	[apellido] [varchar](15) NOT NULL,
	[empresa] [varchar](20) NULL,
	[domicilio] [varchar](20) NULL,
	[ciudad] [varchar](25) NULL,
	[provincia_cod] [char](2) NULL,
	[codPostal] [char](5) NULL,
	[telefono] [varchar](18) NULL,
	[cliente_ref] [int] NULL,
	[estado] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[cliente_num] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[clientes]  WITH CHECK ADD FOREIGN KEY([cliente_ref])
REFERENCES [dbo].[clientes] ([cliente_num])
GO

ALTER TABLE [dbo].[clientes]  WITH CHECK ADD FOREIGN KEY([provincia_cod])
REFERENCES [dbo].[provincias] ([provincia_cod])
GO

