using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srvlocal_gui.AppMananger
{
    public class EmailVerificationResult
    {
        public string Email { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public string Role { get; set; }
        public string Disposable { get; set; }
        public string Free { get; set; }
        public string AcceptAll { get; set; }
        public string VerifiedAt { get; set; }
        public string Source { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Location { get; set; }
    }
}
