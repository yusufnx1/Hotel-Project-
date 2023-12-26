using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccesLayer.Abstrack
{
    public interface IAppUserDal : IGenericDal<AppUser>
    {
        List<AppUser> UserListWhitWorkLocation();
        List<AppUser> UserListWhitWorkLocations();
        int AppUserCout();
    }
}
