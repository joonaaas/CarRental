using Coderstation.Window;
using System;
using System.Dynamic;
using System.Windows.Forms;

namespace CarRental
{
    public partial class Clients : UserControl
    {

        Coders_FormControl MyFormControl = new Coders_FormControl();

        public Clients()
        {
            InitializeComponent();
        }

        private void CMDSave_Click(object sender, EventArgs e)
        {
            if (TxtClientId.Text != "" && TxtFirstName.Text != "")
            {

                DialogResult dialogResult = MessageBox.Show("Client Record Management System." +
                    Environment.NewLine + "Confirm Save?" + Environment.NewLine + Environment.NewLine +
                        "Click [OK] to continue...", "Save Record", MessageBoxButtons.OKCancel,  MessageBoxIcon.Question);

                if (dialogResult == DialogResult.OK)
                {
                    dynamic ClientProfile = new ExpandoObject();
                    Client MyClient = new Client();

                    ClientProfile.ClientID = TxtClientId.Text;
                    ClientProfile.FirstName = TxtFirstName.Text;
                    ClientProfile.MiddleName = TxtMiddleName.Text;
                    ClientProfile.LastName = TxtLastName.Text;
                    ClientProfile.ContactNo = TxtContactNo.Text;
                    ClientProfile.LicenseNo = TxtLicenseNo.Text;
                    ClientProfile.Age = TxtAge.Text;
                    ClientProfile.Birthdate = DtpBirthdate.Value.ToString();
                    ClientProfile.Address = TxtAddress.Text;

                    ClientProfile.Process = "UpdateClientsProfile";

                    String _Status = (String) MyClient.Update(ClientProfile).Result;
                    MessageBox.Show(_Status);
                }
            }

        }

        public void LoadRecord(String _ClientId)
        {
            Client MyProfile = new Client();
            dynamic ClientProfile = (ExpandoObject) MyProfile.Search(_ClientId).Result;

            if ((String) ClientProfile.Status == "Record_Found")
            {
                TxtClientId.Text = (String) ClientProfile.Record.ClientID;
                TxtFirstName.Text = (String) ClientProfile.Record.FirstName;
                TxtMiddleName.Text = (String) ClientProfile.Record.MiddleName;
                TxtLastName.Text = (String) ClientProfile.Record.LastName;
                TxtContactNo.Text = (String) ClientProfile.Record.ContactNo;
                TxtLicenseNo.Text = (String) ClientProfile.Record.LicenseNo;
                TxtAge.Text = (String) ClientProfile.Record.Age;
                DtpBirthdate.Text = (String) ClientProfile.Record.Birthdate;
                TxtAddress.Text = (String) ClientProfile.Record.Address;

            }

            else
            {
                MyFormControl.CleareAllControlsRecursive(this);
                MessageBox.Show((String) ClientProfile.Status + Environment.NewLine + Environment.NewLine + "No Record Found"); 
            }
          
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            this.LoadRecord(TxtSearch.Text);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Client MyStudent = new Client();

            if (TxtClientId.Text != "" && TxtFirstName.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Client Record Management System." +
                    Environment.NewLine + "Remove the current Record?" + Environment.NewLine + Environment.NewLine +
                        "Click [OK] to continue...", "Remove Record", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.OK)
                {
                    dynamic MyProfile = MyStudent.Delete(TxtClientId.Text).Result;
                    int RecordCountDeleted = Convert.ToInt32(MyProfile.RecordCountDeleted);

                    if (RecordCountDeleted >= 1)
                    {
                        MyFormControl.CleareAllControlsRecursive(this);
                        TxtClientId.Focus();
                    }
                    MessageBox.Show(MyProfile.Status + Environment.NewLine + "Record Count Deleted :" 
                        + MyProfile.RecordCountDeleted, "Remove Current Record..");
                }
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            MyFormControl.CleareAllControlsRecursive(this);
            TxtClientId.Focus();
        }

    }
}
