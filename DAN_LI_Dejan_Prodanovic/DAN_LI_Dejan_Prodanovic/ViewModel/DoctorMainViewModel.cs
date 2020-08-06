using DAN_LI_Dejan_Prodanovic.Service;
using DAN_LI_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
