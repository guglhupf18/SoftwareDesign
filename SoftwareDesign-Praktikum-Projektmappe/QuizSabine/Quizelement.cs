using System;
using System.Collections.Generic;
using System.Text;

namespace QuizSabine
{
    class Quizelement
    {
        public string question = "";
        public List<string> wrongAnswers = new List<string>();
        public string correctAnswer = "";

        public void display()
        {
            
            Console.WriteLine("Please answer the question.");
            Console.WriteLine("\n" + Quizspiel.qList[Quizspiel.answeredQuestions].question);

            for (int i = 0; i < wrongAnswers.Count; i++)
            {
                Console.WriteLine(i + 1 + ": " + wrongAnswers[i] + "\n");
            }
            var input = Console.ReadLine();

            if (evaluate(input))
            {
                Console.WriteLine("Your answer was correct");
                Quizspiel.score++;
                Quizspiel.answeredQuestions++;
            }
            else
            {
                Console.WriteLine("Your answer was not correct");
            }
            
               
        }   

        public bool evaluate(string answer)
        {
            if (answer == correctAnswer)
                return true;
            else
                return false;

        }
    }

    
}
