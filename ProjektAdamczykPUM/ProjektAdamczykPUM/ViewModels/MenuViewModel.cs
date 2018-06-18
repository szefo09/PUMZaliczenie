using ProjektAdamczykPUM.Data;
using ProjektAdamczykPUM.Models.Sqlite;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjektAdamczykPUM.ViewModels
{
    public class MenuViewModel : BaseViewModel
	{
        public Command ToMenuCommand { get; set; }
        public Command Alert { get; set; }
        public MenuViewModel()
        {
           
          
            ToMenuCommand = new Command(() =>
            {  
                Navigate(); 
                //await Application.Current.MainPage.DisplayAlert("Sorry", "You loose :(", "Ok");
            });
        }
         async private void Navigate()
        {
            await NavigationService.NavigateTo(new Views.CounterPage());
        }
        async public void DB()
        {
            try
            {
                var players = await App.LocalDB.GetItems<PlayerLP>();
            }
            catch (Exception e)
            {
                //await Application.Current.MainPage.DisplayAlert("Sorry", e.ToString(), "Ok");
                var players = new List<PlayerLP>();
               players.Add(new PlayerLP() { Value = 8000 });
               players.Add(new PlayerLP() {Value = 8000 });
               await App.LocalDB.SaveItemAsync<PlayerLP>(players[0]);
               await App.LocalDB.SaveItemAsync<PlayerLP>(players[1]);
            }
        }
    }
}