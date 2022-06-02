namespace HospitalManagementSystem.Entity
{
    public class Hospital : EntityBase
    {
        public Hospital()
        {

        }
        public Hospital(IList<Doctor> doctors, IList<Nurse> nurses, IList<Pharmacist> pharmacists, Accountant accountant, Receptionist receptionist, decimal consultationCharges, decimal roomFee, IList<Drug> drugs)
        {
            Doctors = doctors;
            Nurses = nurses;
            Pharmacists = pharmacists;
            Accountant = accountant;
            Receptionist = receptionist;
            ConsultationCharges = consultationCharges;
            RoomFee = roomFee;
            Drugs = drugs;
        }

        public Hospital(IList<Doctor> doctors, IList<Nurse> nurses, IList<Pharmacist> pharmacists, Accountant accountant, Receptionist receptionist, decimal consultationCharges, decimal roomFee, IList<Drug> drugs, IList<Patient> patients): this(doctors, nurses, pharmacists, accountant, receptionist, consultationCharges, roomFee, drugs)
        {
            Patients = patients;
        }

        public virtual IList<Doctor> Doctors { get; set; }
        public virtual IList<Nurse> Nurses { get; set; }
        public virtual IList<Pharmacist> Pharmacists { get; set; }
        public virtual Receptionist Receptionist { get; set; }
        public virtual Accountant Accountant { get; set; }
        public virtual IList<Patient> Patients { get; set; }

        public virtual IEnumerable<Drug> Drugs { get; set; }

        public virtual decimal ConsultationCharges { get; set; }

        public virtual decimal RoomFee { get; set; }
    }
}
