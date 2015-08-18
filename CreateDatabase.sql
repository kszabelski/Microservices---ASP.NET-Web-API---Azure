USE [master]
GO

CREATE DATABASE [MarketManagementServiceDb]
GO

CREATE TABLE [dbo].[Markets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Markets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
)
GO

CREATE TABLE [dbo].[Ratings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserEmail] [nvarchar](max) NULL,
	[Comment] [nvarchar](max) NULL,
	[Rate] [int] NOT NULL,
	[MarketId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Ratings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
)
GO

CREATE TABLE [dbo].[Recommendations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserEmail] [nvarchar](max) NOT NULL,
	[MarketId] [int] NOT NULL,
 CONSTRAINT [PK_Recommendations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
)
GO