using HotelProject.DataAccesLayer.Abstrack;
using HotelProject.DataAccesLayer.Concrete;
using HotelProject.DataAccesLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccesLayer.EntityFramework
{
    public class EfSendMessageDal : GenericRepository<SendMessage>, ISendMessageDal
    {
        public EfSendMessageDal(Context contex) : base(contex)
        {
        }

        public int GetSenMessageCount()
        {
            var context = new Context();
            return context.SendMessages.Count();
        }
    }
}
