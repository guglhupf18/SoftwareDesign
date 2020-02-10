using System;
using System.Collections.Generic;
using System.Text;

namespace L04_Quiz
{
    class SingleAnswerQuestion : QuizElement
    {
        public List<string> answers;
        public string correctAnswer;

        public SingleAnswerQuestion()
        {
            answers = new List<string>();
            correctAnswer = new string("");
        }

        public void displayQuestion()
        {
            base.displayQuestion();
            for (int i =0; i<=answers.Count;i++)
               Console.WriteLine(answers[i]);
        }
    }
}
