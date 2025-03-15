CREATE TABLE Users (
                       Id INTEGER PRIMARY KEY AUTOINCREMENT,
                       Username TEXT NOT NULL UNIQUE,
                       PasswordHash TEXT NOT NULL,
                       Email TEXT NOT NULL
);

CREATE TABLE Categories (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL UNIQUE
);

CREATE TABLE Words (
                       Id INTEGER PRIMARY KEY AUTOINCREMENT,
                       English TEXT NOT NULL,
                       Polish TEXT NOT NULL
);

CREATE TABLE WordCategories (
                                WordId INTEGER NOT NULL,
                                CategoryId INTEGER NOT NULL,
                                FOREIGN KEY (WordId) REFERENCES Words(Id),
                                FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
                                PRIMARY KEY (WordId, CategoryId)
);

CREATE TABLE WordDifficulty (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                WordId INTEGER NOT NULL,
                                DifficultyLevel TEXT NOT NULL,
                                FOREIGN KEY (WordId) REFERENCES Words(Id)
);

CREATE TABLE UserWords (
                           Id INTEGER PRIMARY KEY AUTOINCREMENT,
                           UserId INTEGER NOT NULL,
                           WordId INTEGER NOT NULL,
                           FOREIGN KEY (UserId) REFERENCES Users(Id),
                           FOREIGN KEY (WordId) REFERENCES Words(Id)
);
