USE Venture_Market

SET IDENTITY_INSERT Application ON
INSERT Application (ID,ManagerID,StartupID,State,Application_Round) VALUES
(1,2,5,N'considered',1),
(2,1,4,N'accepted',1),
(3,4,3,N'rejected',2),
(4,3,2,N'rejected',1),
(5,9,1,N'accepted',1),
(6,NULL,6,N'no state',0),
(7,NULL,7,N'no state',0),
(8,NULL,8,N'no state',0),
(9,NULL,9,N'no state',0)
SET IDENTITY_INSERT Application OFF
