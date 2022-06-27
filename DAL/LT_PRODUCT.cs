using System;
using System.Collections.Generic;
using System.IO;
using Entities;
using Newtonsoft.Json;

namespace DAL
{
    public class LT_PRODUCT :ILT_PRODUCT
    {
        public List<product> doc_danh_Sach()
        {
            var danh_sach_mat_hang = new List<product>();
            var duong_dan = @"\OOP_DOAN\Web\du_lieu\mat_hang.json";
            if (!File.Exists(duong_dan))
            {
                throw new Exception("duong dan ko ton tai");
            }
            StreamReader file = new StreamReader(duong_dan);
            string content = file.ReadToEnd();
            var kq = JsonConvert.DeserializeObject<product[]>(content);
            foreach (var mat_hang in kq)
            {
                danh_sach_mat_hang.Add(mat_hang);
            }
            file.Close();
            return danh_sach_mat_hang;
        }
        public void ghi_danh_sach_mat_hang(List<product> ds_san_pham)
        {
            var duong_dan = @"\OOP_DOAN\Web\du_lieu\mat_hang.json";
            if (!File.Exists(duong_dan))
            {
                throw new Exception("duong dan ko ton tai");
            }
            StreamWriter file = new StreamWriter(duong_dan);
            string content = JsonConvert.SerializeObject(ds_san_pham);
            file.WriteLine(content);
            file.Close();
        }
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
    }
}
