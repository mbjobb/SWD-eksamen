using Shipping_Management_Application.BuisnessLogic.User;
using Shipping_Management_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.ViewPanel
{
    public class AdminViewPanel
    {

        DataContext _dataContext = new();
        InfoAboutOurApp _infoAboutOurApp = new();
        LoadingView loadingView = new();
        //viewpanel for admin <--> OrderRegistration.cs
        //Call bak CURD methods <--> 
        public void AdminViewPage(User user)
        {
            Console.Clear();
            _infoAboutOurApp.HeaderComponent();
            RunAdminView(user);


        }
        public void RunAdminView(User user)
        {
            
            // menu 
            while (true)
            {
                Console.WriteLine("----------- Enter your Choice! 1, 2, 3 or 4");
                Console.WriteLine("----------- 1. Manage Order");// CURD needs ManageObjectViewPanel(UserEntity user)
                Console.WriteLine("----------- 2. Manage Customer");//Have an method to view customers GetAllCustomer(), and Viewpanel();   
                Console.WriteLine("----------- 3. Find Order / Search Order by SerialNumber"); //crate method
                Console.WriteLine("----------- 4. Create newAdmin");                                                                              
                Console.WriteLine("----------- 5. HomePage"); // go back to MainPanelViewPanel()

                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        {
                            Console.WriteLine("Component -> Manage OrderViewPanel()");
                            loadingView.Print("Loading...");
                            // comming method -> CustomerViewPanel() 
                            //userLogin.ShowLoginPage();
                            break;
                        }


                    case "2":
                        {
                            Console.WriteLine("Component -> ManageCustomer() CURD ??");
                            loadingView.Print("Loading...");
                            // comming method -> AdminViewPanel()
                            //userLogin.ShowLoginPage();
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine(" FindOrderBySerialNumber....");
                            FindOrderBySerialNumber findOrderBySerialNumber = new(_dataContext);
                            findOrderBySerialNumber.GetOrderBySerialNumber(user);
                            break;

                        }
                        case "4":
                        {
                            Console.WriteLine("Creating newAdmin....");
                            UserRegistration userRegistration = new();
                            userRegistration.CreateAdminFromAdmin();
                            break;
                        }

                    case "5":
                        while (true)
                        {
                            Console.WriteLine("Do you want to Exit Program? (yes/no)");
                            string? input = Console.ReadLine();
                            if (input.ToLower() == "yes")
                            {
                                Console.WriteLine("Exiting....\n HomePage");
                                //infoAboutOurApp.EndProgram();
                                Thread.Sleep(1000);
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
                        Console.WriteLine("Invalid option. Please enter 1, 2, 3, 4 or 5.");
                        break;
                }
            }

        }

        // Method to check Is user Input is valid or not 
        public bool IsValidInput(string input)
        {
            return input == "1" || input == "2" || input == "3" || input == "4" || input == "5";
        }
    }
    }
