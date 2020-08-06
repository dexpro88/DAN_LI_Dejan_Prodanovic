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
    class DoctorMainViewModel:ViewModelBase
    {
        View.DoctorMainView view;
        IService service;

        public DoctorMainViewModel(DoctorMainView doctorMainView)
        {
            view = doctorMainView;
            service = new ServiceClass();
           
        }

        public DoctorMainViewModel(DoctorMainView doctorMainView, tblDoctor logedInDoctor)
        {
            service = new ServiceClass();
            view = doctorMainView;
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

        private ICommand showPatients;
        public ICommand ShowPatients
        {
            get
            {
                if (showPatients == null)
                {
                    showPatients = new RelayCommand(param => ShowPatientsExecute(),
                        param => CanShowPatientsExecute());
                }
                return showPatients;
            }
        }

        private void ShowPatientsExecute()
        {
            try
            {
                ShowPatientsView chooseDoctorView = new ShowPatientsView(ThisDoctor);
                chooseDoctorView.ShowDialog();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanShowPatientsExecute()
        {
            return true;
        }

    }
}
