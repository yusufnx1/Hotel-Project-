using HotelProject.BusinnesLayer.Abstrack;
using HotelProject.DataAccesLayer.Abstrack;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinnesLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public int TAppUserCout()
        {
            return _appUserDal.AppUserCout();
        }

        public void TDelete(AppUser t)
        {
            _appUserDal.Delete(t);
        }

        public AppUser TGetById(int id)
        {
            return _appUserDal.GetById(id);
        }

        public List<AppUser> TGetList()
        {
            return _appUserDal.GetList();
        }

        public void TInsert(AppUser t)
        {
            _appUserDal.Insert(t);
        }

        public void TUpdate(AppUser t)
        {
            _appUserDal.Update(t);
        }

        public List<AppUser> TUserListWhitWorkLocation()
        {
            return _appUserDal.UserListWhitWorkLocation();
        }

        public List<AppUser> TUserListWhitWorkLocations()
        {
            return _appUserDal.UserListWhitWorkLocations();
        }
    }
}
