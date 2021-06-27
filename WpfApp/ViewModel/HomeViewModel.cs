using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.View.Common;

namespace WpfApp.ViewModel
{
    class HomeViewModel : BaseViewModel
    {
        #region Variables

        private JobAdvertisementListViewModel _jobAdvertisementListViewModel = null;

        #endregion

        #region Constructeurs

        public HomeViewModel()
        {
            _jobAdvertisementListViewModel = new JobAdvertisementListViewModel();
        }

        #endregion

        #region Data Bindings

        public JobAdvertisementListViewModel JobAdvertisementListViewModel
        {
            get { return _jobAdvertisementListViewModel; }
            set { _jobAdvertisementListViewModel = value; }
        }

        #endregion
    }
}
