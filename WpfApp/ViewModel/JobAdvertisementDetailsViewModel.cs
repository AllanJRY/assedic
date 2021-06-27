using BusinessLayer;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.View.Common;

namespace WpfApp.ViewModel
{
    class JobAdvertisementDetailsViewModel : BaseViewModel
    {
        #region Variables

        private int _id;
        private string _title;
        private string _description;
        private float _salary;
        private DateTime _date;
        private string _status;
        private string _manager;
        private RelayCommand _save;
        private PostulationListViewModel _postulationListViewModel = null;

        #endregion

        #region Constructeurs

        public JobAdvertisementDetailsViewModel(JobAdvertisement jobAdvertisement)
        {
            _id = jobAdvertisement.Id;
            _title = jobAdvertisement.Title;
            _description = jobAdvertisement.Description;
            _salary = jobAdvertisement.Salary;
            _date = jobAdvertisement.Date;
            _status = jobAdvertisement.Status.Label;
            _manager = jobAdvertisement.Manager;
            _postulationListViewModel = new PostulationListViewModel(BusinessManager.Instance().GetAllEmployeesPostulantOfAdvertisement(jobAdvertisement.Id));
        }

        #endregion

        #region Data Bindings

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description= value; }
        }

        public float Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        public string Manager
        {
            get { return _manager; }
            set { _manager = value; }
        }


        public PostulationListViewModel PostulationListViewModel
        {
            get { return _postulationListViewModel; }
            set { _postulationListViewModel = value; }
        }

        #endregion

        #region Commandes

        public ICommand Save
        {
            get
            {
                if (_save == null)
                    _save = new RelayCommand(() => this.SaveUpdates());
                return _save;
            }
        }

        private void SaveUpdates()
        {
            JobAdvertisement newJobAdvertisementData = new JobAdvertisement()
            {
                Id = _id,
                Title = _title,
                Description = _description,
                Salary = _salary,
                Date = _date,
                Manager = _manager
            };
            BusinessManager.Instance().UpdateJobAdvertisement(newJobAdvertisementData);
        }

        #endregion
    }
}
