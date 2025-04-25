using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporteredmenyek.Core.Models
{
    class User
    {
        public string name;
        private string _email { get; set; }
        private string _password { get; set; }

        public User(string name, string email, string password){
            this.name = name;
            this._email = email;
            this._password = password;
        }

        
    }


}
