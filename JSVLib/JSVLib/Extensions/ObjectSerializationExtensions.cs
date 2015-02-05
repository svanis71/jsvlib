using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace JSVLib.Extensions
{
    public static class ObjectSerializationExtensions
    {
        public static byte[] ToByteArray<T>(this T repository)
        {
            var formatter = new BinaryFormatter();
            var ms = new MemoryStream();
            formatter.Serialize(ms, repository);
            return ms.ToArray();
        }

        public static T GetSerializedForm<T>(this byte[] data) where T : class
        {
            var repository = default(T);
            if (data != null)
            {
                var formatter = new BinaryFormatter();
                var ms = new MemoryStream(data);
                repository = formatter.Deserialize(ms) as T;

                if (repository == null)
                    throw new InvalidOperationException("Kunde inte deserialisera session");

            }
            return repository;
        }
    }
}
