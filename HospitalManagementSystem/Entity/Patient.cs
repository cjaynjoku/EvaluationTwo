using HospitalManagementSystem.HospitalEnum;

namespace HospitalManagementSystem.Entity
{
    public class Patient : Person
    {
        public Patient()
        {

        }
        public Patient(string name, IEnumerable<MedicalCondition> condition, Hospital hospital, decimal hospitalBudget, Gender gender)
        {
            MedicalConditions = condition;
            Name = name;
            Hospital = hospital;
            HospitalBudget = hospitalBudget;
            Gender = gender;
        }

        public Patient(string name, IEnumerable<MedicalCondition> condition, Hospital hospital, decimal hospitalBudget, Gender gender, bool registered) : this(name, condition, hospital, hospitalBudget, gender)
        {
            Registered = registered;
        }

        public virtual void SeeDoctorCheck(long Id)
        {
            Hospital.Receptionist.PatientAppointment(this);
        }


        public virtual Appointment BookAppointment(Doctor doctor, DateTime appointmentTime)
        {
            Appointment = new Appointment(doctor, this, appointmentTime);
            return Appointment;
        }

        public virtual long PatientId { get; protected set; }
        public virtual Hospital Hospital { get; set; }
        public virtual IEnumerable<MedicalCondition> MedicalConditions { get; set; }
        public virtual Appointment Appointment { get; set; }
        public virtual IEnumerable<Drug> Drugs { get; set; }
        public virtual decimal HospitalBudget { get; set; }
        public virtual bool Registered { get; set; }
        public virtual Bill Bill { get; set; }

    }
}

