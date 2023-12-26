using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinnesLayer.Abstrack
{
    public interface IRoomService : IGenericService<Room>
    {
        int TRoomCount();
    }
}
