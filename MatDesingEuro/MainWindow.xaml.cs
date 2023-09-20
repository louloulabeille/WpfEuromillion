using DAL;
using EuroLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Outil;
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
using DAL.InterfaceUnitOfWork;
using DAL.UnitOfWork;

namespace MatDesingEuro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly EuroDbContest DbContest = new EuroDbContest(_configuration["Connexion:ConnexionString"]?? default!);
        private static readonly IConfiguration _configuration = new ConfigurationBuilder().AddUserSecrets<MainWindow>().Build();
        private readonly IUnitOfWork _unitOfWork;

        public MainWindow()
        {
            InitializeComponent();

            // gestion de la version du logiciel
            VersionEuro ver = new (Parametre.Default.version);
            string version = ver.GetVersion();
            Lab_Version.Content = $"Version {version}";
            _unitOfWork = new UnitOfWorkTirage(DbContest);
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
