using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthDrinkBas.Views;
using Xamarin.Forms;

namespace TruthDrinkBas
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool isUsernameEmpty = String.IsNullOrEmpty(UsernameEntry.Text);
            bool isPasswordEmpty = String.IsNullOrEmpty(PasswordEntry.Text);

            if (isUsernameEmpty)
            {
                UsernameEntry.Placeholder = "This can't be empty!";
            }
            else if (isPasswordEmpty)
            {
                PasswordEntry.Placeholder = "This can't be empty!";
            }
            else if (UsernameEntry.Text == "a" && PasswordEntry.Text == "a")
            {
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                _ = DisplayAlert("Ai", "Wrong Username or Password", "Ok");
            }
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page3());
        }


    }
}
