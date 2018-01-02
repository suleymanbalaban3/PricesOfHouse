using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using System.Data;
using HouseOfPrices.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace HouseOfPrices.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            bool isLegal = true;

            if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
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
                    command.CommandText = "SelectUser";
                    param1 = new SqlParameter("@Mail_Adress", Email.Text);
                    param2 = new SqlParameter("@Password", Password.Text);

                    param1.Direction = ParameterDirection.Input;
                    param2.Direction = ParameterDirection.Input;

                    param1.DbType = DbType.String;
                    param2.DbType = DbType.String;

                    command.Parameters.Add(param1);
                    command.Parameters.Add(param2);
                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(ds);

                    if (ds.Tables[0].Rows[i][0].ToString() != null)
                    {
                        Response.Write(" Giriş yapıldı");
                        //cookie.AddCookie("user", Mail_TextBox.Text);
                        //HttpCookie musteriCookie = new HttpCookie("user");
                        //musteriCookie.Value = Mail_TextBox.Text;
                        //musteriCookie.Expires = DateTime.Now.AddHours(1);
                        //Response.Cookies.Add(musteriCookie);
                        //Response.Redirect("InsertAd.aspx", true);
                        //main.aspx e bagla buradan
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    //Response.Write("<script LANGUAGE='JavaScript' >alert('Hata')</script>");
                    FailureText.Text = "Invalid login attempt";
                    ErrorMessage.Visible = true;
                    isLegal = false;
                    
                }
                if (isLegal)
                {
                    var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                    /*switch (result)
                    {
                        case SignInStatus.Success:
                            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                            break;
                        case SignInStatus.LockedOut:
                            Response.Redirect("/Account/Lockout");
                            break;
                        case SignInStatus.RequiresVerification:
                            Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                            Request.QueryString["ReturnUrl"],
                                                            RememberMe.Checked),
                                              true);
                            break;
                        case SignInStatus.Failure:
                        default:
                            FailureText.Text = "Invalid login attempt";
                            ErrorMessage.Visible = true;
                            break;
                    }*/
                }
            }
        }
    }
}