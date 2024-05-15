CREATE TABLE Containers (
    ID INT identity,
    Number INT,
    Type VARCHAR(255),
    Length INT,
    Width INT,
    Height INT,
    Weight INT,
    IsEmpty BIT,
    ArrivalDate DATETIME,
    PRIMARY KEY (ID)
);
