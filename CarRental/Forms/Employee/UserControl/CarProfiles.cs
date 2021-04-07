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
    public partial class CarProfiles : UserControl
    {
        public CarProfiles()
        {
            InitializeComponent();
        }

        dynamic JsonProfile = new ExpandoObject();
        Car MyCar = new Car();

        private void CarData()
        {
            Car MyCar = new Car();
            dynamic JsonProfile = MyCar.LoadCarList().Result;

            DataGrid.Rows.Clear();
            DataGrid.RowCount = JsonProfile.Record.Count;

            for (int i = 0; i < JsonProfile.Record.Count; i++)
            {
                DataGrid.Rows[i].Cells[0].Value = JsonProfile.Record[i].CarID;
                DataGrid.Rows[i].Cells[1].Value = JsonProfile.Record[i].Brand;
                DataGrid.Rows[i].Cells[2].Value = JsonProfile.Record[i].Model;
                DataGrid.Rows[i].Cells[3].Value = JsonProfile.Record[i].PlateNo;
                DataGrid.Rows[i].Cells[4].Value = JsonProfile.Record[i].Type;
                DataGrid.Rows[i].Cells[5].Value = JsonProfile.Record[i].Seater;
                DataGrid.Rows[i].Cells[6].Value = JsonProfile.Record[i].Rate;
            }
        }

        private void CarProfiles_Load(object sender, EventArgs e)
        {
            CarData();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            DataGrid.Rows.Clear();
            CarData();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            JsonProfile = MyCar.LoadCarList().Result;
            MyCar = new Car();
            Print_Dialog.Document = PrintDoc;
            // Print_Dialog.WindowState = FormWindowState.Maximized;
            Print_Dialog.Width = 1000;
            Print_Dialog.Height = 500;
            Print_Dialog.Text = "Car Profile";
            Print_Dialog.StartPosition = FormStartPosition.CenterScreen;
            Print_Dialog.ShowDialog();
        }

        private void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (MyCar.PageStop == false)
            {
                MyCar.PrintCarList(JsonProfile, e);
            }
        }


    }
}
