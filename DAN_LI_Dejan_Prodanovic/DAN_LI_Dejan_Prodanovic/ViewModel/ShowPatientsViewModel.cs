using DAN_LI_Dejan_Prodanovic.Model;
using DAN_LI_Dejan_Prodanovic.Service;
using DAN_LI_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
