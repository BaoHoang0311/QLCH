using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Entities;
namespace Web.Pages
{
    public class MH_SUA_HOA_DON_NHAPModel : PageModel
    {
        public IXuLyHoaDon<Hoa_don_nhap> xl_hoa_don_nhap;

        [BindProperty]
        public Hoa_don_nhap hdnhap { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Pid { get; set; }
        public string chuoi { get; set; }
        public MH_SUA_HOA_DON_NHAPModel()
        {
            xl_hoa_don_nhap = new XuLyHoaDonNhap();
        }
        public void OnGet()
        {
            hdnhap = xl_hoa_don_nhap.doc_hoa_don(Pid);
        }
        public void OnPost()
        {
            hdnhap.ma = Pid;
            var kq = xl_hoa_don_nhap.Sua_hoa_don(hdnhap);
            Response.Redirect("/MH_HOA_DON_NHAP");
        }
    }
}
