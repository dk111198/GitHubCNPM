using QLThuVien.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuVien.BUS
{
    class DocGia
    {
        Database db;
        public DocGia()
        {
            db = new Database();
        }
        public DataTable LayDSDocGia()
        {
            string strSQL = "Select * from DocGia";
            DataTable dt = db.Execute(strSQL);
            return dt;
        }
        public void XoaDocGia(string index_dg)
        {
            string sql = "Delete from DocGia where MaDocGia = " + index_dg;
            db.ExecuteNonQuery(sql);
        }
        //Thêm 1 nhân viên mới
        public void ThemDocGia(string ten, string ngaysinh, string diachi, string email, string ngayLapThe,string ngayHetHan,string tienNo)
        {
            string sql = string.Format("Insert Into DocGia Values(N'{0}','{1}', '{2}',N'{3}','{4}','{5}',{6})", ten, ngaysinh, diachi, email,ngayLapThe,ngayHetHan,tienNo);
            db.ExecuteNonQuery(sql);
        }
        //Cập nhật nhân viên
        public void CapNhatDocGia(string index_dg, string ten, string ngaysinh, string diachi, string email, string ngayLapThe, string ngayHetHan, string tienNo)
        {
            //Chuẩn bị câu lẹnh truy vấn
            string str = string.Format("Update DocGia set HoTenDocGia = N'{0}', NgaySinh = '{1}', diachi = N'{2}',email= N'{3}', NgayLapThe = '{4}' ,NgayHetHan = '{5}',TienNo={6} where MaDocGia = {7}", ten, ngaysinh, diachi, email,ngayLapThe,ngayHetHan,tienNo,index_dg);
            db.ExecuteNonQuery(str);
        }
    }
}
