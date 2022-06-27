using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace Web.Pages
{
    public class MH_HOA_DON_BANModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public DateTime tu_khoa { get; set; }

        public IXuLyHoaDon<Hoa_don_ban> xuLyHoaDonNhap;

        public List<Hoa_don_ban> ds_hoa_don_ban;

        public MH_HOA_DON_BANModel()
        {
            xuLyHoaDonNhap = new XuLyHoaDonBan();
        }
        public void OnGet()
        {
            ds_hoa_don_ban = xuLyHoaDonNhap.tim_kiem_hoa_don(tu_khoa);
        }
    }
}
