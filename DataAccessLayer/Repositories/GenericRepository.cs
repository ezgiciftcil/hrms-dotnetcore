using DataAccessLayer.EF;
using DataAccessLayer.Repositories.Interface;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class, IEntity, new()
    {
        public void Add(T t)
        {
            using(var context=new Context())
            {
                context.Add(t);
                context.SaveChanges();
            }
        }

        public void Delete(T t)
        {
            using (var context = new Context())
            {
                context.Remove(t);
                context.SaveChanges();
            }
        }

        public List<T> GetAll()
        {
            using (var context = new Context())
            {
                return context.Set<T>().ToList();
            }
        }

        public T GetById(int id)
        {
            using (var context = new Context())
            {
                return context.Set<T>().Find(id);
            }
        }

        public void Update(T t)
        {
            using (var context = new Context())
            {
                context.Update(t);
                context.SaveChanges();
            }
        }
    }
}
