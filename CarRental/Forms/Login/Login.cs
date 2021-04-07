using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private enum Users
        {
            Employee, Admin
        }

        private void Login_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= Enum.GetNames(typeof(Users)).Length - 1; i++)
            {
                CmbUser.Items.Add(Enum.GetNames(typeof(Users))[i].Replace("_", " "));
            }
        }

        private void Login_Check(string _User, string _Pass)
        {
            Accounts account = new Accounts();

            if (CmbUser.Text == "Employee")
            {
                if (_User == account.EmployeeUser && _Pass == account.EmployeePass)
                {
                    FormMain formMain = new FormMain();
                    formMain.Show();
                    this.Hide();
                }
            }
            else if (CmbUser.Text == "Admin")
            {
                if (_User == account.AdminUser && _Pass == account.AdminPass)
                {
                    MainAdmin form = new MainAdmin();
                    form.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Error Either User or Password");
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Login_Check(TxtUserName.Text, TxtPassword.Text);
        }

        private void LblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
