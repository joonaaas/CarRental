using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Coderstation.DataGridControl;
using System.Dynamic;

namespace CarRental
{
    public partial class ClientReport : UserControl
    {
        public ClientReport()
        {
            InitializeComponent();
        }

        dynamic JsonProfile = new ExpandoObject();
        Client MyClient = new Client();

        private void ClientData()
        {
            Client MyClient = new Client();
            dynamic JsonProfile = MyClient.LoadClientList().Result;

            DataGrid.Rows.Clear();
            DataGrid.RowCount = JsonProfile.Record.Count;

            for (int i = 0; i < JsonProfile.Record.Count; i++)
            {
                DataGrid.Rows[i].Cells[0].Value = JsonProfile.Record[i].ClientID;
                DataGrid.Rows[i].Cells[1].Value = JsonProfile.Record[i].FirstName;
                DataGrid.Rows[i].Cells[2].Value = JsonProfile.Record[i].MiddleName;
                DataGrid.Rows[i].Cells[3].Value = JsonProfile.Record[i].LastName;
                DataGrid.Rows[i].Cells[4].Value = JsonProfile.Record[i].ContactNo;
                DataGrid.Rows[i].Cells[5].Value = JsonProfile.Record[i].LicenseNo;
                DataGrid.Rows[i].Cells[6].Value = JsonProfile.Record[i].Birthdate;
                DataGrid.Rows[i].Cells[7].Value = JsonProfile.Record[i].Address;
            }

        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            DataGrid.Rows.Clear();
            ClientData();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            JsonProfile = MyClient.LoadClientList().Result;
            MyClient = new Client();
            Print_Dialog.Document = PrintDoc;
            // Print_Dialog.WindowState = FormWindowState.Maximized;
            Print_Dialog.Width = 1000;
            Print_Dialog.Height = 500;
            Print_Dialog.Text = "Client Profile";
            Print_Dialog.StartPosition = FormStartPosition.CenterScreen;
            Print_Dialog.ShowDialog();
        }

        private void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (MyClient.PageStop == false)
            {
                MyClient.PrintClientList(JsonProfile, e);
            }
        }

        private void ClientReport_Load(object sender, EventArgs e)
        {
            ClientData();
        }

    }
}
