using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
   static class Profiles
    {[PrimaryKey, AutoIncrement]
    public static int Id{ get; set; }
       public static string Name{ get; set; }
       public static string ProfilePic { get; set; }
       public static int Score { get; set; }
       
       public static string Wordmissed { get; set; }
    }
}