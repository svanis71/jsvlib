// // famsvanstrom.se: ExtensionMethods.cs
// // Author: Johan Svanström
// // Created: 2015-05-07
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

#endregion

namespace famsvanstrom.se.Extensions
{
    public static class ExtensionMethods
    {
        public static byte[] ToByteArray<T>(this T repository)
        {
            var formatter = new BinaryFormatter();
            var ms = new MemoryStream();
            formatter.Serialize(ms, repository);
            return ms.ToArray();
        }

        public static T GetSerializedForm<T>(this byte[] data)  where T : class
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