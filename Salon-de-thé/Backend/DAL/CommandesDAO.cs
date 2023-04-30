using Salon_de_thé.Backend.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Salon_de_thé.Backend.DAO
{
    public class CommandesDAO
    {
        public static int AjouterCommande(Commande commande)
        {
            Program.command.CommandText = $"insert into Commandes values('{commande.DateCom.ToString("yyyy-MM-dd")}', '{commande.HeureCom.ToString("HH:mm:ss")}', {commande.IdServeur.ToString()});";
            Program.command.ExecuteNonQuery();
            Program.command.CommandText = $"select IdCommande from Commandes where DateCom='{commande.DateCom.ToString("yyyy-MM-dd")}' and HeureCom='{commande.HeureCom.ToString("HH:mm:ss")}'";
            SqlDataReader reader = Program.command.ExecuteReader();
            List<Commande> list = new List<Commande>();
            int id=-1;
            while (reader.Read())
            {
                id=(int)reader[0];
            }
            reader.Close();
            return id;
        }
        public static void AjouterCommandeFinale(int idBoisson, int idCommande, int qte)
        {
            Program.command.CommandText = $"insert into BoissonsCommandées values({idBoisson}, {idCommande}, {qte});";
            Program.command.ExecuteNonQuery();
        }
        public static void SuprimerCommande(int id)
        {
            Program.command.CommandText = $"delete from Commandes where idCommande={id}";
            Program.command.ExecuteNonQuery();
        }
        public static void ModifierCommande(int id,DateOnly date,TimeOnly heure, int idServeur)
        {
            Program.command.CommandText = $"update Commandes set DateCom='{date.ToString("yyyy-MM-dd")}', HeureCom='{heure.ToString("HH:mm:ss")}', IdServeur={idServeur} where idCommande={id}";
            Program.command.ExecuteNonQuery();
        }
        public static List<Commande> RecupererTous()
        {
            Program.command.CommandText = $"select * from Commandes";
            SqlDataReader reader = Program.command.ExecuteReader();
            List<Commande> list = new List<Commande>();
            while (reader.Read())
            {
                DateTime today = DateTime.Today;
                DateTime dateTime = today + (TimeSpan)reader[2];
                list.Add(new Commande ( (int)reader[3], DateOnly.FromDateTime((DateTime)reader[1]), TimeOnly.FromDateTime(dateTime), (int)reader[0]));
            }
            reader.Close();
            return list;
        }
        public static Commande Recuperer(int id)
        {
            Program.command.CommandText = $"select * from Commandes where IdCommande={id}";
            SqlDataReader reader = Program.command.ExecuteReader();
            List<Commande> list = new List<Commande>();
            Commande commande = null;
            while (reader.Read())
            {
                commande = new Commande((int)reader[3], DateOnly.FromDateTime((DateTime)reader[1]), TimeOnly.FromDateTime((DateTime)reader[2]), (int)reader[0]);
            }
            reader.Close();
            return commande;
        }
        public static List<List<string>> Bilan(int id)
        {
            Program.command.CommandText = $"select Commandes.IdCommande, Commandes.HeureCom, Boissons.Designation, Boissons.Prix, BoissonsCommandées.QuantiteCommandee, Boissons.Prix* BoissonsCommandées.QuantiteCommandee as 'Montant' from Commandes inner join BoissonsCommandées on Commandes.IdCommande = BoissonsCommandées.IdCommande inner join Boissons on BoissonsCommandées.IdBoisson = Boissons.IdBoisson where Commandes.IdServeur={id} and Commandes.DateCom='{(new DateOnly()).ToString("yyyy-MM-dd")}'";
            SqlDataReader reader = Program.command.ExecuteReader();
            List<List<string>> l=new List<List<string>>();
            int i = 0;
            while (reader.Read())
            {
                l.Add(new List<string>());
                for(int j=0; j < 6; j++)
                {
                    l[i].Add(reader[j].ToString());
                }
                i++;
            }
            reader.Close();
            return l;
        }
    }
}
