using System;
using System.IO;
using System.Xml.Serialization;

namespace aDevLib.Extensions.SerializationExtensions
{
    public static class XmlSerializationExtensions
    {
        public static byte[] XmlSerialize<T>(this T obj)
        {
            var xmlFormatter = new XmlSerializer(typeof(T));
            using (var memoryStream = new MemoryStream())
            {
                xmlFormatter.Serialize(memoryStream, obj);
                return memoryStream.ToArray();
            }
        }

        public static string  XmlSerializeToBase64<T>(this T obj) =>
            Convert.ToBase64String(XmlSerialize(obj));

        public static T XmlDeserialize<T>(this byte[] data)
        {
            var xmlFormatter = new XmlSerializer(typeof(T));
            using (var memoryStream = new MemoryStream(data))
                return (T) xmlFormatter.Deserialize(memoryStream);
        }

        public static T XmlDeserializeFromBase64<T>(this string base64EncodedData) =>
            XmlDeserialize<T>(Convert.FromBase64String(base64EncodedData));
    }
}