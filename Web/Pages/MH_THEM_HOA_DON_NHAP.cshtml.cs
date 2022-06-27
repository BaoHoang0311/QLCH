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
    public class MH_THEM_HOA_DON_NHAPModel : PageModel
    {
        public IXuLyHoaDon<Hoa_don_nhap> xl_hoa_don_nhap;

        public IXuLyProduct xl_product;

        public string chuoi;
        public List<product> ds_san_pham { get; set; }
        [BindProperty]
        public string Ten_San_Pham { get; set; }

        [BindProperty]
        public Hoa_don_nhap hdnhap { get; set; }

        public MH_THEM_HOA_DON_NHAPModel()
        {
            xl_hoa_don_nhap = new XuLyHoaDonNhap();
            xl_product = new XuLyProduct();
            ds_san_pham = xl_product.doc_danh_Sach().data;
        }
        public void OnPost()
        {
            hdnhap.SanPham = Ten_San_Pham;
            Servicesresult<bool> kq = xl_hoa_don_nhap.Them_hoa_don(hdnhap);
            if (kq.isSuccess == true) chuoi = kq.chuoi;
            else chuoi = kq.chuoi;
        }
    }
}
