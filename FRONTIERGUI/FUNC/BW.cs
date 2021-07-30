using System.IO;
namespace GIL.FUNCTION
{
    class BW : BinaryWriter
    {
        public BW(Stream stream) : base(stream)
        {

        }
        public void WritePadding(int padding, long pos)
        {
            while ((base.BaseStream.Position - pos) % (long)padding != 0L)
            {
                base.Write((byte)0);
            }
        }
        public void WriteInt32BE(uint val)
        {
            base.Write((byte)(val / 16777216 & (int)byte.MaxValue));
            base.Write((byte)(val / 65536 & (int)byte.MaxValue));
            base.Write((byte)(val / 256 & (int)byte.MaxValue));
            base.Write((byte)(val & (int)byte.MaxValue));

        }

    }
}