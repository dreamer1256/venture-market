USE Venture_Market
GO
SET IDENTITY_INSERT dbo.Role ON 
INSERT dbo.Role (ID, Role_Title, Role_Description) VALUES
 (1, N'Angel_Investor', N'Бізнес-ангел'),
 (2, N'IC_Member', N'Представник інвестиційної компанії'),
 (3, N'StartupCEO', N'Керівник стартапу'),
 (4, N'Invest_Manager', N'Інвестиційний менеджер'),
 (5, N'Startup_Member', N'Учасник стартапу'),
 (6, N'Admin', N'Адміністратор')

SET IDENTITY_INSERT dbo.Role OFF
