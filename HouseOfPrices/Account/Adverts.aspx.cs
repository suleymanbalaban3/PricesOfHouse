using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;

namespace HouseOfPrices.Account
{
    public partial class Adverts : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string session = Session["AdvertId"].ToString();
            String Latitude = _Default.ds.Tables[0].Rows[int.Parse(session)][1].ToString();
            String Longitude = _Default.ds.Tables[0].Rows[int.Parse(session)][2].ToString();
            String RequestedPrice, EstimatedPrice;

            Latitude = Latitude.Replace(",", ".");
            Longitude = Longitude.Replace(",", ".");

            txtlat.Value = Latitude;
            txtlon.Value = Longitude;

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "initialize()", true);

            Image img = null;
            Byte[] bytes = (byte[])_Default.ds.Tables[0].Rows[int.Parse(session)][10];

            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            String Src = "data:image/png;base64," + base64String;
            picture.Src = Src;

            RoomNumberText.Text = _Default.ds.Tables[0].Rows[int.Parse(session)][3].ToString() + " + " + _Default.ds.Tables[0].Rows[int.Parse(session)][4].ToString();
            FloorNumberText.Text = _Default.ds.Tables[0].Rows[int.Parse(session)][5].ToString();
            SquareMeterText.Text = _Default.ds.Tables[0].Rows[int.Parse(session)][6].ToString() + " m2";
            AgeText.Text = _Default.ds.Tables[0].Rows[int.Parse(session)][7].ToString();
            HeatingText.Text = GetHeating(_Default.ds.Tables[0].Rows[int.Parse(session)][8].ToString());
            ProximityToTranportationText.Text = GetProximityToTransportation(_Default.ds.Tables[0].Rows[int.Parse(session)][9].ToString());
            CityText.Text = _Default.ds.Tables[0].Rows[int.Parse(session)][16].ToString();
           /* RequestedPriceText.Text = _Default.ds.Tables[0].Rows[int.Parse(session)][13].ToString();
            EstimatedPriceText.Text = _Default.ds.Tables[0].Rows[int.Parse(session)][14].ToString();*/
            RequestedPrice = _Default.ds.Tables[0].Rows[int.Parse(session)][13].ToString();
            EstimatedPrice = _Default.ds.Tables[0].Rows[int.Parse(session)][14].ToString();
            MoneyTypeGenerator _MoneyTypeGenerator = new MoneyTypeGenerator();
            RequestedPrice = _MoneyTypeGenerator.getMoneyTypeNumber(RequestedPrice);
            EstimatedPrice = _MoneyTypeGenerator.getMoneyTypeNumber(EstimatedPrice);
            RequestedPriceText.Text = RequestedPrice;
            EstimatedPriceText.Text = EstimatedPrice;
            InformationText.Text = _Default.ds.Tables[0].Rows[int.Parse(session)][11].ToString();


            string Mail = Context.User.Identity.GetUserName();

            if (Mail == "" || Mail == null)
            {
                special_row.Visible = false;
            }

        }
        public string GetProximityToTransportation(string ProximityToTransportation)
        {
            if (ProximityToTransportation == "7")
            {
                return "0 - 200 m";
            }
            else if (ProximityToTransportation == "6")
            {
                return "200 - 400 m";
            }
            else if (ProximityToTransportation == "5")
            {
                return "400 - 600 m";
            }
            else if (ProximityToTransportation == "4")
            {
                return "600 - 1000 m";
            }
            else if (ProximityToTransportation == "3")
            {
                return "1 - 1.5 km";
            }
            else if (ProximityToTransportation == "2")
            {
                return "1.5 - 2 km";
            }
            else
            {
                return "2 km +";
            }
        }
        public string GetHeating(string Heating)
        {
            if (Heating == "1.5")
            {
                return "Heater";
            }
            else if (Heating == "1.0")
            {
                return "Central Heating";
            }
            else
            {
                return "Stove";
            }
        }
    }
}