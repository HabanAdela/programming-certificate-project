using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Joc
{
    public partial class LogareForm : Form
    {
        private string connStr = @"Server=localhost\SQLEXPRESS;Database=Joc1;Trusted_Connection=True;";
        public LogareForm()
        {
            InitializeComponent();
        }

        private void btnLogare_Click(object sender, EventArgs e)
        {
            string nume = txtNumeLog.Text;
            string parola = txtParolaLog.Text;

            if (!ExistaUtilizator(nume, parola))
            {
                MessageBox.Show("Eroare autentificare!");
                txtNumeLog.Text = "";
                txtParolaLog.Text = "";
                return;
            }
            else
            {
                AlegeForm frm = new AlegeForm(nume);
                this.Visible = false;
                frm.ShowDialog();
                Application.Exit();
            }
        }

        private bool ExistaUtilizator(string nume, string parola)
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spExistaUtilizator";

                    cmd.Parameters.AddWithValue("@nume", nume);
                    cmd.Parameters.AddWithValue("@parola", parola);

                    int x = (int)cmd.ExecuteScalar();
                    return x == 1;
                }      
            }
                
        }

        private void btnInregistrare_Click(object sender, EventArgs e)
        {
            InregistrareForm frm = new InregistrareForm();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true;
        }
    }
}
