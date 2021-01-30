IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Buildings] (
    [Id] bigint NOT NULL,
    [Address] nvarchar(max) NULL,
    [Phone] nvarchar(max) NULL,
    [Discriminator] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Buildings] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Empoyees] (
    [Id] bigint NOT NULL,
    [Username] nvarchar(max) NULL,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [Address] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [AccountNumber] nvarchar(max) NULL,
    [SSecurityNumber] nvarchar(max) NULL,
    [Salary] decimal(18,2) NOT NULL,
    [Discriminator] nvarchar(max) NOT NULL,
    [ShopId] bigint NULL,
    [WarehouseId] bigint NULL,
    CONSTRAINT [PK_Empoyees] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Empoyees_Buildings_ShopId] FOREIGN KEY ([ShopId]) REFERENCES [Buildings] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Empoyees_Buildings_WarehouseId] FOREIGN KEY ([WarehouseId]) REFERENCES [Buildings] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Empoyees_ShopId] ON [Empoyees] ([ShopId]);

GO

CREATE INDEX [IX_Empoyees_WarehouseId] ON [Empoyees] ([WarehouseId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201209210950_Initial', N'3.1.5');

GO

