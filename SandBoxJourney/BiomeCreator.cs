using System;
using System.Drawing;
using System.Windows.Forms;

namespace SandBoxJourney
{
    
    internal class BiomeCreator
    {
        static Random random = new Random();

        // Block Type available
        public enum BlockType
        {
            Sky,
            Grass,
            Dirt,
            Barrier,
            Warning,
            Lightning
        }
        int blockWidth;
        int blockHeight;
        int grassLayer;

        PictureBox[] currentPicturesShowen = new PictureBox[10];
        int pictureCount = 0;

        /// <summary>
        /// Builder for class
        /// </summary>
        /// <param name="blockWidth">Width of a block</param>
        /// <param name="blockHeight">Height of a block</param>
        public BiomeCreator(int blockWidth, int blockHeight)
        {
            this.blockWidth = blockWidth;
            this.blockHeight = blockHeight;
        }

        /// <summary>
        /// Calculates the "grass layer" of the map
        /// Under that level, dirt, above it, sky.
        /// </summary>
        /// <param name="lenZero">The length of vertical matrix</param>
        /// <returns>The grass level</returns>
        int CreateGrassLayer(int lenZero)
        {
            int grassLayer = lenZero / 2 + 1 + random.Next(2);

            return grassLayer >= 5 ? grassLayer : 5;
        }


        /// <summary>
        /// Creating the grass level, the land array with the given lengths
        /// setting the blockType,
        /// </summary>
        /// <param name="lenZero">The length of vertical matrix</param>
        /// <param name="lenOne">The length of horizental matrix</param>
        /// <returns>The blocks array with values</returns>
        public BlockType[,] BaseGenerator(int lenZero, int lenOne)
        {
            BlockType[,] landArray = new BlockType[lenZero, lenOne];
            grassLayer = CreateGrassLayer(lenZero); 
            for (int i = 0; i < lenZero; i++)
            {
                for (int j = 0; j < lenOne; j++)
                {
                    if (i > grassLayer)
                    {
                        landArray[i, j] = BlockType.Dirt;
                    }
                    else if (i == grassLayer)
                    {
                        landArray[i, j] = BlockType.Grass;
                    }
                    else
                    {
                        landArray[i, j] = BlockType.Sky;
                    }
                }
            }

            PlainTrees(landArray);

            return landArray;

        }

        /// <summary>
        /// Handles the tree creation, random amount
        /// based on the length of the map, and makes sure
        /// trees wont 'stack' on each other.
        /// later, puts trees on random places of the allowed ones,
        /// </summary>
        /// <param name="landArray">the game array</param>
        void PlainTrees(BlockType[,] landArray)
        {
            // Creates the y location of the ground
            int groundY = grassLayer * blockHeight;
            // Randomize tree count
            int treeCount = random.Next(1, landArray.GetLength(1) / 3);
            int groundX;
            bool[] hasTreeX = new bool[landArray.GetLength(1)];

            for (int i = 0; i < hasTreeX.Length; i++)
            {
                hasTreeX[i] = false;
            }
            /*
             * sets to true all the possible locations for a tree to spawn.
             * each tree need a space of 1 each side to not be stacked on each other
            */
            for (int i = 1; i < hasTreeX.Length - 2; i++)
            {
                if (i == 1)
                {
                    hasTreeX[i] = true;
                }
                else if(hasTreeX[i-1] == false && hasTreeX[i-2] == false && hasTreeX[i + 1] == false && hasTreeX[i + 2] == false)
                {
                    hasTreeX[i] = true;
                }
            }
            /*
             * using the tree count, randomzing the location of which the tree will spawn in
             * and adds it to the picture arrray.
            */
            for (int i = 0; i < treeCount; i++)
            {
                do
                {
                    groundX = random.Next(1, hasTreeX.Length);
                } while (!hasTreeX[groundX]);
                hasTreeX[groundX] = false;

                currentPicturesShowen[pictureCount] = new PictureBox
                {
                    Name = "pictureBox",
                    BackColor = Color.Transparent,
                    Size = new Size(blockWidth * 3, blockHeight * 5),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(groundX * blockWidth, groundY - blockHeight * 5 + blockHeight / 5),
                    Image = new Bitmap(Properties.Resources.Tree),
                };

                pictureCount++;
            }
        }

        public int GetPicutreCount()
        {
            return pictureCount;
        }
        public int GetOffset()
        {
            return grassLayer;
        }
        public PictureBox[] GetPicutreArray()
        {
            return currentPicturesShowen;
        }
    }
}
