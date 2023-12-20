using HotelProject.DataAccesLayer.Abstrack;
using HotelProject.DataAccesLayer.Concrete;
using HotelProject.DataAccesLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccesLayer.EntityFramework
{
    public class EfContactDal : GenericRepository<Contact>, IContactDal
    {
        public EfContactDal(Context contex) : base(contex)
        {
        }

        public int GetContactCount()
        {
            var context = new Context();
            return context.Contacts.Count();    
        }
    }
}
