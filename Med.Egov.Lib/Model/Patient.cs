using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med.Egov.Lib.Model
{
    public class Patient:People
    {
        //public string Name { get; set; }
        //public string Surname { get; set; }
        //public string MiddleName { get; set; }

        private string IIN_;
        public string IIN
        {
            get
            {
                return IIN_;
            }
            set
            {
                if (value.Length != 12)
                    throw new ArgumentException("Введите корректный ИИН!");
                IIN_ = value;
            }
        }
        public MedOrg MedOrg { get; set; } = null;
        public int MedOrgId { get; set; }
        public Patient():base()
        {
        }
        public Patient(string name, string surname, string middleName = "") :base(name, surname, middleName)
        {
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("Приклеплен к: {0}", MedOrg);
        }
        public override double GetDiscount()
        {
            return 0.2;
        }

    }
}
