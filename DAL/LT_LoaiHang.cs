using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Newtonsoft.Json;

namespace DAL
{
    public class LT_LoaiHang : ILT_LoaiHang
    {

        public List<LOAIHANG> doc_loai_hang()
        {
            var danh_sach_loai_hang = new List<LOAIHANG>();
            string duong_dan = @"\OOP_DOAN\Web\du_lieu\loai_hang.json";
            StreamReader file = new StreamReader(duong_dan);
            string content = file.ReadToEnd();
            var loai_hang = JsonConvert.DeserializeObject<LOAIHANG[]>(content);
            foreach (var item in loai_hang)
            {
                danh_sach_loai_hang.Add(item);
            }
            file.Close();
            return danh_sach_loai_hang;
        }

        public void ghi_loai_hang(List<LOAIHANG> danh_sach_loai_hang)
        {
            string duong_dan = @"\OOP_DOAN\Web\du_lieu\loai_hang.json";
            StreamWriter file = new StreamWriter(duong_dan);
            var content = JsonConvert.SerializeObject(danh_sach_loai_hang);
            file.WriteLine(content);
            file.Close();
        }
    }
}
