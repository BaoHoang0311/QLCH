using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class product
    {

        public string Ma { get; set; }
        [DisplayName("Tên Hàng")]
        [Required]
        public string Ten_hang { get; set; }
        [Required]
        public DateTime Han_dung { get; set; }
        [Required]
        public string Cong_ty_sx { get; set; }
        [Required]
        public int Nam_sx { get; set; }
        [Required]
        public string Loai_hang { get; set; }
        [Required]
        public int Soluong { get; set; }
    }
}
