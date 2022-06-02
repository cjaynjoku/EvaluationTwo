using HospitalManagementSystem.Entity;
using NHibernate;
using HospitalManagementSystem.Repository.EntityIRepository;

namespace HospitalManagementSystem.Repository.EntityRepository
{
    public class AccountantRepository : GenericRepository<Accountant>, IAccountantRepository
    {
        

        public AccountantRepository(ISession session):base(session)
        {
            
        }
    }
}
