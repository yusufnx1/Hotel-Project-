using HotelProject.DataAccesLayer.Abstrack;
using HotelProject.DataAccesLayer.Concrete;
using HotelProject.DataAccesLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccesLayer.EntityFramework
{
    public class EfStaffDal : GenericRepository<Staff>, IStaffDal
    {
        public EfStaffDal(Context context) : base(context)
        {

        }

        public int GetStaffCount()
        {
            var context = new Context();
            var value = context.Staff.Count();
            return value;
        }

        public List<Staff> Last4Staff()
        {
            var context = new Context();
            var values = context.Staff.OrderByDescending(x => x.StaffId).Take(4).ToList();
            return values;
        }
    }
}
