using System;
using System.Collections.Generic;
using System.Text;

namespace L04_Quiz
{
    
    class QuizElement
    {
        public string question = "";
        public List<string> answers = new List<string>();
        public int correctAnswer = 0;

        public void displayQuestion(string message)
        {
            Console.WriteLine(question);
        }

    }
}
