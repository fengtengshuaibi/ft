using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notepad
{
    class User
    {
        String username, password;

        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        public String Username
        {
            get { return username; }
            set { username = value; }
        }
    }
}
