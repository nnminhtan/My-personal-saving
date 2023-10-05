using Lab05.BUS;
using Lab05.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week7
{
    public partial class frmdkcn : Form
    {
        private readonly StudentService studentService = new StudentService();
        private readonly FacultyService facultyService = new FacultyService();
        private readonly MajorService majorService = new MajorService();
        Database db = new Database();

        public frmdkcn()
        {
            InitializeComponent();
        }

        private void dkcn_Load(object sender, EventArgs e)
        {
            try
            {
                var listFacultys = facultyService.GetAll();
                FillFacultyCombobox(listFacultys);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillFacultyCombobox(List<tblFaculty> listFacultys)
        {
            this.cbbKhoa.DataSource = listFacultys;
            this.cbbKhoa.DisplayMember = "FACULTYNAME";
            this.cbbKhoa.ValueMember = "FACULTYID";
        }

        private void cbbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            tblFaculty seletedFaculty = cbbKhoa.SelectedItem as tblFaculty;
            if(seletedFaculty != null)
            {
                var listMajor = majorService.GetAllByFaculty(seletedFaculty.FACULTYID);
                FillMajorCombobox(listMajor);
                var listStudents = studentService.GetAllHasNoMajor(seletedFaculty.FACULTYID);
                BindGrid(listStudents);
            }
        }

        private void BindGrid(List<tblStudent> listStudents)
        {
            dgvData.Rows.Clear();
            foreach (var item in listStudents) 
            {
                int index = dgvData.Rows.Add();
                dgvData.Rows[index].Cells[1].Value = item.STUDENTID;
                dgvData.Rows[index].Cells[2].Value = item.FULLNAME;
                if(item.tblFaculty != null)
                    dgvData.Rows[index].Cells[3].Value = item.tblFaculty.FACULTYNAME;
                dgvData.Rows[index].Cells[4].Value = item.AVERAGESCORE;
                if(item.MAJORID != null)
                dgvData.Rows[index].Cells[5].Value = item.tblMajor.MAJORNAME;
            }
        }

        private void FillMajorCombobox(List<tblMajor> listMajor)
        {
            this.cbbCN.DataSource = listMajor;
            this.cbbCN.DisplayMember = "MAJORNAME";
            this.cbbCN.ValueMember = "MAJORID";
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells[0] as DataGridViewCheckBoxCell;
                if (checkBoxCell.Value != null)
                {
                    bool isChecked = Convert.ToBoolean(checkBoxCell.Value);
                    string studentID = dgvData.CurrentRow.Cells[1].Value.ToString(); // Adjust column name as needed
                    string cn = cbbCN.SelectedValue != null ? cbbCN.SelectedValue.ToString() : null;
                    // Find the student in the list by StudentID
                    if (studentService.FindById(studentID) != null)
                    {
                        if (isChecked)
                        {
                            // Update the MajorName property of the selected tblStudent's tblMajor object
                            tblStudent st = studentService.FindById(studentID);
                            st.MAJORID = Convert.ToInt32(cn);
                            studentService.InsertUpdate(st);
                        }
                    }
                }
            }
        }
    }
}
