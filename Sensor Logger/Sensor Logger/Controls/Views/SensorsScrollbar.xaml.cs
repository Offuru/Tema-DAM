using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace Sensor_Logger.Controls.Views;

public partial class SensorsScrollbar : ContentView
{
    public static readonly BindableProperty AccelerometerCommandProperty =
        BindableProperty.Create(
            nameof(AccelerometerCommand),
            typeof(Command),
            typeof(SensorsScrollbar),
            default(Command));

    public Command AccelerometerCommand
    {
        get => (Command)GetValue(AccelerometerCommandProperty);
        set => SetValue(AccelerometerCommandProperty, value);
    }

    public static readonly BindableProperty GpsCommandProperty =
        BindableProperty.Create(
            nameof(GpsCommand),
            typeof(Command),
            typeof(SensorsScrollbar),
            default(Command));

    public Command GpsCommand
    {
        get => (Command)GetValue(GpsCommandProperty);
        set => SetValue(GpsCommandProperty, value);
    }

    public static readonly BindableProperty BarometerCommandProperty =
        BindableProperty.Create(
            nameof(BarometerCommand),
            typeof(Command),
            typeof(SensorsScrollbar),
            default(Command));

    public Command BarometerCommand
    {
        get => (Command)GetValue(BarometerCommandProperty);
        set => SetValue(BarometerCommandProperty, value);
    }

    public static readonly BindableProperty CompassCommandProperty =
        BindableProperty.Create(
            nameof(CompassCommand),
            typeof(Command),
            typeof(SensorsScrollbar),
            default(Command));

    public Command CompassCommand
    {
        get => (Command)GetValue(CompassCommandProperty);
        set => SetValue(CompassCommandProperty, value);
    }

    public static readonly BindableProperty GyroscopeCommandProperty =
        BindableProperty.Create(
            nameof(GyroscopeCommand),
            typeof(Command),
            typeof(SensorsScrollbar),
            default(Command));

    public Command GyroscopeCommand
    {
        get => (Command)GetValue(GyroscopeCommandProperty);
        set => SetValue(GyroscopeCommandProperty, value);
    }

    private ICommand? accelerometerCommand;
	public SensorsScrollbar()
	{
		InitializeComponent();
	}
}