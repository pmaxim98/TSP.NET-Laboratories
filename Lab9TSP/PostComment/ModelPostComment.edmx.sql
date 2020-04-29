
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/28/2020 23:58:50
-- Generated from EDMX file: E:\Visual Studio Projects\GrpcGreeter\PostComment\ModelPostComment.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ModelPostComment];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PostComment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_PostComment];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Posts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Posts];
GO
IF OBJECT_ID(N'[dbo].[Comments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comments];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Posts'
CREATE TABLE [dbo].[Posts] (
    [PostId] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Domain] nvarchar(max)  NOT NULL,
    [Date] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Comments'
CREATE TABLE [dbo].[Comments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [PostPostId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [PostId] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [PK_Posts]
    PRIMARY KEY CLUSTERED ([PostId] ASC);
GO

-- Creating primary key on [Id] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [PK_Comments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PostPostId] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_PostComment]
    FOREIGN KEY ([PostPostId])
    REFERENCES [dbo].[Posts]
        ([PostId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PostComment'
CREATE INDEX [IX_FK_PostComment]
ON [dbo].[Comments]
    ([PostPostId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------