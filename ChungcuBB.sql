USE [ChungcuBB]
GO
/****** Object:  Table [dbo].[Quanly]    Script Date: 21/04/2021 12:04:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quanly](
	[taikhoan] [nvarchar](50) NOT NULL,
	[matkhau] [nvarchar](50) NULL,
 CONSTRAINT [PK_Quanly] PRIMARY KEY CLUSTERED 
(
	[taikhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Quanly] ([taikhoan], [matkhau]) VALUES (N'nt0609', N'nt0609')
INSERT [dbo].[Quanly] ([taikhoan], [matkhau]) VALUES (N'ta2510', N'ta2510')
GO
