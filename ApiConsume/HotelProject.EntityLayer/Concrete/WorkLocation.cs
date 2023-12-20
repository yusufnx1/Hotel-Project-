namespace HotelProject.EntityLayer.Concrete
{
    public class WorkLocation
    {
        public int WorkLocationId { get; set; }
        public string WorkLocationCityName { get; set;}
        public string WorkLocationCity { get; set;}

        public List<AppUser> Users { get; set; }
    }
}
