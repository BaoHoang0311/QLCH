using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Servicesresult<T>
    {
        public string chuoi { get; set; }
        public T data { get; set; }
        public bool isSuccess { get; set; }
        public Servicesresult(string _chuoi, T _data, bool _isSuccess)
        {
            chuoi = _chuoi;
            data = _data;
            isSuccess = _isSuccess;
        }
    }
}
