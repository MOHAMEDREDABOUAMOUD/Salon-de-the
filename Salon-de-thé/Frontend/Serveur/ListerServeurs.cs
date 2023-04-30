using Salon_de_thé.Backend.DAO;
using Salon_de_thé.Frontend.Boisson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Effects;

namespace Salon_de_thé.Frontend.Serveur
{
    public partial class ListerServeurs : Form
    {
        Panel p;
        public ListerServeurs(Panel p)
        {
            this.p = p;
            InitializeComponent();
        }

        public void fillDatagrid()
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns[0].Name = "Id";
            dataGridView1.Columns[1].Name = "Nom";
            dataGridView1.Columns[2].Name = "Prenom";
            List<Salon_de_thé.Backend.Models.Serveur> l = ServeursDAO.RecupererTous();
            foreach (Salon_de_thé.Backend.Models.Serveur s in l)
            {
                dataGridView1.Rows.Add(s.Id, s.Nom, s.Prenom);
            }
        }

        public void OpenChildForm(Form childForm)
        {

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            p.Controls.Add(childForm);
            p.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void ListerServeurs_Load(object sender, EventArgs e)
        {
            fillDatagrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Id"].Value.ToString());
            ServeursDAO.SuprimerServeur(id);
            fillDatagrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new AjouterServeur();
            f.ShowDialog();
            fillDatagrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new ModifierServeur(int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Id"].Value.ToString()), dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Nom"].Value.ToString(), dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Prenom"].Value.ToString());
            f.ShowDialog();
            fillDatagrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            OpenChildForm(new Bilan(int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Id"].Value.ToString())));
        }
    }
}
