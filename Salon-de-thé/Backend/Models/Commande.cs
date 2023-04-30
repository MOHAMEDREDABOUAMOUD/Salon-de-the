using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salon_de_thé.Backend.Models
{
    public class Commande
    {
        int id;
        DateOnly dateCom;
        TimeOnly heureCom;
        int idServeur;

        public DateOnly DateCom { get => dateCom; set => dateCom = value; }
        public TimeOnly HeureCom { get => heureCom; set => heureCom = value; }
        public int IdServeur { get => idServeur; set => idServeur = value; }
        public int Id { get => id; set => id = value; }

        public Commande(int idServeur, DateOnly dateCom=new DateOnly(), TimeOnly heureCom=new TimeOnly(), int id=0)
        {
            this.dateCom = dateCom;
            this.heureCom = heureCom;
            this.idServeur = idServeur;
            this.id = id;
        }
    }
}
