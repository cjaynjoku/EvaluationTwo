namespace HospitalManagementSystem.Entity
{
    public class MedicalCondition: EntityBase
    {
        public MedicalCondition()
        {

        }
        public MedicalCondition(string name)
        {
            Name = name;
        }
        public MedicalCondition(string name, IList<Patient> patients):this(name)
        {
            Patients = patients;
        }

        public virtual long MedicalConditionId { get; set; }

        public virtual string Name { get; set; }
        public virtual IList<Patient> Patients { get; set; }
    }
}

