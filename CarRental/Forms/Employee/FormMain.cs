using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Coderstation.Window;
using System.Dynamic;

namespace CarRental
{
    public partial class FormMain : Form
    {

        static FormMain _obj;

        public static FormMain Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new FormMain();
                }
                return _obj;
            }
        }

        public Panel PnlContainer
        {
            get { return PanelContainer; }
            set { PanelContainer = value; }
        }

        private void LblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            _obj = this;
            Home home = new Home
            {
                Dock = DockStyle.Fill
            };
            PanelContainer.Controls.Add(home);
        }

        private void BtnCars_Click(object sender, EventArgs e)
        {
            if (!Instance.PnlContainer.Controls.ContainsKey("CarProfiles"))
            {
                CarProfiles cars = new CarProfiles
                {
                    Dock = DockStyle.Fill
                };
                Instance.PnlContainer.Controls.Add(cars);
            }
            Instance.PnlContainer.Controls["CarProfiles"].BringToFront();
        }
    

    private void BtnClient_Click(object sender, EventArgs e)
    {
        if (!Instance.PnlContainer.Controls.ContainsKey("Clients"))
        {
            Clients clients = new Clients
            {
                Dock = DockStyle.Fill
            };
            Instance.PnlContainer.Controls.Add(clients);
        }
        Instance.PnlContainer.Controls["Clients"].BringToFront();
    }

    private void BntRental_Click(object sender, EventArgs e)
    {
        if (!Instance.PnlContainer.Controls.ContainsKey("Rental"))
        {
            Rental rental = new Rental
            {
                Dock = DockStyle.Fill
            };
            Instance.PnlContainer.Controls.Add(rental);
        }
        Instance.PnlContainer.Controls["Rental"].BringToFront();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Login login = new Login();
        login.Show();
        this.Close();
    }

        private void LblExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
