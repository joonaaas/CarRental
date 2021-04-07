using Coderstation.Window;
using System;
using System.Dynamic;
using System.Windows.Forms;

namespace CarRental
{
    public partial class CarRegistration : UserControl
    {
        Coders_FormControl MyFormControl = new Coders_FormControl();

        public CarRegistration()
        {
            InitializeComponent();
        }

        public enum CarBrand
        {
            Audi, BMW, Chevrolet, Chrysler, Ford, GMC, Nissan, Tesla, Toyota
        }

        public enum CarType
        {
            Hatchback, Sedan, MPV, SUV, Crossover
        }

        public enum CarSeater
        {
            Four, Five, Six, Seven, Eight, Nine, Ten
        }

        private void CarRegistration_Load(object sender, EventArgs e)
        {

            CmbBrand.Items.Clear();
            for (int i = 0; i <= Enum.GetNames(typeof(CarBrand)).Length - 1; i++)
            {
                CmbBrand.Items.Add(Enum.GetNames(typeof(CarBrand))[i].Replace("_", " "));
            }

            CmbType.Items.Clear();
            for (int i = 0; i <= Enum.GetNames(typeof(CarType)).Length - 1; i++)
            {
                CmbType.Items.Add(Enum.GetNames(typeof(CarType))[i].Replace("_", " "));
            }

            CmbSeater.Items.Clear();
            for (int i = 0; i <= Enum.GetNames(typeof(CarSeater)).Length - 1; i++)
            {
                CmbSeater.Items.Add(Enum.GetNames(typeof(CarSeater))[i].Replace("_", " "));
            }

        }

        private void CMDSave_Click_1(object sender, EventArgs e)
        {
            if (TxtCarId.Text != "" && TxtPlateNo.Text != "")
            {

                DialogResult dialogResult = MessageBox.Show("Car Record Management System." +
                    Environment.NewLine + "Confirm Save?" + Environment.NewLine + Environment.NewLine +
                        "Click [OK] to continue...", "Save Record", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.OK)
                {
                    dynamic CarProfile = new ExpandoObject();
                    Car MyCar = new Car();

                    CarProfile.CarID = TxtCarId.Text;
                    CarProfile.Rate = TxtRate.Text;
                    CarProfile.Brand = CmbBrand.Text;
                    CarProfile.Model = TxtModel.Text;
                    CarProfile.PlateNo = TxtPlateNo.Text;
                    CarProfile.Type = CmbType.Text;
                    CarProfile.Seater = CmbSeater.Text;

                    CarProfile.Process = "UpdateCarsProfile";

                    String _Status = (String) MyCar.Update(CarProfile).Result;
                    MessageBox.Show(_Status);
                }

            }
        }

        public void LoadRecord(String _CarID)
        {
            Car MyProfile = new Car();
            dynamic CarProfile = (ExpandoObject) MyProfile.Search(_CarID).Result;

            if ((String) CarProfile.Status == "Record_Found")
            {
                TxtCarId.Text = (String) CarProfile.Record.CarID;
                TxtRate.Text = (String) CarProfile.Record.Rate;
                CmbBrand.Text = (String) CarProfile.Record.Brand;
                TxtModel.Text = (String) CarProfile.Record.Model;
                TxtPlateNo.Text = (String) CarProfile.Record.PlateNo;
                CmbType.Text = (String) CarProfile.Record.Type;
                CmbSeater.Text = (String) CarProfile.Record.Seater;
            }

            else
            {
                MyFormControl.CleareAllControlsRecursive(this);
                MessageBox.Show((String) CarProfile.Status + Environment.NewLine + Environment.NewLine + "No Record Found");
            }

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            this.LoadRecord(TxtSearch.Text);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            MyFormControl.CleareAllControlsRecursive(this);
            TxtCarId.Focus();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Car MyCar = new Car();

            if (TxtCarId.Text != "" && TxtPlateNo.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Car Record Management System." +
                    Environment.NewLine + "Remove the current Record?" + Environment.NewLine + Environment.NewLine +
                        "Click [OK] to continue...", "Remove Record", MessageBoxButtons.OKCancel,
                                                                                                MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.OK)
                {
                    dynamic MyProfile = MyCar.Delete(TxtCarId.Text).Result;
                    int RecordCountDeleted = Convert.ToInt32(MyProfile.RecordCountDeleted);

                    if (RecordCountDeleted >= 1)
                    {
                        MyFormControl.CleareAllControlsRecursive(this);
                        TxtCarId.Focus();
                    }
                    MessageBox.Show(MyProfile.Status + Environment.NewLine + "Record Count Deleted :"
                        + MyProfile.RecordCountDeleted, "Remove Current Record..");
                }
            }
        }



    }
}
