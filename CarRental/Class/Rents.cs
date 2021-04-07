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
    class Rents
    {

        Coders_HttpRequest MyRestAPI = new Coders_HttpRequest();
        public static String URLPage = "Rents.php";
        public String URL = "";

        public Rents()
        {
            Coders_TextFile MyTextFile = new Coders_TextFile();
            String FileName = Environment.CurrentDirectory + "/Configure.ini";
            String Configure = MyTextFile.Load(FileName);
            //System.Windows.Forms.MessageBox.Show(Configure);
            dynamic ServerSetting = Coders_Parsing.JsonString_ToExpandoObject(Configure);
            URL = (String) ServerSetting.WebServer;
        }

        /*SAVE*/
        public async Task<String> Update(dynamic MyRent)
        {
            String _Status = "";
            URL = URL + "\\" + URLPage;
            var RecordJSon = Coders_Parsing.ExpandoObject_ToJsonString(MyRent);
            String RecieveJSon = await MyRestAPI.ExecuteHttpWebRequest(URL, RecordJSon);

            try
            {
                MyRent = Coders_Parsing.JsonString_ToExpandoObject(RecieveJSon);
                _Status = MyRent.Status;
            }
            catch { _Status = RecieveJSon; }

            return _Status;

        }

        /*SEARCH CLIENT*/
        public async Task<dynamic> SearchClient(String _ClientId)
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

        /*SEARCH CAR*/
        public async Task<dynamic> SearchCar(String _CarId)
        {
            URL = URL + "\\" + URLPage;
            dynamic MyCar = new ExpandoObject();
            MyCar.Process = "LoadCarsProfile";
            MyCar.CarID = _CarId;

            var RecordJSon = Coders_Parsing.ExpandoObject_ToJsonString(MyCar);
            String RecieveJSon = await MyRestAPI.ExecuteHttpWebRequest(URL, RecordJSon);
            try
            {
                MyCar = Coders_Parsing.JsonString_ToExpandoObject(RecieveJSon);
                if (((String) MyCar.Record.CarID).Trim() != "") { MyCar.Status = "Record_Found"; }
                else { MyCar.Status = "No_Record_Found"; }
            }
            catch
            {
                MyCar.Status = RecieveJSon;
            }

            return MyCar;
        }

        /*SEARCH RENT*/
        public async Task<dynamic> SearchRent(String _RentID)
        {
            URL = URL + "\\" + URLPage;
            dynamic MyRent = new ExpandoObject();
            MyRent.Process = "LoadRentList";
            MyRent.RentID = _RentID;

            var RecordJSon = Coders_Parsing.ExpandoObject_ToJsonString(MyRent);
            String RecieveJSon = await MyRestAPI.ExecuteHttpWebRequest(URL, RecordJSon);
            try
            {
                MyRent = Coders_Parsing.JsonString_ToExpandoObject(RecieveJSon);
                if (((String) MyRent.Record.RentID).Trim() != "") { MyRent.Status = "Record_Found"; }
                else { MyRent.Status = "No_Record_Found"; }
            }
            catch
            {
                MyRent.Status = RecieveJSon;
            }

            return MyRent;
        }

        /*LOAD RENT LIST*/
        public async Task<dynamic> LoadTransactionList()
        {
            URL = URL + "\\" + URLPage;
            dynamic MyRent = new ExpandoObject();
            MyRent.Process = "LoadTransactionList";

            var RecordJSon = Coders_Parsing.ExpandoObject_ToJsonString(MyRent);
            String RecieveJSon = await MyRestAPI.ExecuteHttpWebRequest(URL, RecordJSon);

            try
            {
                MyRent = Coders_Parsing.JsonString_ToExpandoObject(RecieveJSon);
            }
            catch { MyRent.Status = RecieveJSon; }

            return MyRent;
        }

        int Page = 1;
        public Boolean PageStop = false;

        //PRINT RENT LIST
        public void PrintRentList(dynamic MyClientList, PrintPageEventArgs e)
        {
            Font TitleFontsize = new Font("Arial", 18, System.Drawing.FontStyle.Bold);
            Font LabelFontsize = new Font("Arial", 12, System.Drawing.FontStyle.Bold);
            Font DataFontsize = new Font("Arial", 12, System.Drawing.FontStyle.Regular);
            int Row = 190;

            for (int i = 0; i < MyClientList.Record.Count; i++)
            {
                e.Graphics.DrawString("Transaction", TitleFontsize, Brushes.Black, new Point(50, 140));
                for (int Cnt = 50; Cnt < 750; Cnt++) { e.Graphics.DrawString("-", LabelFontsize, Brushes.Black, new Point(Cnt, 170)); }

                e.Graphics.DrawString("Transaction ID", LabelFontsize, Brushes.Black, new Point(110, 185));
                e.Graphics.DrawString("Name", LabelFontsize, Brushes.Black, new Point(210, 185));
                e.Graphics.DrawString("Car Model", LabelFontsize, Brushes.Black, new Point(410, 185));
                e.Graphics.DrawString("Car Brand", LabelFontsize, Brushes.Black, new Point(520, 185));

                for (int Cnt = 50; Cnt < 750; Cnt++) { e.Graphics.DrawString("-", LabelFontsize, Brushes.Black, new Point(Cnt, 195)); }

                Row += 20;
                e.Graphics.DrawString((i + 1).ToString() + ".", DataFontsize, Brushes.Black, new Point(60, Row));
                e.Graphics.DrawString(MyClientList.Record[i].RentID, DataFontsize, Brushes.Black, new Point(100, Row));
                e.Graphics.DrawString(MyClientList.Record[i].ClientName, DataFontsize, Brushes.Black, new Point(200, Row));
                e.Graphics.DrawString(MyClientList.Record[i].CarBrand, DataFontsize, Brushes.Black, new Point(400, Row));
                e.Graphics.DrawString(MyClientList.Record[i].CarModel, DataFontsize, Brushes.Black, new Point(500, Row));
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

        public int TotalCost(int _Days, int _RentFee, int _InsuranceFee, int CarRate)
        {
            int perDay = 500;
            int cost = (_Days * perDay) + _RentFee + _InsuranceFee + CarRate;
            return cost;
        }



    }
}
