namespace Sensor_Logger.Controls.Views;

public partial class Gyroscope : ContentView
{
    public static readonly BindableProperty XAxisLabelTextProperty =
            BindableProperty.Create(nameof(XAxisLabelText), typeof(string), typeof(Gyroscope), default(string));

    public static readonly BindableProperty YAxisLabelTextProperty =
        BindableProperty.Create(nameof(YAxisLabelText), typeof(string), typeof(Gyroscope), default(string));

    public static readonly BindableProperty ZAxisLabelTextProperty =
        BindableProperty.Create(nameof(ZAxisLabelText), typeof(string), typeof(Gyroscope), default(string));

    public string XAxisLabelText
    {
        get => (string)GetValue(XAxisLabelTextProperty);
        set => SetValue(XAxisLabelTextProperty, value);
    }

    public string YAxisLabelText
    {
        get => (string)GetValue(YAxisLabelTextProperty);
        set => SetValue(YAxisLabelTextProperty, value);
    }

    public string ZAxisLabelText
    {
        get => (string)GetValue(ZAxisLabelTextProperty);
        set => SetValue(ZAxisLabelTextProperty, value);
    }
    public Gyroscope()
	{
		InitializeComponent();
	}
}