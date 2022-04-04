using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace PrimaProva
{
    public partial class CreaAccount : Form
    {
        OleDbConnection conn;
        Keys k;
        public CreaAccount(Keys k,OleDbConnection conn)
        {
            this.conn = conn;
            this.k = k;
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string psw = tbPassword.Text;
            if (psw.Any(char.IsUpper) && psw.Any(char.IsLower) && psw.Any(char.IsDigit))
            {
                try
                {
                    string query = "INSERT INTO UTENTI VALUES (?,?,?,?,?)";
                    OleDbCommand comm = new OleDbCommand(query, conn);
                    comm.Parameters.AddWithValue("@user", tbUser.Text);
                    comm.Parameters.AddWithValue("@psw", tbPassword.Text);
                    comm.Parameters.AddWithValue("@n", k.PublicKey.N);
                    comm.Parameters.AddWithValue("@pubk", k.PublicKey.E.Number);
                    comm.Parameters.AddWithValue("@prvk", k.PrivateKey.D);
                    comm.ExecuteNonQuery();                    
                    this.DialogResult = DialogResult.OK;                    
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("La password deve contenere almeno una lettera maiuscola, una lettera minuscola e un numero");
            }
        }

        private void CreaAccount_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cBShow_CheckedChanged(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = !cBShow.Checked;
        }
    }
}
