using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Hoa_don_nhap
    {
        public string ma { get; set; }
        [Required]
        public DateTime ngay_tao_hoa_don { get; set; }
        [Required]
        public string SanPham { get; set; }
        [Required]
        [Range(minimum:1,maximum:20)]
        public int so_luong { get; set; }
    }
}
