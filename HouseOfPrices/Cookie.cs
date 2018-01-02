using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseOfPrices
{
    public class Cookie: System.Web.UI.Page
    {
        public void AddCookie(string cookieName, string cookieValue)
        { 
            HttpCookie cookie = new HttpCookie(cookieName, cookieValue); 
            cookie.Expires = DateTime.Now.AddSeconds(30); // Süre(30 dakika) 
            Response.Cookies.Add(cookie); 
        }
        public void DeleteCookie(string userCookieName) 
        { 
            HttpCookie myCookie = new HttpCookie(userCookieName); 
            myCookie.Expires = DateTime.Now.AddSeconds(-30); 
            Response.Cookies.Add(myCookie); 
        }
        public string GetCookie(string cookieName) 
        { 
            string cookie = Request.Cookies[cookieName].Value; 
            return cookie; 
        }
    }
}