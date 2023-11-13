using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.ViewPanel
{
    public class AdminViewPanel
    {
        InfoAboutOurApp InfoAboutOurApp = new();
        LoadingView loadingView = new();
        UserLogin userLogin = new();
        //viewpanel for admin <--> OrderRegistration.cs
        //Call bak CURD methods <--> 
        public void AdminViewPage()
        {
            InfoAboutOurApp.HeaderComponent("appname");
            RunAdminView();


        }
        public void RunAdminView()
        {
            // menu 
            while (true)
            {
                Console.WriteLine("----------- Enter your Choice! 1, 2, or 3");
                Console.WriteLine("----------- 1. Manage Order");// CURD needs ManageObjectViewPanel(UserEntity user)
                Console.WriteLine("----------- 2. Manage Customer");//Have an method to view customers GetAllCustomer(), and Viewpanel();   
                Console.WriteLine("----------- 3. Manage Modes");
                Console.WriteLine("----------- 4. Manage M");
                Console.WriteLine("----------- 5. HomePage"); // go back to MainPanelViewPanel()

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
                               //infoAboutOurApp.EndProgram();
                                Thread.Sleep(7000);
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
    }
