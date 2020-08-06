using DAN_LI_Dejan_Prodanovic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_LI_Dejan_Prodanovic.Service
{
    class ServiceClass:IService
    {
        public tblDoctor AddDoctor(tblDoctor doctor)
        {
            try
            {
                using (MedicalDataEntities context = new MedicalDataEntities())
                {

                    tblDoctor newDoctor = new tblDoctor();
                    newDoctor.FirstName = doctor.FirstName;
                    newDoctor.LastName = doctor.LastName;
                    newDoctor.JMBG = doctor.JMBG;
                    newDoctor.CurrentAccountNumber = doctor.CurrentAccountNumber;
                    newDoctor.UserName = doctor.UserName;
                    newDoctor.Passwd = doctor.Passwd;


                    context.tblDoctors.Add(newDoctor);
                    context.SaveChanges();

                    return newDoctor;


                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblDoctor GetDoctorByUserNameAndPassword(string username, string password)
        {
            try
            {
                using (MedicalDataEntities context = new MedicalDataEntities())
                {


                    tblDoctor user = (from x in context.tblDoctors
                                    where x.UserName.Equals(username)
                                    && x.Passwd.Equals(password)
                                    select x).First();

                    return user;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}
