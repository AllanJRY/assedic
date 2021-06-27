using BusinessLayer;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.View.Common;

namespace WpfApp.ViewModel
{
    class JobAdvertisementListViewModel : BaseViewModel
    {
        #region Variables

        private ObservableCollection<JobAdvertisementDetailsViewModel> _jobAdvertisements = null;
        private JobAdvertisementDetailsViewModel _selectedJobAdvertisements;
        private ObservableCollection<Status> _appStatus = null;
        private Status _activeStatusFilter;

        #endregion

        #region Constructeurs

        public JobAdvertisementListViewModel()
        {

            _jobAdvertisements = new ObservableCollection<JobAdvertisementDetailsViewModel>();
            foreach (JobAdvertisement jobAdvertisement in BusinessManager.Instance().GetAllJobAdvertisements().OrderByDescending(j => j.Date))
            {
                _jobAdvertisements.Add(new JobAdvertisementDetailsViewModel(jobAdvertisement));
            }

            _appStatus = new ObservableCollection<Status>(BusinessManager.Instance().GetAllStatus());
            _appStatus.Insert(0, new Model.Entity.Status() { Label = "All" });

            if (_jobAdvertisements != null && _jobAdvertisements.Count > 0) _selectedJobAdvertisements = _jobAdvertisements.ElementAt(0);
        }

        #endregion

        #region Data Bindings

        public ObservableCollection<JobAdvertisementDetailsViewModel> JobAdvertisements
        {
            get { return _jobAdvertisements; }
            set
            {
                _jobAdvertisements = value;
                OnPropertyChanged("JobAdvertisements");
            }
        }

        public JobAdvertisementDetailsViewModel SelectedJobAdvertisement
        {
            get { return _selectedJobAdvertisements; }
            set
            {
                _selectedJobAdvertisements = value;
                OnPropertyChanged("SelectedJobAdvertisement");
            }
        }

        public ObservableCollection<Status> Status
        {
            get { return _appStatus; }
        }

        public Status ActiveStatusFilter
        {
            get { return _activeStatusFilter; }
            set
            {
                _activeStatusFilter = value;
                OnPropertyChanged("ActiveStatusFilter");
                if (_activeStatusFilter != null && _activeStatusFilter.Label != "All")
                {
                    _jobAdvertisements = new ObservableCollection<JobAdvertisementDetailsViewModel>();
                    foreach (JobAdvertisement jobAdvertisement in BusinessManager.Instance().GetAllJobAdvertisementsOfStatus(_activeStatusFilter).OrderByDescending(j => j.Date))
                    {
                        _jobAdvertisements.Add(new JobAdvertisementDetailsViewModel(jobAdvertisement));
                    }
                }
                else
                {
                    _jobAdvertisements = new ObservableCollection<JobAdvertisementDetailsViewModel>();
                    foreach (JobAdvertisement jobAdvertisement in BusinessManager.Instance().GetAllJobAdvertisements().OrderByDescending(j => j.Date))
                    {
                        _jobAdvertisements.Add(new JobAdvertisementDetailsViewModel(jobAdvertisement));
                    }
                }

                OnPropertyChanged("JobAdvertisements");
            }
        }

        #endregion
    }
}
