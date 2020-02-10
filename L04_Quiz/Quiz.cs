using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace L04_Quiz
{
    class Quiz
    {
        public static int score;

        static bool running = true;
        static void Main(string[] args)
        {
            score = 0;
           // setupDefaultQuestions();
            ReadJsonFile();

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
            SingleAnswerQuestion qe = new SingleAnswerQuestion();

            qe.question = "Wie viele Monde hat der Planet Erde?";
            qe.answers.Add("1");
            qe.answers.Add("2");
            qe.correctAnswer = ("1");
            qList.Add(qe);

            SingleAnswerQuestion qe2 = new SingleAnswerQuestion();
            qe2.question = "Woraus wird Sake hergestellt?";
            qe2.answers.Add("Weizen");
            qe2.answers.Add("Mais");
            qe2.answers.Add("Reis");
            qe2.correctAnswer = ("Reis");
            qList.Add(qe2);

            SingleAnswerQuestion qe3 = new SingleAnswerQuestion();
            qe3.question = "Was feiert man am 35. Hochzeitstag?";
            qe3.answers.Add("Silberhochzeit");
            qe3.answers.Add("Winterhochzeit");
            qe3.answers.Add("Sommerhochzeit");
            qe3.answers.Add("Korallenhochzeit");
            qe3.correctAnswer = ("Korallenhochzeit");
            qList.Add(qe3);

        }

        static int answeredQuestions = 0;
        static void displayQuestion()
        {   
            Random rnd = new Random();
            int rn = rnd.Next(0, questionArray.Count);
            Console.WriteLine(questionArray[rn]["Question"]);
            Console.WriteLine(">");
            var input = Console.ReadLine();
            string type = questionArray[rn]["Type"].ToString();

            var currentQuizElement = questionArray[rn];
            switch (type)
            {   
                case "SingleAnswer":
                    SingleAnswerQuestion element = new SingleAnswerQuestion
                    {
                        question = currentQuizElement["Question"].ToString(),
                        correctAnswer = currentQuizElement["CorrectAnswer"].ToString()
                      
                    };
                    Console.WriteLine(questionArray["Answers"][0].ToString());
                    //element.answers.Add(questionArray["Answers"][0].ToString());
                    Console.WriteLine("SingleAnswer");
                    break;
                default:
                    Console.WriteLine("No type found");
                    break;
                // TODO: Answer Question
            }
        }

        static void answerQuestion()
        {
            qList[answeredQuestions].answerQuestion();
            /*
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
            
             */
        }
        static void addQuestion()
        {
            Console.WriteLine("currently not implemented");
            /**
            QuizElement qe = new QuizElement();

            Console.WriteLine("Create new element");
            Console.WriteLine("Please enter your question:");
            qe.question = Console.ReadLine();

            Console.WriteLine("Enter at least two and up to six answers. Seperate them with \";\". (Example: Apple;Pear;Banana)");
            string input = Console.ReadLine();
            string[] answersArray = input.Split(';');
            List<string> answersList = new List<string>();
    /**     TODO: 
     * 
     * 
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
    */
        }
      
        public static JArray questionArray;

        static void ReadJsonFile()
        {
            string file = "question.json";
            // TODO: Deserializer
            // Dictionary -> FragenTyp, Klasse
            // Fragentypen unterscheiden
            // Neue Frage in neue Json Datei speichern
            // Unit Testing lesen
            // 
            using (StreamReader r = new StreamReader(file))
            {
                var json = r.ReadToEnd();
                questionArray = JArray.Parse(json);
               
            }
        }

    }
}
