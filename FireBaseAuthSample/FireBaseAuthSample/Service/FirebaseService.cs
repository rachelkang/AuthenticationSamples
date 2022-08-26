using Firebase.Auth;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;
using FirebaseAuth = FirebaseAdmin.Auth.FirebaseAuth;
using User = FireBaseAuthSample.Model.User;

namespace FireBaseAuthSample.Service;
public partial class FirebaseService
{
    public string projectId = "fir-authsample-b63ac"; // TODO - Repalce with your ProjectID 
    public FirebaseService() { }

    // Log in and get the token
    public async Task<string> LoginAsync(FirebaseAuthProvider authProvider, User user)
    {
        var auth = await authProvider.SignInWithEmailAndPasswordAsync(user.Email, user.Password); // log in
        var content = await auth.GetFreshAuthAsync(); // log in content (information)
        var serialziedContent = JsonConvert.SerializeObject(content); // encode the content if needed
        var token = auth.FirebaseToken;
        return token;
    }

    // Verify the token
    public async Task<FirebaseToken> VerifyIdTokenAsync(string token)
    {
        // Get user claims
        FirebaseToken decodedToken = await FirebaseAuth.DefaultInstance
        .VerifyIdTokenAsync(token);
        return decodedToken;
    }

    // Get user claims that were provided
    public void GetUserClaims(FirebaseToken decodedToken, User user)
    {
        if (decodedToken is not null) 
            user.Email = decodedToken.Claims.FirstOrDefault(x => x.Key.Equals("email")).Value?.ToString();
            user.DisplayName = decodedToken.Claims.FirstOrDefault(x => x.Key.Equals("displayName")).Value?.ToString();
    }
}
