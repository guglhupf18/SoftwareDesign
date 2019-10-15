using System;

namespace L01_Buchstabendreher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte einen kleinen Satz eingeben");
            Console.Write("> ");
            var text = Console.ReadLine();
            string letters = ReverseLetters(text);
            //string words = ReverseWords(text);
            string sentence = ReverseSentence(text);
            Console.WriteLine(sentence + "\n" /*+ words + "\n" */ + letters);
        }

        static string ReverseLetters(string text)
        {
            Console.WriteLine("Hi");
             char [] letters = text.ToCharArray();
            Array.Reverse(letters);
            return new String(letters);
        }



   /*     static string ReverseSentence(string text)
        {
            char[] c = text.ToCharArray();
            Array.Reverse(c);
            return new string(c);
        }
        */
        static string ReverseWords(string text){
            string [] words = text.Split(" ");
            Array.Reverse(words);

            string wordsreversed = string.Join(" ", words); 
            return wordsreversed; 
        }

         static string ReverseSentence(string text)
        {
            //first I reverse the letters than i reverse the words

            text = ReverseLetters(text);
            return ReverseWords(text);
        }
    }
}
