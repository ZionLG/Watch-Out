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
    public partial class GameOpener : Form
    {
        public GameOpener()
        {
            InitializeComponent();
        }

        private void toMenu_Click(object sender, EventArgs e)
        {
            GameMenu gameMenu = new GameMenu();
            gameMenu.Show();
            this.Hide();
        }

        private void appClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
