using System.Windows.Forms;
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly DocReader _reader;
        private CardNameIdentifier _cardNameDic;
        private Document _content;
        BindingSource GridViewbindingSource = new BindingSource();
        BindingSource dataGridView1bindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            InitGridView();
            InitdataGridView1();
            _cardNameDic = new CardNameIdentifier();
            _reader = new DocReader(new Config());
            _reader.CreateDocDirectory();
        }

        private void InitGridView()
        {
            gridView.AutoGenerateColumns = false;

            gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "BonNr",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Date",
                HeaderText = "Datum",
                DefaultCellStyle = { Format = "dd.MM.yy" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Value",
                HeaderText = "Wert",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });


            // Bind DataGridView to BindingSource
            gridView.DataSource = GridViewbindingSource;
        }

        private void InitdataGridView1()
        {
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CardId",
                HeaderText = "CardId",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Bind DataGridView to BindingSource
            dataGridView1.DataSource = dataGridView1bindingSource;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            string file = (string)comboBox.SelectedItem;

            if (string.IsNullOrEmpty(file))
                return;

            var doc = _reader.FindDocument(file);
            _content = _reader.ReadDocContent(doc);

            if (_content.Members != null)
            {
                var cardName = _cardNameDic.Identify(_content);

                dataGridView1bindingSource.DataSource = cardName.Members;
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            var items = _reader.ReadDocDirectory();

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(items.Select(p => p.Title).ToArray());
        }

        private void dataGridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
                return;

            var row = dataGridView1.SelectedRows[0].DataBoundItem as Member;
            if (row != null)
            {
                var value = row.Positions.Sum(p => p.Value);

                GridViewbindingSource.DataSource = row.Positions;

                textBox1.Clear();
                textBox1.Text = value.ToString();

                textBox2.Text = (value * 0.1).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var source = dataGridView1bindingSource.DataSource as IEnumerable<Member>;
            _cardNameDic.Set(source);

            MessageBox.Show("Zuordnung erfolgreich gespeichert", "Card Identifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.SelectedRows[0].DataBoundItem as Member;
            if (row != null)
            {
                _reader.WritePdf(row);
            }

            MessageBox.Show($"PDF für {row.Name}/{row.CardId} erfolgreich erstellt", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}