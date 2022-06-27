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
    public class MH_XOA_HOA_DON_BANModel : PageModel
    {
        public XuLyHoaDonBan xl_hoa_don_ban;

        public IXuLyProduct xl_product;
        public Hoa_don_ban hoa_don_ban { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Pid { get; set; }
        public MH_XOA_HOA_DON_BANModel()
        {
            xl_hoa_don_ban = new XuLyHoaDonBan();
        }
        public void OnGet()
        {
            //input : Pid => trừ bên sản phẩm , xóa hóa đơn đó luôn

            hoa_don_ban = xl_hoa_don_ban.lt_hoa_don_ban.doc_hoa_don().FirstOrDefault(p => p.ma == Pid);
        }
        public void OnPost()
        {
            hoa_don_ban = new Hoa_don_ban();
            xl_hoa_don_ban.Xoa_hoa_don(Pid);
            Response.Redirect("/MH_HOA_DON_BAN");
        }
    }
}
