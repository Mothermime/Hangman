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
  public class Profiles
    {[PrimaryKey, AutoIncrement]
       public   int Id{ get; set; }
       public string Name{ get; set; }
       public int ProfilePic { get; set; }
        public int Score { get; set; }
        public string Word { get; set; }
       public string Wordmissed { get; set; }
        public Profiles()
        { }

    }
}