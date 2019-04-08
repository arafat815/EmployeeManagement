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
    public partial class View_Employee : Form
    {
        public Operations opr = new Operations();
        public Informations info = new Informations();
        public View_Employee()
        {
            InitializeComponent();
        }

        private void View_Employee_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = opr.viewEmployee(info);
            DgvEmp.DataSource = dt;
            DgvEmp.Columns[0].Visible = false;
            DgvEmp.Columns[6].Visible = false;
            DgvEmp.Columns[7].Visible = false;
        }
    }
}
