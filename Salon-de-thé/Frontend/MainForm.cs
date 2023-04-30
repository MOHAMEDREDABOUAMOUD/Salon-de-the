using Salon_de_thé.Frontend.Boisson;
using Salon_de_thé.Frontend.Commande;
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

namespace Salon_de_thé.Frontend
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            ////////////////////////////center screen
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int formWidth = this.Width;
            int formHeight = this.Height;
            this.Location = new Point((screenWidth - formWidth) / 2, (screenHeight - formHeight) / 2);
            //////////////////////////

            label1.Text = "Home";
            flowLayoutPanel2.Anchor = AnchorStyles.None;
            label1.Location = new Point((flowLayoutPanel2.Width / 2) - (label1.Width / 2), (flowLayoutPanel2.Height / 2) - (label1.Height / 2));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Application.ExitThread();
        }

        public void OpenChildForm(Form childForm)
        {

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(childForm);
            this.panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Serveurs management";
            OpenChildForm(new ListerServeurs(panel1));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Commandes management";
            OpenChildForm(new ListerCommandes());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "Boissons management";
            OpenChildForm(new ListerBoissons());
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
