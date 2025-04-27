create database Outfity;

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY,
    Email NVARCHAR(255) NOT NULL,
    PasswordHash NVARCHAR(MAX) NOT NULL,
    Gender NVARCHAR(10),          -- Male / Female
    HijabStyle NVARCHAR(50),      -- Optional: "None", "Hijab", "Turban", etc.
    PreferredColors NVARCHAR(MAX),
    PreferredStyles NVARCHAR(MAX),
    BodyType NVARCHAR(50),
    CreatedAt DATETIME DEFAULT GETUTCDATE()
);

CREATE TABLE ClosetItems (
    Id INT PRIMARY KEY IDENTITY,
    UserId INT FOREIGN KEY REFERENCES Users(Id),
    Name NVARCHAR(100),
    Type NVARCHAR(50),            -- "Shirt", "Pants", etc.
    Color NVARCHAR(50),
    Season NVARCHAR(50),          -- "Winter", "Summer"
    Occasion NVARCHAR(50),        -- "Work", "Casual", etc.
    Material NVARCHAR(50),
    ImageUrl NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETUTCDATE()
);
CREATE TABLE Outfits (
    Id INT PRIMARY KEY IDENTITY,
    UserId INT FOREIGN KEY REFERENCES Users(Id),
    Name NVARCHAR(100),
    Description NVARCHAR(MAX),
    ImageUrl NVARCHAR(MAX),           -- AI-generated or assembled image (optional)
    IsFavorite BIT DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETUTCDATE()
);
CREATE TABLE OutfitItems (
    Id INT PRIMARY KEY IDENTITY,
    OutfitId INT FOREIGN KEY REFERENCES Outfits(Id),
    ClosetItemId INT FOREIGN KEY REFERENCES ClosetItems(Id)
);
CREATE TABLE AI_History (
    Id INT PRIMARY KEY IDENTITY,
    UserId INT FOREIGN KEY REFERENCES Users(Id),
    TriggeredByItemId INT NULL,      -- القطعة الجديدة
    SuggestedOutfitId INT NULL,      -- ممكن يكون أوتفيت تولد
    Notes NVARCHAR(MAX),             -- أي تعليقات أو وصف
    CreatedAt DATETIME DEFAULT GETUTCDATE()
);
CREATE TABLE StyleTags (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50)
);
CREATE TABLE ClosetItemTags (
    Id INT PRIMARY KEY IDENTITY,
    ClosetItemId INT FOREIGN KEY REFERENCES ClosetItems(Id),
    StyleTagId INT FOREIGN KEY REFERENCES StyleTags(Id)
);
