namespace Sensor_Logger.Controls.Views;

public partial class Compass : ContentView
{
    public static readonly BindableProperty CompassTextProperty =
    BindableProperty.Create(nameof(CompassText), typeof(string), typeof(Compass), default(string));

    public string CompassText
    {
        get => (string)GetValue(CompassTextProperty);
        set => SetValue(CompassTextProperty, value);
    }
    public Compass()
	{
		InitializeComponent();
	}
}