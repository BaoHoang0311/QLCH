using Entities;
using System.Collections.Generic;

namespace Services
{
    public interface IXuLyLOAIHANG
    {
        Servicesresult<List<LOAIHANG>> doc_loai_hang(string tu_khoa);
        Servicesresult<bool> them_loai_hang(LOAIHANG p);
        Servicesresult<bool> sua_loai_hang(LOAIHANG p, string temp_id);
        Servicesresult<bool> xoa_loai_hang(string Pid);
        LOAIHANG doc_loai_hang_id(string Pid);

    }
}
