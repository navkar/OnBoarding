using OnBoarding.Model;
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
	public partial class TwoChoices : ContentPage
	{
        public TwoChoices ()
        {
	        InitializeComponent ();
        }
                
        void OptionsListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var lv = sender as ListView;
            if (lv != null)
            {
                lv.SelectedItem = null;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var itemsList = new List<OptionsModel>();
            itemsList.Add(new OptionsModel() { OptionColor = "#D39D38", OptionText = "Buyer", ImageUri = "buyer.png" });
            itemsList.Add(new OptionsModel() { OptionColor = "#4DA0B0", OptionText = "Grower", ImageUri = "grower.png" });
            OptionsListView.ItemsSource = itemsList;
        }
    }
}