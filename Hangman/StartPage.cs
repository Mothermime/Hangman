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
    [Activity(Label = "StartPage", MainLauncher = true, Theme = "@style/Theme.Custom")]
    public class StartPage : Activity
    {//declare variable
        private Button btnStart;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //when the app starts running the layout will be that of the 'Start page' design
            SetContentView(Resource.Layout.StartPage);
            // Create your application here

            //everything has to be tied together - using exactly the same names otherwise nothing works!
            
       btnStart = FindViewById<Button>(Resource.Id.btnStart);
          btnStart.Click += btnStart_Click;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
           StartActivity(typeof(SetProfile));
            //when the button is clicked it starts the page identified ie SetProfile view
        }
    }
}