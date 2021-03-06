USE [master]
GO
/****** Object:  Database [UniversityCRMS]    Script Date: 06-Jun-18 8:56:16 AM ******/
CREATE DATABASE [UniversityCRMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversityCRMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\UniversityCRMS.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UniversityCRMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\UniversityCRMS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UniversityCRMS] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityCRMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityCRMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversityCRMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversityCRMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversityCRMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversityCRMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversityCRMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversityCRMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversityCRMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityCRMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversityCRMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversityCRMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversityCRMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversityCRMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversityCRMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversityCRMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniversityCRMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversityCRMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversityCRMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversityCRMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversityCRMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversityCRMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniversityCRMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversityCRMS] SET RECOVERY FULL 
GO
ALTER DATABASE [UniversityCRMS] SET  MULTI_USER 
GO
ALTER DATABASE [UniversityCRMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversityCRMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversityCRMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversityCRMS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [UniversityCRMS] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'UniversityCRMS', N'ON'
GO
USE [UniversityCRMS]
GO
/****** Object:  Table [dbo].[CourseAssignToTeacher]    Script Date: 06-Jun-18 8:56:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CourseAssignToTeacher](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Course] [varchar](20) NOT NULL,
	[Teacher] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 06-Jun-18 8:56:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Courses](
	[Code] [varchar](20) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Credit] [float] NOT NULL,
	[Descriptions] [varchar](100) NULL,
	[Department] [varchar](20) NOT NULL,
	[Samester] [int] NOT NULL,
	[status] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 06-Jun-18 8:56:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Departments](
	[Code] [varchar](20) NOT NULL,
	[Name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Designations]    Script Date: 06-Jun-18 8:56:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Designations](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Designation] [varchar](50) NOT NULL,
 CONSTRAINT [PK__ID__3214EC27C9EF1727] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Results]    Script Date: 06-Jun-18 8:56:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Results](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NOT NULL,
	[Course] [varchar](20) NOT NULL,
	[Grade] [varchar](2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RoomAllocation]    Script Date: 06-Jun-18 8:56:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoomAllocation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Course] [varchar](20) NOT NULL,
	[Room] [int] NOT NULL,
	[Day] [varchar](5) NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 06-Jun-18 8:56:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rooms](
	[RoomNO] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](10) NOT NULL,
	[Status] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Samesters]    Script Date: 06-Jun-18 8:56:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Samesters](
	[NO] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentEnroll]    Script Date: 06-Jun-18 8:56:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentEnroll](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NOT NULL,
	[Course] [varchar](20) NOT NULL,
	[Date] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Students]    Script Date: 06-Jun-18 8:56:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Students](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RegistrationNo] [varchar](15) NULL
) ON [PRIMARY]
SET ANSI_PADDING OFF
ALTER TABLE [dbo].[Students] ADD [Name] [varchar](40) NOT NULL
ALTER TABLE [dbo].[Students] ADD [Email] [varchar](50) NOT NULL
ALTER TABLE [dbo].[Students] ADD [Contact] [int] NOT NULL
ALTER TABLE [dbo].[Students] ADD [Department] [varchar](20) NOT NULL
ALTER TABLE [dbo].[Students] ADD [Date] [date] NOT NULL
ALTER TABLE [dbo].[Students] ADD [Address] [varchar](100) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 06-Jun-18 8:56:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Teachers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](40) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Contact] [int] NOT NULL,
	[Department] [varchar](20) NOT NULL,
	[Address] [varchar](100) NULL,
	[Credit] [float] NOT NULL,
	[Designation] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CourseAssignToTeacher] ON 

INSERT [dbo].[CourseAssignToTeacher] ([ID], [Course], [Teacher]) VALUES (1, N'CSE-111', 1)
INSERT [dbo].[CourseAssignToTeacher] ([ID], [Course], [Teacher]) VALUES (2, N'CSE-112', 2)
INSERT [dbo].[CourseAssignToTeacher] ([ID], [Course], [Teacher]) VALUES (3, N'CSE-221', 1)
INSERT [dbo].[CourseAssignToTeacher] ([ID], [Course], [Teacher]) VALUES (4, N'CSE-311', 2)
INSERT [dbo].[CourseAssignToTeacher] ([ID], [Course], [Teacher]) VALUES (5, N'CSE-121', 1)
SET IDENTITY_INSERT [dbo].[CourseAssignToTeacher] OFF
INSERT [dbo].[Courses] ([Code], [Name], [Credit], [Descriptions], [Department], [Samester], [status]) VALUES (N'Chem-111', N'Introduction to Chem', 3, N'Introduction Subject ', N'Ch.E', 1, N'availavle')
INSERT [dbo].[Courses] ([Code], [Name], [Credit], [Descriptions], [Department], [Samester], [status]) VALUES (N'CSE-111', N'Introduction to Computer System', 3, N'Basic of CSE', N'CSE', 1, N'availavle')
INSERT [dbo].[Courses] ([Code], [Name], [Credit], [Descriptions], [Department], [Samester], [status]) VALUES (N'CSE-112', N'Computer Programming', 3, N'Basic of CSE-2', N'CSE', 1, N'availavle')
INSERT [dbo].[Courses] ([Code], [Name], [Credit], [Descriptions], [Department], [Samester], [status]) VALUES (N'CSE-113', N'Computer Programming Practical', 1.5, N'Basic of CSE-3', N'CSE', 1, N'availavle')
INSERT [dbo].[Courses] ([Code], [Name], [Credit], [Descriptions], [Department], [Samester], [status]) VALUES (N'CSE-121', N'Data Structure', 3, N'Data Type', N'CSE', 2, N'availavle')
INSERT [dbo].[Courses] ([Code], [Name], [Credit], [Descriptions], [Department], [Samester], [status]) VALUES (N'CSE-211', N'Algorithm Design ', 3, N'Algorithm Subject', N'CSE', 3, N'availavle')
INSERT [dbo].[Courses] ([Code], [Name], [Credit], [Descriptions], [Department], [Samester], [status]) VALUES (N'CSE-221', N'Software Engineering', 3, N'Software solution ', N'CSE', 4, N'availavle')
INSERT [dbo].[Courses] ([Code], [Name], [Credit], [Descriptions], [Department], [Samester], [status]) VALUES (N'CSE-222', N'Software Engineering Practical', 1.5, N'Software solution ', N'CSE', 4, N'availavle')
INSERT [dbo].[Courses] ([Code], [Name], [Credit], [Descriptions], [Department], [Samester], [status]) VALUES (N'CSE-311', N'Computer Architecture', 3, N'Design sub', N'CSE', 5, N'availavle')
INSERT [dbo].[Courses] ([Code], [Name], [Credit], [Descriptions], [Department], [Samester], [status]) VALUES (N'CSE-321', N'Digital Logic And Design ', 3, N'Digital Gate', N'CSE', 6, N'availavle')
INSERT [dbo].[Courses] ([Code], [Name], [Credit], [Descriptions], [Department], [Samester], [status]) VALUES (N'CSE-411', N'Networking', 3, N'Digital Networking', N'CSE', 7, N'availavle')
INSERT [dbo].[Courses] ([Code], [Name], [Credit], [Descriptions], [Department], [Samester], [status]) VALUES (N'CSE-421', N'Web Engineering', 4, N'Digital Networking', N'CSE', 8, N'availavle')
INSERT [dbo].[Courses] ([Code], [Name], [Credit], [Descriptions], [Department], [Samester], [status]) VALUES (N'EEE-111', N'Introduction to EEE', 3, N'Digital Networking', N'EEE', 1, N'availavle')
INSERT [dbo].[Departments] ([Code], [Name]) VALUES (N'Ch.E', N'Department of Chemical Engineering')
INSERT [dbo].[Departments] ([Code], [Name]) VALUES (N'Chem', N'Department of chemistry')
INSERT [dbo].[Departments] ([Code], [Name]) VALUES (N'CSE', N'Computer Science And Engineering')
INSERT [dbo].[Departments] ([Code], [Name]) VALUES (N'EEE', N'Electronics and Electrical Engineering')
INSERT [dbo].[Departments] ([Code], [Name]) VALUES (N'ETE', N'Electronics and TeleComunication Engineering')
INSERT [dbo].[Departments] ([Code], [Name]) VALUES (N'Math', N'Department of Mathematics')
INSERT [dbo].[Departments] ([Code], [Name]) VALUES (N'Phys', N'Department of Physics')
SET IDENTITY_INSERT [dbo].[Designations] ON 

INSERT [dbo].[Designations] ([ID], [Designation]) VALUES (1, N'Lecturer')
INSERT [dbo].[Designations] ([ID], [Designation]) VALUES (2, N'Professor')
SET IDENTITY_INSERT [dbo].[Designations] OFF
SET IDENTITY_INSERT [dbo].[Results] ON 

INSERT [dbo].[Results] ([ID], [StudentID], [Course], [Grade]) VALUES (1, 1, N'CSE-111', N'A+')
INSERT [dbo].[Results] ([ID], [StudentID], [Course], [Grade]) VALUES (2, 5, N'CSE-321', N'B+')
SET IDENTITY_INSERT [dbo].[Results] OFF
SET IDENTITY_INSERT [dbo].[RoomAllocation] ON 

INSERT [dbo].[RoomAllocation] ([ID], [Course], [Room], [Day], [StartTime], [EndTime]) VALUES (1, N'CSE-111', 1, N'Sat', CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time))
INSERT [dbo].[RoomAllocation] ([ID], [Course], [Room], [Day], [StartTime], [EndTime]) VALUES (2, N'CSE-111', 1, N'Sat', CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time))
INSERT [dbo].[RoomAllocation] ([ID], [Course], [Room], [Day], [StartTime], [EndTime]) VALUES (3, N'EEE-111', 1, N'Sat', CAST(N'11:00:00' AS Time), CAST(N'16:00:00' AS Time))
INSERT [dbo].[RoomAllocation] ([ID], [Course], [Room], [Day], [StartTime], [EndTime]) VALUES (4, N'CSE-111', 1, N'Sat', CAST(N'16:00:00' AS Time), CAST(N'17:00:00' AS Time))
INSERT [dbo].[RoomAllocation] ([ID], [Course], [Room], [Day], [StartTime], [EndTime]) VALUES (6, N'CSE-112', 1, N'Sat', CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[RoomAllocation] OFF
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([RoomNO], [Name], [Status]) VALUES (1, N'A-100', N'free')
INSERT [dbo].[Rooms] ([RoomNO], [Name], [Status]) VALUES (2, N'A-101', N'free')
INSERT [dbo].[Rooms] ([RoomNO], [Name], [Status]) VALUES (3, N'A-102', N'free')
INSERT [dbo].[Rooms] ([RoomNO], [Name], [Status]) VALUES (4, N'A-103', N'free')
INSERT [dbo].[Rooms] ([RoomNO], [Name], [Status]) VALUES (5, N'B-100', N'free')
INSERT [dbo].[Rooms] ([RoomNO], [Name], [Status]) VALUES (6, N'B-101', N'booked')
INSERT [dbo].[Rooms] ([RoomNO], [Name], [Status]) VALUES (7, N'B-102', N'free')
INSERT [dbo].[Rooms] ([RoomNO], [Name], [Status]) VALUES (8, N'C-100', N'booked')
INSERT [dbo].[Rooms] ([RoomNO], [Name], [Status]) VALUES (9, N'C-101', N'free')
INSERT [dbo].[Rooms] ([RoomNO], [Name], [Status]) VALUES (10, N'C-102', N'booked')
INSERT [dbo].[Rooms] ([RoomNO], [Name], [Status]) VALUES (12, N'D-102', N'booked')
SET IDENTITY_INSERT [dbo].[Rooms] OFF
SET IDENTITY_INSERT [dbo].[Samesters] ON 

INSERT [dbo].[Samesters] ([NO], [Name]) VALUES (1, N'1st Semester')
INSERT [dbo].[Samesters] ([NO], [Name]) VALUES (2, N'2nd Semester')
INSERT [dbo].[Samesters] ([NO], [Name]) VALUES (3, N'3rd Semester')
INSERT [dbo].[Samesters] ([NO], [Name]) VALUES (4, N'4th Semester')
INSERT [dbo].[Samesters] ([NO], [Name]) VALUES (5, N'5th Semester')
INSERT [dbo].[Samesters] ([NO], [Name]) VALUES (6, N'6th Semester')
INSERT [dbo].[Samesters] ([NO], [Name]) VALUES (7, N'7th Semester')
INSERT [dbo].[Samesters] ([NO], [Name]) VALUES (8, N'8th Semester')
SET IDENTITY_INSERT [dbo].[Samesters] OFF
SET IDENTITY_INSERT [dbo].[StudentEnroll] ON 

INSERT [dbo].[StudentEnroll] ([ID], [StudentID], [Course], [Date]) VALUES (1, 1, N'CSE-111', CAST(N'2018-06-27' AS Date))
INSERT [dbo].[StudentEnroll] ([ID], [StudentID], [Course], [Date]) VALUES (2, 5, N'CSE-311', CAST(N'2018-06-27' AS Date))
INSERT [dbo].[StudentEnroll] ([ID], [StudentID], [Course], [Date]) VALUES (3, 1, N'CSE-112', CAST(N'2018-06-15' AS Date))
INSERT [dbo].[StudentEnroll] ([ID], [StudentID], [Course], [Date]) VALUES (4, 1, N'CSE-113', CAST(N'2018-06-15' AS Date))
INSERT [dbo].[StudentEnroll] ([ID], [StudentID], [Course], [Date]) VALUES (5, 5, N'CSE-321', CAST(N'2018-06-15' AS Date))
SET IDENTITY_INSERT [dbo].[StudentEnroll] OFF
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([ID], [RegistrationNo], [Name], [Email], [Contact], [Department], [Date], [Address]) VALUES (1, N'CSE-2018-001', N'Sayed Al Zawad', N'sayed@gmail.com', 1131314541, N'CSE', CAST(N'2018-06-06' AS Date), N'Rangpur')
INSERT [dbo].[Students] ([ID], [RegistrationNo], [Name], [Email], [Contact], [Department], [Date], [Address]) VALUES (2, N'CSE-2018-002', N'Md. Robiul', N'robiul@gmail.com', 1131314541, N'CSE', CAST(N'2018-05-06' AS Date), N'Comilla')
INSERT [dbo].[Students] ([ID], [RegistrationNo], [Name], [Email], [Contact], [Department], [Date], [Address]) VALUES (3, N'EEE-2018-001', N'Md. Kamrul', N'kamrul@gmail.com', 1131314541, N'EEE', CAST(N'2018-07-06' AS Date), N'Comilla')
INSERT [dbo].[Students] ([ID], [RegistrationNo], [Name], [Email], [Contact], [Department], [Date], [Address]) VALUES (4, N'CSE-2017-001', N'Md. Monir', N'monir@gmail.com', 1131314541, N'CSE', CAST(N'2017-06-06' AS Date), N'Comilla')
INSERT [dbo].[Students] ([ID], [RegistrationNo], [Name], [Email], [Contact], [Department], [Date], [Address]) VALUES (5, N'CSE-2018-003', N'Md. Moinul', N'moinul@gmail.com', 1131314541, N'CSE', CAST(N'2018-02-06' AS Date), N'Comilla')
SET IDENTITY_INSERT [dbo].[Students] OFF
SET IDENTITY_INSERT [dbo].[Teachers] ON 

INSERT [dbo].[Teachers] ([ID], [Name], [Email], [Contact], [Department], [Address], [Credit], [Designation]) VALUES (1, N'Monir Hossain', N'monir@gmail.com', 1744214651, N'CSE', N'Nowakhali', 20, 1)
INSERT [dbo].[Teachers] ([ID], [Name], [Email], [Contact], [Department], [Address], [Credit], [Designation]) VALUES (2, N'Md. Torun', N'torun@gmail.com', 0, N'CSE', N'Khulna', 20, 1)
SET IDENTITY_INSERT [dbo].[Teachers] OFF
ALTER TABLE [dbo].[CourseAssignToTeacher]  WITH CHECK ADD FOREIGN KEY([Course])
REFERENCES [dbo].[Courses] ([Code])
GO
ALTER TABLE [dbo].[CourseAssignToTeacher]  WITH CHECK ADD FOREIGN KEY([Teacher])
REFERENCES [dbo].[Teachers] ([ID])
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD FOREIGN KEY([Department])
REFERENCES [dbo].[Departments] ([Code])
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD FOREIGN KEY([Samester])
REFERENCES [dbo].[Samesters] ([NO])
GO
ALTER TABLE [dbo].[Results]  WITH CHECK ADD FOREIGN KEY([Course])
REFERENCES [dbo].[Courses] ([Code])
GO
ALTER TABLE [dbo].[Results]  WITH CHECK ADD FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([ID])
GO
ALTER TABLE [dbo].[RoomAllocation]  WITH CHECK ADD FOREIGN KEY([Course])
REFERENCES [dbo].[Courses] ([Code])
GO
ALTER TABLE [dbo].[RoomAllocation]  WITH CHECK ADD FOREIGN KEY([Room])
REFERENCES [dbo].[Rooms] ([RoomNO])
GO
ALTER TABLE [dbo].[StudentEnroll]  WITH CHECK ADD FOREIGN KEY([Course])
REFERENCES [dbo].[Courses] ([Code])
GO
ALTER TABLE [dbo].[StudentEnroll]  WITH CHECK ADD FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([ID])
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD FOREIGN KEY([Department])
REFERENCES [dbo].[Departments] ([Code])
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD FOREIGN KEY([Department])
REFERENCES [dbo].[Departments] ([Code])
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD FOREIGN KEY([Designation])
REFERENCES [dbo].[Designations] ([ID])
GO
USE [master]
GO
ALTER DATABASE [UniversityCRMS] SET  READ_WRITE 
GO
