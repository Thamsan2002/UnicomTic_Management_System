 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTic_Management_System.Models;

namespace UnicomTic_Management_System.ParentClasses
{
    internal class Validations
    {

        protected string PhoneValidation(string phone)
        {
             if (phone.Length != 10 || !phone.All(Char.IsDigit))
            {
                MessageBox.Show("Invalid MobileNo!");
                return "Invalid";
            }
            else { return phone; }
        }
        protected string EmailValidation(string email) 
        {
            if (!email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase) || email.Length <= "@gmail.com".Length)
            {
                MessageBox.Show("Invalid Gmail Format!");
                return "Invalid";
            }
            else {return email; }
        }
    }
}
