
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/02/2021 12:23:13
-- Generated from EDMX file: C:\Users\diggy\source\repos\4.semester\Eksamen-Auktion-folder\EksamensProjekt-Auktion\AuktionsEntity\Model\AuktionsModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Auktions];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_KundeSetKoebstilbudSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KoebstilbudSet] DROP CONSTRAINT [FK_KundeSetKoebstilbudSet];
GO
IF OBJECT_ID(N'[dbo].[FK_SalgsudbudSetKoebstilbudSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KoebstilbudSet] DROP CONSTRAINT [FK_SalgsudbudSetKoebstilbudSet];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[KoebstilbudSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KoebstilbudSet];
GO
IF OBJECT_ID(N'[dbo].[KundeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KundeSet];
GO
IF OBJECT_ID(N'[dbo].[SalgsudbudSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SalgsudbudSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'KoebstilbudSet'
CREATE TABLE [dbo].[KoebstilbudSet] (
    [KoebstilbudId] int IDENTITY(1,1) NOT NULL,
    [Pris] int  NOT NULL,
    [OpretningsDato] datetime  NOT NULL,
    [KundeSet_Email] nvarchar(400)  NOT NULL,
    [SalgsudbudSet_SalgsudbudId] int  NOT NULL
);
GO

-- Creating table 'KundeSet'
CREATE TABLE [dbo].[KundeSet] (
    [Navn] nvarchar(max)  NOT NULL,
    [Tlf] int  NOT NULL,
    [Email] nvarchar(400)  NOT NULL
);
GO

-- Creating table 'SalgsudbudSet'
CREATE TABLE [dbo].[SalgsudbudSet] (
    [SalgsudbudId] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Maengde] int  NOT NULL,
    [Tidsfrist] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [KoebstilbudId] in table 'KoebstilbudSet'
ALTER TABLE [dbo].[KoebstilbudSet]
ADD CONSTRAINT [PK_KoebstilbudSet]
    PRIMARY KEY CLUSTERED ([KoebstilbudId] ASC);
GO

-- Creating primary key on [Email] in table 'KundeSet'
ALTER TABLE [dbo].[KundeSet]
ADD CONSTRAINT [PK_KundeSet]
    PRIMARY KEY CLUSTERED ([Email] ASC);
GO

-- Creating primary key on [SalgsudbudId] in table 'SalgsudbudSet'
ALTER TABLE [dbo].[SalgsudbudSet]
ADD CONSTRAINT [PK_SalgsudbudSet]
    PRIMARY KEY CLUSTERED ([SalgsudbudId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [KundeSet_Email] in table 'KoebstilbudSet'
ALTER TABLE [dbo].[KoebstilbudSet]
ADD CONSTRAINT [FK_KundeSetKoebstilbudSet]
    FOREIGN KEY ([KundeSet_Email])
    REFERENCES [dbo].[KundeSet]
        ([Email])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KundeSetKoebstilbudSet'
CREATE INDEX [IX_FK_KundeSetKoebstilbudSet]
ON [dbo].[KoebstilbudSet]
    ([KundeSet_Email]);
GO

-- Creating foreign key on [SalgsudbudSet_SalgsudbudId] in table 'KoebstilbudSet'
ALTER TABLE [dbo].[KoebstilbudSet]
ADD CONSTRAINT [FK_SalgsudbudSetKoebstilbudSet]
    FOREIGN KEY ([SalgsudbudSet_SalgsudbudId])
    REFERENCES [dbo].[SalgsudbudSet]
        ([SalgsudbudId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SalgsudbudSetKoebstilbudSet'
CREATE INDEX [IX_FK_SalgsudbudSetKoebstilbudSet]
ON [dbo].[KoebstilbudSet]
    ([SalgsudbudSet_SalgsudbudId]);
GO



-- --------------------------------------------------
-- TestUserData
-- --------------------------------------------------

INSERT INTO [dbo].KundeSet(Navn, Tlf, Email)
VALUES ("Frederik", 51236165, "frederikholmboe@hotmail.com"),
       ("Andreas", 23512352, "andreas@hotmail.com"),
       ("Bjarne", 51235234, "bjarnesmail@hotmail.com")
GO

INSERT INTO [dbo].SalgsudbudSet(Type, Maengde, Tidsfrist)
VALUES ("Guld", 20, "2021-06-30"),
       ("Bronze", 5, "2021-05-04"),
       ("Tin", 4, "2021-04-03"),
       ("Sølv", 19, "2021-06-25")
GO

INSERT INTO [dbo].KoebstilbudSet(Pris, OpretningsDato, KundeSet_Email, SalgsudbudSet_SalgsudbudId)
VALUES (200, "2021-06-04", "frederikholmboe@hotmail.com", 1),
       (400, "2021-06-04", "frederikholmboe@hotmail.com", 4),
       (1200, "2021-05-03", "bjarnesmail@hotmail.com", 2)
GO


-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------