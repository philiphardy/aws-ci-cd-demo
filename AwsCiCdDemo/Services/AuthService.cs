using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;

namespace AwsCiCdDemo.Services
{
    public class AuthService
    {
        public static readonly AuthService Instance = new AuthService();

        private string password;
        private string session;

        private AuthService()
        {
            this.password = Environment.GetEnvironmentVariable("PASSWORD", EnvironmentVariableTarget.Machine);
            if (this.password == null)
            {
                Debug.WriteLine("No env variable PASSWORD found. Defaulting to 'password'");
                this.password = "password";
            }
        }

        public bool authenticate(HttpResponseBase response, string password)
        {
            if (password == this.password)
            {
                this.session = Guid.NewGuid().ToString();
                response.SetCookie(new HttpCookie("session", this.session));
                Debug.WriteLine("Successfully authenticated!");
                return true;
            }

            response.StatusCode = (int)HttpStatusCode.Forbidden;
            Debug.WriteLine("Authentication failed.");
            return false;
        }

        public bool isAuthenticated(HttpRequestBase request)
        {
            HttpCookie requestCookie = request.Cookies["session"];
            return requestCookie != null && requestCookie.Value == this.session;
        }
    }
}