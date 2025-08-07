using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models.ViewModels
{
    public class CreateKhachHangVM
    {
        [Required]
        public string HoTen { get; set; }

        [Required]
        public string SDT { get; set; }

        public string email { get; set; }
        public string diachi { get; set; }
    }


}

