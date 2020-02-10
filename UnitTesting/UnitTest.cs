using System;

namespace UnitTesting
{
    class UnitTest
    {
        static bool running = true;
        static void Main(string[] args)
        {
            /**  Console.WriteLine("Please choose:" + "\n" + "1: EmailCheck"+ "\n" + "2: Exit");

              
              var input = Int32.Parse(Console.ReadLine());
              while (running)
              {
                  switch (input)
                  {

                      case 1:
                          Display();
                          break;
                      case 3:
                          running = false;
                          break;
                      default:
                          Console.WriteLine("Invalid input");
                          break;
                  }
              }
              */

            // Test 1
            string mailaddress = "ich@provider.com";
            TestEmailAdress(mailaddress, true);
            // Test 2
            mailaddress = "@provider.com";
            TestEmailAdress(mailaddress, false);
            // Test 3
            mailaddress = "ritter.12@";
            TestEmailAdress(mailaddress, false);

            // False Positive Section
            mailaddress = "ich@provider.com";
            TestEmailAdress(mailaddress, false);
            // 
            mailaddress = "@provider.com";
            TestEmailAdress(mailaddress, true);

        }

        public static bool TestEmailAdress(string emailAdress, bool expectedResult)
        {
            bool result = IsEmailAddress(emailAdress);
            bool asExpected = (result == expectedResult);

            if (asExpected)
            {
                Console.WriteLine("TEST PASSED");
                return true;
            }
            else
            {
                Console.WriteLine("TEST FAILED");
                return false;
            }
        }
        public static void Display()
        {
            Console.WriteLine("Enter an email adress to check");
            Console.WriteLine(">");
            string input = Console.ReadLine();
            Console.WriteLine(IsEmailAddress(input));
            return;
         }

        public static bool IsEmailAddress(string emailAddress)
        {
            int iAt = emailAddress.IndexOf('@');
            int iDot = emailAddress.LastIndexOf('.');
            return (iAt > 0 && iDot > iAt);
        }
    }
}
