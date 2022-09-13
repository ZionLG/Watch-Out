using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SandBoxJourney.GameForm;

namespace SandBoxJourney
{
    internal class LevelBuilder
    {
        BiomeCreator.BlockType[,] landArray;
        int blockWidth, blockHeight;
        int pictureCount;
        PictureBox[] currentPicturesShowen;
        BiomeCreator biomeCreator;
        Difficulty difficulty;
        static Random random = new Random();

        

        public LevelBuilder(int blockWidth, int blockHeight, int blockWidthNumber, int blockHeightNumber, Difficulty difficulty)
        {
            this.difficulty = difficulty;
            this.blockWidth = blockWidth;
            this.blockHeight = blockHeight;
            biomeCreator = new BiomeCreator(blockWidth, blockHeight);
            landArray = biomeCreator.BaseGenerator(blockHeightNumber, blockWidthNumber);
            this.pictureCount = biomeCreator.GetPicutreCount();
            currentPicturesShowen = biomeCreator.GetPicutreArray();
        }

        /// <summary>
        /// takes the pictures from the array and draws them
        /// </summary>
        /// <param name="form">the game form</param>
        private void DrawTrees(Form form, PaintEventArgs e)
        {
            for (int i = 0; i < pictureCount; i++)
            {
                
                var tree = currentPicturesShowen[i];
                e.Graphics.DrawImage(tree.Image, tree.Left, tree.Top, tree.Width, tree.Height);

            }

        }

        /// <summary>
        /// Disposes all trees
        /// </summary>
        /// <param name="form">the game form</param>
        public void DisposePictures(Form form)
        {
            for (int i = 0; i < pictureCount; i++)
            {
                currentPicturesShowen[i].Dispose();
            }
            pictureCount = 0;
        }

        /// <summary>
        /// Sets up all brushes, and paint the block depending the blocktype of the 2d Array
        /// </summary>
        /// <param name="e">Paint event args</param>
        /// <param name="form">Game form</param>
        public void DrawLevel(PaintEventArgs e, Form form)
        {
            Brush skyBrush = new SolidBrush(Color.LightBlue);
            Brush dirtBrush = new SolidBrush(Color.Brown);
            Brush grassBrush = new SolidBrush(Color.Green);
            Brush Warning = new SolidBrush(Color.Red);
            Brush Lightning = new SolidBrush(Color.Blue);

            var landArray = GetArray();
            for (int i = 0; i < GetLandArrayLen0(); i++)
            {
                for (int j = 0; j < landArray.GetLength(1); j++)
                {
                    if (landArray[i, j] == BiomeCreator.BlockType.Sky)
                    {
                        e.Graphics.FillRectangle(skyBrush, GetWidth() * j, GetHeight() * i, GetWidth(), GetHeight());
                    }
                    else if (landArray[i, j] == BiomeCreator.BlockType.Dirt)
                    {
                        e.Graphics.FillRectangle(dirtBrush, GetWidth() * j, GetHeight() * i, GetWidth(), GetHeight());
                    }
                    else if (landArray[i, j] == BiomeCreator.BlockType.Grass)
                    {
                        e.Graphics.FillRectangle(grassBrush, GetWidth() * j, GetHeight() * i, GetWidth(), GetHeight());
                    }
                    else if(landArray[i, j] == BiomeCreator.BlockType.Warning)
                    {
                        e.Graphics.FillRectangle(Warning, GetWidth() * j, GetHeight() * i, GetWidth(), GetHeight());
                    }
                    else // if(landArray[i, j] == BiomeCreator.BlockType.Lightning)
                    {
                        e.Graphics.FillRectangle(Lightning, GetWidth() * j, GetHeight() * i, GetWidth(), GetHeight());
                    }
                }
            }

            DrawTrees(form, e);

        }

        /// <summary>
        /// Start a strike depending on the level difficulty 
        /// </summary>
        public void StartWave()
        {
            switch(difficulty)
            {
                case Difficulty.Tutorial:
                    TutorialLevel();
                    break;
                case Difficulty.Easy:
                    EasyLevel();
                    break;
                case Difficulty.Normal:
                case Difficulty.Hard:
                case Difficulty.Hardcore:
                    NormalLevelPlus();
                    break;
            }
        }
        void TutorialLevel()
        {
            int maxLightning = GetLandArrayLen1() / 4;
            CreateWarnings(maxLightning);
        }

        void EasyLevel()
        {
            int maxLightning = GetLandArrayLen1() / 3;
            CreateWarnings(maxLightning);
        }
        void NormalLevelPlus()
        {
            int maxLightning = GetLandArrayLen1() / 2;
            CreateWarnings(maxLightning);
        }

        /// <summary>
        /// Sets a random amount of blocks in the offset (grass) layer to 'warning'
        /// </summary>
        /// <param name="maxLightning">Max allowed warnings to appear.</param>
        void CreateWarnings(int maxLightning)
        {
            for (int i = 0; i < maxLightning; i++)
            {
                landArray[GetOffset(), random.Next(GetLandArrayLen1())] = BiomeCreator.BlockType.Warning;
            }
        }
        /// <summary>
        /// Removes all the warnings and sets them to Lightnings
        /// checks if the player is on any warning blocks that turned to lightning
        /// if so, makes him losing a life
        /// </summary>
        /// <param name="player">Pplayer instence</param>
        /// <param name="displayForm">game form</param>
        public void RemoveWarnings(Player player, Form displayForm)
        {
            for (int i = 0; i < GetOffset(); i++)
            {
                for (int j = 0; j < GetLandArrayLen1(); j++)
                {
                    if (landArray[GetOffset(), j] == BiomeCreator.BlockType.Warning)
                    {
                        landArray[i, j] = BiomeCreator.BlockType.Lightning;
                    }
                }
            }
            for (int i = 0; i < GetLandArrayLen1(); i++)
            {
                landArray[GetOffset(), i] = BiomeCreator.BlockType.Grass;
            }
            for (int i = 0; i < GetLandArrayLen1(); i++)
            {
                if(landArray[GetOffset()-1, i] == BiomeCreator.BlockType.Lightning && player.GetPlayerBlock() == i)
                {                 
                    player.LoseLive();
                }
            }
        }
        /// <summary>
        /// changes all lightnings back to sky.
        /// </summary>
        public void RemoveLightning()
        {
            for (int i = 0; i < GetOffset(); i++)
            {
                for (int j = 0; j < GetLandArrayLen1(); j++)
                {
                    landArray[i, j] = BiomeCreator.BlockType.Sky;
                }
            }
        }
        public BiomeCreator.BlockType[,] GetArray()
        {
            return landArray;
        }
        public int GetLandArrayLen0()
        {
            return landArray.GetLength(0);
        }
        public Difficulty GetDifficulty()
        {
            return difficulty;
        }
        public int GetLandArrayLen1()
        {
            return landArray.GetLength(1);
        }

        public int GetWidth()
        {
            return blockWidth;
        }
        public int GetOffset()
        {
            return biomeCreator.GetOffset();
        }
        public int GetHeight()
        {
            return blockHeight;
        }
    }
}
