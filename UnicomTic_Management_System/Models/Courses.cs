using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTic_Management_System.Models
{
    internal class Courses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }
}
