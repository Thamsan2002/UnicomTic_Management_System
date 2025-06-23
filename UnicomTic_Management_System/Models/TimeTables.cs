using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTic_Management_System.Models
{
    internal class TimeTables
    {
        public int ID { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get;set; }
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public string HallName { get; set; }
        public int HallID { get; set; }

    }
}
