using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Hangman
{
    [Activity(Label = "SetProfile", Theme = "@style/Theme.Custom")]
    public class SetProfile : Activity
    {//declare variables - all the different components(objects) to be used 
        private ImageButton ibtnBlue;
        private ImageButton ibtnPink;
        private ImageButton ibtnGreen;
        private ImageButton ibtnRed;
        private ImageButton ibtnPurple;
        private ImageButton ibtnYellow;
        private ImageButton ibtnIndigo;
        private Button btnPlay;
        private ImageView ivProfile;
       static EditText txtName;
        private string tag = "aaaaa";
        private int SelectedPicture;
        public Profiles myProfiles = new Profiles() ;
        DatabaseManager Db = new DatabaseManager();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
           
            // Create your application here
            SetContentView(Resource.Layout.SetProfile);
            //again, set out which view will be used and tie all the components in
            ibtnBlue = FindViewById<ImageButton>(Resource.Id.ibtnBlue);
            ibtnPink = FindViewById<ImageButton>(Resource.Id.ibtnPink);
            ibtnGreen = FindViewById<ImageButton>(Resource.Id.ibtnGreen);
            ibtnRed = FindViewById<ImageButton>(Resource.Id.ibtnRed);
            ibtnPurple = FindViewById<ImageButton>(Resource.Id.ibtnPurple);
            ibtnYellow = FindViewById<ImageButton>(Resource.Id.ibtnYellow);
            ibtnIndigo = FindViewById<ImageButton>(Resource.Id.ibtnIndigo);
            btnPlay = FindViewById<Button>(Resource.Id.btnPlay);
            ivProfile = FindViewById<ImageView>(Resource.Id.ivProfile);

            txtName = FindViewById<EditText>(Resource.Id.txtName);
            txtName.Text = myProfiles.Name; 
            btnPlay.Click += btnPlay_Click;

            //Assign all imageview buttons to one click event
            ibtnBlue.Click += AllColors_Click;
            ibtnPink.Click += AllColors_Click;
            ibtnGreen.Click += AllColors_Click;
            ibtnRed.Click += AllColors_Click;
            ibtnPurple.Click += AllColors_Click;
            ibtnYellow.Click += AllColors_Click;
            ibtnIndigo.Click += AllColors_Click;

        }
       
        private void AllColors_Click(object sender, EventArgs e)
        {
            //Send whichever picture clicked on to the image view
            ImageButton fakeButton =  (ImageButton) sender;
            ivProfile.SetImageResource(AddWordAndName.AssignProfilePic(fakeButton.Tag.ToString()));
           
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Log.Info(tag, "On btnPlayClick");
          
            {
                if  (txtName.Text != "" && ivProfile.Drawable != null)
                {
                 //As long as both name and a profile picture have something in them
                    myProfiles.Name = txtName.Text;
                   AddWordAndName.Name = myProfiles.Name;
                    myProfiles.ProfilePic = AddWordAndName.ProfilePic;
                  
                    //Add to database
                    Db.AddItem( AddWordAndName.Name, AddWordAndName.ProfilePic );

                    //the start the game
                    StartActivity(typeof(MainActivity));
                }
                if (txtName.Text == "" || ivProfile.Drawable == null)
                {//If either or both are empty get a message to request those and don't start game
                    Toast.MakeText(this, "Please enter your name and select a profile picture.", ToastLength.Long).Show();

                    }

                Log.Info(tag, "Profile added");
            }

        }
        //======================================================================== Old Code Below =============================
        //public void SetProfileImage(string picId)
        ////assign all the image ids to a single number to make it easier to use them 
        //{
        //    SelectedPicture = Convert.ToInt16(picId);

        //    switch (picId)
        //    {

        //        case "1":
        //            //stack overflow response to query of how to put an image into an image view
        //            //I had tried ivProfile.Background = (Drawable)Resource.Id.ibtnBlue; and Drawable.Stickman1a (or something like that, both of which appeared good but neither worked!

        //            ivProfile.SetImageResource(Resource.Drawable.Stickman1a);
        //            break;

        //        case "2":

        //            ivProfile.SetImageResource(Resource.Drawable.Stickman2a);
        //            break;

        //        case "3":

        //            ivProfile.SetImageResource(Resource.Drawable.Stickman3a);
        //            break;

        //        case "4":

        //            ivProfile.SetImageResource(Resource.Drawable.Stickman4a);
        //            break;

        //        case "5":
        //            ivProfile.SetImageResource(Resource.Drawable.Stickman5a);
        //            break;

        //        case "6":

        //            ivProfile.SetImageResource(Resource.Drawable.Stickman8);
        //            break;

        //        case "7":

        //            ivProfile.SetImageResource(Resource.Drawable.Stickman7b);
        //            break;
        //        //default view to identify there is an error
        //        default:

        //            Toast.MakeText(this, "Didn't work", ToastLength.Long).Show();
        //            break;
        //    }

        //    {

        //    }
        //}
        public void SelectProfile()
        {
          




        }
    }
}