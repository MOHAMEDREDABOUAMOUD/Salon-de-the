using Salon_de_thé.Backend.DAO;
using Salon_de_thé.Frontend.Serveur;
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
    public partial class ListerCommandes : Form
    {
        public ListerCommandes()
        {
            InitializeComponent();
        }

        public void fillDatagrid()
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns[0].Name = "Id";
            dataGridView1.Columns[1].Name = "Date";
            dataGridView1.Columns[2].Name = "Heure";
            dataGridView1.Columns[3].Name = "IdServeur";
            List<Salon_de_thé.Backend.Models.Commande> l = CommandesDAO.RecupererTous();
            foreach (Salon_de_thé.Backend.Models.Commande c in l)
            {
                dataGridView1.Rows.Add(c.Id, c.DateCom, c.HeureCom, c.IdServeur);
            }
        }

        private void ListerCommandes_Load(object sender, EventArgs e)
        {
            fillDatagrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Id"].Value.ToString());
            CommandesDAO.SuprimerCommande(id);
            fillDatagrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new AjouterCommande();
            f.ShowDialog();
            fillDatagrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new ModifierCommande(int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Id"].Value.ToString()), DateOnly.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Date"].Value.ToString()), TimeOnly.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Heure"].Value.ToString()), int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["IdServeur"].Value.ToString()));
            f.ShowDialog();
            fillDatagrid();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
