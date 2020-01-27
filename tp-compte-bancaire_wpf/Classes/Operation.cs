using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_compte_bancaire_wpf.Classes
{
    public class Operation
    {
        private int numCompte;
        private DateTime dateCreation;
        private string type;
        private decimal montant;

        

        

        public int NumCompte { get => numCompte; set => numCompte = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public string Type { get => type; set => type = value; }
        public decimal Montant { get => montant; set => montant = value; }

        public static List<Operation> listeOpe = new List<Operation>();
    }
}
