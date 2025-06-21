using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTic_Management_System.Database_Uses;

namespace UnicomTic_Management_System.Repositories
{
    internal static class Migration
    {
        internal static void CreateTable()
        {
            using (SQLiteConnection connect = DatabaseManager.GetConnection()) 
            {
                SQLiteCommand command = connect.CreateCommand();
                command.CommandText = @"CREATE TABLE IF NOT EXISTS Users(
                                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Name TEXT NOT NULL UNIQUE,
                                        GMail TEXT NOT NULL,
                                        Password TEXT NOT NULL,
                                        Role TEXT NOT NULL,
                                        CreatedDate TEXT NOT NULL,
                                        UpdatedDate TEXT NOT NULL);

                                        CREATE TABLE IF NOT EXISTS Departments(
                                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Name TEXT NOT NULL UNIQUE);
                                        
                                        CREATE TABLE IF NOT EXISTS Courses(
                                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Name TEXT NOT NULL,
                                        DepartmentsID INTEGER NOT NULL,
                                        FOREIGN KEY (DepartmentsID) REFERENCES Departments(ID));

                                        CREATE TABLE IF NOT EXISTS Admins(
                                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Date TEXT NOT NULL,
                                        FirstName TEXT NOT NULL,
                                        LastName TEXT NOT NULL,
                                        Address TEXT NOT NULL,
                                        Phone TEXT NOT NULL UNIQUE,
                                        Gender TEXT NOT NULL,
                                        NicNumber TEXT NOT NULL UNIQUE,
                                        AccessLevel TEXT NOT NULL,
                                        UsersID INTEGR,
                                        FOREIGN KEY (UsersID) REFERENCES Users(ID));

                                        CREATE TABLE IF NOT EXISTS Staffs(
                                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Date TEXT NOT NULL,
                                        FirstName TEXT NOT NULL,
                                        LastName TEXT NOT NULL,
                                        Address TEXT NOT NULL,
                                        Phone TEXT NOT NULL UNIQUE,
                                        Gender TEXT NOT NULL,
                                        NicNumber TEXT NOT NULL UNIQUE,
                                        Designation TEXT NOT NULL,
                                        Salary REAL NOT NULL,
                                        UsersID INTEGR NOT NULL,
                                        FOREIGN KEY (UsersID) REFERENCES Users(ID));

                                        CREATE TABLE IF NOT EXISTS Lecturers(
                                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Date TEXT NOT NULL,
                                        FirstName TEXT NOT NULL,
                                        LastName TEXT NOT NULL,
                                        Address TEXT NOT NULL,
                                        Phone TEXT NOT NULL,
                                        Gender TEXT NOT NULL,
                                        NicNumber TEXT NOT NULL UNIQUE,
                                        EmployeeNo TEXT NOT NULL,
                                        Salary REAL NOT NULL,
                                        DepartmentsID INTEGER NOT NULL,
                                        UsersID INTEGR NOT NULL,
                                        FOREIGN KEY (DepartmentsID) REFERENCES Departments(ID),
                                        FOREIGN KEY (UsersID) REFERENCES Users(ID));

                                        CREATE TABLE IF NOT EXISTS CourseLecturer(
                                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                        CoursesID INTEGER,
                                        LecturersID INTEGER,
                                        UNIQUE(CoursesID, LecturersID)
                                        FOREIGN KEY (CoursesID) REFERENCES Courses(ID),
                                        FOREIGN KEY (LecturersID) REFERENCES Lecturers(ID));

                                        CREATE TABLE IF NOT EXISTS Rooms(
                                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Type TEXT NOT NULL,
                                        Name TEXT NOT NULL);

                                        CREATE TABLE IF NOT EXISTS Students(
                                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Date TEXT NOT NULL,
                                        FirstName TEXT NOT NULL,
                                        LastName TEXT NOT NULL,
                                        Address TEXT NOT NULL,
                                        Gender TEXT NOT NULL,
                                        StudentId TEXT NOT NULL,
                                        Phone TEXT NOT NULL,
                                        NicNumber TEXT NOT NULL,
                                        CoursesID INTEGER,
                                        DepartmentsID INTEGER,
                                        UsersID INTEGR,
                                        FOREIGN KEY (UsersID) REFERENCES Users(ID),                                        
                                        FOREIGN KEY (DepartmentsID) REFERENCES Departments(ID),
                                        FOREIGN KEY (CoursesID) REFERENCES Courses(ID));

                                        CREATE TABLE IF NOT EXISTS Subjects(
                                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Name TEXT NOT NULL,
                                        LecturersID INTEGER NOT NULL,
                                        DepartmentsID INTEGER NOT NULL,
                                        FOREIGN KEY (DepartmentsID) REFERENCES Departments(ID),
                                        FOREIGN KEY (LecturersID) REFERENCES Lecturers(ID));

                                        

                                        CREATE TABLE IF NOT EXISTS CourseSubject(
                                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                        CoursesID INTEGER NOT NULL,
                                        SubjectsID INTEGER NOT NULL,
                                        FOREIGN KEY (CoursesID) REFERENCES Courses(ID),
                                        FOREIGN KEY (SubjectsID) REFERENCES Subjects(ID));

                                        CREATE TABLE IF NOT EXISTS Exams(
                                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Date TEXT NOT NULL,
                                        Name TEXT NOT NULL,
                                        SubjectsID INTEGER,
                                        FOREIGN KEY (SubjectsID) REFERENCES Subjects(ID));

                                        CREATE TABLE IF NOT EXISTS ExamMarks(
                                        ExamsID INTEGER,
                                        StudentsID INTEGER,
                                        Score TEXT NOT NULL,
                                        FOREIGN KEY (ExamsID) REFERENCES Exams(ID),
                                        FOREIGN KEY (StudentsID) REFERENCES Students(ID));

                                        CREATE TABLE IF NOT EXISTS LecturerStudent(
                                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                        LecturersID INTEGER,
                                        StudentsID INTEGER,
                                        FOREIGN KEY (LecturersID) REFERENCES Lecturers(ID),
                                        FOREIGN KEY (StudentsID) REFERENCES Students(ID));

                                        CREATE TABLE IF NOT EXISTS StudentSubject(
                                        StudentsID INTEGER,
                                        SubjectsID INTEGER,
                                        FOREIGN KEY (StudentsID) REFERENCES Students(ID),
                                        FOREIGN KEY (SubjectsID) REFERENCES Subjects(ID));

                                        CREATE TABLE IF NOT EXISTS TimeTables(
                                        Date TEXT NOT NULL,
                                        Time TEXT NOT NULL,
                                        SubjectsID INTEGER,
                                        RoomsID INTEGER,
                                        FOREIGN KEY (SubjectsID) REFERENCES Subjects(ID),
                                        FOREIGN KEY (RoomsID) REFERENCES Rooms(ID));
                                        ";
                command.ExecuteNonQuery();
            }
           
        }
        internal static object ExistsUsersTable() 
        {
            using (SQLiteConnection connection =DatabaseManager.GetConnection())
            {
                SQLiteCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT Id FROM Users WHERE Id=@id";
                cmd.Parameters.AddWithValue("@id",1);
                int result = cmd.ExecuteNonQuery();
                return result;
            }
        }
    }
}

