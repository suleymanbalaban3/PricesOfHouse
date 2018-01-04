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

            RoomNumberText.Text = _Default.ds.Tables[0].Rows[int.Parse(session)][3].ToString();
            FloorNumberText.Text = _Default.ds.Tables[0].Rows[int.Parse(session)][5].ToString();
            SquareMeterText.Text = _Default.ds.Tables[0].Rows[int.Parse(session)][6].ToString();
            AgeText.Text = _Default.ds.Tables[0].Rows[int.Parse(session)][7].ToString();
            HeatingText.Text = _Default.ds.Tables[0].Rows[int.Parse(session)][8].ToString();
            ProximityToTranportationText.Text = _Default.ds.Tables[0].Rows[int.Parse(session)][9].ToString();
            RequestedPriceText.Text = _Default.ds.Tables[0].Rows[int.Parse(session)][13].ToString();
            EstimatedPriceText.Text = _Default.ds.Tables[0].Rows[int.Parse(session)][14].ToString();
            InformationText.Text = _Default.ds.Tables[0].Rows[int.Parse(session)][11].ToString();


            string Mail = Context.User.Identity.GetUserName();

            if (Mail == "" || Mail == null)
            {
                special_row.Visible = false;
            }

        }
    }
}