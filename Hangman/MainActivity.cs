using System;
using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Media;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Provider;
using Android.Util;


namespace Hangman
{

   

    [Activity(Label = "Hangman", MainLauncher = false, Icon = "@drawable/icon", Theme = "@style/Theme.Custom")]
    public class MainActivity : Activity
    {
        //public void MainActivity()
        //{
        //}


        //need to add 'using System' stuff to get this to work
        List<string> DictList = new List<string>();
        Dictionary<string, string> DictOxford = new Dictionary<string, string>();
        private string tag = "aaaaa";
        private Button btnA;
        private Button btnB;
        private Button btnC;
        private Button btnD;
        private Button btnE;
        private Button btnF;
        private Button btnG;
        private Button btnH;
        private Button btnI;
        private Button btnJ;
        private Button btnK;
        private Button btnL;
        private Button btnM;
        private Button btnN;
        private Button btnO;
        private Button btnP;
        private Button btnQ;
        private Button btnR;
        private Button btnS;
        private Button btnT;
        private Button btnU;
        private Button btnV;
        private Button btnW;
        private Button btnX;
        private Button btnY;
        private Button btnZ;
      

        private ImageView IvHangman;
        private EditText txtWord;
    
       
    //    string word = "Hangman";
      
       
        //string[] gamewords = {
        //"active",
        //"forum",
        //"participation",
        //"reward",
        //"ratings"
        //};
       
        //StringWord
       
        //ForI = ((((OT)))??? I = Word.Length
        //
        //fakebutton.Text = Word[]
        //{
        //displayWord[I] = Word[I]
        // }
        private string[] wordsolve;
     
        private int[] GamePics = {Resource.Drawable.Blackboard1, Resource.Drawable.Blackboard2, Resource.Drawable.Blackboard3, Resource.Drawable.Blackboard4, Resource.Drawable.Blackboard5, Resource.Drawable.Blackboard6, Resource.Drawable.Blackboard22, Resource.Drawable.Blackboard21, Resource.Drawable.Blackboard20, Resource.Drawable.Blackboard19, Resource.Drawable.Blackboard18, Resource.Drawable.Blackboard17,Resource.Drawable.Blackboard16, Resource.Drawable.Blackboard15};
        private int wrongGuesses = 0;

        public MainActivity(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public MainActivity()
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Log.Info(tag, "Started to generate tag");
            Initialize();
            LoadDic();
          //  CopyTheDB();
 Random r = new Random();
        }

        private void Initialize()
        { // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            IvHangman = FindViewById<ImageView>(Resource.Id.ivHangman);
            txtWord = FindViewById<EditText>(Resource.Id.txtWord);
            btnA = FindViewById<Button>(Resource.Id.btnA);
            btnB = FindViewById<Button>(Resource.Id.btnB);
            btnC = FindViewById<Button>(Resource.Id.btnC);
            btnD = FindViewById<Button>(Resource.Id.btnD);
            btnE = FindViewById<Button>(Resource.Id.btnE);
            btnF = FindViewById<Button>(Resource.Id.btnF);
            btnG = FindViewById<Button>(Resource.Id.btnG);
            btnH = FindViewById<Button>(Resource.Id.btnH);
            btnI = FindViewById<Button>(Resource.Id.btnI);
            btnJ = FindViewById<Button>(Resource.Id.btnJ);
            btnK = FindViewById<Button>(Resource.Id.btnK);
            btnL = FindViewById<Button>(Resource.Id.btnL);
            btnM = FindViewById<Button>(Resource.Id.btnM);
            btnN = FindViewById<Button>(Resource.Id.btnN);
            btnO = FindViewById<Button>(Resource.Id.btnO);
            btnP = FindViewById<Button>(Resource.Id.btnP);
            btnQ = FindViewById<Button>(Resource.Id.btnQ);
            btnR = FindViewById<Button>(Resource.Id.btnR);
            btnS = FindViewById<Button>(Resource.Id.btnS);
            btnT = FindViewById<Button>(Resource.Id.btnT);
            btnU = FindViewById<Button>(Resource.Id.btnU);
            btnV = FindViewById<Button>(Resource.Id.btnV);
            btnW = FindViewById<Button>(Resource.Id.btnW);
            btnX = FindViewById<Button>(Resource.Id.btnX);
            btnY = FindViewById<Button>(Resource.Id.btnY);
            btnZ = FindViewById<Button>(Resource.Id.btnZ);
            // Get our button from the layout resource,
            // and attach an event to it
            btnA.Click += OnButton_Click;
            btnB.Click += OnButton_Click;
            btnC.Click += OnButton_Click;
            btnD.Click += OnButton_Click;
            btnE.Click += OnButton_Click;
            btnF.Click += OnButton_Click;
            btnG.Click += OnButton_Click;
            btnH.Click += OnButton_Click;
            btnI.Click += OnButton_Click;
            btnJ.Click += OnButton_Click;
            btnK.Click += OnButton_Click;
            btnL.Click += OnButton_Click;
            btnM.Click += OnButton_Click;
            btnN.Click += OnButton_Click;
            btnO.Click += OnButton_Click;
            btnP.Click += OnButton_Click;
            btnQ.Click += OnButton_Click;
            btnR.Click += OnButton_Click;
            btnS.Click += OnButton_Click;
            btnT.Click += OnButton_Click;
            btnU.Click += OnButton_Click;
            btnV.Click += OnButton_Click;
            btnW.Click += OnButton_Click;
            btnY.Click += OnButton_Click;
            btnX.Click += OnButton_Click;
            btnZ.Click += OnButton_Click;

        }
        private string SolvePuzzle(string word)
        {
            string solveWord = word;

            char[] gameWord = word.ToCharArray();

            return word;
        }


     public void OnButton_Click(object sender, EventArgs e)
        {// no matter which button is pressed it will apply 

            Button fakeButton = (Button)sender;
          

                wrongGuesses++;
            if (wrongGuesses < 13)
            {
                //ivProfile.SetImageResource(Resource.Drawable.Stickman2a);
                IvHangman.SetBackgroundResource(GamePics[wrongGuesses]);

            }
           
           
            
            else if (wrongGuesses == 13)
            {
                IvHangman.SetBackgroundResource(GamePics[wrongGuesses]);
                Toast.MakeText(this, "Game over", ToastLength.Long).Show();
                }
                
             
          
            
                
                
            


        }

        //private void guessClick(Object sender, EventArgs e)
        //{

        //}

        // Need to:
        //build the engine of the game  i.e. make it work for one word!
        //have database available
        //get a list of words - dictionary
        //make a string array of gamewords and wordsolve,
        //randomly choose a word from the dictionary and place in txtWord
        //split word into chars
        //replace letters if correctly guessed 
        //make buttons disappear once used
        //replace images in image view for incorrect guesses
        private void CopyTheDB()
        {
            string dbName = "Profiles";
            string dbPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbName);
            // Check if your DB has already been extracted. If the file does not exist move it
            if (!File.Exists(dbPath))
            {

                using (BinaryReader br = new BinaryReader(Assets.Open(dbName)))
                {
                    using (BinaryWriter bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int len = 0;
                        while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            bw.Write(buffer, 0, len);
                        }
                    }
                }
                //       *Log.Info(tag, "DB Copied over");
                //**/   }

                //     Log.Info(tag, "DB Exists - Last log before Events");
            }
        }

        public void LoadDic()
        {
            //need to tie the asset manager to these assets in this project This method can only run under the activity as it doesn't know what Assets is otherwise, this.Assets doesn't work. 
            try
            {
                var assets = Assets;
                using (var sr = new StreamReader(assets.Open("OxfordDicWithDesc.txt")))
                {
                    //while (!sr.EndOfStream)
                    //{
                    //    var text = sr.ReadLine();

                    //    if (text != string.Empty && text.Length > 4) //ignore empty lines or words less than 4 letters
                    //    {
                    //        text = text.Trim();


                    //        var definition = text.Remove(0, text.IndexOf(' ')); //get the def
                    //        var word = text.Remove(text.IndexOf(' '));

                    //        //cut out the stuff you don't want

                    //        if (word.Contains("-"))
                    //        {
                    //            word = word.Replace("-", "");
                    //        }
                    //        if (word.Contains("1"))
                    //        {
                    //            word = word.Replace("1", "");
                    //        }
                    //        if (word.Contains("2"))
                    //        {
                    //            word = word.Replace("2", "");
                    //        }
                    // if (word.Contains("3"))
                    //        {
                    //            word = word.Replace("3", "");
                    //        }
                   // if (word.Contains("4"))
                    //        {
                    //            word = word.Replace("4", "");
                    //        }
                    //        if (definition.Contains("�"))
                    //        {
                    //            //� not working
                    //            definition = definition.Replace("�", "");
                    //        
                      
                    //        word = word.Trim();
                    //        definition = definition.Trim(); //trim off spaces after got length of defn

                        //        if (!DictOxford.ContainsKey(word) && word.Length > 3)
                        //        {
                        //            //if the word is not already there (apparently there is more than 1 and the word is longer than 4 letters)
                        //            DictOxford.Add(word, definition); //load into dictonary
                        //            DictList.Add(word); //add it to list                     
                        //                                // count++; //count how many entries
                        //        }
                        //    }
                        //}
                }
                Log.Info(tag, "Dictionary Loaded");
            }
            catch (Exception)
            {

                Toast.MakeText(this, "Database didn't load", ToastLength.Short).Show();
            }
        }

        private void GenerateWord()
        {
            Log.Info(tag, "GenerateWord");
            Random rand = new Random();
            
        }
        //scoring system start with 13, lose one point for every piece of gallows
    }
}

