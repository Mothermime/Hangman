using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Hangman
{
    [Activity(Label = "Scores", Theme = "@style/Theme.Custom")]
    public class Scores : Activity
    {
        private Button btnPlayAgain;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Scores);

            btnPlayAgain = FindViewById<Button>(Resource.Id.btnPlayAgain);
            btnPlayAgain.Click += btnPlayAgain_Click;
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}