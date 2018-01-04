using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;

namespace HouseOfPrices
{
    public partial class DataUserControl : System.Web.UI.UserControl
    {
        MoneyTypeGenerator _MoneyTypeGenerator = new MoneyTypeGenerator();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void LinkClick(object sender, EventArgs e)
        {
            LinkButton l = new LinkButton();
            l = (LinkButton)sender;
            Session["AdvertId"] = l.ID.ToString();
            Response.Redirect("/Account/Adverts.aspx");
        }
        public string SquareMeter
        {
            get
            {
                return col0.Text;
            }
            set
            {
                col0.Text = value;
            }
        }
        public string RoomNumber
        {
            get
            {
                return col1.Text;
            }
            set
            {
                col1.Text = value;
            }
        }
        public string Age
        {
            get
            {
                return col2.Text;
            }
            set
            {
                col2.Text = value;
            }
        }
        public string Info
        {
            get
            {
                return col3.Text;
            }
            set
            {
                col3.Text = value;
            }
        }
        public string Price
        {
            get
            {
                return col5.Text;
            }
            set
            {
                col5.Text = _MoneyTypeGenerator.getMoneyTypeNumber(value);
            }
        }
        public string Estimated
        {
            get
            {
                return col6.Text;
            }
            set
            {
                col6.Text = _MoneyTypeGenerator.getMoneyTypeNumber(value);
            }
        }
        public string FloorNum
        {
            get
            {
                return col7.Text;
            }
            set
            {
                col7.Text = value;
            }
        }
        public bool IsLogin
        {
            get
            {
                string Mail = Context.User.Identity.GetUserName();
                if (Mail == "" || Mail == null)
                    return false;
                return true;
            }
            set
            {
                EstimatedTab.Visible = value;
            }
        
        }
        public int AdvertId
        {
            get
            {
                return int.Parse(lbtn.ID);
            }
            set
            {
                lbtn.ID = value.ToString();
            }
        }
        public string City
        {
            get
            {
                return City_Label.Text;
            }
            set
            {
                City_Label.Text = value;
            }
        }
        public String Picture
        {
            get
            {
                return picture.Src;
            }
            set
            {
                picture.Src = value;
                picture.Height = 40;
                picture.Width = 55;
                               
            }
        }
    }
}