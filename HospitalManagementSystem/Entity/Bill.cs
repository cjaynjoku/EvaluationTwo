namespace HospitalManagementSystem.Entity
{
    public class Bill : EntityBase
    {
        public Bill()
        {

        }

        public Bill(Patient patient, IEnumerable<Drug> drugs, decimal totalCost, decimal billPaid, decimal remainder)
        {
            Patient = patient;
            Drugs = drugs;
            TotalCost = totalCost;
            Remainder = remainder;
            BillPaid = billPaid;
        }


        public virtual long BillId { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual decimal TotalCost { get; protected set; }
        public virtual decimal BillPaid { get; set; }
        public virtual decimal Remainder { get; set; }
        public virtual IEnumerable<Drug> Drugs { get; set; }

    }
}

