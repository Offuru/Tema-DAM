using System.Numerics;

namespace Sensor_Logger.Controls.Views;

public partial class Acceleration : ContentView
{
    public static readonly BindableProperty XAxisLabelTextProperty =
            BindableProperty.Create(nameof(XAxisLabelText), typeof(string), typeof(Acceleration), default(string));

    public static readonly BindableProperty YAxisLabelTextProperty =
        BindableProperty.Create(nameof(YAxisLabelText), typeof(string), typeof(Acceleration), default(string));

    public static readonly BindableProperty ZAxisLabelTextProperty =
        BindableProperty.Create(nameof(ZAxisLabelText), typeof(string), typeof(Acceleration), default(string));

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

    public Acceleration()
    {
        InitializeComponent();
    }
}


