using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stegonagraph
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        ////1 hide 0 unhide
        private void PbHide_Click(object sender, EventArgs e)
        {
            OpenNewForm(true);
            return;
        }

        private void PbUnhide_Click(object sender, EventArgs e)
        {
            OpenNewForm(false);
        }

        private void OpenNewForm(Boolean bl)
        {
            Form ifrm = new KeyForm(bl);
            ifrm.Show();
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(System.IO.Directory.GetCurrentDirectory() + "//Resources//AboutApplication_EN.pdf");
            }
            catch(Exception err)
            {
                MessageBox.Show("The file is damaged!");
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            panelGenerate.Visible = true;
            Random rnd = new Random();

            List<int> prList = new List<int>();
            for (int i = 20; i < 100; i++)
            {
                if (IsPrime(i))
                    prList.Add(i);
            }

            long[,] publicKey = new long[16, 2];
            long[,] privateKey = new long[16, 2];
            for (int i = 0; i < 16; i++)
            {
                RSA rsa = new RSA();

                int num1 = 0, num2 = 0;
                do
                {
                    num1 = prList[rnd.Next(0, prList.Count)];
                    num2 = prList[rnd.Next(0, prList.Count)];
                }
                while (num1 == num2);

                rsa.GenerateValues(num1, num2);

                publicKey[i, 0] = rsa.e;
                publicKey[i, 1] = rsa.n;
                privateKey[i, 0] = rsa.d;
                privateKey[i, 1] = rsa.n;
            }

            char cr;
            string unicodeString;
            tbPublicKey.Text = "";
            tbPrivateKey.Text = "";
            for (int i = 0; i < 16; i++)
            {
                cr = Convert.ToChar(Convert.ToInt32(publicKey[i,0]));
                unicodeString = char.ConvertFromUtf32(cr).ToString();
                tbPublicKey.Text += unicodeString;
                cr = Convert.ToChar(Convert.ToInt32(publicKey[i, 1]));
                unicodeString = char.ConvertFromUtf32(cr).ToString();
                tbPublicKey.Text += unicodeString;

                cr = Convert.ToChar(Convert.ToInt32(privateKey[i, 0]));
                unicodeString = char.ConvertFromUtf32(cr).ToString();
                tbPrivateKey.Text += unicodeString;
                cr = Convert.ToChar(Convert.ToInt32(privateKey[i, 1]));
                unicodeString = char.ConvertFromUtf32(cr).ToString();
                tbPrivateKey.Text += unicodeString;
            }
        }

        private String AddByte(String str) {
            while (str.Length < 8)
                str = "0" + str;
            return str;
        }

        private Boolean IsPrime(BigInteger num1)
        {
            for (int i = 2; i <= Math.Sqrt((Double)num1); i++)
            {
                if (num1 % i == 0)
                    return false;
            }
            return true;
        }

    }
}
