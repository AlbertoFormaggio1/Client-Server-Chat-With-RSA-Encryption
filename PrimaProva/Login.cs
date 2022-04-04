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
    public partial class Login : Form
    {
        OleDbConnection conn;
        public Keys Key { get; set; }        
        public string User { get; set; }
        public Login(OleDbConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT numberN,publicKey,privateKey FROM UTENTI WHERE USERNAME=? AND PASSWORD=?";
                OleDbCommand comm = new OleDbCommand(query,conn);
                comm.Parameters.AddWithValue("@user", tbUser.Text);
                comm.Parameters.AddWithValue("@psw", tbPassword.Text);                
                OleDbDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    User = tbUser.Text;
                    while (dr.Read())
                    {
                        Keys k = new Keys(Convert.ToInt64(dr["numberN"]), Convert.ToInt64(dr["PublicKey"]), Convert.ToInt64(dr["PrivateKey"]));
                        Key = k;
                    }                    
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Username o password errati");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cBShow_CheckedChanged(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = !cBShow.Checked;            
        }
    }
}