using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.IO;


namespace SandBoxJourney
{
    public partial class GameForm : Form
    {
        static Random ran = new Random(Guid.NewGuid().GetHashCode());
        Form menu;
        // single block with/height
        int blockWidth;
        int blockHeight;

        // Total amount of blocks
        int blockWidthNumber;
        int blockHeightNumber;

        // Object of the level and player
        LevelBuilder level;
        Player player;

        // is the game started a new level
        bool newLevel;

        // The current progress with the game dialog
        int dialogProgress;

        int answeredQuesions;


        Label TextDialog;

        // How many attacks have been fired in a row.
        int attackRow;
        int maxAttackRow;

        //If there should be another wave of attacks
        bool anotherWave;

        public enum Difficulty
        {
            Tutorial,
            Easy,
            Normal,
            Hard,
            Hardcore
        }

        static string[] UsedId = new string[25];
        static string[] currentQuestion;
        static string[,] Cards = new string[25, 6] {
                { "1", "x^2+5x+7", "2x+5", "x^2+7", "2x+7", "2x+5x" },
                { "2", "x^3+2x+8x^2", "3x^2+16x+2", "x^2+2+8x", "x+2x+8x", "x^2+8+2x" },
                { "3", "x^2+2", "2x", "x+2", "2", "2x+2" },
                { "4", "4x^2+6x+3", "8x+6", "4x+6", "6x+4", "8x+6+3x" },
                { "5", "2x^2+9+4x", "4x+4", "2x+4", "9+4x", "4x+9" },
                { "6", "5x^2+9", "10x", "9x", "5x", "5x+9" },
                { "7", "2x+3x^2+2", "6x+2", "2+3x", "2+3x", "3x+2x" },
                { "8", "5x+5x^2+5", "10x+5", "5x+5", "5x+10x", "10x+5x+5" },
                { "9", "9x+x^2+2", "9+2x", "2+9x", "2x+9x", "2x" },
                { "10", "x^3+2x+1", "3x^2+2", "x^2+2", "3x+2", "3x+2x" },
                { "11", "x^4+x^3+7x", "4x^3+3x^2+7", "4x^2+3x^2+7", "4x+3x+7", "7" },
                { "12", "x+5x", "6", "5", "1", "6x" },
                { "13", "x^2+2x+1", "2x+2", "x^2+2", "2x+1", "2x+2x" },
                { "14", "7x^2+2x+4", "14x+2", "7x^2+2", "7x+2", "4" },
                { "15", "2x^2+3x+9", "4x+3", "2x^2+9", "2x+3x", "2x+9" },
                { "16", "3x^2+2x+5", "6x+2", "3x^2+2", "3x+2", "5x+3x" },
                { "17", "x^2+67x+1", "2x+67", "67", "2x", "x^2+67" },
                { "18", "3x^2+2x+1", "6x+2", "3x^2+2", "3x+2", "2x+5x" },
                { "19", "2x^2+x", "4x+1", "2x+x", "2x+1", "2+1" },
                { "20", "4x^2+2x+11", "8x+2", "4x^2+2", "2x+11", "4x+2x" },
                { "21", "2x^2+5x+35", "4x+5", "35", "2x+5", "4x+35" },
                { "22", "5x^2+93x+12", "10x+93", "5x^2+93", "93x+12", "5x+93x" },
                { "23", "2x^2+23x+2", "4x+23", "2x^2+23", "23x+2", "4x+23x" },
                { "24", "7x^2+12x+76", "14x+12", "7x^2+12", "7x+12", "76" },
                { "25", "9x^2+64x+13", "18x+64", "9x^2+13", "64x+13", "13x+64x" },};
        public GameForm(Form menu, int blockWidth, int blockHeight, int blockWidthNumber, int blockHeightNumber)
        {
            InitializeComponent();
            this.menu = menu;
            this.blockWidth = blockWidth;
            this.blockHeight = blockHeight;
            this.blockWidthNumber = blockWidthNumber;
            this.blockHeightNumber = blockHeightNumber;

            level = new LevelBuilder(blockWidth, blockHeight, blockWidthNumber, blockHeightNumber, Difficulty.Tutorial);
            player = new Player(level, 3, this);
            for (int i = 0; i < UsedId.Length; i++)
            {
                UsedId[i] = String.Empty;
            }
            // New screen size depends on the height, width and amount of blocks
            Size = new Size(blockWidth * blockWidthNumber, blockHeight * blockHeightNumber);
            dialogProgress = 0;
            newLevel = false;
            answeredQuesions = 0;
            attackRow = 0;
            maxAttackRow = 5;
            anotherWave = false;


            TextDialog = new Label();
            CreateDialogLabel();
            livesLabel.Font = new Font("Arial", blockWidth * blockWidthNumber / 36, FontStyle.Bold);
            locationLabel.Font = new Font("Arial", blockWidth * blockWidthNumber / 36, FontStyle.Bold);
            locationLabel.Location = new Point(this.Width - locationLabel.Width * 2, livesLabel.Location.Y);
            lives.Font = new Font("Arial", blockWidth * blockWidthNumber / 36, FontStyle.Bold);
            lives.Location = new Point(livesLabel.Location.X + livesLabel.Width, livesLabel.Location.Y);
            locationValue.Font = new Font("Arial", blockWidth * blockWidthNumber / 36, FontStyle.Bold);
            locationValue.Location = new Point(locationLabel.Location.X + locationLabel.Width, livesLabel.Location.Y);

            backMenu.Location = new Point(backMenu.Location.X, blockWidth * (blockHeightNumber - 1));
            backMenu.Font = new Font("Arial", blockWidth * blockWidthNumber / 36, FontStyle.Bold);
            backMenu.Size = new Size(blockWidth * blockWidthNumber / 6, blockHeight * blockHeightNumber / 12);

            this.DoubleBuffered = true;

            this.KeyPreview = true;

        }
        static string[] GetCard()
        {
            //Chosen card will be the id of our chosen card (eg. "1", "6")
            string chosenCard;

            // Count will make sure there is a possible card, and  that the following
            // loop wont be infinite
            int count = 0;

            string[] card = new string[Cards.GetLength(1)];
            do
            {
                count++;
                // setting card to a random number
                chosenCard = ran.Next(0, Cards.GetLength(0)).ToString();

            } while (IsUsed(chosenCard) && count != Cards.GetLength(0)); // We firstly check that the card wasnt already chosen

            if (count == Cards.GetLength(0))
            {
                card[0] = "Not Found";
                return card;
            }

            // Adding the chosen card to the used id list, so it wont show up again.
            UsedId[int.Parse(chosenCard)] = chosenCard;

            for (int i = 0; i < Cards.GetLength(1); i++)
            {
                card[i] = Cards[int.Parse(chosenCard), i];
            }
            return card;
        }
        static bool IsUsed(string id)
        {
            // Checks that the given card is not used
            for (int i = 0; i < UsedId.Length; i++)
            {
                if (UsedId[i] == id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Setting the panel and its children to a custom size/font/location depending the size of the screen
        /// and randomzing the location of the answers.
        /// </summary>
        void SetQuestionPanel()
        {
            QuestionPanel.Location = new Point(blockWidth, blockHeight);
            QuestionPanel.Size = new Size(blockWidth * blockWidthNumber - blockWidth * 2, blockHeight * blockHeightNumber - blockHeight * 2);
            currentQuestion = GetCard();


            QuestionTitle.Font = new Font("Arial", (blockWidth * blockWidthNumber - blockWidth * 2) / 36, FontStyle.Bold);
            QuestionTitle.Location = new Point(blockWidth / 10, blockHeight / 10);
            QuestionTitle.Text = "Please solve the following Derivative:";

            Question.Text = currentQuestion[1];
            Question.Font = new Font("Arial", (blockWidth * blockWidthNumber - blockWidth * 2) / 24, FontStyle.Bold);
            Question.Location = new Point(blockWidth / 10, blockHeight);

            radioButton1.Location = new Point(blockWidth / 10, blockHeight * 2);
            radioButton1.Font = new Font("Arial", (blockWidth * blockWidthNumber - blockWidth * 2) / 24, FontStyle.Bold);

            radioButton2.Location = new Point(blockWidth / 10, blockHeight * (blockHeightNumber /2 ));
            radioButton2.Font = new Font("Arial", (blockWidth * blockWidthNumber - blockWidth * 2) / 24, FontStyle.Bold);

            radioButton3.Location = new Point(blockWidth * (blockWidthNumber - 2) / 2, blockHeight * 2);
            radioButton3.Font = new Font("Arial", (blockWidth * blockWidthNumber - blockWidth * 2) / 24, FontStyle.Bold);

            radioButton4.Location = new Point(blockWidth * (blockWidthNumber - 2) / 2, blockHeight * (blockHeightNumber /2) );
            radioButton4.Font = new Font("Arial", (blockWidth * blockWidthNumber - blockWidth * 2) / 24, FontStyle.Bold);

            answer.Font = new Font("Arial", (blockWidth * blockWidthNumber - blockWidth * 2) / 24, FontStyle.Bold);

            switch (ran.Next(1, 5))
            {
                case 1:
                    radioButton1.Text = currentQuestion[2];
                    radioButton2.Text = currentQuestion[3];
                    radioButton3.Text = currentQuestion[4];
                    radioButton4.Text = currentQuestion[5];
                    break;
                case 2:
                    radioButton1.Text = currentQuestion[3];
                    radioButton2.Text = currentQuestion[2];
                    radioButton3.Text = currentQuestion[4];
                    radioButton4.Text = currentQuestion[5];
                    break;
                case 3:
                    radioButton1.Text = currentQuestion[4];
                    radioButton2.Text = currentQuestion[3];
                    radioButton3.Text = currentQuestion[2];
                    radioButton4.Text = currentQuestion[5];
                    break;
                case 4:
                    radioButton1.Text = currentQuestion[5];
                    radioButton2.Text = currentQuestion[3];
                    radioButton3.Text = currentQuestion[4];
                    radioButton4.Text = currentQuestion[2];
                    break;
            }


        }
        /// <summary>
        /// Creating the dialog label that speaks to the player
        /// </summary>
        void CreateDialogLabel()
        {
            TextDialog.MaximumSize = new Size(blockWidth * blockWidthNumber, blockWidth * 2);
            TextDialog.Font = new Font("Arial", blockWidth * blockWidthNumber / 36, FontStyle.Bold);
            TextDialog.Location = new Point(0, blockWidth);
            TextDialog.AutoSize = true;
            TextDialog.BackColor = Color.Transparent;
            this.Controls.Add(TextDialog);

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            level.DrawLevel(e, this);

        }

        /// <summary>
        /// checks the key pressed and moving right/left depending the key.
        /// changing the block location label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            var picturePlayer = player.GetPlayer();
            switch (e.KeyCode) // Get the value of the key pressed
            {
                case Keys.Left:
                    if (player.GetPlayerBlock() > 0 && player.GetCanMove())
                    {
                        player.BackBlock();
                        WalkTimerLeft.Enabled = true;
                        locationValue.Text = player.GetPlayerBlock().ToString();
                    }

                    break;
                case Keys.Right:
                    if (player.GetPlayerBlock() < level.GetLandArrayLen1() - 1 && player.GetCanMove())
                    {
                        //player.GoRight(this);
                        player.FowardBlock();
                        WalkTimerRight.Enabled = true;
                        locationValue.Text = player.GetPlayerBlock().ToString();
                    }                      
                    break;
            }
        }


        /// <summary>
        /// Drawing te player on load and gets his starting location
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            player.DrawPlayer(this, 0);
            locationValue.Text = player.GetPlayerBlock().ToString();
        }

        /// <summary>
        /// Gets the current health in a local variable
        /// removes to warnings and replacing them with the lightning,
        /// if the player hit the lightning it will make him lose health
        /// if the current health (before firing the lightnings) is not the same
        /// as the current health (after the lightning), we can assume he got hit
        /// which will trigger the question panel
        /// and stop the timers/player movement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Warning_Lightning_Tick(object sender, EventArgs e)
        {
            int currentHealth = player.GetLives();
            level.RemoveWarnings(player, this);
            this.Invalidate();

            if (currentHealth != player.GetLives())
            {
                Lightning.Enabled = false;
                player.SetCantMove();
                SetQuestionPanel();
                QuestionPanel.Visible = true;
                QuestionTitle.Visible = true;
                return;

            }

            Lightning.Enabled = false;
            RemoveLightning.Enabled = true;
        }

        // Remove the lightnings
        private void RemoveLightning_Tick(object sender, EventArgs e)
        {
            level.RemoveLightning();
            this.Invalidate();
            RemoveLightning.Enabled = false;
            Break.Enabled = true;
        }

      
        private void Break_Tick(object sender, EventArgs e)
        {

            if (anotherWave)
            {

                if (attackRow == maxAttackRow)
                {
                    anotherWave = false;
                    TextBreak.Enabled = true;
                    Break.Enabled = false;
                    return;

                }
                // Start a new wave
                level.StartWave();
                this.Invalidate();
                // Start the warnning-lightning timer
                Lightning.Enabled = true;
                attackRow++;
            }

            Break.Enabled = false;
        }


        /// <summary>
        /// Takes care of game progression
        /// </summary>
        private void TextBreak_Tick(object sender, EventArgs e)
        {
            switch (dialogProgress)
            {
                case 0:
                    TextDialog.Text = "Welcome!";
                    TextBreak.Interval = 1000;
                    break;
                case 1:
                    TextDialog.Text = "This is 'Watch out!', and I'm here to explain what's going on here!";
                    TextBreak.Interval = 4000;
                    break;
                case 2:
                    TextDialog.Text = "This is the 'Tutorial Level', it should be easy for you to pass!";
                    TextBreak.Interval = 3000;
                    break;
                case 3:
                    TextDialog.Text = "You can move by pressing the Arrow Keys!, give it a shot.";
                    TextBreak.Interval = 5000;
                    break;
                case 4:
                    TextDialog.Text = "As you see, the entire game is randomly generated, from trees, to terrain, to attacks.";
                    TextBreak.Interval = 5000;
                    break;
                case 5:
                    NewLevel("Lets start.", Difficulty.Tutorial, 2000);
                    break;
                case 6:
                    TextDialog.Text = "Great!, Now, In this game the player need to watch out from falling lightnings";
                    break;
                case 7:
                    TextDialog.Text = "When the floor turns Red, you will know that a Lightning is near.. Wait.. WATCH OUT!";
                    break;
                case 8:
                    Attack("When the floor turns Red, you will know that a Lightning is near.. Wait.. WATCH OUT!", 0, 1000);
                    TextBreak.Interval = 2000;
                    break;
                case 9:
                    if (player.GetLives() == 3)
                    {
                        TextDialog.Text = "Good job!, I see more waves of lightnings on their way, watch out!";
                    }
                    else
                    {
                        TextDialog.Text = "Dont worry, you still have more chances!, Try better next time";
                    }
                    break;
                case 10:
                    RemoveLightning.Interval = 500;
                    TextBreak.Interval = 3000;
                    Attack("More on their way, they will be faster this time!", 5, 1000);
                    break;
                case 11:
                    NewLevel("Great job!. Level ended.", Difficulty.Easy, 1500);
                    break;
                case 12:
                    RemoveLightning.Interval = 250;
                    Attack("Lets see you deal with THIS", 5, 800);
                    break;
                case 13:
                    Attack("GET THIS", 10, 800);
                    break;
                case 14:
                    NewLevel("Very well, level over.", Difficulty.Normal, 1200);
                    break;

                case 15:
                    Attack("Good luck this time.", 5, 800);
                    break;
                case 16:
                    Attack("GET THIS", 10, 800);
                    break;
                case 17:
                    NewLevel("HOW?", Difficulty.Hard, 1000);
                    break;
                case 18:
                    Attack("Bye bye", 5, 700);
                    break;
                case 19:
                    Attack("YOU WILL LOSE THIS", 10, 700);
                    break;
                case 20:
                    NewLevel("...?", Difficulty.Hardcore, 800);
                    break;
                case 21:
                    Attack("No way..", 5, 600);
                    break;
                case 22:
                    Attack("YOU CANT BEAT ME", 10, 600);
                    break;
                default:
                    Win win = new Win(menu);
                    win.Show();
                    this.Hide();

                    break;
            }

            dialogProgress++;
        }

        /// <summary>
        /// taking care of all timers and booleans for a new attack to start.
        /// </summary>
        /// <param name="text">The text to show on the dialog</param>
        /// <param name="maxAttacks">max row of strikes for this attack</param>
        /// <param name="interval">lighting timer interval, the less, the harder next time.</param>
        private void Attack(string text, int maxAttacks, int interval)
        {
            attackRow = 0;
            TextDialog.Text = text;
            maxAttackRow = maxAttacks;
            level.StartWave();
            newLevel = false;
            anotherWave = true;
            Lightning.Enabled = true;
            Lightning.Interval = interval;
            TextBreak.Enabled = false;
            this.Invalidate();
        }
        /// <summary>
        /// same as Attack, but creates a new level and player.
        /// </summary>
        /// <param name="text">The text to show on the dialog</param>
        /// <param name="maxAttacks">max row of strikes for this attack</param>
        /// <param name="interval">lighting timer interval, the less, the harder next time.</param>
        private void NewLevel(string text, Difficulty difficulty, int interval)
        {
            attackRow = 0;
            TextDialog.Text = text;
            maxAttackRow = 5;
            newLevel = true;
            TextBreak.Enabled = false;

            SetQuestionPanel();

            /* Normaly, the player touches a lightning (which takes a life)
            / to trigger the panel, not in this case.
            / therefore, we need to make the player lose a life
            / so if he gets the question right, it will give him what he lost.
            */
            player.LoseLive();
            QuestionPanel.Visible = true;
            QuestionTitle.Visible = true;

            level.DisposePictures(this);

            level = new LevelBuilder(blockWidth, blockHeight, blockWidthNumber, blockHeightNumber, difficulty);
            int currentHealth = player.GetLives();
            player.PlayerDispose(this);
            player = new Player(level, currentHealth, this);
            player.SetCantMove();
            player.DrawPlayer(this, 0);
            locationValue.Text = player.GetPlayerBlock().ToString();
            Lightning.Interval = interval;

            this.Invalidate();
        }
        
        /// <summary>
        /// creates a radio array, and checks if the checked one
        /// equals to the right answer, if yes, regain a life.
        /// if its checked but WRONG, it will just continue the game.
        /// if health is now 0 after getting it wrong, it game is over.
        /// </summary>
        private void answer_Click(object sender, EventArgs e)
        {
            RadioButton[] radios = { radioButton1, radioButton2, radioButton3, radioButton4 };
            for (int i = 0; i < radios.Length; i++)
            {
                if (radios[i].Checked)
                {
                    if (radios[i].Text == currentQuestion[2])
                    {
                        player.AddLive();
                        lives.Text = player.GetLives().ToString();
                        HidePanel();
                        answeredQuesions++;
                        if (answeredQuesions > 5)
                        {
                            Win win = new Win(menu);
                            win.Show();
                            this.Hide();
                        }
                        return;
                    }
                    else
                    {
                        lives.Text = player.GetLives().ToString();
                        if (player.GetLives() <= 0)
                        {
                            Lost lost = new Lost(menu);
                            lost.Show();
                            this.Hide();
                            return;
                        }
                        HidePanel();
                        return;

                    }
                }
            }

        }
        /// <summary>
        /// Hides the question panel
        /// </summary>
        private void HidePanel()
        {
            this.KeyPreview = true;
            player.SetMove();
            QuestionPanel.Visible = false;
            QuestionTitle.Visible = false;
            RemoveLightning.Enabled = true;
            if (newLevel)
            {
                TextBreak.Enabled = true;
            }
        }


        private void backMenu_Click(object sender, EventArgs e)
        {
            menu.Show();
            this.Hide();
        }

        /// <summary>
        /// When triggered from the keyup event, the function 
        /// moves the playerBlock by 1.
        /// this function is moving the player from its current X location
        /// to the wanted location of playerBlock.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WalkTimerLeft_Tick(object sender, EventArgs e)
        {
            if (player.GetPlayer().Location.X - (level.GetWidth() / 10) > player.GetPlayerBlock() * level.GetWidth())
            {
                player.DrawPlayer(this, player.GetPlayer().Location.X - (level.GetWidth() / 10));
            }
            else
            {
                player.DrawPlayer(this, player.GetPlayerBlock() * level.GetWidth());
                WalkTimerLeft.Enabled = false;
            }
        }

        /// <summary>
        /// When triggered from the keyup event, the function 
        /// moves the playerBlock by 1.
        /// this function is moving the player from its current X location
        /// to the wanted location of playerBlock.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WalkTimerRight_Tick(object sender, EventArgs e)
        {
            if (player.GetPlayer().Location.X + (level.GetWidth() / 10) < player.GetPlayerBlock() * level.GetWidth())
            {
                player.DrawPlayer(this, player.GetPlayer().Location.X + (level.GetWidth() / 10));
            }
            else
            {
                player.DrawPlayer(this, player.GetPlayerBlock() * level.GetWidth());
                WalkTimerRight.Enabled = false;
            }
        }
    }
}
