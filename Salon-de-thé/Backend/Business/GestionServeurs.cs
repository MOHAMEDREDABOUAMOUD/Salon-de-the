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
    internal class GestionServeurs : IGestionServeurs
    {
        public void AjouterServeur(Serveur serveur)
        {
            ServeursDAO.AjouterServeur(serveur);
        }

        public void ModifierServeur(int id, string nom, string prenom)
        {
            ServeursDAO.ModifierServeur(id, nom, prenom);
        }

        public List<Serveur> Recuperer(string fullName)
        {
            return ServeursDAO.Recuperer(fullName);
        }

        public List<Serveur> RecupererTous()
        {
            return ServeursDAO.RecupererTous();
        }

        public void SuprimerServeur(int id)
        {
            ServeursDAO.SuprimerServeur(id);
        }
    }
}
