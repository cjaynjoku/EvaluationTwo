using HospitalManagementSystem.Entity;
using NHibernate;

namespace HospitalManagementSystem.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        protected ISession _session;

        public GenericRepository(ISession session)
        {
            _session = session;
        }
        public void AddEntity(T entity)
        {
            _session.Save(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _session.Query<T>();
        }

        public T GetById(long Id)
        {
            T entity = _session.Query<T>().FirstOrDefault(x => x.Id == Id);
            if(entity != null)
            {
                return entity;
            }
            else
            {
                throw new NullReferenceException("Invalid Id.");
            }
        }

        public bool IsExist(long Id)
        {
            return _session.Query<T>().FirstOrDefault(x => x.Id == Id) != null;
        }

        public void RemoveEntity(long Id)
        {
            T entity = _session.Query<T>().FirstOrDefault(x => x.Id == Id);
            if(entity != null)
            {
                _session.Delete(entity);

            }
            else
            {
                throw new NullReferenceException("Invalid Id");
            }
        }

        public void UpdateEntity(T entity)
        {
            if (IsExist(entity.Id))
            {
                _session.Update(entity);
            }
            else
            {
                throw new NullReferenceException("Entity does not exist.");
            }
        }
    }
}
