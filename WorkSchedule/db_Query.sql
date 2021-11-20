USE [master]
GO
/****** Object:  Database [WorkingScheduleDB]    Script Date: 20.11.2021 22:34:14 ******/
CREATE DATABASE [WorkingScheduleDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WorkingScheduleDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\WorkingScheduleDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WorkingScheduleDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\WorkingScheduleDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [WorkingScheduleDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WorkingScheduleDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WorkingScheduleDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WorkingScheduleDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WorkingScheduleDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WorkingScheduleDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WorkingScheduleDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [WorkingScheduleDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WorkingScheduleDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WorkingScheduleDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WorkingScheduleDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WorkingScheduleDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WorkingScheduleDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WorkingScheduleDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WorkingScheduleDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WorkingScheduleDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WorkingScheduleDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WorkingScheduleDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WorkingScheduleDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WorkingScheduleDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WorkingScheduleDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WorkingScheduleDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WorkingScheduleDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WorkingScheduleDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WorkingScheduleDB] SET RECOVERY FULL 
GO
ALTER DATABASE [WorkingScheduleDB] SET  MULTI_USER 
GO
ALTER DATABASE [WorkingScheduleDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WorkingScheduleDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WorkingScheduleDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WorkingScheduleDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WorkingScheduleDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WorkingScheduleDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'WorkingScheduleDB', N'ON'
GO
ALTER DATABASE [WorkingScheduleDB] SET QUERY_STORE = OFF
GO
USE [WorkingScheduleDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 20.11.2021 22:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 20.11.2021 22:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](50) NOT NULL,
	[EmployeeSurname] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedules]    Script Date: 20.11.2021 22:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedules](
	[ScheduleId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Week] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[SwType] [nvarchar](2) NOT NULL,
 CONSTRAINT [PK_Schedules] PRIMARY KEY CLUSTERED 
(
	[ScheduleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [WorkingScheduleDB] SET  READ_WRITE 
GO
