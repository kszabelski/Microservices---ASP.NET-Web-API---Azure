USE [AnalyticsServiceServiceDb]
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