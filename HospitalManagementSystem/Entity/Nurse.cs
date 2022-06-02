namespace HospitalManagementSystem.Entity
{
    public class Nurse : Person
    {
        public Nurse()
        {

        }
        public Nurse(string name, Hospital hospital)
        {
            Name = name;
            Hospital = hospital;
        }
        public virtual long NurseId { get; protected set; }
        public virtual Hospital Hospital { get; set; }

    }
}
