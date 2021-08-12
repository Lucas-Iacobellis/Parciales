USE [master];
CREATE DATABASE comida;
GO
USE comida
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comidas](
	[nombre] [varchar](50) NULL,
	[precio] [float] NULL
) ON [PRIMARY]
GO
INSERT INTO comidas(nombre,precio) values
('mila con fritas',850),
('ravioles',550),
('ñoquis',450),
('canelones',500),
('panchito',350),
('cono fritas',350),
('hamburguesa',450)
