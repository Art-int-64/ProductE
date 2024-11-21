using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp4
{
    class Profile
    {
        public string logon { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string e_mail { get; set; }
        public string image { get; set; }

        public Profile(string logon, string password, string phone, string e_mail,string image)
        {
            this.logon = logon;
            this.password = password;
            this.phone = phone;
            this.e_mail= e_mail;
            this.image = image;
        }       
    }
}
