using Coderstation.Window;
using System;
using System.Dynamic;
using System.Windows.Forms;

namespace CarRental
{

    public partial class NewRent : Form
    {

        Coders_FormControl MyFormControl = new Coders_FormControl();

        public NewRent()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Rent Record Management System." +
                Environment.NewLine + "Confirm Transaction?" + Environment.NewLine + Environment.NewLine +
                    "Click [OK] to continue...", "Save Record", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.OK)
            {
                dynamic RentProfile = new ExpandoObject();
                Rents MyRent = new Rents();

                RentProfile.RentID = TxtRentID.Text;
                RentProfile.ClientID = TxtClientID.Text;
                RentProfile.CarID = TxtCarID.Text;
                RentProfile.ClientName = TxtName.Text;
                RentProfile.CarModel = TxtModel.Text;
                RentProfile.CarBrand = TxtBrand.Text;
                RentProfile.CarRate = TxtRate.Text;
                RentProfile.RentDate = DateRent.Value.ToString();
                RentProfile.RentFee = TxtRentFee.Text;
                RentProfile.InsuranceFee = TxtInsuranceFee.Text;
                RentProfile.TotalCost = TxtTotalCost.Text;
                RentProfile.NoofDays = TxtNoofDays.Text;
                RentProfile.IsReturn = "False";
                RentProfile.Process = "UpdateRentsProfile";

                String _Status = (String) MyRent.Update(RentProfile).Result;
                MessageBox.Show(_Status);
            }

        }

        public void LoadClientRecord(String _ClientId)
        {

            Rents MyProfile = new Rents();
            dynamic ClientProfile = (ExpandoObject) MyProfile.SearchClient(_ClientId).Result;

            if ((String) ClientProfile.Status == "Record_Found")
            {
                TxtClientID.Text = (String) ClientProfile.Record.ClientID;
                string firstName = (String) ClientProfile.Record.FirstName;
                string middleName = (String) ClientProfile.Record.MiddleName;
                string lastName = (String) ClientProfile.Record.LastName;
                TxtName.Text = firstName + " " + middleName + " " + lastName;
                TxtContactNo.Text = (String) ClientProfile.Record.ContactNo;
                TxtLicenseNo.Text = (String) ClientProfile.Record.LicenseNo;
                TxtAddress.Text = (String) ClientProfile.Record.Address;

            }

            else
            {
                MyFormControl.CleareAllControlsRecursive(this);
                MessageBox.Show((String) ClientProfile.Status + Environment.NewLine + Environment.NewLine + "No Record Found");
            }

        }

        private void BtnClientSearch_Click(object sender, EventArgs e)
        {
            this.LoadClientRecord(TxtClientID.Text);
        }

        public void LoadCarRecord(String _CarID)
        {

            Rents MyProfile = new Rents();
            dynamic CarProfile = (ExpandoObject) MyProfile.SearchCar(_CarID).Result;

            if ((String) CarProfile.Status == "Record_Found")
            {
                TxtCarID.Text = (String) CarProfile.Record.CarID;
                TxtRate.Text = (String) CarProfile.Record.Rate;
                TxtPlateNo.Text = (String) CarProfile.Record.PlateNo;
                TxtBrand.Text = (String) CarProfile.Record.Brand;
                TxtModel.Text = (String) CarProfile.Record.Model;
                TxtType.Text = (String) CarProfile.Record.Type;
                TxtSeater.Text = (String) CarProfile.Record.Seater;
            }

            else
            {
                MyFormControl.CleareAllControlsRecursive(this);
                MessageBox.Show((String) CarProfile.Status + Environment.NewLine + Environment.NewLine + "No Record Found");
            }

        }

        private void BtnCarSearch_Click(object sender, EventArgs e)
        {
            this.LoadCarRecord(TxtCarID.Text);
        }

        private void Cost()
        {
            Rents MyRent = new Rents();
            try
            {
                int noOfDays = Convert.ToInt32(TxtNoofDays.Text);
                int rentFee = Convert.ToInt32(TxtRentFee.Text);
                int insuranceFee = Convert.ToInt32(TxtInsuranceFee.Text);
                int carRate = Convert.ToInt32(TxtRate.Text);

                int total = MyRent.TotalCost(noOfDays, rentFee, insuranceFee, carRate);
                TxtTotalCost.Text = total.ToString();
            }
            catch (Exception)
            {

            }

        }

        private void TxtNoofDays_Enter(object sender, EventArgs e)
        {
            Cost();
        }

        private void TxtRentFee_Enter(object sender, EventArgs e)
        {
            Cost();
        }

        private void TxtInsuranceFee_Enter(object sender, EventArgs e)
        {
            Cost();
        }

    }
}
