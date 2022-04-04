using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Net;
using System.Net.Sockets;
using System.IO;
using ExtensionMethods;
using Newtonsoft.Json;
using System.Data.OleDb;

namespace PrimaProva
{
    public partial class Form1 : Form
    {
        private Keys myKeys;
        private Keys theirKeys;
        private TcpClient client;
        public StreamReader str;
        public StreamWriter stw;
        public string receivedText;
        public string text;        
        public ElementToSend elem;
        string user;
        OleDbConnection conn;

        public Form1()
        {
            InitializeComponent();

            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName()); //Ottiene indirizzo IPv4 e IPv6 dell'host corrente
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork) //Se l'indirizzo è quello IPv4 lo mostro nella textBox
                {
                    tbServerIP.Text = address.ToString();
                }
            }
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                TcpListener listener = new TcpListener(IPAddress.Any, Convert.ToInt32(tbServerPort.Text)); //Crea un listener che rimane in ascolto sull'indirizzo IP e la porta specificata
                listener.Start(); //inizia ad ascoltare
                client = listener.AcceptTcpClient(); //Accetta richiesta di collegamento in sospeso da parte di un client. Rimane in attesa fino alla connessione di un client
                                                     //Ottiene Stream dal client, sul quale potrà leggere e scrivere
                str = new StreamReader(client.GetStream());
                stw = new StreamWriter(client.GetStream());
                stw.AutoFlush = true; //Sw scarica dati automaticamente quando viene invocato metodo write dello streamWriter
                backgroundWorker2.WorkerSupportsCancellation = true;  //Quando è a true permette di chiamare il metodo CancelAsync per interrompere un'operazione in background 
                elem = new ElementToSend("Key", new string[] { myKeys.PublicKey.N.ToString(), myKeys.PublicKey.E.Number.ToString() });
                backgroundWorker2.RunWorkerAsync(); //Invio chiave pubblica       
                                                    //SendPublicKey();
                backgroundWorker1.RunWorkerAsync(); //avvia esecuzione operazione in background (di tipo asincrono, ovvero rimane in attesa che si attivi un trigger    
                DisableTools();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        /// <summary>
        /// Disattivo controlli che non possono essere usati quando avvio la connessione
        /// </summary>
        void DisableTools()
        {
            tbClientIP.Enabled = false;
            tbServerIP.Enabled = false;
            tbClientPort.Enabled = false;
            tbServerPort.Enabled = false;
            btnStart.Enabled = false;
            btnConnect.Enabled = false;
            btnSend.Enabled = true;
            generateNewKeysToolStripMenuItem.Enabled = true;
            if (conn.State == ConnectionState.Open)
            {
                accountToolStripMenuItem.Enabled = true;
            }
        }

        /// <summary>
        /// Si era pensato di fare in questo modo, ma ciò non ha senso: il file con la chiave viene scritto sullo stream e non appena l'altro client si collega, verrà letto con il backgroundWorker1
        /// </summary>
        void SendPublicKey()
        {
            while (!client.Connected)
            { }
            stw.WriteLine(text);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient();
                IPEndPoint localEP = new IPEndPoint(IPAddress.Parse(tbClientIP.Text), Convert.ToInt32(tbClientPort.Text)); //Crea un endpoint (porta + indirizzo IP) locale            
                client.Connect(localEP);
                if (client.Connected)
                {
                    lBChat.Items.Add("Connected to server \n");
                    str = new StreamReader(client.GetStream());
                    stw = new StreamWriter(client.GetStream());
                    stw.AutoFlush = true;
                    backgroundWorker2.WorkerSupportsCancellation = true;
                    elem = new ElementToSend("Key", new string[] { myKeys.PublicKey.N.ToString(), myKeys.PublicKey.E.Number.ToString() });              //Qua non si è fatto il metodo a parte perchè facendo RunWorkerAsync dentro al metodo, prima si attende il termine di esso per poi eseguire l'istruzione di backgroundWorker1 e si avrebbe avuto un accesso sincrono. NON asincrono.
                    backgroundWorker2.RunWorkerAsync(); //Invio chiave pubblica 
                    backgroundWorker1.RunWorkerAsync();
                    DisableTools();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                try
                {
                    string received = str.ReadLine(); //Leggo linea scritta all'interno dello stream dall'altro utente per poi scriverla nella mia textBox
                    ElementToSend elem = JsonConvert.DeserializeObject<ElementToSend>(received);

                    if (elem.Type == "Text") //Se il file che mi è arrivato contiene del testo (un messaggio)
                    {
                        char[] decryptedChars = new char[elem.Values.Length];
                        for (int i = 0; i < elem.Values.Length; i++)
                        {
                            BigInteger valdec= BigInteger.ModPow(BigInteger.Parse(elem.Values[i]), myKeys.PrivateKey.D, myKeys.PrivateKey.N);
                            decryptedChars[i] = (char)valdec; //Esegue operazione (testo^d Mod N)
                        }
                        receivedText = string.Join("", decryptedChars);

                        //Esegue il delegato passato (in questo caso il metodo viene creato e invocato direttamente) sulla finestra controllata dal backgroundWorker1
                        this.lBChat.Invoke(new MethodInvoker(delegate ()
                        {
                            lBChat.Items.Add("X: " + receivedText + "\n"); //aggiunge testo in chiaro alla listbox della chat
                        }));

                        this.lBCrypted.Invoke(new MethodInvoker(delegate ()
                        {
                            lBCrypted.Items.Clear();
                            lBCrypted.Items.Add("Crypted received message");
                            foreach (string val in elem.Values)
                            {
                                lBCrypted.Items.Add(val); //aggiunge testo cifrato (numeri) nella listbox dei messaggi criptati
                            }
                        }));
                        receivedText = "";
                    }
                    else if (elem.Type == "Key") //Se invece mi è arrivata una chiave
                    {
                        theirKeys = new Keys(Convert.ToInt64(elem.Values[0]), Convert.ToInt64(elem.Values[1])); //values[0]=n  values[1]=e
                        //if (Convert.ToInt32(elem.Values[0]) < 256)  //Non si dovrebbe mai essere questo errore perchè le chiavi sono controllate in fase di generazione
                        //    MessageBox.Show("Chiavi settate ma potrebbero esserci errori in fase di comunicazione");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (client.Connected)
            {                
                string textToSend = JsonConvert.SerializeObject(elem);
                stw.WriteLine(textToSend); //Scrivo i dati nello stream (verrà poi letto con lo streamReader dall'altro utente)
                if (elem.Type == "Text") //Se non è una chiave scrivo nella textbox
                {                    
                    this.lBChat.Invoke(new MethodInvoker(delegate ()
                    {
                        lBChat.Items.Add("Io: " + text + "\n");
                    }));

                    this.lBCrypted.Invoke(new MethodInvoker(delegate ()
                    {
                        lBCrypted.Items.Clear();
                        lBCrypted.Items.Add("Crypted sended message");
                        foreach (string val in elem.Values)
                        {                            
                            lBCrypted.Items.Add(val);
                        }
                    }));
                }
            }
            else
            {
                MessageBox.Show("Impossibile inviare");
            }
            backgroundWorker2.CancelAsync(); //Annulla un'operazione asincrona in background
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbMessage.Text)) //La textbox del messaggio non deve essere vuota
            {
                text = tbMessage.Text;
                char[] charsToSend;
                charsToSend = tbMessage.Text.ToCharArray();
                string[] cryptedNums = new string[charsToSend.Length];
                for (int i = 0; i < charsToSend.Length; i++)
                {
                    cryptedNums[i] = BigInteger.ModPow(charsToSend[i], theirKeys.PublicKey.E.Number, theirKeys.PublicKey.N).ToString();  //BigInteger non è serializzabile
                }
                elem = new ElementToSend("Text", cryptedNums);
                backgroundWorker2.RunWorkerAsync(); //Si mette in ascolto per eventuali eventi
            }
            else
            {
                MessageBox.Show("Inserire del testo da inviare");
            }
            tbMessage.Text = "";
        }        

        private void Form1_Load(object sender, EventArgs e)
        {
            myKeys = new Keys(); //Genero chiave privata e pubblica
            try
            {
                conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=./Utenti.accdb");
                conn.Open();
            }
            catch
            {                
                MessageBox.Show("It was not possible to connect to the database. The number of features is reduced.");
            }
        }     

        private void generateRandomKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myKeys = new Keys();
            elem = new ElementToSend("Key", new string[] { myKeys.PublicKey.N.ToString(), myKeys.PublicKey.E.Number.ToString() }); //Genero chiave casuale
            backgroundWorker2.RunWorkerAsync();
            UpdateCredentials();
        }

        private void insertKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            InsertKey ik = new InsertKey();
            ik.ShowDialog();
            if (ik.DialogResult == DialogResult.OK)
            {
                myKeys = new Keys(ik.P, ik.Q);
                elem = new ElementToSend("Key", new string[] { myKeys.PublicKey.N.ToString(), myKeys.PublicKey.E.Number.ToString() }); //Genero chiave con i valori creati all'interno dell'altro form
                backgroundWorker2.RunWorkerAsync();
                UpdateCredentials();
            }                        
        }

        void UpdateCredentials()
        {
            if (user != null)
            {
                try
                {
                    string query = "UPDATE UTENTI SET numberN=?, publicKey=?, privateKey=? WHERE Username=?";
                    OleDbCommand comm = new OleDbCommand(query, conn);
                    comm.Parameters.AddWithValue("@NumberN", myKeys.PublicKey.N);
                    comm.Parameters.AddWithValue("@PubK", myKeys.PublicKey.E.Number);
                    comm.Parameters.AddWithValue("@PrivK", myKeys.PrivateKey.D);
                    comm.Parameters.AddWithValue("@User", user);
                    comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void creaAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreaAccount ca = new CreaAccount(myKeys,conn);
            ca.ShowDialog();            
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login log = new Login(conn);
            log.ShowDialog();
            if (log.DialogResult == DialogResult.OK)
            {
                myKeys = log.Key; 
                user = log.User; //Prendo l'username per cambiare in seguito la password
                elem = new ElementToSend("Key", new string[] { myKeys.PublicKey.N.ToString(), myKeys.PublicKey.E.Number.ToString() });  //Invio la chiave dell'utente che ha effettuato il login
                backgroundWorker2.RunWorkerAsync();                
            }
        }
    }
}