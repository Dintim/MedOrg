using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med.Egov.Lib.Model
{
    public abstract class People
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public DateTime dob { get; set; }
        public int Age
        {
            get
            {
                return DateTime.Now.Year - dob.Year;
            }
        }

        public People() { }
        public People(string name, string surname, string middleName = "")
        {
            this.Name = name;
            this.Surname = surname;
        }
        
        public virtual void PrintInfo()
        {
            Console.WriteLine("{0} {1} {2}", Name, Surname, MiddleName);
        }
        public abstract double GetDiscount();
    }
}
