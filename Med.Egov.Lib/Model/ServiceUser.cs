using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med.Egov.Lib.Model
{
    public class ServiceUser
    {
        public static bool UpdatePatientMedOrg(int medOrgId, int patientId)
        {
            using (LiteDatabase db = new LiteDatabase("med.db"))
            {
                var users = db.GetCollection<Patient>("Patient");
                var user = users.FindById(patientId);
                user.MedOrgId = medOrgId;
                user.Id = patientId;
                users.Update(user);                
            }
            return true;
        }
        public static List<Patient> GetPatients()
        {
            using (LiteDatabase db = new LiteDatabase("med.db"))
            {
                var p = db.GetCollection<Patient>("Patients");
                return p.FindAll().ToList();
            }
        }
        public static void AddPatient(Patient m)
        {
            using (LiteDatabase db = new LiteDatabase("med.db"))
            {
                var p = db.GetCollection<Patient>("Patients");
                p.Insert(m);
            }
        }
    }
}
