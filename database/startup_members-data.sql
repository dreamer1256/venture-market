USE Venture_Market

SET IDENTITY_INSERT Startup_Members ON
INSERT Startup_Members (ID,StartupID,UserID,FName,LName,Country,Is_CEO,Skype) VALUES
(1,1,7,N'Donna',N'Morrison',N'Canada',1,N'donna.morrison'),
(2,1,9,N'Chloe',N'Campbell',N'Canada',0,N'chloe.campbell'),
(3,1,18,N'Jane',N'Wright',N'Canada',0,NULL),
(4,1,19,N'Sally',N'Newman',N'Canada',0,NULL),
(5,2,20,N'Fiona',N'Chapman',N'Poland',1,N'FionaChapman'),
(6,2,21,N'Gabrielle',N'Davies',N'Poland',0,NULL),
(7,2,22,N'Elizabeth',N'Kelly',N'Poland',0,N'elizabeth.kelly'),
(8,2,23,N'Joanne',N'Piper',N'Poland',0,NULL),
(9,2,24,N'Austin',N'Peters',N'Poland',0,NULL),
(10,3,25,N'Amy',N'Ogden',N'Ukraine',1,N'amy.ogden'),
(11,3,26,N'Michael',N'Campbell',N'Ukraine',0,N'michael.campbell'),
(12,3,27,N'Andrea',N'Davidson',N'Ukraine',0,N'andrea.davidson'),
(13,4,28,N'Benjamin',N'Mitchell',N'USA',1,N'benjamin.mitchell'),
(14,4,29,N'Dan',N'Parsons',N'USA',0,NULL),
(15,4,30,N'Thomas',N'Alsop',N'USA',0,N'thomas.alsop'),
(16,4,31,N'John',N'Arnold',N'USA',0,N'john.arnold'),
(17,5,32,N'Natalie',N'Nolan',N'UK',1,N'natalie.nolan'),
(18,5,33,N'Connor',N'Black',N'UK',0,NULL),
(19,5,34,N'Karen',N'Berry',N'UK',0,N'karen.berry'),
(20,5,35,N'Molly',N'Wright',N'UK',0,NULL)
SET IDENTITY_INSERT Startup_Members OFF

SELECT * FROM Startup_Members