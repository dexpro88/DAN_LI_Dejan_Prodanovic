using DAN_LI_Dejan_Prodanovic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_LI_Dejan_Prodanovic.Service
{
    interface IService
    {
        tblDoctor AddDoctor(tblDoctor doctor);
        tblDoctor GetDoctorByUserNameAndPassword(string username, string password);

    }
}
