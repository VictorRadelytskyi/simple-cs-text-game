using System;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace Game
{   public class NonPlayerCharacter
    {  
        public string Name { get; set; }
        public List<NpcDialogPart>? Dialogs { get; set; }
        public NonPlayerCharacter(string name, List<NpcDialogPart>? dialogs = null) 
        { 
            Name = name;
            Dialogs = dialogs ?? new List<NpcDialogPart>();
        }

    }

    public class NpcDialogPart : IDialogPart
    {
        public string HeroName { get; set; }
        public string? Content { get; set; }
        public List<HeroDialogPart>? PossibleHeroResponses { get; set; }

        public NpcDialogPart(string heroName, string? content = null, List<HeroDialogPart>? possibleHeroResponses = null)
        {
            HeroName = heroName;
            Content = content ?? "";
            PossibleHeroResponses = possibleHeroResponses;
        }

        public string? GetContent()
        {
            return Content;
        }

    }

    public class HeroDialogPart : IDialogPart 
    {
        public string? HeroName { get; set; } = null;
        public string? Content { get; set; }
        public List<NpcDialogPart>? PossibleNpcResponses { get; set; }

        public HeroDialogPart(string heroName, string? content = null, List<NpcDialogPart>? possibleNpcResponses = null)
        {
            HeroName = heroName;
            Content = content ?? "";
            PossibleNpcResponses = possibleNpcResponses;
        }

        public string? GetContent()
        {
            return Content;
        }
    }
    public interface IDialogPart
    {
        string? GetContent();
    }

    public class Location
    {
        public string Name { get; set;}
        public List<NonPlayerCharacter> Characters { get; set; }
       public Location(string name, List<NonPlayerCharacter>? npcs = null)
        {
            this.Name = name;
            this.Characters = npcs ?? new List<NonPlayerCharacter>();
        }
    }

    public class Game
    {
        public static void ShowLocation(Location location, string heroName)
        {
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("You are in location: "+location.Name+". what do you want to do?");
            for (int i = 0; i < location.Characters.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] Talk to the {location.Characters[i].Name}");
            }
            Console.WriteLine("[X] Close the program");

            bool wrongChoice = true;
            while (wrongChoice)
            {
                string? choiceText = Console.ReadLine();
                int choice;
                if (choiceText == "X")
                {
                    Console.WriteLine("X was pressed, closing the program...");
                    Thread.Sleep(500);
                    Environment.Exit(0);
                }
                if (int.TryParse(choiceText, out choice)
                        && choice >= 1 && choice <= location.Characters.Count)
                {
                    wrongChoice = false;
                    TalkTo(location.Characters[choice - 1], heroName);
                    break;
                }


                Console.WriteLine("Please choose a correct option");
            }

        }

        public static void TalkTo(NonPlayerCharacter npc, string heroName)
        {
            Thread.Sleep(2000);
            
            Random random = new Random();
            
            void RecursiveDialog(NpcDialogPart npcDialog)
            {
                Console.WriteLine($"{npc.Name}: " + npcDialog.Content);

                if (npcDialog.PossibleHeroResponses == null || npcDialog.PossibleHeroResponses.Count == 0)
                {
                    Console.WriteLine("[The converstation ends here]");
                    return;
                }

                Console.WriteLine("Choose your response:");

                for (int i = 0; i < npcDialog.PossibleHeroResponses.Count; i++)
                {
                    Console.WriteLine($"[{i+1}]: " + npcDialog.PossibleHeroResponses[i].Content);
                }

                int choice;
                while (true)
                {
                    string? choiceText = Console.ReadLine();
                    if (int.TryParse(choiceText, out choice)
                        && choice >= 1 && choice <= npcDialog.PossibleHeroResponses.Count)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice, please try again");
                    }
                }

                HeroDialogPart heroDialogPart = npcDialog.PossibleHeroResponses[choice - 1];
                Console.WriteLine($"{heroName}: " + heroDialogPart.Content);

                if (heroDialogPart.PossibleNpcResponses == null || heroDialogPart.PossibleNpcResponses.Count == 0)
                {
                    Console.WriteLine("[The dialog ends here]");
                    return;
                }

                NpcDialogPart nextNpcDialog = heroDialogPart.PossibleNpcResponses[random.Next(heroDialogPart.PossibleNpcResponses.Count)];
                RecursiveDialog(nextNpcDialog);
            }

            if (npc.Dialogs != null && npc.Dialogs.Count > 0)
            {
                NpcDialogPart initialNpcDialog = npc.Dialogs[random.Next(npc.Dialogs.Count)];
                RecursiveDialog(initialNpcDialog);
            }
            else
            {
                Console.WriteLine($"[{npc.Name} has nothing to say]");
            }
        }
    }
}
