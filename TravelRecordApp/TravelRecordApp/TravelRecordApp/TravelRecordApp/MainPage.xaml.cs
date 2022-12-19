using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void loginButton_Clicked(object sender, EventArgs e)
        {
            var isNotEmptyForm = !string.IsNullOrEmpty(emailEntry.Text) && !string.IsNullOrEmpty(passwordEntry.Text);

            if (isNotEmptyForm)
            {
                Navigation.PushAsync(new HomePage());
            }
            else
            {
                DisplayAlert("Error", "Please write Email and Password", "Ok");
            }

        }
    }
}
