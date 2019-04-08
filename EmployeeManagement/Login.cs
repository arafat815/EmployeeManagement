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
    public partial class Login : Form
    {
        public Informations info = new Informations();
        public Operations opr = new Operations();
        public string utype;
        DataTable dt = new DataTable();
        public Login()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            info.username = tbUn.Text;
            info.password = tbPass.Text;
            dt = opr.login(info);
            if(dt.Rows.Count>0)
            {
                utype = dt.Rows[0][7].ToString();
                if(utype=="A")
                {
                    Admin a = new Admin();
                    a.Show();
                }
                else
                {
                    Employee em = new Employee();
                    em.Show();
                }
                
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}
