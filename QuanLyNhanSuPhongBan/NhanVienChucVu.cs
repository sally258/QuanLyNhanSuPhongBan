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
    public partial class txtPhongBan : Form
    {
        QuanLyNhanSuPhongBanEntities db = MenuMain.db;
        public txtPhongBan()
        {
            InitializeComponent();
            LoadForm();
        }

        private void txtPhongBan_Load(object sender, EventArgs e)
        {

        }
        
        void LoadForm()
        {
            LoadData();
            LoadNhanVien();
            LoadChucVu();
            ShowProperties();
        }
        void LoadData()
        {
            var result = from c in db.NhanVien_ChucVu
                         join d in db.ChucVus on c.MaChucVu equals d.MaChucVu
                         join p in db.NhanViens on c.MaNhanVien equals p.MaNhanVien
                         select new
                         {
                             MaNhanVien = c.MaNhanVien,
                             TenNhanVien = p.TenNhanVien,
                             ChucVu = d.TenChucVu
                         };
            
            if (result != null)
            {
                dtGVChucVuNhanVien.DataSource = result.ToList();
                dtGVChucVuNhanVien.Columns[0].HeaderText = "Mã nhân viên";
                dtGVChucVuNhanVien.Columns[1].HeaderText = "Tên nhân viên";
                dtGVChucVuNhanVien.Columns[2].HeaderText = "Chức vụ";
            }    


        }
        void LoadNhanVien()
        {
            var result = db.NhanViens.Select(p => p.MaNhanVien);
            if (result != null)
            {
                cbbMaNhanVien.DataSource = result.ToList();
            }    
        }
        void LoadChucVu()
        {
            var result = db.ChucVus.Select(p => p.MaChucVu);
            if (result != null)
            {
                cbbChucVu.DataSource = result.ToList();
            }    
        }
        void ShowProperties()
        {
            var result1 = db.NhanViens.Where(p => p.MaNhanVien == cbbMaNhanVien.Text).Select(p => p.TenNhanVien).FirstOrDefault();
            txtTenNhanVien.Text = result1.ToString();
            var result2 = db.ChucVus.Where(p => p.MaChucVu == cbbChucVu.Text).Select(p => p.TenChucVu).FirstOrDefault();
            txtTenChucVu.Text = result2.ToString();
            var result3 = db.NhanViens.Where(p => p.MaNhanVien == cbbMaNhanVien.Text).Select(p => p.MaPhong).FirstOrDefault();
            txtMaPhong.Text = result3.ToString();
        }

        private void dtGVChucVuNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void cbbMaNhanVien_SelectedValueChanged(object sender, EventArgs e)
        {
            var result1 = db.NhanViens.Where(p => p.MaNhanVien == cbbMaNhanVien.Text).Select(p => p.TenNhanVien).FirstOrDefault();
            txtTenNhanVien.Text = result1.ToString();
            var result3 = db.NhanViens.Where(p => p.MaNhanVien == cbbMaNhanVien.Text).Select(p => p.MaPhong).FirstOrDefault();
            txtMaPhong.Text = result3.ToString();
        }

        private void cbbChucVu_SelectedValueChanged(object sender, EventArgs e)
        {
            var result2 = db.ChucVus.Where(p => p.MaChucVu == cbbChucVu.Text).Select(p => p.TenChucVu).FirstOrDefault();
            txtTenChucVu.Text = result2.ToString();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cbbMaNhanVien.SelectedIndex = 0;
            cbbChucVu.SelectedIndex = 0;
            LoadData();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            var result = from c in db.NhanVien_ChucVu
                         join d in db.ChucVus on c.MaChucVu equals d.MaChucVu
                         join p in db.NhanViens on c.MaNhanVien equals p.MaNhanVien
                         where p.MaNhanVien == cbbMaNhanVien.Text
                         select new
                         {
                             MaNhanVien = c.MaNhanVien,
                             TenNhanVien = p.TenNhanVien,
                             TenChucVu = d.TenChucVu,
                         };
           
            dtGVChucVuNhanVien.DataSource = result.ToList();
            dtGVChucVuNhanVien.Columns[0].HeaderText = "Mã nhân viên";
            dtGVChucVuNhanVien.Columns[1].HeaderText = "Tên nhân viên";
            dtGVChucVuNhanVien.Columns[2].HeaderText = "Chức vụ";
        }

        void AddNhanVienChucVu ()
        {
            if (cbbMaNhanVien.Text.Length > 0 && cbbChucVu.Text.Length > 0)
            {
                NhanVien_ChucVu result = db.NhanVien_ChucVu.Where(p => p.MaNhanVien == cbbMaNhanVien.Text && p.MaChucVu == cbbChucVu.Text).FirstOrDefault();
                if (result != null)
                {
                    MessageBox.Show("Nhân viên "+cbbMaNhanVien.Text+" đã tồn tại chức vụ "+cbbChucVu.Text+"!", "Thông báo!");

                } else
                {
                    NhanVien_ChucVu nvcv = new NhanVien_ChucVu { MaNhanVien = cbbMaNhanVien.Text, MaChucVu = cbbChucVu.Text };
                    db.NhanVien_ChucVu.Add(nvcv);
                    db.SaveChanges();

                    MessageBox.Show("Đã thêm chức vụ " + cbbChucVu.Text + " cho nhân viên " + cbbMaNhanVien.Text + " thành công!", "Thông báo!");
                    changeAfterAddNhanVienChucVu();

                    var result1 = from c in db.NhanVien_ChucVu
                                 join d in db.ChucVus on c.MaChucVu equals d.MaChucVu
                                 join p in db.NhanViens on c.MaNhanVien equals p.MaNhanVien
                                 where p.MaNhanVien == cbbMaNhanVien.Text
                                 select new
                                 {
                                     MaNhanVien = c.MaNhanVien,
                                     TenNhanVien = p.TenNhanVien,
                                     TenChucVu = d.TenChucVu,
                                 };

                    dtGVChucVuNhanVien.DataSource = result1.ToList();
                    dtGVChucVuNhanVien.Columns[0].HeaderText = "Mã nhân viên";
                    dtGVChucVuNhanVien.Columns[1].HeaderText = "Tên nhân viên";
                    dtGVChucVuNhanVien.Columns[2].HeaderText = "Chức vụ";
                } 
            }    
        }
        void changeAfterAddNhanVienChucVu()
        {
            ChucVu cv = db.ChucVus.Where(p => p.MaChucVu == cbbChucVu.Text).FirstOrDefault();
            cv.SoNhanVien = cv.SoNhanVien + 1;
            db.SaveChanges();
        }
        void DeleteNhanVienChucVu()
        {
            if (cbbMaNhanVien.Text.Length > 0 && cbbChucVu.Text.Length > 0)
            {
                NhanVien_ChucVu result = db.NhanVien_ChucVu.Where(p => p.MaNhanVien == cbbMaNhanVien.Text && p.MaChucVu == cbbChucVu.Text).FirstOrDefault();
                if (result == null)
                {
                    MessageBox.Show("Nhân viên " + cbbMaNhanVien.Text + " không tồn tại chức vụ " + cbbChucVu.Text + "!", "Thông báo!");
                } else
                {
                    db.NhanVien_ChucVu.Remove(result);
                    db.SaveChanges();

                    changeBeforeDeleteNhanVienChucVu();
                    MessageBox.Show("Xóa chức vụ " + cbbChucVu.Text + " cho nhân viên " + cbbMaNhanVien.Text + " thành công!", "Thông báo!");

                    var result1 = from c in db.NhanVien_ChucVu
                                 join d in db.ChucVus on c.MaChucVu equals d.MaChucVu
                                 join p in db.NhanViens on c.MaNhanVien equals p.MaNhanVien
                                 where p.MaNhanVien == cbbMaNhanVien.Text
                                 select new
                                 {
                                     MaNhanVien = c.MaNhanVien,
                                     TenNhanVien = p.TenNhanVien,
                                     TenChucVu = d.TenChucVu,
                                 };

                    dtGVChucVuNhanVien.DataSource = result1.ToList();
                    dtGVChucVuNhanVien.Columns[0].HeaderText = "Mã nhân viên";
                    dtGVChucVuNhanVien.Columns[1].HeaderText = "Tên nhân viên";
                    dtGVChucVuNhanVien.Columns[2].HeaderText = "Chức vụ";
                }
            }    
        }
        void changeBeforeDeleteNhanVienChucVu()
        {
            ChucVu cv = db.ChucVus.Where(p => p.MaChucVu == cbbChucVu.Text).FirstOrDefault();
            cv.SoNhanVien = cv.SoNhanVien - 1;
            db.SaveChanges();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Đồng ý thêm chức vụ " + cbbChucVu.Text + " cho nhân viên " + cbbMaNhanVien.Text + "?", "Thông báo!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                AddNhanVienChucVu();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Đồng ý xóa chức vụ " + cbbChucVu.Text + " của nhân viên " + cbbMaNhanVien.Text + "?", "Thông báo!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                DeleteNhanVienChucVu();
        }
    }
}
