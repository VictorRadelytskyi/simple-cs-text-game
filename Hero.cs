using System;

namespace Game
{
    public partial class Hero
    {

        private string Name;
        private HeroClasses Class;

        public Hero(string name, HeroClasses heroClass)
        {
            Name = name;
            Class = heroClass;
        }

        public string GetName()
        {
            return Name;
        }

        public HeroClasses GetHeroClass()
        {
            return Class;
        }


    }
}

