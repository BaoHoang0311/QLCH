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
    public class MH_DOC_SAN_PHAMModel : PageModel
    {

        [BindProperty (SupportsGet = true) ]
        public string tu_khoa { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime ngay { get; set; }

        public List<product> ds_san_pham;
        public IXuLyProduct ixulyproduct;

        public MH_DOC_SAN_PHAMModel()
        {
            ixulyproduct = new XuLyProduct();
        }
        public void OnGet()
        {
            //Servicesresult<List<product>> kq = ixulyproduct.doc_danh_Sach();
            //if (kq.isSuccess == true)
            //    ds_san_pham = kq.data;

            if(tu_khoa==null && ngay == default)
            {
                Servicesresult<List<product>> kq = ixulyproduct.doc_danh_Sach();
                if (kq.isSuccess == true)
                    ds_san_pham = kq.data;
            }
            else
            {
                Servicesresult<List<product>> kq = ixulyproduct.danh_sach_tim_kiem_mat_hang(tu_khoa, ngay);
                if (kq.isSuccess == true)
                    ds_san_pham = kq.data;
            }
        }
        public void OnPost()
        {
            //Servicesresult<List<product>> kq = ixulyproduct.danh_sach_tim_kiem_mat_hang(tu_khoa,ngay);
            //if (kq.isSuccess == true)
            //    ds_san_pham = kq.data;
        }
    }
}
