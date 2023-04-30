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

namespace Salon_de_thé.Frontend.Boisson
{
    public partial class ListerBoissons : Form
    {
        public void fillDatagrid()
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns[0].Name ="Id";
            dataGridView1.Columns[1].Name = "Designation";
            dataGridView1.Columns[2].Name = "Prix";
            dataGridView1.Columns[3].Name = "Qte en stock";
            List<Salon_de_thé.Backend.Models.Boisson> l = BoissonsDAO.RecupererTous();
            foreach (Salon_de_thé.Backend.Models.Boisson b in l)
            {
                dataGridView1.Rows.Add(b.Id,b.Designation, b.Prix, b.QteStock);
            }
        }
        public ListerBoissons()
        {
            InitializeComponent();
        }

        private void ListerBoissons_Load(object sender, EventArgs e)
        {
            fillDatagrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Id"].Value.ToString());
            BoissonsDAO.SuprimerBoisson(id);
            fillDatagrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new AjouterBoisson();
            f.ShowDialog();
            fillDatagrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new ModifierBoisson(int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Id"].Value.ToString()), dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Designation"].Value.ToString(), float.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Prix"].Value.ToString()), int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Qte en stock"].Value.ToString()));
            f.ShowDialog();
            fillDatagrid();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
