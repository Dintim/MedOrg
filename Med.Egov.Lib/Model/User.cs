using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med.Egov.Lib.Model
{
    public enum Access { admin=1, user=0}
    public sealed class User:Patient
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int Access { get; set; }
        //public MedOrg MedOrg { get; set; }
        public override void PrintInfo()
        {
            Console.WriteLine("login: {0}\npassword: {1}\naccess: {2}", Login, Password, ((Access)Access).ToString());
        }
        public override double GetDiscount()
        {
            switch ((Access)Access)
            {
                case Model.Access.admin:
                    return 1.2;
                case Model.Access.user:
                    return 0.2;
                default:
                    return 0;
            }
        }
    }
}
