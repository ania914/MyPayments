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
