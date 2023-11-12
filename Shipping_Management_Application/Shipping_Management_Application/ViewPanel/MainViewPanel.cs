﻿using Shipping_Management_Application.ViewPanel;
using System;
using System.Threading;

public class MainViewPanel
{
    public void MainView()
    {
        LoadingView loadingView = new();
        UserLogin userLogin = new();
        // show welcom text
        loadingView.Print("Loading...");
        Console.WriteLine("Welcome to Our Shipping Management. We are here to help you take care of your orders!");//we write more info about our application
        Thread.Sleep(4000);


        // menu
        while (true)
        {
            Console.WriteLine("Enter your Choice! 1, 2, or 3");
            Console.WriteLine("1. LogIn for Customer");
            Console.WriteLine("2. LogIn for Admin");
            Console.WriteLine("3. Exit");

            var userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    {
                        Console.WriteLine("LogIn for Customer");
                        loadingView.Print("Loading...");
                        // comming method -> CustomerViewPanel()
                        userLogin.ShowLoginPage();
                        break;
                    }
                        

                case "2":
                    {
                        Console.WriteLine("LogIn for Admin");
                        loadingView.Print("Loading...");
                        // comming method -> AdminViewPanel()
                        userLogin.ShowLoginPage();
                        break;
                    }

                case "3":
                    while (true)
                    {
                        Console.WriteLine("Do you want to Exit Program? (yes/no)");
                        string input = Console.ReadLine().ToLower();
                        if (input.ToLower() == "yes")
                        {
                            Console.WriteLine("Exiting....\n Program finished");
                            return;
                        }
                        else if (input.ToLower() == "no")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter 'yes' to exit or 'no' to return to the main menu.");
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Invalid option. Please enter 1, 2, or 3.");
                    break;
            }
        }
    }

    // Method to check Is user Input is valid or not 
    public bool IsValidInput(string input)
    {
        return input == "1" || input == "2" || input == "3";
    }

}