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
    public partial class PostDetail : ContentPage
    {
        Post post;

        public PostDetail(Post selectedPost)
        {
            InitializeComponent();
            post = selectedPost;
            experienceEntry.Text = selectedPost.Experience;
        }

        private void updateButton_Clicked(object sender, EventArgs e)
        {
            post.Experience = experienceEntry.Text;

            using (SQLiteConnection conn = new SQLiteConnection(App.DbLocation))
            {
                conn.CreateTable<Post>();
                var posts = conn.Update(post);

                Navigation.PushAsync(new PostDetail(post));

            }

        }

        private void deleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DbLocation))
            {
                conn.CreateTable<Post>();
                var posts = conn.Delete(post);
            }

            Navigation.PushAsync(new HomePage());

        }
    }
}