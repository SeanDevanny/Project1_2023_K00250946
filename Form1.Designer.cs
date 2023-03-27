namespace Project1_2023_K00250946
{
    partial class Form1
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
            this.episodesListBox = new System.Windows.Forms.ListBox();
            this.podcastsListBox = new System.Windows.Forms.ListBox();
            this.descriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.episodeLabel = new System.Windows.Forms.Label();
            this.podcastPictureBox = new System.Windows.Forms.PictureBox();
            this.playButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.podcastPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // episodesListBox
            // 
            this.episodesListBox.FormattingEnabled = true;
            this.episodesListBox.Location = new System.Drawing.Point(247, 182);
            this.episodesListBox.Name = "episodesListBox";
            this.episodesListBox.Size = new System.Drawing.Size(532, 225);
            this.episodesListBox.TabIndex = 0;
            this.episodesListBox.SelectedIndexChanged += new System.EventHandler(this.episodesListBox_SelectedIndexChanged);
            // 
            // podcastsListBox
            // 
            this.podcastsListBox.FormattingEnabled = true;
            this.podcastsListBox.Location = new System.Drawing.Point(12, 13);
            this.podcastsListBox.Name = "podcastsListBox";
            this.podcastsListBox.Size = new System.Drawing.Size(229, 394);
            this.podcastsListBox.TabIndex = 1;
            this.podcastsListBox.SelectedIndexChanged += new System.EventHandler(this.podcastsListBox_SelectedIndexChanged);
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.descriptionTextBox.Location = new System.Drawing.Point(247, 50);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.Size = new System.Drawing.Size(405, 121);
            this.descriptionTextBox.TabIndex = 2;
            this.descriptionTextBox.Text = "";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("HP Simplified", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(247, 13);
            this.titleLabel.MaximumSize = new System.Drawing.Size(3000, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(335, 20);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "Welcome! Select or add a podcast title to begin!";
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(695, 413);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(84, 25);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(605, 413);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(84, 25);
            this.pauseButton.TabIndex = 5;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 413);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(84, 25);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // episodeLabel
            // 
            this.episodeLabel.AutoSize = true;
            this.episodeLabel.Location = new System.Drawing.Point(248, 33);
            this.episodeLabel.Name = "episodeLabel";
            this.episodeLabel.Size = new System.Drawing.Size(0, 13);
            this.episodeLabel.TabIndex = 7;
            // 
            // podcastPictureBox
            // 
            this.podcastPictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.podcastPictureBox.ImageLocation = "";
            this.podcastPictureBox.Location = new System.Drawing.Point(658, 50);
            this.podcastPictureBox.Name = "podcastPictureBox";
            this.podcastPictureBox.Size = new System.Drawing.Size(121, 121);
            this.podcastPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.podcastPictureBox.TabIndex = 8;
            this.podcastPictureBox.TabStop = false;
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(515, 413);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(84, 25);
            this.playButton.TabIndex = 9;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.podcastPictureBox);
            this.Controls.Add(this.episodeLabel);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.podcastsListBox);
            this.Controls.Add(this.episodesListBox);
            this.Name = "Form1";
            this.Text = "Podcast Player";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.podcastPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox episodesListBox;
        private System.Windows.Forms.ListBox podcastsListBox;
        private System.Windows.Forms.RichTextBox descriptionTextBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label episodeLabel;
        private System.Windows.Forms.PictureBox podcastPictureBox;
        private System.Windows.Forms.Button playButton;
    }
}

