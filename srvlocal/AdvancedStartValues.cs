using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace srvlocal
{
    /// <summary>
    /// Start Values
    /// </summary>

    public class AdvancedStartValues
    {
        private long port;
        private string user;
        private string password;
        private string dir;

        /// <summary>
        /// Class Builder
        /// </summary>
        /// <param name="port"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="dir"></param>

        public AdvancedStartValues(long port, string user, string password, string dir)
        {
            Port = port;
            User = user;
            Password = password;
            this.Dir = dir;
        }

        /// <summary>
        ///  Listening Port
        /// </summary>

        public long Port
        {
            get { return port; }
            set { port = value; }
        }

        /// <summary>
        /// Registered User
        /// </summary>

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        /// <summary>
        /// Password used to Autheticate
        /// </summary>

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        /// <summary>
        /// Host Directory
        /// </summary>

        public string Dir 
        {
            get { return dir; } 
            set {  dir = value; } 
        }
    }
}
