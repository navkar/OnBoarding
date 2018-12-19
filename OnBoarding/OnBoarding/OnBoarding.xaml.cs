using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnBoarding
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OnBoarding : ContentPage
	{
        //https://stackoverflow.com/questions/23201134/transparent-argb-hex-value
        public OnBoarding ()
		{
			InitializeComponent ();
        }
	}
}