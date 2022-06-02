using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.Repository.EntityIRepository;
namespace HospitalManagementSystem.Repository.EntityRepository
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        

        public AppointmentRepository(ISession session) : base(session)
        {
            
        }
    }
}
