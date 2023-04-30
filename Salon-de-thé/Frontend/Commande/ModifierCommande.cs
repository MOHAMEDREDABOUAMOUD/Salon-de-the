using Salon_de_thé.Backend.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salon_de_thé.Frontend.Commande
{
    public partial class ModifierCommande : Form
    {
        int id, idServeur;
        DateTime datetime;
        public ModifierCommande(int id, DateOnly date, TimeOnly heure, int idServeur)
        {
            this.id = id;
            datetime = new DateTime(date.Year, date.Month, date.Day, heure.Hour, heure.Minute, heure.Second);
            InitializeComponent();
        }

        private void ModifierCommande_Load(object sender, EventArgs e)
        {
            ////////////////////////////center screen
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int formWidth = this.Width;
            int formHeight = this.Height;
            this.Location = new Point((screenWidth - formWidth) / 2, (screenHeight - formHeight) / 2);
            //////////////////////////
            ///
            List<Backend.Models.Serveur> l = ServeursDAO.RecupererTous();
            int i = 0;
            foreach (Backend.Models.Serveur s in l)
            {
                comboBox1.Items.Add(s.Id + "-" + s.Nom + " " + s.Prenom);
                if (s.Id == id)
                {
                    comboBox1.SelectedIndex = i;
                }
                i++;
            }
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            dateTimePicker1.Value = datetime;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateOnly date = DateOnly.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            TimeOnly time = TimeOnly.Parse(dateTimePicker1.Value.ToString("HH:mm:ss"));
            DateTime dateTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
            CommandesDAO.ModifierCommande(id, DateOnly.FromDateTime(dateTime), TimeOnly.FromDateTime(dateTime), int.Parse(comboBox1.SelectedItem.ToString().Split('-')[0]));
            Hide();
        }
    }
}
