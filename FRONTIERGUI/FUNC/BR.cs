using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
namespace GIL.FUNCTION
{

    public class BR :BinaryReader
    {
        public  BR(Stream stream):base(stream)
        {
        	
        }
        public Int32 ReadInt32BE()
        {
        	var data = base.ReadBytes(4);
        	Array.Reverse(data);
        	return BitConverter.ToInt32(data, 0);
        }
        public Int16 ReadInt16BE()
        {
        	var data = base.ReadBytes(2);
        	Array.Reverse(data);
        	return BitConverter.ToInt16(data, 0);
        }
        public string GetUtf8()
    	{
            var bldr = new StringBuilder();
            int nc;
            while ((nc = base.Read()) > 0)
            bldr.Append((char)nc);
            return bldr.ToString();
        }
        public byte[] GetBinaryNullTerm()
        {
            List<byte> bldr = new List<byte>();
            byte nc;
            while ((nc = base.ReadByte()) > 0)
                bldr.Add(nc);
            return bldr.ToArray();
        }

        public string GetUtf16()
       {
             var bldr = new StringBuilder();
             int nc;
             while ((nc = base.ReadInt16()) > 0)
             bldr.Append((char)nc);
             return bldr.ToString();
        }
        public void ReadPadding(int padding)
        { 
        	
			while (base.BaseStream.Position % (long)padding != 0L)
				{
						base.BaseStream.ReadByte();
				}
        	
        }
        public byte[] GetBytes(long offset, int size)
        
        {
        	long tmp = base.BaseStream.Position;
        	base.BaseStream.Seek(offset, SeekOrigin.Begin);
        	byte[] v = base.ReadBytes(size);
        	base.BaseStream.Seek(tmp, SeekOrigin.Begin);
        	return v;
        }
        
    }
}