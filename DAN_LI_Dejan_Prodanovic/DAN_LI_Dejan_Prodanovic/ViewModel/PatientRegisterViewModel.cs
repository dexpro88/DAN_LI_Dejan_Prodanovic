using DAN_LI_Dejan_Prodanovic.Command;
using DAN_LI_Dejan_Prodanovic.Model;
using DAN_LI_Dejan_Prodanovic.Service;
using DAN_LI_Dejan_Prodanovic.Utility;
using DAN_LI_Dejan_Prodanovic.Validation;
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
    class PatientRegisterViewModel:ViewModelBase
    {
        PatientRegisterView view;
        IService service;

        public PatientRegisterViewModel(PatientRegisterView patientRegisterView)
        {
            view = patientRegisterView;
            service = new ServiceClass();
            Patient = new tblPatient();

        }

        private tblPatient patient;
        public tblPatient Patient
        {
            get
            {
                return patient;
            }
            set
            {
                patient = value;
                OnPropertyChanged("Patient");
            }
        }



        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(SaveExecute, CanSaveExecute);
                }
                return save;
            }
        }

        private void SaveExecute(object parameter)
        {
            try
            {
                DateTime dateOfBirth;

                if (!ValidationClass.JMBGisValid(Patient.JMBG, out dateOfBirth))
                {
                    MessageBox.Show("JMBG is not valid");
                    return;
                }

                
                if (!ValidationClass.IsInsuranceCardNumberValid(Patient.InsuranceCardNumber))
                {
                    MessageBox.Show("InsuranceCardNumber is not valid");
                    return;
                }
                var passwordBox = parameter as PasswordBox;
                var password = passwordBox.Password;

                string encryptedString = EncryptionHelper.Encrypt(password);


                Patient.Passwd = encryptedString;
                service.AddPatient(Patient);


                string str = string.Format("You succesfuly registered as patient");
                MessageBox.Show(str);
                view.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute(object parameter)
        {

            //if (String.IsNullOrEmpty(User.FirstName) || String.IsNullOrEmpty(User.LastName)
            //    || String.IsNullOrEmpty(User.JMBG) || String.IsNullOrEmpty(User.Residence)
            //    || String.IsNullOrEmpty(User.Username) || parameter as PasswordBox == null
            //    || SelectedSector == null)
            //{
            //    return false;
            //}
            //else
            //{
            return true;
            //}
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
