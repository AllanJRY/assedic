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
    class PostulationDetailsViewModel : BaseViewModel
    {
        #region Variables

        private int _id;
        private string _lastname;
        private string _firstname;

        #endregion

        #region Constructeurs

        public PostulationDetailsViewModel(Employee employee)
        {
            _id = employee.Id;
            _lastname = employee.Lastname;
            _firstname = employee.Firstname;
        }

        #endregion

        #region Data Bindings

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        public string Fullname
        {
            get { return $"{_firstname} {_lastname}"; }
        }

        #endregion

    }
}
