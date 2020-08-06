using DAN_LI_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_LI_Dejan_Prodanovic.ViewModel
{
    class SickLeaveViewModel:ViewModelBase
    {
        SickLeaveView view;
        public SickLeaveViewModel(SickLeaveView sickLeaveView)
        {
            view = sickLeaveView;
            

        }
    }
}
