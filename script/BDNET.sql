USE [NET]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 16/9/2020 22:54:50 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpleadoDiaTrabajas]    Script Date: 16/9/2020 22:54:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpleadoDiaTrabajas](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Dia] [int] NOT NULL,
	[HorasTrabaja] [int] NOT NULL,
	[EmpleadoId] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.EmpleadoDiaTrabajas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleadoes]    Script Date: 16/9/2020 22:54:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleadoes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TipoDocumento] [int] NOT NULL,
	[Documento] [nvarchar](max) NULL,
	[PrimerApellido] [nvarchar](max) NULL,
	[SegundoApellido] [nvarchar](max) NULL,
	[PrimerNombre] [nvarchar](max) NULL,
	[SegundoNombre] [nvarchar](max) NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[Sexo] [int] NOT NULL,
	[TipoSalario] [int] NOT NULL,
	[Salario] [decimal](18, 2) NOT NULL,
	[Activo] [bit] NOT NULL,
	[FechaDesactivado] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Empleadoes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmpleadoDiaTrabajas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EmpleadoDiaTrabajas_dbo.Empleadoes_EmpleadoId] FOREIGN KEY([EmpleadoId])
REFERENCES [dbo].[Empleadoes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmpleadoDiaTrabajas] CHECK CONSTRAINT [FK_dbo.EmpleadoDiaTrabajas_dbo.Empleadoes_EmpleadoId]
GO
