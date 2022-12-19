using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        private void SavePost_Clicked(object sender, EventArgs e)
        {
            var post = new Post()
            {
                Experience = experienceEntry.Text
            };


            using (SQLiteConnection conn = new SQLiteConnection(App.DbLocation))
            {

                conn.CreateTable<Post>();
                int rows = conn.Insert(post);

                if (rows == 0) DisplayAlert("Error", "Error inserting", "Ok");
                else {DisplayAlert("Success", "Exprience Inserted", "OK"); Navigation.PushAsync(new HomePage());
                }
            }
 


        }
    }
}