using Salon_de_thé.Backend.Business.interfaces;
using Salon_de_thé.Backend.DAO;
using Salon_de_thé.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salon_de_thé.Backend.Business
{
    internal class GestionCommandes : IGestionCommande
    {
        public void AjouterCommande(Commande commande)
        {
            CommandesDAO.AjouterCommande(commande);
        }

        public void ModifierCommande(int id, DateOnly date, TimeOnly heure, int IdServeur)
        {
            CommandesDAO.ModifierCommande(id, date, heure, IdServeur);
        }

        public Commande Recuperer(int id)
        {
            return CommandesDAO.Recuperer(id);
        }

        public List<Commande> RecupererTous()
        {
            return CommandesDAO.RecupererTous();
        }

        public void SuprimerCommande(int id)
        {
            CommandesDAO.SuprimerCommande(id);
        }
    }
}
