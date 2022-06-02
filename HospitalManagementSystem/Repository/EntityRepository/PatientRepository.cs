using HospitalManagementSystem.Entity;
using NHibernate;
using HospitalManagementSystem.Repository.EntityIRepository;


namespace HospitalManagementSystem.Repository.EntityRepository
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {


        public PatientRepository(ISession session) : base(session)
        {
        }
    }

}
