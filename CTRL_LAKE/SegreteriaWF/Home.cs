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
using System.Reflection;

namespace SegreteriaWF
{
    public partial class HomeSegreteria : Form
    {

        /*
         *  CHE E' STA ROBA?
         *  todo
         */

        private ServicesClient service = new ServicesClient();
        private BindingSource tableBindingS = new BindingSource();
        private DataTable dataTable;
        private DataSet dataSet = new DataSet();

        Noleggio[] prenotazioni;
        Lezione[] lezioni;

        public HomeSegreteria(string username)
        {
            InitializeComponent();
            welcomeLabel.Text = username;
            DataLoad();

        }

        //CONFIGURAZIONE E CARICAMENTO DATI

        private void DataLoad()
        {
            prenotazioni = service.GetPrenotazioni("Segreteria");
            lezioni = service.GetListLezioni("Segreteria");

            dataTable = CreateDataTable(prenotazioni, lezioni);
            tableBindingS.DataSource = dataTable.DefaultView;
            AutocompleteTexBox();
        }

        private void AutocompleteTexBox()
        {
            ClienteFilterBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            ClienteFilterBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            foreach (Noleggio n in prenotazioni)
                coll.Add(n.Cliente.Nome + " " + n.Cliente.Cognome);

            ClienteFilterBox.AutoCompleteCustomSource = coll;
        }

        //CREA UNA DATATABLE DA DUE LISTE, CREANDO COLONNE E RIGHE FORMATTATE SECONDO QUANTO RICHIESTO DALLA BUSINESS LOGIC
        public static DataTable CreateDataTable<T, T1>(IEnumerable<T> list, IEnumerable<T1> list1)
        {
            /*
             * AGGIUNTA COLONNE
             */

            //AGGIUNTA COLONNE TIPO 1
            Type type = typeof(T);
            var properties = type.GetProperties();

            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
            {
                var t = Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType;
                if (t == typeof(Cliente))
                {
                    dataTable.Columns.Add(new DataColumn(info.Name, typeof(string))); //imposto un tipo custom (stringa) come valore accettato per la colonna
                }
                else if (t == typeof(DettaglioNoleggio[]))
                    dataTable.Columns.Add(new DataColumn(info.Name, typeof(string))); //imposto un tipo custom (stringa) come valore accettato per la colonna
                else if (t != typeof(System.Runtime.Serialization.ExtensionDataObject))
                    dataTable.Columns.Add(new DataColumn(info.Name, t));
            }

            //AGGIUNTA COLONNE TIPO 2 
            type = typeof(T1);
            properties = type.GetProperties();
            foreach (PropertyInfo info in properties)
            {
                var t = Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType;

                bool found = false;
                foreach (DataColumn c in dataTable.Columns)
                    if (c.ColumnName == info.Name /*&& c.DataType == t*/)
                        found = true;

                if (!found)
                {
                    if (t == typeof(Cliente))
                    {
                        dataTable.Columns.Add(new DataColumn(info.Name, typeof(string)));
                    }
                    else if (t == typeof(Istruttore))
                        dataTable.Columns.Add(new DataColumn(info.Name, typeof(string)));
                    else if (t == typeof(System.Runtime.Serialization.ExtensionDataObject))
                        continue;
                    else
                        dataTable.Columns.Add(new DataColumn(info.Name, t));
                }
            }

            /*
             * AGGIUNTA RIGHE
             */

            //AGGIUNTA RIGHE TIPO 1
            type = typeof(T);
            properties = type.GetProperties();

            //sono presenti due metodi per aggiungere righe, vedere riga 110 e 122
            foreach (T entity in list)
            {
                DataRow row = dataTable.NewRow();
                foreach (PropertyInfo info in properties)
                {
                    var t = Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType;
                    if (t == typeof(Cliente))
                    {
                        string s = (entity as Noleggio).Cliente.Nome + " " + (entity as Noleggio).Cliente.Cognome;
                        row[dataTable.Columns[info.Name].Ordinal] = s;

                    }
                    else if (t == typeof(DettaglioNoleggio[]))
                    {
                        StringBuilder strinbuilder = new StringBuilder();
                        foreach (DettaglioNoleggio value in (entity as Noleggio).ElencoDettagli)
                        {
                            strinbuilder.Append(value.Attrezzatura.Tipo);
                            strinbuilder.Append(',');
                        }

                        row[dataTable.Columns[info.Name].Ordinal] = strinbuilder.ToString();
                    }
                    else if (t != typeof(System.Runtime.Serialization.ExtensionDataObject))
                        row[dataTable.Columns[info.Name].Ordinal] = info.GetValue(entity);
                }
                dataTable.Rows.Add(row);
                row.AcceptChanges();
            }

            //AGGIUNTA RIGHE TIPO 2
            type = typeof(T1);
            properties = type.GetProperties();
            foreach (T1 entity in list1)
            {
                DataRow row = dataTable.Rows.Add();
                foreach (PropertyInfo info in properties)
                {
                    var t = Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType;
                    if (t == typeof(Cliente))
                        row[dataTable.Columns[info.Name].Ordinal] = (entity as Lezione).Cliente.Nome + " " + (entity as Lezione).Cliente.Cognome;
                    else if (t == typeof(Istruttore))
                        row[dataTable.Columns[info.Name].Ordinal] = (entity as Lezione).Istruttore.Nome;
                    else if (t != typeof(System.Runtime.Serialization.ExtensionDataObject))
                        row[dataTable.Columns[info.Name].Ordinal] = info.GetValue(entity);
                }
                row.AcceptChanges();
                //MAN: serve per conoscere quali sono le righe che sono state modificate, senza non è possibile fare la revert changes. 
            }

            return dataTable;
        }

        //GRAFICA E CONTROLLI
        private void Form1_Load(object sender, EventArgs e)
        {
            tabellaPrenotazioni.DataSource = tableBindingS;
            //textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", tableBindingS, "Cliente", true)); 
            //MAN: sincronizza la textbox con la tabella
        }
        private void label1_Click(object sender, EventArgs e) { }
        private void tabellaPrenotazioni_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void deleteButton_Click(object sender, EventArgs e) { }
        private void FilterTableApply_Click(object sender, EventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void dateTimeFilter_ValueChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void ClienteFilterBox_TextChanged(object sender, EventArgs e)
        {
            dataTable.DefaultView.RowFilter = string.Format("Cliente LIKE '%{0}%'", ClienteFilterBox.Text);
        }
        private void LogoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("Logout Effettuato.");
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }

        private void tabellaPrenotazioni_SelectionChanged(object sender, EventArgs e)
        {
            //var c = tableBindingS.Current;

        }

        private void editPrenotazione_Click(object sender, EventArgs e)
        {
            ModificaPrenotazione modificaPrenotazione = new ModificaPrenotazione((DataRowView)tableBindingS.Current);
            modificaPrenotazione.Show();

            //tableBindingS.Position = 0; 
            //MAN: (unado viene premuto il tasto) sposta la riga selezionata in cima alla tabella.

            //((DataRowView)tableBindingS.Current)["Cliente"] = "MMM";
            //MAN: (quando viene premuto il tasto) sostituisce il campo nella colonna cliente della riga selzionata con una stringa "MMM";

            //((DataRowView)tableBindingS.Current).Row.RejectChanges();
            //MAN: annulla le modifiche alla tabella
        }
    }
}
