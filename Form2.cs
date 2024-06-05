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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "individualnaya27_1DataSet.Ведомость_оптовых_цен". При необходимости она может быть перемещена или удалена.
            this.ведомость_оптовых_ценTableAdapter.Fill(this.individualnaya27_1DataSet.Ведомость_оптовых_цен);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "individualnaya27_1DataSet.Учет_продаж". При необходимости она может быть перемещена или удалена.
            this.учет_продажTableAdapter.Fill(this.individualnaya27_1DataSet.Учет_продаж);

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            учетПродажBindingSource.Filter = "";
            учет_продажTableAdapter.Update(individualnaya27_1DataSet.Учет_продаж);
            ведомость_оптовых_ценTableAdapter.Update(individualnaya27_1DataSet.Ведомость_оптовых_цен);
            учет_продажTableAdapter.Fill(individualnaya27_1DataSet.Учет_продаж);
            ведомость_оптовых_ценTableAdapter.Fill(individualnaya27_1DataSet.Ведомость_оптовых_цен);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string naim;
            if (toolStripComboBox1.SelectedIndex == -1) return;
            if (toolStripTextBox1.Text == "") return;
            int kod = 0;

            if (toolStripComboBox1.SelectedItem.ToString() == "Наименование")
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    naim = dataGridView1.Rows[i].Cells[1].FormattedValue.ToString();
                    if (naim.Contains(toolStripTextBox1.Text))
                    {
                        kod = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                        break;
                    }
                }
                учетПродажBindingSource.Filter = "[Код товара] = " + kod;
            }
            else if(toolStripComboBox1.SelectedItem.ToString() == "Стоимость") {
                if (toolStripTextBox1.Text[0] == '>' || toolStripTextBox1.Text[0] == '<')
                {
                    учетПродажBindingSource.Filter = "[Стоимость, руб] " + toolStripTextBox1.Text;
                    return;
                }
                учетПродажBindingSource.Filter = "[Стоимость, руб] " + "=" + toolStripTextBox1.Text;

            }
            else if (toolStripComboBox1.SelectedItem.ToString() == "Количество продаж")
            {
                if (toolStripTextBox1.Text[0] == '>' || toolStripTextBox1.Text[0] == '<')
                {
                    учетПродажBindingSource.Filter = "[Количество продаж] " + toolStripTextBox1.Text;
                    return;
                }
                учетПродажBindingSource.Filter = "[Количество продаж] " + "=" + toolStripTextBox1.Text;

            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
