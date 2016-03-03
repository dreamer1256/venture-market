USE Venture_Market

SET IDENTITY_INSERT Startup ON
INSERT Startup(ID,Title,Business_Model,Competitors,Marketing_Strategy,Total_Investment,Website,IncubatorID,Development_StageID) VALUES
(1,N'Cardiomo',N'Fee in',NULL,N'Product',55000,N'Cardiomo.com',2,2),
(2,N'VoltyCO',N'Free in',3,N'Product',50000,N'Volty.com',1,1),
(3,N'Green Wheels',N'Franchise',2,N'pricing',15000,N'WheelsG.com',1,2),
(4,N'intubus',N'Free in',5,N'Product',300000,N'intubus.com',3,2),
(5,N'mymobstr',N'Free in',4,N'Product',42000,N'mymo.com',1,1)
SET IDENTITY_INSERT Startup OFF
