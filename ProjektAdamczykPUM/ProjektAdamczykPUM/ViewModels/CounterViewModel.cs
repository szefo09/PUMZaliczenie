using ProjektAdamczykPUM.Models.Sqlite;
using ProjektAdamczykPUM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ProjektAdamczykPUM.ViewModels
{
	public class CounterViewModel : BaseViewModel
	{
        public int LP1 { get; private set; }
        public int LP2 { get; private set; }
        public Command LpRed { get; set; }//reduce LP
        public Command LpInc { get; set; }//increase LP
        public Command DiceRoll { get; set; }
        public Command CoinFlip { get; set; }
        public Command Reset { get; set; }
        PlayerLP P1 { get; set; }
        PlayerLP P2 { get; set; }
    public CounterViewModel ()
		{
            GetPlayersFromDB();
            LpRed = new Command<string> (LPReduce);
            LpInc= new Command<string>(LPIncreace);
            DiceRoll = new Command(Dice);
            CoinFlip = new Command(Coin);
            Reset = new Command(ResetDuel);
        }
        private async void ResetDuel()
        {
            P1.Value = 8000;
            P2.Value = 8000;
            await App.LocalDB.SaveItemAsync<PlayerLP>(P1);
            await App.LocalDB.SaveItemAsync<PlayerLP>(P2);
            LP1 = P1.Value;
            LP2 = P2.Value;
            RaisePropertyChanged(nameof(LP1));
            RaisePropertyChanged(nameof(LP2));
        }
        private async void Dice()
        {
            
            await Application.Current.MainPage.DisplayAlert("DiceRoll Result:",Random(7).ToString(), "Ok");
        }
        private async void Coin()
        {
            if (Random(3) % 2 == 0)
            {
                await Application.Current.MainPage.DisplayAlert("CoinFlip Result:","Tails", "Ok");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("CoinFlip Result:", "Heads", "Ok");
            }
        }
        private int Random(int i)
        {
            Random rnd = new Random();
            return rnd.Next(1, i);
        }
        private async void GetPlayersFromDB() {

            P1 = await App.LocalDB.GetPlayerByID(1);
            P2 = await App.LocalDB.GetPlayerByID(2);
            if (P1 == null)
            {
                P1 = new PlayerLP { ID = 1, Value = 8000 };
                await App.LocalDB.SaveItemAsync<PlayerLP>(P1);
            }
            if (P2 == null)
            {
                P2 = new PlayerLP { ID = 2, Value = 8000 };
                await App.LocalDB.SaveItemAsync<PlayerLP>(P2);
            }
            LP1 = P1.Value;
            LP2 = P2.Value;
            RaisePropertyChanged(nameof(LP1));
            RaisePropertyChanged(nameof(LP2));
        }
        public CounterViewModel(int lp1, int lp2)
        {
            LP1 = lp1;
            LP2 = lp2;
            LpRed = new Command<string>(LPReduce);
            LpInc = new Command<string>(LPIncreace);
        }
         async void LPReduce(string player)
        {
            if (player == "1")
            {
                await App.LocalDB.SaveItemAsync<PlayerLP>(P1);
                await NavigationService.NavigateTo(new LPValuePage(player,true));
            }
            else
            {
                await App.LocalDB.SaveItemAsync<PlayerLP>(P2);
                await NavigationService.NavigateTo(new LPValuePage(player, true));
            }
        }
         async void LPIncreace(string player)
        {
            if (player == "1")
            {
                await App.LocalDB.SaveItemAsync<PlayerLP>(P1);
                await NavigationService.NavigateTo(new LPValuePage(player, false));
            }
            else
            {
                await App.LocalDB.SaveItemAsync<PlayerLP>(P2);
                await NavigationService.NavigateTo(new LPValuePage(player, false));
            }
        }


    }
}