using System;
using System.Collections.Generic;
using System.Text;

namespace L04_Quiz
{
    class Quiz
    {
        public static int score;

        static bool running = true;
        static void Main(string[] args)
        {
            score = 0;
            setupDefaultQuestions();
            
            while (running)
            {
                Console.WriteLine("Please choose:" + "\n" + "1: Answer a question" + "\n"
               + "2: Add a question" + "\n" + "3: Exit");

                var input = Int32.Parse(Console.ReadLine());

                switch (input)
                {

                    case 1:
                        displayQuestion();
                        break;
                    case 2:
                        addQuestion();
                        break;
                    case 3:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }


        }


        private static List<QuizElement> qList = new List<QuizElement>();

        static void setupDefaultQuestions()
        {
            QuizElement qe = new QuizElement();

            qe.question = "Wie viele Monde hat der Planet Erde?";
            qe.answers.Add("1");
            qe.answers.Add("2");
            qe.correctAnswer = 0;
            qList.Add(qe);

            QuizElement qe2 = new QuizElement();
            qe2.question = "Woraus wird Sake hergestellt?";
            qe2.answers.Add("Weizen");
            qe2.answers.Add("Mais");
            qe2.answers.Add("Reis");
            qe2.correctAnswer = 2;
            qList.Add(qe2);

            QuizElement qe3 = new QuizElement();
            qe3.question = "Was feiert man am 35. Hochzeitstag?";
            qe3.answers.Add("Silberhochzeit");
            qe3.answers.Add("Winterhochzeit");
            qe3.answers.Add("Sommerhochzeit");
            qe3.answers.Add("Korallenhochzeit");
            qe3.correctAnswer = 3;
            qList.Add(qe3);

        }

        static int answeredQuestions = 0;
        static void displayQuestion()
        {
            if (answeredQuestions < qList.Count)
            {
                Console.WriteLine("Please answer the question. Select your answer with the numbers on your keyboard!");
                Console.WriteLine("\n" + qList[answeredQuestions].question);
                for (int i = 0; i < qList[answeredQuestions].answers.Count; i++)
                {
                    Console.WriteLine(i + 1 + ": " + qList[answeredQuestions].answers[i] + "\n");
                }
                int input = Int32.Parse(Console.ReadLine()) - 1;

                answerQuestion(input);
            }
            else
                Console.WriteLine("No more questions left. Your final score is: " + "" + score);
        }

        static void answerQuestion(int answer)
        { 
                if (answer == qList[answeredQuestions].correctAnswer)
                {
                    Console.WriteLine("Your answer was correct");
                    score++;
                    answeredQuestions++;
                }
                else
                {
                    Console.WriteLine("Your answer was wrong. Please try again!");
                }
                displayQuestion();
            
       
        }
        static void addQuestion()
        {
            QuizElement qe = new QuizElement();

            Console.WriteLine("Create new element");
            Console.WriteLine("Please enter your question:");
            qe.question = Console.ReadLine();

            Console.WriteLine("Enter at least two and up to six answers. Seperate them with \";\". (Example: Apple;Pear;Banana)");
            string input = Console.ReadLine();
            string[] answersArray = input.Split(';');
            List<string> answersList = new List<string>();

            if (answersArray.Length <= 2)
            {
                Console.WriteLine("Not enough possible answers. Please add at least two answers!");
                return;
            }
            else if (answersArray.Length <= 6 && !answersArray[1].Equals(""))
            {
                for (int i = 0; i < answersArray.Length; i++)
                {
                    answersList.Add(answersArray[i]);
                }
            }
            else
            {
                Console.WriteLine("Too many possible answers. Please add six answers at maximum");
                return;
            }
            qe.answers = answersList;

            Console.WriteLine("Please determine the right answer by pressing the according number.");

            for (int i = 0; i < answersList.Count; i++)
            {
                Console.WriteLine(i + ": " + answersList[i]);
            }

            int correctAnswer = Int32.Parse(Console.ReadLine());
            qe.correctAnswer = correctAnswer;

            Console.WriteLine("Your input was:" + "\n" + "Question: " + "" + qe.question + "\n"
                + "Possible Answers:");

            foreach (string answer in qe.answers)
            {
                Console.WriteLine(answer);
            }

            Console.WriteLine("Correct Answer: " + qe.answers[correctAnswer]);

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
        static void addQuestion(QuizElement element)
        {
            qList.Add(element);
        }

        static void addQuestion(string question, List<String> answers, int correctAnswerIndex)
        {
            QuizElement qe = new QuizElement();
            qe.question = question;
            qe.answers = answers;
            qe.correctAnswer = correctAnswerIndex;

            qList.Add(qe);
        }



    }
}
