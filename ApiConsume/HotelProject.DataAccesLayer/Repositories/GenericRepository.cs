using HotelProject.DataAccesLayer.Abstrack;
using HotelProject.DataAccesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccesLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly Context _contex;

        public GenericRepository(Context contex)
        {
            _contex = contex;
        }

        public void Delete(T t)
        {
            _contex.Remove(t);
            _contex.SaveChanges();
        }

        public T GetById(int id)
        {
            return _contex.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return _contex.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            _contex.Add(t);
            _contex.SaveChanges();
        }

        public void Update(T t)
        {
            _contex.Update(t);
            _contex.SaveChanges();
        }
    }
}
