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
    public class MH_THEM_LOAI_HANGModel : PageModel
    {
        public IXuLyLOAIHANG xl_loai_hang;
        public string chuoi { get; set; }
        [BindProperty]
        public LOAIHANG loaihang { get; set; }
        public MH_THEM_LOAI_HANGModel()
        {
            xl_loai_hang = new XuLyLoaiHang();
        }
        public void OnPost()
        {
            try
            {
                Servicesresult<bool> kq = xl_loai_hang.them_loai_hang(loaihang);
                if (kq.isSuccess == true) chuoi = "Thêm thành công";
                else chuoi = kq.chuoi;
            }
            catch (Exception ex)
            {
                chuoi = ex.Message;
            }
        }
    }
}
