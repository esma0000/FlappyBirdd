namespace FlapyBird
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            bird = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)bird).BeginInit();
            SuspendLayout();
            // 
            // bird
            // 
            bird.BackColor = Color.Transparent;
            bird.Image = Properties.Resources.kus1;
            bird.Location = new Point(36, 285);
            bird.Name = "bird";
            bird.Size = new Size(70, 52);
            bird.SizeMode = PictureBoxSizeMode.StretchImage;
            bird.TabIndex = 0;
            bird.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1039, 624);
            Controls.Add(bird);
            Name = "Form1";
            Text = " ";
            ((System.ComponentModel.ISupportInitialize)bird).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox bird;
    }
}
