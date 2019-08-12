using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
/*
  *STUDENT NAME:
  * STUDENT ID:
  * DESCRIPTION: This is the CharacterGeneratorForm
  */
namespace COMP123_S2019_FinalTestB.Views
{
    public partial class CharacterGeneratorForm : MasterForm
    {
        public CharacterGeneratorForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// this is the event handler for the BackButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            if(MainTabControl.SelectedIndex==0)
            {
                MainTabControl.SelectedIndex--;
            }
        }

        /// <summary>
        /// this is the event handler for the NextButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e)
        {
            if(MainTabControl.SelectedIndex<MainTabControl.TabPages.Count)
            {
                MainTabControl.SelectedIndex++;
            }
        }
    }
}
