using CommunityToolkit.Mvvm.ComponentModel;
using System.Text.Json.Serialization;

namespace Sensor_Logger.Models
{
    public partial class User : ObservableObject
    {
        [property: JsonPropertyName("username")]
        [ObservableProperty]
        private string username;

        [property: JsonPropertyName("password")]
        [ObservableProperty]
        private string password;

        public User(string username = "N/A", string password = "N/A")
        {
            Username = username;
            Password = password;
        }

        public override bool Equals(object? obj)
        {
            if(obj == null || obj.GetType() != typeof(User))
                return false;

            var other = obj as User;
            return other.Username == Username;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Username, Password);
        }
    }
}
