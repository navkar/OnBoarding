using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnBoarding
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            LoadingActivity.IsRunning = true;
            Task.Delay(5000);
            var itemsList = new List<string>();
            for(int i =0; i<100; i++)
            {
                itemsList.Add(DateTime.UtcNow.Ticks.ToString());
            }
            TimeDataListView.ItemsSource = itemsList;

            LoadingActivity.IsRunning = false;
            LoadingActivity.IsVisible = false;
        }

        void TimeDataListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var lv = sender as ListView;
            if (lv != null)
            {
                lv.SelectedItem = null;
            }
        }

        void TimeDataListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            TimeDataListView.SelectedItem = null;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            button.BackgroundColor = Color.Accent;
        }
    }
}
