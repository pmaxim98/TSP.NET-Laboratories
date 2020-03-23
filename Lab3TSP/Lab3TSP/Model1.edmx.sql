
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/10/2020 20:25:50
-- Generated from EDMX file: C:\Visual Studio Projects\Lab3TSP\Lab3TSP\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TestPerson];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CustomerOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderSet] DROP CONSTRAINT [FK_CustomerOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_AlbumArtist_Album]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AlbumArtist] DROP CONSTRAINT [FK_AlbumArtist_Album];
GO
IF OBJECT_ID(N'[dbo].[FK_AlbumArtist_Artist]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AlbumArtist] DROP CONSTRAINT [FK_AlbumArtist_Artist];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[People]', 'U') IS NOT NULL
    DROP TABLE [dbo].[People];
GO
IF OBJECT_ID(N'[dbo].[CustomerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerSet];
GO
IF OBJECT_ID(N'[dbo].[OrderSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderSet];
GO
IF OBJECT_ID(N'[dbo].[AlbumSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AlbumSet];
GO
IF OBJECT_ID(N'[dbo].[ArtistSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ArtistSet];
GO
IF OBJECT_ID(N'[dbo].[AlbumArtist]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AlbumArtist];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'People'
CREATE TABLE [dbo].[People] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(10)  NOT NULL,
    [LastName] nvarchar(10)  NOT NULL,
    [MiddleName] nvarchar(10)  NOT NULL,
    [TelephoneNumber] nvarchar(10)  NOT NULL
);
GO

-- Creating table 'CustomerSet'
CREATE TABLE [dbo].[CustomerSet] (
    [CustomerId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [City] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'OrderSet'
CREATE TABLE [dbo].[OrderSet] (
    [OrderId] int IDENTITY(1,1) NOT NULL,
    [TotalValue] decimal(12,2)  NOT NULL,
    [Date] datetime  NOT NULL,
    [CustomerCustomerId] int  NOT NULL
);
GO

-- Creating table 'AlbumSet'
CREATE TABLE [dbo].[AlbumSet] (
    [AlbumId] int IDENTITY(1,1) NOT NULL,
    [AlbumName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ArtistSet'
CREATE TABLE [dbo].[ArtistSet] (
    [ArtistId] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AlbumArtist'
CREATE TABLE [dbo].[AlbumArtist] (
    [Album_AlbumId] int  NOT NULL,
    [Artist_ArtistId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [PK_People]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [CustomerId] in table 'CustomerSet'
ALTER TABLE [dbo].[CustomerSet]
ADD CONSTRAINT [PK_CustomerSet]
    PRIMARY KEY CLUSTERED ([CustomerId] ASC);
GO

-- Creating primary key on [OrderId] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [PK_OrderSet]
    PRIMARY KEY CLUSTERED ([OrderId] ASC);
GO

-- Creating primary key on [AlbumId] in table 'AlbumSet'
ALTER TABLE [dbo].[AlbumSet]
ADD CONSTRAINT [PK_AlbumSet]
    PRIMARY KEY CLUSTERED ([AlbumId] ASC);
GO

-- Creating primary key on [ArtistId] in table 'ArtistSet'
ALTER TABLE [dbo].[ArtistSet]
ADD CONSTRAINT [PK_ArtistSet]
    PRIMARY KEY CLUSTERED ([ArtistId] ASC);
GO

-- Creating primary key on [Album_AlbumId], [Artist_ArtistId] in table 'AlbumArtist'
ALTER TABLE [dbo].[AlbumArtist]
ADD CONSTRAINT [PK_AlbumArtist]
    PRIMARY KEY CLUSTERED ([Album_AlbumId], [Artist_ArtistId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerCustomerId] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [FK_CustomerOrder]
    FOREIGN KEY ([CustomerCustomerId])
    REFERENCES [dbo].[CustomerSet]
        ([CustomerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerOrder'
CREATE INDEX [IX_FK_CustomerOrder]
ON [dbo].[OrderSet]
    ([CustomerCustomerId]);
GO

-- Creating foreign key on [Album_AlbumId] in table 'AlbumArtist'
ALTER TABLE [dbo].[AlbumArtist]
ADD CONSTRAINT [FK_AlbumArtist_Album]
    FOREIGN KEY ([Album_AlbumId])
    REFERENCES [dbo].[AlbumSet]
        ([AlbumId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Artist_ArtistId] in table 'AlbumArtist'
ALTER TABLE [dbo].[AlbumArtist]
ADD CONSTRAINT [FK_AlbumArtist_Artist]
    FOREIGN KEY ([Artist_ArtistId])
    REFERENCES [dbo].[ArtistSet]
        ([ArtistId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AlbumArtist_Artist'
CREATE INDEX [IX_FK_AlbumArtist_Artist]
ON [dbo].[AlbumArtist]
    ([Artist_ArtistId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------