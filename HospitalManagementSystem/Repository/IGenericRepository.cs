using HospitalManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Repository
{
    public interface IGenericRepository<T> where T: EntityBase
    {
        bool IsExist(long Id);
        T GetById(long Id);
        IEnumerable<T> GetAll();
        void AddEntity(T entity);
        void UpdateEntity(T entity);
        void RemoveEntity(long Id);

    }
}
