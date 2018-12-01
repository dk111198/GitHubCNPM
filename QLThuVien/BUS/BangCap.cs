using QLThuVien.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuVien.BUS
{
    class BangCap
    {
        Database db;
        public BangCap()
        {
            db = new Database();
        }
        public DataTable LayBangcap()
        {
            string strSQL = "Select * from bangcap";
            DataTable dt = db.Execute(strSQL);
            return dt;
        }
        public void XoaBangCap(string index_nv)
        {
            string sql = "Delete from BangCap where MaBangCap = " + index_nv;
            db.ExecuteNonQuery(sql);
        }
        //Thêm 1 nhân viên mới
        public void ThemBangCap(string tenBangCap)
        {
            string sql = string.Format("Insert Into BangCap Values(N'{0}')", tenBangCap);
            db.ExecuteNonQuery(sql);
        }
        //Cập nhật nhân viên
        public void CapNhatBangCap(string index_bc,string tenBangCap)
        {
            //Chuẩn bị câu lẹnh truy vấn
            string str = string.Format("Update BangCap set TenBangCap = N'{0}'where MaBangCap = {1} ", tenBangCap,index_bc);    
            db.ExecuteNonQuery(str);
        }
    }
}
