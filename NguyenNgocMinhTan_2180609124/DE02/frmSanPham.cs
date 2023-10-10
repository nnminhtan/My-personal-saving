using DE02.DAL.Entities;
using DE02.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;
using System.Runtime.Remoting.Contexts;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.Entity;
using Database = DE02.DAL.Entities.Database;

namespace DE02
{
    public partial class frmSanPham : Form
    {
        Database db = new Database();
        private readonly SanPhamService sanPhamService = new SanPhamService(); 
        private readonly LoaiSPService loaiSPService = new LoaiSPService();
        public int CountRow;

        public int OriginalRow;
        public frmSanPham()
        {
            InitializeComponent();
        }
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            try
            {
                var listSanPham = sanPhamService.GetAll();
                var listLoaiSP = loaiSPService.GetAll();
                BindList(listSanPham);
                fillCboLoaiSP(listLoaiSP);
                OriginalRow = lvSanPham.Items.Count;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void fillCboLoaiSP(List<LoaiSP> listLoaiSP)
        {
            this.cboLoaiSP.DataSource = listLoaiSP;
            this.cboLoaiSP.DisplayMember = "TenLoai";
            this.cboLoaiSP.ValueMember = "MaLoai";
        }
        private void BindList(List<SanPham> listSanPham)
        {
            // Bind the ListView control to the list of students.
            lvSanPham.Items.Clear();
            foreach (SanPham sp in listSanPham)
            {
                ListViewItem item = new ListViewItem();
                item.Text = sp.MaSP;
                item.SubItems.Add(new ListViewSubItem(item, sp.TenSP));
                item.SubItems.Add(new ListViewSubItem(item, sp.NgayNhap.ToString()));
                item.SubItems.Add(new ListViewSubItem(item, sp.LoaiSP?.TenLoai));
                lvSanPham.Items.Add(item);
            }
        }

        private void lvSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSanPham.SelectedItems.Count > 0)
            {
                // Get the selected item in the ListView.
                ListViewItem item = lvSanPham.SelectedItems[0];

                // Get the data from the selected item.
                string maSV = item.Text;
                string hoTenSV = item.SubItems[1].Text;
                DateTime ngaySinh;
                string tenLop = item.SubItems[3].Text;

                // Set the values of the TextBox, DateTimePicker and ComboBox.
                txtMaSP.Text = maSV;
                txtTenSP.Text = hoTenSV;
                if (DateTime.TryParse(item.SubItems[2].Text.ToString(), out ngaySinh))
                {
                    dtNgayNhap.Value = ngaySinh;
                }
                cboLoaiSP.Text = tenLop;
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem(txtMaSP.Text);
            item.SubItems.Add(txtTenSP.Text);
            item.SubItems.Add(dtNgayNhap.Value.ToString());
            item.SubItems.Add(cboLoaiSP.Text);
            lvSanPham.Items.Add(item);
            txtMaSP.Text = null;
            txtTenSP.Text = null;
            dtNgayNhap.Value = DateTime.Now;
            cboLoaiSP.SelectedIndex = 0;
            CountRow = lvSanPham.Items.Count;
            // Update the save button state.
            UpdateSaveandUnsaveButtonState();
        }

        //private void RefreshData()
        //{
        //    var listStudents = sanPhamService.GetAll();
        //    BindList(listStudents);
        //    lvSanPham.Update();
        //    lvSanPham.Refresh();
        //}

        private void UpdateSaveandUnsaveButtonState()
        {
            // Enable the save button only if there are any unsaved changes in the ListView.
            btLuu.Enabled = lvSanPham.Items.Count >= OriginalRow || lvSanPham.Items.Count < OriginalRow;
            btKLuu.Enabled = lvSanPham.Items.Count >= OriginalRow || lvSanPham.Items.Count < OriginalRow;
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (lvSanPham.SelectedItems.Count > 0)
            {
                ListViewItem lv = lvSanPham.SelectedItems[0];
                lv.SubItems[1].Text = txtTenSP.Text;
                lv.SubItems[2].Text = dtNgayNhap.Value.ToString();
                lv.SubItems[3].Text = cboLoaiSP.Text;
                txtMaSP.Text = null;
                txtTenSP.Text = null;
                dtNgayNhap.Value = DateTime.Now;
                cboLoaiSP.SelectedIndex = 0;
                UpdateSaveandUnsaveButtonState();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                    "Do you want to delete this?",
                    "Title",
                    MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if (lvSanPham.SelectedItems.Count > 0)
                {
                    // Get the selected item(s)
                    ListViewItem selectedItem = lvSanPham.SelectedItems[0];

                    // Remove the selected item from the ListView
                    lvSanPham.Items.Remove(selectedItem);
                }
                UpdateSaveandUnsaveButtonState();
            }
            else
            {
                return;
            }
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            List<SanPham> newSP = new List<SanPham>();

            foreach (ListViewItem item in lvSanPham.Items)
            {
                SanPham SP = new SanPham();
                SP.MaSP = item.Text;
                SP.TenSP = item.SubItems[1].Text;

                DateTime ngayNhap;
                if (DateTime.TryParse(item.SubItems[2].Text, out ngayNhap))
                {
                    SP.NgayNhap = ngayNhap;
                }
                var tenLoai = item.SubItems[3].Text;
                var maLoai = db.LoaiSP
                    .Where(loai => loai.TenLoai == tenLoai)
                    .Select(loai => loai.MaLoai)
                    .FirstOrDefault();

                if (!string.IsNullOrEmpty(maLoai))
                {
                    SP.MaLoai = maLoai;
                }

                newSP.Add(SP);
            }
            var maSPsInNewSP = newSP.Select(sp => sp.MaSP).ToList();
            // Retrieve existing entities from the database that have MaSP in the newSP list
            var existingEntities = db.SanPham.Where(s => maSPsInNewSP.Contains(s.MaSP)).ToList();

            // Update existing entities based on the newSP list
            foreach (var existingEntity in existingEntities)
            {
                var correspondingNewSP = newSP.FirstOrDefault(sp => sp.MaSP == existingEntity.MaSP);
                if (correspondingNewSP != null)
                {
                    // Update existingEntity properties with correspondingNewSP values
                    existingEntity.TenSP = correspondingNewSP.TenSP;
                    existingEntity.NgayNhap = correspondingNewSP.NgayNhap;
                    existingEntity.MaLoai = correspondingNewSP.MaLoai;
                }
            }

            var entitiesToDelete = db.SanPham.Where(s => !maSPsInNewSP.Contains(s.MaSP)).ToList();
            db.SanPham.RemoveRange(entitiesToDelete);
            var entitiesToAdd = newSP.Where(sp => !existingEntities.Any(ee => ee.MaSP == sp.MaSP)).ToList();
            db.SanPham.AddRange(entitiesToAdd);

            db.SaveChanges();
            lvSanPham.Refresh();
            //disable it
            btLuu.Enabled = false;
            btKLuu.Enabled = false;
        }

        private void btKLuu_Click(object sender, EventArgs e)
        {
            RefreshData();
            //disable it
            btKLuu.Enabled = false;
            btLuu.Enabled = false;
        }

        private void RefreshData()
        {
            var listSanPham = sanPhamService.GetAll();
            var listLoaiSP = loaiSPService.GetAll();
            BindList(listSanPham);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                    "Do you want to quit?",
                    "Title",
                    MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void btFind_Click(object sender, EventArgs e)
        {
            List<SanPham> searchStudents = new List<SanPham>();
            string name = txtFind.Text;
            foreach (ListViewItem item in lvSanPham.Items)
            {
                var ten = item.SubItems[1].Text;
                if (ten != null && ten.ToLower().Contains(name.ToLower()))
                {
                    SanPham student = new SanPham();
                    student.MaSP = item.Text;
                    student.TenSP = item.SubItems[1].Text;
                    DateTime ngaySinh;
                    if (DateTime.TryParse(item.SubItems[2].Text.ToString(), out ngaySinh))
                    {
                        dtNgayNhap.Value = ngaySinh;
                    }
                    student.NgayNhap = dtNgayNhap.Value;
                    string maSV = item.Text.ToString();
                    var maLop = sanPhamService.FindByMaSP(maSV)?.MaLoai?.ToString();
                    if (maLop != null)
                    {
                        student.MaLoai = item.SubItems[3].Text;
                    }
                    searchStudents.Add(student);
                }

            }
            if (searchStudents.Count == 0)
            {
                MessageBox.Show("khong tim thay sinh vien");
            }
            else
            {
                // Convert the list of students to an array of ListViewItem objects.
                ListViewItem[] listViewItems = ConvertStudentsToListViewItems(searchStudents);
                lvSanPham.Items.Clear();
                lvSanPham.Items.AddRange(listViewItems);
                txtFind = null;
            }
        }
        private ListViewItem[] ConvertStudentsToListViewItems(List<SanPham> students)
        {
            ListViewItem[] listViewItems = new ListViewItem[students.Count];

            for (int i = 0; i < students.Count; i++)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = students[i].MaSP;
                listViewItem.SubItems.Add(students[i].TenSP);
                listViewItem.SubItems.Add(students[i].NgayNhap.ToString());
                listViewItem.SubItems.Add(students[i].MaLoai);

                listViewItems[i] = listViewItem;
            }

            return listViewItems;
        }
    }
}
