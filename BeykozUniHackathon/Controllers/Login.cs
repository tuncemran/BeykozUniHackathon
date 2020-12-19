using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BeykozUniHackathon.Models;
using CubeBoxLib;

namespace BeykozUniHackathon.Controllers
{
    public class LoginController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginEvent(LoginModel loginModel)
        {
            ResultJson resultJson = new ResultJson();
            try
            {
                SessionData session = new SessionData();
                session.EndPointURL = "https://cubebox.secube.com.tr/CubeBoxCloudyServer/CubeBoxCloudyServerHTTP";
                ConfigurationManager.AppSettings["CubeBoxUrl"] = session.EndPointURL;

                var client = CubeBoxClient.ConnectCloudyHelper.Connect(session.EndPointURL);
                var loginInfo = client.Login(loginModel.Username, loginModel.Password);
                session.LoginInfo = loginInfo;
                client.Close();
                // if user can login
                if (loginInfo.CanLogin)
                {
                    FormsAuthentication.SetAuthCookie(session.LoginInfo.emailAddress, false);
                    Session.Add("AppUserId", session.LoginInfo.UserId);
                    Session.Add("AppIsAuthenticated", true);
                    Session.Add("AppUser", session.LoginInfo);
                    Session.Add("AppSession", session);

                    var ticket = new FormsAuthenticationTicket(
                            version:1,
                            name:session.LoginInfo.emailAddress,
                            issueDate:DateTime.Now, 
                            expiration:DateTime.Now.AddMinutes(Session.Timeout),
                            isPersistent:false,
                            userData:session.LoginInfo.UserId.ToString()
                        );

                    var encryptedTicket = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    Response.Cookies.Add(cookie);
                    resultJson.Success = true;
                    resultJson.Response = loginInfo;
                }
                else
                {
                    resultJson.Success = false;
                    resultJson.Response = loginInfo;
                }
            }
            catch (Exception e)
            {
                resultJson.Success = false;
                resultJson.Response = e.Message;
            }
            return Json(resultJson);
        }
    }

}