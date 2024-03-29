USE [FarmEasy]
GO
/****** Object:  Table [dbo].[CropDetails]    Script Date: 15-06-2020 08:04:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CropDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Temperature_Min] [real] NOT NULL,
	[Temperature_Max] [real] NOT NULL,
	[CropName] [nvarchar](max) NULL,
 CONSTRAINT [PK_CropDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CropSoilMappings]    Script Date: 15-06-2020 08:04:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CropSoilMappings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CropId] [int] NOT NULL,
	[SoilId] [int] NOT NULL,
 CONSTRAINT [PK_CropSoilMappings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SoilTypes]    Script Date: 15-06-2020 08:04:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SoilTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SoilName] [nvarchar](max) NULL,
	[SoilDetails] [nvarchar](max) NULL,
 CONSTRAINT [PK_SoilTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CropDetails] ON 

INSERT [dbo].[CropDetails] ([Id], [Temperature_Min], [Temperature_Max], [CropName]) VALUES (2, 15, 27, N'Rice')
INSERT [dbo].[CropDetails] ([Id], [Temperature_Min], [Temperature_Max], [CropName]) VALUES (3, 27, 32, N'Jowar')
INSERT [dbo].[CropDetails] ([Id], [Temperature_Min], [Temperature_Max], [CropName]) VALUES (4, 12, 25, N'Wheat')
INSERT [dbo].[CropDetails] ([Id], [Temperature_Min], [Temperature_Max], [CropName]) VALUES (5, 25, 30, N'Gram')
INSERT [dbo].[CropDetails] ([Id], [Temperature_Min], [Temperature_Max], [CropName]) VALUES (6, 18, 27, N'Cotton')
INSERT [dbo].[CropDetails] ([Id], [Temperature_Min], [Temperature_Max], [CropName]) VALUES (7, 20, 30, N'Groundnut')
INSERT [dbo].[CropDetails] ([Id], [Temperature_Min], [Temperature_Max], [CropName]) VALUES (8, 15, 27, N'Maize')
INSERT [dbo].[CropDetails] ([Id], [Temperature_Min], [Temperature_Max], [CropName]) VALUES (9, 25, 35, N'Clove')
INSERT [dbo].[CropDetails] ([Id], [Temperature_Min], [Temperature_Max], [CropName]) VALUES (11, 15, 40, N'Black Pepper')
INSERT [dbo].[CropDetails] ([Id], [Temperature_Min], [Temperature_Max], [CropName]) VALUES (12, 22, 33, N'Oil-palm')
INSERT [dbo].[CropDetails] ([Id], [Temperature_Min], [Temperature_Max], [CropName]) VALUES (14, 18, 22, N'Fruits')
INSERT [dbo].[CropDetails] ([Id], [Temperature_Min], [Temperature_Max], [CropName]) VALUES (15, 18, 24, N'Vegetables')
INSERT [dbo].[CropDetails] ([Id], [Temperature_Min], [Temperature_Max], [CropName]) VALUES (16, 10, 24, N'Sweet Potato')
INSERT [dbo].[CropDetails] ([Id], [Temperature_Min], [Temperature_Max], [CropName]) VALUES (17, 15, 40, N'SugarCane')
INSERT [dbo].[CropDetails] ([Id], [Temperature_Min], [Temperature_Max], [CropName]) VALUES (18, 20, 33, N'Coconut')
INSERT [dbo].[CropDetails] ([Id], [Temperature_Min], [Temperature_Max], [CropName]) VALUES (19, 20, 30, N'Turmeric')
SET IDENTITY_INSERT [dbo].[CropDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[CropSoilMappings] ON 

INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (1, 2, 4)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (2, 2, 5)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (3, 2, 6)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (4, 2, 9)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (5, 3, 4)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (6, 3, 5)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (7, 4, 4)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (8, 4, 9)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (9, 4, 14)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (10, 5, 4)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (11, 5, 5)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (12, 6, 4)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (13, 6, 6)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (14, 6, 13)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (15, 6, 14)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (16, 7, 5)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (17, 7, 7)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (18, 8, 5)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (19, 8, 7)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (20, 9, 12)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (21, 10, 12)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (22, 11, 10)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (23, 12, 11)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (24, 13, 6)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (25, 13, 9)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (26, 13, 13)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (27, 14, 6)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (28, 14, 9)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (29, 15, 6)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (30, 15, 9)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (31, 15, 13)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (32, 16, 11)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (33, 16, 13)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (34, 17, 6)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (35, 17, 9)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (36, 17, 13)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (37, 18, 10)
INSERT [dbo].[CropSoilMappings] ([Id], [CropId], [SoilId]) VALUES (38, 19, 10)
SET IDENTITY_INSERT [dbo].[CropSoilMappings] OFF
GO
SET IDENTITY_INSERT [dbo].[SoilTypes] ON 

INSERT [dbo].[SoilTypes] ([Id], [SoilName], [SoilDetails]) VALUES (4, N'Shallow black soils', N'Shallow black soils have been developed from the basaltic trap in Saurashtra and the Deccan trap in extreme eastern part while the remaining strips in Chhotaudepur and Saurashtra districts have been developed from granite and gneiss parent material. The depth of soil ranges from a few cm to 30 cm. (Gujarat State Agricultural Marketing Board (GSAMB) 2007). Shallow black soils are light grey in colour and mainly sandy clay loam in texture. The soil is poor in fertility. ')
INSERT [dbo].[SoilTypes] ([Id], [SoilName], [SoilDetails]) VALUES (5, N'Medium black soil', N' Medium black soils have a basaltic trap parent material. Such soils in some
parts of Sabarkantha and Panchmahals have been also developed from the granite and gneiss
parent material. These soils vary in depth from 30 to 60 cm. They are calcareous in nature except
in the Panchmahals and Sabarkantha districts. A layer of murum (unconsolidated material of
decomposed trap and limestone) is found below a depth of about 40 cm, especially in the
Saurashtra region (GSAMB 2007). The soils are silt loam to clay in texture and neutral to
alkaline in reaction. These soils are adequately supplied with potassium and poorly supplied with
phosphorous and nitrogen. ')
INSERT [dbo].[SoilTypes] ([Id], [SoilName], [SoilDetails]) VALUES (6, N'Deep black soils', N'The districts of Bharuch, Surat, Valsad and southern part of Vadodara, and
the Bhal region have deep black soils. Similarly, in the Ghed tract of Junagadh districts mostly
covering the talukas of Porbandar, Kutiyana, and Manavadar and part of the Mangrol taluka, the
deep black soils have been formed due to the deposition of basaltic trap materials transported by
the rivers Bhadar, Minsar, Osat Madhuvanti etc. They have faced the problem of salinity and
alkalinity. They are also impregnated with a fairly high amount of free lime. The soils are dark
brown to very dark greyish brown in colour. They contain 40 to 70 percent clay minerals. The
deep black soils, in general, are clay-like in texture, poor in drainage, and neutral to alkaline in
reaction. These soils are most fertile soil in Black soils. ')
INSERT [dbo].[SoilTypes] ([Id], [SoilName], [SoilDetails]) VALUES (7, N'Mixed red and black soils', N'The mixed red and black soils are shallow in depth with reddish
brown colour at higher and greyish brown colour at lower elevations. Texturally, they are clay
loam to clay and skeletal in nature, with stony material as high as 50 percent in subsurface layer.
This provides an ideal drainage conditions for these soils. The soils are highly calcareous in
nature and alkaline in reaction. The soils are low in available nitrogen, medium in phosphorus,
and high in potassium (GSAMB 2007).')
INSERT [dbo].[SoilTypes] ([Id], [SoilName], [SoilDetails]) VALUES (8, N'Lateritic soil', N'True laterites in the real sense of the term don"t occur in Gujarat. However, in the Dangs district,
which has an abundant forest vegetation and high annual precipitation of about 250 cm, lateritic 
soils have developed. They support good forests. Clayey in texture they become hard within
hours of receiving irrigation and rainfall. 
')
INSERT [dbo].[SoilTypes] ([Id], [SoilName], [SoilDetails]) VALUES (9, N'Alluvial soils', N'These soils are very deep. These soils are further divided into alluvial sandy to sandy loam soils,
alluvial sandy loam to sandy clay loam, and coastal alluvial soil.')
INSERT [dbo].[SoilTypes] ([Id], [SoilName], [SoilDetails]) VALUES (10, N'Alluvial sandy to sandy loam soils', N'These soils cover all the northern districts, namely,
Banaskantha and Mehsana except the southern part and the area of Sabarkantha bordering the
Kheralu and Vijapur talukas of Mehsana district. The original alluvial material in Banaskantha
and some parts of the Mehsana district has been overlaid by sandy material brought in by the
winds blowing through the desert of Kutch. From a fertility point of view, these soils are low in
available nutrients.')
INSERT [dbo].[SoilTypes] ([Id], [SoilName], [SoilDetails]) VALUES (11, N'Alluvial sandy loam to sandy clay loam', N' Alluvial sandy loam to sandy clay soils are found in
the Kheda, Gandhinagar, Ahmadabad and Mehsana district and the western part of the Vadodara
district. These soils are the most productive soils in the state and contains fairly good amount of
potassium. ')
INSERT [dbo].[SoilTypes] ([Id], [SoilName], [SoilDetails]) VALUES (12, N'Coastal alluvial soils', N'The coastal alluvial soils are sandy clay loam to clay in texture. The
fertility of this type of soil is of medium class.')
INSERT [dbo].[SoilTypes] ([Id], [SoilName], [SoilDetails]) VALUES (13, N'Hill soils', N'This type of soil occurs in the hilly areas and eastern strip of the mainland Gujarat. The soil
profile is not well developed due to steep slope and erosion. Soil is shallow in depth formed by
undecomposed rock and poor in fertility. Hill soils have been developed from parent materials
existing in the respective areas. Shallow and composed of undecomposed rock fragments, they
are poor in fertility. ')
INSERT [dbo].[SoilTypes] ([Id], [SoilName], [SoilDetails]) VALUES (14, N'Desert soils', N'Desert soil is generally found in the little and greater desert of Kutch. The soil is deep and light
grey in colour with no definite structure. It is sandy to sandy loam with silt clay loam in
structure. This type of salt has high salt content and sufficient amount of gypsum in the soil
profile. ')
SET IDENTITY_INSERT [dbo].[SoilTypes] OFF
GO
