
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/13/2016 20:43:56
-- Generated from EDMX file: D:\Alberto\apps\mimascota\tuMascota\TuMascota\TuMascota.AccesoDatos\DataModels\MascotaModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [bd_tumascota];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [IdUsuario] bigint IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(250)  NOT NULL,
    [Password] nvarchar(300)  NOT NULL,
    [Email] nvarchar(250)  NOT NULL,
    [Nombres] nvarchar(300)  NOT NULL,
    [Apellidos] nvarchar(300)  NULL,
    [Celular] nvarchar(100)  NULL,
    [Telefono] nvarchar(120)  NULL,
    [Direccion] nvarchar(800)  NULL,
    [Facebook] nvarchar(250)  NULL
);
GO

-- Creating table 'Mascotas'
CREATE TABLE [dbo].[Mascotas] (
    [IdMascota] bigint IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(300)  NOT NULL,
    [Nacimiento] datetime  NULL,
    [FechaCreacion] datetime  NOT NULL,
    [Color] nvarchar(50)  NOT NULL,
    [Raza] nvarchar(250)  NULL,
    [Imagen] nvarchar(250)  NULL,
    [Estado] nvarchar(5)  NOT NULL,
    [Descripcion] nvarchar(800)  NULL,
    [IdUsuario] bigint  NOT NULL,
    [Latitud] bigint  NULL,
    [Longitud] bigint  NULL,
    [TipoAnimal] nvarchar(3)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdUsuario] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([IdUsuario] ASC);
GO

-- Creating primary key on [IdMascota] in table 'Mascotas'
ALTER TABLE [dbo].[Mascotas]
ADD CONSTRAINT [PK_Mascotas]
    PRIMARY KEY CLUSTERED ([IdMascota] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdUsuario] in table 'Mascotas'
ALTER TABLE [dbo].[Mascotas]
ADD CONSTRAINT [FK_UsuarioMascota]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Usuarios]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioMascota'
CREATE INDEX [IX_FK_UsuarioMascota]
ON [dbo].[Mascotas]
    ([IdUsuario]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------