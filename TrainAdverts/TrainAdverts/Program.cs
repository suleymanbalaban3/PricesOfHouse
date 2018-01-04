using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;


namespace TrainAdverts
{
    class Program
    { 
        public static double[,] x;
        public static double[,] y;
        public static double[,] matrix;
        static void Main(string[] args)
        {
           
            LineerRegression _LineerRegression = new LineerRegression();
            LoadData();
            
            matrix = _LineerRegression.Make(x, y);

            for (int i = 0; i < x.GetLength(0); i++)
            {
                double estimated = 0.0;
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    estimated += x[i, j] * matrix[j, 0];
                    Console.Write(x[i, j] + " ");
                }
                Console.WriteLine(" = " + y[i, 0] + "estimated = " + estimated);
            }
            Update();


        }
        public static void LoadData()
        {
            double result = 0;
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommand command = new SqlCommand();
            SqlParameter param1, param2;
            DataSet ds = new DataSet();
            try
            {

                //connection = new SqlConnection("Data Source=SLYMNBLBN;Initial Catalog=msdb;Integrated Security=True;MultipleActiveResultSets=True");
                connection = new SqlConnection("Data Source=192.168.211.2,1433;Network Library=DBMSSOCN;User Id=admin;Password=Sblbn.94;Initial Catalog=msdb;MultipleActiveResultSets=True");
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SelectIndependentFromAdvert";
                adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);
                int lastEstimatedIndex = 0;
                x = new double[ds.Tables[0].Rows.Count, 9];
                y = new double[ds.Tables[0].Rows.Count, 1];
                int j = 0;
                if (ds.Tables[0].Rows[0][0].ToString() != null)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        for (j = 0; j < 9; j++)
                        {
                            x[i, j] = double.Parse(ds.Tables[0].Rows[i][j].ToString());
                        }
                        y[i, 0] = double.Parse(ds.Tables[0].Rows[i][j].ToString());
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                //Response.Write("<script LANGUAGE='JavaScript' >alert('Hata')</script>");
            }
        }
        public static void Update()
        {
            try
            {
                SqlConnection Cnn = new SqlConnection("Data Source=192.168.211.2;User Id=admin;Password=Sblbn.94;Network Library=DBMSSOCN;Initial Catalog=msdb;MultipleActiveResultSets=True");
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "InsertRegressionValue";
                Cmd.Parameters.AddWithValue("@X_Coordinate_Beta", matrix[0, 0]);
                Cmd.Parameters.AddWithValue("@Y_Coordinate_Beta", matrix[1, 0]);
                Cmd.Parameters.AddWithValue("@Room_Number_Beta", matrix[2, 0]);
                Cmd.Parameters.AddWithValue("@Living_Room_Number_Beta", matrix[3, 0]);
                Cmd.Parameters.AddWithValue("@Floor_Number_Beta", matrix[4, 0]);
                Cmd.Parameters.AddWithValue("@Square_Meter_Beta", matrix[5, 0]);
                Cmd.Parameters.AddWithValue("@Age_Beta", matrix[6, 0]);
                Cmd.Parameters.AddWithValue("@Heating_Beta", matrix[7, 0]);
                Cmd.Parameters.AddWithValue("@Proximity_Transportation_Beta", matrix[8, 0]);
                Cmd.Connection = Cnn;
                if (Cnn.State == ConnectionState.Closed) Cnn.Open();
                int result1 = Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
            }
        }

    }
}
