using Salon_de_thé.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salon_de_thé.Backend.Business.interfaces
{
    internal interface IGestionCommande
    {
        public void AjouterCommande(Commande commande);
        public void SuprimerCommande(int id);
        public void ModifierCommande(int id, DateOnly date, TimeOnly heure, int IdServeur);
        public List<Commande> RecupererTous();
        public Commande Recuperer(int id);
    }
}
