using HospitalManagementSystem.Repository.EntityRepository;
using NHibernate;

namespace HospitalManagementSystem.Entity
{
    public class Accountant : Person
    {
        public Accountant()
        {

        }
        public Accountant(string name, Hospital hospital)
        {
            Name = name;
            Hospital = hospital;
            
        }

        
        public virtual Bill ManageBill(Patient patient, IEnumerable<Drug> drugs)
        {
            decimal totalCost = 0;
            foreach(var drug in drugs)
            {
                totalCost += drug.DrugPrice;
            }
            totalCost += Hospital.ConsultationCharges + Hospital.RoomFee;
            decimal remainder = patient.HospitalBudget - totalCost;
            var bill = new Bill(patient, drugs, totalCost, patient.HospitalBudget, remainder);

            return bill;
        }

        public virtual Hospital Hospital { get; set; }
        public virtual long AccountantId { get; set; }
       
    }
}
