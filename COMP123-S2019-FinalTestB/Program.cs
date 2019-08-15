using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMP123_S2019_FinalTestB.Objects;
using COMP123_S2019_FinalTestB.Views;

namespace COMP123_S2019_FinalTestB
{
    /*
     *STUDENT NAME:
     * STUDENT ID:
     * DESCRIPTION: This is the driver class for the application
     */

    public static class Program
    {
        public static CharacterGeneratorForm characterForm;
        public static Character character;
        public static Item firstItem;
        public static Item secondItem;
        public static Item thirdItem;
        public static Item fourthItem;
        public static AboutBox aboutBox;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            characterForm = new CharacterGeneratorForm();
            character = new Character();
            firstItem = new Item();
            secondItem = new Item();
            thirdItem = new Item();
            fourthItem = new Item();
            aboutBox = new AboutBox();
            Application.Run(characterForm);
        }
    }
}
