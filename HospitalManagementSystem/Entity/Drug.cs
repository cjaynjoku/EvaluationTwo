namespace HospitalManagementSystem.Entity
{
    
    public class Drug : EntityBase
    {
        public Drug()
        {
            
        }
        public Drug(string drugName, decimal drugPrice)
        {
            DrugName = drugName;
            DrugPrice = drugPrice;
        }

        public virtual long DrugId { get; protected set; }
        public virtual string DrugName { get; set; }
        public virtual decimal DrugPrice { get; set; }
        public virtual IList<Patient> Patients { get; set; }
        public virtual IEnumerable<Bill> Bill { get; set; }
        public virtual IEnumerable<Hospital> Hospitals { get; protected set; }
    }
}

