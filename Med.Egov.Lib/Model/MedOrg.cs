using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med.Egov.Lib.Model
{
    public class MedOrg
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Patient> Patients = null;
        public MedOrg():this("", "")
        {            
        }
        public MedOrg(string name, string address)
        {
            this.Name = name;
            this.Address = address;
            Patients = new List<Patient>();
        }
    }
}
