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
    public class MH_THONG_KE_TON_KHOModel : PageModel
    {
        public IXuLyProduct xu_ly_product;

        [BindProperty]
        public string tu_khoa { get; set; }
        public List<product> ds_san_pham;
        public MH_THONG_KE_TON_KHOModel()
        {
            xu_ly_product = new XuLyProduct();
        }        
        public void OnPost()
        {
            ds_san_pham = xu_ly_product.doc_danh_Sach().data;
        }
        public void OnGet()
        {
            ds_san_pham = xu_ly_product.ds_tim_kiem_ton_kho();
        }
    }
}
