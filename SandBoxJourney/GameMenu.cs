using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SandBoxJourney
{
    public partial class GameMenu : Form
    {
        public GameMenu()
        {
            InitializeComponent();
        }

        private void appClose_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        private void startGame_Click(object sender, EventArgs e)
        {
            Setup setupMenu = new Setup(this);

            setupMenu.Show();

            this.Hide();
        }
    }
}
