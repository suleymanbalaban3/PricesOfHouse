using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;

namespace HouseOfPrices.Account
{
    public partial class NewAdvert : Page
    {
        House MineHouse = new House();
        protected void Page_Load(object sender, EventArgs e)
        {
            //EstimatedPrice();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string lattStr = latt1.Value.Substring(0,6);
            string lonnStr = lonn1.Value.Substring(0,6);
            float LattValue = float.Parse(lattStr) / (int)Math.Pow(10, lattStr.IndexOf('.')+1);
            float LonnValue = float.Parse(lonnStr) / (int)Math.Pow(10, lonnStr.IndexOf('.')+1);
            DateTime date = DateTime.Now;
            int Room = int.Parse(RoomNumbers.SelectedItem.Text.Substring(0, 1));
            int LivingRoom = int.Parse(RoomNumbers.SelectedItem.Text.Substring(4, 1));
            double HeatingNumber = GetHeating(Heating.SelectedItem.Text);
            int ProximityTransportation = GetProximityToTransportation(ProximityToTransportation.SelectedItem.Text);           
            string Mail = Context.User.Identity.GetUserName();

            if (lattStr == "" || lonnStr == ""){
                Response.Write("<script LANGUAGE='JavaScript' >alert('Please mark your house on this map!')</script>");
            }
            else if (FileUpload1.PostedFile.ContentLength == null || FileUpload1.PostedFile.ContentLength == 0)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Please upload an image!')</script>");
            }
            else if (int.Parse(SquareMeter.Text) < 1) 
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Square meter can't smaller than one!')</script>");
            }
            else if (int.Parse(SquareMeter.Text) > 1000)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('You enter the very big Square meter!')</script>");
            }
            else if (int.Parse(Age.Text) < 0)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('House age can't smaller than zero!')</script>");
            }
            else if (int.Parse(Age.Text) > 1000)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('You enter the very big House age!')</script>");
            }
            else if(int.Parse(FloorNumber.Text) < -2)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Floor number can't smaller than -2!')</script>");
            }
            else if (int.Parse(FloorNumber.Text) > 160)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Burj Khalifa, the world's tallest building with 160 floors!')</script>");
            }
            else if (int.Parse(RequestedPrice.Text) < 0)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Requested price can't be negative!')</script>");
            }
            else{
                try
                {
                    string FileName = "";

                    int length1 = FileUpload1.PostedFile.ContentLength;
                    byte[] picture = new byte[length1];
                    FileUpload1.PostedFile.InputStream.Read(picture, 0, length1);



                    SqlConnection Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ToString());
                    SqlCommand Cmd = new SqlCommand();
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "InsertAdvertLast";

                    MineHouse.CoordinateX = LattValue;
                    MineHouse.CoordinateY = LonnValue;
                    MineHouse.RoomNumber = Room;
                    MineHouse.LivingRoomNumber = LivingRoom;
                    MineHouse.FloorNumber = int.Parse(FloorNumber.Text);
                    MineHouse.SquareMeter = int.Parse(SquareMeter.Text);
                    MineHouse.Age = int.Parse(Age.Text);
                    MineHouse.Heating = HeatingNumber;
                    MineHouse.ProximityToTransportation = ProximityTransportation;
                    MineHouse.RequestedPrice = int.Parse(RequestedPrice.Text);

                    CityFinder _CityFinder = new CityFinder();
                    String City = _CityFinder.getCity(LattValue.ToString(), LonnValue.ToString());


                    Cmd.Parameters.AddWithValue("@X_Coordinate", LattValue);
                    Cmd.Parameters.AddWithValue("@Y_Coordinate", LonnValue);
                    Cmd.Parameters.AddWithValue("@Room_Number", Room);
                    Cmd.Parameters.AddWithValue("@Living_Room_Number", LivingRoom);
                    Cmd.Parameters.AddWithValue("@Floor_Number", int.Parse(FloorNumber.Text));
                    Cmd.Parameters.AddWithValue("@Square_Meter", int.Parse(SquareMeter.Text));
                    Cmd.Parameters.AddWithValue("@Age", int.Parse(Age.Text));
                    Cmd.Parameters.AddWithValue("@Heating", HeatingNumber);
                    Cmd.Parameters.AddWithValue("@Proximity_Transportation", ProximityTransportation);
                    Cmd.Parameters.AddWithValue("@Image", picture);
                    Cmd.Parameters.AddWithValue("@Information", Information.Text);
                    Cmd.Parameters.AddWithValue("@User_Mail_Adress", Mail);
                    Cmd.Parameters.AddWithValue("@Requested_Price", int.Parse(RequestedPrice.Text));
                    Cmd.Parameters.AddWithValue("@Estimated_Price", EstimatedPrice());
                    Cmd.Parameters.AddWithValue("@Insert_Time", date);
                    Cmd.Parameters.AddWithValue("@City", City);
                    Cmd.Connection = Cnn;
                    if (Cnn.State == ConnectionState.Closed) Cnn.Open();
                    int result = Cmd.ExecuteNonQuery();
                    Response.Write(result.ToString() + " Kayıt güncellendi...");
                }
                catch (Exception ex)
                {
                    //Mail_TextBox.Text = "";
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Bu ilan sistemimizde kayıtlı!')</script>");
                    //IsError = 1;
                }
                latt1.Value = "";
                lonn1.Value = "";
                FloorNumber.Text = "";
                SquareMeter.Text = "";
                Age.Text = "";
                Information.Text = "";
                RequestedPrice.Text = "";
                Response.Redirect("~/Account/Manage.aspx", true);
            }           
        }
        public double GetHeating(string Heating)
        {
            if (Heating == "Heater")
            {
                return 1.5;
            }
            else if (Heating == "Central Heating")
            {
                return 1.0;
            }
            else
            {
                return 0.5;
            }
        }
        public int GetProximityToTransportation(string ProximityToTransportation)
        {
            if (ProximityToTransportation == "0 - 200 m")
            {
                return 7;
            }
            else if (ProximityToTransportation == "200 - 400 m")
            {
                return 6;
            }
            else if (ProximityToTransportation == "400 - 600 m")
            {
                return 5;
            }
            else if (ProximityToTransportation == "600 - 1000 m")
            {
                return 4;
            }
            else if (ProximityToTransportation == "1 - 1.5 km")
            {
                return 3;
            }
            else if (ProximityToTransportation == "1.5 - 2 km")
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }
        public int EstimatedPrice()
        {
            double result = 0;
            int i = 0;
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommand command = new SqlCommand();
            SqlParameter param1, param2;
            DataSet ds = new DataSet();
            try
            {

                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ToString());
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SelectRegressionValues";
                adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);
                int lastEstimatedIndex = 0;
                if (ds.Tables[0].Rows[0][0].ToString() != null)
                {
                    lastEstimatedIndex = ds.Tables[0].Rows.Count-1;
                    SquareMeter.Text = "" + lastEstimatedIndex;
                    result = float.Parse(ds.Tables[0].Rows[lastEstimatedIndex][0].ToString()) * MineHouse.CoordinateX;
                    result += float.Parse(ds.Tables[0].Rows[lastEstimatedIndex][1].ToString()) * MineHouse.CoordinateY;
                    result += float.Parse(ds.Tables[0].Rows[lastEstimatedIndex][2].ToString()) * MineHouse.RoomNumber;
                    result += float.Parse(ds.Tables[0].Rows[lastEstimatedIndex][3].ToString()) * MineHouse.LivingRoomNumber;
                    result += float.Parse(ds.Tables[0].Rows[lastEstimatedIndex][4].ToString()) * MineHouse.FloorNumber;
                    result += float.Parse(ds.Tables[0].Rows[lastEstimatedIndex][5].ToString()) * MineHouse.SquareMeter;
                    result += float.Parse(ds.Tables[0].Rows[lastEstimatedIndex][6].ToString()) * MineHouse.Age;
                    result += float.Parse(ds.Tables[0].Rows[lastEstimatedIndex][7].ToString()) * MineHouse.Heating;
                    result += float.Parse(ds.Tables[0].Rows[lastEstimatedIndex][8].ToString()) * MineHouse.ProximityToTransportation;
                    
                    Response.Write("Regression values readed");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Hata')</script>");
            }
            return (int)result;
        }
        
    }
}