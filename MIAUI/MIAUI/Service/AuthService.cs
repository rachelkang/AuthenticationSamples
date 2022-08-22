using Microsoft.Identity.Client;
using System.IdentityModel.Tokens.Jwt;

namespace MIAUI.Service;

public class AuthService
{
    public static IPublicClientApplication authenticationClient { get; private set; }
    public AuthService()
    {
        // The AuthenticationClient is what we will call in other pages to authenticate users.
        authenticationClient = PublicClientApplicationBuilder.Create(Constants.ClientId)
            .WithB2CAuthority(Constants.AuthoritySignIn) // provides the default Authority, or policy, that will be used to authenticate users.
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
                .WithPrompt(Prompt.ForceLogin)
#if ANDROID
                .WithParentActivityOrWindow(Microsoft.Maui.ApplicationModel.Platform.CurrentActivity)
#endif
                .ExecuteAsync(cancellationToken);
            return result; // returns token 
        }
        catch (MsalClientException)
        {
            return null;
        }
    }

    // If there's an existing account
    // get the claims
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
