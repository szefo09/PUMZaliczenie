using ProjektAdamczykPUM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjektAdamczykPUM.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LPValuePage : ContentPage
	{
        public string player;
		public LPValuePage (string player,bool decraese)
		{
            this.player = player;
			InitializeComponent ();
            BindingContext = new LPValueViewModel(player,decraese);
		}
	}
}