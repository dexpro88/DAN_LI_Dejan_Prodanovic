using DAN_LI_Dejan_Prodanovic.Command;
using DAN_LI_Dejan_Prodanovic.Model;
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
    class DoctorRegisterViewModel:ViewModelBase
    {
        DoctorRegisterView view;
        


        public DoctorRegisterViewModel(DoctorRegisterView doctorRegisterView)
        {
            view = doctorRegisterView;


          
        }







        private string selectedSector;
        public string SelectedSector
        {
            get
            {
                return selectedSector;
            }
            set
            {
                selectedSector = value;
                OnPropertyChanged("SelectedSector");
            }
        }





        private tblDoctor user;
        public tblDoctor User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        private string gender = "male";
        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
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
