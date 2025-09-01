using Foundation;

namespace UltraMinimalCrash.iOS;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() => UltraMinimalCrash.MauiProgram.CreateMauiApp();
}