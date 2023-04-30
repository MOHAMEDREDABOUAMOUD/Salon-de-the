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

namespace Salon_de_thé.Frontend.Serveur
{
    public partial class AjouterServeur : Form
    {
        public AjouterServeur()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServeursDAO.AjouterServeur(new Backend.Models.Serveur(textBox1.Text, textBox2.Text));
            Hide();
        }

        private void AjouterServeur_Load(object sender, EventArgs e)
        {
            ////////////////////////////center screen
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int formWidth = this.Width;
            int formHeight = this.Height;
            this.Location = new Point((screenWidth - formWidth) / 2, (screenHeight - formHeight) / 2);
            //////////////////////////
        }
    }
}
