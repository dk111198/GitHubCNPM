using QLThuVien.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThuVien.GUI
{
    public partial class SachGUI : Form
    {
        private SachBUS _sachContext = new SachBUS();
        private bool _themmoi; 
        public SachGUI()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        void setNull()
        {
            txtTenSach.Text = "";
            txtTacGia.Text = "";
            txtTriGia.Text = "";
            txtNamXuatBan.Text = "";    
            txtNhaXuatBan.Text = "";
            
        }
        void setButton(bool val)
        {
            btnThem.Enabled = val;
            btnXoa.Enabled = val;
            btnSua.Enabled = val;
            btnThoat.Enabled = val;
            btnLuu.Enabled = !val;
            btnHuy.Enabled = !val;
        }
        void HienthiSach()
        {
            lsvSach.Items.Clear();
            DataTable dt =_sachContext.LayDSSach();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvSach.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][5].ToString());
            }
        }
        private void SachGUI_Load(object sender, EventArgs e)
        {
            setNull();
            setButton(true);
            HienthiSach();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            _themmoi = true;
            setButton(false);
            txtTenSach.Focus();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lsvSach.SelectedIndices.Count > 0)
            {
                _themmoi = false;
                setButton(false);
            }
            else
                MessageBox.Show("Bạn phải chọn mẫu tin cập nhật", "Sửa mẫu tin");
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lsvSach.SelectedIndices.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc xóa không ? ", "Xóa bằng cấp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    _sachContext.XoaSach(lsvSach.SelectedItems[0].SubItems[0].Text);
                    lsvSach.Items.RemoveAt(lsvSach.SelectedIndices[0]);
                    setNull();
                }
            }
            else
                MessageBox.Show("Bạn phải chọn mẩu tin cần xóa");
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            setButton(true);
        }
        private void lsvSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvSach.SelectedIndices.Count > 0)
            {
                txtTenSach.Text = lsvSach.SelectedItems[0].SubItems[1].Text;
                txtTacGia.Text = lsvSach.SelectedItems[0].SubItems[2].Text;
                txtNamXuatBan.Text =lsvSach.SelectedItems[0].SubItems[3].Text;
                txtNhaXuatBan.Text = lsvSach.SelectedItems[0].SubItems[4].Text;
                txtTriGia.Text = lsvSach.SelectedItems[0].SubItems[5].Text;
                dtpNgayNhap.Value=DateTime.Parse(lsvSach.SelectedItems[0].SubItems[6].Text);

            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string NgayNhap = String.Format("{0:MM/dd/yyyy}", dtpNgayNhap.Value);
            //Định dạng ngày tương ứng với trong CSDL SQLserver
            if (_themmoi)
            {
                _sachContext.ThemSach(txtTenSach.Text.Trim(),txtTacGia.Text.Trim(), txtNamXuatBan.Text.Trim(),txtNhaXuatBan.Text.Trim(), txtTriGia.Text.Trim(),NgayNhap );
                MessageBox.Show("Thêm mới thành công");
            }
            else
            {
                _sachContext.CapNhatSach(lsvSach.SelectedItems[0].SubItems[0].Text, txtTenSach.Text.Trim(), txtTacGia.Text.Trim(), txtNamXuatBan.Text.Trim(), txtNhaXuatBan.Text.Trim(), txtTriGia.Text.Trim(), NgayNhap);
                MessageBox.Show("Cập nhật thành công");
            }
            HienthiSach();
            setNull();
        }
    }
}
