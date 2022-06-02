namespace HospitalManagementSystem.Entity
{
    public class Pharmacist:Person
    {
        public Pharmacist()
        {

        }
        public Pharmacist(string name, Hospital hospital)
        {
            Hospital = hospital;
            Name = name;
        }

        public virtual IEnumerable<Drug> AdministerDrug(Patient patient, IEnumerable<Drug> drugs)
        {
            patient.Drugs = drugs;
            return drugs;
        }

        public virtual Hospital Hospital { get; set; }
        public  virtual long PharmacistId { get; protected set; }
    }
}
