using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opakovani_WPF
{
    public class User
    {
        private string username;
        private string email;
        private string role;

        public User(string username, string role)
        {
            Username = username;
            Role = role;
        }

        public User() { }

        public string Username 
        {
            get => username;
            set 
            { 
                username = value; 
                email = $"{value}@company.com";
            }
        }
        public string Email 
        {
            get => email;
        }
        public string Role
        {
            get => role;
            set
            {
                value = value.ToLower();
                if (value == "admin" || value == "editor")
                {
                    role = value;
                }
                else
                {
                    role = "customer";
                }
            }
        }

        public override string ToString()
        {
            return $"{Username};{Email};{Role}";
        }
    }
}
