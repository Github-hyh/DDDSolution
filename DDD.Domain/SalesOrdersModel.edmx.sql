
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/04/2016 22:08:42
-- Generated from EDMX file: D:\ProgrammingTest\DDDSolution\DDD.Domain\SalesOrdersModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SalesOrderDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProductProductCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_ProductProductCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Address] DROP CONSTRAINT [FK_CustomerAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_SalesOrderOrderItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderItem] DROP CONSTRAINT [FK_SalesOrderOrderItem];
GO
IF OBJECT_ID(N'[dbo].[FK_SalesOrderCustomerInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesOrder] DROP CONSTRAINT [FK_SalesOrderCustomerInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderItemProductInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderItem] DROP CONSTRAINT [FK_OrderItemProductInfo];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO
IF OBJECT_ID(N'[dbo].[ProductCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductCategory];
GO
IF OBJECT_ID(N'[dbo].[Customer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customer];
GO
IF OBJECT_ID(N'[dbo].[Address]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Address];
GO
IF OBJECT_ID(N'[dbo].[SalesOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SalesOrder];
GO
IF OBJECT_ID(N'[dbo].[OrderItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderItem];
GO
IF OBJECT_ID(N'[dbo].[CustomerInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerInfo];
GO
IF OBJECT_ID(N'[dbo].[ProductInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductInfo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Product'
CREATE TABLE [dbo].[Product] (
    [Id] uniqueidentifier  NOT NULL,
    [ProductName] nvarchar(max)  NOT NULL,
    [Color] nvarchar(max)  NOT NULL,
    [Size] nvarchar(max)  NOT NULL,
    [Count] int  NOT NULL,
    [UnitPrice] decimal(18,0)  NOT NULL,
    [ProductCategory_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'ProductCategory'
CREATE TABLE [dbo].[ProductCategory] (
    [Id] uniqueidentifier  NOT NULL,
    [CategoryName] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Customer'
CREATE TABLE [dbo].[Customer] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Mobile] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Address'
CREATE TABLE [dbo].[Address] (
    [Id] uniqueidentifier  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Street] nvarchar(max)  NOT NULL,
    [Customer_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'SalesOrder'
CREATE TABLE [dbo].[SalesOrder] (
    [Id] uniqueidentifier  NOT NULL,
    [DateTime] datetime  NOT NULL,
    [TotalPrice] decimal(18,0)  NOT NULL,
    [CustomerInfo_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'OrderItem'
CREATE TABLE [dbo].[OrderItem] (
    [Id] uniqueidentifier  NOT NULL,
    [Amount] int  NOT NULL,
    [LineTotal] decimal(18,0)  NOT NULL,
    [SalesOrder_Id] uniqueidentifier  NOT NULL,
    [ProductInfo_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'CustomerInfo'
CREATE TABLE [dbo].[CustomerInfo] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Mobile] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Street] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProductInfo'
CREATE TABLE [dbo].[ProductInfo] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [UnitPrice] decimal(18,0)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [PK_Product]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductCategory'
ALTER TABLE [dbo].[ProductCategory]
ADD CONSTRAINT [PK_ProductCategory]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Customer'
ALTER TABLE [dbo].[Customer]
ADD CONSTRAINT [PK_Customer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Address'
ALTER TABLE [dbo].[Address]
ADD CONSTRAINT [PK_Address]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SalesOrder'
ALTER TABLE [dbo].[SalesOrder]
ADD CONSTRAINT [PK_SalesOrder]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderItem'
ALTER TABLE [dbo].[OrderItem]
ADD CONSTRAINT [PK_OrderItem]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CustomerInfo'
ALTER TABLE [dbo].[CustomerInfo]
ADD CONSTRAINT [PK_CustomerInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductInfo'
ALTER TABLE [dbo].[ProductInfo]
ADD CONSTRAINT [PK_ProductInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProductCategory_Id] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [FK_ProductProductCategory]
    FOREIGN KEY ([ProductCategory_Id])
    REFERENCES [dbo].[ProductCategory]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductProductCategory'
CREATE INDEX [IX_FK_ProductProductCategory]
ON [dbo].[Product]
    ([ProductCategory_Id]);
GO

-- Creating foreign key on [Customer_Id] in table 'Address'
ALTER TABLE [dbo].[Address]
ADD CONSTRAINT [FK_CustomerAddress]
    FOREIGN KEY ([Customer_Id])
    REFERENCES [dbo].[Customer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerAddress'
CREATE INDEX [IX_FK_CustomerAddress]
ON [dbo].[Address]
    ([Customer_Id]);
GO

-- Creating foreign key on [SalesOrder_Id] in table 'OrderItem'
ALTER TABLE [dbo].[OrderItem]
ADD CONSTRAINT [FK_SalesOrderOrderItem]
    FOREIGN KEY ([SalesOrder_Id])
    REFERENCES [dbo].[SalesOrder]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SalesOrderOrderItem'
CREATE INDEX [IX_FK_SalesOrderOrderItem]
ON [dbo].[OrderItem]
    ([SalesOrder_Id]);
GO

-- Creating foreign key on [CustomerInfo_Id] in table 'SalesOrder'
ALTER TABLE [dbo].[SalesOrder]
ADD CONSTRAINT [FK_SalesOrderCustomerInfo]
    FOREIGN KEY ([CustomerInfo_Id])
    REFERENCES [dbo].[CustomerInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SalesOrderCustomerInfo'
CREATE INDEX [IX_FK_SalesOrderCustomerInfo]
ON [dbo].[SalesOrder]
    ([CustomerInfo_Id]);
GO

-- Creating foreign key on [ProductInfo_Id] in table 'OrderItem'
ALTER TABLE [dbo].[OrderItem]
ADD CONSTRAINT [FK_OrderItemProductInfo]
    FOREIGN KEY ([ProductInfo_Id])
    REFERENCES [dbo].[ProductInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderItemProductInfo'
CREATE INDEX [IX_FK_OrderItemProductInfo]
ON [dbo].[OrderItem]
    ([ProductInfo_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------