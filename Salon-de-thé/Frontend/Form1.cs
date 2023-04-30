using Salon_de_thé.Frontend;
using System.Runtime.InteropServices;

namespace Salon_de_thé
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            (new MainForm()).Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int formWidth = this.Width;
            int formHeight = this.Height;
            this.Location = new Point((screenWidth - formWidth) / 2, (screenHeight - formHeight) / 2);
        }
    }
}