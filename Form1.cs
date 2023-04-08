using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValBackgroundChanger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bool Once = false;
            string gameName = "VALORANT-Win64-Shipping";
            string gamePath = null;

            MessageBox.Show("App Is Launched.");
            if(Properties.Settings.Default.GamePath == "Empty")
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                openFileDialog.Filter = "Executable files (*.exe)|*.exe";

                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Properties.Settings.Default.GamePath = openFileDialog.FileName;
                    Properties.Settings.Default.Save();
                }
            }

            gamePath = Path.Combine(Properties.Settings.Default.GamePath, @"ShooterGame\Content\Movies\Menu");
            gamePath = gamePath.Replace("\\VALORANT.exe", string.Empty);

            while (true)
            {
                Process[] processes = Process.GetProcessesByName(gameName);

                if (processes.Length > 0)
                {
                    if(Once == false)
                    {
                        Once = true;
                        string sourceFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HomepageEp6A2.mp4");

                        string destinationFilePath = Path.Combine(gamePath, "HomepageEp6A2.mp4");

                        if (File.Exists(sourceFilePath))
                        {
                            File.Copy(sourceFilePath, destinationFilePath, true);
                        }
                        else
                        {
                            MessageBox.Show("HMMMM Something Went Wrong");
                        }
                    }
                }
                else
                {
                    if(Once == true)
                    {
                        Once = false;
                        string sourceFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "OriginalHomepageEp6A2.mp4");
                       
                        string destinationFilePath = Path.Combine(gamePath, "HomepageEp6A2.mp4");

                        if (File.Exists(sourceFilePath))
                        {
                            File.Copy(sourceFilePath, destinationFilePath, true);
                        }
                        else
                        {
                            MessageBox.Show("HMMMM Something Went Wrong");
                        }
                    }
                }
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
