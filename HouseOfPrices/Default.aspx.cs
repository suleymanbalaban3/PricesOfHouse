using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Drawing;
using System.Web;
using System.Web.UI;
//using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;

namespace HouseOfPrices
{
    public partial class _Default : Page
    {
        public static DataSet ds = new DataSet();
        public static List<AdvertsIterations> ad;

        static _Default()
        {
            ad = new List<AdvertsIterations>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //lblmessage.Text += "Page load event handled. <br />";
            string connetionString = null;
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommand command = new SqlCommand();
            SqlParameter param1, param2;
            bool LoginSucces = true;
            int i = 0;


            string Mail = Context.User.Identity.GetUserName();

            if (Mail == "" || Mail == null)
            {
                col6.Visible = false;
                LoginSucces = false;
            }

            try
            {

                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ToString());
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SelectAdvert";

                adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);

                if (ds.Tables[0].Rows[i][0].ToString() != null)
                {
                    Response.Write("Sayfa Yüklendi...");
                    //cookie.AddCookie("user", Mail_TextBox.Text);
                    //main.aspx e bagla buradan
                }
                else
                    Response.Write("E-mail adresinizi veya şifrenizi yanlış girdiniz!");

                connection.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Hata')</script>");
            }

            if (ds.Tables[0].Rows.Count > 10)
                i = ds.Tables[0].Rows.Count - 11;
            for (; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i][0].ToString() == null)
                    break;
                else
                {
                    string ascx = "DataUserControl.ascx";
                    Control Data = Page.LoadControl(ascx);

                    PropertyInfo ozellik = Data.GetType().GetProperty("Age");
                    ozellik.SetValue(Data, ds.Tables[0].Rows[i][7].ToString(), null);

                    ozellik = Data.GetType().GetProperty("Info");
                    ozellik.SetValue(Data, ds.Tables[0].Rows[i][11].ToString(), null);

                    ozellik = Data.GetType().GetProperty("FloorNum");
                    ozellik.SetValue(Data, ds.Tables[0].Rows[i][5].ToString(), null);

                    ozellik = Data.GetType().GetProperty("RoomNumber");
                    ozellik.SetValue(Data, ds.Tables[0].Rows[i][3].ToString() + " + " + ds.Tables[0].Rows[i][4].ToString(), null);

                    ozellik = Data.GetType().GetProperty("SquareMeter");
                    ozellik.SetValue(Data, ds.Tables[0].Rows[i][6].ToString() + " m2", null);

                    ozellik = Data.GetType().GetProperty("Price");
                    ozellik.SetValue(Data, ds.Tables[0].Rows[i][13].ToString(), null);

                    ozellik = Data.GetType().GetProperty("Estimated");
                    ozellik.SetValue(Data, ds.Tables[0].Rows[i][14].ToString(), null);

                    ozellik = Data.GetType().GetProperty("IsLogin");
                    if(!LoginSucces)
                        ozellik.SetValue(Data, false, null);
                    else
                        ozellik.SetValue(Data, true, null);

                    ozellik = Data.GetType().GetProperty("AdvertId");
                    ozellik.SetValue(Data, int.Parse(ds.Tables[0].Rows[i-1][0].ToString()), null);
                    //ad.Add(new AdvertsIterations(int.Parse(ds.Tables[0].Rows[i][0].ToString())));
                    ozellik = Data.GetType().GetProperty("Picture");
                    
                    Image img = null;
                    Byte[] bytes = (byte[])ds.Tables[0].Rows[i][10];
                    /*using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        img = Image.FromStream(ms);
                    }
                    */

                   /* MemoryStream ms1 = new MemoryStream(bytes);
                    img.Save(ms1, ImageFormat.RawFormat);
                    var base64Data = Convert.ToBase64String(ms1.ToArray());
                    String Src = "data:image/png;base64," + base64Data;*/
                    //Byte[] bytes = br.ReadBytes((Int32)bytes.Length);
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    String Src = "data:image/png;base64," + base64String;
                    ozellik.SetValue(Data, Src, null);
                    DataPlaceHolder.Controls.Add(Data);
                }
            }

        }

    }
}