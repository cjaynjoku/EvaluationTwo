using HospitalManagementSystem.Entity;
using HospitalManagementSystem.Repository.EntityIRepository;
using NHibernate;

namespace HospitalManagementSystem.Repository.EntityRepository
{
    public class BillRepository : GenericRepository<Bill>, IBillRepository
    {
        

        public BillRepository(ISession session) : base(session)
        {
            
        }
    }
}
