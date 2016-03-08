USE Venture_Market

SET IDENTITY_INSERT Application ON
INSERT Application (ID,ManagerID,StartupID,State,Application_Round) VALUES
(1,2,3,N'considered',1),
(2,1,4,N'accepted',1),
(3,4,4,N'rejected',2),
(4,3,1,N'rejected',1),
(5,9,2,N'accepted',1),
(6,8,2,N'considered',2),
(7,7,5,N'rejected',1),
(8,6,1,N'accepted',1),
(9,5,3,N'accepted',1)
SET IDENTITY_INSERT Application OFF
