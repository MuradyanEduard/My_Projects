using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stegonagraph
{
    static public class HelpTools
    {
        static public String AutoAddByte(String bfStr, int count)
        {
            while (bfStr.Length < count)
                bfStr = "0" + bfStr;

            return bfStr;
        }
        static public String ExtensionToByte(String strExt)
        {
            strExt = strExt.ToLower();
            String extBinar = "";
            for (int i = 0; i < strExt.Length; i++)
            {
                for (int j = 97; j <= 122; j++)
                {
                    if ((char)j == (char)strExt[i])
                    {
                        extBinar += AutoAddByte(Convert.ToString(j - 96, 2), 5);
                        break;
                    }
                }

            }

            while (extBinar.Length < 40)
                extBinar += "0";

            return extBinar;
        }
        static public String ByteToExtension(String extBinar)
        {
            String strExt = "";

            while (extBinar.Length > 0)
            {
                int num = (Convert.ToInt32(extBinar.Substring(0, 5), 2) + 96);
                if (num >= 97 && num <= 122)
                    strExt += ((char)num).ToString();
                extBinar = extBinar.Substring(5);
            }
            return strExt;
        }
    }
}
