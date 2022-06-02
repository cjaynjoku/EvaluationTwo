using HospitalManagementSystem.Entity;
using NHibernate;
using HospitalManagementSystem.Repository.EntityIRepository;


namespace HospitalManagementSystem.Repository.EntityRepository
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        

        public DoctorRepository(ISession session) : base(session)
        {
            
        }
    }
}
