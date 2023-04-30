using Salon_de_thé.Backend.DAO;
using Salon_de_thé.Backend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Salon_de_thé.Frontend.Commande
{
    public partial class AjouterCommande : Form
    {
        public AjouterCommande()
        {
            InitializeComponent();
        }

        private void AjouterCommande_Load(object sender, EventArgs e)
        {
            ////////////////////////////center screen
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int formWidth = this.Width;
            int formHeight = this.Height;
            this.Location = new Point((screenWidth - formWidth) / 2, (screenHeight - formHeight) / 2);
            //////////////////////////

            List<Backend.Models.Serveur> l = ServeursDAO.RecupererTous();
            foreach (Backend.Models.Serveur s in l)
            {
                comboBox1.Items.Add(s.Id+"-"+s.Nom+" "+s.Prenom);
            }
            List<Backend.Models.Boisson> b = BoissonsDAO.RecupererTous();
            foreach (Backend.Models.Boisson bo in b)
            {
                comboBox2.Items.Add(bo.Id + "-" + bo.Designation);
            }
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Backend.Models.Boisson> b = BoissonsDAO.Recuperer(comboBox2.SelectedItem.ToString().Split('-')[1]);
            if (b[0].QteStock < int.Parse(textBox1.Text))
            {
                MessageBox.Show("la quatité demandée n'est pas disponible");
            }
            else
            {
                DateOnly date = DateOnly.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                TimeOnly time = TimeOnly.Parse(dateTimePicker1.Value.ToString("HH:mm:ss"));
                DateTime dateTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
                int idCom = CommandesDAO.AjouterCommande(new Backend.Models.Commande(int.Parse(comboBox1.SelectedItem.ToString().Split('-')[0]), DateOnly.FromDateTime(dateTime), TimeOnly.FromDateTime(dateTime), 0));
                if (idCom != -1) CommandesDAO.AjouterCommandeFinale(int.Parse(comboBox2.Text.Split("-")[0]), idCom, int.Parse(textBox1.Text));
                else MessageBox.Show("voous pouvez pas ajouter boissonsCommandées");
                Hide();
            }
        }
    }
}
