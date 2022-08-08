using Foundation;
using UIKit;
using Microsoft.Identity.Client;

namespace AuthenticationSimpleSample;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate

{
    public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
    {
        AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(url);
        //return true;
        return base.OpenUrl(app, url, options);

        //url = new NSUrl("msal46ae553c-44c6-40bd-aded-daca74801f3e://auth");
        //UIApplication.SharedApplication.OpenUrl(url);
        //return true;
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

}
