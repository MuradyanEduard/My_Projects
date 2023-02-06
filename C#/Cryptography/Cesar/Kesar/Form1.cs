using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kesar
{
    public partial class Form1 : Form
    {
        String Shifr = "";
        readonly String StrDefult = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";//26;
                                                       
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnShifr_Click(object sender, EventArgs e)
        {
            if(ChBoxEncrypt.Checked ==false && ChBoxDecrypt.Checked==false)
            {
                MessageBox.Show("Check metod!");
                return;
            }

            if (TxtKey.Text.Length == 0)
            {
                MessageBox.Show("Insert the key!");
                return;
            }
            
            for (int i = 0; i < TxtKey.Text.Length; i++)
                if (TxtKey.Text[i] < '0' || TxtKey.Text[i] > '9')
                {
                    MessageBox.Show("Key is wrong!");
                    return;
                }

            int KeyValue = Int32.Parse(TxtKey.Text);
            if (KeyValue < 0 || KeyValue > 25)
            {
                MessageBox.Show("Key must be more then 0 and little then 25!");
                return;
            }

            labelAnswer.Text = "";
            Shifr = StrDefult.Substring(KeyValue, StrDefult.Length - KeyValue) + StrDefult.Substring(0, KeyValue);

            if (this.dataGridView1.Rows.Count > 2)
                dataGridView1.Rows.RemoveAt(1);

            this.dataGridView1.Rows.Add("A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z");

            for (int i = 0; i < 26; i++)
                dataGridView1.Rows[1].Cells[i].Value = Shifr.Substring(i, 1);

            if (ChBoxEncrypt.Checked == true)
            {
                for (int i = 0; i < TxtSentence.Text.Length; i++)
                {
                    if (TxtSentence.Text[i].Equals(' ') || TxtSentence.Text[i].Equals(',') || TxtSentence.Text[i].Equals(':')
                        || TxtSentence.Text[i].Equals('.') || (TxtSentence.Text[i] >= '0' && TxtSentence.Text[i] <= '9'))
                    {
                        labelAnswer.Text = labelAnswer.Text + TxtSentence.Text[i];
                        continue;
                    }
                    else
                        SearchLetter(TxtSentence.Text[i], StrDefult, Shifr);

                }
            }
            else
            {
                for (int i = 0; i < TxtSentence.Text.Length; i++)
                {
                    if (TxtSentence.Text[i].Equals(' ') || TxtSentence.Text[i].Equals(',') || TxtSentence.Text[i].Equals(':')
                        || TxtSentence.Text[i].Equals('.') || (TxtSentence.Text[i] >= '0' && TxtSentence.Text[i] <= '9'))
                    {
                        labelAnswer.Text = labelAnswer.Text + TxtSentence.Text[i];
                        continue;
                    }
                    else
                        SearchLetter(TxtSentence.Text[i],Shifr, StrDefult);

                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 26;
            this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 15);

            for (int i = 0; i < 26; i++)
            {
                DataGridViewColumn column = dataGridView1.Columns[i];
                column.Width =23;
            }

            this.dataGridView1.Rows.Add("A", "B", "C", "D", "E","F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z");
            
        }

        private void SearchLetter(char a,String StrCrypte,String StrAyb)
        {
            //if(Char.ToUpper(a)==true)
            for (int i = 0; i < StrCrypte.Length; i++)
                if (StrCrypte[i].Equals(Char.ToUpper(a)))
                {
                    if(a.Equals(Char.ToUpper(a)))
                        labelAnswer.Text = labelAnswer.Text + StrAyb[i];
                    else
                        labelAnswer.Text = labelAnswer.Text + char.ToLower(StrAyb[i]);
                } 
        }

        private void ChBoxDecipher_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBoxDecrypt.Checked == true)
                ChBoxEncrypt.Checked = false;

        }

        private void ChBoxEncrypt_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBoxEncrypt.Checked == true)
                ChBoxDecrypt.Checked = false;
        }

        /*  private void Tm1_Tick(object sender, EventArgs e)
          {
              for (int i = 0; i < TxtKey.Text.Length; i++)
                  if (TxtKey.Text[i] < '0' || TxtKey.Text[i] > '9')
                      labelShifr.Text = "Key is wrong!";

                  //if ((TxtKey.Text[i]<'A' && TxtKey.Text[i] > 'Z')|| (TxtKey.Text[i] < 'a' && TxtKey.Text[i] > 'z'))


          }*/
    }
}
