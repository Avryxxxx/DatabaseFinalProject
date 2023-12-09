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
VALUES (1, 'sbuniv', 'sponge');

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

INSERT INTO Grades (`StdId`, `SubjectName`, `Quiz`, `Assessment`, `Activity`, `Project`, `MidtermExam`, `FinalExam`, `FinalGrade`) 
VALUES 
(1, 'Computer Networking 1', 85, 90, 78, 95, 88, 92, 89.5),
(1, 'Advance Computer Programming', 92, 88, 96, 85, 90, 91, 92.3),
(1, 'Asean Literature', 78, 85, 80, 92, 86, 88, 84.5),
(1, 'Physical Education', 95, 98, 92, 100, 88, 90, 94.7),
(1, 'Object Oriented Programming', 88, 94, 90, 87, 93, 95, 91.8),
(1, 'Discrete Mathematics', 90, 86, 94, 88, 92, 89, 91.5),
(2, 'Computer Networking 1', 89, 73, 100, 100, 99, 99, 93.45),
(2, 'Advance Computer Programming', 95, 85, 92, 88, 94, 96, 91.7),
(2, 'Asean Literature', 87, 91, 78, 96, 85, 89, 88.2),
(2, 'Physical Education', 98, 100, 94, 92, 90, 92, 95.6),
(2, 'Object Oriented Programming', 91, 88, 96, 90, 87, 94, 92.3),
(2, 'Discrete Mathematics', 86, 94, 90, 88, 95, 91, 91.2),
(3, 'Computer Networking 1', 92, 84, 89, 93, 87, 91, 90.5),
(3, 'Advance Computer Programming', 90, 87, 91, 89, 92, 88, 89.8),
(3, 'Asean Literature', 85, 89, 92, 94, 88, 90, 89.6),
(3, 'Physical Education', 94, 92, 88, 91, 89, 93, 91.6),
(3, 'Object Oriented Programming', 89, 91, 95, 86, 93, 87, 90.4),
(3, 'Discrete Mathematics', 91, 88, 90, 92, 94, 89, 90.8),
(4, 'Computer Networking 1', 91, 89, 87, 92, 90, 94, 90.8),
(4, 'Advance Computer Programming', 87, 91, 94, 88, 92, 89, 90.2),
(4, 'Asean Literature', 90, 86, 92, 89, 91, 88, 89.6),
(4, 'Physical Education', 93, 95, 89, 91, 94, 87, 91.4),
(4, 'Object Oriented Programming', 92, 88, 90, 93, 89, 91, 90.8),
(4, 'Discrete Mathematics', 88, 90, 87, 94, 92, 89, 90),
(5, 'Computer Networking 1', 89, 92, 86, 90, 87, 93, 89.5),
(5, 'Advance Computer Programming', 91, 87, 94, 88, 92, 89, 90.2),
(5, 'Asean Literature', 88, 90, 87, 94, 92, 89, 90),
(5, 'Physical Education', 93, 95, 89, 91, 94, 87, 91.4),
(5, 'Object Oriented Programming', 92, 88, 90, 93, 89, 91, 90.8),
(5, 'Discrete Mathematics', 90, 86, 92, 89, 91, 88, 89.6),
(6, 'Computer Networking 1', 85, 89, 90, 92, 94, 87, 89.6),
(6, 'Advance Computer Programming', 91, 86, 94, 88, 92, 89, 89.7),
(6, 'Asean Literature', 88, 90, 87, 94, 92, 89, 90),
(6, 'Physical Education', 93, 95, 89, 91, 94, 87, 91.4),
(6, 'Object Oriented Programming', 92, 88, 90, 93, 89, 91, 90.8),
(6, 'Discrete Mathematics', 90, 86, 92, 89, 91, 88, 89.6),
(7, 'Computer Networking 1', 89, 92, 86, 90, 87, 93, 89.5),
(7, 'Advance Computer Programming', 91, 87, 94, 88, 92, 89, 90.2),
(7, 'Asean Literature', 88, 90, 87, 94, 92, 89, 90),
(7, 'Physical Education', 93, 95, 89, 91, 94, 87, 91.4),
(7, 'Object Oriented Programming', 92, 88, 90, 93, 89, 91, 90.8),
(7, 'Discrete Mathematics', 90, 86, 92, 89, 91, 88, 89.6),
(8, 'Computer Networking 1', 91, 89, 87, 92, 90, 94, 90.8),
(8, 'Advance Computer Programming', 87, 91, 94, 88, 92, 89, 90.2),
(8, 'Asean Literature', 90, 86, 92, 89, 91, 88, 89.6),
(8, 'Physical Education', 93, 95, 89, 91, 94, 87, 91.4),
(8, 'Object Oriented Programming', 92, 88, 90, 93, 89, 91, 90.8),
(8, 'Discrete Mathematics', 88, 90, 87, 94, 92, 89, 90),
(9, 'Computer Networking 1', 90, 91, 93, 88, 94, 86, 91.5),
(9, 'Advance Computer Programming', 88, 90, 87, 92, 89, 91, 90.8),
(9, 'Asean Literature', 89, 92, 86, 91, 93, 87, 90.3),
(9, 'Physical Education', 91, 87, 94, 88, 92, 89, 90.2),
(9, 'Object Oriented Programming', 94, 86, 92, 89, 91, 88, 90),
(9, 'Discrete Mathematics', 90, 89, 87, 94, 92, 89, 90.2),
(10, 'Computer Networking 1', 92, 85, 88, 90, 94, 89, 90.7),
(10, 'Advance Computer Programming', 88, 92, 85, 96, 91, 87, 90.3),
(10, 'Asean Literature', 89, 78, 86, 91, 92, 94, 88.7),
(10, 'Physical Education', 96, 94, 98, 89, 90, 93, 94.2),
(10, 'Object Oriented Programming', 94, 90, 87, 92, 89, 95, 91.8),
(10, 'Discrete Mathematics', 90, 91, 93, 88, 94, 86, 91.5);


SELECT StudentInfo.StdId, StdFirstName, StdLastName, SubjectName, FinalGrade
FROM StudentInfo
JOIN Grades ON StudentInfo.StdId = Grades.StdId
WHERE SubjectName = 'Computer Networking 1';

SELECT StudentInfo.StdId, StdFirstName, StdLastName, SubjectName
FROM StudentInfo
JOIN Grades ON StudentInfo.StdId = Grades.StdId;

SELECT Subject.SubjectName, StudentInfo.StdId, StdFirstName, StdLastName
FROM Subject
JOIN Grades ON Subject.SubjectName = Grades.SubjectName
JOIN StudentInfo ON Grades.StdId = StudentInfo.StdId;

SELECT StudentInfo.StdId, StdFirstName, StdLastName, SubjectName, FinalGrade, SubjectHour, Description
FROM StudentInfo
JOIN Grades ON StudentInfo.StdId = Grades.StdId
JOIN Subject ON Grades.SubjectName = Subject.SubjectName;

SELECT StudentInfo.StdId, StdFirstName, StdLastName, SubjectName, FinalGrade, SubjectHour, Description
FROM StudentInfo
JOIN Grades ON StudentInfo.StdId = Grades.StdId
JOIN Subject ON Grades.SubjectName = Subject.SubjectName;

SELECT Subject.SubjectName, StudentInfo.StdId, StdFirstName, StdLastName, FinalGrade
FROM Subject
JOIN Grades ON Subject.SubjectName = Grades.SubjectName
JOIN StudentInfo ON Grades.StdId = StudentInfo.StdId;

