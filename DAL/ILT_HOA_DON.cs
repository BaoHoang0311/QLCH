using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace DAL
{
    public interface ILT_HOA_DON<T>
    {
        List<T> doc_hoa_don();
        void ghi_hoa_don( List<T> ds_hoa_don );
    }
}
