using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Newtonsoft.Json;
namespace DAL
{
    public interface  ILT_PRODUCT
    {
        List<product> doc_danh_Sach();
        void ghi_danh_sach_mat_hang(List<product> ds_san_pham);
        List<LOAIHANG> doc_loai_hang();
    }
}
