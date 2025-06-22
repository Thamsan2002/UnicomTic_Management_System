using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTic_Management_System.Models
{
    internal class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Gmail { get; set; }
        public string Role { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string UserNameCreateType { get; set; }

    }
}
