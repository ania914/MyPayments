using DataLayer;
using System;
using Xamarin.Forms;
using System.Threading.Tasks;

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

        async void addNewAddress()
        {
            var address = new Address() { FullAddress = "Test address" };
            App.Database.Save(address);
            addressListView.ItemsSource = await App.Database.GetAll<Address>(true);
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
        }
    }
}
