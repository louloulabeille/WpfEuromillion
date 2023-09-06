using EuroLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace MatDesingEuro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            // gestion de la version du logiciel
            VersionEuro ver = new (Parametre.Default.version);
            string version = ver.GetVersion();
            Lab_Version.Content = $"Version {version}";
        }

        /// <summary>
        /// methode de sortie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Fermer_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
