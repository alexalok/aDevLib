using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace aDevLib.Extensions.SerializationExtensions
{
    public static class BinarySerializationExtensions
    {
        public static byte[] BinSerialize<T>(this T obj)
        {
            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, obj);
                return memoryStream.ToArray();
            }
        }

        public static string BinSerializeToBase64<T>(this T obj)
        {
            return Convert.ToBase64String(BinSerialize(obj));
        }

        public static T BinDeserialize<T>(this byte[] data)
        {
            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream(data))
                return (T) binaryFormatter.Deserialize(memoryStream);
        }

        public static T BinDeserializeFromBase64<T>(this string base64EncodedData)
        {
            return BinDeserialize<T>(Convert.FromBase64String(base64EncodedData));
        }
    }
}