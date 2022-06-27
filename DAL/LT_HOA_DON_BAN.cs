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
    public class LT_HOA_DON_BAN : ILT_HOA_DON<Hoa_don_ban>
    {
        public List<Hoa_don_ban> doc_hoa_don()
        {
            var ds_hd_ban = new List<Hoa_don_ban>();
            var duong_dan = @$"\OOP_DOAN\Web\du_lieu\hoa_don_ban.json";
            if (!File.Exists(duong_dan))
            {
                throw new Exception("duong dan ko ton tai");
            }
            StreamReader file = new StreamReader(duong_dan);
            string content = file.ReadToEnd();
            var kq = JsonConvert.DeserializeObject<Hoa_don_ban[]>(content);
            foreach (var hd_ban in kq)
            {
                ds_hd_ban.Add(hd_ban);
            }
            file.Close();
            return ds_hd_ban;
        }

        public void ghi_hoa_don(List<Hoa_don_ban> ds_hoa_don)
        {
            var duong_dan = @$"\OOP_DOAN\Web\du_lieu\hoa_don_ban.json";
            StreamWriter file = new StreamWriter(duong_dan);
            var content = JsonConvert.SerializeObject(ds_hoa_don);
            file.WriteLine(content);
            file.Close();
        }
    }
}
