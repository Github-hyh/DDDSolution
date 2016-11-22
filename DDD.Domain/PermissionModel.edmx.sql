
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/22/2016 22:09:24
-- Generated from EDMX file: C:\work\programing\DDDSolution\DDD.Domain\PermissionModel.edmx
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

IF OBJECT_ID(N'[dbo].[FK_BAS_PermissionContainerBAS_PermissionAssign]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BAS_PermissionAssign] DROP CONSTRAINT [FK_BAS_PermissionContainerBAS_PermissionAssign];
GO
IF OBJECT_ID(N'[dbo].[FK_BAS_IdentityContainerBAS_PermissionAssign]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BAS_PermissionAssign] DROP CONSTRAINT [FK_BAS_IdentityContainerBAS_PermissionAssign];
GO
IF OBJECT_ID(N'[dbo].[FK_BAS_ObjectContainerBAS_PermissionAssign]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BAS_PermissionAssign] DROP CONSTRAINT [FK_BAS_ObjectContainerBAS_PermissionAssign];
GO
IF OBJECT_ID(N'[dbo].[FK_BAS_ObjectBAS_OOSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BAS_OOSet] DROP CONSTRAINT [FK_BAS_ObjectBAS_OOSet];
GO
IF OBJECT_ID(N'[dbo].[FK_BAS_ObjectSetBAS_OOSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BAS_OOSet] DROP CONSTRAINT [FK_BAS_ObjectSetBAS_OOSet];
GO
IF OBJECT_ID(N'[dbo].[FK_BAS_PermissionBAS_PPSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BAS_PPSet] DROP CONSTRAINT [FK_BAS_PermissionBAS_PPSet];
GO
IF OBJECT_ID(N'[dbo].[FK_BAS_PermissionSetBAS_PPSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BAS_PPSet] DROP CONSTRAINT [FK_BAS_PermissionSetBAS_PPSet];
GO
IF OBJECT_ID(N'[dbo].[FK_BAS_UserUDPSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BAS_UDPSet] DROP CONSTRAINT [FK_BAS_UserUDPSet];
GO
IF OBJECT_ID(N'[dbo].[FK_BAS_PostUDPSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BAS_UDPSet] DROP CONSTRAINT [FK_BAS_PostUDPSet];
GO
IF OBJECT_ID(N'[dbo].[FK_BAS_DepartmentUDPSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BAS_UDPSet] DROP CONSTRAINT [FK_BAS_DepartmentUDPSet];
GO
IF OBJECT_ID(N'[dbo].[FK_BAS_RoleBAS_PR]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BAS_PR] DROP CONSTRAINT [FK_BAS_RoleBAS_PR];
GO
IF OBJECT_ID(N'[dbo].[FK_BAS_PostBAS_PR]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BAS_PR] DROP CONSTRAINT [FK_BAS_PostBAS_PR];
GO
IF OBJECT_ID(N'[dbo].[FK_BAS_RoleBAS_UR]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BAS_UR] DROP CONSTRAINT [FK_BAS_RoleBAS_UR];
GO
IF OBJECT_ID(N'[dbo].[FK_BAS_UserBAS_UR]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BAS_UR] DROP CONSTRAINT [FK_BAS_UserBAS_UR];
GO
IF OBJECT_ID(N'[dbo].[FK_BAS_RoleBAS_DR]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BAS_DR] DROP CONSTRAINT [FK_BAS_RoleBAS_DR];
GO
IF OBJECT_ID(N'[dbo].[FK_BAS_DepartmentBAS_DR]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BAS_DR] DROP CONSTRAINT [FK_BAS_DepartmentBAS_DR];
GO
IF OBJECT_ID(N'[dbo].[FK_BAS_UserBAS_UserLogin]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BAS_User] DROP CONSTRAINT [FK_BAS_UserBAS_UserLogin];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BAS_PermissionContainer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BAS_PermissionContainer];
GO
IF OBJECT_ID(N'[dbo].[BAS_IdentityContainer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BAS_IdentityContainer];
GO
IF OBJECT_ID(N'[dbo].[BAS_ObjectContainer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BAS_ObjectContainer];
GO
IF OBJECT_ID(N'[dbo].[BAS_PermissionAssign]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BAS_PermissionAssign];
GO
IF OBJECT_ID(N'[dbo].[BAS_Object]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BAS_Object];
GO
IF OBJECT_ID(N'[dbo].[BAS_ObjectSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BAS_ObjectSet];
GO
IF OBJECT_ID(N'[dbo].[BAS_OOSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BAS_OOSet];
GO
IF OBJECT_ID(N'[dbo].[BAS_Permission]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BAS_Permission];
GO
IF OBJECT_ID(N'[dbo].[BAS_PermissionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BAS_PermissionSet];
GO
IF OBJECT_ID(N'[dbo].[BAS_PPSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BAS_PPSet];
GO
IF OBJECT_ID(N'[dbo].[BAS_User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BAS_User];
GO
IF OBJECT_ID(N'[dbo].[BAS_Post]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BAS_Post];
GO
IF OBJECT_ID(N'[dbo].[BAS_Department]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BAS_Department];
GO
IF OBJECT_ID(N'[dbo].[BAS_UDPSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BAS_UDPSet];
GO
IF OBJECT_ID(N'[dbo].[BAS_Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BAS_Role];
GO
IF OBJECT_ID(N'[dbo].[BAS_PR]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BAS_PR];
GO
IF OBJECT_ID(N'[dbo].[BAS_UR]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BAS_UR];
GO
IF OBJECT_ID(N'[dbo].[BAS_DR]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BAS_DR];
GO
IF OBJECT_ID(N'[dbo].[BAS_UserLogin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BAS_UserLogin];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BAS_PermissionContainer'
CREATE TABLE [dbo].[BAS_PermissionContainer] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BAS_IdentityContainer'
CREATE TABLE [dbo].[BAS_IdentityContainer] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BAS_ObjectContainer'
CREATE TABLE [dbo].[BAS_ObjectContainer] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BAS_PermissionAssign'
CREATE TABLE [dbo].[BAS_PermissionAssign] (
    [Id] uniqueidentifier  NOT NULL,
    [BAS_PermissionContainer_Id] uniqueidentifier  NOT NULL,
    [BAS_IdentityContainer_Id] uniqueidentifier  NOT NULL,
    [BAS_ObjectContainer_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BAS_Object'
CREATE TABLE [dbo].[BAS_Object] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Obj_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BAS_ObjectSet'
CREATE TABLE [dbo].[BAS_ObjectSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Obj_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BAS_OOSet'
CREATE TABLE [dbo].[BAS_OOSet] (
    [Id] uniqueidentifier  NOT NULL,
    [BAS_Object_Id] uniqueidentifier  NOT NULL,
    [BAS_ObjectSet_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BAS_Permission'
CREATE TABLE [dbo].[BAS_Permission] (
    [Id] uniqueidentifier  NOT NULL,
    [CodeProperty] nvarchar(max)  NOT NULL,
    [Operation] int  NOT NULL,
    [CodeValue] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Per_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BAS_PermissionSet'
CREATE TABLE [dbo].[BAS_PermissionSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Per_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BAS_PPSet'
CREATE TABLE [dbo].[BAS_PPSet] (
    [Id] uniqueidentifier  NOT NULL,
    [BAS_Permission_Id] uniqueidentifier  NOT NULL,
    [BAS_PermissionSet_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BAS_User'
CREATE TABLE [dbo].[BAS_User] (
    [Id] uniqueidentifier  NOT NULL,
    [No] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Mobile] nvarchar(max)  NOT NULL,
    [Con_Id] uniqueidentifier  NOT NULL,
    [BAS_UserLogin_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BAS_Post'
CREATE TABLE [dbo].[BAS_Post] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Con_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BAS_Department'
CREATE TABLE [dbo].[BAS_Department] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Con_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BAS_UDPSet'
CREATE TABLE [dbo].[BAS_UDPSet] (
    [Id] uniqueidentifier  NOT NULL,
    [IsMain] bit  NOT NULL,
    [BAS_User_Id] uniqueidentifier  NOT NULL,
    [BAS_Post_Id] uniqueidentifier  NOT NULL,
    [BAS_Department_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BAS_Role'
CREATE TABLE [dbo].[BAS_Role] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Con_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BAS_PR'
CREATE TABLE [dbo].[BAS_PR] (
    [Id] uniqueidentifier  NOT NULL,
    [BAS_Role_Id] uniqueidentifier  NOT NULL,
    [BAS_Post_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BAS_UR'
CREATE TABLE [dbo].[BAS_UR] (
    [Id] uniqueidentifier  NOT NULL,
    [BAS_Role_Id] uniqueidentifier  NOT NULL,
    [BAS_User_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BAS_DR'
CREATE TABLE [dbo].[BAS_DR] (
    [Id] uniqueidentifier  NOT NULL,
    [BAS_Role_Id] uniqueidentifier  NOT NULL,
    [BAS_Department_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BAS_UserLogin'
CREATE TABLE [dbo].[BAS_UserLogin] (
    [Id] uniqueidentifier  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'BAS_PermissionContainer'
ALTER TABLE [dbo].[BAS_PermissionContainer]
ADD CONSTRAINT [PK_BAS_PermissionContainer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BAS_IdentityContainer'
ALTER TABLE [dbo].[BAS_IdentityContainer]
ADD CONSTRAINT [PK_BAS_IdentityContainer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BAS_ObjectContainer'
ALTER TABLE [dbo].[BAS_ObjectContainer]
ADD CONSTRAINT [PK_BAS_ObjectContainer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BAS_PermissionAssign'
ALTER TABLE [dbo].[BAS_PermissionAssign]
ADD CONSTRAINT [PK_BAS_PermissionAssign]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BAS_Object'
ALTER TABLE [dbo].[BAS_Object]
ADD CONSTRAINT [PK_BAS_Object]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BAS_ObjectSet'
ALTER TABLE [dbo].[BAS_ObjectSet]
ADD CONSTRAINT [PK_BAS_ObjectSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BAS_OOSet'
ALTER TABLE [dbo].[BAS_OOSet]
ADD CONSTRAINT [PK_BAS_OOSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BAS_Permission'
ALTER TABLE [dbo].[BAS_Permission]
ADD CONSTRAINT [PK_BAS_Permission]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BAS_PermissionSet'
ALTER TABLE [dbo].[BAS_PermissionSet]
ADD CONSTRAINT [PK_BAS_PermissionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BAS_PPSet'
ALTER TABLE [dbo].[BAS_PPSet]
ADD CONSTRAINT [PK_BAS_PPSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BAS_User'
ALTER TABLE [dbo].[BAS_User]
ADD CONSTRAINT [PK_BAS_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BAS_Post'
ALTER TABLE [dbo].[BAS_Post]
ADD CONSTRAINT [PK_BAS_Post]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BAS_Department'
ALTER TABLE [dbo].[BAS_Department]
ADD CONSTRAINT [PK_BAS_Department]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BAS_UDPSet'
ALTER TABLE [dbo].[BAS_UDPSet]
ADD CONSTRAINT [PK_BAS_UDPSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BAS_Role'
ALTER TABLE [dbo].[BAS_Role]
ADD CONSTRAINT [PK_BAS_Role]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BAS_PR'
ALTER TABLE [dbo].[BAS_PR]
ADD CONSTRAINT [PK_BAS_PR]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BAS_UR'
ALTER TABLE [dbo].[BAS_UR]
ADD CONSTRAINT [PK_BAS_UR]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BAS_DR'
ALTER TABLE [dbo].[BAS_DR]
ADD CONSTRAINT [PK_BAS_DR]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BAS_UserLogin'
ALTER TABLE [dbo].[BAS_UserLogin]
ADD CONSTRAINT [PK_BAS_UserLogin]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BAS_PermissionContainer_Id] in table 'BAS_PermissionAssign'
ALTER TABLE [dbo].[BAS_PermissionAssign]
ADD CONSTRAINT [FK_BAS_PermissionContainerBAS_PermissionAssign]
    FOREIGN KEY ([BAS_PermissionContainer_Id])
    REFERENCES [dbo].[BAS_PermissionContainer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BAS_PermissionContainerBAS_PermissionAssign'
CREATE INDEX [IX_FK_BAS_PermissionContainerBAS_PermissionAssign]
ON [dbo].[BAS_PermissionAssign]
    ([BAS_PermissionContainer_Id]);
GO

-- Creating foreign key on [BAS_IdentityContainer_Id] in table 'BAS_PermissionAssign'
ALTER TABLE [dbo].[BAS_PermissionAssign]
ADD CONSTRAINT [FK_BAS_IdentityContainerBAS_PermissionAssign]
    FOREIGN KEY ([BAS_IdentityContainer_Id])
    REFERENCES [dbo].[BAS_IdentityContainer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BAS_IdentityContainerBAS_PermissionAssign'
CREATE INDEX [IX_FK_BAS_IdentityContainerBAS_PermissionAssign]
ON [dbo].[BAS_PermissionAssign]
    ([BAS_IdentityContainer_Id]);
GO

-- Creating foreign key on [BAS_ObjectContainer_Id] in table 'BAS_PermissionAssign'
ALTER TABLE [dbo].[BAS_PermissionAssign]
ADD CONSTRAINT [FK_BAS_ObjectContainerBAS_PermissionAssign]
    FOREIGN KEY ([BAS_ObjectContainer_Id])
    REFERENCES [dbo].[BAS_ObjectContainer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BAS_ObjectContainerBAS_PermissionAssign'
CREATE INDEX [IX_FK_BAS_ObjectContainerBAS_PermissionAssign]
ON [dbo].[BAS_PermissionAssign]
    ([BAS_ObjectContainer_Id]);
GO

-- Creating foreign key on [BAS_Object_Id] in table 'BAS_OOSet'
ALTER TABLE [dbo].[BAS_OOSet]
ADD CONSTRAINT [FK_BAS_ObjectBAS_OOSet]
    FOREIGN KEY ([BAS_Object_Id])
    REFERENCES [dbo].[BAS_Object]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BAS_ObjectBAS_OOSet'
CREATE INDEX [IX_FK_BAS_ObjectBAS_OOSet]
ON [dbo].[BAS_OOSet]
    ([BAS_Object_Id]);
GO

-- Creating foreign key on [BAS_ObjectSet_Id] in table 'BAS_OOSet'
ALTER TABLE [dbo].[BAS_OOSet]
ADD CONSTRAINT [FK_BAS_ObjectSetBAS_OOSet]
    FOREIGN KEY ([BAS_ObjectSet_Id])
    REFERENCES [dbo].[BAS_ObjectSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BAS_ObjectSetBAS_OOSet'
CREATE INDEX [IX_FK_BAS_ObjectSetBAS_OOSet]
ON [dbo].[BAS_OOSet]
    ([BAS_ObjectSet_Id]);
GO

-- Creating foreign key on [BAS_Permission_Id] in table 'BAS_PPSet'
ALTER TABLE [dbo].[BAS_PPSet]
ADD CONSTRAINT [FK_BAS_PermissionBAS_PPSet]
    FOREIGN KEY ([BAS_Permission_Id])
    REFERENCES [dbo].[BAS_Permission]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BAS_PermissionBAS_PPSet'
CREATE INDEX [IX_FK_BAS_PermissionBAS_PPSet]
ON [dbo].[BAS_PPSet]
    ([BAS_Permission_Id]);
GO

-- Creating foreign key on [BAS_PermissionSet_Id] in table 'BAS_PPSet'
ALTER TABLE [dbo].[BAS_PPSet]
ADD CONSTRAINT [FK_BAS_PermissionSetBAS_PPSet]
    FOREIGN KEY ([BAS_PermissionSet_Id])
    REFERENCES [dbo].[BAS_PermissionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BAS_PermissionSetBAS_PPSet'
CREATE INDEX [IX_FK_BAS_PermissionSetBAS_PPSet]
ON [dbo].[BAS_PPSet]
    ([BAS_PermissionSet_Id]);
GO

-- Creating foreign key on [BAS_User_Id] in table 'BAS_UDPSet'
ALTER TABLE [dbo].[BAS_UDPSet]
ADD CONSTRAINT [FK_BAS_UserUDPSet]
    FOREIGN KEY ([BAS_User_Id])
    REFERENCES [dbo].[BAS_User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BAS_UserUDPSet'
CREATE INDEX [IX_FK_BAS_UserUDPSet]
ON [dbo].[BAS_UDPSet]
    ([BAS_User_Id]);
GO

-- Creating foreign key on [BAS_Post_Id] in table 'BAS_UDPSet'
ALTER TABLE [dbo].[BAS_UDPSet]
ADD CONSTRAINT [FK_BAS_PostUDPSet]
    FOREIGN KEY ([BAS_Post_Id])
    REFERENCES [dbo].[BAS_Post]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BAS_PostUDPSet'
CREATE INDEX [IX_FK_BAS_PostUDPSet]
ON [dbo].[BAS_UDPSet]
    ([BAS_Post_Id]);
GO

-- Creating foreign key on [BAS_Department_Id] in table 'BAS_UDPSet'
ALTER TABLE [dbo].[BAS_UDPSet]
ADD CONSTRAINT [FK_BAS_DepartmentUDPSet]
    FOREIGN KEY ([BAS_Department_Id])
    REFERENCES [dbo].[BAS_Department]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BAS_DepartmentUDPSet'
CREATE INDEX [IX_FK_BAS_DepartmentUDPSet]
ON [dbo].[BAS_UDPSet]
    ([BAS_Department_Id]);
GO

-- Creating foreign key on [BAS_Role_Id] in table 'BAS_PR'
ALTER TABLE [dbo].[BAS_PR]
ADD CONSTRAINT [FK_BAS_RoleBAS_PR]
    FOREIGN KEY ([BAS_Role_Id])
    REFERENCES [dbo].[BAS_Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BAS_RoleBAS_PR'
CREATE INDEX [IX_FK_BAS_RoleBAS_PR]
ON [dbo].[BAS_PR]
    ([BAS_Role_Id]);
GO

-- Creating foreign key on [BAS_Post_Id] in table 'BAS_PR'
ALTER TABLE [dbo].[BAS_PR]
ADD CONSTRAINT [FK_BAS_PostBAS_PR]
    FOREIGN KEY ([BAS_Post_Id])
    REFERENCES [dbo].[BAS_Post]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BAS_PostBAS_PR'
CREATE INDEX [IX_FK_BAS_PostBAS_PR]
ON [dbo].[BAS_PR]
    ([BAS_Post_Id]);
GO

-- Creating foreign key on [BAS_Role_Id] in table 'BAS_UR'
ALTER TABLE [dbo].[BAS_UR]
ADD CONSTRAINT [FK_BAS_RoleBAS_UR]
    FOREIGN KEY ([BAS_Role_Id])
    REFERENCES [dbo].[BAS_Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BAS_RoleBAS_UR'
CREATE INDEX [IX_FK_BAS_RoleBAS_UR]
ON [dbo].[BAS_UR]
    ([BAS_Role_Id]);
GO

-- Creating foreign key on [BAS_User_Id] in table 'BAS_UR'
ALTER TABLE [dbo].[BAS_UR]
ADD CONSTRAINT [FK_BAS_UserBAS_UR]
    FOREIGN KEY ([BAS_User_Id])
    REFERENCES [dbo].[BAS_User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BAS_UserBAS_UR'
CREATE INDEX [IX_FK_BAS_UserBAS_UR]
ON [dbo].[BAS_UR]
    ([BAS_User_Id]);
GO

-- Creating foreign key on [BAS_Role_Id] in table 'BAS_DR'
ALTER TABLE [dbo].[BAS_DR]
ADD CONSTRAINT [FK_BAS_RoleBAS_DR]
    FOREIGN KEY ([BAS_Role_Id])
    REFERENCES [dbo].[BAS_Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BAS_RoleBAS_DR'
CREATE INDEX [IX_FK_BAS_RoleBAS_DR]
ON [dbo].[BAS_DR]
    ([BAS_Role_Id]);
GO

-- Creating foreign key on [BAS_Department_Id] in table 'BAS_DR'
ALTER TABLE [dbo].[BAS_DR]
ADD CONSTRAINT [FK_BAS_DepartmentBAS_DR]
    FOREIGN KEY ([BAS_Department_Id])
    REFERENCES [dbo].[BAS_Department]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BAS_DepartmentBAS_DR'
CREATE INDEX [IX_FK_BAS_DepartmentBAS_DR]
ON [dbo].[BAS_DR]
    ([BAS_Department_Id]);
GO

-- Creating foreign key on [BAS_UserLogin_Id] in table 'BAS_User'
ALTER TABLE [dbo].[BAS_User]
ADD CONSTRAINT [FK_BAS_UserBAS_UserLogin]
    FOREIGN KEY ([BAS_UserLogin_Id])
    REFERENCES [dbo].[BAS_UserLogin]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BAS_UserBAS_UserLogin'
CREATE INDEX [IX_FK_BAS_UserBAS_UserLogin]
ON [dbo].[BAS_User]
    ([BAS_UserLogin_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------