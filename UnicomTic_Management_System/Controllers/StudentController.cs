using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTic_Management_System.Database_Uses;
using UnicomTic_Management_System.Models;

namespace UnicomTic_Management_System.Controllers
{
    internal class StudentController : CommanUses
    {
        public List<string> CheckEmptyVariables(Students student,string GMail)
        {
            List<string> Deta = new List<string>();
            foreach (PropertyInfo prop in student.GetType().GetProperties())
            {
                if (prop.GetValue(student) == null || string.IsNullOrWhiteSpace(prop.GetValue(student).ToString()))
                {
                    Deta.Add(prop.Name);
                }
                else if (prop.PropertyType == typeof(int) && Convert.ToInt32(prop.GetValue(student)) ==0) 
                {

                    Deta.Add(prop.Name); 
                }
            }
            if (string.IsNullOrWhiteSpace(GMail)) { Deta.Add("Gmail"); }
            return Deta;

        }
        private string StudentNum()
        {
            using (SQLiteConnection connect = DatabaseManager.GetConnection())
            {
                SQLiteCommand cmd = connect.CreateCommand();
                cmd.CommandText = "SELECT StudentId FROM Students ORDER BY Id DESC LIMIT 1;";
                object lastId = cmd.ExecuteScalar();
                if (lastId == null || lastId == DBNull.Value) { return "STU1000"; }
                else
                {
                    return ($"STU{(Convert.ToInt32(lastId.ToString().Substring(3)) + 1).ToString()}");
                }
            }
        }
        public List<Students> LoadStudents(string Search)
        {
            List<Students> list = new List<Students>();
            using (SQLiteConnection connect = DatabaseManager.GetConnection())
            {
                SQLiteCommand cmd = connect.CreateCommand();
                cmd.CommandText = @"SELECT Students.* , Courses.Name AS CourseName ,Departments.Name AS DepartmentName FROM Students
                                    LEFT JOIN Courses ON Courses.ID = Students.CoursesID
                                    LEFT JOIN Departments ON Departments.ID =Students.DepartmentsID";
                using (var Readings = cmd.ExecuteReader())
                {
                    while (Readings.Read())
                    {
                        if (string.IsNullOrWhiteSpace(Search))
                        {
                            list.Add(new Students
                            {
                                Id = Convert.ToInt32(Readings["ID"]),
                                Date = Readings["Date"].ToString(),
                                FirstName = Readings["FirstName"].ToString(),
                                LastName = Readings["LastName"].ToString(),
                                Address = Readings["Address"].ToString(),
                                Phone = Readings["Phone"].ToString(),
                                Gender = Readings["Gender"].ToString(),
                                NicNo = Readings["NicNumber"].ToString(),
                                StudentNo = Readings["StudentId"].ToString(),
                                CourseName = Readings["CourseName"].ToString(),
                                DepartmentName = Readings["DepartmentName"].ToString(),
                                UserID = Convert.ToInt32(Readings["UsersID"]),
                              
                            });
                        }
                        else
                        {
                            for (int j = 1; j <= 11; j++)
                            {
                                if (Readings[j].ToString().Contains(Search))
                                {
                                    list.Add(new Students
                                    {
                                        Id = Convert.ToInt32(Readings["ID"]),
                                        Date = Readings["Date"].ToString(),
                                        FirstName = Readings["FirstName"].ToString(),
                                        LastName = Readings["LastName"].ToString(),
                                        Address = Readings["Address"].ToString(),
                                        Phone = Readings["Phone"].ToString(),
                                        Gender = Readings["Gender"].ToString(),
                                        NicNo = Readings["NicNumber"].ToString(),
                                        StudentNo = Readings["StudentId"].ToString(),
                                        CourseName = Readings["CourseName"].ToString(),
                                        DepartmentName = Readings["DepartmentName"].ToString(),
                                        UserID = Convert.ToInt32(Readings["UsersID"]),

                                    });
                                    break;
                                }
                            }
                        }

                    }
                }
            }
            return list;
        }
        public int StudentRegister(Students student)
        {
            if (!string.IsNullOrWhiteSpace(student.FirstName) && !string.IsNullOrWhiteSpace(student.LastName) && !string.IsNullOrWhiteSpace(student.NicNo)
                && !string.IsNullOrWhiteSpace(student.Address) && !string.IsNullOrWhiteSpace(student.Phone) && student.DepartmentID != 0
                && student.CourseID != 0 && !string.IsNullOrWhiteSpace(student.Gender))
            {
                student.UserID = GetLastInsertedId();
                string PoneResult = PhoneValidation(student.Phone);
                string NicResult = NicValidation(student.NicNo);
                if (PoneResult == "Invalid")
                { 
                    UserController.DeleteUser(student.UserID);
                    return 0;
                }
                else if (NicResult == "Invalid")
                {
                    UserController.DeleteUser(student.UserID);
                    return 0;
                }
                else
                {
                    student.StudentNo = StudentNum();
                    try
                    {
                        using (SQLiteConnection connect = DatabaseManager.GetConnection())
                        {
                            SQLiteCommand cmd = connect.CreateCommand();
                            cmd.CommandText = @"INSERT INTO Students(Date,FirstName,LastName,Address,Gender,StudentId,Phone,NicNumber,CoursesID,DepartmentsID,UsersID)
                                        VALUES(@date,@fName,@lName,@address,@gender,@sid,@phone,@nic,@cid,@did,@uid);
                                        SELECT last_insert_rowid()";
                            cmd.Parameters.AddWithValue("@date",student.Date);
                            cmd.Parameters.AddWithValue("@fName",student.FirstName);
                            cmd.Parameters.AddWithValue("@lName",student.LastName);
                            cmd.Parameters.AddWithValue("@address",student.Address);
                            cmd.Parameters.AddWithValue("@gender",student.Gender);
                            cmd.Parameters.AddWithValue("@sid",student.StudentNo);
                            cmd.Parameters.AddWithValue("@phone",student.Phone);
                            cmd.Parameters.AddWithValue("@nic",student.NicNo);
                            cmd.Parameters.AddWithValue("@cid",student.CourseID);
                            cmd.Parameters.AddWithValue("@did",student.DepartmentID);
                            cmd.Parameters.AddWithValue("@uid",student.UserID);

                            int ID = Convert.ToInt32(cmd.ExecuteScalar());
                            return ID;
                        }
                    }
                    catch (SQLiteException ex) when (ex.ResultCode == SQLiteErrorCode.Constraint)
                    {
                        if (ex.Message.Contains("Phone")) { MessageBox.Show("This Mobile Number Already Registered!"); }
                        else if (ex.Message.Contains("NicNumber")) { MessageBox.Show("This NIC Number Already Registered!"); }
                        UserController.DeleteUser(student.UserID);
                        return 0;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Fill All  d Details");
                UserController.DeleteUser(student.UserID);
                return 0;
            }
        }
        public void DeleteStudent(Students student)
        {
            if (student.Id == 0) { MessageBox.Show("Select a Student!"); }
            else
            {
                DialogResult result = MessageBox.Show("Confirm Delete This Student", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    using (SQLiteConnection connect = DatabaseManager.GetConnection())
                    {
                        LecturerStudent.DeleteStudentLecturer(connect, student.Id);
                        StudentSubjectController.DeleteStudentSubject(connect, student.Id);
                        SQLiteCommand cmd = connect.CreateCommand();
                        cmd.CommandText = "DELETE FROM Students WHERE ID=@id";
                        cmd.Parameters.AddWithValue("@id", student.Id);
                        cmd.ExecuteNonQuery();
                        UserController.DeleteUser(student.UserID);
                        MessageBox.Show("Student Deleted Successfully");
                    }
                }
            }
        }
        public void UpdateStudent(Students student)
        {
            if (!string.IsNullOrWhiteSpace(student.FirstName) && !string.IsNullOrWhiteSpace(student.LastName) && !string.IsNullOrWhiteSpace(student.NicNo) &&
               !string.IsNullOrWhiteSpace(student.Phone) && !string.IsNullOrWhiteSpace(student.Gender) && !string.IsNullOrWhiteSpace(student.Address))
            {
                DialogResult result = MessageBox.Show("Make Changes for This Student", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    using (SQLiteConnection connect = DatabaseManager.GetConnection())
                    {
                        using (SQLiteCommand cmd = connect.CreateCommand())
                        {
                            cmd.CommandText = @"UPDATE Students SET FirstName=@fname, LastName=@lname, NicNumber=@nic, Phone=@phone, Gender=@gender, Address=@address WHERE ID=@id";
                            cmd.Parameters.AddWithValue("@id", student.Id);
                            cmd.Parameters.AddWithValue("@fname", student.FirstName);
                            cmd.Parameters.AddWithValue("@lname", student.LastName);
                            cmd.Parameters.AddWithValue("@nic", student.NicNo);
                            cmd.Parameters.AddWithValue("@phone", student.Phone);
                            cmd.Parameters.AddWithValue("@gender", student.Gender);
                            cmd.Parameters.AddWithValue("@address", student.Address);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Updated Successfully");
                        }
                    }
                }
            }
            else { MessageBox.Show("Fill All Details!"); }
        }
        public static int GetStudentCourseID(int UserID) 
        {
            using(SQLiteConnection connect = DatabaseManager.GetConnection()) 
            {
                SQLiteCommand cmd = connect.CreateCommand();
                cmd.CommandText = "SELECT CoursesID FROM Students WHERE UsersID=@uid ";
                cmd.Parameters.AddWithValue("@uid", UserID);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
