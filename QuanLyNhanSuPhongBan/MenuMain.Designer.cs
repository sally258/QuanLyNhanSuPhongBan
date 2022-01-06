namespace QuanLyNhanSuPhongBan
{
    partial class MenuMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnQuanLy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnPhongBan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnChucVu = new System.Windows.Forms.ToolStripMenuItem();
            this.panelForm = new System.Windows.Forms.Panel();
            this.khácToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmChứcVụChoNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnHeThong,
            this.mnQuanLy});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(949, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnHeThong
            // 
            this.mnHeThong.Name = "mnHeThong";
            this.mnHeThong.Size = new System.Drawing.Size(69, 20);
            this.mnHeThong.Text = "Hệ thống";
            // 
            // mnQuanLy
            // 
            this.mnQuanLy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnPhongBan,
            this.mnNhanVien,
            this.mnChucVu,
            this.khácToolStripMenuItem});
            this.mnQuanLy.Name = "mnQuanLy";
            this.mnQuanLy.Size = new System.Drawing.Size(60, 20);
            this.mnQuanLy.Text = "Quản lý";
            this.mnQuanLy.Click += new System.EventHandler(this.quảnLýToolStripMenuItem_Click);
            // 
            // mnPhongBan
            // 
            this.mnPhongBan.Name = "mnPhongBan";
            this.mnPhongBan.Size = new System.Drawing.Size(180, 22);
            this.mnPhongBan.Text = "Phòng ban";
            this.mnPhongBan.Click += new System.EventHandler(this.mnPhongBan_Click);
            // 
            // mnNhanVien
            // 
            this.mnNhanVien.Name = "mnNhanVien";
            this.mnNhanVien.Size = new System.Drawing.Size(180, 22);
            this.mnNhanVien.Text = "Nhân viên";
            this.mnNhanVien.Click += new System.EventHandler(this.mnNhanVien_Click);
            // 
            // mnChucVu
            // 
            this.mnChucVu.Name = "mnChucVu";
            this.mnChucVu.Size = new System.Drawing.Size(180, 22);
            this.mnChucVu.Text = "Chức vụ";
            this.mnChucVu.Click += new System.EventHandler(this.mnChucVu_Click);
            // 
            // panelForm
            // 
            this.panelForm.AutoSize = true;
            this.panelForm.Location = new System.Drawing.Point(0, 28);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(949, 624);
            this.panelForm.TabIndex = 1;
            // 
            // khácToolStripMenuItem
            // 
            this.khácToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmChứcVụChoNhânViênToolStripMenuItem});
            this.khácToolStripMenuItem.Name = "khácToolStripMenuItem";
            this.khácToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.khácToolStripMenuItem.Text = "Khác";
            // 
            // thêmChứcVụChoNhânViênToolStripMenuItem
            // 
            this.thêmChứcVụChoNhânViênToolStripMenuItem.Name = "thêmChứcVụChoNhânViênToolStripMenuItem";
            this.thêmChứcVụChoNhânViênToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.thêmChứcVụChoNhânViênToolStripMenuItem.Text = "Chức vụ nhân viên";
            this.thêmChứcVụChoNhânViênToolStripMenuItem.Click += new System.EventHandler(this.thêmChứcVụChoNhânViênToolStripMenuItem_Click);
            // 
            // MenuMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 649);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.DarkRed;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuMain";
            this.Text = "Quản lý nhân sự - phòng ban";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnQuanLy;
        private System.Windows.Forms.ToolStripMenuItem mnPhongBan;
        private System.Windows.Forms.ToolStripMenuItem mnNhanVien;
        private System.Windows.Forms.ToolStripMenuItem mnChucVu;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.ToolStripMenuItem khácToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmChứcVụChoNhânViênToolStripMenuItem;
    }
}

