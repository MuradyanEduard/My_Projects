using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stegonagraph
{
    public partial class KeyForm : Form
    {
        Boolean tpSteg;
        public KeyForm(Boolean tpSteg)
        {
            InitializeComponent();

            if (tpSteg)
                panel1.Visible = true;
            else
            {
                panel2.Visible = true;
                panel2.Location = new Point(12, 12);
            }
            //tbPrivate.Text = "㊡꒽ⵧ豱΁ϓԛᆽࢹ℟䟋扯m໳ฃᾍͭЁⅹ㯏᠟ῷ啧灕ܳࠗ虻ꎽ্岕姧皑";
            //tbCryptedUnhide.Text = "牸㡕Ơ̘ᓓ偈ࠅࢋȿ╝ᗹ๝ҡ琌侘⎒";

            this.tpSteg = tpSteg;
            Random rnd = new Random();

            for (int i = 1; i < 65; i++)
            {
                lsbDataGridView.Rows.Add();
                lsbDataGridView.Rows[i - 1].Cells[0].Value = i;
                lsbDataGridView.Rows[i - 1].Cells[1].Value = rnd.Next(0, 4);
            }

            lsbDataGridView.ClearSelection();
            lsbDataGridView.CurrentCell = null;

            lsbDataGridView.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            lsbDataGridView.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        Byte checkedID = 0;
        Boolean refreshVal = false;
        private void lsbDataGridView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (lsbDataGridView.SelectedRows.Count == 0)
                return;

            if (e.StateChanged != DataGridViewElementStates.Selected)
                return;

            if (e.Row.Index < 0)
                return;

            refreshVal = true;
            checkedID = Convert.ToByte(lsbDataGridView.Rows[e.Row.Index].Cells[1].Value);

            switch (checkedID)
            {
                case 0:
                    radioButton1.Checked = true;
                    break;
                case 1:
                    radioButton2.Checked = true;
                    break;
                case 2:
                    radioButton3.Checked = true;
                    break;
                case 3:
                    radioButton4.Checked = true;
                    break;
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            byte rbId = 0;

            if (radioButton1.Checked)
                rbId = 1;
            else if (radioButton2.Checked)
                rbId = 2;
            else if (radioButton3.Checked)
                rbId = 3;
            else if (radioButton4.Checked)
                rbId = 4;

            if (rbId == checkedID)
                return;

            if (lsbDataGridView.SelectedRows.Count == 0)
                return;

            if (refreshVal)
            {
                refreshVal = false;
                return;
            }

            lsbDataGridView.SelectedRows[0].Cells[1].Value = rbId - 1;
            checkedID = rbId;
        }

        private void btnEndKey_Click(object sender, EventArgs e)
        {
            if (tbPublic.Text.Length != 32)
            {
                MessageBox.Show("Public Key is Wrong!");
                return;
            }
            String strBinar = "";

            for (int i = 0; i < 64; i++)
            {
                String str = Convert.ToString(Convert.ToByte(lsbDataGridView.Rows[i].Cells[1].Value), 2);
                if (str.Length == 1)
                    str = "0" + str;

                strBinar += str;
            }

            long[,] publicKey = new long[16, 2];
            tbCryptedHide.Text = "";

            for (int i = 0; i < 16; i++)
            {
                publicKey[i, 0] = (long)tbPublic.Text[i * 2];
                publicKey[i, 1] = (long)tbPublic.Text[i * 2 + 1];

                RSA rsa = new RSA();
                rsa.e = publicKey[i, 0];
                rsa.n = publicKey[i, 1];

                long nm = rsa.Encrypt(Convert.ToByte(strBinar.Substring(0, 8), 2));
                char cr = Convert.ToChar(nm);
                string unicodeString = char.ConvertFromUtf32(cr).ToString();
                tbCryptedHide.Text += unicodeString;

                strBinar = strBinar.Substring(8);
            }


        }

        Boolean formCond = true;
        private void btnStart_Click(object sender, EventArgs e)
        {
            formCond = false;
            byte[] keysArray = new byte[64];

            if (tpSteg)
            {
                for (int i = 0; i < 64; i++)
                {
                    keysArray[i] = Convert.ToByte(lsbDataGridView.Rows[i].Cells[1].Value);
                    keysArray[i]++;
                }
            }
            else
            {
                for (int i = 0; i < 64; i++)
                {
                    keysArray[i] = Convert.ToByte(getKeyDataGridView.Rows[i].Cells[1].Value);
                    keysArray[i]++;
                }
            }

            Form ifrm = new StegPanel(tpSteg, keysArray);
            ifrm.Show();
            this.Close();
        }

        private void btnGetKey_Click(object sender, EventArgs e)
        {
            if (tbPrivate.Text.Length != 32)
            {
                MessageBox.Show("Private Key is Wrong!");
                return;
            }

            if (tbCryptedUnhide.Text.Length != 16)
            {
                MessageBox.Show("Crypted Key is Wrong!");
                return;
            }

            getKeyDataGridView.Rows.Clear();

            long[,] privateKey = new long[16, 2];
            string unicodeString = "";

            for (int i = 0; i < 16; i++)
            {
                privateKey[i, 0] = (long)tbPrivate.Text[i * 2];
                privateKey[i, 1] = (long)tbPrivate.Text[i * 2 + 1];

                RSA rsa = new RSA();
                rsa.d = privateKey[i, 0];
                rsa.n = privateKey[i, 1];

                long nm = rsa.Decrypt((long)tbCryptedUnhide.Text[i]);

                String str = "";
                str = Convert.ToString(nm, 2);
                while (str.Length < 8)
                    str = "0" + str;

                unicodeString += str;
            }

            for (int i = 0; i < 64; i++)
            {
                getKeyDataGridView.Rows.Add();
                getKeyDataGridView.Rows[i].Cells[0].Value = i;
                getKeyDataGridView.Rows[i].Cells[1].Value = Convert.ToByte(unicodeString.Substring(0, 2), 2);
                unicodeString = unicodeString.Substring(2);
            }

        }

        private void KeyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!formCond)
                return;

            foreach (Form form in Application.OpenForms)
            {
                form.Activate();
                form.Show();
                return;
            }
        }
    }
}
