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
        //All the stuff I need - ingredients!
        private string tag = "aaaaa";
        private ListView lvScores;
        private List<Profiles> myList;
        DatabaseManager myDbManager = new DatabaseManager();
        private Button btnPlayAgain;
        private Button btnNewPlayer;
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

            
            SetContentView(Resource.Layout.Scores);

            // The stuff that will show on the opening of the view
            lvScores = FindViewById<ListView>(Resource.Id.lvScores);
            btnPlayAgain = FindViewById<Button>(Resource.Id.btnPlayAgain);
            btnPlayAgain.Click += btnPlayAgain_Click;
            btnNewPlayer = FindViewById<Button>(Resource.Id.btnNewPlayer);
            btnNewPlayer.Click += btnNewPlayer_Click;
            lvScores.ItemClick += OnListScores_Click;
            Log.Info(tag, "resource loaded");
            myList = myDbManager.ViewAll();
            lvScores.Adapter = new DataAdapter(this, myList);
           
          
          
        }

        private void btnNewPlayer_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(StartPage));
        }

        private void OnListScores_Click(object sender, AdapterView.ItemClickEventArgs e)
        {
            //    //get the list entry at the position clicked on to EDIT THE ENTRY
            var ScoreItem = myList[e.Position];


            //    //load up the EditProfiles and pass across the data at that place 
         var edititem = new Intent(this, typeof(EditProfiles));

            //'PutExtra' sends across extra data to the Edititem activity that we created above
           
           edititem.PutExtra("name", ScoreItem.Name);
            edititem.PutExtra("Id", ScoreItem.Id);
            edititem.PutExtra("ProfilePic", ScoreItem.ProfilePic);

            //All fields need to be listed to make sure they are all included in the update
            edititem.PutExtra("Word", ScoreItem.Word);
            edititem.PutExtra("Score", ScoreItem.Score);
            StartActivity(edititem);

        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            //goes back to the game
            StartActivity(typeof(MainActivity));
        }

    }
}