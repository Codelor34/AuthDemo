using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AuthDemo.Models
{
    public class ChatLieu : ThongTinChung
    {
        [Key]
        public Guid MaterialID { get; set; } // giữ nguyên
        [StringLength(50)]
        public string TenChatLieu { get; set; }
        [StringLength(50)]
        public string MaChatLieuCode { get; set; }
        public ICollection<ChiTietGiay> ?ChiTietGiays { get; set; }
    }
} 