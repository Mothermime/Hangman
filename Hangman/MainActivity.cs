using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using Javax.Security.Auth;


namespace Hangman
{
    [Activity(Label = "Hangman", MainLauncher = false, Icon = "@drawable/icon", Theme = "@style/Theme.Custom")]
    public class MainActivity : Activity
    {
        //need to add 'using System' stuff to get this to work
        private List<string> WordList = new List<string>();
        //  Dictionary<string, string> HangmanDic = new Dictionary<string, string>();
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
        private TextView tvWord;
        private char[] GameBlank;
        private char[] gameWord;
        int counter = 130;
        private string word;
        private string GameWord;
        private char letter;
        Profiles myProfiles = new Profiles();
       // private char guessedletter;

       // private string[] solveword;
        //int LengthOfArray = wordsolve.Length;
        private int[] GamePics =
        {
            Resource.Drawable.Blackboard1, Resource.Drawable.Blackboard2,
            Resource.Drawable.Blackboard3, Resource.Drawable.Blackboard4, Resource.Drawable.Blackboard5,
            Resource.Drawable.Blackboard6, Resource.Drawable.Blackboard22, Resource.Drawable.Blackboard21,
            Resource.Drawable.Blackboard20, Resource.Drawable.Blackboard19, Resource.Drawable.Blackboard18,
            Resource.Drawable.Blackboard17, Resource.Drawable.Blackboard16, Resource.Drawable.Blackboard15
        };

        private int wrongGuesses = 0;

        //public MainActivity(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        //{
        //}

        //public MainActivity()
        //{
        //}

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Log.Info(tag, "Started to generate tag");
            Initialize();
            LoadDic();
            CopyTheDB();
            GenerateWord();
      

        }

        private void Initialize()
        {
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            IvHangman = FindViewById<ImageView>(Resource.Id.ivHangman);
         tvWord = FindViewById<TextView>(Resource.Id.tvWord);
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


  public void OnButton_Click(object sender, EventArgs e)
        {
//for each letter in the word does the button letter match the word letter if yes change screen if no draw gallows
            // no matter which button is pressed it will apply 

            Button fakeButton = (Button) sender;

            letter = Convert.ToChar(fakeButton.Text.ToLower());
            fakeButton.Enabled = false;
            DisplayWord();
            Button choice = sender as Button;
           if (!GameBlank.Contains('_'))
            {
             Toast.MakeText(this, "Well done!" +  " Score:" + counter , ToastLength.Long).Show();
                StartActivity(typeof(Scores));
            }
              if (!gameWord.Contains(letter))
            {
                BuildGallows();
            }
             
        }

        //private void Score()
        //{
            
        //}
        private void BuildGallows()
        {
          
            wrongGuesses++;
           
            if (wrongGuesses < 13)
            {
               //display the different pictures in sequence for each successive wrong guess
                IvHangman.SetBackgroundResource(GamePics[wrongGuesses]);
                counter = counter - 10;
            }
            
            else if (wrongGuesses == 13)
            {//put up the last picture and display a message to say the game is over
                IvHangman.SetBackgroundResource(GamePics[wrongGuesses]);
                Toast.MakeText(this, "Game over.  " + "The word was . " + new string(gameWord) + "  Score: " + counter, ToastLength.Long).Show();
                StartActivity(typeof(Scores));
              counter = 0;
            }
           
            myProfiles.Score = counter;
            
            //for (int i = 13; i >= 0; i--)
            //{
           myProfiles.Score = counter;
            // }
        }

      
        private void CopyTheDB()
        {
            string dbName = "Profiles.sqlite";
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
            } Log.Info(tag, "Db Loaded");
        }

        public void LoadDic()
        {
            //need to tie the asset manager to these assets in this project This method can only run under the activity as it doesn't know what Assets is otherwise, this.Assets doesn't work. 
            try
            {//get list from assets file and read it
                var assets = Assets;
                using (var sr = new StreamReader(assets.Open("EnglishWords.txt")))//make sure the .txt part of the file name is there or it doesn't work!!!
                {
                    while (!sr.EndOfStream)
                        //keep reading and adding as long as the end of the string hasn't been reached
                    {
                          string text = sr.ReadLine();
                    WordList.Add(text);
                    }
                }
                Log.Info(tag, "Dictionary Loaded");
                //Yeeha, I've got this far!
            }
            catch (Exception)
            {
                Toast.MakeText(this, "Database didn't load", ToastLength.Short).Show();
            }
        }
        private void GenerateWord()
        {//Pick a random word to use in game
            Random rand = new Random();
            int RndNumber = rand.Next(1, WordList.Count);
            // return RndNumber between the first and however many letters there are in the list;
            Log.Info(tag, "RndNumber " + RndNumber);
            //make a tag to help with debugging
            string Word = WordList[RndNumber];
            //the word at whichever random number is picked
            gameWord = Word.ToCharArray();
            //convert it to an array of letters
            GameBlank = new char[gameWord.Length];
            //the same length as the word
            Log.Info(tag, "GenerateWord");

            for (int i = 0; i < GameBlank.Length; i++)
            {  //loop through the chars in the word and convert them to underscores
               GameBlank[i] = '_';
                //show in text field
               tvWord.Text += "_ ";
                           
                    Log.Info(tag, "Word loaded");
                //show where I am up to on log
            }
        }
        private string DisplayWord()
        {//the series of dashes on screen
            int counter = 0;
            for (int i = 0; i < GameBlank.Length; i++)
            {
//loop through the length of the word
                if (letter == gameWord[i])
                {
//to see if the letter matches in the same place
                    GameBlank[i] = letter;
                }
                //then put it in
                tvWord.Text = "";
            }
            foreach (char element in GameBlank)
                {//with a gap between letters!
                    tvWord.Text += (element + " ");
                }

                Log.Info(tag, "Word implemented");
                //locked and loaded, ready to go
            
           // tvWord.Text = new string(GameBlank); 
            return word;
            
      }


       

       
       

    }
}

