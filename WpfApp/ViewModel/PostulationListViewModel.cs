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
    class PostulationListViewModel : BaseViewModel
    {
        #region Variables

        private ObservableCollection<PostulationDetailsViewModel> _postulations = null;
        private PostulationDetailsViewModel _selectedPostulation;

        #endregion

        #region Constructeurs

        public PostulationListViewModel(List<Employee> postulants)
        {
            _postulations = new ObservableCollection<PostulationDetailsViewModel>();
            foreach (Employee postulant in postulants)
            {
                _postulations.Add(new PostulationDetailsViewModel(postulant));
            }

            if (_postulations != null && _postulations.Count > 0)
                _selectedPostulation = _postulations.ElementAt(0);
        }

        #endregion

        #region Data Bindings

        public ObservableCollection<PostulationDetailsViewModel> Postulations
        {
            get { return _postulations; }
            set
            {
                _postulations = value;
                OnPropertyChanged("Postulations");
            }
        }

        public PostulationDetailsViewModel SelectedPostulation
        {
            get { return _selectedPostulation; }
            set
            {
                _selectedPostulation = value;
                OnPropertyChanged("SelectedPostulation");
            }
        }


        #endregion
    }
}
