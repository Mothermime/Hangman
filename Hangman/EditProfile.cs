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
            {
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
             //  ivEditProfile.Selected.ToString() = ProfilePic.ToString();
                

                adjDb = new DatabaseManager();
           }
            private void AllColors_Click(object sender, EventArgs e)
            {
                ImageButton fakeButton = (ImageButton) sender;
                ivEditProfile.SetImageResource(AddWordAndName.AssignProfilePic(fakeButton.Tag.ToString()));

            }
        private void OnBtnUpdateClick(object sender, EventArgs e)
        {
            try
            {
                adjDb.EditItem(txtEditName.Text, Word, Score, ListId, AddWordAndName.ProfilePic);
                     // adjDb.EditItem(txtEditName.Text,  ListId, AddWordAndName.ProfilePic);
                //         adjDb.EditItem("aaa", 1, 45678);
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
                try
                {
                   adjDb.DeleteItem(ListId);
                    Toast.MakeText(this, "Player Deleted", ToastLength.Long).Show();
                    this.Finish();
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