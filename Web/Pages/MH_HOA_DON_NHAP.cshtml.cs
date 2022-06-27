using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using Services;
namespace Web.Pages
{
    public class MH_HOA_DON_NHAPModel : PageModel
    {
        [BindProperty (SupportsGet =true)]
        public DateTime tu_khoa { get; set; }

        public IXuLyHoaDon<Hoa_don_nhap> xuLyHoaDonNhap;

        public List<Hoa_don_nhap> ds_hoa_don_nhap;

        public MH_HOA_DON_NHAPModel()
        {
            xuLyHoaDonNhap = new XuLyHoaDonNhap();
        }
        public void OnGet()
        {
            ds_hoa_don_nhap = xuLyHoaDonNhap.tim_kiem_hoa_don(tu_khoa);
        }
    }
}
