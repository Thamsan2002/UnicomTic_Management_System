using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTic_Management_System.Models
{
    internal class Marks
    {
        public int ID { get; set; }
        public int ExamID { get; set; }
        public string ExamName { get; set; }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string Score { get; set; }

    }
}
