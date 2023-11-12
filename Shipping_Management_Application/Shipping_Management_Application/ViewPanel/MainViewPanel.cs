using System;
using System.Threading;

public class MainViewPanel
{
    public void MainView()
    {
        Console.WriteLine("Welcome to Our Shipping Management. We are here to help you take care of your orders!");
        Thread.Sleep(3000);
        Console.WriteLine("1. LogIn for Customer");
        Console.WriteLine("2. LogIn for Admin");
        Console.WriteLine("3. Exit");

        var userInput = Console.ReadLine();
        switch (userInput)
        {
            case "1":
                Console.WriteLine("LogIn for Customer");// comming method 
                Console.WriteLine("Loading....");
                Thread.Sleep(3000);
                break;
            case "2":
                Console.WriteLine("LogIn for Admin"); // comming method 
                Console.WriteLine("Loading....");
                Thread.Sleep(3000);
                break;
            case "3":
                Console.WriteLine("Exiting");
                break;

            default:
                Console.WriteLine("Invalid option. Please enter 1, 2 or 3.");
                break;
        }

      
    }
    //Check out is input isValid 
    public bool IsValidInput(string input)
    {
        return input == "1" || input == "2" || input == "3";
    }
}
