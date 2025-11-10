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
    public partial class InregistrareForm : Form
    {
        private string connStr = @"Server=localhost\SQLEXPRESS;Database=Joc1;Trusted_Connection=True;";
        public InregistrareForm()
        {
            InitializeComponent();
        }


        private void btnInregistrare_Click(object sender, EventArgs e)
        {
            string nume = txtNume.Text;
            if (nume == "")
            {
                MessageBox.Show("Campul Nume utilizator nu trebuie sa fie vid!");
                return;
            }

         
            string parola = txtParola.Text;
            string confirm = txtConfParola.Text;
            if (ExistaUtilizator(nume))
            {
                MessageBox.Show("Numele de utilizator este deja folost!");
                return;
            }

            if (parola == "" || confirm == "")
            {
                MessageBox.Show("Campul parola nu trebuie sa fie vida!");
                return;
            }

            if (parola != confirm)
            {
                MessageBox.Show("Parola nu coincide cu confirmarea parolei!");
                return;
            }

            InsertUtilizator(nume, parola);

            this.Visible = false;
            this.Close();
        }

        private void InsertUtilizator(string nume, string parola)
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spInsertUtilizator";
                    cmd.Parameters.AddWithValue("@nume", nume);
                    cmd.Parameters.AddWithValue("@parola", parola);
                    cmd.ExecuteNonQuery();
                }
                    
            }
                
        }
        private bool ExistaUtilizator(string nume)
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spExistaNume";

                    cmd.Parameters.AddWithValue("@nume", nume);

                    int x = (int)cmd.ExecuteScalar();
                    return x == 1;
                }
            }

        }
    }
}
