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
    }
}
