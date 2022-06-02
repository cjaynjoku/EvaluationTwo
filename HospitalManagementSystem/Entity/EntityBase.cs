using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Entity
{
    public class EntityBase
    {
        public virtual long Id { get; protected set; }
    }
}
