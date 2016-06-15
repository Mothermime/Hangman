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
            Log.Info(tag, "Db connected");
        }

        public List<Profiles> ViewAll()
        {
            try
            {
                //SQLiteConnection db = new SQLiteConnection(System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), "Scoring.sqlite"));

                return db.Query<Profiles>("select Id, ProfilePic, Name, Word, Score from Profiles order by Score Desc ");
            }
            catch (Exception e)
            {
                Log.Info(tag, "ERROR Did the DB move across??:" + e.Message);
                return null;
            }
        }

       public void DBConnect()
        {
            try
            {
                db =
                new SQLiteConnection(System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(),
                    "Profiles.sqlite"));
               


            }
            catch (Exception e)
            {

                Log.Info(tag, "ERROR Did the connection work??:" + e.Message);
            }
           
        }

        public void AddItem( string Name, int ProfilePic)
        {
            Log.Info(tag, "AddItem Name = " + Name  + " AddItem ProfilePic = " + ProfilePic);

            try
            {
                var AddThis = new Profiles
                {
                    
                 Name = Name,
                 //Score = Score,
                 //Word = myProfiles.Word,
                 ProfilePic = ProfilePic
                };

                db.Insert(AddThis);

              // db.Execute("INSERT INTO Profiles(ProfilePic, Name, Word, Score)// VALUES(?1,? 2,? 3))
                Log.Info(tag, "Data Added " + AddThis);

            }
            catch (Exception e)
            {
                Log.Info(tag, "Add Error:  " + e.Message);
            }
        }

      public void EditItem( string Name, string Word, int Score, int Id, int ProfilePic)
           // public void EditItem(string Name,  int Id, int ProfilePic)
        {

            Log.Info(tag, "EditProfile Name = " + Name);
            try
            {
                //http://stackoverflow.com/questions/14007891/how-are-sqlite-records-updated


              //  int profilePic = 0;
                var EditThis = new Profiles
                {
                    Id = Id,
                   
                    Name = Name,
                    Score = Score,
                    Word = Word,
                    ProfilePic =  ProfilePic,
                   
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

       public void addScore( int Score, string Word, String Name, int ProfilePic)
       {
            Log.Info(tag, " AddItem Score = " + Score, "AddItem Word = " + Word);

            try
            {
                var AddScore = new Profiles
                {
                //Id =Id,
                 Score = Score,
                 Word = Word,
                 Name = Name,
                 ProfilePic = ProfilePic,
                
                };

                db.Insert(AddScore);

              // db.Execute("INSERT INTO Profiles(ProfilePic, Name, Word, Score)// VALUES(?1,? 2,? 3))
                Log.Info(tag, "Score Added " + AddScore);

            }
            catch (Exception e)
            {
                Log.Info(tag, "Add Error:  " + e.Message);
            }
        }
       }

    }



    
