using SegreteriaWF.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegreteriaWF
{
    public partial class ModificaPrenotazione : Form
    {
        private ServicesClient service = new ServicesClient();
        private DataRowView selectedPrenDRow;
        private bool deleteConfirmation;
        private object receivedPayload;

        public ModificaPrenotazione()
        {
            InitializeComponent();
        }

        public ModificaPrenotazione(DataRowView d)
        {
           InitializeComponent();
           selectedPrenDRow = d;
        }
        private void ModificaPrenotazione_Load(object sender, EventArgs e)
        {
            selectedPreLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", selectedPrenDRow, "Cliente", true));
            
            DataLoad();
        }
        private void DataLoad()
        {
            selectedPrenotationGrid.DataSource = selectedPrenDRow.DataView;
            DataTable selectedTable = new DataTable();
            selectedTable.Columns.Add(new DataColumn("ElencoDettagli"));
            selectedTable.Columns.Add(new DataColumn("Posti",typeof(int)));

            selectedTable.ImportRow(selectedPrenDRow.Row);
            selectedPrenotationGrid.DataSource = selectedTable.DefaultView;

            DataTable detailsTable = new DataTable();
            detailsTable.Columns.Add(new DataColumn("Istruttore"));
            detailsTable.Columns.Add(new DataColumn("Inizio", typeof(DateTime)));
            detailsTable.Columns.Add(new DataColumn("Fine", typeof(DateTime)));
            detailsTable.Columns.Add(new DataColumn("Partecipanti",typeof(int)));

            detailsTable.ImportRow(selectedPrenDRow.Row);
            selectedPrenotationDetailGrid.DataSource = detailsTable.DefaultView;

            DataTable availGear = new DataTable();
            availGear.Columns.Add(new DataColumn("Orario",typeof(DateTime)));
            availGear.Columns.Add(new DataColumn("Barche",typeof(Attrezzatura)));
            availGear.Columns.Add(new DataColumn("Windsurf",typeof(Attrezzatura)));
            availGear.Columns.Add(new DataColumn("Sup",typeof(Attrezzatura)));
            availGear.Columns.Add(new DataColumn("Canoe",typeof(Attrezzatura)));


            availableGearGrid.DataSource = availGear.DefaultView;

        }
        
        private void selectedPrenotationGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (checkBox1.Checked)
            {
                string res = service.CancellaPrenotazione(id);
                if (res == "success")
                {
                    MessageBox.Show("Prenotazione " + id + " cancellata correttamente");

                }
            }
            else MessageBox.Show("Flag di conferma non spuntato. Riprovare.");
            //((DataRowView)selectedPrenDRow.Current).Row.RejectChanges();
            this.Close();
        }

       

        private void selectedPreLabel_Click(object sender, EventArgs e)
        {

        }

        private void availableGearGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
