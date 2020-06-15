IF NOT EXISTS(SELECT 1 FROM [dbo].[SoilTypes] WHERE [SoilName] = 'Shallow black soils') BEGIN INSERT INTO [dbo].[SoilTypes] ([SoilName],[SoilDetails]) values('Shallow black soils','Shallow black soils have been developed from the basaltic trap in Saurashtra and the Deccan trap in extreme eastern part while the remaining strips in Chhotaudepur and Saurashtra districts have been developed from granite and gneiss parent material. The depth of soil ranges from a few cm to 30 cm. (Gujarat State Agricultural Marketing Board (GSAMB) 2007). Shallow black soils are light grey in colour and mainly sandy clay loam in texture. The soil is poor in fertility. ') END
IF NOT EXISTS(SELECT 1 FROM [dbo].[SoilTypes] WHERE [SoilName] = 'Medium black soil') BEGIN INSERT INTO [dbo].[SoilTypes] ([SoilName],[SoilDetails]) values('Medium black soil',' Medium black soils have a basaltic trap parent material. Such soils in some
parts of Sabarkantha and Panchmahals have been also developed from the granite and gneiss
parent material. These soils vary in depth from 30 to 60 cm. They are calcareous in nature except
in the Panchmahals and Sabarkantha districts. A layer of murum (unconsolidated material of
decomposed trap and limestone) is found below a depth of about 40 cm, especially in the
Saurashtra region (GSAMB 2007). The soils are silt loam to clay in texture and neutral to
alkaline in reaction. These soils are adequately supplied with potassium and poorly supplied with
phosphorous and nitrogen. ') END
IF NOT EXISTS(SELECT 1 FROM [dbo].[SoilTypes] WHERE [SoilName] = 'Deep black soils') BEGIN INSERT INTO [dbo].[SoilTypes] ([SoilName],[SoilDetails]) values('Deep black soils','The districts of Bharuch, Surat, Valsad and southern part of Vadodara, and
the Bhal region have deep black soils. Similarly, in the Ghed tract of Junagadh districts mostly
covering the talukas of Porbandar, Kutiyana, and Manavadar and part of the Mangrol taluka, the
deep black soils have been formed due to the deposition of basaltic trap materials transported by
the rivers Bhadar, Minsar, Osat Madhuvanti etc. They have faced the problem of salinity and
alkalinity. They are also impregnated with a fairly high amount of free lime. The soils are dark
brown to very dark greyish brown in colour. They contain 40 to 70 percent clay minerals. The
deep black soils, in general, are clay-like in texture, poor in drainage, and neutral to alkaline in
reaction. These soils are most fertile soil in Black soils. ') END
IF NOT EXISTS(SELECT 1 FROM [dbo].[SoilTypes] WHERE [SoilName] = 'Mixed red and black soils') BEGIN INSERT INTO [dbo].[SoilTypes] ([SoilName],[SoilDetails]) values('Mixed red and black soils','The mixed red and black soils are shallow in depth with reddish
brown colour at higher and greyish brown colour at lower elevations. Texturally, they are clay
loam to clay and skeletal in nature, with stony material as high as 50 percent in subsurface layer.
This provides an ideal drainage conditions for these soils. The soils are highly calcareous in
nature and alkaline in reaction. The soils are low in available nitrogen, medium in phosphorus,
and high in potassium (GSAMB 2007).') END
IF NOT EXISTS(SELECT 1 FROM [dbo].[SoilTypes] WHERE [SoilName] = 'Lateritic soil') BEGIN INSERT INTO [dbo].[SoilTypes] ([SoilName],[SoilDetails]) values('Lateritic soil','True laterites in the real sense of the term don"t occur in Gujarat. However, in the Dangs district,
which has an abundant forest vegetation and high annual precipitation of about 250 cm, lateritic 
soils have developed. They support good forests. Clayey in texture they become hard within
hours of receiving irrigation and rainfall. 
') END
IF NOT EXISTS(SELECT 1 FROM [dbo].[SoilTypes] WHERE [SoilName] = 'Alluvial soils') BEGIN INSERT INTO [dbo].[SoilTypes] ([SoilName],[SoilDetails]) values('Alluvial soils','These soils are very deep. These soils are further divided into alluvial sandy to sandy loam soils,
alluvial sandy loam to sandy clay loam, and coastal alluvial soil.') END
IF NOT EXISTS(SELECT 1 FROM [dbo].[SoilTypes] WHERE [SoilName] = 'Alluvial sandy to sandy loam soils') BEGIN INSERT INTO [dbo].[SoilTypes] ([SoilName],[SoilDetails]) values('Alluvial sandy to sandy loam soils','These soils cover all the northern districts, namely,
Banaskantha and Mehsana except the southern part and the area of Sabarkantha bordering the
Kheralu and Vijapur talukas of Mehsana district. The original alluvial material in Banaskantha
and some parts of the Mehsana district has been overlaid by sandy material brought in by the
winds blowing through the desert of Kutch. From a fertility point of view, these soils are low in
available nutrients.') END
IF NOT EXISTS(SELECT 1 FROM [dbo].[SoilTypes] WHERE [SoilName] = 'Alluvial sandy loam to sandy clay loam') BEGIN INSERT INTO [dbo].[SoilTypes] ([SoilName],[SoilDetails]) values('Alluvial sandy loam to sandy clay loam',' Alluvial sandy loam to sandy clay soils are found in
the Kheda, Gandhinagar, Ahmadabad and Mehsana district and the western part of the Vadodara
district. These soils are the most productive soils in the state and contains fairly good amount of
potassium. ') END
IF NOT EXISTS(SELECT 1 FROM [dbo].[SoilTypes] WHERE [SoilName] = 'Coastal alluvial soils') BEGIN INSERT INTO [dbo].[SoilTypes] ([SoilName],[SoilDetails]) values('Coastal alluvial soils','The coastal alluvial soils are sandy clay loam to clay in texture. The
fertility of this type of soil is of medium class.') END
IF NOT EXISTS(SELECT 1 FROM [dbo].[SoilTypes] WHERE [SoilName] = 'Hill soils') BEGIN INSERT INTO [dbo].[SoilTypes] ([SoilName],[SoilDetails]) values('Hill soils','This type of soil occurs in the hilly areas and eastern strip of the mainland Gujarat. The soil
profile is not well developed due to steep slope and erosion. Soil is shallow in depth formed by
undecomposed rock and poor in fertility. Hill soils have been developed from parent materials
existing in the respective areas. Shallow and composed of undecomposed rock fragments, they
are poor in fertility. ') END
IF NOT EXISTS(SELECT 1 FROM [dbo].[SoilTypes] WHERE [SoilName] = 'Desert soils') BEGIN INSERT INTO [dbo].[SoilTypes] ([SoilName],[SoilDetails]) values('Desert soils','Desert soil is generally found in the little and greater desert of Kutch. The soil is deep and light
grey in colour with no definite structure. It is sandy to sandy loam with silt clay loam in
structure. This type of salt has high salt content and sufficient amount of gypsum in the soil
profile. ') END