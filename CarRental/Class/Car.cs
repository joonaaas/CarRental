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
    class Car
    {

        Coders_HttpRequest MyRestAPI = new Coders_HttpRequest();
        public static String URLPage = "Car.php";
        public String URL = "";

        public Car()
        {
            Coders_TextFile MyTextFile = new Coders_TextFile();
            String FileName = Environment.CurrentDirectory + "/Configure.ini";
            String Configure = MyTextFile.Load(FileName);
            //System.Windows.Forms.MessageBox.Show(Configure);
            dynamic ServerSetting = Coders_Parsing.JsonString_ToExpandoObject(Configure);
            URL = (String) ServerSetting.WebServer;
        }

        /*SAVE*/
        public async Task<String> Update(dynamic MyCar)
        {
            String _Status = "";
            URL = URL + "\\" + URLPage;
            var RecordJSon = Coders_Parsing.ExpandoObject_ToJsonString(MyCar);
            String RecieveJSon = await MyRestAPI.ExecuteHttpWebRequest(URL, RecordJSon);

            try
            {
                MyCar = Coders_Parsing.JsonString_ToExpandoObject(RecieveJSon);
                _Status = MyCar.Status;
            }
            catch { _Status = RecieveJSon; }

            return _Status;

        }

        /*SEARCH*/
        public async Task<dynamic> Search(String _CarId)
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

        /*DELETE CAR*/
        public async Task<dynamic> Delete(String _CarID)
        {
            URL = URL + "\\" + URLPage;
            dynamic MyCar = new ExpandoObject();
            MyCar.Process = "RemoveCarsProfile";
            MyCar.CarID = _CarID;

            var RecordJSon = Coders_Parsing.ExpandoObject_ToJsonString(MyCar);
            String RecieveJSon = await MyRestAPI.ExecuteHttpWebRequest(URL, RecordJSon);


            try { MyCar = Coders_Parsing.JsonString_ToExpandoObject(RecieveJSon); }
            catch
            {
                MyCar.RecordCountDeleted = "0";
                MyCar.Status = RecieveJSon;
            }

            return MyCar;
        }


        /*LOAD CAR DATA*/
        public async Task<dynamic> LoadCarList()
        {
            URL = URL + "\\" + URLPage;
            dynamic MyCar = new ExpandoObject();
            MyCar.Process = "LoadCarList";

            var RecordJSon = Coders_Parsing.ExpandoObject_ToJsonString(MyCar);
            String RecieveJSon = await MyRestAPI.ExecuteHttpWebRequest(URL, RecordJSon);

            try
            {
                MyCar = Coders_Parsing.JsonString_ToExpandoObject(RecieveJSon);
            }
            catch { MyCar.Status = RecieveJSon; }

            return MyCar;
        }


        int Page = 1;
        public Boolean PageStop = false;

        /*PRINT CAR*/
        public void PrintCarList(dynamic MyCarList, PrintPageEventArgs e)
        {
            Font TitleFontsize = new Font("Arial", 18, System.Drawing.FontStyle.Bold);
            Font LabelFontsize = new Font("Arial", 12, System.Drawing.FontStyle.Bold);
            Font DataFontsize = new Font("Arial", 12, System.Drawing.FontStyle.Regular);
            int Row = 190;

            for (int i = 0; i < MyCarList.Record.Count; i++)
            {
                e.Graphics.DrawString("Car List", TitleFontsize, Brushes.Black, new Point(50, 140));
                for (int Cnt = 50; Cnt < 750; Cnt++) { e.Graphics.DrawString("-", LabelFontsize, Brushes.Black, new Point(Cnt, 170)); }

                e.Graphics.DrawString("Car ID", LabelFontsize, Brushes.Black, new Point(110, 185));
                e.Graphics.DrawString("Brand", LabelFontsize, Brushes.Black, new Point(210, 185));
                e.Graphics.DrawString("Model", LabelFontsize, Brushes.Black, new Point(410, 185));
                e.Graphics.DrawString("Rate", LabelFontsize, Brushes.Black, new Point(520, 185));

                for (int Cnt = 50; Cnt < 750; Cnt++) { e.Graphics.DrawString("-", LabelFontsize, Brushes.Black, new Point(Cnt, 195)); }

                Row += 20;
                //e.Graphics.DrawString((i + 1).ToString() + ".", DataFontsize, Brushes.Black, new Point(60, Row));
                e.Graphics.DrawString(MyCarList.Record[i].CarID, DataFontsize, Brushes.Black, new Point(100, Row));
                e.Graphics.DrawString(MyCarList.Record[i].Brand, DataFontsize, Brushes.Black, new Point(200, Row));
                e.Graphics.DrawString(MyCarList.Record[i].Model, DataFontsize, Brushes.Black, new Point(400, Row));
                e.Graphics.DrawString(MyCarList.Record[i].Rate, DataFontsize, Brushes.Black, new Point(500, Row));
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
                e.Graphics.DrawString("Car Profile", TitleFontsize, Brushes.Black, new Point(100, 140));
                for (int Cnt = 50; Cnt < 750; Cnt++) { e.Graphics.DrawString("-", LabelFontsize, Brushes.Black, new Point(Cnt, 170)); }
                e.Graphics.DrawString("Car ID   :", LabelFontsize, Brushes.Black, new Point(100, 190));
                e.Graphics.DrawString("Brand        :", LabelFontsize, Brushes.Black, new Point(100, 220));
                e.Graphics.DrawString("Model      :", LabelFontsize, Brushes.Black, new Point(100, 250));
                e.Graphics.DrawString("Rate :", LabelFontsize, Brushes.Black, new Point(400, 250));
                //e.Graphics.DrawString("Contact No. :", LabelFontsize, Brushes.Black, new Point(100, 280));
                //e.Graphics.DrawString("Email Address :", LabelFontsize, Brushes.Black, new Point(400, 280));

                e.Graphics.DrawString(MyProfile.CarID, DataFontsize, Brushes.Black, new Point(230, 190));
                e.Graphics.DrawString(MyProfile.Brand, DataFontsize, Brushes.Black, new Point(230, 220));
                e.Graphics.DrawString(MyProfile.Model, DataFontsize, Brushes.Black, new Point(230, 250));
                e.Graphics.DrawString(MyProfile.Rate, DataFontsize, Brushes.Black, new Point(550, 250));
                //e.Graphics.DrawString(MyProfile.ContactNo, DataFontsize, Brushes.Black, new Point(230, 280));
                //e.Graphics.DrawString(MyProfile.EmailAddress, DataFontsize, Brushes.Black, new Point(550, 280));
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
