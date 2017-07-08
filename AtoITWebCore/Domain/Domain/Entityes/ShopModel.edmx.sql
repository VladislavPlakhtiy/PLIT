
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/07/2017 15:07:42
-- Generated from EDMX file: D:\ATOIT\PLIT\AtoITWebCore\Domain\Domain\Entityes\ShopModel.edmx
-- --------------------------------------------------
Use  ShopСontainer

SET QUOTED_IDENTIFIER OFF;
GO
USE [ShopСontainer];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProductCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_ProductCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_PhotoProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Photo] DROP CONSTRAINT [FK_PhotoProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_OrdersProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_OrdersProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_StatusOrders]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Status] DROP CONSTRAINT [FK_StatusOrders];
GO
IF OBJECT_ID(N'[dbo].[FK_DeliveryOrders]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delivery] DROP CONSTRAINT [FK_DeliveryOrders];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO
IF OBJECT_ID(N'[dbo].[Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category];
GO
IF OBJECT_ID(N'[dbo].[Status]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Status];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[Reviews]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reviews];
GO
IF OBJECT_ID(N'[dbo].[Photo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Photo];
GO
IF OBJECT_ID(N'[dbo].[Delivery]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Delivery];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Product'
CREATE TABLE [dbo].[Product] (
    [ProductId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [SpecOffer] nvarchar(max)  NULL,
    [Price] decimal(18,0)  NOT NULL,
    [DateCreate] datetime  NOT NULL,
    [Quantity] int  NULL,
    [Existence] bit  NULL,
    [OrdersProductId] int  NULL,
    [Category_CategoryId] int  NOT NULL
);
GO

-- Creating table 'Category'
CREATE TABLE [dbo].[Category] (
    [NameCategory] nvarchar(max)  NOT NULL,
    [CategoryId] int  NOT NULL
);
GO

-- Creating table 'Status'
CREATE TABLE [dbo].[Status] (
    [StatusName] nvarchar(max)  NOT NULL,
    [StatusId] int  NOT NULL,
    [Orders_OrderId] int  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [OrderId] int IDENTITY(1,1) NOT NULL,
    [Sum] decimal(18,0)  NOT NULL,
    [ClientName] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [Sity] nvarchar(max)  NULL,
    [Comments] nvarchar(max)  NULL,
    [DateOrder] datetime  NOT NULL
);
GO

-- Creating table 'Reviews'
CREATE TABLE [dbo].[Reviews] (
    [ReviewId] int IDENTITY(1,1) NOT NULL,
    [ClientName] nvarchar(max)  NOT NULL,
    [ClientFeedback] nvarchar(max)  NOT NULL,
    [Rating] int  NULL,
    [DateFeedback] datetime  NOT NULL
);
GO

-- Creating table 'Photo'
CREATE TABLE [dbo].[Photo] (
    [PhotoId] int IDENTITY(1,1) NOT NULL,
    [Priority] bit  NULL,
    [PhotoUrl] nvarchar(max)  NOT NULL,
    [Product_ProductId] int  NOT NULL
);
GO

-- Creating table 'Delivery'
CREATE TABLE [dbo].[Delivery] (
    [NameDelivery] nvarchar(max)  NOT NULL,
    [DeliveryId] int  NOT NULL,
    [Orders_OrderId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ProductId] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [PK_Product]
    PRIMARY KEY CLUSTERED ([ProductId] ASC);
GO

-- Creating primary key on [CategoryId] in table 'Category'
ALTER TABLE [dbo].[Category]
ADD CONSTRAINT [PK_Category]
    PRIMARY KEY CLUSTERED ([CategoryId] ASC);
GO

-- Creating primary key on [StatusId] in table 'Status'
ALTER TABLE [dbo].[Status]
ADD CONSTRAINT [PK_Status]
    PRIMARY KEY CLUSTERED ([StatusId] ASC);
GO

-- Creating primary key on [OrderId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([OrderId] ASC);
GO

-- Creating primary key on [ReviewId] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [PK_Reviews]
    PRIMARY KEY CLUSTERED ([ReviewId] ASC);
GO

-- Creating primary key on [PhotoId] in table 'Photo'
ALTER TABLE [dbo].[Photo]
ADD CONSTRAINT [PK_Photo]
    PRIMARY KEY CLUSTERED ([PhotoId] ASC);
GO

-- Creating primary key on [DeliveryId] in table 'Delivery'
ALTER TABLE [dbo].[Delivery]
ADD CONSTRAINT [PK_Delivery]
    PRIMARY KEY CLUSTERED ([DeliveryId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Category_CategoryId] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [FK_ProductCategory]
    FOREIGN KEY ([Category_CategoryId])
    REFERENCES [dbo].[Category]
        ([CategoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductCategory'
CREATE INDEX [IX_FK_ProductCategory]
ON [dbo].[Product]
    ([Category_CategoryId]);
GO

-- Creating foreign key on [Product_ProductId] in table 'Photo'
ALTER TABLE [dbo].[Photo]
ADD CONSTRAINT [FK_PhotoProduct]
    FOREIGN KEY ([Product_ProductId])
    REFERENCES [dbo].[Product]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PhotoProduct'
CREATE INDEX [IX_FK_PhotoProduct]
ON [dbo].[Photo]
    ([Product_ProductId]);
GO

-- Creating foreign key on [OrdersProductId] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [FK_OrdersProduct]
    FOREIGN KEY ([OrdersProductId])
    REFERENCES [dbo].[Orders]
        ([OrderId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrdersProduct'
CREATE INDEX [IX_FK_OrdersProduct]
ON [dbo].[Product]
    ([OrdersProductId]);
GO

-- Creating foreign key on [Orders_OrderId] in table 'Status'
ALTER TABLE [dbo].[Status]
ADD CONSTRAINT [FK_StatusOrders]
    FOREIGN KEY ([Orders_OrderId])
    REFERENCES [dbo].[Orders]
        ([OrderId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StatusOrders'
CREATE INDEX [IX_FK_StatusOrders]
ON [dbo].[Status]
    ([Orders_OrderId]);
GO

-- Creating foreign key on [Orders_OrderId] in table 'Delivery'
ALTER TABLE [dbo].[Delivery]
ADD CONSTRAINT [FK_DeliveryOrders]
    FOREIGN KEY ([Orders_OrderId])
    REFERENCES [dbo].[Orders]
        ([OrderId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeliveryOrders'
CREATE INDEX [IX_FK_DeliveryOrders]
ON [dbo].[Delivery]
    ([Orders_OrderId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------