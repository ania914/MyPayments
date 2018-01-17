using DataLayer;
using MyPaymentsCrossPlatform.EF;
using System;
using System.Diagnostics;
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
                var service = new EFService<Address>();
                var utilityService = new EFService<UtilityBill>();
                await service.Insert(address);
                await utilityService.Insert(utility);
                addressListView.ItemsSource =  await service.GetAll();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
        }
    }
}
