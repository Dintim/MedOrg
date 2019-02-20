using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med.Egov.Lib.Model
{
    public class ServiceMedOrg
    {
        public static bool RemovePatientFromMedOrg(int patientId, int medOrgId)
        {
            using (LiteDatabase db = new LiteDatabase("med.db")) 
            {
                var pam = db.GetCollection<PatientAddedMed>("PatientAddedMed");
                int t = pam.Delete(f => f.MedOrgId == medOrgId && f.PatientId == patientId);
                if (t > 0)
                    return true;
                else
                    return false;
            }
        }
        public static bool AddPatientToMedOrg(int patientId, int medOrgId)
        {
            using (LiteDatabase db = new LiteDatabase("med.db"))
            {
                var pam = db.GetCollection<PatientAddedMed>("PatientAddedMed");
                PatientAddedMed p = new PatientAddedMed();
                p.MedOrgId = medOrgId;
                p.PatientId = patientId;
                pam.Insert(p);
                return true;
            }
        }

        public static List<MedOrg> GetMedOrg()
        {
            using (LiteDatabase db = new LiteDatabase("med.db"))
            {
                var medOrg = db.GetCollection<MedOrg>("MedOrg");
                return medOrg.FindAll().ToList();                
            }
        }
        public static void AddMedOrg(MedOrg m)
        {
            using (LiteDatabase db = new LiteDatabase("med.db"))
            {
                var medOrg = db.GetCollection<MedOrg>("MedOrg");    
                medOrg.Insert(m);
            }
        }

    }
}
