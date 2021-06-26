using Model;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusinessManager
    {
        private readonly Context context;

        private static BusinessManager businessManager = null;

        private BusinessManager()
        {
            context = new Context();
        }

        public static BusinessManager Instance()
        {
            if(businessManager == null)
            {
                businessManager = new BusinessManager();
            }

            return businessManager;
        }

        #region JobAdvertisement
        /*public JobAdvertisement GetAllJobAdvertisements()
        {
            JobAdvertisementQuery jobAdvertisementQuery = new JobAdvertisementQuery(context);
            return offreQuery.GetAll().ToList
        }*/
        #endregion
    }
}
