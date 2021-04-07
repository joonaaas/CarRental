using Coderstation.FileDirectory;
using Coderstation.JsonParser;
using Coderstation.RestAPI;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Dynamic;
using System.Threading.Tasks;


namespace CarRental
{
    class Client
    {

        Coders_HttpRequest MyRestAPI = new Coders_HttpRequest();
        public static String URLPage = "Client.php";
        public String URL = "";

        public Client()
        {
            Coders_TextFile MyTextFile = new Coders_TextFile();
            String FileName = Environment.CurrentDirectory + "/Configure.ini";
            String Configure = MyTextFile.Load(FileName);
            //System.Windows.Forms.MessageBox.Show(Configure);
            dynamic ServerSetting = Coders_Parsing.JsonString_ToExpandoObject(Configure);
            URL = (String) ServerSetting.WebServer;
        }

        /*SAVE*/
        public async Task<String> Update(dynamic MyClient)
        {
            String _Status = "";
            URL = URL + "\\" + URLPage;
            var RecordJSon = Coders_Parsing.ExpandoObject_ToJsonString(MyClient);
            String RecieveJSon = await MyRestAPI.ExecuteHttpWebRequest(URL, RecordJSon);

            try
            {
                MyClient = Coders_Parsing.JsonString_ToExpandoObject(RecieveJSon);
                _Status = MyClient.Status;
            }
            catch { _Status = RecieveJSon; }

            return _Status;

        }
    
        /*SEARCH*/
        public async Task<dynamic> Search(String _ClientId)
        {
            URL = URL + "\\" + URLPage;
            dynamic MyClient = new ExpandoObject();
            MyClient.Process = "LoadClientsProfile";
            MyClient.ClientID = _ClientId;

            var RecordJSon = Coders_Parsing.ExpandoObject_ToJsonString(MyClient);
            String RecieveJSon = await MyRestAPI.ExecuteHttpWebRequest(URL, RecordJSon);
            try
            {
                MyClient = Coders_Parsing.JsonString_ToExpandoObject(RecieveJSon);
                if (((String) MyClient.Record.ClientID).Trim() != "") { MyClient.Status = "Record_Found"; }
                else { MyClient.Status = "No_Record_Found"; }
            }
            catch
            {
                MyClient.Status = RecieveJSon;
            }

            return MyClient;
        }

        public async Task<dynamic> Delete(String _ClientId)
        {
            URL = URL + "\\" + URLPage;
            dynamic MyClient = new ExpandoObject();
            MyClient.Process = "RemoveClientsProfile";
            MyClient.ClientID = _ClientId;

            var RecordJSon = Coders_Parsing.ExpandoObject_ToJsonString(MyClient);
            String RecieveJSon = await MyRestAPI.ExecuteHttpWebRequest(URL, RecordJSon);


            try { MyClient = Coders_Parsing.JsonString_ToExpandoObject(RecieveJSon); }
            catch
            {
                MyClient.RecordCountDeleted = "0";
                MyClient.Status = RecieveJSon;
            }

            return MyClient;
        }

        public async Task<dynamic> LoadClientList()
        {
            URL = URL + "\\" + URLPage;
            dynamic MyClient = new ExpandoObject();
            MyClient.Process = "LoadClientsList";

            var RecordJSon = Coders_Parsing.ExpandoObject_ToJsonString(MyClient);
            String RecieveJSon = await MyRestAPI.ExecuteHttpWebRequest(URL, RecordJSon);

            try
            {
                MyClient = Coders_Parsing.JsonString_ToExpandoObject(RecieveJSon);
            }
            catch { MyClient.Status = RecieveJSon; }


            return MyClient;
        }

        int Page = 1;
        public Boolean PageStop = false;

        public void PrintClientList(dynamic MyClientList, PrintPageEventArgs e)
        {
            Font TitleFontsize = new Font("Arial", 18, System.Drawing.FontStyle.Bold);
            Font LabelFontsize = new Font("Arial", 12, System.Drawing.FontStyle.Bold);
            Font DataFontsize = new Font("Arial", 12, System.Drawing.FontStyle.Regular);
            int Row = 190;

            for (int i = 0; i < MyClientList.Record.Count; i++)
            {
                e.Graphics.DrawString("Client List", TitleFontsize, Brushes.Black, new Point(50, 140));
                for (int Cnt = 50; Cnt < 750; Cnt++) { e.Graphics.DrawString("-", LabelFontsize, Brushes.Black, new Point(Cnt, 170)); }

                e.Graphics.DrawString("Client ID", LabelFontsize, Brushes.Black, new Point(110, 185));
                e.Graphics.DrawString("First Name", LabelFontsize, Brushes.Black, new Point(210, 185));
                e.Graphics.DrawString("License No", LabelFontsize, Brushes.Black, new Point(410, 185));
                e.Graphics.DrawString("Address", LabelFontsize, Brushes.Black, new Point(520, 185));

                for (int Cnt = 50; Cnt < 750; Cnt++) { e.Graphics.DrawString("-", LabelFontsize, Brushes.Black, new Point(Cnt, 195)); }

                Row += 20;
                e.Graphics.DrawString((i + 1).ToString() + ".", DataFontsize, Brushes.Black, new Point(60, Row));
                e.Graphics.DrawString(MyClientList.Record[i].ClientID, DataFontsize, Brushes.Black, new Point(100, Row));
                e.Graphics.DrawString(MyClientList.Record[i].FirstName, DataFontsize, Brushes.Black, new Point(200, Row));
                e.Graphics.DrawString(MyClientList.Record[i].LicenseNo, DataFontsize, Brushes.Black, new Point(400, Row));
                e.Graphics.DrawString(MyClientList.Record[i].Address, DataFontsize, Brushes.Black, new Point(500, Row));
            }
            Page = 2;
            Row += 20;
            for (int Cnt = 50; Cnt < 750; Cnt++) { e.Graphics.DrawString("-", LabelFontsize, Brushes.Black, new Point(Cnt, Row)); }





            if (Page <= 1) { e.HasMorePages = true; }
            else
            {
                e.HasMorePages = false;
                this.PageStop = true;
            }


        }

        //UNUSED
        public void Print(dynamic MyProfile, PrintPageEventArgs e)
        {
            Font TitleFontsize = new Font("Arial", 18, System.Drawing.FontStyle.Bold);
            Font LabelFontsize = new Font("Arial", 12, System.Drawing.FontStyle.Bold);
            Font DataFontsize = new Font("Arial", 12, System.Drawing.FontStyle.Regular);

            if (Page == 1)
            {
                for (int Cnt = 50; Cnt < 750; Cnt++) { e.Graphics.DrawString("--", LabelFontsize, Brushes.Black, new Point(Cnt, 120)); }
                e.Graphics.DrawString("Student Profile", TitleFontsize, Brushes.Black, new Point(100, 140));
                for (int Cnt = 50; Cnt < 750; Cnt++) { e.Graphics.DrawString("-", LabelFontsize, Brushes.Black, new Point(Cnt, 170)); }
                e.Graphics.DrawString("ID Number   :", LabelFontsize, Brushes.Black, new Point(100, 190));
                e.Graphics.DrawString("Name        :", LabelFontsize, Brushes.Black, new Point(100, 220));
                e.Graphics.DrawString("Gender      :", LabelFontsize, Brushes.Black, new Point(100, 250));
                e.Graphics.DrawString("Civil Status  :", LabelFontsize, Brushes.Black, new Point(400, 250));
                e.Graphics.DrawString("Contact No. :", LabelFontsize, Brushes.Black, new Point(100, 280));
                e.Graphics.DrawString("Email Address :", LabelFontsize, Brushes.Black, new Point(400, 280));

                e.Graphics.DrawString(MyProfile.IDNumber, DataFontsize, Brushes.Black, new Point(230, 190));
                e.Graphics.DrawString(MyProfile.StudentName, DataFontsize, Brushes.Black, new Point(230, 220));
                e.Graphics.DrawString(MyProfile.Gender, DataFontsize, Brushes.Black, new Point(230, 250));
                e.Graphics.DrawString(MyProfile.CivilStatus, DataFontsize, Brushes.Black, new Point(550, 250));
                e.Graphics.DrawString(MyProfile.ContactNo, DataFontsize, Brushes.Black, new Point(230, 280));
                e.Graphics.DrawString(MyProfile.EmailAddress, DataFontsize, Brushes.Black, new Point(550, 280));
                for (int Cnt = 50; Cnt < 750; Cnt++) { e.Graphics.DrawString("-", LabelFontsize, Brushes.Black, new Point(Cnt, 300)); }
                Page = 2;
            }


            else if (Page == 2)
            {
                e.Graphics.DrawString("Second Page", TitleFontsize, Brushes.Black, new Point(100, 140));
                Page = 3;
            }
            else if (Page == 3)
            {
                e.Graphics.DrawString("Third Page", TitleFontsize, Brushes.Black, new Point(100, 140));
                Page = 4;
            }

            if (Page <= 3) { e.HasMorePages = true; }
            else
            {
                e.HasMorePages = false;
                this.PageStop = true;
            }


        }
    
    }

}
