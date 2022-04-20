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

namespace ProNatur_Biomarkt_GmbH
{
    public partial class InvoiceScreen : Form
    {
        private SqlConnection databaseConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Anwender\Documents\ProNatur Biomarkt GmbH.mdf;Integrated Security = True; Connect Timeout = 30");

        private int lastSelectedInvoiceKey;

        public InvoiceScreen()
        {
            InitializeComponent();
            ShowInvoice();
        }

        private void btnInvoiceSave_Click(object sender, EventArgs e)
        {
            if (textBoxInvoiceName.Text == ""
                || textBoxInvoiceProduct.Text == ""
                || textBoxInvoicePrice.Text == ""
                || comboBoxInvoiceCategory.Text == "")
            {
                MessageBox.Show("Bitte alle Felder füllen!");
                return;
            }

            // save product name in database
            string invoiceName = textBoxInvoiceName.Text;
            string invoiceProduct = textBoxInvoiceProduct.Text;
            string invoiceCategory = comboBoxInvoiceCategory.Text;
            string invoicePrice = textBoxInvoicePrice.Text;
            
            string query = string.Format("insert into Invoice values('{0}', '{1}', '{2}', '{3}')", invoiceName, invoiceProduct, invoiceCategory, invoicePrice);
            ExecuteQuery(query);

            ClearFelder();
            ShowInvoice();
        }

        private void btnInvoiceEdit_Click(object sender, EventArgs e)
        {
            if (lastSelectedInvoiceKey == 0)
            {
                MessageBox.Show("Bitte wähle erst ein Produkt aus.");
                return;
            }

            string invoiceName = textBoxInvoiceName.Text;
            string invoiceProduct = textBoxInvoiceProduct.Text;
            string invoiceCategory = comboBoxInvoiceCategory.Text;
            string invoicePrice = textBoxInvoicePrice.Text;

            string query = string.Format("update Invoice set Empfänger='{0}', Produkt='{1}', Kategorie='{2}', Gesamtpreis='{3}' where Id={4}"
                , invoiceName, invoiceProduct, invoiceCategory, invoicePrice, lastSelectedInvoiceKey);

            ExecuteQuery(query);
            ShowInvoice();
        }

        private void btnInvoiceClear_Click(object sender, EventArgs e)
        {
            ClearFelder();
        }

        private void btnInvoiceDelete_Click(object sender, EventArgs e)
        {
            if (lastSelectedInvoiceKey == 0)
            {
                MessageBox.Show("Bitte wähle erst ein Produkt aus.");
                return;
            }

            string query = string.Format("delete from Invoice where Id={0}", lastSelectedInvoiceKey);
            ExecuteQuery(query);

            ClearFelder();
            ShowInvoice();
        }

        // Zeige Rechnungen bei Start
        private void ShowInvoice()
        {
            // Start
            databaseConnection.Open();

            string query = "Select * from dbo.Invoice";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, databaseConnection);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            invoiceDGV.DataSource = dataSet.Tables[0];

            invoiceDGV.Columns[0].Visible = false;

            databaseConnection.Close();
        }

        //Datenbank connecten und mit query übergeben
        private void ExecuteQuery(string query)
        {
            databaseConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, databaseConnection);
            sqlCommand.ExecuteNonQuery();
            databaseConnection.Close();
        }

        // Lösche Inhalt
        public void ClearFelder()
        {
            textBoxInvoiceName.Text = "";
            textBoxInvoiceProduct.Text = "";
            comboBoxInvoiceCategory.Text = "";
            textBoxInvoicePrice.Text = "";
            comboBoxInvoiceCategory.SelectedItem = null;
        }

        // Noch einzustellen bei Eigenschaften unter DataGridView -> MultiSelect = False / SelectionMode = FullRowSelect / ReadOnly = True
        private void invoiceDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxInvoiceName.Text = invoiceDGV.SelectedRows[0].Cells[1].Value.ToString();
            textBoxInvoiceProduct.Text = invoiceDGV.SelectedRows[0].Cells[2].Value.ToString();
            comboBoxInvoiceCategory.Text = invoiceDGV.SelectedRows[0].Cells[3].Value.ToString();
            textBoxInvoicePrice.Text = invoiceDGV.SelectedRows[0].Cells[4].Value.ToString();

            lastSelectedInvoiceKey = (int)invoiceDGV.SelectedRows[0].Cells[0].Value;
        }

        // Gesamtsumme berechnen
        private void GesamtsummeEinnahmen()
        {

        }
    }
}
