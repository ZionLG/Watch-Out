namespace SandBoxJourney
{
    partial class GameOpener
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toMenu = new System.Windows.Forms.Button();
            this.appClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 48F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Tomato;
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 79);
            this.label1.TabIndex = 11;
            this.label1.Text = "Watch Out!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(271, 390);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(373, 43);
            this.label2.TabIndex = 10;
            this.label2.Text = "By Liran Goldman - 17/10";
            // 
            // toMenu
            // 
            this.toMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.toMenu.ForeColor = System.Drawing.Color.RoyalBlue;
            this.toMenu.Location = new System.Drawing.Point(327, 214);
            this.toMenu.Name = "toMenu";
            this.toMenu.Size = new System.Drawing.Size(155, 57);
            this.toMenu.TabIndex = 9;
            this.toMenu.Text = "Menu";
            this.toMenu.UseVisualStyleBackColor = false;
            this.toMenu.Click += new System.EventHandler(this.toMenu_Click);
            // 
            // appClose
            // 
            this.appClose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.appClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.appClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.appClose.ForeColor = System.Drawing.Color.RoyalBlue;
            this.appClose.Location = new System.Drawing.Point(15, 383);
            this.appClose.Name = "appClose";
            this.appClose.Size = new System.Drawing.Size(155, 57);
            this.appClose.TabIndex = 8;
            this.appClose.Text = "Close";
            this.appClose.UseVisualStyleBackColor = false;
            this.appClose.Click += new System.EventHandler(this.appClose_Click);
            // 
            // GameOpener
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toMenu);
            this.Controls.Add(this.appClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameOpener";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameOpener";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button toMenu;
        private System.Windows.Forms.Button appClose;
    }
}