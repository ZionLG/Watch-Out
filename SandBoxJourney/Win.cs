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
    public partial class Win : Form
    {
        Form menu;

        public Win(Form menu)
        {
            this.menu = menu;
            InitializeComponent();
        }

        private void startGame_Click(object sender, EventArgs e)
        {

            menu.Show();
            this.Close();
        }
    }
}
