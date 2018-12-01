﻿using QLThuVien.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuVien.BUS
{
    class Nhanvien
    {
        Database db;
        public Nhanvien()
        {
            db = new Database();
        }
        public DataTable LayDSNhanvien()
        {
            string strSQL = "Select Manhanvien, HoTenNhanVien, Ngaysinh," + "Diachi,Dienthoai, TenBangcap From Nhanvien N, BANGCAP B " +"Where N.MaBangCap = B.MaBangCap";
            DataTable dt = db.Execute(strSQL);
            return dt;
        }
        public DataTable LayBangcap()
        {
            string strSQL = "Select * from bangcap";
            DataTable dt = db.Execute(strSQL);
            return dt;
        }
        public void Xoa(string index_nv)
        {
            string sql = "Delete from NhanVien where MaNhanVien = " +index_nv;
            db.ExecuteNonQuery(sql);
        }
        //Thêm 1 nhân viên mới
        public void Them(string ten, string ngaysinh,string diachi, string dienthoai, string index_bc)
        {
            string sql = string.Format("Insert Into NhanVien Values(N'{0}', '{1}', N'{2}', '{3}',{4})",ten, ngaysinh, diachi, dienthoai, index_bc);
            db.ExecuteNonQuery(sql);
        }
        //Cập nhật nhân viên
        public void CapNhat(string index_nv, string hoten,
            string ngaysinh, string diachi, string dienthoai, string index_bc)
        {
            //Chuẩn bị câu lẹnh truy vấn
            string str = string.Format("Update NHANVIEN set HoTenNhanVien = N'{0}', NgaySinh = '{1}', diachi = N'{2}',dienthoai = '{3}', MaBangCap = {4} where MaNhanVien = {5}",hoten, ngaysinh, diachi, dienthoai, index_bc, index_nv);
            db.ExecuteNonQuery(str);
        }
    }

}

