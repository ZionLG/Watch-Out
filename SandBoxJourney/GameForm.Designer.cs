namespace SandBoxJourney
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.locationValue = new System.Windows.Forms.Label();
            this.Lightning = new System.Windows.Forms.Timer(this.components);
            this.RemoveLightning = new System.Windows.Forms.Timer(this.components);
            this.Break = new System.Windows.Forms.Timer(this.components);
            this.TextBreak = new System.Windows.Forms.Timer(this.components);
            this.lives = new System.Windows.Forms.Label();
            this.QuestionPanel = new System.Windows.Forms.Panel();
            this.answer = new System.Windows.Forms.Button();
            this.Question = new System.Windows.Forms.Label();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.QuestionTitle = new System.Windows.Forms.Label();
            this.locationLabel = new System.Windows.Forms.Label();
            this.livesLabel = new System.Windows.Forms.Label();
            this.backMenu = new System.Windows.Forms.Button();
            this.WalkTimerRight = new System.Windows.Forms.Timer(this.components);
            this.WalkTimerLeft = new System.Windows.Forms.Timer(this.components);
            this.QuestionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // locationValue
            // 
            this.locationValue.AutoSize = true;
            this.locationValue.BackColor = System.Drawing.Color.Transparent;
            this.locationValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.locationValue.Location = new System.Drawing.Point(767, 5);
            this.locationValue.Name = "locationValue";
            this.locationValue.Size = new System.Drawing.Size(21, 24);
            this.locationValue.TabIndex = 0;
            this.locationValue.Text = "0";
            // 
            // Lightning
            // 
            this.Lightning.Interval = 2000;
            this.Lightning.Tick += new System.EventHandler(this.Warning_Lightning_Tick);
            // 
            // RemoveLightning
            // 
            this.RemoveLightning.Interval = 1000;
            this.RemoveLightning.Tick += new System.EventHandler(this.RemoveLightning_Tick);
            // 
            // Break
            // 
            this.Break.Interval = 200;
            this.Break.Tick += new System.EventHandler(this.Break_Tick);
            // 
            // TextBreak
            // 
            this.TextBreak.Enabled = true;
            this.TextBreak.Interval = 1;
            this.TextBreak.Tick += new System.EventHandler(this.TextBreak_Tick);
            // 
            // lives
            // 
            this.lives.AutoSize = true;
            this.lives.BackColor = System.Drawing.Color.Transparent;
            this.lives.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lives.Location = new System.Drawing.Point(76, 9);
            this.lives.Name = "lives";
            this.lives.Size = new System.Drawing.Size(21, 24);
            this.lives.TabIndex = 1;
            this.lives.Text = "3";
            // 
            // QuestionPanel
            // 
            this.QuestionPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.QuestionPanel.Controls.Add(this.answer);
            this.QuestionPanel.Controls.Add(this.Question);
            this.QuestionPanel.Controls.Add(this.radioButton4);
            this.QuestionPanel.Controls.Add(this.radioButton3);
            this.QuestionPanel.Controls.Add(this.radioButton2);
            this.QuestionPanel.Controls.Add(this.radioButton1);
            this.QuestionPanel.Controls.Add(this.QuestionTitle);
            this.QuestionPanel.Location = new System.Drawing.Point(96, 55);
            this.QuestionPanel.Name = "QuestionPanel";
            this.QuestionPanel.Size = new System.Drawing.Size(574, 308);
            this.QuestionPanel.TabIndex = 2;
            this.QuestionPanel.Visible = false;
            // 
            // answer
            // 
            this.answer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.answer.AutoSize = true;
            this.answer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.answer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.answer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.answer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.answer.ForeColor = System.Drawing.Color.RoyalBlue;
            this.answer.Location = new System.Drawing.Point(479, 263);
            this.answer.Name = "answer";
            this.answer.Size = new System.Drawing.Size(93, 43);
            this.answer.TabIndex = 6;
            this.answer.Text = "Send";
            this.answer.UseVisualStyleBackColor = false;
            this.answer.Click += new System.EventHandler(this.answer_Click);
            // 
            // Question
            // 
            this.Question.AutoSize = true;
            this.Question.Location = new System.Drawing.Point(22, 45);
            this.Question.Name = "Question";
            this.Question.Size = new System.Drawing.Size(35, 13);
            this.Question.TabIndex = 5;
            this.Question.Text = "label2";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(25, 142);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(85, 17);
            this.radioButton4.TabIndex = 4;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "radioButton4";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(25, 119);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(85, 17);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "radioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(25, 85);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(85, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(25, 61);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // QuestionTitle
            // 
            this.QuestionTitle.AutoSize = true;
            this.QuestionTitle.ForeColor = System.Drawing.Color.White;
            this.QuestionTitle.Location = new System.Drawing.Point(22, 23);
            this.QuestionTitle.Name = "QuestionTitle";
            this.QuestionTitle.Size = new System.Drawing.Size(35, 13);
            this.QuestionTitle.TabIndex = 0;
            this.QuestionTitle.Text = "label2";
            this.QuestionTitle.Visible = false;
            // 
            // locationLabel
            // 
            this.locationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.locationLabel.AutoSize = true;
            this.locationLabel.BackColor = System.Drawing.Color.Transparent;
            this.locationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.locationLabel.Location = new System.Drawing.Point(675, 5);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(86, 24);
            this.locationLabel.TabIndex = 3;
            this.locationLabel.Text = "Location:";
            // 
            // livesLabel
            // 
            this.livesLabel.AutoSize = true;
            this.livesLabel.BackColor = System.Drawing.Color.Transparent;
            this.livesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.livesLabel.Location = new System.Drawing.Point(12, 9);
            this.livesLabel.Name = "livesLabel";
            this.livesLabel.Size = new System.Drawing.Size(58, 24);
            this.livesLabel.TabIndex = 4;
            this.livesLabel.Text = "Lives:";
            // 
            // backMenu
            // 
            this.backMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.backMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.backMenu.ForeColor = System.Drawing.Color.RoyalBlue;
            this.backMenu.Location = new System.Drawing.Point(12, 381);
            this.backMenu.Name = "backMenu";
            this.backMenu.Size = new System.Drawing.Size(155, 57);
            this.backMenu.TabIndex = 7;
            this.backMenu.Text = "Menu";
            this.backMenu.UseVisualStyleBackColor = false;
            this.backMenu.Click += new System.EventHandler(this.backMenu_Click);
            // 
            // WalkTimerRight
            // 
            this.WalkTimerRight.Interval = 1;
            this.WalkTimerRight.Tick += new System.EventHandler(this.WalkTimerRight_Tick);
            // 
            // WalkTimerLeft
            // 
            this.WalkTimerLeft.Interval = 1;
            this.WalkTimerLeft.Tick += new System.EventHandler(this.WalkTimerLeft_Tick);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backMenu);
            this.Controls.Add(this.livesLabel);
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.QuestionPanel);
            this.Controls.Add(this.lives);
            this.Controls.Add(this.locationValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.QuestionPanel.ResumeLayout(false);
            this.QuestionPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label locationValue;
        private System.Windows.Forms.Timer Lightning;
        private System.Windows.Forms.Timer RemoveLightning;
        private System.Windows.Forms.Timer Break;
        private System.Windows.Forms.Timer TextBreak;
        private System.Windows.Forms.Label lives;
        private System.Windows.Forms.Panel QuestionPanel;
        private System.Windows.Forms.Label QuestionTitle;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label Question;
        private System.Windows.Forms.Button answer;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.Label livesLabel;
        private System.Windows.Forms.Button backMenu;
        private System.Windows.Forms.Timer WalkTimerRight;
        private System.Windows.Forms.Timer WalkTimerLeft;
    }
}

