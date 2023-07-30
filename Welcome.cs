using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacManGUI
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Loading.Value += 10;
            if(Loading.Value == 100)
            {
                timer1.Enabled = false;
                this.Hide();
                Form game = new Form1();
                game.ShowDialog();
                this.Show();
            }
        }

        private void Welcome_Load(object sender, EventArgs e)
        {

        }
    }
}
