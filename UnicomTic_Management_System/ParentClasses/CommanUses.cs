using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTic_Management_System.Database_Uses;

namespace UnicomTic_Management_System
{
    internal class CommanUses
    {
        public int GeneratePassCode() 
        {
            Random random = new Random();
            int Passcode = random.Next(100000, 1000000);
            return Passcode;
        }

        protected int GetLastInsertedId() 
        {
            int lastId = 0;
            using (SQLiteConnection connect = DatabaseManager.GetConnection())
            {
                using (SQLiteCommand cmd = connect.CreateCommand()) 
                {
                    cmd.CommandText = "SELECT Id FROM Users ORDER BY Id DESC LIMIT 1;;";
                    lastId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return lastId;
        }
        protected string PhoneValidation(string phone)
        {
            if (phone.Length != 10 || !phone.All(Char.IsDigit))
            {
                MessageBox.Show("Invalid MobileNo!");
                return "Invalid";
            }
            else { return phone; }
        }
        protected string GmailValidation(string email)
        {
            if (!email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase) 
                || email.Length <= "@gmail.com".Length)
            {
                MessageBox.Show("Invalid Gmail Format!");
                return "Invalid";
            }
            else { return email; }
        }
        protected string NicValidation(string nic) 
        {
            if (nic.Length ==12 && nic.All(Char.IsDigit)) { return nic; }
            else if (nic.Length == 10 && nic.Substring(0, 9).All(Char.IsDigit) && nic.EndsWith("V")) { return nic; }
            else {MessageBox.Show("Invalid NicNo!"); return "Invalid"; }
        }
        protected string CurrencyValidation(string currency)
        {
            try 
            { 
                double newcurrency = Convert.ToDouble(currency);
                return currency;
            }
            catch(Exception ex) { return "Invalid"; }
        }
    }
}
