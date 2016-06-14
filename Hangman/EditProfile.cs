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
            private EditText txtEditName;
            private ImageView ivScoreProfilePic;
            private Button btnUpdate;
            private Button btnDelete;
            private DatabaseManager adjDb ;
            private string tag = "aaaaa";
       
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
                SetContentView(Resource.Layout.EditProfile);
            txtEditName = FindViewById<EditText>(Resource.Id.txtEditName);
                ivScoreProfilePic = FindViewById<ImageView>(Resource.Id.ivScoreProfile);
                btnUpdate = FindViewById<Button>(Resource.Id.btnUpdate);
                btnDelete = FindViewById<Button>(Resource.Id.btnDelete);

                btnUpdate.Click += OnBtnUpdateClick;
                btnDelete.Click += OnBtnDeleteClick;

                ListId = Intent.GetIntExtra("Id", 0);
               
                Name = Intent.GetStringExtra("name");
           
                Log.Info(tag, "ListID " + ListId +  " Name " + Name + " ProfilePic " + ProfilePic);
            txtEditName.Text = Name;
               // ivScoreProfilePic.Selected.ToString() = ProfilePic.ToString();
                

                adjDb = new DatabaseManager();
            }

        private void OnBtnUpdateClick(object sender, EventArgs e)
        {
            try
            {
                adjDb.EditItem(txtEditName.Text, ListId);
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