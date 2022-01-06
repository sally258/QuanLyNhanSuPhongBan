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
    public partial class NhanVienForm : Form
    {
        QuanLyNhanSuPhongBanEntities db = MenuMain.db;
        public NhanVienForm()
        {
            InitializeComponent();
            LoadForm();
        }
      
        private void NhanVienForm_Load(object sender, EventArgs e)
        {

        }

        void LoadForm()
        {
            LoadData();
            
        }
        void LoadData()
        {
            var result = from nv in db.NhanViens
                         join pb in db.PhongBans on nv.MaPhong equals pb.MaPhong into dept
                         from PhongBan in dept.DefaultIfEmpty()
                         select new
                         {
                             MaNhanVien =nv.MaNhanVien,
                             TenNhanVien = nv.TenNhanVien,
                             PhongBan = PhongBan.TenPhong
                         };
            if (result != null)
            {
                dtGVNhanVien.DataSource = result.ToList();

                dtGVNhanVien.Columns[0].HeaderText = "Mã nhân viên";
                dtGVNhanVien.Columns[1].HeaderText = "Tên nhân viên";
                dtGVNhanVien.Columns[2].HeaderText = "Phòng ban";
            }    
            
        }

        void ShowProperties(string manhanvien)
        {
            NhanVien nv = db.NhanViens.Where(p => p.MaNhanVien == manhanvien).FirstOrDefault();
            if (nv != null)
            {
                txtMaNhanVien.Text = nv.MaNhanVien;
                txtTenNhanVien.Text = nv.TenNhanVien;
                timePickerNgaySinh.Value = (DateTime)nv.NgaySinh;
                txtDiaChi.Text = nv.DiaChi;
                rdNam.Checked = true ? nv.GioiTinh == "Nam" : false;
                rdNu.Checked = true ? nv.GioiTinh == "Nữ" : false;
                txtSDT.Text = nv.SoDienThoai;
                txtEmail.Text = nv.Email;
                txtCMND.Text = nv.CMND;
                txtHocVan.Text = nv.HocVan;
                txtHonNhan.Text = nv.TinhTrangHonNhan;
                txtPhongBan.Text = nv.MaPhong;
                if (nv.NgayVaoLam != null) timePickerNgayVaoLam.Value = (DateTime)nv.NgayVaoLam;
                if (nv.Luong != null) txtLuong.Text = nv.Luong.ToString(); 
            }
            
            var lstNvcv = db.NhanVien_ChucVu.Where(p => p.MaNhanVien == manhanvien).Select(p => p.MaChucVu).ToList();
            for (int i=0; i<lstNvcv.Count; i++)
            {
                var nvcv = lstNvcv[i];
                ChucVu cv = db.ChucVus.Where(p => p.MaChucVu == nvcv).FirstOrDefault();
                if (cv != null)
                {
                    lstNvcv[i] = cv.TenChucVu;
                }    
            }

            cbbChucVu.Text = "";
            cbbChucVu.DataSource = lstNvcv;

            var result = from c in db.NhanVien_ChucVu
                         join d in db.ChucVus on c.MaChucVu equals d.MaChucVu
                         where c.MaNhanVien == manhanvien
                         select d.TenChucVu.ToList();
            cbbChucVu.DataSource = result;
        }

        void Clear()
        {
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            timePickerNgaySinh.Value = DateTime.Parse("01/01/2022");
            txtDiaChi.Text = "";
            rdNam.Checked = false;
            rdNu.Checked = false;
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtCMND.Text = "";
            txtHocVan.Text = "";
            txtHonNhan.Text = "";
            txtPhongBan.Text = "";
            timePickerNgayVaoLam.Value = DateTime.Parse("01/01/2022");
            txtLuong.Text = "";
        }

        void AddNhanVien()
        {
            NhanVien nv = new NhanVien()
            {
                MaNhanVien = txtMaNhanVien.Text,
                TenNhanVien = txtTenNhanVien.Text,
                NgaySinh = timePickerNgaySinh.Value,
                NgayVaoLam = timePickerNgayVaoLam.Value
            };
            if (rdNam.Checked == true) nv.GioiTinh = "Name";
            else if (rdNu.Checked == true) nv.GioiTinh = "Nu";
            if (txtDiaChi.Text.Length > 0)
                nv.DiaChi = txtDiaChi.Text;
            if (txtSDT.Text.Length > 0)
                nv.SoDienThoai = txtSDT.Text;
            if (txtEmail.Text.Length > 0)
                nv.Email = txtEmail.Text;
            if (txtCMND.Text.Length > 0)
                nv.CMND = txtCMND.Text;
            if (txtHocVan.Text.Length > 0)
                nv.HocVan = txtHocVan.Text;
            if (txtHonNhan.Text.Length > 0)
                nv.TinhTrangHonNhan = txtHonNhan.Text;
            if (txtPhongBan.Text.Length > 0)
                nv.MaPhong = txtPhongBan.Text;
            else
                nv.MaPhong = "None";
            if (txtLuong.Text != null)
                nv.Luong = decimal.Parse(txtLuong.Text);
            db.NhanViens.Add(nv);
            db.SaveChanges();
            changeAfterAddNhanVien();
        }

        int checkAddNhanVien()
        {
            if (txtMaNhanVien.Text.Length == 0)
            {
                MessageBox.Show("Mã nhân viên không được trống!", "Thông báo!");
                return 0;
            }    
            if (txtMaNhanVien.Text.Length > 10)
            {
                MessageBox.Show("Mã nhân viên không quá 10 ký tự!", "Thông báo!");
                return 0;
            }    
            if (txtTenNhanVien.Text.Length == 0)
            {
                MessageBox.Show("Tên nhân viên không được trống!", "Thông báo!");
                return 0;
            }    
            if (txtTenNhanVien.Text.Length > 100)
            {
                MessageBox.Show("Tên nhân viên không quá 100 ký tự!", "Thông báo!");
                return 0;
            }   
            if (txtDiaChi.Text.Length > 255)
            {
                MessageBox.Show("Địa chỉ không quá 255 ký tự!", "Thông báo!");
                return 0;
            }   
            if (txtSDT.Text.Length > 15)
            {
                MessageBox.Show("Số điện thoại không quá 15 ký tự!", "Thông báo!");
                return 0;
            }    
            if (txtEmail.Text.Length > 50)
            {
                MessageBox.Show("Email không quá 50 ký tự!", "Thông báo!");
                return 0;
            }    
            if (txtCMND.Text.Length > 15)
            {
                MessageBox.Show("CMND không quá 15 ký tự!", "Thông báo!");
                return 0;
            }    
            if (txtHocVan.Text.Length > 50)
            {
                MessageBox.Show("Học vấn không quá 50 ký tự!", "Thông báo!");
                return 0;
            }    
            if (txtHonNhan.Text.Length > 20)
            {
                MessageBox.Show("Tình trạng hôn nhân không quá 20 ký tự!", "Thông báo!");
                return 0;
            }    
            if (txtPhongBan.Text.Length > 10)
            {
                MessageBox.Show("Mã phòng ban không quá 10 ký tự!", "Thông báo!");
                return 0;
            }    
            try
            {
                decimal luong = decimal.Parse(txtLuong.Text);

            } catch
            {
                MessageBox.Show("Lương phải là số thực!", "Thông báo!");
                return 0;
            }
            NhanVien nv = db.NhanViens.Where(p => p.MaNhanVien == txtMaNhanVien.Text).FirstOrDefault();
            if (nv != null)
            {
                MessageBox.Show("Mã nhân viên " + txtMaNhanVien.Text + " đã tồn tại!", "Thông báo!");
                return 0;
            }
            PhongBan pb = db.PhongBans.Where(p => p.MaPhong == txtPhongBan.Text).FirstOrDefault();
            if (pb == null && txtPhongBan.Text.Length > 0)
            {
                MessageBox.Show("Mã phòng ban không tồn tại!", "Thông báo!");
                return 0;
            }    
            return 1;
        }
        
        void changeAfterAddNhanVien ()
        {
            if (txtPhongBan.Text.Length > 0)
            {
                PhongBan pb = db.PhongBans.Where(p => p.MaPhong == txtPhongBan.Text).FirstOrDefault();
                pb.SoNhanVien = pb.SoNhanVien + 1;
                db.SaveChanges();
            }
        }
        private void dtGVNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string manhanvien = dtGVNhanVien.SelectedCells[0].OwningRow.Cells["MaNhanVien"].Value.ToString();
            ShowProperties(manhanvien);
        }

        void DeleteNhanVien()
        {
            NhanVien nv = db.NhanViens.Where(p => p.MaNhanVien == txtMaNhanVien.Text).FirstOrDefault();
            if (nv != null)
            {
                changeBeforeDeleteNhanVien();
                db.NhanViens.Remove(nv);
                db.SaveChanges();
                MessageBox.Show("Xóa thành công!", "Thông báo!");
            } else
            {
                MessageBox.Show("Mã nhân viên " + txtMaNhanVien.Text + " không tồn tại!", "Thông báo!");
            }
        }

        int checkEditNhanVien()
        {
            if (txtTenNhanVien.Text.Length == 0)
            {
                MessageBox.Show("Tên nhân viên không được trống!", "Thông báo!");
                return 0;
            }
            if (txtTenNhanVien.Text.Length > 100)
            {
                MessageBox.Show("Tên nhân viên không quá 100 ký tự!", "Thông báo!");
                return 0;
            }
            if (txtDiaChi.Text.Length > 255)
            {
                MessageBox.Show("Địa chỉ không quá 255 ký tự!", "Thông báo!");
                return 0;
            }
            if (txtSDT.Text.Length > 15)
            {
                MessageBox.Show("Số điện thoại không quá 15 ký tự!", "Thông báo!");
                return 0;
            }
            if (txtEmail.Text.Length > 50)
            {
                MessageBox.Show("Email không quá 50 ký tự!", "Thông báo!");
                return 0;
            }
            if (txtCMND.Text.Length > 15)
            {
                MessageBox.Show("CMND không quá 15 ký tự!", "Thông báo!");
                return 0;
            }
            if (txtHocVan.Text.Length > 50)
            {
                MessageBox.Show("Học vấn không quá 50 ký tự!", "Thông báo!");
                return 0;
            }
            if (txtHonNhan.Text.Length > 20)
            {
                MessageBox.Show("Tình trạng hôn nhân không quá 20 ký tự!", "Thông báo!");
                return 0;
            }
            if (txtPhongBan.Text.Length > 10)
            {
                MessageBox.Show("Mã phòng ban không quá 10 ký tự!", "Thông báo!");
                return 0;
            }
            try
            {
                decimal luong = decimal.Parse(txtLuong.Text);

            }
            catch
            {
                MessageBox.Show("Lương phải là số thực!", "Thông báo!");
                return 0;
            }
            PhongBan pb = db.PhongBans.Where(p => p.MaPhong == txtPhongBan.Text).FirstOrDefault();
            if (pb == null && txtPhongBan.Text.Length > 0)
            {
                MessageBox.Show("Mã phòng ban không tồn tại!", "Thông báo!");
                return 0;
            }
            return 1;
        }
        void EditNhanVien()
        {
            NhanVien nv = db.NhanViens.Find(txtMaNhanVien.Text);

            if (nv == null)
            {
                MessageBox.Show("Mã nhân viên " + txtMaNhanVien.Text + " không tồn tại!", "Thông báo!");
            }
            else
            {
                if (checkEditNhanVien() == 1)
                {
                    if (txtTenNhanVien.Text.Length > 0)
                        nv.TenNhanVien = txtTenNhanVien.Text;
                    if (rdNam.Checked == true)
                        nv.GioiTinh = "Nam";
                    if (rdNu.Checked == true)
                        nv.GioiTinh = "Nữ";
                    nv.NgaySinh = timePickerNgaySinh.Value;
                    if (txtDiaChi.Text.Length > 0)
                        nv.DiaChi = txtDiaChi.Text;
                    if (txtSDT.Text.Length > 0)
                        nv.SoDienThoai = txtSDT.Text;
                    if (txtEmail.Text.Length > 0)
                        nv.Email = txtEmail.Text;
                    if (txtCMND.Text.Length > 0)
                        nv.CMND = txtCMND.Text;
                    if (txtHocVan.Text.Length > 0)
                        nv.HocVan = txtHocVan.Text;
                    if (txtHonNhan.Text.Length > 0)
                        nv.TinhTrangHonNhan = txtHonNhan.Text;
                    if (txtLuong.Text.Length > 0)
                        nv.Luong = decimal.Parse(txtLuong.Text);
                    nv.NgayVaoLam = timePickerNgayVaoLam.Value;
                    if (txtPhongBan.Text.Length > 0)
                    {
                        changeBeforeEditNhanVien();
                        changeAfterEditNhanVien();
                        nv.MaPhong = txtPhongBan.Text;
                    }
                    db.SaveChanges();
                    MessageBox.Show("Thay đổi thông tin nhân viên " + txtMaNhanVien.Text + " thành công!", "Thông báo!");
                }
            
        }  
             
        }    
        void changeBeforeEditNhanVien()
        {
            NhanVien nv = db.NhanViens.Where(p => p.MaNhanVien == txtMaNhanVien.Text).FirstOrDefault();
            if (nv.MaPhong != null)
            {
                PhongBan pb = db.PhongBans.Where(p => p.MaPhong == nv.MaPhong).FirstOrDefault();
                pb.SoNhanVien = pb.SoNhanVien - 1;
                db.SaveChanges();
            }    
        }
        void changeAfterEditNhanVien()
        {
            PhongBan pb = db.PhongBans.Where(p => p.MaPhong == txtPhongBan.Text).FirstOrDefault();
            if (pb != null)
            {
                pb.SoNhanVien = pb.SoNhanVien + 1;
                db.SaveChanges();
            }    
        }
        void changeBeforeDeleteNhanVien()
        {
            NhanVien nv = db.NhanViens.Where(p => p.MaNhanVien == txtMaNhanVien.Text).FirstOrDefault();
            if (nv.MaPhong != null)
            {
                PhongBan pb = db.PhongBans.Where(p => p.MaPhong == nv.MaPhong).FirstOrDefault();
                pb.SoNhanVien = pb.SoNhanVien - 1;
                db.SaveChanges();
            }
            var lstNvCv = db.NhanVien_ChucVu.Where(p => p.MaNhanVien == txtMaNhanVien.Text).ToList();
            foreach (var nvcv in lstNvCv)
            {
                ChucVu cv = db.ChucVus.Where(p => p.MaChucVu == nvcv.MaChucVu).FirstOrDefault();
                cv.SoNhanVien = cv.SoNhanVien - 1;
                db.NhanVien_ChucVu.Remove(nvcv);
                db.SaveChanges();
            }    
        }    

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Đồng ý thêm nhân viên!", "Thông báo!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (checkAddNhanVien() == 1)
                {
                    AddNhanVien();
                    MessageBox.Show("Thêm nhân viên " + txtMaNhanVien.Text + " thành công!");
                    LoadForm();
                }   
            }    
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Đồng ý sửa thông tin nhân viên " + txtMaNhanVien.Text + "?", "Thông báo!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                EditNhanVien();
                LoadData();
            }    
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Đồng ý xóa nhân viên " + txtMaNhanVien.Text + "?", "Thông báo!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DeleteNhanVien();
                LoadForm();
            }    
        }
    }
}
