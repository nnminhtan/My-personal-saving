using onclassweek6.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace onclassweek6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        StudentContextDB db = new StudentContextDB();

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                List<tblStudent> dssv = db.tblStudents.ToList();
                List<tblFaculty> dsk = db.tblFaculties.ToList();
                BindGird(dssv);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindGird(List<tblStudent> dssv)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in dssv)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.STUDENTID;
                dataGridView1.Rows[index].Cells[1].Value = item.FULLNAME;
                dataGridView1.Rows[index].Cells[2].Value = item.tblFaculty.FACULTYNAME;
                dataGridView1.Rows[index].Cells[3].Value = item.AVERAGESCORE;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tblStudent st = new tblStudent()
            {
                STUDENTID = txtMSSV.Text,
                FULLNAME = txtHoten.Text,
                FACULTYID = cbmKhoa.SelectedIndex + 1,
                AVERAGESCORE = Convert.ToDouble(txtDTB.Text)
            };
                db.tblStudents.Add(st);
                db.SaveChanges();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String id = (dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString());
            tblStudent st = db.tblStudents.Find(id);
            if (st != null)
            {
                st.FULLNAME = txtHoten.Text;
                string facultyName = cbmKhoa.Text;
                tblFaculty faculty = db.tblFaculties.FirstOrDefault(f => f.FACULTYNAME == facultyName);
                if (faculty != null)
                {
                    st.tblFaculty = faculty;
                }
                else
                {
                    MessageBox.Show("Selected faculty does not exist in the database.");
                }
                st.AVERAGESCORE = Convert.ToInt32(txtDTB.Text);
                db.SaveChanges();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var rowData = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
            tblStudent nv = db.tblStudents.Find(rowData);
            db.tblStudents.Remove(nv);
            db.SaveChanges();
        }

        private void btnRef_Click(object sender, EventArgs e)
        {

            //var result = dssv;
            //dataGridView1.DataSource = result;
            dataGridView1.Update();
            dataGridView1.Refresh();
        }
    }

}
