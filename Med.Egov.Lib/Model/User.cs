using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med.Egov.Lib.Model
{
    public enum Access { admin=1, user=0}
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int Access { get; set; }
        public MedOrg MedOrg { get; set; }
    }
}
