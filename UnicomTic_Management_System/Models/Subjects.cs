using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTic_Management_System.Models
{
    internal class Subjects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int LecturerID { get; set; }
        public string LecturerName { get;set;}
    }
}
