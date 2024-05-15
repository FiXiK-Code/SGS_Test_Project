CREATE TABLE Operations (
    ID INT identity,
    ContainerID INT,
    StartDate DATETIME,
    EndDate DATETIME,
    OperationType VARCHAR(255),
    OperatorName VARCHAR(255),
    InspectionLocation VARCHAR(255),
    PRIMARY KEY (ID),
    FOREIGN KEY (ContainerID) REFERENCES Containers(ID)
);