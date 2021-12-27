using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WP.Models.EFModels;
using WP.Models.Interfeces;
using WP.Models.Repositories;

namespace WP.Models.Services
{
    public class SecurityService
    {
        //Constructor
        private ISecRepository repository;//Call Interface

        public SecurityService(ISecRepository repo)
        {
            this.repository = repo;//Constructor
        }
        //
        public bool IsValid(string account, string password)
        {
            var employee = repository.Load(account);
            if (employee == null) { return false; }
            if (employee.Password == password) { return true; }
            return false;
        }

        //手寫以下內容手動抓取cookies
        //ASP.NET Application life cycle
        public string ProcessLogin(string account, bool rememberMe, out HttpCookie cookie)
        {
            //取得目前的使用者屬於哪個群組
            string userRoles = repository.Load(account).Roles;//Get user roles from EmployeeEntity

            //將userID, Level存到Cookie中
            //建立一張認證票
            FormsAuthenticationTicket ticket =
                new FormsAuthenticationTicket(
                                1,                          //版本別，沒特別用處
                                account,
                                DateTime.Now,               //ticket發行日
                                DateTime.Now.AddDays(2),    //ticket到期日
                                rememberMe,                 //是否續存
                                userRoles,                  //使用者資料
                                "/"                         //cookie位置
                    );

            //將cookie加密
            string value = FormsAuthentication.Encrypt(ticket); 
            //存入cookie
            cookie = new HttpCookie(FormsAuthentication.FormsCookieName, value);

            //導引回目的地的網頁
            string url = FormsAuthentication.GetRedirectUrl(account, true); //第2個參數沒用

            return url;
        }
    }
}