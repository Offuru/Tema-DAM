using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor_Logger.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ContentView currentView;

        [RelayCommand]
        private void ChangeToAccelerometer()
        {
            Debug.WriteLine("Button pressed");
            CurrentView = new ContentView
            {
                Content = new Label { Text = "I'm Content!" },
            };
        }
    }
}
