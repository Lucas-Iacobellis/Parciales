USE [master]
GO
/****** Object:  Database [Negocio]    Script Date: 19/11/2020 01:02:24 ******/
CREATE DATABASE [Negocio]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Negocio', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Negocio.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Negocio_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Negocio_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Negocio] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Negocio].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Negocio] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Negocio] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Negocio] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Negocio] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Negocio] SET ARITHABORT OFF 
GO
ALTER DATABASE [Negocio] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Negocio] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Negocio] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Negocio] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Negocio] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Negocio] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Negocio] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Negocio] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Negocio] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Negocio] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Negocio] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Negocio] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Negocio] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Negocio] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Negocio] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Negocio] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Negocio] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Negocio] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Negocio] SET  MULTI_USER 
GO
ALTER DATABASE [Negocio] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Negocio] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Negocio] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Negocio] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Negocio] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Negocio] SET QUERY_STORE = OFF
GO
USE [Negocio]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 19/11/2020 01:02:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Nombre] [nvarchar](50) NULL,
	[Apellido] [nvarchar](50) NULL,
	[Edad] [int] NULL,
	[DNI] [int] NULL,
	[IdCliente] [int] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 19/11/2020 01:02:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[Nombre] [nvarchar](50) NULL,
	[Apellido] [nvarchar](50) NULL,
	[Edad] [int] NULL,
	[DNI] [int] NULL,
	[IdEmpleado] [int] NOT NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 19/11/2020 01:02:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Nombre] [nvarchar](50) NULL,
	[Precio] [float] NULL,
	[Cantidad] [int] NULL,
	[IdProducto] [nvarchar](50) NOT NULL,
	[Marca] [nvarchar](50) NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Clientes] ([Nombre], [Apellido], [Edad], [DNI], [IdCliente]) VALUES (N'Pedro', N'Perez', 35, 30932457, 1)
INSERT [dbo].[Clientes] ([Nombre], [Apellido], [Edad], [DNI], [IdCliente]) VALUES (N'Javier', N'Gimenez', 40, 26341289, 2)
GO
INSERT [dbo].[Empleados] ([Nombre], [Apellido], [Edad], [DNI], [IdEmpleado]) VALUES (N'Gaston', N'Gonzalez', 40, 26472190, 1)
INSERT [dbo].[Empleados] ([Nombre], [Apellido], [Edad], [DNI], [IdEmpleado]) VALUES (N'Mauro', N'Martinez', 35, 30752314, 2)
GO
INSERT [dbo].[Productos] ([Nombre], [Precio], [Cantidad], [IdProducto], [Marca]) VALUES (N'Cigarrillos', 150, 10, N'1', N'Lucky Strike')
INSERT [dbo].[Productos] ([Nombre], [Precio], [Cantidad], [IdProducto], [Marca]) VALUES (N'Gaseosa', 100, 20, N'2', N'Coca Cola')
INSERT [dbo].[Productos] ([Nombre], [Precio], [Cantidad], [IdProducto], [Marca]) VALUES (N'Cerveza', 120, 15, N'3', N'Quilmes')
GO
USE [master]
GO
ALTER DATABASE [Negocio] SET  READ_WRITE 
GO
