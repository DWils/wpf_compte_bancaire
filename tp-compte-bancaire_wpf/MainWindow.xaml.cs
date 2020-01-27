using System;
using System.Collections.Generic;
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
using tp_compte_bancaire_wpf.Classes;

namespace tp_compte_bancaire_wpf
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                Client client = new Client() { Nom = nom.Text, Prenom = prenom.Text, Telephone = tel.Text };
                client.Save();
                MessageBox.Show("Client ajouté");
                nom.Clear();
                prenom.Clear();
                tel.Clear();
            }
            catch (Exception)
            {

                MessageBox.Show("Erreur");
            }


        }
    }
}
