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
    public partial class TransactionReport : UserControl
    {
        public TransactionReport()
        {
            InitializeComponent();
        }

        dynamic JsonProfile = new ExpandoObject();
        Rents MyRent = new Rents();

        private void RentData()
        {
            Rents MyRent = new Rents();
            dynamic JsonProfile = MyRent.LoadTransactionList().Result;

            DataGrid.Rows.Clear();
            DataGrid.RowCount = JsonProfile.Record.Count;

            for (int i = 0; i < JsonProfile.Record.Count; i++)
            {
                DataGrid.Rows[i].Cells[0].Value = JsonProfile.Record[i].RentID;
                DataGrid.Rows[i].Cells[1].Value = JsonProfile.Record[i].RentDate;
                DataGrid.Rows[i].Cells[2].Value = JsonProfile.Record[i].IsReturn;
                DataGrid.Rows[i].Cells[3].Value = JsonProfile.Record[i].ClientName;
                DataGrid.Rows[i].Cells[4].Value = JsonProfile.Record[i].CarBrand;
                DataGrid.Rows[i].Cells[5].Value = JsonProfile.Record[i].CarModel;
                DataGrid.Rows[i].Cells[6].Value = JsonProfile.Record[i].TotalCost;
                DataGrid.Rows[i].Cells[7].Value = JsonProfile.Record[i].NoofDays;
            }

        }

        private void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (MyRent.PageStop == false)
            {
                MyRent.PrintRentList(JsonProfile, e);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            DataGrid.Rows.Clear();
            RentData();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            JsonProfile = MyRent.LoadTransactionList().Result;
            MyRent = new Rents();
            Print_Dialog.Document = PrintDoc;
            // Print_Dialog.WindowState = FormWindowState.Maximized;
            Print_Dialog.Width = 1000;
            Print_Dialog.Height = 500;
            Print_Dialog.Text = "Transactions";
            Print_Dialog.StartPosition = FormStartPosition.CenterScreen;
            Print_Dialog.ShowDialog();
        }

        private void TransactionReport_Load(object sender, EventArgs e)
        {
            RentData();
        }

    }
}
