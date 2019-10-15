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
            char[] c = text.ToCharArray();
            char[] testArray = new char[c.Length];
            string word = "";
            int index = 0;
            int pivot = 0;
            // 
            for (int i = 0; i < c.Length; i++)
            {
                if (!char.IsWhiteSpace(c[i]))
                {
                    testArray[i] = c[i];
                }
                else
                {
                    pivot = i;
                    Array.Reverse(c, index, pivot);
                    word += new string(testArray);
                    index = pivot;
                }
            }
            return new string(word);
        }

        static string ReverseSentence(string text)
        {
            char[] c = text.ToCharArray();
            Array.Reverse(c);
            return new string(c);
        }
    }
}
