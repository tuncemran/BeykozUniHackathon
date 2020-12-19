using System;
using System.Web;
using System.Web.Mvc;
using CubeBoxClient.CubeBoxCloudyServer;

namespace BeykozUniHackathon.Controllers
{
    public class BaseController : Controller
        {
            private LoginInfo loginInfo = null;
            private bool companyStatus = false;

            public BaseController()
            {
            }

            public void InitSession(HttpSessionStateBase session)
            {
                if (session != null && session["AppUser"] != null)
                {
                    loginInfo = (LoginInfo)session["AppUser"];
                    if (!String.IsNullOrEmpty(loginInfo.CompanyId))
                    {
                        companyStatus = true;
                    }
                }
            }

            public bool IsAdmin()
            {
                return loginInfo.IsAdmin;
            }

            public String GetToken()
            {
                return loginInfo.Token;
            }

            public int GetUserId()
            {
                return loginInfo.UserId;
            }

            public String GetUserCode()
            {
                return loginInfo.UserCode;
            }

            public String[] GetUserRoles()
            {
                return loginInfo.Roles;
            }

            public String GetUserRootPathLocator()
            {
                return loginInfo.UserRootPathLocator;
            }

            public bool GetCompanyStatus()
            {
                return companyStatus;
            }

            public String GetCompanyId()
            {
                return loginInfo.CompanyId;
            }

            public String GetCompanyName()
            {
                return loginInfo.CompanyName;
            }

            public String GetFileTableName()
            {
                return loginInfo.FileTableNamePrefix;
            }

            public int GetQuota()
            {
                return loginInfo.Quota;
            }
    }
}