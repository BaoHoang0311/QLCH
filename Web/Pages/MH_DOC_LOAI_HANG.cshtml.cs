using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using DAL;
using Services;

namespace Web.Pages
{
    public class MH_DOC_LOAI_HANGModel : PageModel
    {
        [BindProperty]
        public string tu_khoa { get; set; }

        public List<LOAIHANG> ds_loai_hang;

        public IXuLyLOAIHANG xl_loai_hang;

        public Servicesresult<List<LOAIHANG>> kq;
       
        public MH_DOC_LOAI_HANGModel()
        {
            xl_loai_hang = new XuLyLoaiHang();
        }
        public void OnGet()
        {
            kq = xl_loai_hang.doc_loai_hang(null);
            ds_loai_hang = kq.data;
        }
        public void OnPost()
        {
            kq = xl_loai_hang.doc_loai_hang(tu_khoa);
            ds_loai_hang = kq.data;
        }
    }
}
