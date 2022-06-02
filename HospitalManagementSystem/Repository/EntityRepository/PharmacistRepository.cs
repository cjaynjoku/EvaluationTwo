using HospitalManagementSystem.Entity;
using NHibernate;
using HospitalManagementSystem.Repository.EntityIRepository;


namespace HospitalManagementSystem.Repository.EntityRepository
{
    public class PharmacistRepository : GenericRepository<Pharmacist>, IPharmacistRepository
    {

        public PharmacistRepository(ISession session) : base(session)
        {
            
        }
    }
}
