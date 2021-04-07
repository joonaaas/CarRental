using Coderstation.Window;
using System;
using System.Dynamic;
using System.Windows.Forms;

namespace CarRental
{
    public partial class ReturnRent : Form
    {

        Coders_FormControl MyFormControl = new Coders_FormControl();

        public ReturnRent()
        {
            InitializeComponent();
        }

        public void LoadRentRecord(String _RentID)
        {

            Rents MyProfile = new Rents();
            dynamic RentProfile = (ExpandoObject) MyProfile.SearchRent(_RentID).Result;

            if ((String) RentProfile.Status == "Record_Found")
            {
                TxtRentID.Text = (String) RentProfile.Record.RentID;
                TxtClientID.Text = (String) RentProfile.Record.ClientID;
                TxtCarID.Text = (String) RentProfile.Record.CarID;
                TxtRentDate.Text = (String) RentProfile.Record.RentDate;
                TxtClientName.Text = (String) RentProfile.Record.ClientName;
                TxtCarModel.Text = (String) RentProfile.Record.CarModel;
                TxtCarBrand.Text = (String) RentProfile.Record.CarBrand;
                TxtCarRate.Text = (String) RentProfile.Record.CarRate;
                TxtInsuranceFee.Text = (String) RentProfile.Record.InsuranceFee;
                TxtRentFee.Text = (String) RentProfile.Record.RentFee;
                TxtTotalCost.Text = (String) RentProfile.Record.TotalCost;
                TxtNoofDays.Text = (String) RentProfile.Record.NoofDays;
                TxtIsReturn.Text = (String) RentProfile.Record.IsReturn;
            }
            else
            {
                MyFormControl.CleareAllControlsRecursive(this);
                MessageBox.Show((String) RentProfile.Status + Environment.NewLine + Environment.NewLine + "No Record Found");
            }

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadRentRecord(TxtRentID.Text);
        }

        private void BtnConfirmReturn_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Car Record Management System." +
                Environment.NewLine + "Confirm Return?" + Environment.NewLine + Environment.NewLine +
                    "Click [OK] to continue...", "Save Record", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.OK)
            {
                dynamic RentProfile = new ExpandoObject();
                Rents MyRent = new Rents();

                RentProfile.RentID = TxtRentID.Text;
                RentProfile.ClientID = TxtClientID.Text;
                RentProfile.CarID = TxtCarID.Text;
                RentProfile.ClientName = TxtClientName.Text;
                RentProfile.CarModel = TxtCarModel.Text;
                RentProfile.CarBrand = TxtCarBrand.Text;
                RentProfile.CarRate = TxtCarRate.Text;
                RentProfile.RentDate = TxtRentDate.Text;
                RentProfile.RentFee = TxtRentFee.Text;
                RentProfile.InsuranceFee = TxtInsuranceFee.Text;
                RentProfile.TotalCost = TxtTotalCost.Text;
                RentProfile.NoofDays = TxtNoofDays.Text;
                RentProfile.IsReturn = "True";
                RentProfile.Process = "UpdateRentsProfile";

                String _Status = (String) MyRent.Update(RentProfile).Result;
                MessageBox.Show(_Status);
            }

        }
    }
}
