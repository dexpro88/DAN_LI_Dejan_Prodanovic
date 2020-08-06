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


                    tblDoctor doctor = (from x in context.tblDoctors
                                    where x.UserName.Equals(username)
                                    && x.Passwd.Equals(password)
                                    select x).First();

                    return doctor;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblPatient AddPatient(tblPatient patient)
        {
            try
            {
                using (MedicalDataEntities context = new MedicalDataEntities())
                {

                    tblPatient newPatient = new tblPatient();
                    newPatient.FullName = patient.FullName;
                    newPatient.JMBG = patient.JMBG;
                    newPatient.InsuranceCardNumber = patient.InsuranceCardNumber;

                    newPatient.UserName = patient.UserName;
                    newPatient.Passwd = patient.Passwd;


                    context.tblPatients.Add(newPatient);
                    context.SaveChanges();

                    return newPatient;


                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblPatient GetPatientByUserNameAndPassword(string username, string password)
        {
            try
            {
                using (MedicalDataEntities context = new MedicalDataEntities())
                {


                    tblPatient patient = (from x in context.tblPatients
                                      where x.UserName.Equals(username)
                                      && x.Passwd.Equals(password)
                                      select x).First();

                    return patient;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<tblDoctor> GetDoctors()
        {
            try
            {
                using (MedicalDataEntities context = new MedicalDataEntities())
                {
                    List<tblDoctor> list = new List<tblDoctor>();
                    list = (from x in context.tblDoctors select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblDoctor GetDoctorById(int doctorId)
        {
            try
            {
                using (MedicalDataEntities context = new MedicalDataEntities())
                {


                    tblDoctor doctor = (from x in context.tblDoctors
                                        where x.DoctorID == doctorId
                                        select x).First();

                    return doctor;
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
