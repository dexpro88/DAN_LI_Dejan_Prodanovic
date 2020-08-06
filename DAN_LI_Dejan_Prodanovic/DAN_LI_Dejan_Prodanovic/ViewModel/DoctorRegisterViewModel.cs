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
    class DoctorRegisterViewModel:ViewModelBase
    {
        DoctorRegisterView view;
        IService service;

        public DoctorRegisterViewModel(DoctorRegisterView doctorRegisterView)
        {
            view = doctorRegisterView;
            service = new ServiceClass();
            Doctor = new tblDoctor();


        }

        private tblDoctor doctor;
        public tblDoctor Doctor
        {
            get
            {
                return doctor;
            }
            set
            {
                doctor = value;
                OnPropertyChanged("Doctor");
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

                if (!ValidationClass.JMBGisValid(Doctor.JMBG, out dateOfBirth))
                {
                    MessageBox.Show("JMBG is not valid");
                    return;
                }

                int age = ValidationClass.CountAge(dateOfBirth);
                if (age < 25)
                {
                    MessageBox.Show("JMBG is not valid\nDoctor has to be at least 25 years old");
                    return;
                }
                if (!ValidationClass.IsAccountNumberValid(Doctor.CurrentAccountNumber))
                {
                    MessageBox.Show("AccountNumber is not valid");
                    return;
                }

                if (service.GetDoctorByUserName(Doctor.UserName) != null)
                {
                    string str1 = string.Format("User with this username exists\nChoose another username");
                    MessageBox.Show(str1);
                    return;
                }


                if (service.GetPatientByUserName(Doctor.UserName) != null)
                {
                    string str1 = string.Format("User with this username exists\nChoose another username");
                    MessageBox.Show(str1);
                    return;
                }

                if (service.GetDoctorByCurrentAccountNumber(Doctor.CurrentAccountNumber) != null)
                {
                    string str1 = string.Format("User with this  CurrentAccountNumber exists\n" +
                        "Choose another CurrentAccountNumber");
                    MessageBox.Show(str1);
                    return;
                }
                var passwordBox = parameter as PasswordBox;
                var password = passwordBox.Password;

                string encryptedString = EncryptionHelper.Encrypt(password);


                Doctor.Passwd = encryptedString;
                service.AddDoctor(Doctor);

          
                string str = string.Format("You succesfuly registered as doctor");
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

            if (String.IsNullOrEmpty(Doctor.FirstName) || String.IsNullOrEmpty(Doctor.LastName)
                || String.IsNullOrEmpty(Doctor.JMBG) || String.IsNullOrEmpty(Doctor.CurrentAccountNumber)
                || String.IsNullOrEmpty(Doctor.UserName) || parameter as PasswordBox == null
                || String.IsNullOrEmpty((parameter as PasswordBox).Password
                ))
            {
                return false;
            }
            else
            {
                return true;
            }
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
