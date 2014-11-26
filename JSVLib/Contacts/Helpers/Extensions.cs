using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using Contacts.Models.Page;

namespace Contacts.Helpers
{
    public static class Extensions
    {
        public static byte[] ToByteArray(this ContactDataProvider repository)
        {
            var formatter = new BinaryFormatter();
            var ms = new MemoryStream();
            formatter.Serialize(ms, repository);
            return ms.ToArray();
        }

        public static ContactDataProvider GetSerializedForm(this byte[] data)
        {
            ContactDataProvider repository = null;
            if (data != null)
            {
                var formatter = new BinaryFormatter();
                var ms = new MemoryStream(data);
                repository = formatter.Deserialize(ms) as ContactDataProvider;

                if (repository == null)
                    throw new InvalidOperationException("Kunde inte deserialisera session");

            }
            return repository;
        }
    }
}