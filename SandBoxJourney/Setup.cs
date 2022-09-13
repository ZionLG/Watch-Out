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
    public partial class Setup : Form
    {
        Form menu;
        public Setup(Form menu)
        {
            InitializeComponent();
            this.menu = menu;
        }

        private void startGame_Click(object sender, EventArgs e)
        {

            if (int.TryParse(blockWidth.Text, out int blockWidthInt) &&
               int.TryParse(blockHeight.Text, out int blockHeightInt) &&
               int.TryParse(BlockHorizontal.Text, out int BlockHorizontalInt) &&
               int.TryParse(BlockVertical.Text, out int BlockVerticalInt) &&
               blockWidthInt >= 30 && blockHeightInt >= 30 && BlockHorizontalInt >= 6 && BlockVerticalInt >= 6 && BlockVerticalInt <= 25 && BlockHorizontalInt <= 25)
            {
                startGame.Visible = false;

                GameForm game = new GameForm(menu, blockWidthInt, blockHeightInt, BlockHorizontalInt, BlockVerticalInt);

                game.Show();

                this.Hide();
            }
        }
    }
}
