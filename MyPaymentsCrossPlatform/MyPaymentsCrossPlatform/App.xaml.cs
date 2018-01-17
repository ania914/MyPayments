using DataLayer;
using MyPaymentsCrossPlatform.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MyPaymentsCrossPlatform
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            
            MainPage = new NavigationPage(new MyPaymentsCrossPlatform.MainPage());
		}

        //static PaymentsDatabase database;
        //public static PaymentsDatabase Database
        //{
        //    get
        //    {
        //        if (database == null)
        //        {
        //            database = new PaymentsDatabase(DependencyService.Get<IFileHelper>()
        //                .GetLocalFilePath("PaymentsLite.db3"));
        //        }
        //        return database;
        //    }
        //}

        static PaymentsContext database;
        public static PaymentsContext Database
        {
            get
            {
                if (database == null)
                {
                    database = new PaymentsContext(DependencyService.Get<IFileHelper>()
                        .GetLocalFilePath("PaymentsLite.db3"));
                }
                return database;
            }
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
