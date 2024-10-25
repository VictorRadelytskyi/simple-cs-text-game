// See https://aka.ms/new-console-template for more information
using System.Net.NetworkInformation;

using System;
using System.Runtime.ConstrainedExecution;
using Game;
using static Game.Hero;

namespace Game
{
    class Program
    {
        public const string GameName = "Game About Killing";
        public static string HeroName = "";
        public static HeroClasses HeroClass = HeroClasses.Barbarian;

        

        void SetHeroName()
        {
            Console.WriteLine("Hero name: ");
            bool valid = false;
            while(valid == false)
            {
                string? providedName = Console.ReadLine()?.Trim();

                if(!string.IsNullOrEmpty(providedName) 
                    && providedName.All(char.IsLetter) 
                    && providedName.Length > 2)
                {
                    valid = true;
                    HeroName = providedName;
                    Console.WriteLine($"Your hero name has been set to {HeroName}");
                }
                else
                {
                    Console.WriteLine("Unvalid hero name provided. " +
                        "Ensure the hero name contains only letters and is longer than 2 characters");
                }
            }
        }
        void SetHeroClass()
        {
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("Please select a class:");
            foreach(var heroClass in Enum.GetValues(typeof(HeroClasses)))
            {
                Console.WriteLine($"{heroClass}");
            }
            while (true)
            {
                string? heroClassProvided = Console.ReadLine();
                if(Enum.TryParse(heroClassProvided, true, out HeroClasses heroClass))
                {
                    HeroClass = heroClass;
                    Console.WriteLine($"Your class has been set to {HeroClass}");
                    break;
                }
                else
                {
                    Console.WriteLine("Please try to provide a valid herro class");
                }
            }
        }

        void StartProgram()
        {
            Thread.Sleep(1000);
            Console.Clear();

            SetHeroName();
            SetHeroClass();

            Thread.Sleep(1500);
            Console.Clear();
            Console.WriteLine($"{HeroClass} {HeroName} starts his journey!");

            Game.ShowLocation(DialogExamples.dungeon, HeroName);
            Console.ReadLine();
            Environment.Exit(0);
        }

        void StartMenu(Program p)
        {
            Console.WriteLine($"Welcome to the {GameName} ");
            Console.WriteLine("[1] Begin a new game");
            Console.WriteLine("[X] Close the program");
            while (true)
            {
                string? input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("Starting a program");
                    p.StartProgram();
                    break;
                }
                else if (input == "X")
                {
                    Console.WriteLine("Closing the program");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Unknown input, please try again\n");
                }
            }
        }   
        static void Main(string[] args)
        {
            Program program = new Program();
            program.StartMenu(program);
        }
        
    }

    

    
}