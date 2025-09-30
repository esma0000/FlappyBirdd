using System.Windows.Forms;
using System.Drawing;

namespace FlapyBird
{
    public partial class Form1 : Form
    {
        int gravity = 8;
        int pipeSpeed = 8;
        int score = 0;
        System.Windows.Forms.Timer gameTimer = new System.Windows.Forms.Timer();

        const int pipeCount = 3;
        const int pipeGap = 180; // Borular arasý boþluk
        Random rnd = new Random();

        PictureBox[] pipeTops;
        PictureBox[] pipeBottoms;
        Label labelScore; // Sýnýfýn baþýna ekledik

        public Form1()
        {
            InitializeComponent(); 

            // Dinamik boru dizileri oluþtur
            pipeTops = new PictureBox[pipeCount];
            pipeBottoms = new PictureBox[pipeCount];

            for (int i = 0; i < pipeCount; i++)
            {
                // Üst boru
                pipeTops[i] = new PictureBox();
                pipeTops[i].Image = Properties.Resources.boru;
                pipeTops[i].SizeMode = PictureBoxSizeMode.StretchImage;
                pipeTops[i].BackColor = Color.Transparent;
                pipeTops[i].Width = 89;
                pipeTops[i].Height = rnd.Next(100, 300);
                pipeTops[i].Left = 400 + i * 300;
                pipeTops[i].Top = -50;
                this.Controls.Add(pipeTops[i]);
                pipeTops[i].BringToFront();

                // Alt boru
                pipeBottoms[i] = new PictureBox();
                pipeBottoms[i].Image = Properties.Resources.boru;
                pipeBottoms[i].SizeMode = PictureBoxSizeMode.StretchImage;
                pipeBottoms[i].BackColor = Color.Transparent;
                pipeBottoms[i].Width = 89;
                pipeBottoms[i].Height = this.ClientSize.Height - pipeTops[i].Height - pipeGap;
                pipeBottoms[i].Left = pipeTops[i].Left;
                pipeBottoms[i].Top = pipeTops[i].Height + pipeGap;
                this.Controls.Add(pipeBottoms[i]);
                pipeBottoms[i].BringToFront();
            }

            bird.BringToFront();

            // Skor etiketi ayarlarý
            labelScore = new Label();
            labelScore.Font = new Font("Arial", 18, FontStyle.Bold);
            labelScore.ForeColor = Color.White;
            labelScore.BackColor = Color.Transparent;
            labelScore.AutoSize = true;
            labelScore.Left = 20;
            labelScore.Top = 20;
            labelScore.Text = "Skor: 0";
            this.Controls.Add(labelScore);
            labelScore.BringToFront();

            gameTimer.Interval = 20;
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();

            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            bird.Top += gravity;

            for (int i = 0; i < pipeCount; i++)
            {
                pipeTops[i].Left -= pipeSpeed;
                pipeBottoms[i].Left -= pipeSpeed;

                // Borular ekran dýþýna çýkýnca tekrar baþa al ve yükseklikleri rastgele ayarla
                if (pipeTops[i].Left < -pipeTops[i].Width)
                {
                    pipeTops[i].Height = rnd.Next(100, 300);
                    pipeTops[i].Left = this.ClientSize.Width;
                    pipeBottoms[i].Height = this.ClientSize.Height - pipeTops[i].Height - pipeGap;
                    pipeBottoms[i].Left = pipeTops[i].Left;
                    pipeBottoms[i].Top = pipeTops[i].Height + pipeGap;
                    score++;
                    labelScore.Text = "Skor: " + score;
                }
                else
                {
                    pipeBottoms[i].Left = pipeTops[i].Left;
                    pipeBottoms[i].Top = pipeTops[i].Height + pipeGap;
                }

                // Çarpýþma kontrolü
                if (bird.Bounds.IntersectsWith(pipeTops[i].Bounds) ||
                    bird.Bounds.IntersectsWith(pipeBottoms[i].Bounds))
                {
                    GameOver();
                    return;
                }
            }

            if (bird.Top < 0 || bird.Bottom > this.ClientSize.Height)
            {
                GameOver();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -12;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 8;
            }
        }

        private void pipeTop_Click(object sender, EventArgs e)
        {
            // Boruya týklanýnca bir þey yapýlmayacak
        }

        private void RestartGame()
        {
            score = 0;
            labelScore.Text = "Skor: 0";
            bird.Top = this.ClientSize.Height / 2;

            for (int i = 0; i < pipeCount; i++)
            {
                pipeTops[i].Height = rnd.Next(100, 300);
                pipeTops[i].Left = 400 + i * 300;
                pipeBottoms[i].Height = this.ClientSize.Height - pipeTops[i].Height - pipeGap;
                pipeBottoms[i].Left = pipeTops[i].Left;
                pipeBottoms[i].Top = pipeTops[i].Height + pipeGap;
            }

            gravity = 8;
            gameTimer.Start();
        }

        private void GameOver()
        {
            gameTimer.Stop();
            var result = MessageBox.Show("Oyun Bitti! Skor: " + score + "\nTekrar oynamak ister misiniz?", "Oyun Bitti", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                RestartGame();
            }
            else
            {
                this.Close();
            }
        }
    }
}
