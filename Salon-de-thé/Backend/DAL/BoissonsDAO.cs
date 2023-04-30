using Salon_de_thé.Backend.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salon_de_thé.Backend.DAO
{
    internal class BoissonsDAO
    {
        public static void AjouterBoisson(Boisson boisson)
        {
            Program.command.CommandText=$"insert into Boissons values('{boisson.Designation}', {boisson.Prix}, {boisson.QteStock});";
            Program.command.ExecuteNonQuery();
        }
        public static void SuprimerBoisson(int id)
        {
            Program.command.CommandText = $"delete from Boissons where idBoisson={id}";
            Program.command.ExecuteNonQuery();
        }
        public static void ModifierBoisson(int id, string designation, float prix, int qte)
        {
            Program.command.CommandText = $"update Boissons set Designation='{designation}', Prix={prix}, QteStock={qte} where idBoisson={id}";
            Program.command.ExecuteNonQuery();
        }
        public static List<Boisson> RecupererTous()
        {
            Program.command.CommandText = $"select * from Boissons";
            SqlDataReader reader = Program.command.ExecuteReader();
            List<Boisson> list = new List<Boisson>();
            while (reader.Read())
            {
                list.Add(new Boisson {Id=(int)reader[0], Designation = (string)reader[1], Prix = float.Parse(reader[2].ToString()), QteStock = (int)reader[3]});
            }
            reader.Close();
            return list;
        }
        public static List<Boisson> Recuperer(string designation)
        {
            Program.command.CommandText = $"select * from Boissons where Designation={designation}";
            SqlDataReader reader = Program.command.ExecuteReader();
            List<Boisson> list = new List<Boisson>();
            while (reader.Read())
            {
                list.Add(new Boisson { Id = (int)reader[0], Designation = (string)reader[1], Prix = float.Parse(reader[2].ToString()), QteStock = (int)reader[3] });
            }
            reader.Close();
            return list;
        }
    }
}
