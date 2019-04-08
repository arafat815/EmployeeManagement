using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;
using BEL;

namespace EmployeeManagement
{
    public partial class Form1 : Form
    {
        public Informations info = new Informations();
        public Operations opr = new Operations();
        string gender;
        public Form1()
        {
            InitializeComponent();
        }

        private void btReg_Click(object sender, EventArgs e)
        {
            info.name = tbName.Text;
            if(rdMale.Checked==true)
            {
                gender = "Male";
            }
            if(rdFemale.Checked==true)
            {
                gender = "Female";
            }
            info.gender = gender;
            info.dob = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());
            info.address = tbAdd.Text;
            info.username = tbUN.Text;
            info.password = tbPass.Text;
            info.type = tbUserType.Text;
            int row=opr.insert(info);
            if(row>0)
            {
                MessageBox.Show("Data saved");
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            info.name = tbName.Text;
            if (rdMale.Checked == true)
            {
                gender = "Male";
            }
            if (rdFemale.Checked == true)
            {
                gender = "Female";
            }
            info.gender = gender;
            info.dob = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());
            info.address = tbAdd.Text;
            info.username = tbUN.Text;
            info.password = tbPass.Text;
            info.type = tbUserType.Text;
            int row = opr.update(info);
            if (row > 0)
            {
                MessageBox.Show("Data Updated");
            }
        }

        private void btShow_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt=opr.show(info);
            DGVreg.DataSource = dt;
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            info.name = tbName.Text;
            int row = opr.delete(info);
            if (row > 0)
            {
                MessageBox.Show("Data Deleted");
            }
        }

        private void DGVreg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.DGVreg.Rows[e.RowIndex];

                tbName.Text = row.Cells["Name"].Value.ToString();
                tbAdd.Text = row.Cells["Address"].Value.ToString();
                tbUN.Text = row.Cells["Username"].Value.ToString();
                tbPass.Text = row.Cells["Password"].Value.ToString();
                tbUserType.Text = row.Cells["Type"].Value.ToString();

            }

        }

        void populate(Informations info)
        {
            tbName.Text = info.name;
            tbAdd.Text = info.address;
            tbUN.Text = info.username;
            tbPass.Text = info.password;
            tbUserType.Text = info.type;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = opr.show(info);
            DGVreg.DataSource = dt;
            DGVreg.Columns[0].Visible = false; 
        }
  
       
    }
}
