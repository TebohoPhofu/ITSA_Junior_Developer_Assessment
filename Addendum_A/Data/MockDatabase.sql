--
-- File generated with SQLiteStudio v3.3.3 on Sat Apr 23 16:02:44 2022
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

Drop Table Class;
Drop Table Course;
Drop Table Instructor;
Drop Table Marks;
Drop Table Student;

-- Table: Class
CREATE TABLE Class (Id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL, StudentId INTEGER UNIQUE REFERENCES Student (Id) NOT NULL, CourseId INTEGER REFERENCES Course (Id) NOT NULL, InstructorId INTEGER REFERENCES Instructor (Id) NOT NULL, ClassStart TIME NOT NULL, ClassEnd TIME NOT NULL);
INSERT INTO Class (Id, StudentId, CourseId, InstructorId, ClassStart, ClassEnd) VALUES (1, 1, 1, 1, '08:30:00', '10:30:00');
INSERT INTO Class (Id, StudentId, CourseId, InstructorId, ClassStart, ClassEnd) VALUES (2, 2, 3, 4, '09:00:00', '12:00:00');
INSERT INTO Class (Id, StudentId, CourseId, InstructorId, ClassStart, ClassEnd) VALUES (3, 3, 2, 1, '08:30:00', '10:00:00');
INSERT INTO Class (Id, StudentId, CourseId, InstructorId, ClassStart, ClassEnd) VALUES (4, 4, 1, 5, '13:00:00', '15:00:00');
INSERT INTO Class (Id, StudentId, CourseId, InstructorId, ClassStart, ClassEnd) VALUES (5, 5, 4, 5, '15:00:00', '17:00:00');

-- Table: Course
CREATE TABLE Course (Id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL, Code VARCHAR UNIQUE NOT NULL, Name VARCHAR NOT NULL);
INSERT INTO Course (Id, Code, Name) VALUES (1, 'DPRS20', 'Computer Science');
INSERT INTO Course (Id, Code, Name) VALUES (2, 'DPAG20', 'Accounting');
INSERT INTO Course (Id, Code, Name) VALUES (3, 'DPES20', 'Economics');
INSERT INTO Course (Id, Code, Name) VALUES (4, 'DPAC19', 'Chemistry');
INSERT INTO Course (Id, Code, Name) VALUES (5, 'ADQU20', 'Quality Management');

-- Table: Instructor
CREATE TABLE Instructor (Id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL, Name VARCHAR NOT NULL);
INSERT INTO Instructor (Id, Name) VALUES (1, 'Alex');
INSERT INTO Instructor (Id, Name) VALUES (2, 'Vusi');
INSERT INTO Instructor (Id, Name) VALUES (3, 'Teboho');
INSERT INTO Instructor (Id, Name) VALUES (4, 'Marcus');
INSERT INTO Instructor (Id, Name) VALUES (5, 'Kamo');

-- Table: Marks
CREATE TABLE Marks (Id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL, Module1 INTEGER, Module2 INTEGER, Module3 INTEGER, StudentId INTEGER UNIQUE NOT NULL REFERENCES Student (Id), CourseId INTEGER REFERENCES Course (Id) NOT NULL);
INSERT INTO Marks (Id, Module1, Module2, Module3, StudentId, CourseId) VALUES (1, 60, 55, 75, 1, 1);
INSERT INTO Marks (Id, Module1, Module2, Module3, StudentId, CourseId) VALUES (2, 23, 98, 45, 2, 3);
INSERT INTO Marks (Id, Module1, Module2, Module3, StudentId, CourseId) VALUES (3, 35, 74, 77, 3, 2);
INSERT INTO Marks (Id, Module1, Module2, Module3, StudentId, CourseId) VALUES (4, 65, 87, 66, 4, 1);
INSERT INTO Marks (Id, Module1, Module2, Module3, StudentId, CourseId) VALUES (5, 32, 15, 55, 5, 4);

-- Table: Student
CREATE TABLE Student (Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, StudentNumber INT UNIQUE NOT NULL, Name VARCHAR NOT NULL, Address VARCHAR);
INSERT INTO Student (Id, StudentNumber, Name, Address) VALUES (1, 111, 'Steve', 'Gauteng');
INSERT INTO Student (Id, StudentNumber, Name, Address) VALUES (2, 115, 'Nick', 'North West');
INSERT INTO Student (Id, StudentNumber, Name, Address) VALUES (3, 114, 'Max', 'Free State');
INSERT INTO Student (Id, StudentNumber, Name, Address) VALUES (4, 113, 'Paul', 'North West');
INSERT INTO Student (Id, StudentNumber, Name, Address) VALUES (5, 112, 'Eve', 'Gauteng');

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
