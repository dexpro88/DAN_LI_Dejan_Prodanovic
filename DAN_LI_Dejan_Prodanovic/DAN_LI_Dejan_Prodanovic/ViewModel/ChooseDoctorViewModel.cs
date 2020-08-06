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
    class ChooseDoctorViewModel:ViewModelBase
    {
        ChooseDoctorView view;
        IService service;

        public ChooseDoctorViewModel(ChooseDoctorView chooseDoctorView)
        {
            view = chooseDoctorView;
            service = new ServiceClass();

        }
        public ChooseDoctorViewModel(ChooseDoctorView chooseDoctorView, tblPatient logedInPatient)
        {
            service = new ServiceClass();
            view = chooseDoctorView;
            DoctorList = service.GetDoctors();
            ThisPatient = logedInPatient;

            if (DoctorList == null)
            {
                ViewNoDoctorMessage = Visibility.Visible;
            }
            else
            {
                ViewNoDoctorMessage = Visibility.Hidden;
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
        private List<tblDoctor> doctorList;
        public List<tblDoctor> DoctorList
        {
            get
            {
                return doctorList;
            }
            set
            {
                doctorList = value;
                OnPropertyChanged("DoctorList");
            }
        }

        private  tblDoctor selectedDoctor;
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
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }

        private void SaveExecute()
        {
            try
            {

                ThisPatient.DoctorID = SelectedDoctor.DoctorID;
                service.UpdatePatient(ThisPatient);
                string str = string.Format("You choosed {0} {1} for your doctor",SelectedDoctor.FirstName,
                    SelectedDoctor.LastName);
                MessageBox.Show("You choosed ");
                view.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {

            if (SelectedDoctor==null)
            {
                return false;
            }
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
