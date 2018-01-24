using DataLayer;
using MyPaymentsCrossPlatform.DependencyServices;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyPaymentsCrossPlatform.layouts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddressDialog : ContentPage
	{
        public AddressDialog ()
		{
			InitializeComponent ();
        }

        private async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void OnOKButtonClicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(EnteredAddress.Text))
            {
                DependencyService.Get<IToastMessage>().LongAlert("Address must not be empty!");
                return;
            }
            var address = new Address() { FullAddress = EnteredAddress.Text };
            var id = await App.Database.Save(address);
            // Add default utility bills
            var water = new UtilityBill() { Address = address, IdAddress = id, Name = "Water" };
            var gas = new UtilityBill() { Address = address, IdAddress = id, Name = "Gas" };
            var electricity = new UtilityBill() { Address = address, IdAddress = id, Name = "Electricity" };
            await Navigation.PopModalAsync();
        }
    }
}