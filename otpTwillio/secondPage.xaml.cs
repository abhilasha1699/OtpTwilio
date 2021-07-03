using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace otpTwillio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class secondPage : ContentPage
    {
        private int count = 0;
        private string[] quotes = new string[]{ 
            "Almost everything in the night sky gives off light. Even if we can't see it, the light is still there.",
            "The fear you let build up in your mind is worse than the situation that actually exists",
            "When you change what you believe, you change what you do.",
            "The biggest inhibitor to change lies within yourself, and that nothing gets better until you change."
        };
        public secondPage()
        {
            InitializeComponent();
            quoteLabel.Text = quotes[count];
        }

        private void appInfo_Clicked(object sender, EventArgs e)
        {
            var appName = AppInfo.Name;
            var packageName = AppInfo.PackageName;
            var version = AppInfo.Version;
            var build = AppInfo.BuildString;

            AppInfo.ShowSettingsUI();
        }

        private void deviceDisplay_Clicked(object sender, EventArgs e)
        {
            resultDisplay.Text = DeviceDisplay.MainDisplayInfo.ToString();
        }

        private async void shareText_Clicked(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = entryShare.Text,
                Title = "Share!"
            });
        }

        private void nextQuote_Clicked(object sender, EventArgs e)
        {
            count++;

            if (count == quotes.Length)
            {
                count = 0;
            }

            quoteLabel.Text = quotes[count];
        }

        private async void textToSpeech_Clicked(object sender, EventArgs e)
        {
            await TextToSpeech.SpeakAsync(entryText.Text, new SpeechOptions
            {
                Volume = (float)sliderVolume.Value
            });
        }
    }
}