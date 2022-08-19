namespace MIAUI.Service;

public static class Constants
{
    // All info can be found in your Azure AD or B2C directory
    public static readonly string ClientId = "ClientId"; // Once you register your app you will be able to get a ClientId, subtitute here
    public static readonly string[] Scopes = new string[] { "openid", "offline_access" };

    // B2C
    public static readonly string TenantName = "MauiAuthApp"; // from Azure AD B2C Overview 
    public static readonly string TenantId = $"{TenantName}.onmicrosoft.com";
    public static readonly string SignInPolicy = "B2C_1_Client"; // from user flows
    public static readonly string AuthorityBase = $"https://{TenantName}.b2clogin.com/tfp/{TenantId}/";
    public static readonly string AuthoritySignIn = $"{AuthorityBase}{SignInPolicy}";
}
