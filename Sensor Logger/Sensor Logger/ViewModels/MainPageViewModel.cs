using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using Sensor_Logger.Controls;
using Sensor_Logger.Controls.Views;
using Sensor_Logger.Models;
using Sensor_Logger.Services;

namespace Sensor_Logger.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        public MainPageViewModel(LoginService loginService)
        {
            _loginService = loginService;
            
            settings = new Settings()
            {
                Username = _loginService.CurrentUser.Username,
            };
            settings.SetBinding(Controls.Views.Settings.AccelerometerToggledProperty,
                new Binding(nameof(AccelerometerToggled), mode: BindingMode.TwoWay));
            settings.SetBinding(Controls.Views.Settings.BarometerToggledProperty,
                new Binding(nameof(BarometerToggled), mode: BindingMode.TwoWay));
            settings.SetBinding(Controls.Views.Settings.GyroscopeToggledProperty,
                new Binding(nameof(GyroscopeToggled), mode: BindingMode.TwoWay));
            settings.SetBinding(Controls.Views.Settings.CompassToggledProperty,
                new Binding(nameof(CompassToggled), mode: BindingMode.TwoWay));
            settings.SetBinding(Controls.Views.Settings.GPSToggledProperty,
                new Binding(nameof(GpsToggled), mode: BindingMode.TwoWay));
        }

        #region Properties

        [ObservableProperty]
        private ContentView currentView;

        private LoginService _loginService;

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

        partial void OnAccelerometerToggledChanged(bool value)
        {
            Debug.WriteLine(value ? "Toggled on" : "Toggled off");
        }

        #region Relay commands

        [RelayCommand]
        private void OnAccelerometerButtonPress()
        {
            Debug.WriteLine("Button pressed");
            CurrentView = new ContentView
            {
                Content = new Label { Text = "Accelerometer" },
            };
        }

        [RelayCommand]
        private void OnBarometerButtonPress()
        {
            Debug.WriteLine("Button pressed");
            CurrentView = new ContentView
            {
                Content = new Label { Text = "Barometer" },
            };
        }

        [RelayCommand]
        private void OnGPSButtonPress()
        {
            Debug.WriteLine("Button pressed");
            CurrentView = new ContentView
            {
                Content = new Label { Text = "GPS" },
            };
        }

        [RelayCommand]
        private void OnGyroscopeButtonPress()
        {
            Debug.WriteLine("Button pressed");
            CurrentView = new ContentView
            {
                Content = new Label { Text = "Gyroscope" },
            };
        }

        [RelayCommand]
        private void OnCompassButtonPress()
        {
            Debug.WriteLine("Button pressed");
            CurrentView = new ContentView
            {
                Content = new Label { Text = "Compass" },
            };
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
            CurrentView = new ContentView
            {
                Content = new Label { Text = "Home" },
            };
        }

        #endregion
    }
}
