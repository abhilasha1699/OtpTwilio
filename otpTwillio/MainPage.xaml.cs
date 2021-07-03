using System;
using Xamarin.Forms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace otpTwillio
{
    public partial class MainPage : ContentPage
    {
        public string recentOtp;
        public MainPage()
        {
            InitializeComponent();

            const string accountId = "ACdc5e9e6958c53fe49a01a20374e6e060";
            const string authToken = "c06b209c4b266cc4db570780a765b81b";

            TwilioClient.Init(accountId, authToken);
            Random random = new Random();
            string randopOTP = random.Next(0, 9999).ToString();
            //string phNo = "+91" + phoneNumber.Text;

            var message = MessageResource.Create(
                body: "Your OTP is:" + randopOTP,
                from: new Twilio.Types.PhoneNumber("+16615230137"),
                to: new Twilio.Types.PhoneNumber("+919404642198")
                );

            recentOtp = randopOTP;
            
        }

        private void submit_Clicked(object sender, EventArgs e)
        {
            if (otpEntry.Text == recentOtp)
            {
                App.Current.MainPage.DisplayAlert("Genrerated OTP!", "Verified", "OK");
                //await Navigation.PushAsync(new secondPage());
                Navigation.PushAsync(new secondPage());
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Alert", "Please input the correct OTP", "OK");
            }

        }
    }
}
