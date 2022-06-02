using System.Linq;

namespace HospitalManagementSystem.Entity
{
    public class Doctor : Person
    {
        public Doctor()
        {

        }
        public Doctor(string name, Hospital hospital)
        {
            Name = name;
            Hospital = hospital;

        }

        public virtual IEnumerable<Drug> ReviewMedicalCondition(IEnumerable<MedicalCondition> medicalConditions)
        {
            Random rnd = new Random();
            var drugs = Hospital.Drugs;
            int numberOfDrugs = rnd.Next(2, drugs.Count<Drug>());


            return drugs.OrderBy(x => rnd.Next()).Take(numberOfDrugs);
        }

        public virtual long DoctorId { get; protected set; }
        public virtual IEnumerable<Appointment> Appointments { get; set; }
        public virtual Hospital Hospital { get; set; }

    }
}
