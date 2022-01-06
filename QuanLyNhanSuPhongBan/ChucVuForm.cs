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
    public partial class ChucVuForm : Form
    {
        QuanLyNhanSuPhongBanEntities db = MenuMain.db;
        public ChucVuForm()
        {
            InitializeComponent();
            LoadForm();
        }

        private void ChucVuForm_Load(object sender, EventArgs e)
        {

        }
        void LoadForm()
        {
            LoadData();
            AddBinding();
        }

        void LoadData()
        {
            var result = from c in db.ChucVus
                         select new
                         {
                             MaChucVu = c.MaChucVu,
                             TenChucVu = c.TenChucVu,
                             SoNhanVien = c.SoNhanVien
                         };
            dtGVChucVu.DataSource = result.ToList();
            dtGVChucVu.Columns[0].HeaderText = "Chức vụ";
            dtGVChucVu.Columns[1].HeaderText = "Tên chức vụ";
            dtGVChucVu.Columns[2].HeaderText = "Số nhân viên";
        }

        void AddBinding()
        {
            txtMaChucVu.DataBindings.Clear();
            txtTenChucVu.DataBindings.Clear();
            txtSoNhanVien.DataBindings.Clear();

            txtMaChucVu.DataBindings.Add(new Binding("Text", dtGVChucVu.DataSource, "MaChucVu"));
            txtTenChucVu.DataBindings.Add(new Binding("Text", dtGVChucVu.DataSource, "TenChucVu"));
            txtSoNhanVien.DataBindings.Add(new Binding("Text", dtGVChucVu.DataSource, "SoNhanVien"));
        }

        void AddChucVu()
        {
            string machucvu = txtMaChucVu.Text;
            string tenchucvu = txtTenChucVu.Text;

            ChucVu pb = new ChucVu { MaChucVu = machucvu, TenChucVu = tenchucvu, SoNhanVien = 0};
            db.ChucVus.Add(pb);
            db.SaveChanges();
        }

        int checkAddChucVu()
        {
            string machucvu = txtMaChucVu.Text;
            string tenchucvu = txtTenChucVu.Text;

            if (machucvu.Length == 0)
            {
                MessageBox.Show("Mã chức vụ không được trống!", "Thông báo!");
                return 0;
            }    
            if (machucvu.Length > 10)
            {
                MessageBox.Show("Mã chức vụ không quá 10 ký tự!", "Thông báo!");
                return 0;
            }    
            if (tenchucvu.Length == 0)
            {
                MessageBox.Show("Tên chức vụ không được trống!", "Thông báo!");
                return 0;
            }    
            if (tenchucvu.Length > 50)
            {
                MessageBox.Show("Tên chức vụ không quá 50 ký tự!", "Thông báo!");
            }
            int rowIndex = -1;
            foreach (DataGridViewRow row in dtGVChucVu.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(machucvu))
                {
                    rowIndex = row.Index;
                    break;
                }
            }
            if (rowIndex != -1)
            {
                MessageBox.Show("Mã chức vụ đã tồn tại!", "Thông báo!");
                return 0;
            }
            return 1;
        }

        int DeleteChucVu()
        {
            string machucvu = txtMaChucVu.Text;
            ChucVu cv = db.ChucVus.Where(p => p.MaChucVu == machucvu).FirstOrDefault();
            if (cv != null)
            {
                db.ChucVus.Remove(cv);
                db.SaveChanges();
                return 1;
            }
            return 0;
        }

        void EditChucVu()
        {
            string machucvu = txtMaChucVu.Text;
            string tenchucvu = txtTenChucVu.Text;

            ChucVu cv = db.ChucVus.Find(machucvu);

            cv.TenChucVu = tenchucvu;
            db.SaveChanges();
        }

        int checkEditChucVu()
        {
            int rowIndex = -1;
            foreach (DataGridViewRow row in dtGVChucVu.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(txtMaChucVu.Text))
                {
                    rowIndex = row.Index;
                    break;
                }
            }
            if (rowIndex == -1)
            {
                MessageBox.Show("Mã chức vụ không tồn tại!", "Thông báo!");
                return 0;
            }
            return 1;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Đồng ý thêm chức vụ?", "Thông báo!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (checkAddChucVu() == 1)
                {
                    AddChucVu();
                    MessageBox.Show("Thêm chức vụ "+txtMaChucVu.Text+" thành công", "Thông báo!");
                    LoadForm();
                }    
            }    
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Đồng ý xóa chức vụ " + txtMaChucVu.Text + "?", "Thông báo!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int c = DeleteChucVu();
                if (c == 1)
                {
                    MessageBox.Show("Xóa chức vụ " + txtMaChucVu.Text + " thành công!", "Thông báo!");
                    LoadData();
                } else
                {
                    MessageBox.Show("Chức vụ " + txtMaChucVu.Text + " không tồn tại!", "Thông báo!");
                }
            }    
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Đồng ý sửa thông tin chức vụ " + txtMaChucVu.Text + " ?", "Thông báo!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (checkEditChucVu() == 1)
                {
                    EditChucVu();
                    MessageBox.Show("Sửa thông tin chức vụ " + txtMaChucVu.Text + " thành công!", "Thông báo!");
                    LoadForm();
                }    
            }    
        }
    }
}
