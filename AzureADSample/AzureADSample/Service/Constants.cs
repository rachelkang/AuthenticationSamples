using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureADSample.Service;

public static class Constants
{
    // All info can be found in your Azure AD directory
    public static readonly string ClientId = "46ae553c-44c6-40bd-aded-daca74801f3e";
    public static readonly string[] Scopes = new string[] { "openid", "offline_access" };

    // This is for B2C
    /*public static readonly string TenantName = "TENANT_NAME";
    public static readonly string TenantId = $"{TenantName}.onmicrosoft.com";
    public static readonly string SignInPolicy = "POLICY_NAME";
    public static readonly string AuthorityBase = $"https://{TenantName}.b2clogin.com/tfp/{TenantId}/";
    public static readonly string AuthoritySignIn = $"{AuthorityBase}{SignInPolicy}";*/
}
