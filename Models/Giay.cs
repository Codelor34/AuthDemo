using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Models
{
    public class Giay : ThongTinChung
    {
        [Key]
        public Guid ShoeID { get; set; } // giữ nguyên
        [StringLength(100)]
        public string TenGiay { get; set; }
        [StringLength(50)]
        public string MaGiayCode { get; set; }
        [StringLength(255)]
        public string MoTa { get; set; }
        [StringLength(50)]
        public string ?TrangThai { get; set; }
        public ICollection<ChiTietGiay> ?ChiTietGiays { get; set; }
    }
}