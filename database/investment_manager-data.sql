USE Venture_Market

SET IDENTITY_INSERT Investment_Manager ON
INSERT Investment_Manager(ID,Investment_CompanyID,UserID,Fname,LName) VALUES
(1,2,4,N'Leonard',N'Dickens'),
(2,3,1,N'Colin',N'Cornish'),
(3,1,6,N'Dorothy',N'Ince'),
(4,2,11,N'Trevor',N'Gill'),
(5,2,12,N'Victoria',N'Ince'),
(6,3,13,N'David',N'Jones'),
(7,3,14,N'Edward',N'Reid'),
(8,1,15,N'Donna',N'Buckland'),
(9,1,16,N'Jack',N'Avery')
SET IDENTITY_INSERT Investment_Manager OFF
