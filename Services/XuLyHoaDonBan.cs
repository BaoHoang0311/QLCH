using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace Services
{
    public class XuLyHoaDonBan : IXuLyHoaDon<Hoa_don_ban>
    {
        public ILT_HOA_DON<Hoa_don_ban> lt_hoa_don_ban;
        public XuLyProduct xl_product;
        public List<Hoa_don_ban> ds_hoa_don;
        public XuLyHoaDonBan()
        {
            lt_hoa_don_ban = new LT_HOA_DON_BAN();
            xl_product = new XuLyProduct();
            ds_hoa_don = lt_hoa_don_ban.doc_hoa_don();
        }
        public List<Hoa_don_ban> doc_hoa_don()
        {
            return lt_hoa_don_ban.doc_hoa_don();
        }
        public List<Hoa_don_ban> tim_kiem_hoa_don(DateTime tu_khoa)
        {
            if (tu_khoa == default)
            {
                return ds_hoa_don;
            }
            return ds_hoa_don.FindAll(ngay => ngay.ngay_tao_hoa_don == tu_khoa);
        }
        public Hoa_don_ban doc_hoa_don(string Pid)
        {
            return ds_hoa_don.FirstOrDefault(p => p.ma == Pid);
        }

        public void Xoa_hoa_don(string Pid)
        {
            var hoa_don = ds_hoa_don.FirstOrDefault(p => p.ma == Pid);
            var check = ds_hoa_don.Remove(hoa_don);
            lt_hoa_don_ban.ghi_hoa_don(ds_hoa_don);
        }

        public Servicesresult<bool> Them_hoa_don(Hoa_don_ban hd)
        {
            var ds_san_pham = xl_product.doc_danh_Sach().data;
            var ds_hoa_don_ban = lt_hoa_don_ban.doc_hoa_don();
            hd.ma = (ds_hoa_don_ban.Count + 1).ToString();
            foreach (var sp in ds_san_pham)
            {
                if (sp.Ten_hang == hd.SanPham)
                {
                    //hết hạn thì cập nhật ngày mới, ko thì thôi
                    //nếu hết hạn thì xóa luôn 
                    if (sp.Han_dung < DateTime.Now)
                    {
                        return new Servicesresult<bool>("Sp này đã hết hạn trong kho không bán được", false, false);
                    }
                    else // sp.Han_dung >= DateTime.Now
                    {
                        if (sp.Soluong - hd.so_luong < 0)
                            return new Servicesresult<bool>("Số lượng ko đủ", false, false);
                        sp.Soluong = sp.Soluong - hd.so_luong;
                        xl_product.lt_product.ghi_danh_sach_mat_hang(ds_san_pham);
                        ds_hoa_don_ban.Add(hd);
                        lt_hoa_don_ban.ghi_hoa_don(ds_hoa_don_ban);
                    }
                    break;
                }
            }
            return new Servicesresult<bool>("Thêm hóa đơn bán thành công", true, true);
        }

        public Servicesresult<List<Hoa_don_ban>> Sua_hoa_don(Hoa_don_ban hdban)
        {
            var index = ds_hoa_don.FindIndex(p => p.ma == hdban.ma);
            ds_hoa_don[index].ngay_tao_hoa_don = hdban.ngay_tao_hoa_don;
            lt_hoa_don_ban.ghi_hoa_don(ds_hoa_don);
            return new Servicesresult<List<Hoa_don_ban>>("OK", ds_hoa_don, true);
        }
    }
}
