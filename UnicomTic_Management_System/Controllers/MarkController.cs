using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTic_Management_System.Database_Uses;
using UnicomTic_Management_System.Models;

namespace UnicomTic_Management_System.Controllers
{
    internal class MarkController
    {
        public static void AddStudentExam(Exams exam) 
        {
            using(SQLiteConnection connect = DatabaseManager.GetConnection()) 
            {
                using (SQLiteCommand cmd = connect.CreateCommand()) 
                {
                    cmd.CommandText = @"INSERT INTO ExamMarks (ExamsID, StudentsID)SELECT                              
                                    @id, StudentsID FROM StudentSubject WHERE SubjectsID = @sid;";
                    cmd.Parameters.AddWithValue("@id", exam.ID);
                    cmd.Parameters.AddWithValue("@sid", exam.SubjectID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<Marks> ViewExamMArks(string role, int UserID,string Search)
        {
            int StudentID = 0;
            if (role == "Student")
            {
                StudentID = StudentController.GetStudentID(UserID);
            }
            List<Marks> list = new List<Marks>();
            using (SQLiteConnection connect = DatabaseManager.GetConnection())
            {
                using (SQLiteCommand cmd = connect.CreateCommand()) 
                {
                    cmd.CommandText = @"SELECT  ExamMarks.ID, ExamMarks.ExamsID, ExamMarks.StudentsID, ExamMarks.Score,
                                    Exams.Heading AS ExamName, Students.LastName AS StudentName
                                    FROM ExamMarks LEFT JOIN Exams ON Exams.ID = ExamMarks.ExamsID
                                    LEFT JOIN Students ON Students.ID = ExamMarks.StudentsID";
                    using (var reading = cmd.ExecuteReader())
                        while (reading.Read())
                        {
                            if (role != "Student" && string.IsNullOrWhiteSpace(Search))
                            {
                                list.Add(new Marks
                                {
                                    ID = Convert.ToInt32(reading["ID"]),
                                    ExamName = reading["ExamName"].ToString(),
                                    ExamID = Convert.ToInt32(reading["ExamsID"]),
                                    StudentName = reading["StudentName"].ToString(),
                                    StudentID = Convert.ToInt32(reading["StudentsID"]),
                                    Score = reading["Score"].ToString()
                                });
                            }
                            else if (role != "Student" && (reading["ExamName"].ToString().Contains(Search)
                                || reading["StudentName"].ToString().Contains(Search)))
                            {
                                list.Add(new Marks
                                {
                                    ID = Convert.ToInt32(reading["ID"]),
                                    ExamName = reading["ExamName"].ToString(),
                                    ExamID = Convert.ToInt32(reading["ExamsID"]),
                                    StudentName = reading["StudentName"].ToString(),
                                    StudentID = Convert.ToInt32(reading["StudentsID"]),
                                    Score = reading["Score"].ToString()
                                });
                            }
                            else if (reading["StudentsID"].ToString() == StudentID.ToString() && string.IsNullOrWhiteSpace(Search))
                            {
                                list.Add(new Marks
                                {
                                    ID = Convert.ToInt32(reading["ID"]),
                                    ExamName = reading["ExamName"].ToString(),
                                    ExamID = Convert.ToInt32(reading["ExamsID"]),
                                    StudentName = reading["StudentName"].ToString(),
                                    StudentID = Convert.ToInt32(reading["StudentsID"]),
                                    Score = reading["Score"].ToString()
                                });
                            }
                            else if (reading["StudentsID"].ToString() == StudentID.ToString() &&
                                ((reading["ExamName"].ToString().Contains(Search) || reading["StudentName"].ToString().Contains(Search))))
                            {
                                list.Add(new Marks
                                {
                                    ID = Convert.ToInt32(reading["ID"]),
                                    ExamName = reading["ExamName"].ToString(),
                                    ExamID = Convert.ToInt32(reading["ExamsID"]),
                                    StudentName = reading["StudentName"].ToString(),
                                    StudentID = Convert.ToInt32(reading["StudentsID"]),
                                    Score = reading["Score"].ToString()
                                });
                            }

                        }
                }
            }
            return list;
        }
        public void DeleteMark(int ID)
        {
            DialogResult result = MessageBox.Show("Confirm Delete This Mark History ", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SQLiteConnection connect = DatabaseManager.GetConnection())
                {
                    using (SQLiteCommand cmd = connect.CreateCommand()) 
                    {
                        cmd.CommandText = "DELETE FROM ExamMarks WHERE ID=@id";
                        cmd.Parameters.AddWithValue("@id", ID);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("SuccessFully Mark History Removed");
                }
            }
        }
        public bool UpdateMark(Marks mark)
        {
            bool result;
            if (!string.IsNullOrWhiteSpace(mark.Score) && mark.ID>0)
            {
                if (mark.Score.All(Char.IsDigit))
                {
                    if( 0 <= Convert.ToInt32(mark.Score) && Convert.ToInt32(mark.Score) <= 100) 
                    {
                        using (SQLiteConnection connect = DatabaseManager.GetConnection())
                        {
                            using (SQLiteCommand cmd = connect.CreateCommand())
                            {
                                cmd.CommandText = @"UPDATE ExamMarks SET Score =@score  WHERE ID=@id";
                                cmd.Parameters.AddWithValue("@id", mark.ID);
                                cmd.Parameters.AddWithValue("@score", mark.Score);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Successfully ExamMarks Updated");
                                result = true;
                            }

                        }
                    }
                    else { MessageBox.Show("Enter a Valid Score!"); }
                    result = false;
                }
                else { MessageBox.Show("Score Number Only!"); }
                result = false;
            }
            else
            {
                MessageBox.Show("Enter a Marks!");
                result = false;
            }
            return result;


        }
    }
}
