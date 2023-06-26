-- Script Date: 26.04.2023 13:39  - ErikEJ.SqlCeScripting version 3.5.2.94
CREATE TABLE [customers] (
  [Id] INTEGER NOT NULL
, [name] TEXT NOT NULL
, [email] TEXT NULL
, [password_hash] TEXT NOT NULL
, CONSTRAINT [PK_customers] PRIMARY KEY ([Id])
);
