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
        List<string> WordList = new List<string>();
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
        private EditText txtWord;
        private char[] GameBlank;
        private char[] gameWord;
        string word;
        private string displayWord;
      char letter ;
       
       
        private string[] solveword;
        //int LengthOfArray = wordsolve.Length;
        private int[] GamePics = {Resource.Drawable.Blackboard1, Resource.Drawable.Blackboard2, Resource.Drawable.Blackboard3, Resource.Drawable.Blackboard4, Resource.Drawable.Blackboard5, Resource.Drawable.Blackboard6, Resource.Drawable.Blackboard22, Resource.Drawable.Blackboard21, Resource.Drawable.Blackboard20, Resource.Drawable.Blackboard19, Resource.Drawable.Blackboard18, Resource.Drawable.Blackboard17,Resource.Drawable.Blackboard16, Resource.Drawable.Blackboard15};
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
            DisplayWord();
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
       

        public void OnButton_Click(object sender, EventArgs e)
        {
            // no matter which button is pressed it will apply 
           
            Button fakeButton = (Button) sender;
           
           if (fakeButton.Text == letter.ToString())//if the text on whichever button is pressed matches a letter in the word
           {
                InsertLetter();
          
           }
            BuildGallows();
             fakeButton.Enabled = false;
           
        }

        private void InsertLetter()
        { for (int i = 0; i < GameBlank.Length; i++)
            {
                if (letter == gameWord[i])
                {
                    GameBlank[i] = letter;
                   
                }
            } DisplayWord();
  Log.Info(tag, "letter replacement");
        }

       
        private void BuildGallows()
        { 
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

        // Need to:

        // ##build the engine of the game, make the gallows work
        //make it work for one word!
        //##have database available
        //##get a list of words - dictionary
        //make a string array of gamewords and wordsolve,
        //randomly choose a word from the dictionary and place in txtWord
        //##split word into chars
        //replace letters if correctly guessed 
        //make buttons disappear once used
        //##replace images in image view for incorrect guesses
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
            {
                var assets = Assets;
                using (var sr = new StreamReader(assets.Open("HangmanDic.txt")))
                {
                    while (!sr.EndOfStream)
                    {
                          string text = sr.ReadLine();
                    WordList.Add(text);
                    }
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
            Random rand = new Random();
            int RndNumber = rand.Next(1, WordList.Count);

            Log.Info(tag, "RndNumber " + RndNumber);
            // return RndNumber;

            string Word = WordList[RndNumber];

            gameWord = Word.ToCharArray();
            GameBlank = new char[gameWord.Length];
            Log.Info(tag, "GenerateWord");

            for (int i = 0; i < GameBlank.Length; i++)
            {
                             GameBlank[i] = '_';
               txtWord.Text += "_ ";
                    //              foreach (char letter in GameBlank)
                    //              {
                    //                  txtWord.Text += (letter +" " );
                    //              }

                    //          }
                    Log.Info(tag, "working here");

            }
           
        }

        private string DisplayWord()
        {
            for (int i = 0; i < GameBlank.Length; i++)
            {


                if (letter == gameWord[i])
                {
                    GameBlank[i] = letter;
                }

             //   GameBlank[i] = '_';
                // DisplayWord();
                //foreach (char letter in GameBlank)
                //{
                //    txtWord.Text += (letter + " ");
                //}

            }


            //for (int i = 0; i < GameBlank.Length; i++)
            //{
            //    txtWord.Text += GameBlank[i];
            //}


          //  txtWord.Text = Convert.ToString(GameBlank);
            //string displayword = word;
            //char[] gameWord = word.ToCharArray();

            //foreach (char letter in gameWord)
            //{

            //}



            return word;
      }

        private void setupWordChoice()
        {
            wrongGuesses = 0;
             IvHangman.SetBackgroundResource(GamePics[wrongGuesses]);

        }
       

        //scoring system start with 13, lose one point for every piece of gallows
       
       

    }
}

