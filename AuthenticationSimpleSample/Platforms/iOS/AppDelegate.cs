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
        return true;
        //return base.OpenUrl(app, url, options);
    }
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

}
