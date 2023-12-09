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

CREATE TABLE Subject (
  SubjectID INT PRIMARY KEY,
  SubjectName VARCHAR(30),
  SubjectHour INT,
  Description TEXT
);

INSERT INTO Users (UserId, Username, Password)
VALUE (1, 'sbuniv', 'sponge');

INSERT INTO StudentInfo (StdId, StdFirstName, StdLastName, Birthdate, Gender, Phone, Address, Photo)
VALUES
(1, 'SpongeBob', 'Squarepants', '2005-11-07', 'Male', '0937264827', '123 Conch St. Bikini Bottom', '[BLOB - 66.5 KiB]'),
(2, 'Pearl', 'Krabs', '2004-11-14', 'Female', '09731927645', '3541 Anchor St. Bikini Bottom', '[BLOB - 48.6 KiB]'),
(3, 'Sandy', 'Cheeks', '2002-05-03', 'Female', '0927591742', '126 Conch St. Bikini Bottom', '[BLOB - 544.2 KiB]'),
(4, 'Eugene', 'Krabs', '1975-11-30', 'Male', '0973719383', '3541 Anchor St. Bikini Bottom', '[BLOB - 53.8 KiB]'),
(5, 'Squidward', 'Tentacles', '1999-09-10', 'Male', '09738562846', '121 Conch St. Bikini Bottom', '[BLOB - 46.3 KiB]'),
(6, 'Larry', 'Lobster', '1988-05-15', 'Male', '09481857382', 'Bikini Bottom Gym', '[BLOB - 85.5 KiB]'),
(7, 'Penelope', 'Puff', '1978-08-15', 'Female', '09739275628', 'Puff boating School, Bikini Bottom', '[BLOB - 4.6 KiB]'),
(8, 'Sheldon', 'Plankton', '1983-02-22', 'Male', '09183826492', 'Chum Bucket, Bikini Bottom', '[BLOB - 3.7 KiB]'),
(9, 'Ray', 'Ray', '1976-12-05', 'Male', '09956734628', 'Star House Basement', '[BLOB - 6.5 KiB]'),
(10, 'Karen', 'Plankton', '1983-11-14', 'Female', '09293729372', 'Chum Bucket, Bikini Bottom', '[BLOB - 36.6 KiB]');

INSERT INTO Subject (SubjectID, SubjectName, SubjectHour, Description)
VALUES
(1, 'Computer Networking 1', 8, 'Foundational computer network concepts'),
(2, 'Advance Computer Programming', 9, 'Comprehensive Advanced Computer Programming'),
(3, 'Asean Literature', 4, 'Asean Literature and Cultural Perspectives'),
(4, 'Physical Education', 5, 'Sports and Fitness Physical Education Program'),
(5, 'Object Oriented Programming', 8, 'Practical Object-Oriented Programming Skills'),
(6, 'Discrete Mathematics', 5, 'Rigorous Discrete Mathematics Study');

