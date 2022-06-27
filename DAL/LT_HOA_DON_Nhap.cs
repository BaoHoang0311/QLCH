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
    public class LT_HOA_DON_Nhap : ILT_HOA_DON<Hoa_don_nhap>
    {
        public List<Hoa_don_nhap> doc_hoa_don()
        {
            var ds_hd_nhap = new List<Hoa_don_nhap> ();
            var duong_dan = @$"\OOP_DOAN\Web\du_lieu\hoa_don_nhap.json";
            if (!File.Exists(duong_dan))
            {
                throw new Exception("duong dan ko ton tai");
            }
            StreamReader file = new StreamReader(duong_dan);
            string content = file.ReadToEnd();
            var kq = JsonConvert.DeserializeObject<Hoa_don_nhap[]>(content);
            foreach (var hd_nhap in kq)
            {
                ds_hd_nhap.Add(hd_nhap);
            }
            file.Close();
            return ds_hd_nhap;
        }

        public void ghi_hoa_don(List<Hoa_don_nhap> hoa_don)
        {
            var duong_dan = @$"\OOP_DOAN\Web\du_lieu\hoa_don_nhap.json";
            StreamWriter file = new StreamWriter(duong_dan);
            var content = JsonConvert.SerializeObject(hoa_don);
            file.WriteLine(content);
            file.Close();
        }
    }
}
