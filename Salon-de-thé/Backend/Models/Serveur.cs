using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salon_de_thé.Backend.Models
{
    public class Serveur
    {
        int id;
        string nom;
        string prenom;

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public int Id { get => id; set => id = value; }

        public Serveur(string nom="?????", string prenom="?????", int id = 0)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.id = id;
        }
    }
}
