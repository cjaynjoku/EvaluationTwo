using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagementSystem.Repository.EntityIRepository;
using NHibernate;

namespace HospitalManagementSystem.Repository.Wrappers
{
    public interface IUnitOfWork
    {
        IAppointmentRepository AppointmentRepo { get; }
        IBillRepository BillRepo { get; }
        IAccountantRepository AccountantRepo { get; }
        IDoctorRepository DoctorRepo { get; }

        IHospitalRepository HospitalRepo { get; }

        IDrugRepository DrugRepo { get; }
        IMedicalConditionRepository ConditionRepo { get; }

        INurseRepository NurseRepo { get; }
        IPharmacistRepository PharmRepo { get; }
        IReceptionistRepository ReceptionistRepo { get; }
        IPatientRepository PatientRepo { get; }
        void Commit();





    }
}
