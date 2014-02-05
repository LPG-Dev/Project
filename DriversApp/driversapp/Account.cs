using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPG_DEV5
{
   public class Account
    {
        public string login, role, password;
        public Account(string login, string password, string role)
        {
            this.login = login;
            this.password = password;
            this.role = role;
        }
        public string getLogin()
        {
            return this.login;
        }
        public string getRole()
        {
            return this.role;
        }
        public string getPassword()
        {
            return this.password;
        }
       
    }
}
