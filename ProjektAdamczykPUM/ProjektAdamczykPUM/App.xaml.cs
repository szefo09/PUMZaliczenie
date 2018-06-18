using ProjektAdamczykPUM.Data;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProjektAdamczykPUM.Services.Interfaces;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace ProjektAdamczykPUM
{
	public partial class App : Application
	{
        private static LocalDB localDB;
        public static LocalDB LocalDB
        {
            get
            {
                if (localDB == null)
                {
                    var fileHelper = DependencyService.Get<IFileHelper>();
                    var fileName = fileHelper.GetLocalFilePath("App.db3");
                    localDB = new LocalDB(fileName);
                }
                return localDB;
            }
        }
        public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new Views.MenuPage());
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
