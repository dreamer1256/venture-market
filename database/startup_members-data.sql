USE Venture_Market

SET IDENTITY_INSERT Startup_Members ON
INSERT Startup_Members (ID,StartupID,UserID,Country,Is_CEO,Skype) VALUES
(1,1,7,N'Canada',1,N'donna.morrison'),
(2,1,9,N'Canada',0,N'chloe.campbell'),
(3,1,18,N'Canada',0,NULL),
(4,1,19,N'Canada',0,NULL),
(5,2,20,N'Poland',1,N'FionaChapman'),
(6,2,21,N'Poland',0,NULL),
(7,2,22,N'Poland',0,N'elizabeth.kelly'),
(8,2,23,N'Poland',0,NULL),
(9,2,24,N'Poland',0,NULL),
(10,3,25,N'Ukraine',1,N'amy.ogden'),
(11,3,26,N'Ukraine',0,N'michael.campbell'),
(12,3,27,N'Ukraine',0,N'andrea.davidson'),
(13,4,28,N'USA',1,N'benjamin.mitchell'),
(14,4,29,N'USA',0,NULL),
(15,4,30,N'USA',0,N'thomas.alsop'),
(16,4,31,N'USA',0,N'john.arnold'),
(17,5,32,N'UK',1,N'natalie.nolan'),
(18,5,33,N'UK',0,NULL),
(19,5,34,N'UK',0,N'karen.berry'),
(20,5,35,N'UK',0,NULL)
SET IDENTITY_INSERT Startup_Members OFF

SELECT * FROM Startup_Members