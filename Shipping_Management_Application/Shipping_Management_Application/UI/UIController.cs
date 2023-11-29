using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Shipping_Management_Application.UI
{
    public static class UIController
    {
        /// <summary>
        /// Controller for console input and output
        /// that can be used in the UI. 
        /// </summary>
        
        public static void SetTitle( string title )
        {
            Console.Title = title;
        }
        public static void ClearConsole() 
        {
            Console.Clear();
        }

        public static char ReadASingleKeyPress(string? validInput = null)
        {
            char input;
            while (true){
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(intercept: true);
                input = consoleKeyInfo.KeyChar;
                Console.WriteLine(input);
                return input;
            }
        }
        
        public static string ReadAStringInput(List<string>?  validInput = null) 
        {
            
            string input = Console.ReadLine().ToLower();
            string allowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ01234567890@.#/*";
            bool isValid = input.ToUpper().All(c => allowedCharacters.Contains(c));
            validInput = validInput.ConvertAll(v => v.ToLower());

            
            if (validInput is not null && validInput.Contains(input) && isValid) 
            {
                    return input ?? throw new NullReferenceException();
                

            } else if(isValid)
            {
                return input ?? throw new NullReferenceException();

            }
            else
            {
                return null;

            }

            
        }

        public static void CloseApplication(){
            Environment.Exit(0);
        }
        public static void DrawMenu(List<string> options)
        {
            Console.WriteLine("*******************************");
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"Press {i+1} to {options[i]}");

            }
            Console.WriteLine("*******************************");
        }

        /// <summary>
        /// Refactoring  2/x <see cref=""/>
        /// </summary>

        //TODO: better name
        public static string MenuFacade(List<string> options, List<string>? validInput) 
        {
            DrawMenu(options);
            try
            {
                return ReadAStringInput(validInput);
            }
            catch (NullReferenceException)
            {

                Console.WriteLine("one or more fields were empty, try again");
                MenuFacade(options, validInput);
                return null;
            }
        }
    }
}
