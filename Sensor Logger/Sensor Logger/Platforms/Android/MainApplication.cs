using Android.App;
using Android.Runtime;
[assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage, MaxSdkVersion = 32)]
[assembly: UsesPermission(Android.Manifest.Permission.ReadExternalStorage, MaxSdkVersion = 32)]
[assembly: UsesPermission(Android.Manifest.Permission.AccessFineLocation, MaxSdkVersion = 32)]
[assembly: UsesPermission(Android.Manifest.Permission.AccessBackgroundLocation, MaxSdkVersion = 32)]
[assembly: UsesPermission(Android.Manifest.Permission.AccessCoarseLocation, MaxSdkVersion = 32)]
[assembly: UsesPermission(Android.Manifest.Permission.BodySensors, MaxSdkVersion = 32)]
[assembly: UsesPermission(Android.Manifest.Permission.BodySensorsBackground, MaxSdkVersion = 32)]
[assembly: UsesPermission(Android.Manifest.Permission.HighSamplingRateSensors, MaxSdkVersion = 32)]

namespace Sensor_Logger
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
