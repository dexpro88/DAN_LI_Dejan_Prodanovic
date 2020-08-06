using DAN_LI_Dejan_Prodanovic.Command;
using DAN_LI_Dejan_Prodanovic.Model;
using DAN_LI_Dejan_Prodanovic.Service;
using DAN_LI_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DAN_LI_Dejan_Prodanovic.ViewModel
{
    class ShowPatientsViewModel:ViewModelBase
    {
        ShowPatientsView view;
        IService service;

        public ShowPatientsViewModel(ShowPatientsView showPatientsView)
        {
            view = showPatientsView;
            service = new ServiceClass();

        }
        public ShowPatientsViewModel(ShowPatientsView showPatientsView, tblDoctor logedInDoctor)
        {
            service = new ServiceClass();
            view = showPatientsView;
            PatientList = service.GetPatientsOfDoctor(logedInDoctor.DoctorID);
            ThisDoctor = logedInDoctor;

        }

        private tblDoctor thisDoctor;
        public tblDoctor ThisDoctor
        {
            get
            {
                return thisDoctor;
            }
            set
            {
                thisDoctor = value;
                OnPropertyChanged("ThisDoctor");
            }
        }

        private List<tblPatient> patientList;
        public List<tblPatient> PatientList
        {
            get
            {
                return patientList;
            }
            set
            {
                patientList = value;
                OnPropertyChanged("PatientList");
            }
        }

        private ICommand logout;
        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand(param => LogoutExecute(), param => CanLogoutExecute());
                }
                return logout;
            }
        }

        private void LogoutExecute()
        {
            try
            {
                LoginView loginView = new LoginView();
                loginView.Show();
                view.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanLogoutExecute()
        {
            return true;
        }

        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }

        private void CloseExecute()
        {
            try
            {
               
                view.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanCloseExecute()
        {
            return true;
        }
    }
}
