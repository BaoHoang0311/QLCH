using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class XuLyHoaDonNhap : IXuLyHoaDon<Hoa_don_nhap>
    {
        public ILT_HOA_DON<Hoa_don_nhap> lt_hoa_don;
        public XuLyProduct xl_product;
        public List<Hoa_don_nhap> ds_hoa_don;
        public XuLyHoaDonNhap()
        {
            lt_hoa_don = new LT_HOA_DON_Nhap();
            xl_product = new XuLyProduct();
            ds_hoa_don = lt_hoa_don.doc_hoa_don();
        }
        public List<Hoa_don_nhap> doc_hoa_don()
        {
            return lt_hoa_don.doc_hoa_don();
        }

        public List<Hoa_don_nhap> tim_kiem_hoa_don(DateTime tu_khoa)
        {
            if (tu_khoa == default)
            {
                return ds_hoa_don;
            }
            return ds_hoa_don.FindAll(ngay => ngay.ngay_tao_hoa_don == tu_khoa);
        }

        public Servicesresult<bool> Them_hoa_don(Hoa_don_nhap hd)
        {
            var ds_san_pham = xl_product.doc_danh_Sach().data;
            var ds_hoa_don_nhap = lt_hoa_don.doc_hoa_don();
            hd.ma = (ds_hoa_don_nhap.Count + 1).ToString();
            foreach (var sp in ds_san_pham)
            {
                if (sp.Ten_hang == hd.SanPham)
                {
                    //hết hạn thì cập nhật ngày mới, ko thì thôi
                    //nếu hết hạn thì xóa luôn 
                    if (sp.Han_dung < DateTime.Now)
                    {
                        return new Servicesresult<bool>("Sp này đã hết hạn trong kho không thể thêm vào", false, false);
                    }
                    else // sp.Han_dung >= DateTime.Now
                    {
                        hd.ma = ( ds_hoa_don.Count() + 1).ToString();
                        sp.Soluong = sp.Soluong + hd.so_luong;
                        xl_product.lt_product.ghi_danh_sach_mat_hang(ds_san_pham);
                        ds_hoa_don_nhap.Add(hd);
                        lt_hoa_don.ghi_hoa_don(ds_hoa_don_nhap);
                    }
                    break;
                }
            }
            return new Servicesresult<bool>("Thêm hóa đơn nhập thành công", true, true);
        }
        public void Xoa_hoa_don(string Pid)
        {
            var hoa_don = ds_hoa_don.FirstOrDefault(p => p.ma == Pid);
            var check = ds_hoa_don.Remove(hoa_don);
            lt_hoa_don.ghi_hoa_don(ds_hoa_don);

            // tìm sp trong bảng hóa đơn
            //var ds_san_pham = xl_product.doc_danh_Sach().data;
            //var san_pham = ds_san_pham.FirstOrDefault(p => p.Ten_hang == hoa_don.SanPham);

            //đoc ra dc sản phẩm
            //var index = xl_product.doc_danh_Sach().data.FindIndex(p =>
            //p.Ten_hang == hoa_don.SanPham);


            //ds_san_pham[index].Soluong = ds_san_pham[index].Soluong - hoa_don.so_luong;
            // ghi sản phẩm lại
            //xl_product.lt_product.ghi_danh_sach_mat_hang(ds_san_pham);

            // ghi hóa đơn nhập
        }
        public Hoa_don_nhap doc_hoa_don(string Pid)
        {
            return ds_hoa_don.FirstOrDefault(p => p.ma == Pid);
        }
        public Servicesresult<List<Hoa_don_nhap>> Sua_hoa_don(Hoa_don_nhap hdnhap)
        {
            var index = ds_hoa_don.FindIndex(p => p.ma == hdnhap.ma);
            ds_hoa_don[index].ngay_tao_hoa_don = hdnhap.ngay_tao_hoa_don;
            lt_hoa_don.ghi_hoa_don(ds_hoa_don);
            return new Servicesresult<List<Hoa_don_nhap>>("OK", ds_hoa_don,true);
        }
    }
}
