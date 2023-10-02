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
                cbmKhoa.SelectedIndex = 0;
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
            try
            {
                if (txtMSSV.Text == "" || txtHoten.Text == "" || txtDTB.Text == "")
                    throw new Exception("vui long nhap day du thong tin sinh vien");
                if (txtMSSV.Text.Length != 10)
                    throw new Exception("ma sinh vien phai du 10 ki tu ");
                long max;
                if (checkIDsv(txtMSSV.Text) == -1)//-1 la sinh vien moi
                {
                    if (double.Parse(this.txtDTB.Text) >= 0 && double.Parse(this.txtDTB.Text) <= 10)
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
                        refresh();
                    }
                    else
                    {
                        MessageBox.Show("chi nhap so tu 1-10");
                        txtDTB.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private int checkIDsv(string newidsv)
        {
            int length = dataGridView1.Rows.Count;
            for (int i = 0; i < length; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null)
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == newidsv)
                        return i;
            }
            return -1;//khong tim thay
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
                    MessageBox.Show("Khoa ban chon khong nam trong database.");
                }
                st.AVERAGESCORE = Convert.ToInt32(txtDTB.Text);
                MessageBox.Show($"sua sinh vien {st.STUDENTID} thanh cong", "thong bao ", MessageBoxButtons.OK);
                db.SaveChanges();
                refresh();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var rowData = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
            tblStudent st = db.tblStudents.Find(rowData);
            DialogResult result = MessageBox.Show($"ban co dong y xoa sinh vien{st.FULLNAME}", "thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                db.tblStudents.Remove(st);
                MessageBox.Show($"xoa sinh vien {st.FULLNAME}thanh cong", "thong bao ", MessageBoxButtons.OK);

                db.SaveChanges();
                refresh();
            }
        }

        private void refresh(){
            List<tblStudent> dssv = db.tblStudents.ToList();
            BindGird(dssv);
            //var result = dssv;
            //dataGridView1.DataSource = result;
            dataGridView1.Update();
            dataGridView1.Refresh();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                txtMSSV.Text = row.Cells["Column1"].Value.ToString();
                txtHoten.Text = row.Cells["Column2"].Value.ToString();
                cbmKhoa.SelectedItem = row.Cells["Column4"].Value.ToString();
                txtDTB.Text = row.Cells["Column3"].Value.ToString();
            }
        }
    }

}
