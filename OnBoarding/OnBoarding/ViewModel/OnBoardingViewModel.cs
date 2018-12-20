using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using FFImageLoading;
using PanCardView.Extensions;
using OnBoarding.Model;

namespace OnBoarding.ViewModel
{
    public class OnBoardingViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<WelcomeModel> WelcomeDeck { get; }
        public ICommand NextCommand { get; }
        public ICommand SkipCommand { get; }

        private int _currentIndex;
        private string _nextButtonText = "Next";
        public OnBoardingViewModel()
        {
            WelcomeDeck = new ObservableCollection<WelcomeModel>
            {
                new WelcomeModel() { Percentage=0.20, TitleText= "1", CaptionText = "Welcome to IDJoey", ImageUri = "candle.jpeg"},
                new WelcomeModel() { Percentage=0.40, TitleText= "2", CaptionText = "Scan your ID/DL", ImageUri = "shiva.jpg"},
                new WelcomeModel() { Percentage=0.60, TitleText= "3", CaptionText = "Complete your profile", ImageUri = "waterlily.jpeg"},
                new WelcomeModel() { Percentage=0.75, TitleText= "4", CaptionText = "Send verification request", ImageUri = "shiva.jpg"},
                new WelcomeModel() { Percentage=1.0, TitleText= "5", CaptionText = "Await confirmation!", ImageUri = "browser.png"}
            };
                        
            NextCommand = new Command(() =>
            {
                if (NextButtonText.Equals("Done"))
                {
                    CurrentIndex = 0;
                    Application.Current.MainPage.DisplayAlert("Onboarding Complete", "Thank you", "Done");
                    return;
                }
                CurrentIndex++;
            });

            SkipCommand = new Command(() =>
            {
                CurrentIndex = 0;
                Application.Current.MainPage.DisplayAlert("Onboarding Skipped", "Thank you", "OK");
            });
        }

        private void UpdateButtonText()
        {
            if (CurrentIndex == (WelcomeDeck.Count - 1))
            {
                NextButtonText = "Done";
            }
            else
            {
                NextButtonText = "Next";
            }
        }
               
        public string NextButtonText
        {
            get => _nextButtonText;
            set
            {
                _nextButtonText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NextButtonText)));
            }
        }

        public int CurrentIndex
        {
            get => _currentIndex;
            set
            {
                _currentIndex = value;
                UpdateButtonText();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentIndex)));
            }
        }
    }
}
