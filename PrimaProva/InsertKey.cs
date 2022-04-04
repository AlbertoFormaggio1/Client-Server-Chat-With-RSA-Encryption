using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExtensionMethods;

namespace PrimaProva
{
    public partial class InsertKey : Form
    {

        public PrimeNumber P { get; set; }
        public PrimeNumber Q { get; set; }

        public InsertKey()
        {
            InitializeComponent();
        }

        private void tbP_Validating(object sender, CancelEventArgs e)
        {
                        
        }

        void ValidateContent()
        {
            bool validData = true;
            string pValue = tbP.Text.Trim();
            string qValue = tbQ.Text.Trim();
            long numConvertito;
            if (pValue != qValue)
            {
                if (long.TryParse(pValue, out numConvertito))
                {
                    if (PrimeNumberHelper.isPrime(numConvertito))
                    {
                        tbP.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        tbP.BackColor = Color.Red;
                        validData = false;
                    }
                }
                else
                {
                    validData = false;
                    tbP.BackColor = Color.Red;
                }

                if (long.TryParse(qValue, out numConvertito))
                {
                    if (PrimeNumberHelper.isPrime(numConvertito))
                    {
                        tbQ.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        tbQ.BackColor = Color.Red;
                        validData = false;
                    }
                }
                else
                {
                    validData = false;
                    tbQ.BackColor = Color.Red;
                }
            }
            else
            {
                validData = false;
            }
            btnGenerate.Enabled = validData;
        }

        private void tbQ_Validating(object sender, CancelEventArgs e)
        {
            ValidateContent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();            
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {            
            try
            {
                long p = Convert.ToInt64(tbP.Text.Trim());
                long q = Convert.ToInt64(tbQ.Text.Trim());
                if (p * q >= 256)
                {
                    P = new PrimeNumber(p, false);
                    Q = new PrimeNumber(q, false);
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Il prodotto tra p e q deve essere almeno 256 per poter rappresentare tutti i caratteri ASCII");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbP_TextChanged(object sender, EventArgs e)
        {
            ValidateContent();
        }

        private void tbQ_TextChanged(object sender, EventArgs e)
        {
            ValidateContent();
        }
    }
}
