using QLThuVien.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuVien.BUS
{
    class SachBUS
    {
        Database db;
        public SachBUS()
        {
            db = new Database();
        }
        public DataTable LayDSSach()
        {
            string strSQL = "Select * from Sach";
            DataTable dt = db.Execute(strSQL);
            return dt;
        }
        public void XoaSach(string index_sh)
        {
            string sql = "Delete from Sach where MaSach = " + index_sh;
            db.ExecuteNonQuery(sql);
        }
        //Thêm 1 nhân viên mới
        public void ThemSach(string tenSach, string tacGia, string namXuatBan, string nhaXuatBan,string triGia, string ngayNhap)
        {
            string sql = string.Format("Insert Into Sach Values(N'{0}','{1}', {2},N'{3}',{4},'{5}')", tenSach, tacGia, namXuatBan, nhaXuatBan, triGia, ngayNhap);
            db.ExecuteNonQuery(sql);
        }
        //Cập nhật nhân viên
        public void CapNhatSach(string index_sh, string tenSach, string tacGia, string namXuatBan, string nhaXuatBan, string triGia, string ngayNhap)
        {
            //Chuẩn bị câu lẹnh truy vấn
            string str = string.Format("Update Sach set HoTenSach = N'{0}', TacGia =N'{1}', NamXuatBan = {2},NhaXuatBan= N'{3}', TriGia = {4} ,NgayNhap = '{5}',TienNo={6} where MaSach = {6}", tenSach, tacGia, namXuatBan, nhaXuatBan, triGia, ngayNhap, index_sh);
            db.ExecuteNonQuery(str);
        }
    }
}
