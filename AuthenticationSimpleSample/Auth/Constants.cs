using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationSimpleSample.Auth
{
    public static class Constants
    {
        // All info can be found in your Azure AD B2C directory
        // AD
        public static readonly string ClientId = "46ae553c-44c6-40bd-aded-daca74801f3e"; // from App Registrations 
        public static readonly string[] Scopes = new string[] { "openid", "offline_access" };

        // B2C
        public static readonly string TenantName = "MauiAuthApp"; // from Azure AD B2C Overview 
        public static readonly string TenantId = $"{TenantName}.onmicrosoft.com";
        public static readonly string SignInPolicy = "B2C_1_Client"; // from user flows
        public static readonly string AuthorityBase = $"https://{TenantName}.b2clogin.com/tfp/{TenantId}/";
        public static readonly string AuthoritySignIn = $"{AuthorityBase}{SignInPolicy}";
        public static readonly string iosKeychainSecurityGroup = "com.microsoft.adalcache";
    }
}
