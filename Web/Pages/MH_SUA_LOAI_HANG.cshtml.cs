using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Entities;

namespace Web.Pages
{
    public class MH_SUA_LOAI_HANGModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Pid { get; set; }
        [BindProperty]
        public LOAIHANG loai_hang { get; set; }
        public IXuLyLOAIHANG xulyloaihang;
        public string temp_id { get; set; }
        public MH_SUA_LOAI_HANGModel()
        {
            xulyloaihang = new XuLyLoaiHang();
        }
        public void OnGet()
        {
            loai_hang = xulyloaihang.doc_loai_hang_id(Pid);

        }
        public void OnPost()
        {
            temp_id = Pid;
            loai_hang.Ma_hang = Pid;
            Servicesresult<bool> kq = xulyloaihang.sua_loai_hang(loai_hang,temp_id);
            Response.Redirect("/Loai-Hang");
        }
    }
}
