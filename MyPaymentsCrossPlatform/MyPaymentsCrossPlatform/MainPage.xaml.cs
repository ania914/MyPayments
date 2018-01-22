using DataLayer;
using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using MyPaymentsCrossPlatform.layouts;

namespace MyPaymentsCrossPlatform
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            FloatingActionButtonAdd.Command = new Command(addNewAddress);
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //var address = new Address() { FullAddress = "Test address" };
            //var utility = new UtilityBill() { IdAddress = 1, Address = address, IsConstant = false, Name = "bh" };
            //App.Database.Save(address);
            //App.Database.Save(utility);
            addressListView.ItemsSource = await App.Database.GetAll<Address>(true);
        }

        async void addNewAddress()
        {
            var newAddressPage = new AddressDialog();
            await Navigation.PushModalAsync(newAddressPage);
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
        }
    }
}
