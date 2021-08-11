USE [master]
GO
/****** Object:  Database [20201203-sp]    Script Date: 3/12/2020 19:00:51 ******/
CREATE DATABASE [20201203-sp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'20201203-sp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\20201203-sp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'20201203-sp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\20201203-sp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [20201203-sp] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [20201203-sp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [20201203-sp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [20201203-sp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [20201203-sp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [20201203-sp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [20201203-sp] SET ARITHABORT OFF 
GO
ALTER DATABASE [20201203-sp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [20201203-sp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [20201203-sp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [20201203-sp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [20201203-sp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [20201203-sp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [20201203-sp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [20201203-sp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [20201203-sp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [20201203-sp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [20201203-sp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [20201203-sp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [20201203-sp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [20201203-sp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [20201203-sp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [20201203-sp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [20201203-sp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [20201203-sp] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [20201203-sp] SET  MULTI_USER 
GO
ALTER DATABASE [20201203-sp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [20201203-sp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [20201203-sp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [20201203-sp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [20201203-sp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [20201203-sp] SET QUERY_STORE = OFF
GO
USE [20201203-sp]
GO
/****** Object:  Table [dbo].[log]    Script Date: 3/12/2020 19:00:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[entrada] [varchar](100) NOT NULL,
	[alumno] [varchar](60) NOT NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [20201203-sp] SET  READ_WRITE 
GO
