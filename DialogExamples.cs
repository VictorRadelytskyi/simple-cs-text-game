using System;
using System.Collections.Generic;
using static Game.Program;

namespace Game
{
    public class DialogExamples
    {
        public static Location dungeon = new Location(
            "Dungeon",
            new List<NonPlayerCharacter>
            {
                new NonPlayerCharacter("Demon", new List<NpcDialogPart>
                {
                    new NpcDialogPart(HeroName, "Let's fight for death!", new List<HeroDialogPart>
                    {
                        new HeroDialogPart(HeroName, "Surely. Come over here"),
                        new HeroDialogPart(HeroName, "No, thanks. I am scared")
                    }),

                    new NpcDialogPart(HeroName, "Give me gold.", new List<HeroDialogPart>
                    {
                        new HeroDialogPart(HeroName, "But I have no gold..."),
                        new HeroDialogPart(HeroName, "You are out of your mind. Why should I?")
                    })
                }),

                new NonPlayerCharacter("Pit Lord", new List<NpcDialogPart>
                {
                    new NpcDialogPart(HeroName, "Wow-wow-wow, isn't that a hero...? How did you get into the dungeon?", new List<HeroDialogPart>
                    {
                        new HeroDialogPart(HeroName, "Yes, that's me. Got a problem?"),
                        new HeroDialogPart(HeroName, "I came here to find gold. Do you have any?")
                    }),

                    new NpcDialogPart(HeroName, "Oh, a hero. Prepare yourself, you are about to get beaten", new List<HeroDialogPart>
                    {
                        new HeroDialogPart(HeroName, "You are ready to go"),
                        new HeroDialogPart(HeroName, "Please don't attack me! I came here for gold, if you let me go I can share some with you")
                    })
                })
            }
        );
    }
}
