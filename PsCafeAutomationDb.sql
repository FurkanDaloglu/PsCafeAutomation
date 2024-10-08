USE [PsCafeAutomationDb]
GO
/****** Object:  Table [dbo].[TBLHareketler]    Script Date: 24.09.2024 16:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLHareketler](
	[HareketlerID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciID] [int] NOT NULL,
	[MasaID] [int] NOT NULL,
	[Masa] [varchar](50) NOT NULL,
	[Aciklama] [varchar](100) NULL,
	[Tarih] [datetime] NOT NULL,
	[Tutar] [decimal](10, 2) NULL,
 CONSTRAINT [PK_TBLHareketler] PRIMARY KEY CLUSTERED 
(
	[HareketlerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBLIcecekler]    Script Date: 24.09.2024 16:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLIcecekler](
	[IcecekID] [int] IDENTITY(1,1) NOT NULL,
	[IcecekIsmi] [nvarchar](100) NOT NULL,
	[Fiyat] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IcecekID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBLKullanici]    Script Date: 24.09.2024 16:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLKullanici](
	[KullaniciID] [int] IDENTITY(1,1) NOT NULL,
	[AdiSoyadi] [varchar](150) NOT NULL,
	[Telefon] [varchar](50) NULL,
	[Adres] [varchar](150) NULL,
	[Email] [varchar](150) NULL,
	[KullaniciAdi] [varchar](50) NOT NULL,
	[Sifre] [varchar](50) NOT NULL,
	[Gorevi] [varchar](50) NOT NULL,
	[Tarih] [datetime] NOT NULL,
 CONSTRAINT [PK_TBLKullanici] PRIMARY KEY CLUSTERED 
(
	[KullaniciID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBLMasaIcecekler]    Script Date: 24.09.2024 16:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLMasaIcecekler](
	[MasaIcecekID] [int] IDENTITY(1,1) NOT NULL,
	[MasaID] [int] NULL,
	[IcecekID] [int] NULL,
	[Fiyat] [decimal](18, 2) NULL,
	[Durum] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MasaIcecekID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBLMasalar]    Script Date: 24.09.2024 16:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLMasalar](
	[MasaID] [int] IDENTITY(1,1) NOT NULL,
	[Masalar] [varchar](50) NOT NULL,
	[Durumu] [varchar](50) NOT NULL,
	[Aciklama] [nchar](10) NULL,
 CONSTRAINT [PK_TBLMasalar] PRIMARY KEY CLUSTERED 
(
	[MasaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBLSaatUcreti]    Script Date: 24.09.2024 16:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLSaatUcreti](
	[SaatUcretiID] [int] IDENTITY(1,1) NOT NULL,
	[SaatUcreti] [decimal](18, 2) NOT NULL,
	[UcretTuru] [varchar](50) NOT NULL,
	[Aciklama] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TBLSaatUcreti] PRIMARY KEY CLUSTERED 
(
	[SaatUcretiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBLSatis]    Script Date: 24.09.2024 16:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLSatis](
	[SatisID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciID] [int] NOT NULL,
	[MasaID] [int] NOT NULL,
	[BaslangicSaati] [datetime] NOT NULL,
	[BitisSaati] [datetime] NOT NULL,
	[Sure] [decimal](18, 2) NOT NULL,
	[Tutar] [decimal](18, 2) NOT NULL,
	[Aciklama] [varchar](150) NULL,
	[Tarih] [datetime] NOT NULL,
 CONSTRAINT [PK_TBLSatis] PRIMARY KEY CLUSTERED 
(
	[SatisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBLSepet]    Script Date: 24.09.2024 16:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLSepet](
	[SepetID] [int] IDENTITY(1,1) NOT NULL,
	[MasaID] [int] NOT NULL,
	[Masa] [varchar](50) NOT NULL,
	[AcilisTuru] [varchar](50) NOT NULL,
	[Baslangic] [datetime] NOT NULL,
	[Tarih] [datetime] NOT NULL,
	[Bitis] [datetime] NULL,
 CONSTRAINT [PK_TBLSepet] PRIMARY KEY CLUSTERED 
(
	[SepetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TBLMasaIcecekler] ADD  DEFAULT ('AKTİF') FOR [Durum]
GO
ALTER TABLE [dbo].[TBLMasaIcecekler]  WITH CHECK ADD FOREIGN KEY([IcecekID])
REFERENCES [dbo].[TBLIcecekler] ([IcecekID])
GO
ALTER TABLE [dbo].[TBLMasaIcecekler]  WITH CHECK ADD FOREIGN KEY([MasaID])
REFERENCES [dbo].[TBLMasalar] ([MasaID])
GO
