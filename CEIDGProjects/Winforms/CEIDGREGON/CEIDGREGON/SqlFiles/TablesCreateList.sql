IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'[CEIDGREGON].dbo.GUSValues')
            create table [CEIDGREGON].dbo.GUSValues (Id bigint NOT NULL IDENTITY(1,1), XMLValues varchar(max) NOT NULL,
            ImportDate datetime NOT NULL, RaportType tinyint NOT NULL);