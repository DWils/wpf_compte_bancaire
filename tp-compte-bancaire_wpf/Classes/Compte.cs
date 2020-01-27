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
        protected static int compteur = 0;
        private int numero;

        private int id;
        private int idClient;
        private Client client;
        private List<Operation> operations;
        private decimal solde;
        private static SqlCommand command;
        private static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public int IdClient { get => idClient; set => idClient = value; }
        public decimal Solde { get => solde; set => solde = value; }
        public Client Client { get => client; set => client = value; }
        public List<Operation> Operations { get => operations; set => operations = value; }
        public int Numero { get => numero; set => numero = value; }

        public Compte()
        {
            compteur++;
            Numero = compteur;
            operations = new List<Operation>();
            Solde = 0;

        }

        public void SaveCompte(int idClient)
        {
            command = new SqlCommand("INSERT INTO bank_compte (numero, idClient, solde) OUTPUT INSERTED.ID VALUES(@numero, @idClient, @solde)", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@numero", Numero));
            command.Parameters.Add(new SqlParameter("@idClient", idClient));
            command.Parameters.Add(new SqlParameter("@solde", Solde));
            Configuration.connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            Configuration.connection.Close();
        }
    }
}
