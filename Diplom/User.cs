using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    [Serializable]
    public class User 
    {
        public List<Users> list = new List<Users>();
    }
    public class Users
    {
        public Users() { }

        string Login;
        string Pass;

        public string _Login
        {
            get { return Login; }
            set { Login = value; }
        }

        public string _Pass
        {
            get { return Pass; }
            set { Pass = value; }
        }

        public Users (string L, string P)
        {
            Login = L;
            Pass = P;
        }

        public override string ToString()
        {
            return Login + " " + Pass;
        }
    }
}
