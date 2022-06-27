using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace Services
{
    public interface IXuLyHoaDon <T>
    {
        List<T> doc_hoa_don();
        T doc_hoa_don(string Pid);
        List<T> tim_kiem_hoa_don(DateTime ngay);
        Servicesresult<bool> Them_hoa_don(T hd);
        void Xoa_hoa_don(string Pid);
        Servicesresult<List<T>> Sua_hoa_don(T hd);
    }
}
