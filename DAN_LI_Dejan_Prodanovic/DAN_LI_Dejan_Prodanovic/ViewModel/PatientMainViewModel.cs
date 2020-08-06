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
    class PatientMainViewModel:ViewModelBase
    {
        PatientMainView  view;
        IService service;

        public PatientMainViewModel(PatientMainView patientMainView)
        {
            view = patientMainView;
            service = new ServiceClass();

        }
        public PatientMainViewModel(PatientMainView patientMainView,tblPatient logedInPatient)
        {
            service = new ServiceClass();
            view = patientMainView;
            if (logedInPatient.DoctorID!=null)
            {
                SelectedDoctor = service.GetDoctorById((int)logedInPatient.DoctorID);
                ViewNoDoctorMessage = Visibility.Hidden;
                ViewDoctorName = Visibility.Visible;
            }
            else
            {
                ViewNoDoctorMessage = Visibility.Visible;
                ViewDoctorName = Visibility.Hidden;
            }

        }


        private Visibility viewNoDoctorMessage;
        public Visibility ViewNoDoctorMessage
        {
            get
            {
                return viewNoDoctorMessage;
            }
            set
            {
                viewNoDoctorMessage = value;
                OnPropertyChanged("ViewNoDoctorMessage");
            }
        }

        private Visibility viewDoctorName;
        public Visibility ViewDoctorName
        {
            get
            {
                return viewDoctorName;
            }
            set
            {
                viewDoctorName = value;
                OnPropertyChanged("ViewDoctorName");
            }
        }

        private tblPatient thisPatient;
        public tblPatient ThisPatient
        {
            get
            {
                return thisPatient;
            }
            set
            {
                thisPatient = value;
                OnPropertyChanged("ThisPatient");
            }
        }

        private tblDoctor selectedDoctor;
        public tblDoctor SelectedDoctor
        {
            get
            {
                return selectedDoctor;
            }
            set
            {
                selectedDoctor = value;
                OnPropertyChanged("SelectedDoctor");
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


        private ICommand registerAsDoctor;
        public ICommand RegisterAsDoctor
        {
            get
            {
                if (registerAsDoctor == null)
                {
                    registerAsDoctor = new RelayCommand(param => RegisterAsDoctorExecute(),
                        param => CanRegisterAsDoctorExecute());
                }
                return registerAsDoctor;
            }
        }

        private void RegisterAsDoctorExecute()
        {
            try
            {
                DoctorRegisterView doctorRegisterView = new DoctorRegisterView();
                doctorRegisterView.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanRegisterAsDoctorExecute()
        {
            return true;
        }

        private ICommand chooseDoctor;
        public ICommand ChooseDoctor
        {
            get
            {
                if (chooseDoctor == null)
                {
                    chooseDoctor = new RelayCommand(param => ChooseDoctorExecute(),
                        param => CanChooseDoctorExecute());
                }
                return chooseDoctor;
            }
        }

        private void ChooseDoctorExecute()
        {
            try
            {
                ChooseDoctorView chooseDoctorView = new ChooseDoctorView();
                chooseDoctorView.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanChooseDoctorExecute()
        {
            return true;
        }

        private ICommand back;
        public ICommand Back
        {
            get
            {
                if (back == null)
                {
                    back = new RelayCommand(param => BackExecute(), param => CanBackExecute());
                }
                return back;
            }
        }

        private void BackExecute()
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
        private bool CanBackExecute()
        {
            return true;
        }
    }
}
