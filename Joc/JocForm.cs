using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Joc
{
    public partial class JocForm : Form
    {
        private string connStr = @"Server=localhost\SQLEXPRESS;Database=Joc1;Trusted_Connection=True;";
        private List<Cerc> cercuri = new List<Cerc>();
        private Timer timer = new Timer();
        private int r = 20;
        private int id;
        Random rand = new Random();
        private int nrGreenCircles;
        public JocForm(string nume)
        {
            id = GetIdNume(nume);

            InitializeComponent();
            InitializeState();
        }

        private void InitializeState()
        {
            timer.Interval = 20;
            timer.Enabled = true;
            timer.Tick += OnTimerTick;

            this.SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint,
                true
            );
            this.UpdateStyles();


            cercuri.Add(new Cerc(rand.Next(0, this.ClientSize.Width - 2 * r - 5), rand.Next(0, this.ClientSize.Height - 2 * r - 5), rand.Next(-8, 8),rand.Next(-8, 8), Color.Green));
            cercuri.Add(new Cerc(rand.Next(0, this.ClientSize.Width - 2 * r - 5), rand.Next(0, this.ClientSize.Height - 2 * r - 5), rand.Next(-8, 8), rand.Next(-8, 8), Color.Green));
            cercuri.Add(new Cerc(rand.Next(0, this.ClientSize.Width - 2 * r - 5), rand.Next(0, this.ClientSize.Height - 2 * r - 5), rand.Next(-8, 8), rand.Next(-8, 8), Color.Green)); ;
            cercuri.Add(new Cerc(rand.Next(0, this.ClientSize.Width - 2 * r - 5), rand.Next(0, this.ClientSize.Height - 2 * r - 5), rand.Next(-8, 8), rand.Next(-8, 8), Color.Green));
            cercuri.Add(new Cerc(rand.Next(0, this.ClientSize.Width - 2 * r - 5), rand.Next(0, this.ClientSize.Height - 2 * r - 5), rand.Next(-8, 8), rand.Next(-8, 8), Color.Green));
            cercuri.Add(new Cerc(rand.Next(0, this.ClientSize.Width - 2 * r - 5), rand.Next(0, this.ClientSize.Height - 2 * r - 5), rand.Next(-8, 8), rand.Next(-8, 8), Color.Red));
            cercuri.Add(new Cerc(rand.Next(0, this.ClientSize.Width - 2 * r - 5), rand.Next(0, this.ClientSize.Height - 2 * r - 5), rand.Next(-8, 8), rand.Next(-8, 8), Color.Red));
            cercuri.Add(new Cerc(rand.Next(0, this.ClientSize.Width - 2 * r - 5), rand.Next(0, this.ClientSize.Height - 2 * r - 5), rand.Next(-8, 8), rand.Next(-8, 8), Color.Red));

            nrGreenCircles = 5;

            bool gen = true;
            while(gen)
            {
                gen = false;
                for (int i  = 0; i < 8; ++i)
                    for (int j = i + 1; j < 8; ++j)
                    {
                        if (IsColliding(cercuri[i], cercuri[j]) || (cercuri[i].MoveSpeedX == 0 && cercuri[i].MoveSpeedY == 0))
                        {
                            gen = true;
                            cercuri[j].X = rand.Next(0, this.ClientSize.Width - 2 * r - 5);
                            cercuri[j].Y = rand.Next(0, this.ClientSize.Height - 2 * r - 5);    
                        }
                    }
            }
        } 

        private bool Hit(int x, int y, Cerc c)
        {
            return ((x - c.X - r) * (x - c.X - r) + (c.Y - y + r) * (c.Y - y + r)) <= r * r;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            for (int i = 0; i < cercuri.Count; ++i)
            {
                
                if (cercuri[i].X + cercuri[i].MoveSpeedX < 0 || cercuri[i].X + 2 * r + cercuri[i].MoveSpeedX > this.ClientSize.Width)
                    cercuri[i].MoveSpeedX = -cercuri[i].MoveSpeedX;
                else cercuri[i].X += cercuri[i].MoveSpeedX;

               
                if (cercuri[i].Y + cercuri[i].MoveSpeedY < 0 || cercuri[i].Y + 2 * r + cercuri[i].MoveSpeedY > this.ClientSize.Height)
                    cercuri[i].MoveSpeedY = -cercuri[i].MoveSpeedY;
                else
                    cercuri[i].Y += cercuri[i].MoveSpeedY;

                for (int j = i + 1; j < cercuri.Count; ++j)
                {
                    if (IsColliding(cercuri[i], cercuri[j]))
                    {
                        BounceCircles(cercuri[i], cercuri[j]);
                    }
                }
            }

            this.Refresh();
        }

        private void BounceCircles(Cerc cerc1, Cerc cerc2)
        {
            cerc1.MoveSpeedX = -cerc1.MoveSpeedX;
            cerc1.MoveSpeedY = -cerc1.MoveSpeedY;

            cerc2.MoveSpeedX = -cerc2.MoveSpeedX;
            cerc2.MoveSpeedY = -cerc2.MoveSpeedY;
        }

        private bool IsColliding(Cerc c1, Cerc c2)
        {
            float distance = (float)Math.Sqrt(Math.Pow(c2.X - c1.X, 2) + Math.Pow(c2.Y - c1.Y, 2));
            return distance <= 2 * r;
        }

        private void JocForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (var c in cercuri)
            {
                Brush brush = new SolidBrush(c.C);
                e.Graphics.FillEllipse(brush, c.X, c.Y, 2 * r, 2 * r);
                brush.Dispose();
            }
        }

        private int GetIdNume(string nume)
        {
            int id;
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetIdNume";
                    cmd.Parameters.AddWithValue("@nume", nume);
                    var rd = cmd.ExecuteReader();
                    rd.Read();
                    id = (int)rd[0];

                    rd.Close();
                }
            }
            return id;
        }
        private int GetNrWins(int id)
        {
            int wins;
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spNrCastiguri";
                    cmd.Parameters.AddWithValue("@id", id);
                    var rd = cmd.ExecuteReader();
                    rd.Read();
                    wins = (int)rd[0];

                    rd.Close();
                }
            }
            return wins;
        }

        private int GetNrLosses(int id)
        {
            int losses;
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spNrPierderi";
                    cmd.Parameters.AddWithValue("@id", id);
                    var rd = cmd.ExecuteReader();
                    rd.Read();
                    losses = (int)rd[0];

                    rd.Close();
                }
            }
            return losses;
        }

        private void JocForm_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (var c in cercuri)
            {
                if (c.C == Color.Green)
                {
                    if (Hit(e.X, e.Y, c))
                    {
                        ChangeColor(c);
                        --nrGreenCircles;
                        if (nrGreenCircles == 0)
                        {
                            timer.Stop();
                            int wins = GetNrWins(id) + 1;
                            UpdateWins(id, wins);
                            MessageBox.Show("Ai castigat!");

                            StatusForm frm = new StatusForm(id, this); 
                            frm.Show();
                              
                        }

                    }

                }
                else if (Hit(e.X, e.Y, c))
                {
                    timer.Stop();
                    int losses = GetNrLosses(id) + 1;
                    UpdateLosses(id, losses);
                    MessageBox.Show("Ai pierdut!");
                    StatusForm frm = new StatusForm(id, this);
                    frm.Show();
                    
                }
                
            }
            
        }

        private void ChangeColor(Cerc c)
        {
            c.C = Color.Red;
            Invalidate();
        }

        private void UpdateWins(int id, int wins)
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spUpdateCastiguri";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@wins", wins);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void UpdateLosses(int id, int losses)
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spUpdatePierderi";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@losses", losses);
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void ResetState()
        {
            cercuri = new List<Cerc>();
            timer = new Timer();
            InitializeState();
        }

        private void JocForm_Load(object sender, EventArgs e)
        {

        }
    }
}
