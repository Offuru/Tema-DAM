namespace Sensor_Logger.Controls.Views;

public partial class Barometer : ContentView
{

    public static readonly BindableProperty XMagnetometerTextProperty =
        BindableProperty.Create(nameof(XMagnetometerText), typeof(string), typeof(Barometer), default(string));

    public static readonly BindableProperty YMagnetometerTextProperty =
        BindableProperty.Create(nameof(YMagnetometerText), typeof(string), typeof(Barometer), default(string));

    public static readonly BindableProperty ZMagnetometerTextProperty =
        BindableProperty.Create(nameof(ZMagnetometerText), typeof(string), typeof(Barometer), default(string));

    public string XMagnetometerText
    {
        get => (string)GetValue(XMagnetometerTextProperty);
        set => SetValue(XMagnetometerTextProperty, value);
    }

    public string YMagnetometerText
    {
        get => (string)GetValue(YMagnetometerTextProperty);
        set => SetValue(YMagnetometerTextProperty, value);
    }

    public string ZMagnetometerText
    {
        get => (string)GetValue(ZMagnetometerTextProperty);
        set => SetValue(ZMagnetometerTextProperty, value);
    }

    public Barometer()
	{
		InitializeComponent();
	}
}