using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTic_Management_System.Models
{
    internal class CourseSubject
    {
        public int Id { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
    }
}
