using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_compte_bancaire_wpf.Classes
{
    public class Client
    {
        private int id;
        private string nom;
        private string prenom;
        private string telephone;
        private static SqlCommand command;
        private static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }


    }
}
