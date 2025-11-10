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

namespace Joc
{
    public partial class StatusForm : Form
    {
        private string connStr = @"Server=localhost\SQLEXPRESS;Database=Joc1;Trusted_Connection=True;";
        private JocForm parentForm;
        public StatusForm(int id, JocForm parentForm)
        {
            InitializeComponent();
            SelectStatus(id);
            this.parentForm = parentForm;
        }

        private string GetNume(int id)
        {
            string nume;
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetNume";
                    cmd.Parameters.AddWithValue("@id", id);
                    var rd = cmd.ExecuteReader();
                    rd.Read();
                    nume = (string)rd[0];

                    rd.Close();
                }
            }
            return nume;
        }

        private void SelectStatus(int id)
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spSelectStatus";
                    cmd.Parameters.AddWithValue("@id", id);

                    var rd = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rd);
                    dgwStatus.DataSource = dt;
                }
            }
        }

        private void btnRejoaca_Click(object sender, EventArgs e)
        {      
            this.Close();
            parentForm.ResetState();
        }

        private void btnIesi_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
