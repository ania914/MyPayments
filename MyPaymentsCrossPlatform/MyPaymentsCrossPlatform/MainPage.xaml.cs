using DataLayer;
using System;
using Xamarin.Forms;

namespace MyPaymentsCrossPlatform
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                var address = new Address() { FullAddress = "Test address" };
                var utility = new UtilityBill() { IdAddress = 1, Address = address, IsConstant = false, Name = "bh" };
                App.Database.Save(address);
                App.Database.Save(utility);
                addressListView.ItemsSource = await App.Database.GetAll<Address>(true);
            }
            catch (Exception ex)
            {

            }
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
        }
    }
}
