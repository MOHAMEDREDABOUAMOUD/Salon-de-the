using Salon_de_thé.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salon_de_thé.Backend.Business.interfaces
{
    internal interface IGestionServeurs
    {
        public void AjouterServeur(Serveur serveur);
        public void SuprimerServeur(int id);
        public void ModifierServeur(int id, string nom, string prenom);
        public List<Serveur> RecupererTous();
        public List<Serveur> Recuperer(string fullName);
    }
}
