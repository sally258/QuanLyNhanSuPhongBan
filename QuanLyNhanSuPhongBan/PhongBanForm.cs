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
    
    public partial class PhongBanForm : Form
    {
        QuanLyNhanSuPhongBanEntities db = MenuMain.db;
        public PhongBanForm()
        {
            InitializeComponent();
            LoadForm();
        }
        
        private void PhongBanForm_Load(object sender, EventArgs e)
        {
        }

        void LoadForm()
        {
            LoadData();
            AddBinding();
        }

        void LoadData()
        {
            var result = from c in db.PhongBans 
                         select new {
                             MaPhong = c.MaPhong,
                             TenPhong = c.TenPhong,
                             SoNhanVien = c.SoNhanVien,
                             ViTri = c.ViTri
                         };
            dtGVPhongBan.DataSource = result.ToList();
            dtGVPhongBan.Columns[0].HeaderText = "Mã phòng";
            dtGVPhongBan.Columns[1].HeaderText = "Tên phòng";
            dtGVPhongBan.Columns[2].HeaderText = "Số nhân viên";
            dtGVPhongBan.Columns[3].HeaderText = "Vị trí";
        }

        void AddBinding()
        {
            txtMaPhongBan.DataBindings.Clear();
            txtTenPhongBan.DataBindings.Clear();
            lblSoNhanVien.DataBindings.Clear();
            txtViTri.DataBindings.Clear();

            txtMaPhongBan.DataBindings.Add(new Binding("Text", dtGVPhongBan.DataSource, "MaPhong"));
            txtTenPhongBan.DataBindings.Add(new Binding("Text", dtGVPhongBan.DataSource, "TenPhong"));
            lblSoNhanVien.DataBindings.Add(new Binding("Text", dtGVPhongBan.DataSource, "SoNhanVien"));
            txtViTri.DataBindings.Add(new Binding("Text", dtGVPhongBan.DataSource, "ViTri"));
        }

        void AddPhongBan()
        {
            string maphong = txtMaPhongBan.Text;
            string tenphong = txtTenPhongBan.Text;
            string vitri = txtViTri.Text;

            PhongBan pb = new PhongBan {MaPhong = maphong, TenPhong = tenphong, SoNhanVien = 0, ViTri = vitri};
            db.PhongBans.Add(pb);
            db.SaveChanges();
        }

        int checkAddPhongBan()
        {
            string maphong = txtMaPhongBan.Text;
            string tenphong = txtTenPhongBan.Text;

            if (maphong.Length == 0)
            {
                MessageBox.Show("Mã phòng không được trống!", "Thông báo!");
                return 0;
            }

            if (maphong.Length > 10)
            {
                MessageBox.Show("Mã phòng không quá 10 ký tự!", "Thông báo!");
                return 0;
            }  
            if (tenphong.Length == 0)
            {
                MessageBox.Show("Tên phòng không được trống!", "Thông báo!");
                return 0;
            }    
            if (tenphong.Length > 100)
            {
                MessageBox.Show("Tên phòng không vượt quá 100 ký tự", "Thông báo!");
                return 0;
            }

            // check Mã phòng ban tồn tại.
            int rowIndex = -1;
            foreach (DataGridViewRow row in dtGVPhongBan.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(maphong))
                {
                    rowIndex = row.Index;
                    break;
                }    
            }    
            if (rowIndex != -1)
            {
                MessageBox.Show("Mã phòng đã tồn tại!", "Thông báo!");
                return 0;
            }    

            return 1;
        }

        int DeletePhongBan()
        {
            string maphong = txtMaPhongBan.Text;
            PhongBan pb = db.PhongBans.Where(p => p.MaPhong == maphong).FirstOrDefault();
            if (pb != null)
            {
                db.PhongBans.Remove(pb);
                db.SaveChanges();
                return 1;
            }
            return 0;
        }
        int checkEditPhongBan()
        {
            int rowIndex = -1;
            foreach (DataGridViewRow row in dtGVPhongBan.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(txtMaPhongBan.Text))
                {
                    rowIndex = row.Index;
                    break;
                }
            }
            if (rowIndex == -1)
            {
                MessageBox.Show("Mã phòng không tồn tại!", "Thông báo!");
                return 0;
            }   
            
            return 1;
        }    
        void EditPhongBan()
        {
            string maphong = txtMaPhongBan.Text;
            string tenphong = txtTenPhongBan.Text;
            string vitri = txtViTri.Text;

            PhongBan pb = db.PhongBans.Find(maphong);
            
            pb.TenPhong = tenphong;
            pb.ViTri = vitri;

            db.SaveChanges();
        }
        private void btnTruongPhong_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Đồng ý thêm phòng ban?", "Thông báo!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (checkAddPhongBan() == 1)
                {
                    AddPhongBan();
                    MessageBox.Show("Thêm phòng ban " + txtMaPhongBan.Text + " thành công!", "Thông báo!");
                    LoadForm();
                }    
            }    
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Đồng ý xóa phòng ban?", "Thông báo!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int c = DeletePhongBan();
                if (c == 1)
                {
                    MessageBox.Show("Xóa phòng ban " + txtMaPhongBan.Text + " thành công!", "Thông báo!");
                    LoadForm();
                }
                else
                {
                    MessageBox.Show("Mã phòng ban không tồn tại!", "Thông báo!");
                } 
            }    
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maphong = txtMaPhongBan.Text;

            DialogResult result = MessageBox.Show("Đồng ý sửa thông tin phòng "+maphong+"?", "Thông báo!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (checkEditPhongBan() == 1)
                {
                    EditPhongBan();
                    MessageBox.Show("Sửa thông tin phòng " + txtMaPhongBan.Text + " thành công!", "Thông báo!");
                    LoadForm();
                }   
            }    
        }
    }
}
