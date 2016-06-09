using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SQLite;
namespace Hangman
{
   public class DatabaseManager
    {
        private string tag = "aaaaa";
        SQLiteConnection db;

      Profiles myProfiles = new Profiles();

        public  DatabaseManager()
        {
            DBConnect();           
        }

        public List<Profiles> ViewAll()
        {
            try
            {
                //SQLiteConnection db = new SQLiteConnection(System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), "Scoring.sqlite"));

                return db.Query<Profiles>("select * from PlayerScores1");
            }
            catch (Exception e)
            {
                Log.Info(tag, "ERROR Did the DB move across??:" + e.Message);
                return null;
            }
        }

        private void DBConnect()
        {
            db =
                new SQLiteConnection(System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(),
                    "Profiles.sqlite"));
        }

        public void AddItem()
        {

           
            Log.Info(tag, "AddItem Name = " + myProfiles.Name +" AddItem Score = " + myProfiles.Score + " AddItem Word = " + myProfiles.Word);

            try
            {
                var AddThis = new Profiles
                {
                 Name = myProfiles.Name,
                   Score = myProfiles.Score,
                   Word = myProfiles.Word,
                   ProfilePic = myProfiles.ProfilePic
                };

                db.Insert(AddThis);

                //   db.Execute("INSERT INTO Profiles(name, score, word) VALUES(?1,? 2,? 3))
                Log.Info(tag, "Data Added " + AddThis);

            }
            catch (Exception e)
            {
                Log.Info(tag, "Add Error:  " + e.Message);
            }
        }

        public void EditItem(string name, int score, string word, int id)
        {
            try
            {
                //http://stackoverflow.com/questions/14007891/how-are-sqlite-records-updated


                var EditThis = new Profiles
                {
                    Id = id,
                    Name = name,
                   Score = score,
                   Word = word
                };

                db.Update(EditThis);

                //or this
                //  db.Execute("UPDATE scoring Set name = ?, score =, WHERE ID = ?", name, score, word, id);

            }
            catch (Exception e)
            {

                Log.Info(tag, "Update Error:" + e.Message.ToString());

            }
        }

        public void DeleteItem(int listid)
        {
            //https://developer.xamarin.com/guides/cross-platform/application_fundamentals/data/part_3_using_sqlite_orm/
            try
            {
                db.Delete<Profiles>(listid);

            }
            catch (Exception ex)
            {
                Log.Info(tag, "Delete Error:" + ex.Message);
            }
        }

    }
}


    
