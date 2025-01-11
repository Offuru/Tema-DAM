namespace Sensor_Logger.Controls.Views;

public partial class Settings : ContentView
{
    public static readonly BindableProperty UsernameProperty = BindableProperty.Create(
            nameof(Username),
            typeof(string),
            typeof(Settings),
            string.Empty
        );

    public static readonly BindableProperty AccelerometerToggledProperty = BindableProperty.Create(
        nameof(AccelerometerToggled),
        typeof(bool),
        typeof(Settings),
        false
    );

    public static readonly BindableProperty BarometerToggledProperty = BindableProperty.Create(
        nameof(BarometerToggled),
        typeof(bool),
        typeof(Settings),
        false
    );

    public static readonly BindableProperty CompassToggledProperty = BindableProperty.Create(
        nameof(CompassToggled),
        typeof(bool),
        typeof(Settings),
        false
    );

    public static readonly BindableProperty GyroscopeToggledProperty = BindableProperty.Create(
        nameof(GyroscopeToggled),
        typeof(bool),
        typeof(Settings),
        false
    );

    public static readonly BindableProperty GPSToggledProperty = BindableProperty.Create(
        nameof(GPSToggled),
        typeof(bool),
        typeof(Settings),
        false
    );

    public string Username
    {
        get => (string)GetValue(UsernameProperty);
        set => SetValue(UsernameProperty, value);
    }

    public bool AccelerometerToggled
    {
        get => (bool)GetValue(AccelerometerToggledProperty);
        set => SetValue(AccelerometerToggledProperty, value);
    }

    public bool BarometerToggled
    {
        get => (bool)GetValue(BarometerToggledProperty);
        set => SetValue(BarometerToggledProperty, value);
    }

    public bool CompassToggled
    {
        get => (bool)GetValue(CompassToggledProperty);
        set => SetValue(CompassToggledProperty, value);
    }

    public bool GyroscopeToggled
    {
        get => (bool)GetValue(GyroscopeToggledProperty);
        set => SetValue(GyroscopeToggledProperty, value);
    }

    public bool GPSToggled
    {
        get => (bool)GetValue(GPSToggledProperty);
        set => SetValue(GPSToggledProperty, value);
    }
    public Settings()
	{
		InitializeComponent();
	}
}