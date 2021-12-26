using EntityLayer;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IGenericDal<T> where T:class,IEntity,new()
    {
        void Add(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetAll();
        T GetById(int id);
    }
}
