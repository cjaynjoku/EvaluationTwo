using HospitalManagementSystem.Entity;
using NHibernate;
using HospitalManagementSystem.Repository.EntityIRepository;


namespace HospitalManagementSystem.Repository.EntityRepository
{
    public class MedicalConditionRepository : GenericRepository<MedicalCondition>, IMedicalConditionRepository
    {
        

        public MedicalConditionRepository(ISession session) : base(session)
        {
           
        }
    }
}
