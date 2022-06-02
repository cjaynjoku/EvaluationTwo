using HospitalManagementSystem.HospitalEnum;

namespace HospitalManagementSystem.Entity
{
    public  abstract class Person:EntityBase
    {
        public virtual long PersonId { get; set; }
        public virtual string Name { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual string Address { get; set; }
        public virtual DateTime BirthDate { get; set; }

    }
}
