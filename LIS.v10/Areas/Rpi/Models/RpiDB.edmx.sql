
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/14/2018 15:41:12
-- Generated from EDMX file: C:\Users\VILLOSA\Documents\GithubClassic\Lis.2018.03\LIS.v10\Areas\Rpi\Models\RpiDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-LIS.v10-20170509105835];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_RpiDeviceRpiDatalog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RpiDatalogs] DROP CONSTRAINT [FK_RpiDeviceRpiDatalog];
GO
IF OBJECT_ID(N'[dbo].[FK_RpiDeviceRpiControl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RpiControls] DROP CONSTRAINT [FK_RpiDeviceRpiControl];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[RpiDevices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RpiDevices];
GO
IF OBJECT_ID(N'[dbo].[RpiDatalogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RpiDatalogs];
GO
IF OBJECT_ID(N'[dbo].[RpiControls]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RpiControls];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'RpiDevices'
CREATE TABLE [dbo].[RpiDevices] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Version] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RpiDatalogs'
CREATE TABLE [dbo].[RpiDatalogs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DtRead] nvarchar(max)  NOT NULL,
    [DataRead] nvarchar(max)  NOT NULL,
    [RpiDeviceId] int  NOT NULL
);
GO

-- Creating table 'RpiControls'
CREATE TABLE [dbo].[RpiControls] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DtSchedule] nvarchar(max)  NOT NULL,
    [Data] nvarchar(max)  NOT NULL,
    [RpiDeviceId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'RpiDevices'
ALTER TABLE [dbo].[RpiDevices]
ADD CONSTRAINT [PK_RpiDevices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RpiDatalogs'
ALTER TABLE [dbo].[RpiDatalogs]
ADD CONSTRAINT [PK_RpiDatalogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RpiControls'
ALTER TABLE [dbo].[RpiControls]
ADD CONSTRAINT [PK_RpiControls]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RpiDeviceId] in table 'RpiDatalogs'
ALTER TABLE [dbo].[RpiDatalogs]
ADD CONSTRAINT [FK_RpiDeviceRpiDatalog]
    FOREIGN KEY ([RpiDeviceId])
    REFERENCES [dbo].[RpiDevices]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RpiDeviceRpiDatalog'
CREATE INDEX [IX_FK_RpiDeviceRpiDatalog]
ON [dbo].[RpiDatalogs]
    ([RpiDeviceId]);
GO

-- Creating foreign key on [RpiDeviceId] in table 'RpiControls'
ALTER TABLE [dbo].[RpiControls]
ADD CONSTRAINT [FK_RpiDeviceRpiControl]
    FOREIGN KEY ([RpiDeviceId])
    REFERENCES [dbo].[RpiDevices]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RpiDeviceRpiControl'
CREATE INDEX [IX_FK_RpiDeviceRpiControl]
ON [dbo].[RpiControls]
    ([RpiDeviceId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------