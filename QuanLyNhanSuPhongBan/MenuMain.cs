using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSuPhongBan
{
    
    public partial class MenuMain : Form
    {
        public static QuanLyNhanSuPhongBanEntities db = new QuanLyNhanSuPhongBanEntities();
        public MenuMain()
        {
            InitializeComponent();
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnPhongBan_Click(object sender, EventArgs e)
        {
            panelForm.Controls.Clear();
            PhongBanForm frmPhongBan = new PhongBanForm();
            frmPhongBan.TopLevel = false;
            panelForm.Controls.Add(frmPhongBan);
            frmPhongBan.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frmPhongBan.Dock = DockStyle.Fill;
            frmPhongBan.Show();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mnNhanVien_Click(object sender, EventArgs e)
        {
            panelForm.Controls.Clear();
            NhanVienForm frmNhanVien = new NhanVienForm();
            frmNhanVien.TopLevel = false;
            panelForm.Controls.Add(frmNhanVien);
            frmNhanVien.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frmNhanVien.Dock = DockStyle.Fill;
            frmNhanVien.Show();
        }

        private void mnChucVu_Click(object sender, EventArgs e)
        {
            panelForm.Controls.Clear();
            ChucVuForm frmChucVu = new ChucVuForm();
            frmChucVu.TopLevel = false;
            panelForm.Controls.Add(frmChucVu);
            frmChucVu.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frmChucVu.Dock = DockStyle.Fill;
            frmChucVu.Show();
        }

        private void thêmChứcVụChoNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelForm.Controls.Clear();
            txtPhongBan frmNhanVienChucVu = new txtPhongBan();
            frmNhanVienChucVu.TopLevel = false;
            panelForm.Controls.Add(frmNhanVienChucVu);
            frmNhanVienChucVu.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frmNhanVienChucVu.Dock = DockStyle.Fill;
            frmNhanVienChucVu.Show();
        }
    }
}
