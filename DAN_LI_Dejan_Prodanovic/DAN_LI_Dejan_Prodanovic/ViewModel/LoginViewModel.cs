using DAN_LI_Dejan_Prodanovic.Command;
using DAN_LI_Dejan_Prodanovic.Model;
using DAN_LI_Dejan_Prodanovic.Service;
using DAN_LI_Dejan_Prodanovic.Utility;
using DAN_LI_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DAN_LI_Dejan_Prodanovic.ViewModel
{
    class LoginViewModel:ViewModelBase
    {
        LoginView view;
        IService service;

        public LoginViewModel(LoginView loginView)
        {
            view = loginView;
            service = new ServiceClass();
        }

        private string userName;
        public string UserName
        {

            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string someProperty]
        {
            get
            {

                return string.Empty;
            }
        }



        private ICommand submitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                if (submitCommand == null)
                {
                    submitCommand = new RelayCommand(Submit);
                    return submitCommand;
                }
                return submitCommand;
            }
        }

        void Submit(object obj)
        {

            string password = (obj as PasswordBox).Password;



            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Wrong user name or password");
                return;
            }


            string encryptedString = EncryptionHelper.Encrypt(password);

            tblDoctor doctor = service.GetDoctorByUserNameAndPassword(UserName, encryptedString);
            if (doctor != null)
            {
                
                    DoctorMainView doctorMainView = new DoctorMainView(doctor);
                    doctorMainView.Show();
                    view.Close();
                return;
            }
            tblPatient patient = service.GetPatientByUserNameAndPassword(UserName, encryptedString);
            if (patient != null)
            {

                PatientMainView patientMainView = new PatientMainView(patient);
                patientMainView.Show();
                view.Close();
                return;
            }

            
              MessageBox.Show("Wrong username or password");

            


        }

        private ICommand register;
        public ICommand Register
        {
            get
            {
                if (register == null)
                {
                    register = new RelayCommand(param => RegisterExecute(), param => CanRegisterExecute());
                }
                return register;
            }
        }

        private void RegisterExecute()
        {
            try
            {
                RegisterView register = new RegisterView();
                register.Show();
                view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanRegisterExecute()
        {

            return true;
        }

        
    }
}
