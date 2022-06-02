using HospitalManagementSystem.Entity;
using NHibernate;
using HospitalManagementSystem.Repository.EntityIRepository;


namespace HospitalManagementSystem.Repository.EntityRepository
{
    public class HospitalRepository: GenericRepository<Hospital>, IHospitalRepository
    {
       

        public HospitalRepository(ISession session) : base(session)
        {
            
        }
    }
}
