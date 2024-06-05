using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yakovleva_individual
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "individualnaya27_1DataSet.Ведомость_оптовых_цен". При необходимости она может быть перемещена или удалена.
            this.ведомость_оптовых_ценTableAdapter.Fill(this.individualnaya27_1DataSet.Ведомость_оптовых_цен);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedIndex == -1) return;
            if (toolStripTextBox1.Text == "") return;

            if (toolStripComboBox1.SelectedItem.Equals("Наименование"))
            {
                ведомостьОптовыхЦенBindingSource.Filter = "[Наименование]" + " LIKE '" + toolStripTextBox1.Text+ "'";
            }
            else if (toolStripComboBox1.SelectedItem.Equals("Цена поставки") 
                && (toolStripTextBox1.Text[0] == '<' || toolStripTextBox1.Text[0] == '>'))
            {
                ведомостьОптовыхЦенBindingSource.Filter = "[Цена поставки] " + toolStripTextBox1.Text;
                toolStripComboBox1.SelectedIndex = -1;
                toolStripTextBox1.Text = "";
                return;
            }
            else if (toolStripComboBox1.SelectedItem.Equals("Цена поставки"))
            {
                ведомостьОптовыхЦенBindingSource.Filter = "[Цена поставки] " + "="+ Convert.ToInt32(toolStripTextBox1.Text);
                toolStripComboBox1.SelectedIndex = -1;
                toolStripTextBox1.Text = "";
                return;
            }
            toolStripComboBox1.SelectedIndex = -1;
            toolStripTextBox1.Text = "";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ведомостьОптовыхЦенBindingSource.Filter = "";
            ведомость_оптовых_ценTableAdapter.Update(individualnaya27_1DataSet.Ведомость_оптовых_цен);
            ведомость_оптовых_ценTableAdapter.Fill(individualnaya27_1DataSet.Ведомость_оптовых_цен);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
