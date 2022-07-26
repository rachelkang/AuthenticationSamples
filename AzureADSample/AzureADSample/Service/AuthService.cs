using AzureADSample.Model;
using Microsoft.Identity.Client;
using System.IdentityModel.Tokens.Jwt;

namespace AzureADSample.Service;
public class AuthService
{
    public static IPublicClientApplication authenticationClient { get; private set;}
    public AuthService()
    {
        authenticationClient = PublicClientApplicationBuilder.Create(Constants.ClientId)
            //.WithB2CAuthority(Constants.AuthoritySignIn) // uncomment to support B2C
            .WithRedirectUri($"msal{Constants.ClientId}://auth")
            .Build();
    }

    // Get token interactively and prompt the user to login
    public async Task<AuthenticationResult> LoginAsync(CancellationToken cancellationToken)
    {
        AuthenticationResult result;
        try
        {
            result = await authenticationClient
                .AcquireTokenInteractive(Constants.Scopes)
                .WithPrompt(Prompt.ForceLogin) //  command builder => prompt user for credemtials
#if ANDROID
                .WithParentActivityOrWindow(Microsoft.Maui.ApplicationModel.Platform.CurrentActivity)
#endif
                .ExecuteAsync(cancellationToken);
            return result;
        }
        catch (MsalClientException)
        {
            return null;
        }
    }

    // Read tokens and get claims
    public void GetUserClaims(AuthenticationResult result, User user)
    {
        var token = result.IdToken;
        if (token is not null)
        {
            var handler = new JwtSecurityTokenHandler();
            var data = handler.ReadJwtToken(token);
            var claims = data.Claims.ToList();
            if (data is not null)
            {
                user.Name = data.Claims.FirstOrDefault(x => x.Type.Equals("name"))?.Value;
                user.Email = data.Claims.FirstOrDefault(x => x.Type.Equals("preferred_username"))?.Value;
            }
        }
    }

}
