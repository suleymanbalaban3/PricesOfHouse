using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using HouseOfPrices.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace HouseOfPrices.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");
                try
                {
                    String str = "Data Source=SLYMNBLBN;Integrated Security=True";
                    //SqlConnection Cnn = new SqlConnection(str);
                    SqlConnection Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ToString());
                    SqlCommand Cmd = new SqlCommand();
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "InsertUserStoredProcedure";
                    Cmd.Parameters.AddWithValue("@First_Name", FirstName.Text);
                    Cmd.Parameters.AddWithValue("@Last_Name", LastName.Text);
                    Cmd.Parameters.AddWithValue("@Mail_Adress", Email.Text);
                    Cmd.Parameters.AddWithValue("@Password", Password.Text);
                    Cmd.Connection = Cnn;
                    if (Cnn.State == ConnectionState.Closed) Cnn.Open();
                    int result1 = Cmd.ExecuteNonQuery();
                    Response.Write(result1.ToString() + " Kayıt güncellendi...");
                }
                catch (Exception ex)
                {
                    //Mail_TextBox.Text = "";
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Bu mail adresi sistemimizde kayıtlı!')</script>");
                    //IsError = 1;
                }
                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}