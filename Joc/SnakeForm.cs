using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Joc.Properties;

namespace Joc
{
    public partial class SnakeForm : Form
    {
        private List<CercSarpe> Snake = new List<CercSarpe>();
        private CercSarpe food = new CercSarpe();
        int maxWidth;
        int maxHeight;
        int score;
        int highScore;
        Random rand = new Random();
        bool goLeft, goRight, goDown, goUp;
        private string connStr = @"Server=localhost\SQLEXPRESS;Database=Joc1;Trusted_Connection=True;";

        Timer gameTimer = new Timer();
        private string name;
        public SnakeForm(string nume)
        {
            InitializeComponent();
            new Setari();
            gameTimer.Enabled = false;
            gameTimer.Interval = 50;
            gameTimer.Tick += GameTimerEvent;
            name = nume;
            highScore = GetHighScore(name);
            txtHighScore.Text = "High Score: " + Environment.NewLine + highScore;
            txtHighScore.ForeColor = Color.Maroon;
            txtHighScore.TextAlign = ContentAlignment.MiddleCenter;
        }

        private int GetHighScore(string nume)
        {
            int hs;
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetHighScore";
                    cmd.Parameters.AddWithValue("@nume", nume);
                    var rd = cmd.ExecuteReader();
                    rd.Read();
                    hs = (int)rd[0];

                    rd.Close();
                }
            }
            return hs;
        }
        private void UpdateHighScore(string nume, int highScore )
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spUpdateHighScore";
                    cmd.Parameters.AddWithValue("@nume", nume);
                    cmd.Parameters.AddWithValue("@highScore", highScore);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void GameTimerEvent(object sender, EventArgs e)
        {
            if (goLeft)
            {
                Setari.directie = "left";
            }
            if (goRight)
            {
                Setari.directie = "right";
            }
            if (goDown)
            {
                Setari.directie = "down";
            }
            if (goUp)
            {
                Setari.directie = "up";
            }

            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Setari.directie)
                    {
                        case "left":
                            Snake[i].X--;
                            break;
                        case "right":
                            Snake[i].X++;
                            break;
                        case "down":
                            Snake[i].Y++;
                            break;
                        case "up":
                            Snake[i].Y--;
                            break;
                    }
                    if (Snake[i].X < 0)
                    {
                        GameOver();
                    }
                    if (Snake[i].X > maxWidth)
                    {
                        GameOver();
                    }
                    if (Snake[i].Y < 0)
                    {
                        GameOver();
                    }
                    if (Snake[i].Y > maxHeight)
                    {
                        GameOver();
                    }
                    if (Snake[i].X == food.X && Snake[i].Y == food.Y)
                    {
                        EatFood();
                    }
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            GameOver();
                        }
                    }
                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
            pbCanvas.Invalidate();
        }
        private void SnakeForm_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            goLeft = false;
            goRight = false;
            goUp = false;
            goDown = false;

            if ((e.KeyCode == Keys.Left || e.KeyCode == Keys.A)&& Setari.directie != "right")
            {
                goLeft = true;
            }
            if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.D)&& Setari.directie != "left")
            {
                goRight = true;
            }
            if ((e.KeyCode == Keys.Up || e.KeyCode == Keys.W) && Setari.directie != "down")
            {
                goUp = true;
            }
            if ((e.KeyCode == Keys.Down || e.KeyCode == Keys.S) && Setari.directie != "up")
            {
                goDown = true;
            }
        }
        private void SnakeForm_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                goDown = false;
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            maxWidth = pbCanvas.Width / Setari.Width - 1;
            maxHeight = pbCanvas.Height / Setari.Height - 1;
            Snake.Clear();
            btnStart.Enabled = false;
            score = 0;
            Setari.directie = "left";
            txtScore.Text = "Score: " + score;
            CercSarpe head = new CercSarpe { X = 10, Y = 5 };
            Snake.Add(head);
            for (int i = 0; i < 3; i++)
            {
                CercSarpe body = new CercSarpe();
                Snake.Add(body);
            }
            food = new CercSarpe { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
            gameTimer.Start();
        }
        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Brush snakeColour;
            for (int i = 0; i < Snake.Count; i++)
            {
                if (i == 0)
                {
                    snakeColour = Brushes.Black;
                }
                else
                {
                    snakeColour = Brushes.DarkGreen;
                }
                canvas.FillEllipse(snakeColour, new Rectangle
                    (
                    Snake[i].X * Setari.Width,
                    Snake[i].Y * Setari.Height,
                    Setari.Width, Setari.Height
                    ));
            }
            canvas.FillEllipse(Brushes.DarkRed, new Rectangle
            (
            food.X * Setari.Width,
            food.Y * Setari.Height,
            Setari.Width, Setari.Height
            ));
        }
        private void EatFood()
        {
            score += 1;
            txtScore.Text = "Score: " + score;
            CercSarpe body = new CercSarpe
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };
            Snake.Add(body);
            food = new CercSarpe { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
        }
        private void GameOver()
        {
            gameTimer.Stop();
            btnStart.Enabled = true;
            if (score > highScore)
            {
                highScore = score;
                txtHighScore.Text = "High Score: " + Environment.NewLine + highScore;
                txtHighScore.ForeColor = Color.Maroon;
                txtHighScore.TextAlign = ContentAlignment.MiddleCenter;
                UpdateHighScore(name, highScore);
            }

            MessageBox.Show("Ai pierdut!");
        }
    }
}
