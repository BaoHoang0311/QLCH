using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
namespace Services
{
    public class XuLyLoaiHang : IXuLyLOAIHANG
    {
        public XuLyProduct xl_product;
        
        public ILT_LoaiHang lt_loai_hang;
        
        public List<LOAIHANG> ds_loai_hang { get; set; }
        public List<product> ds_san_pham { get; set; }
        public XuLyLoaiHang()
        {
            xl_product = new XuLyProduct();

            lt_loai_hang = new LT_LoaiHang();
            // đọc ds loại hàng
            ds_loai_hang = lt_loai_hang.doc_loai_hang();
            // đọc ds san pham
            ds_san_pham = xl_product.doc_danh_Sach().data;
        }
        public Servicesresult<List<LOAIHANG>> doc_loai_hang(string tu_khoa)
        {
            if (tu_khoa == null)
            {
                return new Servicesresult<List<LOAIHANG>>("", ds_loai_hang, true);
            }
            var ds_tim_kiem = ds_loai_hang.FindAll(p => p.Ten_loai_hang.ToLower().Trim().Contains(tu_khoa.Trim().ToLower()));
            return new Servicesresult<List<LOAIHANG>>("", ds_tim_kiem, true);
        }
        public Servicesresult<bool> them_loai_hang(LOAIHANG p)
        {
            foreach (var item in ds_loai_hang) // trùng tên ko cho thêm
            {
                if (item.Ten_loai_hang.ToLower().Trim() == p.Ten_loai_hang.ToLower().Trim())
                {
                    return new Servicesresult<bool>("Tên Loại Hàng Bị Trùng", false, false);
                }
            }
            p.Ma_hang = (int.Parse(ds_loai_hang[^1].Ma_hang) + 1).ToString();
            ds_loai_hang.Add(p);
            lt_loai_hang.ghi_loai_hang(ds_loai_hang);
            return new Servicesresult<bool>("Thêm Thành Công", true, true);
        }
        public LOAIHANG doc_loai_hang_id(string tu_khoa)
        {
            var ds_tim_kiem = ds_loai_hang.FirstOrDefault(p => p.Ma_hang == tu_khoa);
            return ds_tim_kiem;
        }
        // xóa loại hàng thì phải xóa luôn thằng sản phẩm thuộc loại hàng đó
        public Servicesresult<bool> xoa_loai_hang(string Pid)
        {
            LOAIHANG loai_hang_co_Pid = ds_loai_hang.FirstOrDefault(p => p.Ma_hang == Pid);

            if (loai_hang_co_Pid != null)
            {
                for (int i = 0; i < ds_san_pham.Count; i++)
                {
                    if (ds_san_pham[i].Loai_hang == loai_hang_co_Pid.Ten_loai_hang)
                    {
                        xl_product.xoa_san_pham(ds_san_pham[i].Ma);
                    }
                }
            }
            ds_loai_hang.Remove(ds_loai_hang.FirstOrDefault(p => p.Ma_hang == Pid));
            lt_loai_hang.ghi_loai_hang(ds_loai_hang);
            return new Servicesresult<bool>("Xóa Thành Công", true, true);
        }

        // sửa cả bảng sf và loại sf
        public Servicesresult<bool> sua_loai_hang(LOAIHANG c, string Pid)
        {
            // lấy Pid để tìm ra cái tên cũ loại hàng trước khi đổi trong ds loại hàng,
            LOAIHANG loai_hang_co_Pid = ds_loai_hang.FirstOrDefault(p => p.Ma_hang == Pid);

            // ko cho trùng tên
            // tên cũ = tên mới trả về 
            if (loai_hang_co_Pid.Ten_loai_hang == c.Ten_loai_hang)
            {
                return new Servicesresult<bool>("Trùng Tên ! vui lòng sửa lại tên khác", false, false);
            }

            //thay đổi bên bản sản phẩm
            for (int i = 0; i < ds_san_pham.Count; i++)
            {
                if (ds_san_pham[i].Loai_hang == loai_hang_co_Pid.Ten_loai_hang)
                {
                    ds_san_pham[i].Loai_hang = c.Ten_loai_hang;
                    xl_product.lt_product.ghi_danh_sach_mat_hang(ds_san_pham);
                }
            }

            int index = ds_loai_hang.FindIndex(p => p.Ma_hang == Pid);
            ds_loai_hang[index].Ten_loai_hang = c.Ten_loai_hang;
            lt_loai_hang.ghi_loai_hang(ds_loai_hang);

            return new Servicesresult<bool>("Sửa Thành Công", true, true);

        }
    }
}
