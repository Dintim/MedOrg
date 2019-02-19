using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med.Egov.Lib.Model
{
    public class Patient
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }

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

    }
}
