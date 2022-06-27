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
    public class MH_THEM_HOA_DON_BANModel : PageModel
    {
        public IXuLyHoaDon<Hoa_don_ban> xl_hoa_don_ban;

        public IXuLyProduct xl_product;

        public string chuoi;
        public List<product> ds_san_pham { get; set; }
        [BindProperty]
        public string Ten_San_Pham { get; set; }

        [BindProperty]
        public Hoa_don_ban hdban { get; set; }

        public MH_THEM_HOA_DON_BANModel()
        {
            xl_hoa_don_ban = new XuLyHoaDonBan();
            xl_product = new XuLyProduct();
            ds_san_pham = xl_product.doc_danh_Sach().data;
        }
        public void OnPost()
        {
            hdban.SanPham = Ten_San_Pham;
            Servicesresult<bool> kq = xl_hoa_don_ban.Them_hoa_don(hdban);
            if (kq.isSuccess == true) chuoi = kq.chuoi;
            else chuoi = kq.chuoi;
        }
    }
}
