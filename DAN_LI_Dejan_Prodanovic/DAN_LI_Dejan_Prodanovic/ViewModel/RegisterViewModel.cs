using DAN_LI_Dejan_Prodanovic.Command;
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
    class RegisterViewModel:ViewModelBase
    {
        RegisterView view;




        public RegisterViewModel(RegisterView registerView)
        {
            view = registerView;


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

        private ICommand registerAsPatient;
        public ICommand RegisterAsPatient
        {
            get
            {
                if (registerAsPatient == null)
                {
                    registerAsPatient = new RelayCommand(param => RegisterAsPatientExecute(),
                        param => CanRegisterAsPatientExecute());
                }
                return registerAsPatient;
            }
        }

        private void RegisterAsPatientExecute()
        {
            try
            {
                PatientRegisterView patientRegisterView = new PatientRegisterView();
                patientRegisterView.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanRegisterAsPatientExecute()
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
