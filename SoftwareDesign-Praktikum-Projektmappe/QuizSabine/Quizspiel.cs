using System;
using System.Collections.Generic;
namespace QuizSabine
{
    class Quizspiel

    {
        public static List<Quizelement> qList = new List<Quizelement>();
        static bool running = true;
        public static int score;
        public static int answeredQuestions = 0;
        static void Main(string[] args)
        {
            score = 0;
            Console.WriteLine("Please choose: \n 1. Answer question \n 2. Add new question \n 3. Exit");
            while (running)
            {
                var input = Int32.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        var qe = new Quizelement();
                        qe.display();
                        break;
                    case 2:
                        addQuestion();
                        break;
                    case 3:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("invalid input");
                        break;

                }
            }

        }


        static void addQuestion()
        {
            Quizelement qe = new Quizelement();

            Console.WriteLine("Create new element");
            Console.WriteLine("Please enter your question:");
            qe.question = Console.ReadLine();

            Console.WriteLine("Enter an answer");
            string input = Console.ReadLine();
            qe.wrongAnswers.Add(input);

            Console.WriteLine("Enter an answer");
            input = Console.ReadLine();
            qe.wrongAnswers.Add(input);

            while (qe.wrongAnswers.Count < 6)
            {
                Console.WriteLine("Want to add more answers? Y/N");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    Console.WriteLine("Enter an answer");
                    input = Console.ReadLine();
                    qe.wrongAnswers.Add(input);
                }
                if (Console.ReadKey().Key == ConsoleKey.N)
                {
                    Console.WriteLine("Please enter the correct answer.");
                    input = Console.ReadLine();
                    qe.correctAnswer = input;

                }
            }

            Console.WriteLine("Please enter the correct answer.");
            input = Console.ReadLine();
            qe.correctAnswer = input;
                       

            Console.WriteLine("Your input was:" + "\n" + "Question: " + "" + qe.question + "\n"
                + "Possible Answers:");

            foreach (string answer in qe.wrongAnswers)
            {
                Console.WriteLine(answer);
            }

            Console.WriteLine("Correct Answer: " + qe.correctAnswer);

            Console.WriteLine("To submit the new quiz element press enter. To delete your input press backspace");

            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                qList.Add(qe);
                return;
            }
            if (Console.ReadKey().Key == ConsoleKey.Backspace)
            {
                Console.WriteLine("Your question was deleted. Returning to main menu.");
                return;
            }
        }
    }
}
