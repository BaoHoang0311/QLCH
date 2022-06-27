using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using Services;

namespace DO_AN
{
    public class MH_THEM_SAN_PHAMModel : PageModel
    {
        [BindProperty]
        public product san_pham { get; set; }
        [BindProperty]
        public string id { get; set; }
        public string chuoi { get; set; }

        public List<LOAIHANG> ds_loai_hang;

        public IXuLyProduct ixulyproduct;
        public MH_THEM_SAN_PHAMModel()
        {
            ixulyproduct = new XuLyProduct();
            ds_loai_hang = ixulyproduct.doc_loai_hang().data;
        }
        public void OnGet()
        {

        }
        public void OnPost()
        {
            try
            {
                Servicesresult<List<LOAIHANG>> ds_loai_hang = ixulyproduct.doc_loai_hang();
                san_pham.Loai_hang = ds_loai_hang.data.FirstOrDefault(lh => lh.Ma_hang == id).Ten_loai_hang;
                Servicesresult<bool> kq = ixulyproduct.them_san_pham(san_pham);
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
