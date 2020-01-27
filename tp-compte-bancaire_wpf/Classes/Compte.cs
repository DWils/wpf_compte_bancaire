using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_compte_bancaire_wpf.Classes
{
    public class Compte
    {
        private int id;
        private int idClient;
        private decimal solde;
        private static SqlCommand command;
        private static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public int IdClient { get => idClient; set => idClient = value; }
        public decimal Solde { get => solde; set => solde = value; }




    }
}
