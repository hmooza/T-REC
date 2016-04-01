
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/01/2016 15:25:38
-- Generated from EDMX file: C:\Users\Narinchode\Desktop\Git\T-REC\Web_T-REC\DataModel\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [T-REC];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Customer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customer];
GO
IF OBJECT_ID(N'[dbo].[Department]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Department];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[Employees_Position]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees_Position];
GO
IF OBJECT_ID(N'[dbo].[Equipment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Equipment];
GO
IF OBJECT_ID(N'[dbo].[Equipment_SET]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Equipment_SET];
GO
IF OBJECT_ID(N'[dbo].[Equipment_SET_detail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Equipment_SET_detail];
GO
IF OBJECT_ID(N'[dbo].[Equipment_Type]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Equipment_Type];
GO
IF OBJECT_ID(N'[dbo].[JobPosition]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobPosition];
GO
IF OBJECT_ID(N'[dbo].[JobPosition_Emp]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobPosition_Emp];
GO
IF OBJECT_ID(N'[dbo].[Packages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Packages];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Firstname] nvarchar(128)  NULL,
    [Lastname] nvarchar(128)  NULL,
    [Nickname] nvarchar(128)  NULL,
    [Address] nvarchar(max)  NULL,
    [Phone] nvarchar(50)  NULL,
    [IdenNumber] nvarchar(13)  NULL,
    [AccNo] nvarchar(50)  NULL,
    [AccName] nvarchar(50)  NULL,
    [position] nvarchar(50)  NULL,
    [salary] decimal(18,0)  NULL,
    [EMP_ID] nvarchar(50)  NOT NULL,
    [BirthDate] datetime  NULL,
    [StartWorkDate] datetime  NULL,
    [EndWorkDate] datetime  NULL,
    [Email] nvarchar(250)  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedBy] nvarchar(50)  NULL,
    [UpdatedDate] datetime  NULL,
    [UpdatedBy] nvarchar(50)  NULL,
    [DeptId] int  NULL
);
GO

-- Creating table 'Employees_Position'
CREATE TABLE [dbo].[Employees_Position] (
    [Emp_id] nvarchar(50)  NOT NULL,
    [Pos_id] int  NOT NULL,
    [cost] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Equipment'
CREATE TABLE [dbo].[Equipment] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(256)  NULL,
    [Equip_type_id] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [CreatedBy] nvarchar(50)  NULL,
    [UpdatedDate] datetime  NULL,
    [UpdatedBy] nvarchar(50)  NULL,
    [Fullname] nvarchar(256)  NULL,
    [SN] nvarchar(50)  NULL,
    [Number] nvarchar(50)  NULL,
    [CostBuy] decimal(18,2)  NULL,
    [CostRent] decimal(18,2)  NULL,
    [SupplierName] nvarchar(256)  NULL,
    [BuyDate] datetime  NULL,
    [ReceiptTax] nvarchar(50)  NULL,
    [ExpireDate] datetime  NULL
);
GO

-- Creating table 'Equipment_SET'
CREATE TABLE [dbo].[Equipment_SET] (
    [SETName] nvarchar(max)  NULL,
    [Price] decimal(7,2)  NULL,
    [Description] nvarchar(200)  NULL,
    [SET_ID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Equipment_SET_detail'
CREATE TABLE [dbo].[Equipment_SET_detail] (
    [SET_ID] int  NOT NULL,
    [Equip_ID] int  NOT NULL,
    [cost] decimal(18,0)  NULL,
    [SET_DET_ID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Equipment_Type'
CREATE TABLE [dbo].[Equipment_Type] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(250)  NULL,
    [ParentID] int  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedBy] nvarchar(50)  NULL,
    [UpdatedDate] datetime  NULL,
    [UpdatedBy] nvarchar(50)  NULL
);
GO

-- Creating table 'JobPosition'
CREATE TABLE [dbo].[JobPosition] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Position] nvarchar(150)  NULL,
    [cost] decimal(18,0)  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedBy] nvarchar(50)  NULL,
    [UpdatedDate] datetime  NULL,
    [UpdatedBy] nvarchar(50)  NULL,
    [DeptId] int  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [id] int  NOT NULL,
    [rolename] nvarchar(50)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(20)  NOT NULL,
    [Password] nvarchar(128)  NULL,
    [Employee_ID] nvarchar(10)  NULL,
    [Role_ID] int  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedBy] nvarchar(50)  NULL,
    [UpdatedDate] datetime  NULL,
    [UpdatedBy] nvarchar(50)  NULL
);
GO

-- Creating table 'Customer'
CREATE TABLE [dbo].[Customer] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [C_ID] nvarchar(50)  NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Tel] nvarchar(10)  NULL,
    [Email] nvarchar(50)  NULL,
    [Fax] nvarchar(10)  NULL,
    [EXT] nvarchar(5)  NULL,
    [Name_Company] nvarchar(50)  NULL,
    [Address] nvarchar(50)  NULL,
    [Tax_Number] nvarchar(13)  NULL,
    [Tel_Company] nvarchar(10)  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedBy] nvarchar(50)  NULL,
    [UpdatedBy] nvarchar(50)  NULL,
    [UpdatedDate] datetime  NULL
);
GO

-- Creating table 'Department'
CREATE TABLE [dbo].[Department] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NULL
);
GO

-- Creating table 'JobPosition_Emp'
CREATE TABLE [dbo].[JobPosition_Emp] (
    [Emp_id] nvarchar(50)  NOT NULL,
    [Pos_id] int  NOT NULL,
    [cost] decimal(18,0)  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedBy] nvarchar(50)  NULL,
    [UpdatedDate] datetime  NULL,
    [UpdatedBy] nvarchar(50)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Packages'
CREATE TABLE [dbo].[Packages] (
    [Pack_Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(20)  NULL,
    [Price] decimal(7,2)  NULL,
    [Description] nvarchar(max)  NULL,
    [SET_ID] int  NULL,
    [Equip_Id] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [EMP_ID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([EMP_ID] ASC);
GO

-- Creating primary key on [Emp_id], [Pos_id] in table 'Employees_Position'
ALTER TABLE [dbo].[Employees_Position]
ADD CONSTRAINT [PK_Employees_Position]
    PRIMARY KEY CLUSTERED ([Emp_id], [Pos_id] ASC);
GO

-- Creating primary key on [ID] in table 'Equipment'
ALTER TABLE [dbo].[Equipment]
ADD CONSTRAINT [PK_Equipment]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [SET_ID] in table 'Equipment_SET'
ALTER TABLE [dbo].[Equipment_SET]
ADD CONSTRAINT [PK_Equipment_SET]
    PRIMARY KEY CLUSTERED ([SET_ID] ASC);
GO

-- Creating primary key on [SET_ID], [Equip_ID] in table 'Equipment_SET_detail'
ALTER TABLE [dbo].[Equipment_SET_detail]
ADD CONSTRAINT [PK_Equipment_SET_detail]
    PRIMARY KEY CLUSTERED ([SET_ID], [Equip_ID] ASC);
GO

-- Creating primary key on [ID] in table 'Equipment_Type'
ALTER TABLE [dbo].[Equipment_Type]
ADD CONSTRAINT [PK_Equipment_Type]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'JobPosition'
ALTER TABLE [dbo].[JobPosition]
ADD CONSTRAINT [PK_JobPosition]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Username] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Username] ASC);
GO

-- Creating primary key on [C_ID] in table 'Customer'
ALTER TABLE [dbo].[Customer]
ADD CONSTRAINT [PK_Customer]
    PRIMARY KEY CLUSTERED ([C_ID] ASC);
GO

-- Creating primary key on [ID] in table 'Department'
ALTER TABLE [dbo].[Department]
ADD CONSTRAINT [PK_Department]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Emp_id], [Pos_id] in table 'JobPosition_Emp'
ALTER TABLE [dbo].[JobPosition_Emp]
ADD CONSTRAINT [PK_JobPosition_Emp]
    PRIMARY KEY CLUSTERED ([Emp_id], [Pos_id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Pack_Id] in table 'Packages'
ALTER TABLE [dbo].[Packages]
ADD CONSTRAINT [PK_Packages]
    PRIMARY KEY CLUSTERED ([Pack_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------