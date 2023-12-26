using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinnesLayer.Abstrack
{
    public interface IStaffService : IGenericService<Staff>
    {
        int GetStaffCount();
        List<Staff> Last4Staff();
    }
}
