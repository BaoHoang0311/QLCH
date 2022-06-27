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
    public class MH_THONG_KE_THE_LOAIModel : PageModel
    {
        [BindProperty (SupportsGet =true)]
        public string name { get; set; }

        public List<LOAIHANG> ds_loai_hang;
        public List<product> ds_san_pham;

        public IXuLyProduct ixuLyProduct;
        public IXuLyLOAIHANG ixuluLoaiHang;
        public MH_THONG_KE_THE_LOAIModel()
        {
            ixuLyProduct = new XuLyProduct();
            ds_loai_hang = ixuLyProduct.doc_loai_hang().data;
        }
        public void OnGet()
        {
            if (name == null)
            {
                ds_san_pham = ixuLyProduct.doc_danh_Sach().data;

            }
            else
            {
                ds_san_pham = ixuLyProduct.danh_sach_tim_cung_the_loai(name);
            }
        }
    }
}
