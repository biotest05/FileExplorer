using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace CheckboxFormApp
{
    public partial class Form1 : Form
    {
        private List<CheckBox> checkBoxes;
        private string filePath = "C:\\path\\to\\files"; // Replace with the actual directory path

        public Form1()
        {

            // Initialize the list
            checkBoxes = new List<CheckBox>();

            filePath = System.IO.Directory.GetCurrentDirectory();

            Console.WriteLine(filePath);

            // Get all the files with the .txt extension from the specified directory
            string[] txtFiles = Directory.GetFiles(filePath, "*.txt");

            InitializeComponent();

            // Add checkboxes for each file to the list
            foreach (string file in txtFiles)
            {
                // Create a checkbox
                CheckBox checkBox = new CheckBox();

                string fileName = Path.GetFileName(file);

                // Set the checkbox's display name to include the file name
                checkBox.Name = fileName;
                Console.WriteLine(checkBox.Name);
                checkBox.Text = fileName;

                // Add the checkbox to the list
                checkBoxes.Add(checkBox);
            }
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            foreach (CheckBox checkBox in checkBoxes)
            {
                if (checkBox.Checked)
                {
                    File.Open(checkBox.Name, FileMode.Open);
                }
            }
        }
    }
}