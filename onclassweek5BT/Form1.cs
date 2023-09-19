using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace onclassweek5BT
{
    public partial class Form1 : Form
    {

        List<Student> students = new List<Student>();

        public Form1()
        {
            InitializeComponent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.MdiParent = this;
            f2.TopMost = true;
            f2.Dock = DockStyle.Right;
            List<Student> students;
            f2.Show();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.MdiParent = this;
            f2.TopMost = true;
            f2.Dock = DockStyle.Right;
            List<Student> students;
            f2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rdm = new Random();

            {
                for (int i = 0; i < 10; i++)
                {
                    Double DTB = rdm.NextDouble() * 10;
                    String khoa;
                    if (rdm.Next(0, 4) == 1) khoa = "CNTT";
                    else if (rdm.Next(0, 4) == 2) khoa = "QTKD";
                    else khoa = "NNA";
                    students.Add(new Student { MSSV = $"{i + 1}", HoTen = $"SinhVien{i + 1}", DTB = DTB = Math.Round(DTB, 2), Khoa = khoa });
                }
            }
            var source = new BindingSource(students, null);

            dgvData.DataSource = source;

            
        }
        public void SetDataFromForm2(string dataMSSV, string dataHoTen, string dataDTB, string dataKhoa)
        {
            
            // Process the data from Form2 here
            // Set the data in a control on Form1
            students.Add(new Student() { MSSV = dataMSSV, HoTen = dataHoTen, DTB = Convert.ToDouble(dataDTB), Khoa = dataKhoa });
            var source = new BindingSource(students, null);
            dgvData.DataSource = source;

        }
        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void tstbFind_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tstbFind_Enter(object sender, EventArgs e)
        {
            //string filterText = tstbFind.Text.Trim();

            //foreach (DataGridViewRow row in dgvData.Rows.Cast<DataGridViewRow>())
            //{
            //    string cellValue = row.Cells["HoTen"].Value.ToString();
            //    bool isTrue = Convert.ToBoolean(row.Cells["IsTrue"].Value);

            //    // Check if the cell value matches the filter text and IsTrue is true
            //    if (cellValue.Equals(filterText, StringComparison.OrdinalIgnoreCase) && isTrue)
            //    {
            //        row.Visible = true; // Show the row
            //    }
            //    else
            //    {
            //        row.Visible = false; // Hide the row
            //    }
            //}
        }

        private void tslFind_Click(object sender, EventArgs e)
        {
            //DataView view = dgvData.DefaultView;
            //view.Sort = "day ASC, status DESC";
            //bindingSource1.DataSource = view;
        }
    }
}
