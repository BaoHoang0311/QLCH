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
    public class MH_XOA_HOA_DON_NHAPModel : PageModel
    {
        public XuLyHoaDonNhap xl_hoa_don_nhap;

        public IXuLyProduct xl_product;
        public Hoa_don_nhap hoa_don_nhap { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Pid { get; set; }
        public MH_XOA_HOA_DON_NHAPModel()
        {
            xl_hoa_don_nhap = new XuLyHoaDonNhap();
        }
        public void OnGet()
        {
            //input : Pid => trừ bên sản phẩm , xóa hóa đơn đó luôn

            hoa_don_nhap = xl_hoa_don_nhap.lt_hoa_don.doc_hoa_don().FirstOrDefault(p => p.ma == Pid);
        }
        public void OnPost()
        {
            hoa_don_nhap = new Hoa_don_nhap();
            xl_hoa_don_nhap.Xoa_hoa_don(Pid);
            Response.Redirect("/MH_HOA_DON_NHAP");
        }
    }
}
