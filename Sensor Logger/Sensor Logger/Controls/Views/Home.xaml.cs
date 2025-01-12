namespace Sensor_Logger.Controls.Views;

public partial class Home : ContentView
{
    public static readonly BindableProperty UserTextProperty =
            BindableProperty.Create(nameof(UserText), typeof(string), typeof(Home), default(string));

    public static readonly BindableProperty AccelerometerSupportedTextProperty =
        BindableProperty.Create(nameof(AccelerometerSupportedText), typeof(string), typeof(Home), default(string));

    public static readonly BindableProperty BarometerSupportedTextProperty =
        BindableProperty.Create(nameof(BarometerSupportedText), typeof(string), typeof(Home), default(string));

    public static readonly BindableProperty CompassSupportedTextProperty =
        BindableProperty.Create(nameof(CompassSupportedText), typeof(string), typeof(Home), default(string));

    public static readonly BindableProperty GyroscopeSupportedTextProperty =
        BindableProperty.Create(nameof(GyroscopeSupportedText), typeof(string), typeof(Home), default(string));

    public string UserText
    {
        get => (string)GetValue(UserTextProperty);
        set => SetValue(UserTextProperty, value);
    }

    public string AccelerometerSupportedText
    {
        get => (string)GetValue(AccelerometerSupportedTextProperty);
        set => SetValue(AccelerometerSupportedTextProperty, value);
    }

    public string BarometerSupportedText
    {
        get => (string)GetValue(BarometerSupportedTextProperty);
        set => SetValue(BarometerSupportedTextProperty, value);
    }

    public string CompassSupportedText
    {
        get => (string)GetValue(CompassSupportedTextProperty);
        set => SetValue(CompassSupportedTextProperty, value);
    }

    public string GyroscopeSupportedText
    {
        get => (string)GetValue(GyroscopeSupportedTextProperty);
        set => SetValue(GyroscopeSupportedTextProperty, value);
    }
    public Home()
	{
		InitializeComponent();
	}
}