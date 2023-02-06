using System;
using System.Collections.Generic;
using System.Text;

namespace Stegonagraph
{
    class HuffTree
    {
        public String Code { set; get; }
        public String ValHex { set; get; }

        public HuffTree(String nom, String valHex)
        {
            Code = nom;
            ValHex = valHex;
        }

    }
}
