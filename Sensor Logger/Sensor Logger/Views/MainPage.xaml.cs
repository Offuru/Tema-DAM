using Sensor_Logger.ViewModels;

namespace Sensor_Logger.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}