using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                App.Database.Save(address);
                addressListView.ItemsSource = await App.Database.GetAll<Address>();
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
