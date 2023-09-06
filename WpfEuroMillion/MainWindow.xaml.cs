using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

namespace WpfEuroMillion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Bouton qui ferme le cprogramme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Fermer_Click (object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);       
        }

        private void Menu_Ajout_CSV_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Owner = this;
            window1.ShowDialog();   //ouverture en modal
            //window1.Show();         //ouverture en non modal 
        }
    }
}
