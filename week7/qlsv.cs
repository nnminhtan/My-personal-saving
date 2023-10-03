using Lab05.BUS;
using Lab05.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week7
{
    public partial class frmqlsv : Form
    {
        private readonly StudentService studentService = new StudentService();
        private readonly FacultyService facultyService = new FacultyService();

        public frmqlsv()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try {
                var listFacultys = facultyService.GetAll();
                var listStudents = studentService.GetAll();
                FillFacultyComboBox(listFacultys);
                BindGrid(listStudents);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindGrid(List<tblStudent> listStudents)
        {
            dgvData.Rows.Clear();
            foreach (var item in listStudents)
            {
                int index = dgvData.Rows.Add();
                dgvData.Rows[index].Cells[0].Value = item.STUDENTID;
                dgvData.Rows[index].Cells[1].Value = item.FULLNAME;
                if(item.FACULTYID != null)
                    dgvData.Rows[index].Cells[2].Value = item.tblFaculty.FACULTYNAME;
                dgvData.Rows[index].Cells[3].Value = item.AVERAGESCORE;
                if(item.MAJORID != null)
                dgvData.Rows[index].Cells[4].Value = item.tblMajor.MAJORNAME;
                ShowAvatar(item.AVATAR);
            }
        }

        private void FillFacultyComboBox(List<tblFaculty> listFacultys)
        {
            //listFacultys.Insert(0, new tblFaculty());
            this.cbmKhoa.DataSource = listFacultys;
            this.cbmKhoa.DisplayMember = "FACULTYNAME";
            this.cbmKhoa.ValueMember = "FACULTYID";
        }

        public void RefreshData()
        {
            var listStudents = studentService.GetAll();
            BindGrid(listStudents);
            dgvData.Update();
            dgvData.Refresh();
        }
        private void ckbCN_CheckedChanged(object sender, EventArgs e)
        {
            var ListStudents = new List<tblStudent>();
            if (this.ckbCN.Checked)
                ListStudents = studentService.GetAllHasNoMajor();
            else ListStudents = studentService.GetAll();
            BindGrid(ListStudents);
        }
        private void ShowAvatar(string aVATAR)
        {
            if (string.IsNullOrEmpty(aVATAR))
            {
                ptbAvatar.Image = null;
            }
            else
            {
                string parentDirectory = Directory.GetParent(
                    AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string imagePath = Path.Combine(parentDirectory, "Resources", aVATAR);
                ptbAvatar.Image = Image.FromFile(imagePath);
                ptbAvatar.Refresh();
            }
        }

        private void btnCN_Click(object sender, EventArgs e)
        {
            frmdkcn dkcn = new frmdkcn();
            dkcn.Show();
            RefreshData();
        }

        private void btnAddorUpdate_Click(object sender, EventArgs e)
        {
            if (studentService.FindById(txtMSSV.Text) == null) {
                tblStudent s = new tblStudent()
                {
                    STUDENTID = txtMSSV.Text,
                    FULLNAME = txtHoTen.Text,
                    FACULTYID = cbmKhoa.SelectedIndex + 1,
                    AVERAGESCORE = double.Parse(txtDTB.Text),
                    MAJORID = null,
                    AVATAR = $"{LoadImage()}"
                };
                studentService.InsertUpdate(s);
                RefreshData();
            }
            else
            {
                tblStudent s = new tblStudent()
                {
                    STUDENTID = txtMSSV.Text,
                    FULLNAME = txtHoTen.Text,
                    FACULTYID = cbmKhoa.SelectedIndex + 1,
                    AVERAGESCORE = double.Parse(txtDTB.Text),
                    MAJORID = studentService.FindById(txtMSSV.Text).MAJORID,
                    AVATAR = $"{LoadImage()}"
                };
                studentService.InsertUpdate(s);
                RefreshData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Database context = new Database();
            var rowData = dgvData.SelectedRows[0].Cells["MSSV"].Value.ToString();
            tblStudent s = context.tblStudents.Find(rowData);
            context.tblStudents.Remove(s);
            context.SaveChanges();
            MessageBox.Show("Xoa thanh cong");
            RefreshData();
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {   
                DataGridViewRow row = dgvData.SelectedRows[0];
                string studentID = row.Cells["MSSV"].Value.ToString();
                tblStudent st = studentService.FindById(studentID);
                ShowAvatar(st.AVATAR);
            }
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            string selectedFilePath = LoadImage();

            if (selectedFilePath != null)
            {
                ShowAvatar(selectedFilePath);
            }
        }
        private string LoadImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set initial directory and filter for image files
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                return selectedFilePath;
            }

            // If the user canceled, return null
            return null;
        }
    }
}
