using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        List<string> FirstNameList;
        List<string> LastNameList;
        List<string> InventoryList;
        Random rnd=new Random();

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
            if(MainTabControl.SelectedIndex>0)
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
                CharacterSheetLoad();              
            }
        }

        private void CharacterGeneratorForm_Load(object sender, EventArgs e)
        {
            LoadNames();
            GenerateNames();

            GenerateAbilities();

            LoadInventory();
            GenerateRandomInventory();

            CharacterSheetLoad();
        }

        private void GenerateNameButton_Click(object sender, EventArgs e)
        {            
            GenerateNames();           
        }

        //this method loads names from files
        private void LoadNames()
        {
            FirstNameList = new List<string>();
            LastNameList = new List<string>();
            string fileName = "..\\..\\Data\\firstNames.txt";
            using (StreamReader inputStream = new StreamReader(fileName))
            {
                string line = inputStream.ReadLine();
                while (line != null)
                {
                    FirstNameList.Add(line);
                    line = inputStream.ReadLine();
                }
                
                inputStream.Close();
                inputStream.Dispose();
            }

            fileName = "..\\..\\Data\\lastNames.txt";
            using (StreamReader inputStream = new StreamReader(fileName))
            {
                string line = inputStream.ReadLine();
                while (line != null)
                {
                    LastNameList.Add(line);
                    line = inputStream.ReadLine();
                }                
                inputStream.Close();
                inputStream.Dispose();
            }
        }

        //this method generates random names
        private void GenerateNames()
        {
            int index = rnd.Next(0, FirstNameList.Count);
            FirstNameDataLabel.Text = FirstNameList[index];

            index = rnd.Next(0, LastNameList.Count);
            LastNameDataLabel.Text = LastNameList[index];

            Program.character.FirstName = FirstNameDataLabel.Text;
            Program.character.LastName = LastNameDataLabel.Text;
        }

        private void GenerateAbilitiesButton_Click(object sender, EventArgs e)
        {
            GenerateAbilities();
        }

        private void GenerateAbilities()
        {
            StrengthDataLabel.Text = rnd.Next(3, 18).ToString();
            DexterityDataLabel.Text = rnd.Next(3, 18).ToString();
            ConstituitionDataLabel.Text = rnd.Next(3, 18).ToString();
            IntelligenceDataLabel.Text = rnd.Next(3, 18).ToString();
            WisdomDataLabel.Text = rnd.Next(3, 18).ToString();
            CharismaDataLabel.Text = rnd.Next(3, 18).ToString();

            Program.character.Strength = StrengthDataLabel.Text;
            Program.character.Dexterity = DexterityDataLabel.Text;
            Program.character.Constitution = ConstituitionDataLabel.Text;
            Program.character.Intelligence = IntelligenceDataLabel.Text;
            Program.character.Wisdom = WisdomDataLabel.Text;
            Program.character.Charisma = CharismaDataLabel.Text;
        }

        private void LoadInventory()
        {
            InventoryList = new List<string>();
            string fileName = "..\\..\\Data\\inventory.txt";
            using (StreamReader inputStream = new StreamReader(fileName))
            {
                string line = inputStream.ReadLine();
                while (line != null)
                {
                    InventoryList.Add(line);
                    line = inputStream.ReadLine();
                }

                inputStream.Close();
                inputStream.Dispose();
            }
        }

        private void GenerateRandomInventory()
        {
            int index = rnd.Next(0, InventoryList.Count);
            FirstItemDataLabel.Text = InventoryList[index];
            index = rnd.Next(0, InventoryList.Count);
            SecondItemDataLabel.Text = InventoryList[index];
            index = rnd.Next(0, InventoryList.Count);
            ThirdItemDataLabel.Text = InventoryList[index];
            index = rnd.Next(0, InventoryList.Count);
            FourthItemDataLabel.Text = InventoryList[index];

            Program.firstItem.Description = FirstItemDataLabel.Text;
            Program.secondItem.Description = SecondItemDataLabel.Text;
            Program.thirdItem.Description = ThirdItemDataLabel.Text;
            Program.fourthItem.Description = FourthItemDataLabel.Text;

            Program.character.Inventory.Add(Program.firstItem);
            Program.character.Inventory.Add(Program.secondItem);
            Program.character.Inventory.Add(Program.thirdItem);
            Program.character.Inventory.Add(Program.fourthItem);
        }

        private void GenerateInventoryButton_Click(object sender, EventArgs e)
        {
            GenerateRandomInventory();
        }

        private void CharacterSheetLoad()
        {
            HeroNameDataLabel.Text = CharacterNameTextBox.Text;
            GeneratedNameDataLabel.Text = Program.character.FirstName + " " + Program.character.LastName;

            GeneratedStrengthDataLabel.Text = Program.character.Strength;
            GeneratedIntelligenceDataLabel.Text = Program.character.Intelligence;
            GeneratedWisdomDataLabel.Text = Program.character.Wisdom;
            GeneratedCharismaDataLabel.Text = Program.character.Charisma;
            GeneratedConstitutionDataLabel.Text = Program.character.Constitution;
            GeneratedDexterityDataLabel.Text = Program.character.Dexterity;

            GeneratedFirstItemDataLabel.Text = Program.character.Inventory[0].Description;
            GeneratedSecondItemDataLabel.Text = Program.character.Inventory[1].Description;
            GeneratedThirdItemDataLabel.Text = Program.character.Inventory[2].Description;
            GeneratedFourthItemDataLabel.Text = Program.character.Inventory[3].Description;
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            CharacterSaveFileDialog.FileName = "Character.txt";
            CharacterSaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            CharacterSaveFileDialog.Filter = "Text Files (*.txt)|*.txt| All Files (*.*)|*.*";

            // open file dialog - Modal Form
            var result = CharacterSaveFileDialog.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                // open file to write

                using (StreamWriter outputStream = new StreamWriter(

                    File.Open(CharacterSaveFileDialog.FileName, FileMode.Create)))
                {
                    // write stuff to the file

                    outputStream.WriteLine(Program.character.FirstName);
                    outputStream.WriteLine(Program.character.LastName);
                    outputStream.WriteLine(Program.character.Strength);
                    outputStream.WriteLine(Program.character.Dexterity);
                    outputStream.WriteLine(Program.character.Constitution);
                    outputStream.WriteLine(Program.character.Intelligence);
                    outputStream.WriteLine(Program.character.Wisdom);
                    outputStream.WriteLine(Program.character.Charisma);
                    outputStream.WriteLine(Program.character.Inventory[0].Description);
                    outputStream.WriteLine(Program.character.Inventory[1].Description);
                    outputStream.WriteLine(Program.character.Inventory[2].Description);
                    outputStream.WriteLine(Program.character.Inventory[3].Description);
                    // close the file
                    outputStream.Close();
                    // dispose of the memory
                    outputStream.Dispose();
                }
            }
            }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            CharacterOpenFileDialog.FileName = "Student.txt";
            CharacterOpenFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            CharacterOpenFileDialog.Filter = "Text Files (*.txt)|*.txt| All Files (*.*)|*.*";

            // open the file dialog
            var result = CharacterOpenFileDialog.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                try               
                {
                    // Open your stream to read
                    using (StreamReader inputStream = new StreamReader(

                        File.Open(CharacterOpenFileDialog.FileName, FileMode.Open)))
                    {
                        // Read stuff into the Student class

                        Program.character.FirstName = inputStream.ReadLine();
                        Program.character.LastName = inputStream.ReadLine();

                        Program.character.Strength = inputStream.ReadLine();
                        Program.character.Dexterity = inputStream.ReadLine();
                        Program.character.Constitution = inputStream.ReadLine();
                        Program.character.Intelligence = inputStream.ReadLine();
                        Program.character.Wisdom = inputStream.ReadLine();
                        Program.character.Charisma = inputStream.ReadLine();

                        Program.character.Inventory[0].Description = inputStream.ReadLine();
                        Program.character.Inventory[1].Description = inputStream.ReadLine();
                        Program.character.Inventory[2].Description = inputStream.ReadLine();
                        Program.character.Inventory[3].Description = inputStream.ReadLine();

                        CharacterSheetLoad();
                        // cleanup
                        inputStream.Close();
                        inputStream.Dispose();
                    }
                }
                catch (IOException exception)
                {
                    MessageBox.Show("Error: " + exception.Message, "File I/O Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }           
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            Program.aboutBox.ShowDialog();
        }

        //event for tab control being selected
        private void MainTabControl_Selected(object sender, TabControlEventArgs e)
        {
            if(MainTabControl.SelectedIndex==3)
            {
                CharacterSheetLoad();
            }
        }
    }
}
