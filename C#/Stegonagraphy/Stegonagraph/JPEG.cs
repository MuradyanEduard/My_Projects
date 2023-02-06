using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace Stegonagraph
{
    class JPEG
    {
        public UInt64 info { set; get; }
        private int[] compCount = new int[3];
        private List<HuffTree[][]> DHT_DC = new List<HuffTree[][]>();
        private List<HuffTree[][]> DHT_AC = new List<HuffTree[][]>();
        private byte[] arrayJpeg;
        public JPEG(String path, Boolean tp)
        {
            if (tp)
                JpegCompressor(path);
            else
                arrayJpeg = File.ReadAllBytes(path);

            UInt64 picturePos = 0;

            while (true)
            {

                //0xFFC0 settings 
                if ((arrayJpeg[picturePos] == 255 && arrayJpeg[picturePos + 1] == 192)
                   || (arrayJpeg[picturePos] == 255 && arrayJpeg[picturePos + 1] == 193)
                   || (arrayJpeg[picturePos] == 255 && arrayJpeg[picturePos + 1] == 194))
                {
                    int[] compH = new int[3];
                    int[] compV = new int[3];
                    picturePos += 11;
                    compH[0] = Convert.ToInt32(AddByte(Convert.ToString(arrayJpeg[picturePos], 2)).Substring(0, 4), 2);
                    compV[0] = Convert.ToInt32(AddByte(Convert.ToString(arrayJpeg[picturePos], 2)).Substring(4, 4), 2);
                    picturePos++;
                    picturePos += 2;
                    compH[1] = Convert.ToInt32(AddByte(Convert.ToString(arrayJpeg[picturePos], 2)).Substring(0, 4), 2);
                    compV[1] = Convert.ToInt32(AddByte(Convert.ToString(arrayJpeg[picturePos], 2)).Substring(4, 4), 2);
                    picturePos++;
                    picturePos += 2;
                    compH[2] = Convert.ToInt32(AddByte(Convert.ToString(arrayJpeg[picturePos], 2)).Substring(0, 4), 2);
                    compV[2] = Convert.ToInt32(AddByte(Convert.ToString(arrayJpeg[picturePos], 2)).Substring(4, 4), 2);
                    picturePos++;

                    compCount[0] = (int)(compH[0] * compV[0]);
                    compCount[1] = (int)(compH[1] * compV[1]);
                    compCount[2] = (int)(compH[2] * compV[2]);
                }

                //dht
                if (arrayJpeg[picturePos] == 255 && arrayJpeg[picturePos + 1] == 196)
                {
                    picturePos += 4;
                    int kaefType = Convert.ToInt32(AddByte(Convert.ToString(arrayJpeg[picturePos], 2)).Substring(0, 4), 2);

                    HuffTree[][] shablon = new HuffTree[16][];
                    List<String> kaefCode = new List<String>();
                    kaefCode.Add("0");
                    kaefCode.Add("1");

                    for (int i = 0; i < 16; i++)
                    {
                        picturePos++;

                        shablon[i] = new HuffTree[arrayJpeg[picturePos]];
                        for (int j = 0; j < shablon[i].Length; j++)
                        {
                            shablon[i][j] = new HuffTree(kaefCode[0], "");
                            kaefCode.RemoveRange(0, 1);
                        }

                        int ln = kaefCode.Count;
                        for (int j = 0; j < ln; j++)
                        {
                            kaefCode.Add(kaefCode[j] + "0");
                            kaefCode.Add(kaefCode[j] + "1");
                        }
                        kaefCode.RemoveRange(0, ln);

                    }

                    for (int j = 0; j < 16; j++)
                        for (int i = 0; i < shablon[j].Length; i++)
                            shablon[j][i].ValHex = AddHexByte(arrayJpeg[++picturePos].ToString("X"));

                    if (kaefType == 0)
                        DHT_DC.Add(shablon);
                    else
                        DHT_AC.Add(shablon);

                }

                if (arrayJpeg[picturePos] == 255 && (arrayJpeg[picturePos + 1] == 217 || arrayJpeg[picturePos + 1] == 218))
                    break;

                picturePos++;
            }


        }

        public UInt64 GetInfo(int[] stegType) {
            UInt64 picturePos = 0;
            UInt32 stegPos = 0;

            while (true)
            {
                if (arrayJpeg[picturePos] == 255 && arrayJpeg[picturePos + 1] == 218)
                {
                    List<int> compDC = new List<int>();
                    List<int> compAC = new List<int>();

                    picturePos++;
                    ulong nom = picturePos;
                    int len = 0;
                    len = Convert.ToInt32(AddByte(Convert.ToString(arrayJpeg[++picturePos], 2)) + AddByte(Convert.ToString(arrayJpeg[++picturePos], 2)), 2);
                    int cmpCount = arrayJpeg[++picturePos];
                    picturePos++;

                    for (int i = 0; i < cmpCount; i++)
                    {
                        picturePos++;

                        compDC.Add(Convert.ToInt32(AddByte(Convert.ToString(arrayJpeg[picturePos], 2)).Substring(0, 4), 2));
                        compAC.Add(Convert.ToInt32(AddByte(Convert.ToString(arrayJpeg[picturePos], 2)).Substring(4, 4), 2));

                        picturePos++;
                    }

                    picturePos = nom + (ulong)len;
                    picturePos++;

                    String infoStr = "";
                    int index = 0;
                    int qanak = 0;
                    info = 0;

                    while (true)
                    {
                        if (qanak < compCount[index % compCount.Length])
                            qanak++;
                        else
                        { qanak = 1; index++; }


                        int count = 0;
                        String strHuf = "";
                        int indexStr = 0;
                        HuffTree[][] DC = DHT_DC[compDC[index % compCount.Length]];
                        HuffTree[][] AC = DHT_AC[compAC[index % compCount.Length]];

                        while (count < 64)
                        {
                            while (infoStr.Length < 32)
                            {
                                if (arrayJpeg[picturePos] == 255 && arrayJpeg[picturePos + 1] == 217)
                                    break;

                                if (arrayJpeg[picturePos] == 255 && arrayJpeg[picturePos + 1] == 0)
                                {
                                    infoStr += AddByte(Convert.ToString(arrayJpeg[picturePos], 2));
                                    picturePos++;
                                }
                                else
                                {
                                    infoStr += AddByte(Convert.ToString(arrayJpeg[picturePos], 2));
                                }

                                picturePos++;
                            }

                            strHuf += infoStr[indexStr++];

                            if (count == 0)
                            {
                                for (int j = 0; j < DC[strHuf.Length -1].Length; j++)
                                {
                                    if (DC[strHuf.Length -1][j].Code == strHuf)
                                    {
                                        infoStr = infoStr.Substring(strHuf.Length);

                                        if (DC[strHuf.Length-1][j].ValHex == "00")
                                        {
                                        }
                                        else
                                        {
                                            int chap = int.Parse(DC[strHuf.Length-1][j].ValHex.Substring(1, 1), System.Globalization.NumberStyles.HexNumber);

                                            for (int k = 0; k < int.Parse(DC[strHuf.Length-1][j].ValHex.Substring(0, 1), System.Globalization.NumberStyles.HexNumber); k++)
                                                count++;

                                            infoStr = infoStr.Substring(chap);
                                        }

                                        indexStr = 0;
                                        strHuf = "";
                                        count++;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                for (int j = 0; j < AC[strHuf.Length - 1].Length; j++)
                                {
                                    if (AC[strHuf.Length-1][j].Code == strHuf)
                                    {
                                        infoStr = infoStr.Substring(strHuf.Length);

                                        if (AC[strHuf.Length-1][j].ValHex == "00")
                                        {
                                            goto found;
                                        }
                                        else
                                        {
                                            int chap = int.Parse(AC[strHuf.Length-1][j].ValHex.Substring(1, 1), System.Globalization.NumberStyles.HexNumber);

                                            for (int k = 0; k < int.Parse(AC[strHuf.Length-1][j].ValHex.Substring(0, 1), System.Globalization.NumberStyles.HexNumber); k++)
                                                count++;


                                            if (chap > stegType[stegPos%stegType.Length])
                                                info += (ulong)stegType[stegPos % stegType.Length];
                                            else
                                                info += (ulong)chap;

                                            stegPos++;
                                            infoStr = infoStr.Substring(chap);
                                        }
                                        indexStr = 0;
                                        strHuf = "";
                                        count++;
                                        break;
                                    }
                                }
                            }


                        }

                    found:;

                        if ((arrayJpeg[picturePos] == 255 && arrayJpeg[picturePos + 1] == 254) || (arrayJpeg[picturePos] == 255 && arrayJpeg[picturePos + 1] == 217))
                        {
                            info = info / 8;
                            return info;
                        }
                    }

                }
                picturePos++;
            }

        }
        public void jpegEncode(byte[] arrHide,String savePath,int[] key)
        {
            //byte[] arrHide = File.ReadAllBytes(path);
            int hidePos = 0;
            String strHideInfo = "";

            List<byte> stegIMG = new List<byte>();
            String strStegImg = "";

            UInt32 stegPos = 0;
            //System.Windows.Forms.MessageBox.Show(arrHide.Length.ToString());

            //FF DA
            UInt64 picturePos = 0;

            while (true)
            {
                if (arrayJpeg[picturePos] == 255 && arrayJpeg[picturePos + 1] == 218)
                {
                    List<int> compDC = new List<int>();
                    List<int> compAC = new List<int>();

                    picturePos++;
                    ulong nom = picturePos;
                    int len = 0;
                    len = Convert.ToInt32(AddByte(Convert.ToString(arrayJpeg[++picturePos], 2)) + AddByte(Convert.ToString(arrayJpeg[++picturePos], 2)), 2);
                    int cmpCount = arrayJpeg[++picturePos];
                    picturePos++;

                    for (int i = 0; i < cmpCount; i++)
                    {
                        picturePos++;

                        compDC.Add(Convert.ToInt32(AddByte(Convert.ToString(arrayJpeg[picturePos], 2)).Substring(0, 4), 2));
                        compAC.Add(Convert.ToInt32(AddByte(Convert.ToString(arrayJpeg[picturePos], 2)).Substring(4, 4), 2));

                        picturePos++;
                    }

                    picturePos = nom + (ulong)len;
                    picturePos++;

                    for (UInt64 i = 0; i < picturePos; i++)
                        stegIMG.Add(arrayJpeg[i]);

                    String strInfo = "";

                    int index = 0;
                    int qanak = 0;
                    info = 0;

                    while (true)
                    {
                        if (qanak < compCount[index % compCount.Length])
                            qanak++;
                        else
                        { qanak = 1; index++; }


                        int count = 0;
                        String strHuf = "";
                        int indexStr = 0;
                        HuffTree[][] DC = DHT_DC[compDC[index % compCount.Length]];
                        HuffTree[][] AC = DHT_AC[compAC[index % compCount.Length]];

                        while (count < 64)
                        {
                            while (strStegImg.Length > 8)
                            {
                                stegIMG.Add(Convert.ToByte(strStegImg.Substring(0, 8), 2));

                                if (Convert.ToByte(strStegImg.Substring(0, 8), 2) == 255)
                                    stegIMG.Add(0);

                                strStegImg = strStegImg.Substring(8);

                            }

                            while (strInfo.Length < 32)
                            {
                                if (arrayJpeg[picturePos] == 255 && arrayJpeg[picturePos + 1] == 217)
                                    break;

                                if (arrayJpeg[picturePos] == 255 && arrayJpeg[picturePos + 1] == 0)
                                {
                                    strInfo += AddByte(Convert.ToString(arrayJpeg[picturePos], 2));
                                    picturePos++;
                                }
                                else
                                {
                                    strInfo += AddByte(Convert.ToString(arrayJpeg[picturePos], 2));
                                }

                                picturePos++;
                            }

                            strHuf += strInfo[indexStr++];

                            if (count == 0)
                            {
                                for (int j = 0; j < DC[strHuf.Length - 1].Length; j++)
                                {
                                    if (DC[strHuf.Length-1][j].Code == strHuf)
                                    {
                                        strStegImg += strInfo.Substring(0, strHuf.Length);
                                        strInfo = strInfo.Substring(strHuf.Length);

                                        if (DC[strHuf.Length-1][j].ValHex == "00")
                                        {
                                        }
                                        else
                                        {
                                            int chap = int.Parse(DC[strHuf.Length-1][j].ValHex.Substring(1, 1), System.Globalization.NumberStyles.HexNumber);

                                            for (int k = 0; k < int.Parse(DC[strHuf.Length-1][j].ValHex.Substring(0, 1), System.Globalization.NumberStyles.HexNumber); k++)
                                                count++;

                                            strStegImg += strInfo.Substring(0, chap);
                                            strInfo = strInfo.Substring(chap);
                                        }

                                        indexStr = 0;
                                        strHuf = "";
                                        count++;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                for (int j = 0; j < AC[strHuf.Length - 1].Length; j++)
                                {
                                    if (AC[strHuf.Length-1][j].Code == strHuf)
                                    {
                                        strStegImg += strInfo.Substring(0, strHuf.Length);
                                        strInfo = strInfo.Substring(strHuf.Length);

                                        if (AC[strHuf.Length-1][j].ValHex == "00")
                                        {
                                            goto found;
                                        }
                                        else
                                        {
                                            int chap = int.Parse(AC[strHuf.Length-1][j].ValHex.Substring(1, 1), System.Globalization.NumberStyles.HexNumber);

                                            for (int k = 0; k < int.Parse(AC[strHuf.Length-1][j].ValHex.Substring(0, 1), System.Globalization.NumberStyles.HexNumber); k++)
                                                count++;

                                            //
                                            if (!(hidePos == arrHide.Length && strHideInfo == ""))
                                            {
                                                if (chap > key[stegPos%key.Length])
                                                {
                                                    strHideInfo = WriteCode(ref hidePos, strHideInfo, arrHide, key[stegPos % key.Length]);

                                                    strStegImg += strInfo.Substring(0, chap - key[stegPos % key.Length]) + strHideInfo.Substring(0, key[stegPos % key.Length]);
                                                    strHideInfo = strHideInfo.Substring(key[stegPos % key.Length]);
                                                    info += (ulong)key[stegPos % key.Length];
                                                }
                                                else
                                                {
                                                    strHideInfo = WriteCode(ref hidePos, strHideInfo, arrHide, key[stegPos % key.Length]);

                                                    strStegImg += strHideInfo.Substring(0, chap);
                                                    strHideInfo = strHideInfo.Substring(chap);
                                                    info += (ulong)chap;
                                                }
                                            }
                                            else
                                            {
                                                strStegImg += strInfo.Substring(0, chap);
                                            }

                                            stegPos++;
                                            strInfo = strInfo.Substring(chap);
                                        }

                                        indexStr = 0;
                                        strHuf = "";
                                        count++;
                                        break;
                                    }
                                }
                            }

                        }
                    found:;

                        if ((arrayJpeg[picturePos] == 255 && arrayJpeg[picturePos + 1] == 218) || (arrayJpeg[picturePos] == 255 && arrayJpeg[picturePos + 1] == 217))
                            break;
                    }

                    strStegImg += strInfo;

                    while (strStegImg.Length >= 8)
                    {
                        stegIMG.Add(Convert.ToByte(strStegImg.Substring(0, 8), 2));

                        if (Convert.ToByte(strStegImg.Substring(0, 8), 2) == 255)
                            stegIMG.Add(0);

                        strStegImg = strStegImg.Substring(8);

                    }

                    stegIMG.Add(255);
                    stegIMG.Add(217);

                    File.WriteAllBytes(savePath, stegIMG.ToArray());
                    return;
                }


                if (arrayJpeg[picturePos] == 255 && arrayJpeg[picturePos + 1] == 217)
                    break;

                picturePos++;
            }

        }
        public byte[] jpegDecode(int[] key)
        {
            //arrayJpeg = File.ReadAllBytes(path);
            UInt64 picturePos = 0;
            UInt32 stegPos = 0;

            List<byte> findInfo = new List<byte>();
            String strFindInfo = "";

            //FF DA

            while (true)
            {
                if (arrayJpeg[picturePos] == 255 && arrayJpeg[picturePos + 1] == 218)
                {
                    List<int> compDC = new List<int>();
                    List<int> compAC = new List<int>();

                    picturePos++;
                    ulong nom = picturePos;
                    int len = 0;
                    len = Convert.ToInt32(AddByte(Convert.ToString(arrayJpeg[++picturePos], 2)) + AddByte(Convert.ToString(arrayJpeg[++picturePos], 2)), 2);
                    int cmpCount = arrayJpeg[++picturePos];
                    picturePos++;

                    for (int i = 0; i < cmpCount; i++)
                    {
                        picturePos++;

                        compDC.Add(Convert.ToInt32(AddByte(Convert.ToString(arrayJpeg[picturePos], 2)).Substring(0, 4), 2));
                        compAC.Add(Convert.ToInt32(AddByte(Convert.ToString(arrayJpeg[picturePos], 2)).Substring(4, 4), 2));

                        picturePos++;
                    }

                    picturePos = nom + (ulong)len;
                    picturePos++;

                    String infoStr = "";

                    int index = 0;
                    int qanak = 0;
                    info = 0;

                    while (true)
                    {
                        if (qanak < compCount[index % compCount.Length])
                            qanak++;
                        else
                        { qanak = 1; index++; }


                        int count = 0;
                        String strHuf = "";
                        int indexStr = 0;
                        HuffTree[][] DC = DHT_DC[compDC[index % compCount.Length]];
                        HuffTree[][] AC = DHT_AC[compAC[index % compCount.Length]];

                        while (count < 64)
                        {
                            while (strFindInfo.Length > 8)
                            {
                                findInfo.Add(Convert.ToByte(strFindInfo.Substring(0, 8), 2));
                                strFindInfo = strFindInfo.Substring(8);
                            }

                            while (infoStr.Length < 32)
                            {
                                if (arrayJpeg[picturePos] == 255 && arrayJpeg[picturePos + 1] == 217)
                                    break;

                                if (arrayJpeg[picturePos] == 255 && arrayJpeg[picturePos + 1] == 0)
                                {
                                    infoStr += AddByte(Convert.ToString(arrayJpeg[picturePos], 2));
                                    picturePos++;
                                }
                                else
                                {
                                    infoStr += AddByte(Convert.ToString(arrayJpeg[picturePos], 2));
                                }

                                picturePos++;
                            }

                            strHuf += infoStr[indexStr++];

                            if (count == 0)
                            {
                                for (int j = 0; j < DC[strHuf.Length - 1].Length; j++)
                                {
                                    if (DC[strHuf.Length-1][j].Code == strHuf)
                                    {
                                        infoStr = infoStr.Substring(strHuf.Length);

                                        if (DC[strHuf.Length-1][j].ValHex == "00")
                                        {
                                        }
                                        else
                                        {
                                            int chap = int.Parse(DC[strHuf.Length-1][j].ValHex.Substring(1, 1), System.Globalization.NumberStyles.HexNumber);

                                            for (int k = 0; k < int.Parse(DC[strHuf.Length-1][j].ValHex.Substring(0, 1), System.Globalization.NumberStyles.HexNumber); k++)
                                                count++;

                                            infoStr = infoStr.Substring(chap);
                                        }

                                        indexStr = 0;
                                        strHuf = "";
                                        count++;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                for (int j = 0; j < AC[strHuf.Length - 1].Length; j++)
                                {
                                    if (AC[strHuf.Length-1][j].Code == strHuf)
                                    {
                                        infoStr = infoStr.Substring(strHuf.Length);

                                        if (AC[strHuf.Length-1][j].ValHex == "00")
                                        {
                                            goto found;
                                        }
                                        else
                                        {
                                            int chap = int.Parse(AC[strHuf.Length-1][j].ValHex.Substring(1, 1), System.Globalization.NumberStyles.HexNumber);

                                            for (int k = 0; k < int.Parse(AC[strHuf.Length-1][j].ValHex.Substring(0, 1), System.Globalization.NumberStyles.HexNumber); k++)
                                                count++;


                                            if (chap > key[stegPos % key.Length])
                                            {

                                                strFindInfo += infoStr.Substring(chap - key[stegPos % key.Length], key[stegPos % key.Length]);
                                                info += (ulong)key[stegPos % key.Length];
                                            }
                                            else
                                            {
                                                strFindInfo += infoStr.Substring(0, chap);
                                                info += (ulong)chap;
                                            }

                                            stegPos++;
                                            infoStr = infoStr.Substring(chap);
                                        }
                                        indexStr = 0;
                                        strHuf = "";
                                        count++;
                                        break;
                                    }
                                }
                            }

                        }
                    found:;

                        if ((arrayJpeg[picturePos] == 255 && arrayJpeg[picturePos + 1] == 218) || (arrayJpeg[picturePos] == 255 && arrayJpeg[picturePos + 1] == 217))
                            break;
                    }


                    while (strFindInfo.Length >= 8)
                    {
                        findInfo.Add(Convert.ToByte(strFindInfo.Substring(0, 8), 2));

                        if (Convert.ToByte(strFindInfo.Substring(0, 8), 2) == 255)
                            findInfo.Add(0);

                        strFindInfo = strFindInfo.Substring(8);

                    }

                    return findInfo.ToArray();
                }


                if (arrayJpeg[picturePos] == 255 && arrayJpeg[picturePos + 1] == 217)
                    break;

                picturePos++;
            }

            return findInfo.ToArray();

        }

        private String AddByte(String btStr)
        {
            while (btStr.Length < 8)
                btStr = "0" + btStr;
            return btStr;
        }
        private String AddHexByte(String btStr)
        {
            return btStr.Length < 2 ? "0" + btStr : btStr;
        }
        private void JpegCompressor(String path)
        {
            byte[] byteArray = File.ReadAllBytes(path);

            List<byte> listJpeg = byteArray.OfType<byte>().ToList();

            int count = 0;

            for (int i = 0; i < listJpeg.Count - 1; i++)
                if (listJpeg[i] == 255 && listJpeg[i + 1] == 219)
                    count++;

            int pos = 0;

            for (int i = 0; i < listJpeg.Count - 1; i++)
                if (listJpeg[i] == 255 && listJpeg[i + 1] == 219)
                {
                    pos = i;
                    while (listJpeg[i] == 255 && listJpeg[i + 1] == 219)
                    {
                        i += 2;
                        int len = Convert.ToInt32(AddByte(Convert.ToString(listJpeg[i], 2)) + AddByte(Convert.ToString(listJpeg[i + 1], 2)), 2);
                        i += len;
                    }

                }

            listJpeg.RemoveRange(0, pos);
            listJpeg.InsertRange(0, new List<byte>() { 255, 216, 255, 254, 0, 4, 58, 41 });

            File.WriteAllBytes(System.IO.Directory.GetCurrentDirectory() + "\\" + "shablon.jpg", listJpeg.ToArray());

            FileInfo fi = new FileInfo(path);

            using (Image source = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\" + "shablon.jpg"))
            {
                ImageCodecInfo codec = ImageCodecInfo.GetImageEncoders().First(c => c.MimeType == "image/jpeg");

                EncoderParameters parameters = new EncoderParameters(3);
                parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality,100L);
                parameters.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.ScanMethod, (int)EncoderValue.ScanMethodInterlaced);
                parameters.Param[2] = new EncoderParameter(System.Drawing.Imaging.Encoder.RenderMethod, (int)EncoderValue.RenderProgressive);

                source.Save(fi.Name, codec, parameters);
            }

            arrayJpeg = File.ReadAllBytes(fi.Name);

            File.Delete(System.IO.Directory.GetCurrentDirectory() + "\\" + fi.Name);
            File.Delete(System.IO.Directory.GetCurrentDirectory() + "\\" + "shablon.jpg");

        }
        private String WriteCode(ref int pos, String strHideInfo, byte[] arrInfo,int stegType)
        {

            if (strHideInfo.Length < stegType)
            {
                if (pos != arrInfo.Length)
                    strHideInfo += AddByte(Convert.ToString(arrInfo[pos++], 2));
                else
                {
                    while (strHideInfo.Length % stegType != 0)
                        strHideInfo += "0";
                }
            }

            return strHideInfo;
        }


    }
}
