using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DifiHelman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int G,N,x1,x2,y1,y2,k1,k2;
        private void btnStart_Click(object sender, EventArgs e)
        {
           
            Int32.TryParse(gTxt.Text,out G);
            Int32.TryParse(nTxt.Text,out N);

            Int32.TryParse(x1Txt.Text, out x1);
            Int32.TryParse(x2Txt.Text, out x2);

            y1 = (int)Math.Pow(G, x1) % N;
            y2 = (int)Math.Pow(G, x2) % N;
            y1Label.Text = "y1 = G^x1modN = " + y1.ToString();
            y2Label.Text = "y2 = G^x2modN = " + y2.ToString();

            k1 = (int)Math.Pow(y2, x1) % N;
            k2 = (int)Math.Pow(y1, x2) % N;
            k1Label.Text = "k1 = y2^x1modN = " + k1.ToString();
            k2Label.Text = "k2 = y1^x2modN = " + k2.ToString();
        }

    }
}
