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
using Android.Util;

namespace Hangman
{
    //class EditProfile
    //{
        [Activity(Label = "Edit Name or Profile Picture")]
        public class EditProfiles : Activity
        {
            private int ListId;
            private string Name;
            private int ProfilePic;
            private int Score;
            private string Word;
            private EditText txtEditName;
            private ImageView ivEditProfile;
            private Button btnUpdate;
            private Button btnDelete;
            private DatabaseManager adjDb ;
            private string tag = "aaaaa";
        private ImageButton ibtnBlue;
        private ImageButton ibtnPink;
        private ImageButton ibtnGreen;
        private ImageButton ibtnRed;
        private ImageButton ibtnPurple;
        private ImageButton ibtnYellow;
        private ImageButton ibtnIndigo;

        protected override void OnCreate(Bundle bundle)
            {//All sorts of different requirements 
                base.OnCreate(bundle);
                SetContentView(Resource.Layout.EditProfile);
            txtEditName = FindViewById<EditText>(Resource.Id.txtEditName);
            ivEditProfile = FindViewById<ImageView>(Resource.Id.ivEditProfile);
                btnUpdate = FindViewById<Button>(Resource.Id.btnUpdate);
                btnDelete = FindViewById<Button>(Resource.Id.btnDelete);
                btnUpdate.Click += OnBtnUpdateClick;
                btnDelete.Click += OnBtnDeleteClick;
            ibtnBlue = FindViewById<ImageButton>(Resource.Id.ibtnBlue);
            ibtnPink = FindViewById<ImageButton>(Resource.Id.ibtnPink);
            ibtnGreen = FindViewById<ImageButton>(Resource.Id.ibtnGreen);
            ibtnRed = FindViewById<ImageButton>(Resource.Id.ibtnRed);
            ibtnPurple = FindViewById<ImageButton>(Resource.Id.ibtnPurple);
            ibtnYellow = FindViewById<ImageButton>(Resource.Id.ibtnYellow);
            ibtnIndigo = FindViewById<ImageButton>(Resource.Id.ibtnIndigo);

            
            ibtnBlue.Click += AllColors_Click;
            ibtnPink.Click += AllColors_Click;
            ibtnGreen.Click += AllColors_Click;
            ibtnRed.Click += AllColors_Click;
            ibtnPurple.Click += AllColors_Click;
            ibtnYellow.Click += AllColors_Click;
            ibtnIndigo.Click += AllColors_Click;

            ListId = Intent.GetIntExtra("Id", 0);
               
                Name = Intent.GetStringExtra("name");
            Score = Intent.GetIntExtra("Score", 0);
            Word = Intent.GetStringExtra("Word");
                Log.Info(tag, "ListID " + ListId +  " Name " + Name + " ProfilePic " + ProfilePic);
            txtEditName.Text = Name;
             
                adjDb = new DatabaseManager();//adj = adjusted
           }
            private void AllColors_Click(object sender, EventArgs e)
            {//same as for SetProfile view - send picture of button chow=sen to an image view
                ImageButton fakeButton = (ImageButton) sender;
                ivEditProfile.SetImageResource(AddWordAndName.AssignProfilePic(fakeButton.Tag.ToString()));

            }
        private void OnBtnUpdateClick(object sender, EventArgs e)
        {
            try
            {//List all fields and make sure they are the same as in the Database class parameters

                adjDb.EditItem(txtEditName.Text, Word, Score, ListId, AddWordAndName.ProfilePic);
                  
                Toast.MakeText(this,"Name edited", ToastLength.Short).Show();
                this.Finish();
                StartActivity(typeof(Scores));
                }
            catch (Exception ex)
            {
                Toast.MakeText(this,"Error editing" + ex.Message, ToastLength.Short).Show();
              
            }
        }
        private void OnBtnDeleteClick(object sender, EventArgs e)
            {
            //Get rid of entire entry at the Id listed
                try
                {
                   adjDb.DeleteItem(ListId);
                    Toast.MakeText(this, "Player Deleted", ToastLength.Long).Show();
                    this.Finish();
                //then go back to the Scores view
                    StartActivity(typeof(Scores));
                }
                catch (Exception ex)
                {
                    Log.Info(tag, "Delete Error listid = " + ListId + " " + ex.Message.ToString());
                }
            }
        }
  //  }
}