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
using SQLite;

namespace Hangman
{
    static class AddWordAndName
    {
        public static string Word;
        public static string Name;
        public static int Id;
        public static int ProfilePic;
        private static int SelectedPicture;
      public static int AssignProfilePic(string PicId)
        {
            switch (PicId)
          {
                case "1":

                  ProfilePic = Resource.Drawable.Stickman1a; 
                  break;

                case "2":

                    ProfilePic = Resource.Drawable.Stickman2a;
                    break;

                case "3":

                    ProfilePic = Resource.Drawable.Stickman3a; 
                    break;

                case "4":

                    ProfilePic = Resource.Drawable.Stickman4a; 
                    break;

                case "5":
                    ProfilePic = Resource.Drawable.Stickman5a;
                    break;

                case "6":

                    ProfilePic = Resource.Drawable.Stickman8;
                    break;

                case "7":

                    ProfilePic = Resource.Drawable.Stickman7b;
                    break;
              
            }
            return ProfilePic;
          
        }

        //private static int ConvertProfileId(int IdPic )
        //{
        //    switch (IdPic)
        //    {
        //        case 1:
        //           = ProfilePic;
        //            break;
        //    }
            
        //}
    }
  
}