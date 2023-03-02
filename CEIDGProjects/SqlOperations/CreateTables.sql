IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'[IntegracjaCEIDGREGON].dbo.raport_regon_cidg')
            create table [IntegracjaCEIDGREGON].dbo.raport_regon_cidg (Id bigint NOT NULL IDENTITY(1,1) ,dane_xml varchar(max) NOT NULL,
            data_pobrania datetime NOT NULL, id_kontrahenta bigint);

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'[IntegracjaCEIDGREGON].dbo.WinSlowniki')
            create table [IntegracjaCEIDGREGON].dbo.WinSlowniki (Id bigint NOT NULL IDENTITY(1,1) ,nazwaRaportu varchar(500) UNIQUE NOT NULL,
            Opis varchar(max) NOT NULL, NazwaSkrocona varchar(max) NOT NULL, typRaportu tinyint NOT NULL,
            UNIQUE(nazwaRaportu));