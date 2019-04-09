
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/09/2019 19:15:08
-- Generated from EDMX file: C:\Users\boris\Desktop\git\rg\RGAudio\Dades\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [errege];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ArtistSong_Artist]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ArtistSong] DROP CONSTRAINT [FK_ArtistSong_Artist];
GO
IF OBJECT_ID(N'[dbo].[FK_ArtistSong_Song]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ArtistSong] DROP CONSTRAINT [FK_ArtistSong_Song];
GO
IF OBJECT_ID(N'[dbo].[FK_ArtistAlbum_Artist]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ArtistAlbum] DROP CONSTRAINT [FK_ArtistAlbum_Artist];
GO
IF OBJECT_ID(N'[dbo].[FK_ArtistAlbum_Album]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ArtistAlbum] DROP CONSTRAINT [FK_ArtistAlbum_Album];
GO
IF OBJECT_ID(N'[dbo].[FK_SongAlbum]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AudioFileSet_Song] DROP CONSTRAINT [FK_SongAlbum];
GO
IF OBJECT_ID(N'[dbo].[FK_CategorySong_Category]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CategorySong] DROP CONSTRAINT [FK_CategorySong_Category];
GO
IF OBJECT_ID(N'[dbo].[FK_CategorySong_Song]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CategorySong] DROP CONSTRAINT [FK_CategorySong_Song];
GO
IF OBJECT_ID(N'[dbo].[FK_AppsPermisos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PermisosSet] DROP CONSTRAINT [FK_AppsPermisos];
GO
IF OBJECT_ID(N'[dbo].[FK_PermisosUsers_Permisos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PermisosUsers] DROP CONSTRAINT [FK_PermisosUsers_Permisos];
GO
IF OBJECT_ID(N'[dbo].[FK_PermisosUsers_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PermisosUsers] DROP CONSTRAINT [FK_PermisosUsers_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Song_inherits_AudioFile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AudioFileSet_Song] DROP CONSTRAINT [FK_Song_inherits_AudioFile];
GO
IF OBJECT_ID(N'[dbo].[FK_Podcast_inherits_AudioFile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AudioFileSet_Podcast] DROP CONSTRAINT [FK_Podcast_inherits_AudioFile];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ArtistSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ArtistSet];
GO
IF OBJECT_ID(N'[dbo].[AlbumSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AlbumSet];
GO
IF OBJECT_ID(N'[dbo].[CategorySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategorySet];
GO
IF OBJECT_ID(N'[dbo].[ShowSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShowSet];
GO
IF OBJECT_ID(N'[dbo].[AudioFileSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AudioFileSet];
GO
IF OBJECT_ID(N'[dbo].[UsersSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersSet];
GO
IF OBJECT_ID(N'[dbo].[AppsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AppsSet];
GO
IF OBJECT_ID(N'[dbo].[PermisosSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PermisosSet];
GO
IF OBJECT_ID(N'[dbo].[AudioFileSet_Song]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AudioFileSet_Song];
GO
IF OBJECT_ID(N'[dbo].[AudioFileSet_Podcast]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AudioFileSet_Podcast];
GO
IF OBJECT_ID(N'[dbo].[ArtistSong]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ArtistSong];
GO
IF OBJECT_ID(N'[dbo].[ArtistAlbum]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ArtistAlbum];
GO
IF OBJECT_ID(N'[dbo].[CategorySong]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategorySong];
GO
IF OBJECT_ID(N'[dbo].[PermisosUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PermisosUsers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ArtistSet'
CREATE TABLE [dbo].[ArtistSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AlbumSet'
CREATE TABLE [dbo].[AlbumSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Year] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CategorySet'
CREATE TABLE [dbo].[CategorySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [HexColor] nvarchar(max)  NOT NULL,
    [ParentCategory] int  NOT NULL
);
GO

-- Creating table 'ShowSet'
CREATE TABLE [dbo].[ShowSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AudioFileSet'
CREATE TABLE [dbo].[AudioFileSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FileName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UsersSet'
CREATE TABLE [dbo].[UsersSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AppsSet'
CREATE TABLE [dbo].[AppsSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'PermisosSet'
CREATE TABLE [dbo].[PermisosSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descrip] nvarchar(max)  NOT NULL,
    [Apps_Id] int  NOT NULL
);
GO

-- Creating table 'AudioFileSet_Song'
CREATE TABLE [dbo].[AudioFileSet_Song] (
    [Name] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL,
    [Album_Id] int  NOT NULL
);
GO

-- Creating table 'AudioFileSet_Podcast'
CREATE TABLE [dbo].[AudioFileSet_Podcast] (
    [isPublic] bit  NOT NULL,
    [Uploaded] bit  NOT NULL,
    [AirDateTime] datetime  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'ArtistSong'
CREATE TABLE [dbo].[ArtistSong] (
    [Artist_Id] int  NOT NULL,
    [Song_Id] int  NOT NULL
);
GO

-- Creating table 'ArtistAlbum'
CREATE TABLE [dbo].[ArtistAlbum] (
    [Artist_Id] int  NOT NULL,
    [Album_Id] int  NOT NULL
);
GO

-- Creating table 'CategorySong'
CREATE TABLE [dbo].[CategorySong] (
    [Category_Id] int  NOT NULL,
    [Song_Id] int  NOT NULL
);
GO

-- Creating table 'PermisosUsers'
CREATE TABLE [dbo].[PermisosUsers] (
    [Permisos_Id] int  NOT NULL,
    [Users_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ArtistSet'
ALTER TABLE [dbo].[ArtistSet]
ADD CONSTRAINT [PK_ArtistSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AlbumSet'
ALTER TABLE [dbo].[AlbumSet]
ADD CONSTRAINT [PK_AlbumSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategorySet'
ALTER TABLE [dbo].[CategorySet]
ADD CONSTRAINT [PK_CategorySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ShowSet'
ALTER TABLE [dbo].[ShowSet]
ADD CONSTRAINT [PK_ShowSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AudioFileSet'
ALTER TABLE [dbo].[AudioFileSet]
ADD CONSTRAINT [PK_AudioFileSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersSet'
ALTER TABLE [dbo].[UsersSet]
ADD CONSTRAINT [PK_UsersSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AppsSet'
ALTER TABLE [dbo].[AppsSet]
ADD CONSTRAINT [PK_AppsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PermisosSet'
ALTER TABLE [dbo].[PermisosSet]
ADD CONSTRAINT [PK_PermisosSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AudioFileSet_Song'
ALTER TABLE [dbo].[AudioFileSet_Song]
ADD CONSTRAINT [PK_AudioFileSet_Song]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AudioFileSet_Podcast'
ALTER TABLE [dbo].[AudioFileSet_Podcast]
ADD CONSTRAINT [PK_AudioFileSet_Podcast]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Artist_Id], [Song_Id] in table 'ArtistSong'
ALTER TABLE [dbo].[ArtistSong]
ADD CONSTRAINT [PK_ArtistSong]
    PRIMARY KEY CLUSTERED ([Artist_Id], [Song_Id] ASC);
GO

-- Creating primary key on [Artist_Id], [Album_Id] in table 'ArtistAlbum'
ALTER TABLE [dbo].[ArtistAlbum]
ADD CONSTRAINT [PK_ArtistAlbum]
    PRIMARY KEY CLUSTERED ([Artist_Id], [Album_Id] ASC);
GO

-- Creating primary key on [Category_Id], [Song_Id] in table 'CategorySong'
ALTER TABLE [dbo].[CategorySong]
ADD CONSTRAINT [PK_CategorySong]
    PRIMARY KEY CLUSTERED ([Category_Id], [Song_Id] ASC);
GO

-- Creating primary key on [Permisos_Id], [Users_Id] in table 'PermisosUsers'
ALTER TABLE [dbo].[PermisosUsers]
ADD CONSTRAINT [PK_PermisosUsers]
    PRIMARY KEY CLUSTERED ([Permisos_Id], [Users_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Artist_Id] in table 'ArtistSong'
ALTER TABLE [dbo].[ArtistSong]
ADD CONSTRAINT [FK_ArtistSong_Artist]
    FOREIGN KEY ([Artist_Id])
    REFERENCES [dbo].[ArtistSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Song_Id] in table 'ArtistSong'
ALTER TABLE [dbo].[ArtistSong]
ADD CONSTRAINT [FK_ArtistSong_Song]
    FOREIGN KEY ([Song_Id])
    REFERENCES [dbo].[AudioFileSet_Song]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArtistSong_Song'
CREATE INDEX [IX_FK_ArtistSong_Song]
ON [dbo].[ArtistSong]
    ([Song_Id]);
GO

-- Creating foreign key on [Artist_Id] in table 'ArtistAlbum'
ALTER TABLE [dbo].[ArtistAlbum]
ADD CONSTRAINT [FK_ArtistAlbum_Artist]
    FOREIGN KEY ([Artist_Id])
    REFERENCES [dbo].[ArtistSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Album_Id] in table 'ArtistAlbum'
ALTER TABLE [dbo].[ArtistAlbum]
ADD CONSTRAINT [FK_ArtistAlbum_Album]
    FOREIGN KEY ([Album_Id])
    REFERENCES [dbo].[AlbumSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArtistAlbum_Album'
CREATE INDEX [IX_FK_ArtistAlbum_Album]
ON [dbo].[ArtistAlbum]
    ([Album_Id]);
GO

-- Creating foreign key on [Album_Id] in table 'AudioFileSet_Song'
ALTER TABLE [dbo].[AudioFileSet_Song]
ADD CONSTRAINT [FK_SongAlbum]
    FOREIGN KEY ([Album_Id])
    REFERENCES [dbo].[AlbumSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SongAlbum'
CREATE INDEX [IX_FK_SongAlbum]
ON [dbo].[AudioFileSet_Song]
    ([Album_Id]);
GO

-- Creating foreign key on [Category_Id] in table 'CategorySong'
ALTER TABLE [dbo].[CategorySong]
ADD CONSTRAINT [FK_CategorySong_Category]
    FOREIGN KEY ([Category_Id])
    REFERENCES [dbo].[CategorySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Song_Id] in table 'CategorySong'
ALTER TABLE [dbo].[CategorySong]
ADD CONSTRAINT [FK_CategorySong_Song]
    FOREIGN KEY ([Song_Id])
    REFERENCES [dbo].[AudioFileSet_Song]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategorySong_Song'
CREATE INDEX [IX_FK_CategorySong_Song]
ON [dbo].[CategorySong]
    ([Song_Id]);
GO

-- Creating foreign key on [Apps_Id] in table 'PermisosSet'
ALTER TABLE [dbo].[PermisosSet]
ADD CONSTRAINT [FK_AppsPermisos]
    FOREIGN KEY ([Apps_Id])
    REFERENCES [dbo].[AppsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AppsPermisos'
CREATE INDEX [IX_FK_AppsPermisos]
ON [dbo].[PermisosSet]
    ([Apps_Id]);
GO

-- Creating foreign key on [Permisos_Id] in table 'PermisosUsers'
ALTER TABLE [dbo].[PermisosUsers]
ADD CONSTRAINT [FK_PermisosUsers_Permisos]
    FOREIGN KEY ([Permisos_Id])
    REFERENCES [dbo].[PermisosSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Users_Id] in table 'PermisosUsers'
ALTER TABLE [dbo].[PermisosUsers]
ADD CONSTRAINT [FK_PermisosUsers_Users]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[UsersSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PermisosUsers_Users'
CREATE INDEX [IX_FK_PermisosUsers_Users]
ON [dbo].[PermisosUsers]
    ([Users_Id]);
GO

-- Creating foreign key on [Id] in table 'AudioFileSet_Song'
ALTER TABLE [dbo].[AudioFileSet_Song]
ADD CONSTRAINT [FK_Song_inherits_AudioFile]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[AudioFileSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'AudioFileSet_Podcast'
ALTER TABLE [dbo].[AudioFileSet_Podcast]
ADD CONSTRAINT [FK_Podcast_inherits_AudioFile]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[AudioFileSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------