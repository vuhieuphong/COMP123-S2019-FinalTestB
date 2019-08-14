using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *STUDENT NAME:
 * STUDENT ID:
 * DESCRIPTION: This is the Character class used in character creation
 *              This is also the Data container for the application
 */

namespace COMP123_S2019_FinalTestB.Objects
{
    public class Character
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //character abilities
        public string Strength { get; set; }
        public string Dexterity{ get; set; }
        public string Constitution { get; set; }
        public string Intelligence { get; set; }
        public string Wisdom{ get; set; }
        public string Charisma { get; set; }

        //secondary abilities
        public int ArmourClass { get; set; }
        public int HitPoints { get; set; }

        //character class
        public CharacterClass Class { get; set; }
        public int Level { get; set; }

        //equipment
        public List<Item> Inventory;

        //constructor
        public Character()
        {
            this.Inventory = new List<Item>();
        }
    }
}
