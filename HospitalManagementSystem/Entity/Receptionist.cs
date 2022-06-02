using HospitalManagementSystem.Repository.EntityRepository;
using NHibernate;

namespace HospitalManagementSystem.Entity
{
    public class Receptionist : Person
    {
        public Receptionist()
        {

        }
        public Receptionist(string name, Hospital hospital)
        {
            Name = name;
            Hospital = hospital;
        }

        public virtual void RegisteredAppointment(Patient patient)
        {
            Random rand = new Random();
            int index = rand.Next(0, Hospital.Doctors.Count);
            var doctor = Hospital.Doctors[index];

            if (patient.Appointment != null)
            {
                var pharmacist = Hospital.Pharmacists[index];

                Appointment.AnAppointment(patient, doctor, patient.Appointment.AppointmentTime, pharmacist, Hospital.Accountant);

            }
            else
            {
                patient.Appointment = patient.BookAppointment(doctor, AppointmentTime);
            }

        }
        public virtual void UnRegisteredAppointment(Patient patient)
        {

            Random rand = new Random();
            int index = rand.Next(0, Hospital.Doctors.Count);
            var doctor = Hospital.Doctors[index];

            patient.Appointment = patient.BookAppointment(doctor, AppointmentTime);

        }

        public virtual void PatientAppointment(Patient patient)
        {
            if (checkPatientStatus(patient.Id))
            {
                RegisteredAppointment(patient);
            }
            else
            {
                // registers the patient

                patient.Registered = true;
                UnRegisteredAppointment(patient);
            }

        }

        public virtual bool checkPatientStatus(long patientId)
        {

            ISession session = NhibernateHelper.OpenSession();
            var repo = new PatientRepository(session);

           
            var patient = repo.GetById(patientId);
            

            if (patient.Registered == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private static Random gen = new Random();
        private static DateTime RandomDay()
        {
            DateTime start = new DateTime(2022, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }


        public virtual long ReceptionistId { get; protected set; }
        public virtual DateTime AppointmentTime { get; set; } = RandomDay();
        public virtual Hospital Hospital { get; set; }
    }
}
