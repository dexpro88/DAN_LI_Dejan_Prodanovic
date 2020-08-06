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
        tblPatient AddPatient(tblPatient doctor);
        tblPatient GetPatientByUserNameAndPassword(string username, string password);
        List<tblDoctor> GetDoctors();
        tblDoctor GetDoctorById(int doctorId);
        tblDoctor GetDoctorByUserName(string username);
        tblPatient GetPatientByUserName(string username);
        tblDoctor GetDoctorByCurrentAccountNumber(string number);
        tblPatient GetPatientByInsuranceCardNumber(string number);
    }
}
