
using HospitalManagementSystem.Entity;
using FluentNHibernate.Mapping;


namespace HospitalManagementSystem.Mapping
{
    public class HospitalMap : ClassMap<Hospital>
    {
        public HospitalMap()
        {
            Id(x => x.Id);
            Map(x => x.ConsultationCharges);
            Map(x => x.RoomFee);
            HasMany(x => x.Doctors).Cascade.All();
            HasMany(x => x.Nurses).Cascade.All();
            HasMany(x => x.Pharmacists).Cascade.All();
            HasMany(x => x.Patients)
                .Inverse()
                .Cascade.All();
            HasOne(x => x.Receptionist).Cascade.All();
            HasOne(x => x.Accountant).Cascade.All();
            HasManyToMany(x => x.Drugs).Cascade.All();


        }
    }

    public class DoctorMap : ClassMap<Doctor>
    {
        public DoctorMap()
        {
            Id(x => x.Id);
            Map(x => x.DoctorId);
            References(x => x.Hospital);
            HasMany(x => x.Appointments).Inverse().Cascade.All();
          
        }
    }
    public class AccountantMap : ClassMap<Accountant>
    {
        public AccountantMap()
        {
            Id(x => x.Id);
            Map(x => x.AccountantId);
            Map(x => x.Name);
            HasOne(x => x.Hospital);
        }
    }

    public class AppointmentMap : ClassMap<Appointment>
    {
        public AppointmentMap()
        {
            Id(x => x.Id);
            Map(x => x.AppointmentId);
            References(x => x.Doctor).Cascade.All();
            HasOne(x => x.Patient)
                .Cascade.All();
            Map(x => x.AppointmentTime);
        }
    }
    public class BillMap : ClassMap<Bill>
    {
        public BillMap()
        {
            Id(x => x.Id);
            Map(x => x.BillId);
            References(x => x.Patient)
                .Cascade.All();
            Map(x => x.TotalCost);
            Map(x => x.BillPaid);
            Map(x => x.Remainder);
            HasManyToMany(x => x.Drugs);
        }
    }

    public class MedicalConditionMap : ClassMap<MedicalCondition>
    {
        public MedicalConditionMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.MedicalConditionId);
            HasManyToMany(x => x.Patients);
        }
    }

    public class DrugMap : ClassMap<Drug>
    {
        public DrugMap()
        {
            Id(x => x.Id);
            Map(x => x.DrugId);
            Map(x => x.DrugName);
            Map(x => x.DrugPrice);
            HasMany(x => x.Patients).Cascade.All();
            HasManyToMany(x => x.Bill).Cascade.All();
            HasManyToMany(x => x.Hospitals).Inverse().Cascade.All();
        }
    }

    public class NurseMap: ClassMap<Nurse>
    {
        public NurseMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.NurseId);
            References(x => x.Hospital);
        }
    }

    public class PharmacistMap: ClassMap<Pharmacist>
    {
        public PharmacistMap()
        {
            Id(x => x.Id);
            Map(x => x.PharmacistId);
            Map(x => x.Name);
            References(x => x.Hospital);
        }
    }

    public class ReceptionistMap: ClassMap<Receptionist>
    {
        public ReceptionistMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            HasOne(x => x.Hospital);
            Map(x => x.ReceptionistId);
            Map(x => x.AppointmentTime);

        }
    }

    public class PatientMap : ClassMap<Patient>
    {
        public PatientMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Gender);
            Map(x => x.PatientId);
            Map(x => x.Registered);
            Map(x => x.HospitalBudget);
            HasManyToMany(x => x.MedicalConditions).Cascade.All();
            References(x => x.Hospital);
            HasManyToMany(x => x.Drugs);
            HasOne(x => x.Bill).PropertyRef(r => r.Patient).Cascade.All();
            HasOne(x => x.Appointment).Cascade.All();
           
        }
    }
   

}
