using HospitalManagementSystem.Repository.EntityIRepository;
using HospitalManagementSystem.Repository.EntityRepository;

using NHibernate;

namespace HospitalManagementSystem.Repository.Wrappers
{
    
    internal class UnitOfWork : IUnitOfWork
    {
        protected ISession session;
        public UnitOfWork()
        {
            session = NhibernateHelper.OpenSession();
        }
        private IAppointmentRepository _appointment;
        public IAppointmentRepository AppointmentRepo
        {
            get
            {
                if (_appointment == null)
                {
                    _appointment = new AppointmentRepository(session);
                }
                return _appointment;
            }
        }

        private IPatientRepository _patient;
        public IPatientRepository PatientRepo
        {
            get
            {
                if (_patient == null)
                {
                    _patient = new PatientRepository(session);
                }
                return _patient;
            }
        }

        private IBillRepository _bill;
        public IBillRepository BillRepo
        {
            get
            {
                if (_bill == null)
                {
                    _bill = new BillRepository(session);
                }
                return _bill;
            }

        }

        private IAccountantRepository _accountant;
        public IAccountantRepository AccountantRepo
        {
            get
            {
                if (_accountant == null)
                {
                    _accountant = new AccountantRepository(session);
                }
                return _accountant;
            }
        }

        private IDoctorRepository _doctor;
        public IDoctorRepository DoctorRepo
        {
            get
            {
                if (_doctor == null)
                {
                    _doctor = new DoctorRepository(session);
                }
                return _doctor;
            }
        }

        private IHospitalRepository _hospital;
        public IHospitalRepository HospitalRepo
        {
            get
            {
                if (_hospital == null)
                {
                    _hospital = new HospitalRepository(session);
                }
                return _hospital;
            }
        }

        private IDrugRepository _drug;
        public IDrugRepository DrugRepo
        {
            get
            {
                if (_drug == null)
                {
                    _drug = new DrugRepository(session);
                }
                return _drug;
            }
        }

        private IMedicalConditionRepository _condition;
        public IMedicalConditionRepository ConditionRepo
        {
            get
            {
                if (_condition == null)
                {
                    _condition = new MedicalConditionRepository(session);
                }
                return _condition;
            }
        }

        private INurseRepository _nurse;
        public INurseRepository NurseRepo
        {
            get
            {
                if (_nurse == null)
                {
                    _nurse = new NurseRepository(session);
                }
                return _nurse;
            }
        }

        private IPharmacistRepository _pharma;
        public IPharmacistRepository PharmRepo
        {
            get
            {
                if (_pharma == null)
                {
                    _pharma = new PharmacistRepository(session);
                }
                return _pharma;
            }
        }
        private IReceptionistRepository _receptionist;
        public IReceptionistRepository ReceptionistRepo
        {
            get
            {
                if (_receptionist == null)
                {
                    _receptionist = new ReceptionistRepository(session);
                }
                return _receptionist;
            }
        }

        public void Commit()
        {
            using (var transaction = session.BeginTransaction())
            {
                transaction.Commit();
            }
        }

    }
}
