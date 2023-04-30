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
    internal class GestionBoissons : IGestionBoissons
    {
        public void AjouterBoisson(Boisson boisson)
        {
            BoissonsDAO.AjouterBoisson(boisson);
        }

        public void ModifierBoisson(int id, string designation, float prix, int qte)
        {
            BoissonsDAO.ModifierBoisson(id, designation, prix, qte);
        }

        public List<Boisson> RecupererTous()
        {
            return BoissonsDAO.RecupererTous();
        }

        public List<Boisson> Recuperer(string designation)
        {
            return BoissonsDAO.Recuperer(designation);
        }

        public void SuprimerBoisson(int id)
        {
            BoissonsDAO.SuprimerBoisson(id);
        }
    }
}
