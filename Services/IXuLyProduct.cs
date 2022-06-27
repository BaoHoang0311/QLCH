using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;
using Newtonsoft.Json;
namespace Services
{
    public interface IXuLyProduct
    {
        Servicesresult<List<product>> doc_danh_Sach();
        Servicesresult<List<product>> danh_sach_tim_kiem_mat_hang(string tu_khoa,DateTime ngay);
        Servicesresult<bool> them_san_pham(product p); 
        Servicesresult<product> doc_san_pham(string Pid);
        Servicesresult<List<product>> sua_san_pham(product c);
        Servicesresult<List<product>> xoa_san_pham(string Pid);
        List<product> danh_sach_tim_cung_the_loai(string id);
        Servicesresult<List<LOAIHANG>> doc_loai_hang();

        List<product> ds_tim_kiem_ton_kho();
        
    }
}
