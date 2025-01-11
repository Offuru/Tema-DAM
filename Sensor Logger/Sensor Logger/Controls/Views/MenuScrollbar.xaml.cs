using System.Windows.Input;

namespace Sensor_Logger.Controls.Views;

public partial class MenuScrollbar : ContentView
{
    public static readonly BindableProperty HomeCommandProperty = BindableProperty.Create(
    nameof(HomeCommand),
    typeof(ICommand),
    typeof(MenuScrollbar));

    // BindableProperty for the second button's Command
    public static readonly BindableProperty SettingsCommandProperty = BindableProperty.Create(
        nameof(SettingsCommand),
        typeof(ICommand),
        typeof(MenuScrollbar)
    );

    // Properties to get/set the values
    public ICommand HomeCommand
    {
        get => (ICommand)GetValue(HomeCommandProperty);
        set => SetValue(HomeCommandProperty, value);
    }

    public ICommand SettingsCommand
    {
        get => (ICommand)GetValue(SettingsCommandProperty);
        set => SetValue(SettingsCommandProperty, value);
    }

    public MenuScrollbar()
	{
		InitializeComponent();
	}
}