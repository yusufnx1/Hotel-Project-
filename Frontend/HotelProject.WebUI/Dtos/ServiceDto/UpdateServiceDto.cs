using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceId { get; set; }
        [Required(ErrorMessage = "Hizmet ikon giriniz.")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Hizmet başlığı giriniz.")]
        [StringLength(100, ErrorMessage = "Hizmet başlığı en fazla 100 karakter kullanabilirsiniz.")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
