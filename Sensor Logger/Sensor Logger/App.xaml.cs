
namespace Sensor_Logger
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
#if WINDOWS
            var window = base.CreateWindow(activationState);

            window.Width = 480;
            window.Height = 860;

            return window;
#else
            return base.CreateWindow(activationState);
#endif
        }
    }
}
