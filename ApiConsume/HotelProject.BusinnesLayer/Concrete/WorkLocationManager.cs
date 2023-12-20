using HotelProject.BusinnesLayer.Abstrack;
using HotelProject.DataAccesLayer.Abstrack;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinnesLayer.Concrete
{
    public class WorkLocationManager : IWorkLocationService
    {
        private readonly IWorkLocationDal _workLocation;

        public WorkLocationManager(IWorkLocationDal workLocation)
        {
            _workLocation = workLocation;
        }

        public void TDelete(WorkLocation t)
        {
            _workLocation.Delete(t);    
        }

        public WorkLocation TGetById(int id)
        {
            return _workLocation.GetById(id);
        }

        public List<WorkLocation> TGetList()
        {
            return _workLocation.GetList();
        }

        public void TInsert(WorkLocation t)
        {
            _workLocation.Insert(t);
        }

        public void TUpdate(WorkLocation t)
        {
            _workLocation.Update(t);
        }
    }
}
