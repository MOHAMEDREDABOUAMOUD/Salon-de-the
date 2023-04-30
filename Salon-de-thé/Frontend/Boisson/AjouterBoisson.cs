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

namespace Salon_de_thé.Frontend.Boisson
{
    public partial class AjouterBoisson : Form
    {
        public AjouterBoisson()
        {
            InitializeComponent();
        }

        private void AjouterBoisson_Load(object sender, EventArgs e)
        {
            ////////////////////////////center screen
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int formWidth = this.Width;
            int formHeight = this.Height;
            this.Location = new Point((screenWidth - formWidth) / 2, (screenHeight - formHeight) / 2);
            //////////////////////////
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BoissonsDAO.AjouterBoisson(new Backend.Models.Boisson(0,textBox1.Text, float.Parse(textBox2.Text), int.Parse(textBox3.Text)));
            Hide();
        }
    }
}
