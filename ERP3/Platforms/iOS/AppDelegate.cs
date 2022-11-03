using Foundation;
using UIKit;

namespace ERP3;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	public override bool OpenUrl(UIApplication application, NSUrl url, NSDictionary options)
	{
		if(Platform.OpenUrl(application, url, options))
			return true;

		return base.OpenUrl(application, url, options);
	}

	public override bool ContinueUserActivity(UIApplication application, NSUserActivity userActivity, UIApplicationRestorationHandler completionHandler)
	{
		if (Platform.ContinueUserActivity(application, userActivity, completionHandler))
			return true;

		return base.ContinueUserActivity(application, userActivity, completionHandler);
	}
}
