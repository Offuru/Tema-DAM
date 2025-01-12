using CommunityToolkit.Mvvm.ComponentModel;
using System.Numerics;

namespace Sensor_Logger.Services
{
    public partial class SensorsService : ObservableObject
    {
        #region Properties
        [ObservableProperty]
        private Vector3 accelerationReading;

        [ObservableProperty]
        private Vector3 barometerReading;

        [ObservableProperty]
        private double compassReading;

        [ObservableProperty]
        private Location gpsReading = new();

        [ObservableProperty]
        private Vector3 gyroscopeReading;

        [ObservableProperty]
        private Placemark geocodingReading = new();

        private CancellationTokenSource _cts = new CancellationTokenSource();
        private bool _isListening = false;

        #endregion

        #region Accelereometer
        public void StartAccelerometer()
        {
            if (Accelerometer.IsMonitoring)
                return;
            Accelerometer.ReadingChanged += OnAccelerometerReadingChanged;
            Accelerometer.Start(SensorSpeed.UI);
        }

        public void StopAccelerometer()
        {
            if (Accelerometer.IsMonitoring)
            {
                Accelerometer.Stop();
                Accelerometer.ReadingChanged -= OnAccelerometerReadingChanged;
            }
        }

        public void OnAccelerometerReadingChanged(object? sender, AccelerometerChangedEventArgs e)
        {
            AccelerationReading = e.Reading.Acceleration;
        }
        #endregion

        #region Barometer

        public void StartBarometer()
        {
            if (Magnetometer.IsMonitoring)
                return;
            Magnetometer.ReadingChanged += OnBarometerReadingChanged;
            Magnetometer.Start(SensorSpeed.UI);
        }
        
        public void StopBarometer()
        {
            if (Magnetometer.IsMonitoring)
            {
                Magnetometer.Stop();
                Magnetometer.ReadingChanged -= OnBarometerReadingChanged;
            }
        }

        public void OnBarometerReadingChanged(object? sender, MagnetometerChangedEventArgs e)
        {
           BarometerReading = e.Reading.MagneticField;
        }

        #endregion

        #region Gyroscope

        public void StartGyroscope()
        {
            if (Gyroscope.IsMonitoring)
                return;
            Gyroscope.ReadingChanged += OnGyroscopeReadingChanged;
            Gyroscope.Start(SensorSpeed.UI);
        }

        public void StopGyroscope()
        {
            if (Gyroscope.IsMonitoring)
            {
                Gyroscope.Stop();
                Gyroscope.ReadingChanged -= OnGyroscopeReadingChanged;
            }
        }

        public void OnGyroscopeReadingChanged(object? sender, GyroscopeChangedEventArgs e)
        {
            GyroscopeReading = e.Reading.AngularVelocity;
        }

        #endregion

        #region Compass

        public void StartCompass()
        {
            if (Compass.IsMonitoring)
                return;
            Compass.ReadingChanged += OnCompassReadingChanged;
            Compass.Start(SensorSpeed.UI);
        }

        public void StopCompass()
        {
            if (Compass.IsMonitoring)
            {
                Compass.Stop();
                Compass.ReadingChanged -= OnCompassReadingChanged;
            }
        }

        public void OnCompassReadingChanged(object? sender, CompassChangedEventArgs e)
        {
            CompassReading = e.Reading.HeadingMagneticNorth;
        }

        #endregion

        #region GPS

        public async Task StartGPS()
        {
            if (_isListening)
                return;

            _isListening = true;

            try
            {
                while (_isListening)
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(1));
                    var location = await Geolocation.Default.GetLocationAsync(request, _cts.Token);

                    if (location != null)
                    {
                        GpsReading = location;
                        GeocodingReading = (await Geocoding.Default.GetPlacemarksAsync(location))?.FirstOrDefault();
                    }

                    await Task.Delay(1000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error listening for location updates: {ex.Message}");
            }
        }

        public void StopListening()
        {
            _isListening = false;
            _cts?.Cancel();
            _cts = new CancellationTokenSource();
        }

        #endregion
    }
}
