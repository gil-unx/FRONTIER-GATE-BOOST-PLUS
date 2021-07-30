using GIL.FUNCTION;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
namespace FRONTIERGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }
        private void CopyRegionIntoImage(Bitmap srcBitmap, Rectangle srcRegion, ref Bitmap destBitmap, Rectangle destRegion)
        {
            using (Graphics grD = Graphics.FromImage(destBitmap))
            {
                grD.DrawImage(srcBitmap, destRegion, srcRegion, GraphicsUnit.Pixel);



            }

        }
        private void GenerateModText()
        {

            FileStream fileStream = new FileStream(this.sp40.TXTNAME, FileMode.Open, FileAccess.Read);
            StreamReader txtReader = new StreamReader(fileStream);
            int txtIndex;
            this.sp40.MODIFIED_TEXT = new Dictionary<int, string>();
            for (int i = 0; i < this.sp40.TOTALSTRING; i++)
            {
                int index = i + 1;
                try
                {
                    txtIndex = int.Parse(txtReader.ReadLine().Substring(1, 8));
                    if (txtIndex != index)
                    {


                        return;
                    }

                }
                catch (FormatException)
                {


                    return;
                }

                string text = "";
                while (true)
                {
                    string line = txtReader.ReadLine();

                    if (line.Length > 10)
                    {
                        if (line.Substring(0, 10) == "----------")
                        {
                            text = text.Substring(0, text.Length - 1);

                            break;
                        }
                    }
                    text += line + "\n";
                }


               
                this.sp40.MODIFIED_TEXT.Add(index, text);
            }
            fileStream.Close();



        }
        private void InitListText()
        {
            for(int index =1;index < this.sp40.TOTALSTRING; index++)
            {
                ListViewItem row = new ListViewItem(index.ToString());
                ListViewItem.ListViewSubItem stringText = new ListViewItem.ListViewSubItem(row, this.sp40.MODIFIED_TEXT[index].Replace("\n", "\\n"));

                row.SubItems.Add(stringText);

                this.listText.Items.Add(row);



            }
        }
        private void InitPallete()
        {
            for (int i = 0; i < 16; i++)
            {

                Color col = Color.FromArgb(this.sp40.PALLETE[i][3], this.sp40.PALLETE[i][0], this.sp40.PALLETE[i][1], this.sp40.PALLETE[i][2]);
                this.pallete.Add(col);



            }


        }
        private void InitImg(string arr, ref Bitmap refImage)
        {
            byte[] arrayTile = Convert.FromBase64String(arr);

            byte[] buff = new byte[arrayTile.Length * 2];
            int j = 0;
            for (int i = 0; i < arrayTile.Length; i++)
            {
                buff[j] = (byte)(arrayTile[i] & 0x0f);
                j++;
                buff[j] = (byte)((byte)arrayTile[i] & 0xf0 >> 4);
                j++;

            }
            Bitmap img = new Bitmap(64, buff.Length / 64, PixelFormat.Format32bppArgb);
            int pixel = 0;
            for (int ypos = 0; ypos < buff.Length / 64; ypos++)
            {
                for (int xpos = 0; xpos < 64; xpos++)
                {
                    img.SetPixel(xpos, ypos, this.pallete[buff[pixel]]);
                    pixel++;
                }
            }
            refImage = img;
        }
        private void loadsp()
        {

            this.listText.Columns.Add("Index", 50, HorizontalAlignment.Left);
            this.listText.Columns.Add("Text", 500, HorizontalAlignment.Left);
            this.sp40 = JsonSerializer.Deserialize<SP40>(File.ReadAllText(this.fileName));


        }
        private void generateOrigImg(int index)
        {
            Bitmap textImage = new Bitmap(480, 240, PixelFormat.Format32bppArgb);
            Rectangle desRect = new Rectangle(10, 10, 0, 0);

            foreach (uint c in this.sp40.TEXT[index])
            {
                if (c == 0)
                {

                    continue;
                }


                else if (c < 0x800)
                {
                    Rectangle srcRect = this.sp40.SYSRECT[c];
                    desRect.Width = srcRect.Width;
                    desRect.Height = srcRect.Height;
                    CopyRegionIntoImage(this.sytemImg, srcRect, ref textImage, desRect);
                    desRect.X += desRect.Width + 2;





                }
                else if (c < 0x4000)
                {
                    Rectangle srcRect = this.sp40.KANJIRECT[c];
                    desRect.Width = srcRect.Width;
                    desRect.Height = srcRect.Height;
                    CopyRegionIntoImage(this.kanjiImg, srcRect, ref textImage, desRect);
                    desRect.X += desRect.Width + 2;
                }
                else
                {
                    switch (c)
                    {
                        case 0x4000:
                            desRect.Y += desRect.Height + 2;
                            desRect.X = 10;
                            break;
                        case 0x4001:
                            desRect.Y += desRect.Height * 2;
                            desRect.X = 10;
                            break;
                        default:
                            break;


                    }

                }


            }
            Bitmap res = new Bitmap(600, 300, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(res))
            {
                g.DrawImage(textImage, 0, 0, 600, 300);
            }
            this.originalImgBox.Image = res;


        }
        private void generateModImg(string text)
        {
            Bitmap textImage = new Bitmap(480, 240, PixelFormat.Format32bppArgb);
            Rectangle desRect = new Rectangle(10, 10, 0, 0);
            List<uint> modList = EncodeString(text + "----------", text.Length);
            foreach (uint c in modList)
            {
                if (c == 0)
                {

                    continue;
                }


                else if (c < 0x800)
                {
                    Rectangle srcRect = this.sp40.SYSRECT[c];
                    desRect.Width = srcRect.Width;
                    desRect.Height = srcRect.Height;
                    CopyRegionIntoImage(this.sytemImg, srcRect, ref textImage, desRect);
                    desRect.X += desRect.Width + 2;





                }
                else if (c < 0x4000)
                {
                    Rectangle srcRect = this.sp40.KANJIRECT[c];
                    desRect.Width = srcRect.Width;
                    desRect.Height = srcRect.Height;
                    CopyRegionIntoImage(this.kanjiImg, srcRect, ref textImage, desRect);
                    desRect.X += desRect.Width + 2;
                }
                else
                {
                    switch (c)
                    {
                        case 0x4000:
                            desRect.Y += desRect.Height + 2;
                            desRect.X = 10;
                            break;
                        case 0x4001:
                            desRect.Y += desRect.Height * 2;
                            desRect.X = 10;
                            break;
                        default:
                            break;


                    }

                }


            }
            Bitmap res = new Bitmap(600, 300, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(res))
            {
                g.DrawImage(textImage, 0, 0, 600, 300);
            }
            this.modifiedImgBox.Image = res;


        }
        private void listText_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.modifiedTextBox.Text = this.listText.FocusedItem.SubItems[1].Text.Replace("\\n", "\r\n");
            this.originalTextBox.Text = this.sp40.ORIGINAL_TEXT[int.Parse(this.listText.FocusedItem.SubItems[0].Text)].Replace("\n", "\r\n");
            generateOrigImg(int.Parse(this.listText.FocusedItem.SubItems[0].Text));


        }
        private void modifiedTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.listText.FocusedItem != null)
            {

                this.listText.FocusedItem.SubItems[1].Text = this.modifiedTextBox.Text.Replace("\r\n", "\\n");
                this.sp40.MODIFIED_TEXT[int.Parse(this.listText.FocusedItem.SubItems[0].Text)] = this.modifiedTextBox.Text.Replace("\r\n", "\n");





            }
        }
        private void modifiedImgBox_Click(object sender, EventArgs e)
        {
            if (this.listText.FocusedItem != null)
            {
                generateModImg(this.listText.FocusedItem.SubItems[1].Text.Replace("\\n", "\n"));

            }

        }
        private void openFile(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open json";
            theDialog.Filter = "fgb json|*.json";
            //theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(theDialog.FileName.ToString());
                this.fileName = theDialog.FileName.ToString();
                this.fileNameBox.Text = this.fileName;
                loadsp();
                this.listText.Items.Clear();
                GenerateModText();
                InitListText();
                InitPallete();
                InitImg(this.sp40.TILESYSTEM, ref this.sytemImg);
                if (this.sp40.TOTALKANJI != 0)
                {
                    InitImg(this.sp40.TILEKANJI, ref this.kanjiImg);
                }


            }
        }
        private List<uint> EncodeString(string decodedString, int lenString)
        {
            char[] array = decodedString.ToCharArray();

            //ushort num = ushort.MaxValue;
            List<string> s = new List<string>();
            List<uint> ret = new List<uint>();

            for (int i = 0; i < lenString; i++)
            {
                if
                (
                   array[i] == '[' &&
                   array[i + 1] == '{' &&
                   array[i + 2] == 'P' &&
                   array[i + 3] == 'A' &&
                   array[i + 4] == 'G' &&
                   array[i + 5] == 'E' &&
                   array[i + 6] == '}' &&
                   array[i + 7] == ']' &&
                   array[i + 8] == '\n'
                )
                {
                    s.Add("[{PAGE}]\n");

                    i += 8;
                }
                else if
                (
                   array[i] == '[' &&
                   array[i + 1] == '{' &&

                   array[i + 10] == '}' &&
                   array[i + 11] == ']'


                )
                {

                    s.Add(new string(new char[]
                    {
                        array[i ],
                        array[i + 1],
                        array[i + 2],
                        array[i + 3],
                        array[i + 4],
                        array[i + 5],
                        array[i + 6],
                        array[i + 7],
                        array[i + 8],
                        array[i + 9],
                        array[i + 10],
                        array[i + 11]




                    }));
                    i += 11;


                }
                else if
                (
                   array[i] == '[' &&
                   array[i + 1] == '{' &&

                   array[i + 9] == '}' &&
                   array[i + 10] == ']'


                )
                {

                    s.Add(new string(new char[]
                    {
                        array[i ],
                        array[i + 1],
                        array[i + 2],
                        array[i + 3],
                        array[i + 4],
                        array[i + 5],
                        array[i + 6],
                        array[i + 7],
                        array[i + 8],
                        array[i + 9],
                        array[i + 10],



                    }));
                    i += 10;


                }


                else if
               (
                  array[i] == '[' &&
                  array[i + 1] == '{' &&

                  array[i + 8] == '}' &&
                  array[i + 9] == ']'


               )
                {

                    s.Add(new string(new char[]
                    {
                        array[i ],
                        array[i + 1],
                        array[i + 2],
                        array[i + 3],
                        array[i + 4],
                        array[i + 5],
                        array[i + 6],
                        array[i + 7],
                        array[i + 8],
                        array[i + 9],



                    }));
                    i += 9;


                }


                else if
             (
                array[i] == '[' &&
                array[i + 1] == '{' &&

                array[i + 7] == '}' &&
                array[i + 8] == ']'


             )
                {

                    s.Add(new string(new char[]
                    {
                        array[i ],
                        array[i + 1],
                        array[i + 2],
                        array[i + 3],
                        array[i + 4],
                        array[i + 5],
                        array[i + 6],
                        array[i + 7],
                        array[i + 8],



                    }));
                    i += 8;


                }

                else if
            (
               array[i] == '[' &&
               array[i + 1] == '{' &&

               array[i + 6] == '}' &&
               array[i + 7] == ']'


            )
                {

                    s.Add(new string(new char[]
                    {
                        array[i ],
                        array[i + 1],
                        array[i + 2],
                        array[i + 3],
                        array[i + 4],
                        array[i + 5],
                        array[i + 6],
                        array[i + 7],




                    }));
                    i += 7;


                }

                else if
            (
               array[i] == '[' &&
               array[i + 1] == '{' &&

               array[i + 5] == '}' &&
               array[i + 6] == ']'


            )
                {

                    s.Add(new string(new char[]
                    {
                        array[i ],
                        array[i + 1],
                        array[i + 2],
                        array[i + 3],
                        array[i + 4],
                        array[i + 5],
                        array[i + 6],





                    }));
                    i += 6;


                }


                else if
           (
              array[i] == '[' &&
              array[i + 1] == '{' &&

              array[i + 4] == '}' &&
              array[i + 5] == ']'


           )
                {

                    s.Add(new string(new char[]
                    {
                        array[i ],
                        array[i + 1],
                        array[i + 2],
                        array[i + 3],
                        array[i + 4],
                        array[i + 5],






                    }));
                    i += 5;


                }

                else
                {

                    s.Add(array[i].ToString());



                }

            }

            foreach (string chr in s)
            {

                try
                {
                    ret.Add(this.sp40.TABLE.REVSYSTEM[chr]);

                }

                catch (Exception)
                {
                    try
                    {
                        ret.Add(this.sp40.TABLE.REVKANJI[chr]);

                    }

                    catch (Exception)
                    {
                        try
                        {
                            ret.Add(this.sp40.TABLE.REVCONTROLCODE[chr]);

                        }
                        catch (Exception)
                        {


                        }
                    }
                }


            }


            return ret;
        }
        private byte[] EncodeList(List<uint> arr)
        {
            MemoryStream buffer = new MemoryStream();
            BW buffWriter = new BW(buffer);



            foreach (uint sc in arr)
            {
                if (sc == 0)
                {
                    break;
                }
                uint bVar1 = sc;
                if (bVar1 < 0x81)
                {
                    buffWriter.Write((byte)bVar1);

                }
                else
                {
                    if (bVar1 < 0x4000)
                    {
                        uint hi = ((bVar1 & 0xff)) | 0x80;
                        uint lo = (bVar1 >> 7);
                        buffWriter.Write((ushort)((hi) | lo << 8));

                    }
                    else if (bVar1 == 0x4000)
                    {
                        buffWriter.Write((ushort)0x8080);

                    }
                    else if (bVar1 == 0x4001)
                    {
                        buffWriter.Write((ushort)0x8081);

                    }
                    else if (bVar1 == 0x4002)
                    {
                        buffWriter.Write((ushort)0x8082);

                    }
                    else if (bVar1 == 0x4003)
                    {
                        buffWriter.Write((ushort)0x8083);

                    }
                    else if ((bVar1 & 0xffff00) == 0x400800)
                    {
                        byte num = (byte)((bVar1 & 0xff));
                        buffWriter.Write((ushort)0x8088);
                        buffWriter.Write(num);

                    }
                    else if (bVar1 == 0x4009)
                    {
                        buffWriter.Write((ushort)0x8089);

                    }
                    else if ((bVar1 & 0xffff0000) == 0x40130000)
                    {

                        ushort hi = (ushort)((bVar1 & 0xff00) >> 8);
                        buffWriter.Write((ushort)0x8093);
                        buffWriter.Write((ushort)(hi));
                    }

                    else if ((bVar1 & 0xffff0000) == 0x40140000)
                    {

                        ushort hi = (ushort)((bVar1 & 0xff00) >> 8);
                        buffWriter.Write((ushort)0x8094);
                        buffWriter.Write((ushort)(hi));

                    }
                    else if ((bVar1 & 0xffff00) == 0x401900)
                    {
                        byte num = (byte)((bVar1 & 0xff));
                        buffWriter.Write((ushort)0x8099);
                        buffWriter.Write(num);
                    }

                }

            }



            return buffer.ToArray();
        }
        private void SaveSp40()
        {
            FileStream fileStream = new FileStream(this.sp40.FILENAME, FileMode.Create, FileAccess.Write);
            BW writer = new BW(fileStream);
            MemoryStream ptr = new MemoryStream();
            BW ptrWriter = new BW(ptr);
            MemoryStream text = new MemoryStream();
            BW textWriter = new BW(text);
            byte[] kanjiInfo;
            byte[] tile;


            for (int i = 1; i <= this.sp40.TOTALSTRING; i++)
            {
                string modText = this.sp40.MODIFIED_TEXT[i];
                string origText = this.sp40.ORIGINAL_TEXT[i];
                byte[] textArr;
                if (modText != origText)
                {
                    textArr = EncodeList(EncodeString(modText + "----------------", modText.Length));
                }
                else
                {
                    textArr = EncodeList(this.sp40.TEXT[i]);
                }


                ptrWriter.Write(i);
                ptrWriter.Write((int)textWriter.BaseStream.Position);
                textWriter.Write(textArr);
                textWriter.Write((byte)0);


            }

            ptrWriter.WritePadding(0x80, 0);
            textWriter.WritePadding(0x80, 0);




            if (this.sp40.TOTALKANJI == 0)
            {



                int fileOffset = 0x80;
                this.sp40.PTTEXT = fileOffset;
                fileOffset += (int)ptr.Length;
                this.sp40.TEXTOFFSET = fileOffset;
                fileOffset += (int)text.Length;
                this.sp40.FILESIZE = fileOffset;
                writer.Write(Convert.FromBase64String(this.sp40.MAGIC));
                writer.Write(this.sp40.FILESIZE);
                writer.Write((long)0);
                writer.Write(this.sp40.FILESIZE);
                writer.Write(this.sp40.PTTEXT);
                writer.Write(this.sp40.TEXTOFFSET);
                writer.Write(0);
                writer.Write(0);
                writer.Write(0);
                writer.Write(Convert.FromBase64String(this.sp40.UNK1));
                writer.Write(this.sp40.TOTALSTRING);
                writer.Write(Convert.FromBase64String(this.sp40.UNK2));
                writer.WritePadding(0x80, 0);
                writer.Write(ptr.ToArray());
                writer.Write(text.ToArray());


            }
            else
            {
                kanjiInfo = Convert.FromBase64String(this.sp40.INFOKANJI);
                tile = Convert.FromBase64String(this.sp40.TILEKANJI);
                int fileOffset = 0x80;
                this.sp40.PTTEXT = fileOffset;
                fileOffset += (int)ptr.Length;
                this.sp40.TEXTOFFSET = fileOffset;
                fileOffset += (int)text.Length;
                this.sp40.PTKANJI = fileOffset;
                fileOffset += kanjiInfo.Length;
                this.sp40.TILEOFFSET = fileOffset;
                fileOffset += tile.Length;
                this.sp40.FILESIZE = fileOffset;
                writer.Write(Convert.FromBase64String(this.sp40.MAGIC));
                writer.Write(this.sp40.TILEOFFSET);
                writer.Write((long)0);
                writer.Write(this.sp40.FILESIZE);
                writer.Write(this.sp40.PTTEXT);
                writer.Write(this.sp40.TEXTOFFSET);
                writer.Write(this.sp40.PTKANJI);
                writer.Write(this.sp40.TILEOFFSET);
                writer.Write(this.sp40.TOTALKANJI);
                writer.Write(Convert.FromBase64String(this.sp40.UNK1));
                writer.Write(this.sp40.TOTALSTRING);
                writer.Write(Convert.FromBase64String(this.sp40.UNK2));
                writer.WritePadding(0x80, 0);
                writer.Write(ptr.ToArray());
                writer.Write(text.ToArray());
                writer.Write(kanjiInfo);
                writer.Write(tile);
            }

            writer.Flush();
            writer.Close();


        }
        private void SaveTxt()
        {

            FileStream fs = new FileStream(this.sp40.TXTNAME, FileMode.Create, FileAccess.Write);
            StreamWriter txt = new StreamWriter(fs);
            for (int i = 1; i <= this.sp40.TOTALSTRING; i++)
            {
                txt.WriteLine(string.Format("[{0,0:d8}]", i));
                txt.WriteLine(this.sp40.MODIFIED_TEXT[i]);
                txt.WriteLine("-----------------------------------------------------");
                txt.Flush();


            }
            fs.Flush();
            fs.Close();


        }
        private void buttonSave40PS(object sender, EventArgs e)
        {
            if (this.fileName != null)
            {
                SaveSp40();
                SaveTxt();
                MessageBox.Show(string.Format("SAVED : {0}\nSAVED : {1}", this.sp40.FILENAME, this.sp40.TXTNAME));


            }
            else
            {
                MessageBox.Show("Select *.json File");

            }

        }
        private void UnpackFile(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "unpack_bin.bat";
            process.Start();
            process.WaitForExit();
            SERIAL serial = JsonSerializer.Deserialize<SERIAL>(File.ReadAllText("SERIAL.json"));
            foreach (INFO info in serial.CONTENT)
            {

                switch (info.EXT)
                {
                    case "SFP":
                        SFPUNPACK df = new SFPUNPACK(info.FILENAME, info.CONTENT);
                        break;
                    case "40PS":
                        break;
                    case "SLZ":
                        break;
                    default:
                        if (info.CONTENT != null)
                        {
                            BINUNPACK bin = new BINUNPACK(info.FILENAME, info.CONTENT);
                        }
                        break;

                }
            }
            MessageBox.Show("UNPACKING done..");

        }
        private void RepackFile(object sender, EventArgs e)
        {

            SERIAL serial = JsonSerializer.Deserialize<SERIAL>(File.ReadAllText("SERIAL.json"));
            foreach (INFO info in serial.CONTENT)
            {

                switch (info.EXT)
                {
                    case "SFP":
                        SFPREPACK df = new SFPREPACK(info.FILENAME, info.CONTENT);
                        break;
                    case "40PS":
                        break;
                    case "SLZ":
                        FileStream fileStream = new FileStream("USRDIR/009/ID00002", FileMode.Open, FileAccess.Write);
                        byte[] buffLZ = File.ReadAllBytes("USRDIR/009/ID00003");

                        BW writer = new BW(fileStream);
                        writer.BaseStream.Seek(3, SeekOrigin.Begin);
                        writer.Write((byte)0);
                        writer.BaseStream.Seek(8, SeekOrigin.Begin);
                        writer.Write((int)buffLZ.Length);
                        writer.Write((int)buffLZ.Length);
                        writer.BaseStream.Seek(0x20, SeekOrigin.Begin);
                        writer.Write(buffLZ);
                        fileStream.Flush();
                        fileStream.Close();
                        break;
                    default:
                        if (info.CONTENT != null)
                        {
                            BINREPACK bin = new BINREPACK(info.FILENAME, info.CONTENT);
                        }
                        break;

                }
            }
            Process process = new Process();
            process.StartInfo.FileName = "repack_bin.bat";
            process.Start();

            process.WaitForExit();
            MessageBox.Show("REPACKING done..");

        }
        private void ButtonSaveAll40PS(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles("JSON/", "*.json");
            this.progressBar1.Value = 0;
            this.progressBar1.Maximum = files.Length;
            foreach(string name in files)
            {
                this.fileName = name;
                loadsp();
                GenerateModText();
                SaveSp40();
                this.progressBar1.Value += 1;
            }
            this.progressBar1.Value = 0;


        }
    }
}
