using System;
using System.Collections.Generic;
using DAL;
using Entities;
using Newtonsoft.Json;
using System.Linq;
namespace Services
{
    public class XuLyProduct : IXuLyProduct
    {
        public ILT_PRODUCT lt_product;

        public XuLyProduct()
        {
            lt_product = new LT_PRODUCT();
        }
        public Servicesresult<List<product>> doc_danh_Sach()
        {
            try
            {
                var ds_san_pham = lt_product.doc_danh_Sach();
                return new Servicesresult<List<product>>("doc thanh cong", ds_san_pham, true);
            }
            catch (Exception ex)
            {
                return new Servicesresult<List<product>>(ex.Message, null, false);
            }
        }
        public Servicesresult<List<product>> danh_sach_tim_kiem_mat_hang(string tu_khoa, DateTime ngaynhap)
        {
            var danh_sach_mat_hang = doc_danh_Sach();
            if (tu_khoa == null )
            {
                tu_khoa = "";
            }
            else //(tu_khoa != null)
            {
                tu_khoa = tu_khoa.ToLower().Trim();
            }
            if (ngaynhap == default)
            {
                ngaynhap = new DateTime(9999, 12, 31);
            }
            var danh_sach_tim_kiem = new List<product>();
            danh_sach_tim_kiem = danh_sach_mat_hang.data.FindAll(thanh_phan => (thanh_phan.Ma.ToString().Contains(tu_khoa) || thanh_phan.Ten_hang.ToString().ToLower().Contains(tu_khoa) ||
             thanh_phan.Cong_ty_sx.ToString().ToLower().Contains(tu_khoa) || thanh_phan.Loai_hang.ToString().ToLower().Contains(tu_khoa)) && ngaynhap > thanh_phan.Han_dung);
            return new Servicesresult<List<product>>("Tim kiem thành công", danh_sach_tim_kiem, true);
        }
        public Servicesresult<bool> them_san_pham(product p)
        {
            var danh_sach_mat_hang = doc_danh_Sach();
            foreach (var item in danh_sach_mat_hang.data) 
            {
                // trùng tên nhưng khác loại cũng ko cho thêm
                if (item.Ten_hang.ToLower().Trim() == p.Ten_hang.ToLower().Trim() )
                {
                    return new Servicesresult<bool>("Tên Sản Phẩm bị trùng", false, false);
                }
            }
            p.Han_dung.ToShortDateString();
            p.Ma = (int.Parse(danh_sach_mat_hang.data[^1].Ma) + 1).ToString();
            danh_sach_mat_hang.data.Add(p);
            lt_product.ghi_danh_sach_mat_hang(danh_sach_mat_hang.data);
            return new Servicesresult<bool>("Thêm Thành Công", true, true);
        }
        public Servicesresult<product> doc_san_pham(string Pid)
        {
            var danh_sach_mat_hang = doc_danh_Sach();
            var san_pham = danh_sach_mat_hang.data.FirstOrDefault(p => p.Ma == Pid);
            return new Servicesresult<product>("", san_pham, true);
        }
        public Servicesresult<List<product>> sua_san_pham(product c)
        {
            var danh_sach_mat_hang = doc_danh_Sach();

            int id_1 = danh_sach_mat_hang.data.FindIndex(p => p.Ma == c.Ma);
            danh_sach_mat_hang.data[id_1].Ten_hang = c.Ten_hang ;
            danh_sach_mat_hang.data[id_1].Han_dung = c.Han_dung;
            danh_sach_mat_hang.data[id_1].Cong_ty_sx = c.Cong_ty_sx;
            danh_sach_mat_hang.data[id_1].Nam_sx = c.Nam_sx;
            danh_sach_mat_hang.data[id_1].Loai_hang = c.Loai_hang != null ? c.Loai_hang : danh_sach_mat_hang.data[id_1].Loai_hang;
            
            lt_product.ghi_danh_sach_mat_hang(danh_sach_mat_hang.data);
            return new Servicesresult<List<product>>("Sửa Thành Công", danh_sach_mat_hang.data, true);
        }
        public Servicesresult<List<product>> xoa_san_pham(string Pid)
        {
            var danh_sach_mat_hang = doc_danh_Sach();
            danh_sach_mat_hang.data.Remove(danh_sach_mat_hang.data.FirstOrDefault(p => p.Ma == Pid));
            lt_product.ghi_danh_sach_mat_hang(danh_sach_mat_hang.data);
            return new Servicesresult<List<product>>("", danh_sach_mat_hang.data, true);
        }
        public Servicesresult<List<LOAIHANG>> doc_loai_hang()
        {
            try
            {
                var ds_loai_hang = lt_product.doc_loai_hang();
                return new Servicesresult<List<LOAIHANG>>("doc thanh cong", ds_loai_hang, true);
            }

            catch (Exception ex)
            {
                return new Servicesresult<List<LOAIHANG>>(ex.Message, null, false);
            }
        }

        public List<product> danh_sach_tim_cung_the_loai(string Pid)
        {
            var ds_san_pham = lt_product.doc_danh_Sach();

            var ds_tim_kiem = ds_san_pham.FindAll(p => p.Loai_hang==Pid);
            return ds_tim_kiem;
        }

        public List<product> ds_tim_kiem_ton_kho()
        {
            var ds_san_pham = lt_product.doc_danh_Sach();

            return ds_san_pham.FindAll(p => p.Soluong > 0);
        }
    }
}
