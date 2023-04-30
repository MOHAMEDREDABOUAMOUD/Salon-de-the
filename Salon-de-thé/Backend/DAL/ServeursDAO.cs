using Salon_de_thé.Backend.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salon_de_thé.Backend.DAO
{
    public class ServeursDAO
    {
        public static void AjouterServeur(Serveur serveur)
        {
            Program.command.CommandText = $"insert into Serveurs values('{serveur.Nom}', '{serveur.Prenom}');";
            Program.command.ExecuteNonQuery();
        }
        public static void SuprimerServeur(int id)
        {
            Program.command.CommandText = $"delete from Serveurs where idServeur={id}";
            Program.command.ExecuteNonQuery();
        }
        public static void ModifierServeur(int id,string nom, string prenom)
        {
            Program.command.CommandText = $"update Serveurs set Nom='{nom}', Prenom='{prenom}' where idServeur={id}";
            Program.command.ExecuteNonQuery();
        }
        public static List<Serveur> RecupererTous()
        {
            Program.command.CommandText = $"select * from Serveurs";
            SqlDataReader reader = Program.command.ExecuteReader();
            List<Serveur> list = new List<Serveur>();
            while (reader.Read())
            {
                list.Add(new Serveur((string)reader[1], (string)reader[2], (int)reader[0]));
            }
            reader.Close();
            return list;
        }
        public static List<Serveur> Recuperer(string fullName)
        {
            Program.command.CommandText = $"select * from Serveurs where Nom+' '+Prenom='%{fullName}%'";
            SqlDataReader reader = Program.command.ExecuteReader();
            List<Serveur> list = new List<Serveur>();
            while (reader.Read())
            {
                list.Add(new Serveur((string)reader[1], (string)reader[2], (int)reader[0]));
            }
            reader.Close();
            return list;
        }
    }
}
