using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salon_de_thé.Backend.Models
{
    public class Boisson
    {
        int id;
        string designation;
        float prix;
        int qteStock;
        public string Designation { get => designation; set => designation = value; }
        public float Prix { get => prix; set => prix = value; }
        public int QteStock { get => qteStock; set => qteStock = value; }
        public int Id { get => id; set => id = value; }

        public Boisson(int id = 0, string designation="?????", float prix=0, int qteStock=0)
        {
            this.designation = designation;
            this.prix = prix;
            this.qteStock = qteStock;
            this.id = id;
        }
    }
}
