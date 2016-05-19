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
    [Activity(Label = "SetProfile", Theme = "@style/Theme.Custom")]
    public class SetProfile : Activity
    {
        private ImageButton ibtnBlue;
        private ImageButton ibtnPink;
        private ImageButton ibtnGreen;
        private ImageButton ibtnRed;
        private ImageButton ibtnPurple;
        private ImageButton ibtnYellow;
        private ImageButton ibtnIndigo;
        private Button btnPlay;
        private ImageView ivProfile;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SetProfile);

            ibtnBlue = FindViewById<ImageButton>(Resource.Id.ibtnBlue);
            ibtnPink = FindViewById<ImageButton>(Resource.Id.ibtnPink);
            ibtnGreen = FindViewById<ImageButton>(Resource.Id.ibtnGreen);
            ibtnRed = FindViewById<ImageButton>(Resource.Id.ibtnRed);
            ibtnPurple = FindViewById<ImageButton>(Resource.Id.ibtnPurple);
            ibtnYellow = FindViewById<ImageButton>(Resource.Id.ibtnYellow);
            ibtnIndigo = FindViewById<ImageButton>(Resource.Id.ibtnIndigo);
            btnPlay = FindViewById<Button>(Resource.Id.btnPlay);
            ivProfile = FindViewById<ImageView>(Resource.Id.ivProfile);
            btnPlay.Click += btnPlay_Click;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
           StartActivity(typeof(MainActivity));
        }
    }
}