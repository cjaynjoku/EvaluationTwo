using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagementSystem.Entity;
using NHibernate;
using HospitalManagementSystem.Repository.EntityIRepository;



namespace HospitalManagementSystem.Repository.EntityRepository
{
    public class ReceptionistRepository: GenericRepository<Receptionist>, IReceptionistRepository
    {

        public ReceptionistRepository(ISession session) : base(session)
        {
            
        }
    }
}
