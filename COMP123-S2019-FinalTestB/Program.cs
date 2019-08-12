using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMP123_S2019_FinalTestB.Views;

namespace COMP123_S2019_FinalTestB
{
    
    public static class Program
    {
        public static CharacterGeneratorForm characterForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            characterForm = new CharacterGeneratorForm();
            Application.Run(characterForm);
        }
    }
}
