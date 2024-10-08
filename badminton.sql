USE [master]
GO
/****** Object:  Database [BookingBadminton]    Script Date: 10/3/2024 2:37:53 AM ******/
CREATE DATABASE [BookingBadminton]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookingBadminton', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BookingBadminton.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BookingBadminton_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BookingBadminton_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BookingBadminton] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookingBadminton].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookingBadminton] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookingBadminton] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookingBadminton] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookingBadminton] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookingBadminton] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookingBadminton] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookingBadminton] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookingBadminton] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookingBadminton] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookingBadminton] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookingBadminton] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookingBadminton] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookingBadminton] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookingBadminton] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookingBadminton] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BookingBadminton] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookingBadminton] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookingBadminton] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookingBadminton] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookingBadminton] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookingBadminton] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookingBadminton] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookingBadminton] SET RECOVERY FULL 
GO
ALTER DATABASE [BookingBadminton] SET  MULTI_USER 
GO
ALTER DATABASE [BookingBadminton] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookingBadminton] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookingBadminton] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookingBadminton] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookingBadminton] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BookingBadminton] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BookingBadminton', N'ON'
GO
ALTER DATABASE [BookingBadminton] SET QUERY_STORE = ON
GO
ALTER DATABASE [BookingBadminton] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BookingBadminton]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 10/3/2024 2:37:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[BookingID] [varchar](255) NOT NULL,
	[CourtID] [varchar](255) NOT NULL,
	[UserID] [varchar](255) NOT NULL,
	[TypeID] [varchar](255) NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[TotalSlot] [int] NOT NULL,
	[DateOfWeek] [varchar](255) NULL,
	[IsOnline] [bit] NOT NULL,
	[PaymentStatus] [int] NOT NULL,
	[CreateAt] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BookingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookingTypes]    Script Date: 10/3/2024 2:37:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingTypes](
	[TypeID] [varchar](255) NOT NULL,
	[TypeName] [nvarchar](255) NOT NULL,
	[TypeDesc] [nvarchar](255) NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CardProviders]    Script Date: 10/3/2024 2:37:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardProviders](
	[CardProviderName] [nvarchar](255) NOT NULL,
	[CPFullName] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[CardProviderName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CheckIn]    Script Date: 10/3/2024 2:37:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CheckIn](
	[BookingID] [varchar](255) NOT NULL,
	[CheckInTime] [datetime] NOT NULL,
	[IsChecked] [bit] NOT NULL,
	[CheckedBy] [varchar](255) NULL,
	[IsCheckedOut] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[BookingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourtManagers]    Script Date: 10/3/2024 2:37:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourtManagers](
	[ManagerID] [varchar](255) NOT NULL,
	[UserID] [varchar](255) NOT NULL,
	[CardName] [varchar](255) NULL,
	[CardNumber] [varchar](255) NULL,
	[CardProviderName] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ManagerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courts]    Script Date: 10/3/2024 2:37:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courts](
	[CourtID] [varchar](255) NOT NULL,
	[CourtName] [nvarchar](255) NOT NULL,
	[Location] [nvarchar](255) NOT NULL,
	[OpeningHours] [time](7) NOT NULL,
	[ClosingHours] [time](7) NOT NULL,
	[Status] [int] NOT NULL,
	[IsUsing] [bit] NOT NULL,
	[CreateAt] [date] NOT NULL,
	[CreateBy] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CourtID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedbacks]    Script Date: 10/3/2024 2:37:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedbacks](
	[FeedbackID] [varchar](255) NOT NULL,
	[CourtID] [varchar](255) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[Rate] [float] NOT NULL,
	[Attachment] [bigint] NULL,
	[CreateAt] [date] NOT NULL,
	[CreateBy] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FeedbackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 10/3/2024 2:37:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentID] [varchar](255) NOT NULL,
	[BookingID] [varchar](255) NOT NULL,
	[TotalMoney] [float] NOT NULL,
	[PaymentMethod] [nvarchar](255) NOT NULL,
	[PaymentDate] [date] NOT NULL,
	[CreateAt] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reports]    Script Date: 10/3/2024 2:37:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reports](
	[ReportID] [varchar](255) NOT NULL,
	[Issue] [nvarchar](255) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[Attachment] [varchar](255) NULL,
	[CreateAt] [date] NOT NULL,
	[CreateBy] [varchar](255) NOT NULL,
	[CourtID] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ReportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Revenue]    Script Date: 10/3/2024 2:37:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Revenue](
	[RevenueID] [varchar](255) NOT NULL,
	[CourtID] [varchar](255) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Total] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RevenueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RevenueDetails]    Script Date: 10/3/2024 2:37:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RevenueDetails](
	[RDetailID] [varchar](255) NOT NULL,
	[RevenueID] [varchar](255) NOT NULL,
	[Date] [date] NOT NULL,
	[Income] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slots]    Script Date: 10/3/2024 2:37:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slots](
	[SlotID] [varchar](255) NOT NULL,
	[CourtID] [varchar](255) NOT NULL,
	[SlotNumber] [int] NOT NULL,
	[SlotPrice] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SlotID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/3/2024 2:37:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [varchar](255) NOT NULL,
	[Username] [nvarchar](255) NOT NULL,
	[Email] [varchar](255) NULL,
	[Password] [varchar](255) NOT NULL,
	[Gender] [int] NULL,
	[PhoneNumber] [varchar](255) NULL,
	[Address] [nvarchar](255) NULL,
	[Birthday] [date] NULL,
	[Role] [int] NOT NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WishList]    Script Date: 10/3/2024 2:37:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WishList](
	[WishID] [bigint] NOT NULL,
	[CourtID] [varchar](255) NOT NULL,
	[AddBy] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[WishID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([CourtID])
REFERENCES [dbo].[Courts] ([CourtID])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([TypeID])
REFERENCES [dbo].[BookingTypes] ([TypeID])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[CheckIn]  WITH CHECK ADD FOREIGN KEY([BookingID])
REFERENCES [dbo].[Booking] ([BookingID])
GO
ALTER TABLE [dbo].[CheckIn]  WITH CHECK ADD FOREIGN KEY([CheckedBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[CourtManagers]  WITH CHECK ADD FOREIGN KEY([CardProviderName])
REFERENCES [dbo].[CardProviders] ([CardProviderName])
GO
ALTER TABLE [dbo].[CourtManagers]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Courts]  WITH CHECK ADD FOREIGN KEY([CreateBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Feedbacks]  WITH CHECK ADD FOREIGN KEY([CourtID])
REFERENCES [dbo].[Courts] ([CourtID])
GO
ALTER TABLE [dbo].[Feedbacks]  WITH CHECK ADD FOREIGN KEY([CreateBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD FOREIGN KEY([BookingID])
REFERENCES [dbo].[Booking] ([BookingID])
GO
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD FOREIGN KEY([CourtID])
REFERENCES [dbo].[Courts] ([CourtID])
GO
ALTER TABLE [dbo].[Revenue]  WITH CHECK ADD FOREIGN KEY([CourtID])
REFERENCES [dbo].[Courts] ([CourtID])
GO
ALTER TABLE [dbo].[RevenueDetails]  WITH CHECK ADD FOREIGN KEY([RevenueID])
REFERENCES [dbo].[Revenue] ([RevenueID])
GO
ALTER TABLE [dbo].[Slots]  WITH CHECK ADD FOREIGN KEY([CourtID])
REFERENCES [dbo].[Courts] ([CourtID])
GO
ALTER TABLE [dbo].[WishList]  WITH CHECK ADD FOREIGN KEY([AddBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[WishList]  WITH CHECK ADD FOREIGN KEY([CourtID])
REFERENCES [dbo].[Courts] ([CourtID])
GO
USE [master]
GO
ALTER DATABASE [BookingBadminton] SET  READ_WRITE 
GO
