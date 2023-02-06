using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vigenere
{
    public partial class Form1 : Form
    {
        String StrDefult = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 27;
            this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 10);

            for (int i = 0; i < 27; i++)
            {
                DataGridViewColumn column = dataGridView1.Columns[i];
                column.Width = 20;
                dataGridView1.RowTemplate.Height = 20;
            }

            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value = "";
            for (int i = 0; i < StrDefult.Length; i++)
                dataGridView1.Rows[0].Cells[i+1].Value = StrDefult.Substring(i, 1);

            char chr = 'A';
            for (int i = 1; i < 27; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = chr;
                for (int j = 0; j < StrDefult.Length; j++)
                    dataGridView1.Rows[i].Cells[j+1].Value = StrDefult.Substring(j, 1);

                chr = (Char)(chr + 1);
                String str = StrDefult.Substring(0, 1);
                StrDefult = StrDefult.Substring(1) + str;

            }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            String ShifrKey = "";
            int keyHamar = 0;

            for (int i = 0; i < TxtKey.Text.Length; i++)
                if (Char.ToUpper(TxtKey.Text[i]) < 'A' || Char.ToUpper(TxtKey.Text[i]) > 'Z')
                {
                    MessageBox.Show("Key is wrong!");
                    return;
                }

            for (int i = 0; i < textBox.Text.Length; i++)
                if ((Char.ToUpper(textBox.Text[i]) < 'A' || Char.ToUpper(textBox.Text[i]) > 'Z') && !textBox.Text[i].Equals(' '))
                {
                    MessageBox.Show("Sentence is wrong!");
                    return;
                }

            labelAnswer.Text = "";

            for (int i = 0; i < textBox.Text.Length; i++)
            {
                if (keyHamar == TxtKey.Text.Length)
                    keyHamar = 0;

                if (textBox.Text[i].Equals(' '))
                {
                    ShifrKey = ShifrKey + " ";
                    continue;
                }

                ShifrKey = ShifrKey + TxtKey.Text[keyHamar];
                keyHamar++;
            }

            int posX = 0, posY = 0;

            if (ChBoxEncrypt.Checked == true)
            {
                for (int i = 0; i < textBox.Text.Length; i++)
                {
                    if (textBox.Text[i].Equals(' '))
                    {
                        labelAnswer.Text = labelAnswer.Text + ' ';
                        continue;
                    }

                    for (int j = 1; j < 27; j++)
                        if (dataGridView1.Rows[0].Cells[j].Value.ToString().Equals(Char.ToUpper(textBox.Text[i]).ToString()))
                        {
                            posX = j;
                            break;
                        }

                    for (int j = 1; j < 27; j++)
                        if (dataGridView1.Rows[j].Cells[0].Value.Equals(Char.ToUpper(ShifrKey[i])))
                        {
                            posY = j;
                            break;
                        }

                    labelAnswer.Text = labelAnswer.Text + dataGridView1.Rows[posX].Cells[posY].Value;
                }
            }
            else
            {
                for (int i = 0; i < textBox.Text.Length; i++)
                {
                    if (textBox.Text[i].Equals(' '))
                    {
                        labelAnswer.Text = labelAnswer.Text + ' ';
                        continue;
                    }

                    for (int j = 1; j < 27; j++)
                        if (dataGridView1.Rows[j].Cells[0].Value.Equals(Char.ToUpper(ShifrKey[i])))
                        {
                            posX = j;
                            break;
                        }

                    for (int j = 1; j < 27; j++)
                        if (dataGridView1.Rows[posX].Cells[j].Value.ToString().Equals(Char.ToUpper(textBox.Text[i]).ToString()))
                        {
                            posY = j;
                            break;
                        }



                    labelAnswer.Text = labelAnswer.Text + dataGridView1.Rows[0].Cells[posY].Value;
                }               

            }
        }

        private void ChBoxDecrypt_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBoxDecrypt.Checked == true)
                ChBoxEncrypt.Checked = false;

        }

        private void ChBoxEncrypt_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBoxEncrypt.Checked == true)
                ChBoxDecrypt.Checked = false;
        }

    }
}
