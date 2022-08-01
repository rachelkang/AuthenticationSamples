using Foundation;
using Microsoft.Identity.Client;
using UIKit;

namespace AuthenticationSimpleSample;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
    {
        AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(url);
        return base.OpenUrl(app, url, options);
    }
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
