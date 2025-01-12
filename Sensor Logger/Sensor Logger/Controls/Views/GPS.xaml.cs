namespace Sensor_Logger.Controls.Views;

public partial class GPS : ContentView
{
    public static readonly BindableProperty LongitudeTextProperty =
        BindableProperty.Create(nameof(LongitudeText), typeof(string), typeof(GPS), default(string));

    public static readonly BindableProperty LatitudeTextProperty =
        BindableProperty.Create(nameof(LatitudeText), typeof(string), typeof(GPS), default(string));

    public static readonly BindableProperty CountryTextProperty =
        BindableProperty.Create(nameof(CountryText), typeof(string), typeof(GPS), default(string));

    public static readonly BindableProperty LocalityTextProperty =
        BindableProperty.Create(nameof(LocalityText), typeof(string), typeof(GPS), default(string));

    public string LongitudeText
    {
        get => (string)GetValue(LongitudeTextProperty);
        set => SetValue(LongitudeTextProperty, value);
    }

    public string LatitudeText
    {
        get => (string)GetValue(LatitudeTextProperty);
        set => SetValue(LatitudeTextProperty, value);
    }

    public string CountryText
    {
        get => (string)GetValue(CountryTextProperty);
        set => SetValue(CountryTextProperty, value);
    }

    public string LocalityText
    {
        get => (string)GetValue(LocalityTextProperty);
        set => SetValue(LocalityTextProperty, value);
    }

    public GPS()
	{
		InitializeComponent();
	}
}