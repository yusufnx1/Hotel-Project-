using HotelProject.DataAccesLayer.Abstrack;
using HotelProject.DataAccesLayer.Concrete;
using HotelProject.DataAccesLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.DataAccesLayer.EntityFramework
{
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        public EfAppUserDal(Context contex) : base(contex)
        {
        }

        public int AppUserCout()
        {
            var context = new Context();
            var value = context.Users.Count();
            return value;
        }

        public List<AppUser> UserListWhitWorkLocation()
        {
            var context = new Context();
            return context.Users.Include(x => x.WorkLocation).ToList();
        }

        public List<AppUser> UserListWhitWorkLocations()
        {
            var context = new Context();
            var values = context.Users.Include(x => x.WorkLocation).ToList();
            return values;
        }
    }
}
