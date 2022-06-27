using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace DAL
{
    public interface ILT_LoaiHang
    {
        List<LOAIHANG> doc_loai_hang();
        void ghi_loai_hang(List<LOAIHANG> danh_sach_loai_hang);
    }
}
