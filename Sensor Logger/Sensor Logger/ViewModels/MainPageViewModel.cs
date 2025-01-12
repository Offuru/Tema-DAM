using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using Sensor_Logger.Controls.Views;
using Sensor_Logger.Services;

namespace Sensor_Logger.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        public MainPageViewModel(LoginService loginService, SensorsService sensorService)
        {
            _loginService = loginService;
            _sensorService = sensorService;

            SetupSettings();
            SetupAcceleration();
            SetupBarometer();
            SetupCompass();
            SetupGps();
            SetupGyroscope();
            SetupHome();
        }

        #region Setup

        public void SetupHome()
        {
            Home = new Home()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            User = $"User: {_loginService.CurrentUser.Username}";

            Home.SetBinding(Controls.Views.Home.UserTextProperty,
                new Binding(nameof(User), mode: BindingMode.TwoWay));
            Home.SetBinding(Controls.Views.Home.AccelerometerSupportedTextProperty,
                new Binding(nameof(IsAccelerometerAvailable), mode: BindingMode.TwoWay));
            Home.SetBinding(Controls.Views.Home.BarometerSupportedTextProperty,
                new Binding(nameof(IsBarometerAvailable), mode: BindingMode.TwoWay));
            Home.SetBinding(Controls.Views.Home.CompassSupportedTextProperty,
                new Binding(nameof(IsCompassAvailable), mode: BindingMode.TwoWay));
            Home.SetBinding(Controls.Views.Home.GyroscopeSupportedTextProperty,
                new Binding(nameof(IsGyroscopeAvailable), mode: BindingMode.TwoWay));
        }

        public void SetupSettings()
        {
            Settings = new Settings()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            Settings.SetBinding(Controls.Views.Settings.AccelerometerToggledProperty,
                new Binding(nameof(AccelerometerToggled), mode: BindingMode.TwoWay));
            Settings.SetBinding(Controls.Views.Settings.BarometerToggledProperty,
                new Binding(nameof(BarometerToggled), mode: BindingMode.TwoWay));
            Settings.SetBinding(Controls.Views.Settings.GyroscopeToggledProperty,
                new Binding(nameof(GyroscopeToggled), mode: BindingMode.TwoWay));
            Settings.SetBinding(Controls.Views.Settings.CompassToggledProperty,
                new Binding(nameof(CompassToggled), mode: BindingMode.TwoWay));
            Settings.SetBinding(Controls.Views.Settings.GPSToggledProperty,
                new Binding(nameof(GpsToggled), mode: BindingMode.TwoWay));
        }

        public void SetupAcceleration()
        {
            Acceleration = new Acceleration()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            

            Acceleration.SetBinding(Controls.Views.Acceleration.XAxisLabelTextProperty,
                new Binding(nameof(AccX)));            
            Acceleration.SetBinding(Controls.Views.Acceleration.YAxisLabelTextProperty,
                new Binding(nameof(AccY)));            
            Acceleration.SetBinding(Controls.Views.Acceleration.ZAxisLabelTextProperty,
                new Binding(nameof(AccZ)));


            Task.Run(UpdateAccelerometerData);
        }

        public void SetupCompass()
        {
            CompassView = new Controls.Views.Compass()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            CompassView.SetBinding(Controls.Views.Compass.CompassTextProperty,
                new Binding(nameof(Direction)));

            Task.Run(UpdateCompassData);
        }

        public void SetupBarometer()
        {
            BarometerView = new Controls.Views.Barometer()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            BarometerView.SetBinding(Controls.Views.Barometer.XMagnetometerTextProperty,
                new Binding(nameof(XMagneticField)));
            BarometerView.SetBinding(Controls.Views.Barometer.YMagnetometerTextProperty,
                new Binding(nameof(YMagneticField)));
            BarometerView.SetBinding(Controls.Views.Barometer.ZMagnetometerTextProperty,
                new Binding(nameof(ZMagneticField)));

            Task.Run(UpdateBarometerData);
        }

        public void SetupGyroscope()
        {
            GyroscopeView = new Controls.Views.Gyroscope()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            GyroscopeView.SetBinding(Controls.Views.Gyroscope.XAxisLabelTextProperty,
                new Binding(nameof(MomentumX)));
            GyroscopeView.SetBinding(Controls.Views.Gyroscope.YAxisLabelTextProperty,
                new Binding(nameof(MomentumY)));
            GyroscopeView.SetBinding(Controls.Views.Gyroscope.ZAxisLabelTextProperty,
                new Binding(nameof(MomentumZ)));

            Task.Run(UpdateGyroscopeData);
        }

        public void SetupGps()
        {
            LocationView = new Controls.Views.GPS()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            LocationView.SetBinding(Controls.Views.GPS.LatitudeTextProperty,
                new Binding(nameof(Latitude)));
            LocationView.SetBinding(Controls.Views.GPS.LongitudeTextProperty,
                new Binding(nameof(Longitude)));
            LocationView.SetBinding(Controls.Views.GPS.CountryTextProperty,
                new Binding(nameof(Country)));
            LocationView.SetBinding(Controls.Views.GPS.LocalityTextProperty,
                new Binding(nameof(Locality)));

            Task.Run(UpdateLocationData);
        }

        #endregion

        #region Properties

        [ObservableProperty]
        private ContentView currentView;

        private LoginService _loginService;

        private SensorsService _sensorService;

        
        #region Settings

        [ObservableProperty]
        private bool accelerometerToggled = false;

        [ObservableProperty]
        private bool barometerToggled = false;

        [ObservableProperty]
        private bool gpsToggled = false;

        [ObservableProperty]
        private bool compassToggled = false;

        [ObservableProperty]
        private bool gyroscopeToggled = false;

        [ObservableProperty]
        private ContentView settings;

        #endregion

        #region Acceleration

        [ObservableProperty]
        private ContentView acceleration;

        [ObservableProperty]
        private string accX;

        [ObservableProperty]
        private string accY;

        [ObservableProperty]
        private string accZ;

        #endregion

        #region Barometer

        [ObservableProperty]
        private ContentView barometerView;

        [ObservableProperty]
        private string xMagneticField;

        [ObservableProperty]
        private string yMagneticField;

        [ObservableProperty]
        private string zMagneticField;

        #endregion

        #region Compass

        [ObservableProperty]
        private ContentView compassView;

        [ObservableProperty]
        private string direction;

        #endregion

        #region Location

        [ObservableProperty]
        private ContentView locationView;

        [ObservableProperty]
        private string latitude;

        [ObservableProperty]
        private string longitude;

        [ObservableProperty]
        private string country;

        [ObservableProperty]
        private string locality;

        #endregion

        #region Gyroscope

        [ObservableProperty]
        private ContentView gyroscopeView;

        [ObservableProperty]
        private string momentumX;

        [ObservableProperty]
        private string momentumY;

        [ObservableProperty]
        private string momentumZ;

        #endregion

        #region Home

        [ObservableProperty]
        private ContentView home;

        [ObservableProperty]
        private string user;

        [ObservableProperty]
        private string isAccelerometerAvailable = Accelerometer.IsSupported ? "Accelerometer is supported" : "Accelerometer is not supported";

        [ObservableProperty]
        private string isBarometerAvailable = Magnetometer.IsSupported ? "Magnetometer is supported" : "Magnetometer is not supported";

        [ObservableProperty]
        private string isCompassAvailable = Microsoft.Maui.Devices.Sensors.Compass.IsSupported ? "Compass is supported" : "Compass is not supported";

        [ObservableProperty]
        private string isGyroscopeAvailable = Microsoft.Maui.Devices.Sensors.Gyroscope.IsSupported ? "Gyroscope is supported" : "Gyroscope is not supported";
        
        #endregion

        #endregion

        #region Toggles

        partial void OnAccelerometerToggledChanged(bool value)
        {
            Debug.WriteLine(value ? "Accelerometer toggled on" : "Accelerometer toggled off");


            if (value)
                _sensorService.StartAccelerometer();
            else
                _sensorService.StopAccelerometer();
        }

        partial void OnBarometerToggledChanged(bool value)
        {
            Debug.WriteLine(value ? "Magnetometer toggled on" : "Magnetometer toggled off");


            if (value)
                _sensorService.StartBarometer();
            else
                _sensorService.StopBarometer();
        }

        partial void OnCompassToggledChanged(bool value)
        {
            Debug.WriteLine(value ? "Compass toggled on" : "Compass toggled off");


            if (value)
                _sensorService.StartCompass();
            else
                _sensorService.StopCompass();
        }

        partial void OnGpsToggledChanged(bool value)
        {
            Debug.WriteLine(value ? "GPS toggled on" : "GPS toggled off");


            if (value)
                Task.Run(_sensorService.StartGPS);
            else
                _sensorService.StopListening();
        }

        partial void OnGyroscopeToggledChanged(bool value)
        {
            Debug.WriteLine(value ? "Gyroscope toggled on" : "Gyroscope toggled off");


            if (value)
                _sensorService.StartGyroscope();
            else
                _sensorService.StopGyroscope();
        }

        #endregion

        #region Update data

        public async Task UpdateAccelerometerData()
        {
            IDispatcherTimer timer = Application.Current.Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromSeconds(1);

            timer.Tick += (s, e) =>
            {
                AccX = $"X: {_sensorService.AccelerationReading[0]} G";
                AccY = $"Y: {_sensorService.AccelerationReading[1]} G";
                AccZ = $"Z: {_sensorService.AccelerationReading[2]} G";
            };

            while (true)
            {
                if (AccelerometerToggled && !timer.IsRunning)
                    timer.Start();
                else if (!AccelerometerToggled && timer.IsRunning)
                    timer.Stop();
            }
        }

        public async Task UpdateCompassData()
        {
            IDispatcherTimer timer = Application.Current.Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromSeconds(1);

            timer.Tick += (s, e) =>
            {
                Direction = $"Direction relative to N: {_sensorService.CompassReading} degrees";
            };

            while (true)
            {
                if (CompassToggled && !timer.IsRunning)
                    timer.Start();
                else if (!CompassToggled && timer.IsRunning)
                    timer.Stop();
            }
        }

        public async Task UpdateGyroscopeData()
        {
            IDispatcherTimer timer = Application.Current.Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromSeconds(1);

            timer.Tick += (s, e) =>
            {
                MomentumX = $"X: {_sensorService.GyroscopeReading.X} kg-m^2/s";
                MomentumY = $"Y: {_sensorService.GyroscopeReading.Y} kg-m^2/s";
                MomentumZ = $"Z: {_sensorService.GyroscopeReading.Z} kg-m^2/s";
            };

            while (true)
            {
                if (GyroscopeToggled && !timer.IsRunning)
                    timer.Start();
                else if (!GyroscopeToggled && timer.IsRunning)
                    timer.Stop();
            }
        }

        public async Task UpdateBarometerData()
        {
            IDispatcherTimer timer = Application.Current.Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromSeconds(1);

            timer.Tick += (s, e) =>
            {
                XMagneticField = $"X: {_sensorService.BarometerReading[0]} mt";
                YMagneticField = $"Y: {_sensorService.BarometerReading[1]} mt";
                ZMagneticField = $"Z: {_sensorService.BarometerReading[2]} mt";
            };

            while (true)
            {
                if (BarometerToggled && !timer.IsRunning)
                    timer.Start();
                else if (!BarometerToggled && timer.IsRunning)
                    timer.Stop();
            }
        }

        public async Task UpdateLocationData()
        {
            IDispatcherTimer timer = Application.Current.Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromSeconds(1);

            timer.Tick += (s, e) =>
            {
                Latitude = $"Latitude: {_sensorService.GpsReading.Latitude}";
                Longitude = $"Longitude: {_sensorService.GpsReading.Longitude}";
                Country = $"Country: {_sensorService.GeocodingReading.CountryName}";
                Locality = $"Locality: {_sensorService.GeocodingReading.Locality}";
            };

            while (true)
            {
                if (GpsToggled && !timer.IsRunning)
                    timer.Start();
                else if (!GpsToggled && timer.IsRunning)
                    timer.Stop();
            }
        }

        #endregion

        #region Relay commands

        [RelayCommand]
        private void OnAccelerometerButtonPress()
        {
            Debug.WriteLine("Acceleration button pressed");
            CurrentView = Acceleration;
        }

        [RelayCommand]
        private void OnBarometerButtonPress()
        {
            Debug.WriteLine("Magnetometer button pressed");
            CurrentView = BarometerView;
        }

        [RelayCommand]
        private void OnGPSButtonPress()
        {
            Debug.WriteLine("GPS button pressed");
            CurrentView = LocationView;
        }

        [RelayCommand]
        private void OnGyroscopeButtonPress()
        {
            Debug.WriteLine("Gyroscope button pressed");
            CurrentView = GyroscopeView;
        }

        [RelayCommand]
        private void OnCompassButtonPress()
        {
            Debug.WriteLine("Compass button pressed");
            CurrentView = CompassView;
        }

        [RelayCommand]
        private void OnSettingsButtonPress()
        {
            Debug.WriteLine("Settings button pressed");
            CurrentView = Settings;
        }

        [RelayCommand]
        private void OnHomeButtonPress()
        {
            Debug.WriteLine("Button pressed");
            CurrentView = Home;
        }

        #endregion

    }
}
