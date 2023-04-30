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
    public partial class Bilan : Form
    {
        int id;
        List<List<string>> list;
        public Bilan(int idServeur)
        {
            InitializeComponent();
            this.id = idServeur;
        }
        public void fillDatagrid()
        {
            dataGridView1.ColumnCount = 6;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns[0].Name = "Id Commande";
            dataGridView1.Columns[1].Name = "Heure";
            dataGridView1.Columns[2].Name = "Designation";
            dataGridView1.Columns[3].Name = "Prix";
            dataGridView1.Columns[4].Name = "Qte commandée";
            dataGridView1.Columns[5].Name = "Montant";
            float total = 0;
            foreach (List<string> l in list)
            {
                dataGridView1.Rows.Add(l[0], l[1], l[2], l[3], l[4], l[5]);
                total += int.Parse(l[5]);
            }
            label2.Text=total.ToString();
        }

        private void Bilan_Load(object sender, EventArgs e)
        {
            ////////////////////////////center screen
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int formWidth = this.Width;
            int formHeight = this.Height;
            this.Location = new Point((screenWidth - formWidth) / 2, (screenHeight - formHeight) / 2);
            //////////////////////////
            
            list = CommandesDAO.Bilan(id);
            fillDatagrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
