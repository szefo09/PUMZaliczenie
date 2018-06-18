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
	public partial class CounterPage : ContentPage
	{
		public CounterPage ()
		{
			InitializeComponent ();
            BindingContext = new CounterViewModel();
		}
	}
}