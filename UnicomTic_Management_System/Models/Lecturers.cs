using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTic_Management_System.Models
{
    internal class Lecturers
    {
        public int ID { get; set; }
        public string Date {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string NicNo { get; set; }
        public string EmployeeNo { get; set; }
        public string Salary { get; set; }
        public int UserID { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }


    }
}
