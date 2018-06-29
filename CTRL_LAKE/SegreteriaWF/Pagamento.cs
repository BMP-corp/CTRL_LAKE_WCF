using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SegreteriaWF.ServiceReference1;

namespace SegreteriaWF
{
    public partial class Pagamento : Form
    {
        private ServicesClient service ;
        private DataRowView selectedPrenDRow;
        private Cliente cliente;
        Lezione[] lezioni;
        private float prezzo = 100;
        private float sconto = 0;
        private float danni = 0;
        private float subtotale = 0;
        public Pagamento()
        {
            InitializeComponent();
        }

        public Pagamento(DataRowView d, Cliente user, ServicesClient serv)
        {
            InitializeComponent();
            selectedPrenDRow = d;
            service = serv;
            cliente = user;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Pagamento_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void DataLoad()
        {
            lezioni = service.GetListLezioni(cliente.Username);
            dettagliPagamentoGridView.DataSource = selectedPrenDRow.DataView;
            DataTable selectedTable = new DataTable();

            updatePrezzo();
        }

        private void updatePrezzo()
        {
            //prezzo = prezzo - sconto + danni;
            subtotale = prezzo - sconto + danni;
            //subtotale = prezzo;

            scontoLabel.Text = sconto.ToString();
            subtotLabel.Text = prezzo.ToString();
            label5.Text = danni.ToString();
            totLabel.Text = subtotale.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e) //aggiungisconto
        {
            string scontoS = scontoTexB.Text;
            sconto = float.Parse(scontoS);
            updatePrezzo();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            string danniS = danniTextB.Text;
            danni = float.Parse(danniS);
            updatePrezzo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pagamento effettuato!");
            this.Close();
        }
    }
}
