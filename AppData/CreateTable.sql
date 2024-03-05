USE [PerformanceAppraisalDb]
GO
/****** Object:  Table [dbo].[AppraisalBases]    Script Date: 2024/3/4 12:27:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppraisalBases](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BaseType] [varchar](50) NULL,
	[AppraisalBase] [int] NULL,
	[IsDel] [bit] NULL,
 CONSTRAINT [PK_AppraisalBases_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppraisalCoefficients]    Script Date: 2024/3/4 12:27:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppraisalCoefficients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AppraisalType] [varchar](50) NULL,
	[AppraisalCoefficient] [float] NULL,
	[CalculationMethod] [int] NULL,
	[IsDel] [bit] NULL,
 CONSTRAINT [PK_AppraisalBases] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAppraisals]    Script Date: 2024/3/4 12:27:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAppraisals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[CoefficientId] [int] NULL,
	[Count] [float] NULL,
	[AssessmentYear] [int] NULL,
	[IsDel] [bit] NULL,
 CONSTRAINT [PK_UserAppraisal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2024/3/4 12:27:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Sex] [varchar](8) NULL,
	[Password] [varchar](50) NULL,
	[BaseTypeId] [int] NULL,
	[IsDel] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkDays]    Script Date: 2024/3/4 12:27:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkDays](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WorkDay] [int] NULL,
	[Year] [int] NULL,
 CONSTRAINT [PK_WorkDays] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserAppraisals]  WITH CHECK ADD  CONSTRAINT [FK_UserAppraisal_AppraisalCoefficients] FOREIGN KEY([CoefficientId])
REFERENCES [dbo].[AppraisalCoefficients] ([Id])
GO
ALTER TABLE [dbo].[UserAppraisals] CHECK CONSTRAINT [FK_UserAppraisal_AppraisalCoefficients]
GO
ALTER TABLE [dbo].[UserAppraisals]  WITH CHECK ADD  CONSTRAINT [FK_UserAppraisal_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserAppraisals] CHECK CONSTRAINT [FK_UserAppraisal_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_AppraisalBases] FOREIGN KEY([BaseTypeId])
REFERENCES [dbo].[AppraisalBases] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_AppraisalBases]
GO
