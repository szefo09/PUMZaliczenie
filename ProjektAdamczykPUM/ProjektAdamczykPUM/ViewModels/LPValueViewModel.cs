using ProjektAdamczykPUM.Models.Sqlite;
using ProjektAdamczykPUM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjektAdamczykPUM.ViewModels
{
	public class LPValueViewModel : BaseViewModel
	{
        public int Value { get; set; }
        public PlayerLP P { get; set; }
        public Command LpChange { get; set; }
        public int Amount { get; set; }
        public string Sign { get; set; }
		public LPValueViewModel (string player, bool decrease)
		{
            FindPlayer(player);

            if (decrease)
            {
                Sign = "-";
            }
            else
            {
                Sign = "+";
            }
            RaisePropertyChanged(nameof(String));
            
            LpChange = new Command(() => {
                try
                {
                    if (decrease) {
                        P.Value = P.Value - Amount;
                        if (P.Value < 0)
                        {
                            P.Value=0;
                        }
                    }
                    else
                    {
                        P.Value = P.Value + Amount;
                    }
                   
                    SaveValue(P);
                    NavigateBack();
                }
                catch (Exception)
                {
                    Amount = 0;
                }
            }); 
		}
        async private void FindPlayer(string player)
        {
            P = await App.LocalDB.GetPlayerByID(int.Parse(player));
        }
        async private void NavigateBack()
        {
            await NavigationService.NavigateTo(new CounterPage());
        }
        async private void SaveValue(PlayerLP player)
        {
            await App.LocalDB.SaveItemAsync<PlayerLP>(player);
        }
	}
}