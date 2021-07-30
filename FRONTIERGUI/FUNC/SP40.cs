using GIL.FUNCTION;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace FRONTIERGUI
{
    class TBL
    {
        public Dictionary<uint, string> SYSTEM { get; set; }
        public Dictionary<uint, string> CONTROLCODE { get; set; }
        public Dictionary<uint, string> KANJI { get; set; }
        public Dictionary<string, uint> REVSYSTEM { get; set; }
        public Dictionary<string, uint> REVCONTROLCODE { get; set; }
        public Dictionary<string, uint> REVKANJI { get; set; }

    }
    class SP40
    {
        public string FILENAME { get; set; }
        public string TXTNAME { get; set; }

        public Dictionary<int, string> ORIGINAL_TEXT { get; set; }
        public Dictionary<int, string> MODIFIED_TEXT { get; set; }

        public TBL TABLE { get; set; }
        public string MAGIC { get; set; }
        public int TILEOFFSET { get; set; }
        public int FILESIZE { get; set; }
        public int PTTEXT { get; set; }
        public int TEXTOFFSET { get; set; }
        public int PTKANJI { get; set; }
        public int TOTALKANJI { get; set; }
        public string UNK1 { get; set; }
        public int TOTALSTRING { get; set; }
        public string UNK2 { get; set; }
        public Dictionary<int, List<uint>> TEXT { get; set; }
        public List<List<int>> PALLETE { get; set; }
        public string INFOSYSTEM { get; set; }
        public string TILESYSTEM { get; set; }
        public string INFOKANJI { get; set; }
        public string TILEKANJI { get; set; }
        public Dictionary<uint, Rectangle> SYSRECT { get; set; }

        public Dictionary<uint, Rectangle> KANJIRECT { get; set; }







    }
    public class SERIAL
    {
        public List<INFO> CONTENT { get; set; }
    }
    public class INFO
    {
        public string FILENAME { get; set; }
        public string PACKTYPE { get; set; }
        public string EXT { get; set; }
        public int FILESIZE { get; set; }
        public int UNK { get; set; }
        public int SIZEPLUS { get; set; }

        public List<INFO> CONTENT { get; set; }

    }
    class BINUNPACK
    {
        private BR reader;
        private List<INFO> infos;
        private string outFolder;
        public BINUNPACK(string fileName, List<INFO> inf)
        {
            infos = inf;
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            outFolder = Path.GetDirectoryName(fileName) + "\\" + Path.GetFileNameWithoutExtension(fileName) + "_";

            Console.WriteLine(outFolder);

            Directory.CreateDirectory(outFolder);
            reader = new BR(fileStream);
            Unpack();
            fileStream.Close();


        }
        private void Unpack()
        {

            foreach (INFO info in infos)
            {
                byte[] magic = reader.ReadBytes(4);
                int size = reader.ReadInt32();
                int unk = reader.ReadInt32();
                int sizeplus = reader.ReadInt32();
                byte[] buffData = reader.ReadBytes(size);

                if (info.EXT == "null")
                {
                    size = info.FILESIZE;
                    buffData = reader.ReadBytes(size);
                }
                reader.ReadPadding(16);
                string fileName = info.FILENAME;
                Console.WriteLine(fileName);
                FileStream outStream = new FileStream(outFolder + "\\" + fileName, FileMode.Create, FileAccess.Write);
                outStream.Write(buffData, 0, size);
                outStream.Flush();
                outStream.Close();
                if (info.CONTENT != null)
                {
                    BINUNPACK bin = new BINUNPACK(outFolder + "\\" + fileName, info.CONTENT);
                }

            }


        }
    }
    class BINREPACK
    {
        private BW writer;
        private List<INFO> infos;
        private string outFolder;
        public BINREPACK(string fileName, List<INFO> inf)
        {
            infos = inf;
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            outFolder = Path.GetDirectoryName(fileName) + "\\" + Path.GetFileNameWithoutExtension(fileName) + "_";
            Directory.CreateDirectory(outFolder);
            writer = new BW(fileStream);
            Repack();
            fileStream.Close();


        }
        private void Repack()
        {

            foreach (INFO info in infos)
            {
                Console.WriteLine(outFolder + info.FILENAME);
                if (info.CONTENT != null)
                {
                    BINREPACK bin = new BINREPACK(outFolder + "\\" + info.FILENAME, info.CONTENT);
                }
                byte[] buffer = File.ReadAllBytes(outFolder + "\\" + info.FILENAME);

                int fileSize = (int)buffer.Length;
                int sizeplus = 16 + fileSize;
                int padding = 16 - (16 - (fileSize % 16));
                if (padding != 0)
                {
                    sizeplus += (16 - padding);
                }

                switch (info.PACKTYPE)
                {
                    case "DNE":
                        sizeplus = 0;
                        fileSize = 0;
                        break;
                    case "null":
                        sizeplus = 0;
                        fileSize = 0;
                        info.PACKTYPE = "\u0000";
                        break;
                    default:
                        break;



                }
                writer.Write(Encoding.UTF8.GetBytes(info.PACKTYPE));
                writer.WritePadding(4, 0);
                writer.Write(fileSize);
                writer.Write(info.UNK);
                writer.Write(sizeplus);
                writer.Write(buffer);
                writer.WritePadding(16, 0);


            }


        }
    }
    class SFPUNPACK
    {
        private List<INFO> infos;
        private BR reader;
        private List<int> pointer = new List<int>();
        private string outFolder;
        public SFPUNPACK(string fileName, List<INFO> inf)
        {
            infos = inf;
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            outFolder = fileName + "_";
            Directory.CreateDirectory(outFolder);
            reader = new BR(fileStream);
            byte[] magic = reader.ReadBytes(12);
            reader.ReadBytes(4);
            int fileSize = reader.ReadInt32();
            for (int i = 0; i < 2; i++)
            {
                pointer.Add(reader.ReadInt32());
            }

            pointer.Add((int)fileStream.Length);
            Unpack();
            fileStream.Close();

        }
        private void Unpack()
        {
            for (int i = 0; i < 2; i++)
            {
                int offset = pointer[i];
                int size = pointer[i + 1] - offset;
                byte[] buffData = reader.GetBytes((long)offset, size);
                string fileName = infos[i].FILENAME;
                FileStream outStream = new FileStream(outFolder + "//" + fileName, FileMode.Create, FileAccess.Write);
                Console.WriteLine(outFolder);
                outStream.Write(buffData, 0, size);
                outStream.Flush();
                outStream.Close();





            }


        }

    }
    class SFPREPACK
    {
        private List<INFO> infos;
        private BW writer;
        private List<int> pointer = new List<int>();
        private string outFolder;
        private MemoryStream memoryStream;

        public SFPREPACK(string fileName, List<INFO> inf)
        {
            infos = inf;
            outFolder = fileName + "_";
            byte[] buff = File.ReadAllBytes(fileName);
            MemoryStream hdr = new MemoryStream(buff, 0, 0x20);
            memoryStream = new MemoryStream();
            writer = new BW(memoryStream);
            writer.Write(hdr.ToArray());
            Repack();
            File.WriteAllBytes(fileName, memoryStream.ToArray());



        }
        private void Repack()
        {
            foreach (INFO info in infos)
            {
                string fileName = info.FILENAME;
                byte[] buffer = File.ReadAllBytes(outFolder + "\\" + fileName);
                int offset = (int)writer.BaseStream.Position;
                pointer.Add(offset);
                writer.Write(buffer, 0, (int)buffer.Length);

            }
            int fileSize = (int)writer.BaseStream.Position;
            writer.BaseStream.Seek(0x10, SeekOrigin.Begin);
            writer.Write(fileSize);
            writer.Write(pointer[0]);
            writer.Write(pointer[1]);




        }

    }

}
