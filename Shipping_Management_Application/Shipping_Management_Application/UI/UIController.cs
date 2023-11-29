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

            
            if (validInput is not null && validInput.Contains(input) && isValid) 
            {
                validInput = validInput.ConvertAll(v => v.ToLower());
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
            Console.WriteLine("************* Menu *************");

            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"Press {i+1} to {options[i]}");

            }
            Console.WriteLine("********************************");
        }

        /// <summary>
        /// Refactoring  2/x <see cref="InitializeApp"/>
        /// We had a lot of repitition in the code to display menues and handle inputs,
        /// so we wrote ReadAStringInput() and DrawMenu(), as well as a facade to run both
        /// to reduce the repition of the code. This let us handle all the input sanitization
        /// in one place.
        /// also added null check on valid input so it doesnt auto run if not called
        /// </summary>

        public static string MenuFacade(List<string> options, List<string>? validInput = null) 
        {
            DrawMenu(options);
            try
            {
                if (validInput is not null) { return ReadAStringInput(validInput); }
                return null;
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
