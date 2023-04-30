using Salon_de_thé.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salon_de_thé.Backend.Business.interfaces
{
    internal interface IGestionBoissons
    {
        public void AjouterBoisson(Boisson boisson);
        public void SuprimerBoisson(int id);
        public void ModifierBoisson(int id, string designation,float prix, int qte);
        public List<Boisson> RecupererTous();
        public List<Boisson> Recuperer(string designation);
    }
}
