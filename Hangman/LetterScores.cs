using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Hangman
{
    class LetterScores
    {
     public  static char Letter;
        public static string Word;
       private static int counter;
        public static int LetterValue(char letter)
        {
            switch ( letter)
            {
                case 'e': case 'a': case 'i': case 'o': case 'u': case 'n': case 'r': case 't': case 'l': case 's':
                    return 1;
                case 'd': case 'g':
                    return 2;
                case 'b': case 'c': case 'm': case 'p':
                    return 3;
                case 'f': case 'h': case 'v': case 'w': case 'y':
                    return 4;
                case 'k':
                    return 5;
                case 'j': case 'x':
                    return 8;
                case 'q': case 'z':
                    return 10;
            }

            return 0;

        }

        public static int WordScore(string Word)
        {
            int Abacus = 0; 
                
            foreach (char letter in Word)
            { 
                Abacus += LetterValue(letter);
            }
            return Abacus;
        }
    }
   
            
}
