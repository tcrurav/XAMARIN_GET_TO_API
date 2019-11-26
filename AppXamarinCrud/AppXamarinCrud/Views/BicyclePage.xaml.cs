using System;
using Xamarin.Forms;

namespace AppXamarinCrud
{
	public partial class BicyclePage : ContentPage
	{
		bool isNewItem;

		public BicyclePage (bool isNew = false)
		{
            InitializeComponent();
			isNewItem = isNew;
		}

		async void OnSaveButtonClicked (object sender, EventArgs e)
		{
			var bicycle = (Bicycle)BindingContext;
			await App.BicycleManager.SaveTaskAsync (bicycle, isNewItem);
			await Navigation.PopAsync ();
		}

		async void OnDeleteButtonClicked (object sender, EventArgs e)
		{
			var bicycle = (Bicycle)BindingContext;
			await App.BicycleManager.DeleteTaskAsync (bicycle);
			await Navigation.PopAsync ();
		}

		async void OnCancelButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PopAsync ();
		}
	}
}
