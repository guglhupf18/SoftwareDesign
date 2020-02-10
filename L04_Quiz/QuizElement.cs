using System;
using System.Collections.Generic;
using System.Text;

namespace L04_Quiz
{
    
    class QuizElement
    {
        public string question;
        bool answered = false;

        public bool alreadyAnswered()
        {
            return answered;
        }
        public void answerQuestion()
        {
            answered = true;
        }

        public void displayQuestion()
        {
            Console.WriteLine(question);
        }
    }
}
