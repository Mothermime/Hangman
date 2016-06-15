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
using System.IO;
using Android.Util;




namespace Hangman
{
    [Activity(Label = "Scores", Theme = "@style/Theme.Custom")]
    public class Scores : Activity
    {
        private string tag = "aaaaa";
        private ListView lvScores;
        private List<Profiles> myList;
        DatabaseManager myDbManager = new DatabaseManager();
        private Button btnPlayAgain;
        //private Button btnUpdate;
        //private Button btnDelete;
        private int Listid;
        private string Name;
        private int ProfilePic;
        private TextView tvScoreName;
        private ImageView ivScoreProfile;
        private DatabaseManager adjDb;
        Profiles myProfiles = new Profiles();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Scores);
            lvScores = FindViewById<ListView>(Resource.Id.lvScores);
            btnPlayAgain = FindViewById<Button>(Resource.Id.btnPlayAgain);
            btnPlayAgain.Click += btnPlayAgain_Click;
            //btnUpdate = FindViewById<Button>(Resource.Id.btnUpdate);
            //btnUpdate.Click += btnUpdate_Click;
            //btnDelete = FindViewById<Button>(Resource.Id.btnDelete);
            //btnDelete.Click += btnDelete_Click;
            lvScores.ItemClick += OnListScores_Click;
            Log.Info(tag, "resource loaded");
            myList = myDbManager.ViewAll();
            lvScores.Adapter = new DataAdapter(this, myList);
            //myDbManager.DBConnect();
          
          
        }

        private void OnListScores_Click(object sender, AdapterView.ItemClickEventArgs e)
        {
            //    //get the list entry at the position clicked on to EDIT THE ENTRY
            var ScoreItem = myList[e.Position];


            //    //load up the EditProfiles and pass across the data at that place 
         var edititem = new Intent(this, typeof(EditProfiles));

            //PutExtra sends across extra data to the Edititem activity that we created above
           
           
            edititem.PutExtra("name", ScoreItem.Name);
            edititem.PutExtra("Id", ScoreItem.Id);
            edititem.PutExtra("ProfilePic", ScoreItem.ProfilePic);
            //Need to add all fields  even though only the ones above are being edited or they don't show up on the edited entry.
            edititem.PutExtra("Word", ScoreItem.Word);
            edititem.PutExtra("Score", ScoreItem.Score);
            StartActivity(edititem);

        }


 

    }
}