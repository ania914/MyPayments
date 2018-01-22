using Android.Widget;
using MyPaymentsCrossPlatform.DependencyServices;
using MyPaymentsCrossPlatform.Droid.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidToastMessage))]
namespace MyPaymentsCrossPlatform.Droid.Interfaces
{
    public class AndroidToastMessage : IToastMessage
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }
    }
}