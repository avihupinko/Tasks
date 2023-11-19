IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(250) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [UserTasks] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [Subject] nvarchar(250) NOT NULL,
    [TargetDate] datetime2 NOT NULL,
    [IsCompleted] bit NOT NULL,
    CONSTRAINT [PK_UserTasks] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserTasks_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([Id], [Name])
VALUES (1, N'Avihu'),
(2, N'Dotan'),
(3, N'Ariel');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

CREATE INDEX [IX_UserTasks_UserId] ON [UserTasks] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231119092644_init-db', N'7.0.14');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsCompleted', N'Subject', N'TargetDate', N'UserId') AND [object_id] = OBJECT_ID(N'[UserTasks]'))
    SET IDENTITY_INSERT [UserTasks] ON;
INSERT INTO [UserTasks] ([Id], [IsCompleted], [Subject], [TargetDate], [UserId])
VALUES (1, CAST(0 AS bit), N'Task1', '2023-11-11T00:00:00.0000000', 1),
(2, CAST(1 AS bit), N'Task2', '2023-11-11T00:00:00.0000000', 2),
(3, CAST(0 AS bit), N'Task3', '2023-11-11T00:00:00.0000000', 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsCompleted', N'Subject', N'TargetDate', N'UserId') AND [object_id] = OBJECT_ID(N'[UserTasks]'))
    SET IDENTITY_INSERT [UserTasks] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231119094232_init-db_2', N'7.0.14');
GO

COMMIT;
GO

