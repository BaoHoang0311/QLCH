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
    public class MH_XOA_SAN_PHAMModel : PageModel
    {
        [BindProperty]
        public product san_pham { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Pid { get; set; }

        public string chuoi { get; set; }

        public IXuLyProduct ixulyproduct;


        public MH_XOA_SAN_PHAMModel()
        {
            ixulyproduct = new XuLyProduct();

        }
        public void OnGet()
        {
            san_pham = ixulyproduct.doc_san_pham(Pid).data;
        }
        public void OnPost()
        {
            Servicesresult<List<product>> ds_loai_hang =  ixulyproduct.xoa_san_pham(Pid);
            Response.Redirect("/MH_DOC_SAN_PHAM");
        }
    }
}
