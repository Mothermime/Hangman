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
        {//List all of the database data in order of highest scores down - make sure scores in the database are an int not a varchar
            try
            {
                return db.Query<Profiles>("select Id, ProfilePic, Name, Word, Score from Profiles order by Score Desc ");
            }
            catch (Exception e)
            {
                Log.Info(tag, "ERROR Did the DB move across??:" + e.Message);
                return null;
            }
        }

       public void DBConnect()
        {//connect to the database
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
        {//Add the name and picture from Set Profiles
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

              
                Log.Info(tag, "Data Added " + AddThis);

            }
            catch (Exception e)
            {
                Log.Info(tag, "Add Error:  " + e.Message);
            }
        }

      public void EditItem( string Name, string Word, int Score, int Id, int ProfilePic)
           
        {
            //caused me huge problems but I got there!
            // need all the fields to go through to the final edit to ensure that even the bits not edited show again

            Log.Info(tag, "EditProfile Name = " + Name);
            try
            {
                //http://stackoverflow.com/questions/14007891/how-are-sqlite-records-updated
                
                var EditThis = new Profiles
                {
                    Id = Id,
                   
                    Name = Name,
                    Score = Score,
                    Word = Word,
                    ProfilePic =  ProfilePic,
                   
                };

                db.Update(EditThis);

               

            }
            catch (Exception e)
            {

                Log.Info(tag, "Update Error:" + e.Message.ToString());

            }
        }

        public void DeleteItem(int listid)
        {//Gone!!
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
            //For when the game is over to add the word and score to the database for the player who had the profile on main activity
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



    
