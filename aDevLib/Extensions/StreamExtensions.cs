using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace aDevLib.Extensions
{
    public static class StreamExtensions
    {
        public static async Task<byte[]> ReadExactly(this Stream stream, int count)
        {
            var buffer = new byte[count];
            var offset = 0;
            while (offset < count)
            {
                int read = await stream.ReadAsync(buffer, offset, count - offset);
                if (read == 0)
                    throw new EndOfStreamException();
                offset += read;
            }
            Debug.Assert(offset == count);
            return buffer;
        }
    }
}
