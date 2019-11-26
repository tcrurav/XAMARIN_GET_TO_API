using System;
using Xamarin.Forms;

namespace AppXamarinCrud
{
	public partial class BicycleListPage : ContentPage
	{
		public BicycleListPage()
		{
            InitializeComponent();
		}

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();

			listView.ItemsSource = await App.BicycleManager.GetTasksAsync ();
		}

		async void OnAddItemClicked (object sender, EventArgs e)
		{
            await Navigation.PushAsync(new BicyclePage(true)
            {
                BindingContext = new Bicycle
                {
                    //ID = Guid.NewGuid().ToString()
                }
            });
		}

		async void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
            await Navigation.PushAsync(new BicyclePage
            {
                BindingContext = e.SelectedItem as Bicycle
            });
		}
	}
}
