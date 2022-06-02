namespace HospitalManagementSystem.Entity
{
    public class Appointment : EntityBase
    {
        public Appointment()
        {

        }
        public Appointment(Doctor doctor, Patient patient, DateTime appointmentTime)
        {
            Doctor = doctor;
            Patient = patient;
           
            AppointmentTime = appointmentTime;
            patient.Appointment = this;

        }
        public static void AnAppointment(Patient patient, Doctor doctor, DateTime appointmentTime, Pharmacist pharmacist, Accountant accountant)
        {
            var drugs = doctor.ReviewMedicalCondition(patient.MedicalConditions);
            drugs = pharmacist.AdministerDrug(patient, drugs);
            Bill bill = accountant.ManageBill(patient, drugs);
            patient.Bill = bill;

        }

        public virtual long AppointmentId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual DateTime AppointmentTime { get; set; }

    }
}

