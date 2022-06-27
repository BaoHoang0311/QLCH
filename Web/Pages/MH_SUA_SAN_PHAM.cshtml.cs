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
    public class MH_SUA_SAN_PHAMModel : PageModel
    {
        [BindProperty]
        public product san_pham { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Pid { get; set; }

        [BindProperty]
        public string id_loai_hang { get; set; }

        public List<LOAIHANG> ds_loai_hang;
        public string tlh { get; set; }
        public IXuLyProduct ixulyproduct;
        public string chuoi { get; set; }
        
        public MH_SUA_SAN_PHAMModel()
        {
            ixulyproduct = new XuLyProduct();
            ds_loai_hang = ixulyproduct.doc_loai_hang().data;
        }
        public void OnGet()
        {
            san_pham = ixulyproduct.doc_san_pham(Pid).data;
            tlh = san_pham.Loai_hang;
        }
        public void OnPost()
        {

            if(string.IsNullOrEmpty(id_loai_hang)==false)
            {
                san_pham.Loai_hang = ds_loai_hang.FirstOrDefault(lh => lh.Ma_hang == id_loai_hang).Ten_loai_hang;
            }

            san_pham.Ma = Pid;

            Servicesresult<List<product>> kq = ixulyproduct.sua_san_pham(san_pham);

            if(kq.isSuccess== true)
            {
                Response.Redirect("MH_DOC_SAN_PHAM");
            }
            else
            {
                san_pham = ixulyproduct.doc_san_pham(Pid).data;
                chuoi = kq.chuoi;
            }
        }
    }
}
