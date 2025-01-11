using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace Sensor_Logger.Controls.Views;

public partial class SensorsScrollbar : ContentView
{
    public static readonly BindableProperty AccelerometerCommandProperty =
        BindableProperty.Create(
            nameof(AccelerometerCommand),
            typeof(ICommand),
            typeof(SensorsScrollbar));

    public ICommand AccelerometerCommand
    {
        get => (ICommand)GetValue(AccelerometerCommandProperty);
        set => SetValue(AccelerometerCommandProperty, value);
    }

    public static readonly BindableProperty GpsCommandProperty =
        BindableProperty.Create(
            nameof(GpsCommand),
            typeof(ICommand),
            typeof(SensorsScrollbar),
            default(ICommand));

    public ICommand GpsCommand
    {
        get => (ICommand)GetValue(GpsCommandProperty);
        set => SetValue(GpsCommandProperty, value);
    }

    public static readonly BindableProperty BarometerCommandProperty =
        BindableProperty.Create(
            nameof(BarometerCommand),
            typeof(ICommand),
            typeof(SensorsScrollbar),
            default(ICommand));

    public ICommand BarometerCommand
    {
        get => (ICommand)GetValue(BarometerCommandProperty);
        set => SetValue(BarometerCommandProperty, value);
    }

    public static readonly BindableProperty CompassCommandProperty =
        BindableProperty.Create(
            nameof(CompassCommand),
            typeof(ICommand),
            typeof(SensorsScrollbar),
            default(ICommand));

    public ICommand CompassCommand
    {
        get => (ICommand)GetValue(CompassCommandProperty);
        set => SetValue(CompassCommandProperty, value);
    }

    public static readonly BindableProperty GyroscopeCommandProperty =
        BindableProperty.Create(
            nameof(GyroscopeCommand),
            typeof(ICommand),
            typeof(SensorsScrollbar),
            default(ICommand));

    public ICommand GyroscopeCommand
    {
        get => (ICommand)GetValue(GyroscopeCommandProperty);
        set => SetValue(GyroscopeCommandProperty, value);
    }

	public SensorsScrollbar()
	{
		InitializeComponent();
	}
}