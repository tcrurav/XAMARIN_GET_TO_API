using Xamarin.Forms;

namespace AppXamarinCrud
{
	public static class Constants
	{
        // The iOS simulator can connect to localhost. However, Android emulators must use the 10.0.2.2 special alias to your host loopback interface.
        public static string BaseAddress = Device.RuntimePlatform == Device.Android ? "http://192.168.0.155:40089" : "http://192.168.0.155:40089";
        public static string BicyclesUrl = BaseAddress + "/api/bicycles/{0}";
    }
}
