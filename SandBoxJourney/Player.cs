using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SandBoxJourney
{
    internal class Player
    {
        PictureBox player;
        LevelBuilder level;
        int playerBlock;
        int lives;
        bool canMove;

        public Player(LevelBuilder level, int lives, Form game)
        {
            this.level = level;
            this.lives = lives;
            this.canMove = true;

            player = new PictureBox
            {
                Name = "pictureBox",
                BackColor = Color.Transparent,
                Size = new Size(level.GetWidth(), level.GetHeight() * 2),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(0, (level.GetOffset() - 2) * level.GetHeight()),
                Image = new Bitmap(Properties.Resources.Player),
            };
            game.Controls.Add(player);

        }

        /// <summary>
        /// Creates the player and adds it
        /// </summary>
        /// <param name="form">form to add it on</param>
        /// <param name="location">location to start on (x)</param>
        public void DrawPlayer(Form form, int location)
        {
            player.Location = new Point(location, (level.GetOffset() - 2) * level.GetHeight());
        }
        /// <summary>
        /// moves the player to the left
        /// by deleting him, and re creating him on a different location.
        /// </summary>
        /// <param name="form">game form</param>
        public void GoLeft(Form form)
        {
            if(this.canMove)
            {
                if (playerBlock > 0)
                {
                    form.Controls.Remove(player);
                    playerBlock--;
                    DrawPlayer(form, player.Location.X - level.GetWidth());
                }
            }
                
        }
        /// <summary>
        /// moves the player to the right
        /// by deleting him, and re creating him on a different location.
        /// </summary>
        /// <param name="form">game form</param>
        public void GoRight(Form form)
        {
            if (this.canMove)
            {
                if (playerBlock < level.GetLandArrayLen1() - 1)
                {
                    form.Controls.Remove(player);
                    playerBlock++;
                    DrawPlayer(form, player.Location.X + level.GetWidth());
                }
            }        
        }
        public void PlayerDispose(Form form)
        {
            form.Controls.Remove(player);
        }
        public int GetPlayerBlock()
        {
            return playerBlock;
        }
        public PictureBox GetPlayer()
        {
            return player;
        }
        public void SetMove()
        {
            canMove = true;
        }
        public void FowardBlock()
        {
            ++playerBlock;
        }
        public void BackBlock()
        {
            --playerBlock;
        }
        public void SetCantMove()
        {
            canMove = false;
        }
        public void LoseLive()
        {
            lives--;
        }

        public void AddLive()
        {
            lives++;
        }
        public int GetLives()
        {
            return lives;
        }
        public bool GetCanMove()
        {
            return canMove;
        }
    }
}
