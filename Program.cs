using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoATM_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<CardHolder> cardHolders = new List<CardHolder>();
            cardHolders.Add(new CardHolder { FirstName = "John", LastName = "Hardick",CardNumber = "6703 4444 4444 4449",PinNum = 12345,Balance = 28500});
            cardHolders.Add(new CardHolder { FirstName = "Elon", LastName = "Musk", CardNumber = "6703 2222 1111 4449", PinNum = 54321, Balance = 22500 });
            cardHolders.Add(new CardHolder { FirstName = "Eva", LastName = "Green", CardNumber = "6703 5555 3333 4449", PinNum = 123654, Balance = 500 });
            cardHolders.Add(new CardHolder { FirstName = "Taskune", LastName = "Chan", CardNumber = "6703 6666 7878 4449", PinNum = 456321, Balance = 10500 });
            cardHolders.Add(new CardHolder { FirstName = "Moka", LastName = "Ayoshii", CardNumber = "6703 4242 8989 4449", PinNum = 090808, Balance = 11500 });



            Console.WriteLine("=============**********Welcome to Our ATM Service=============**********");
            Console.WriteLine();
            Console.WriteLine("Enter Your Debit Card Number: \n");
            string dCardNum = "";
            CardHolder CurrentUser = new CardHolder();

            while (true)
            {
                try
                {
                    dCardNum = Console.ReadLine();
                    CurrentUser = cardHolders.FirstOrDefault(a => a.CardNumber == dCardNum);
                     if (CurrentUser != null) { break; }
                     else
                     {
                         Console.WriteLine("Invalid Card Number Please Try Again");
                     }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid Card Number Please Try Again.");
                }
            }
           

            Console.Write("Enter Your Pin Number: \t");
            int userPin = 0;
            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    if(CurrentUser.PinNum == userPin)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Pin Number.Please Try Again");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Incorrect Pin Number.Please Try Again");
                }
            }

            Console.WriteLine("Welcome "+CurrentUser.FirstName+ "!!");
            int option = 0;

            do
            {
                PrintOption();
                try
                {
                    option = int.Parse(Console.ReadLine());
                    if(option == 1) { Deposit(CurrentUser); }
                    else if(option == 2) { Withdraw(CurrentUser); }
                    else if(option == 3) { CheckBalance(CurrentUser); }
                    else if(option == 4) { break; }
                    else
                    {
                        option = 0;
                    }
                }
                catch( Exception ex )
                {
                    Console.WriteLine("Invalid Input Given Please Try Again."+ex.Message);
                }

            } while (option != 4);

            Console.WriteLine("Thanks for being with us!! Have a good day!!");


            Console.ReadKey();
        }

        private static void PrintOption()
        {
            Console.WriteLine("Please Select Your Appropiate Option: \n1.Deposit,\r\n2.Withdraw,\r\n3.CheckBalance,\r\n4.Exit");
        }

        private static void Deposit(CardHolder CurrentUser)
        {
            Console.Write("Enter Amount You Want To Deposit: \t");
            double amountDeposit = double.Parse(Console.ReadLine());
            CurrentUser.Balance = (CurrentUser.Balance + amountDeposit);
            Console.WriteLine("Thank You For Your Deposit. Your New Balance is : " + CurrentUser.Balance);
        }

        private static void Withdraw(CardHolder CurrentUser)
        {
            Console.Write("Enter Amount You Want To Withdraw: \t");
            double amountWithdraw = double.Parse(Console.ReadLine());
            if(CurrentUser.Balance < amountWithdraw)
            {
                Console.WriteLine("Insufficiant Balance. ( ");
            }
            else if(CurrentUser.Balance < 500)
            {
                Console.WriteLine("Insufficiant Balance. ( ");
            }
            else
            {
                CurrentUser.Balance = (CurrentUser.Balance - amountWithdraw);
                Console.WriteLine("Withdraw Process Done!!. Your New Balance is: " + CurrentUser.Balance);
            }
            
        }

        private static void CheckBalance(CardHolder CurrentUser)
        {
            Console.WriteLine("Your Current Balance is: \t "+CurrentUser.Balance);
        }
    }
}
