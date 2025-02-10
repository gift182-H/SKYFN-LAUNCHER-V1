using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SKYFN_SMALL_LAUNCHER.PAGE
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private string selectedPath;

        public object Path69 { get; private set; }
        public object PSBasics { get; private set; }

        public Home()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Demander à l'utilisateur de choisir un fichier ou un dossier
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Title = "Select File or Folder";
            

            // Si l'utilisateur choisit un fichier
            if (dialog.ShowDialog() == false)
            {
                selectedPath = dialog.FileName;  // On récupère le chemin du fichier
                
            }
            else
            {
                // Si l'utilisateur annule, on propose de choisir un dossier
                FolderBrowserDialog folderDialog = new FolderBrowserDialog();
                if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    selectedPath = folderDialog.SelectedPath;  // On récupère le chemin du dossier
                    
                }
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(selectedPath))
            {
                try
                {
                    if (Directory.Exists(selectedPath))
                    {
                        // Si c'est un dossier, on l'ouvre
                        Process.Start("explorer", selectedPath);
                    }
                    else if (File.Exists(selectedPath))
                    {
                        // Si c'est un fichier, on l'ouvre avec l'application par défaut
                        Process.Start(selectedPath);
                    }
                    else
                    {
                        MessageBox.Show("The selected path is invalid. Please select a valid file or folder.", "Invalid Path", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to launch the selected path: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a file or folder first!", "No Path Selected", MessageBoxButton.OK, MessageBoxImage.Warning);


                WebClient OMG = new WebClient();
                OMG.DownloadFile("https://cdn.discordapp.com/attachments/1125117879763865642/1125490815372890183/EonCurl.dll", System.IO.Path.Combine((string)Path69, "Engine\\Binaries\\ThirdParty\\NVIDIA\\NVaftermath\\Win64", "GFSDK_Aftermath_Lib.x64.dll"));
            }
        }
    }
}




