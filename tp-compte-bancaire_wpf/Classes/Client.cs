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
        private List<Compte> comptes;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public List<Compte> Comptes { get => comptes; set => comptes = value; }

        public Client()
        {
            Comptes = new List<Compte>();
        }

        public Client(string n , string p, string t) : this()
        {
            
            Nom = n;
            Prenom = p;
            Telephone = t;
            
        }

        public void Save()
        {
            command = new SqlCommand("INSERT INTO bank_client (nom, prenom, telephone) OUTPUT INSERTED.ID VALUES(@nom, @prenom, @telephone)", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@nom", Nom));
            command.Parameters.Add(new SqlParameter("@prenom", Prenom));
            command.Parameters.Add(new SqlParameter("@telephone", Telephone));
            Configuration.connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            Configuration.connection.Close();
            Compte compte = new Compte() { IdClient= Id };
            compte.SaveCompte(compte.IdClient);
            Comptes.Add(compte);
            
        }

        public static List<Compte> GetComptes()
        {
            List<Compte> liste = new List<Compte>();
            command = new SqlCommand("Select * from bank_compte", Configuration.connection);
            Configuration.connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Compte c = new Compte();
                {
                    c.Numero = reader.GetInt32(1);
                    c.IdClient = reader.GetInt32(2);
                    c.Solde = reader.GetDecimal(3);
                };
                liste.Add(c);
            }
            reader.Close();
            command.Dispose();
            Configuration.connection.Close();
            return liste;
        }


        public string GetClientAndCompteByTel(string tel)
        {
            Compte co = new Compte();
            Client cl = new Client();

            command = new SqlCommand("SELECT nom, prenom , solde  from bank_client as client inner join  bank_compte as compte on compte.idClient = client.id where telephone = @tel", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@tel", tel));
            Configuration.connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                cl.Nom = reader.GetString(0);
                cl.Prenom = reader.GetString(1);
                co.Solde = reader.GetDecimal(2);
                cl.Telephone = tel;
            }
            command.Dispose();
            Configuration.connection.Close();
            return $" { cl.Nom } { cl.Prenom } { co.Solde}";
        }


        public string GetClientAndCompteByNumeroCompte(int numero)
        {
            Compte co = new Compte();
            Client cl = new Client();

            command = new SqlCommand("SELECT nom, prenom , solde  from bank_client as client inner join  bank_compte as compte on compte.idClient = client.id where numero = @numero", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@numero", numero));
            Configuration.connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                cl.Nom = reader.GetString(0);
                cl.Prenom = reader.GetString(1); 
                co.Solde = reader.GetDecimal(2);
                co.Numero = numero;
            }
            command.Dispose();
            Configuration.connection.Close();
            // resultat de la recherche ici
            return $" { cl.Nom } { cl.Prenom } { co.Solde}";

        }


        //public override string ToString()
        //{
        //    return $" {Id} {Nom} {Prenom} {compte.Solde}";
        //}


    }
}
