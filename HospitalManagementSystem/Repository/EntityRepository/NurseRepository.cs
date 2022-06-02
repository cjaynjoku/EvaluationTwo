using HospitalManagementSystem.Entity;
using NHibernate;
using HospitalManagementSystem;
using HospitalManagementSystem.Repository.EntityIRepository;


namespace HospitalManagementSystem.Repository.EntityRepository
{
    public class NurseRepository : GenericRepository<Nurse>, INurseRepository
    {
       

        public NurseRepository(ISession session) : base(session)
        {
            
        }
    }
}
