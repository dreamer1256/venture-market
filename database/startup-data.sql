USE Venture_Market

SET IDENTITY_INSERT Startup ON
INSERT Startup(ID,Title,Business_Model,Competitors,Marketing_Strategy,Total_Investment,Website,IncubatorID,Development_StageID) VALUES
(1,N'Cardiomo',N'Fee in',NULL,N'Product',0,N'Cardiomo.com',2,2),
(2,N'VoltyCO',N'Free in',3,N'Product',0,N'Volty.com',1,1),
(3,N'Green Wheels',N'Franchise',2,N'pricing',0,N'WheelsG.com',1,2),
(4,N'intubus',N'Free in',5,N'Product',0,N'intubus.com',3,2),
(5,N'mymobstr',N'Free in',4,N'Product',0,N'mymo.com',1,1),
(6,N'Infinity',N'Free in',5,N'Product',0,N'Infinity-W.com',NULL,1),
(7,N'NoName',N'Free in',1,N'Franchise',0,N'NoName-club.com',NULL,1),
(8,N'Ark',N'Free in',3,N'Product',0,N'ark.com',NULL,1),
(9,N'Arpen',N'Free in',2,N'Franchise',0,N'Arpen.com',NULL,1)
SET IDENTITY_INSERT Startup OFF
