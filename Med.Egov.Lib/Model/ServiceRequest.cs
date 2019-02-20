using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Med.Egov.Lib.Model
{
    public class ServiceRequest
    {
        private LiteEntity db = new LiteEntity();
        Logger logger = LogManager.GetCurrentClassLogger();
        public bool CreateRequest(Request r)
        {
            try
            {
                db.CreateRequest(r);
                return true;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return false;
                
            }
        }
        public List<Request> getUserRequest(int userId)
        {
            return db.GetRequestsByPatientId(userId);
        }
        public List<Request> getOrgRequest(int orgId)
        {
            return db.GetRequestsByMedOrgId(orgId);
        }
        public void changeRequestStatus(Request r)
        {
            switch (r.RequestStatus)
            {                
                case RequestStatus.approve:
                    {
                        //получить организацию юзера
                        if (r.Patient.MedOrg!=null)
                        {
                            int medOrgId = r.MedOrg.Id;
                            int patientId = r.PatientId;
                            //удалить из организации этого юзера
                            ServiceMedOrg.RemovePatientFromMedOrg(medOrgId, patientId);
                        }
                        //проставить юзеру новую организацию
                        ServiceUser.UpdatePatientMedOrg(r.MedOrgId, r.PatientId);

                        // добавить в новой организации юзера
                        ServiceMedOrg.AddPatientToMedOrg(r.PatientId, r.MedOrgId);
                    }
                    break;
                case RequestStatus.reject:
                    db.UpdateRequest(r);
                    break;             
            }            
        }
    }
}
