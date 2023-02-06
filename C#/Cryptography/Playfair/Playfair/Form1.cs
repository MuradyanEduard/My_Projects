using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Playfair
{
    public partial class Form1 : Form
    {
        String StrDefult = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
        String Pass = "",newPass ="";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 5;
            this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 20);

            for (int i = 0; i < 5; i++)
            {
                DataGridViewColumn column = dataGridView1.Columns[i];
                column.Width = 45;
                dataGridView1.RowTemplate.Height = 45;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StrDefult = "ABCDEFGHIKLMNOPQRSTUVWXYZ";

            if (ChBoxDecrypt.Checked == false && ChBoxEncrypt.Checked == false)
            {
                MessageBox.Show("Select metod!");
                return;
            }

            if (TxtKey.Text.Length > 25) 
            {
                MessageBox.Show("Key length must be little then 25!");
                return;
            }

            for (int i = 0; i < TxtKey.Text.Length; i++)
                if (Char.ToUpper(TxtKey.Text[i]) < 'A' || Char.ToUpper(TxtKey.Text[i]) > 'Z')
                {
                    MessageBox.Show("Key is wrong!");
                    return;
                }

            for (int i = 0; i < TxtSentence.Text.Length; i++)
                if ((Char.ToUpper(TxtSentence.Text[i]) < 'A' || Char.ToUpper(TxtSentence.Text[i]) > 'Z') && !TxtSentence.Text[i].Equals(' '))
                {
                    MessageBox.Show("Text Sentence is wrong!");
                    return;
                }

            Pass = "";
            newPass = "";
            for (int i = 0; i < TxtKey.Text.Length; i++)
            {
                if (Char.ToUpper(TxtKey.Text[i]).Equals('J'))
                    Pass = Pass + Char.ToUpper('I');
                else
                    Pass = Pass + Char.ToUpper(TxtKey.Text[i]);

                for (int j = 0; j < StrDefult.Length; j++)
                    if (Char.ToUpper(StrDefult[j]).Equals(Char.ToUpper(TxtKey.Text[i])))
                        StrDefult = StrDefult.Substring(0,j) + StrDefult.Substring(j + 1, StrDefult.Length - 1 - j);
            }

            Pass = Pass + StrDefult;
            
            for (int i = 0; i < Pass.Length; i++)
            {
                Boolean stugox = true;
                for (int j = 0; j < newPass.Length; j++)
                {
                    if (Pass[i].Equals(newPass[j]))
                        stugox = false;
                }

                if (stugox)
                    newPass = newPass + Pass[i];
            }


            String Answer = "", StrSentence = TxtSentence.Text;
            String str1 = "", str2 = "";
            labelAnswer.Text = "";

            for (int j = 0; j < StrSentence.Length; j++)
                if (StrSentence[j].Equals(' '))
                    StrSentence = StrSentence.Substring(0, j) + StrSentence.Substring(j + 1, StrSentence.Length - 1 - j);

            Pass = newPass;
            dataGridView1.Rows.Clear();

            for (int i = 0; i < 5; i++)
            {
                this.dataGridView1.Rows.Add("A", "B", "C", "D", "E");

                for (int j = 0; j < 5; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = Pass.Substring(0,1);
                    Pass = Pass.Substring(1);
                }
            }



            for (int i = 0; i < StrSentence.Length; i++)
            {

                if (StrSentence[i].Equals(' '))
                {
                    StrSentence = StrSentence.Substring(0, i) + StrSentence.Substring(i + 1, StrSentence.Length - 1 - i);
                    i--;
                }
            }


            if (StrSentence.Length % 2 != 0)
                StrSentence = StrSentence + "Z";
            

            if (ChBoxEncrypt.Checked == true)
            {                
                while (StrSentence.Length != 0)
                {

                    str1 = StrSentence.Substring(0, 1);
                    str2 = StrSentence.Substring(1, 1);

                    if (Char.ToUpper(str1[0]).Equals('J'))
                        str1 = "" + 'I';

                    if (Char.ToUpper(str2[0]).Equals('J'))
                        str1 = "" + 'I';


                    if (Char.ToUpper(str1[0]).Equals(Char.ToUpper(str2[0])) && !Char.ToUpper(str1[0]).Equals('Z'))
                    {
                        StrSentence = StrSentence + Char.ToUpper(str1[0]) + "Z" + Char.ToUpper(str2[0]) + "Z";
                        StrSentence = StrSentence.Substring(2);
                        continue;

                    }

                    int[] pos1XY = LetterSearch(str1[0]);
                    int[] pos2XY = LetterSearch(str2[0]);

                    if (pos1XY[0] == pos2XY[0])
                    {
                        if (pos1XY[1] == 4)
                            pos1XY[1] = 0;
                        else
                            pos1XY[1] = pos1XY[1] + 1;

                        if (pos2XY[1] == 4)
                            pos2XY[1] = 0;
                        else
                            pos2XY[1] = pos2XY[1] + 1;

                        Answer = Answer + dataGridView1.Rows[pos1XY[0]].Cells[pos1XY[1]].Value;
                        Answer = Answer + dataGridView1.Rows[pos2XY[0]].Cells[pos2XY[1]].Value + " ";
                        StrSentence = StrSentence.Substring(2);
                        continue;
                    }

                    if (pos1XY[1] == pos2XY[1])
                    {
                        if (pos1XY[0] == 4)
                            pos1XY[0] = 0;
                        else
                            pos1XY[0] = pos1XY[0] + 1;

                        if (pos2XY[0] == 4)
                            pos2XY[0] = 0;
                        else
                            pos2XY[0] = pos2XY[0] + 1;

                        Answer = Answer + dataGridView1.Rows[pos1XY[0]].Cells[pos1XY[1]].Value;
                        Answer = Answer + dataGridView1.Rows[pos2XY[0]].Cells[pos2XY[1]].Value + " ";
                        StrSentence = StrSentence.Substring(2);
                        continue;
                    }

                    Answer = Answer + dataGridView1.Rows[pos1XY[0]].Cells[pos2XY[1]].Value;
                    Answer = Answer + dataGridView1.Rows[pos2XY[0]].Cells[pos1XY[1]].Value + " ";
                    StrSentence = StrSentence.Substring(2);
                }
            }
            else
                while (StrSentence.Length != 0)
                {
                    str1 = StrSentence.Substring(0, 1);
                    str2 = StrSentence.Substring(1, 1);

                    int[] pos1XY = LetterSearch(str1[0]);
                    int[] pos2XY = LetterSearch(str2[0]);

                    if (pos1XY[0] == pos2XY[0])
                    {
                        if (pos1XY[1] == 0)
                            pos1XY[1] = 4;
                        else
                            pos1XY[1] = pos1XY[1] - 1;

                        if (pos2XY[1] == 0)
                            pos2XY[1] = 4;
                        else
                            pos2XY[1] = pos2XY[1] - 1;

                        Answer = Answer + dataGridView1.Rows[pos1XY[0]].Cells[pos1XY[1]].Value;
                        Answer = Answer + dataGridView1.Rows[pos2XY[0]].Cells[pos2XY[1]].Value + " ";
                        StrSentence = StrSentence.Substring(2);
                        continue;
                    }

                    if (pos1XY[1] == pos2XY[1])
                    {
                        if (pos1XY[0] == 0)
                            pos1XY[0] = 4;
                        else
                            pos1XY[0] = pos1XY[0] - 1;

                        if (pos2XY[0] == 0)
                            pos2XY[0] = 4;
                        else
                            pos2XY[0] = pos2XY[0] - 1;

                        Answer = Answer + dataGridView1.Rows[pos1XY[0]].Cells[pos1XY[1]].Value;
                        Answer = Answer + dataGridView1.Rows[pos2XY[0]].Cells[pos2XY[1]].Value + " ";
                        StrSentence = StrSentence.Substring(2);
                        continue;
                    }

                    Answer = Answer + dataGridView1.Rows[pos1XY[0]].Cells[pos2XY[1]].Value;
                    Answer = Answer + dataGridView1.Rows[pos2XY[0]].Cells[pos1XY[1]].Value + " ";
                    StrSentence = StrSentence.Substring(2);
                }

            for (int i = 0; i < Answer.Length; i++)
            {

                if (Answer[i].Equals(' '))
                {
                    Answer = Answer.Substring(0, i) + Answer.Substring(i + 1, Answer.Length - 1 - i);
                    i--;
                }
            }
            labelAnswer.Text = Answer;

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

        private int[] LetterSearch(Char a)
        {
            a = Char.ToUpper(a);
            String bas = "" + a;
 
            int[] ba = new int[2];
            for (int i = 0; i < 5; i++)          
                for (int j = 0; j < 5; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value.Equals(bas))
                    {
                        ba[0] = i;
                        ba[1] = j;
                        return ba;
                    }
                }
            return ba;
        }

    }
}
