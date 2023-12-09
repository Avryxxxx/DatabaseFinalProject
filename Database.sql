CREATE DATABASE GradingSystem;

CREATE TABLE Users (
    UserId INT(10) PRIMARY KEY,
    Username VARCHAR(50) NOT NULL,
    Password VARCHAR(50) NOT NULL
);

CREATE TABLE StudentInfo (
  StdId INT PRIMARY KEY,
  StdFirstName VARCHAR(15),
  StdLastName VARCHAR(16),
  Birthdate DATE,
  Gender VARCHAR(10),
  Phone VARCHAR(15),
  Address TEXT,
  Photo LONGBLOB
);

CREATE TABLE Grades (
  StdId INT,
  SubjectName VARCHAR(30),
  Quiz INT,
  Assessment INT,
  Activity INT,
  Project INT,
  MidtermExam INT,
  FinalExam INT,
  FinalGrade DOUBLE,
  PRIMARY KEY (StdId, SubjectName),
  FOREIGN KEY (StdId) REFERENCES StudentInfo(StdId)
);

