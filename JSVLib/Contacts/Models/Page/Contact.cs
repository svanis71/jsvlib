using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using Contacts.Helpers;

namespace Contacts.Models.Page
{
    [Serializable]
    public enum PhoneType
    {
        Mobile,
        Home,
        Work
    }

    [Serializable]
    public class Contact
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        [RegularExpression("\\d*", ErrorMessage = "Ålder måste vara numeriskt")]
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public List<Phone> PhoneNumbers { get; set; }
    }

    [Serializable]
    public class Phone
    {
        public Guid phoneId { get; set; }
        public Guid contactId { get; set; }
        public string Number { get; set; }
        public PhoneType Type { get; set; }
    }

    [Serializable]
    public class ContactDataProvider : List<Contact>
    {
        public static Contact New()
        {
            return new Contact() {Id = Guid.NewGuid(), PhotoUrl = "/upload/no_photo.gif",PhoneNumbers = new List<Phone>()};
        }

        public Contact GetById(Guid id)
        {
            return GetItems().SingleOrDefault(p => p.Id == id);
        }

        public void SaveItem(Contact card)
        {
            var allItems = GetItems();
            Contact item = null;
            
            if(allItems != null)
                item = allItems.SingleOrDefault(p => p.Id == card.Id);

            if(item == null)
            {
                Add(card);
            }

            else
            {
                item.Lastname = card.Lastname;
                item.Firstname = card.Firstname;
                item.Age = card.Age;
                //item.PhoneNumbers.Clear();
                //item.PhoneNumbers.AddRange(card.PhoneNumbers);
            }
            Save();
        }

        public IEnumerable<Contact> GetItems()
        {
            var dataPath = HttpContext.Current.Server.MapPath("~/App_Data");
            var xmlFile = Path.Combine(dataPath, "Contacts" + ".xml");
            var list = HttpContext.Current.Session["itemlist"] as byte[];
            ContactDataProvider repo = null;

            if (list == null && File.Exists(xmlFile))
            {
                var serializer = new XmlSerializer(typeof(ContactDataProvider));
                using (var sw = File.OpenRead(xmlFile))
                {
                    repo = serializer.Deserialize(sw) as ContactDataProvider;
                    sw.Close();
                }
            }
            else if (list != null)
                repo = list.GetSerializedForm();

            if (repo != null)
            {
                foreach (var item in repo)
                {
                    if(!this.Any(p => p.Id == item.Id))
                        Add(item);
                }
                HttpContext.Current.Session["itemlist"] = this.ToByteArray();
            }

            return this;
        }

        public void Save()
        {
            var dataPath = HttpContext.Current.Server.MapPath("~/App_Data");
            var xml = Path.Combine(dataPath, "Contacts" + ".xml");
            var serializer = new XmlSerializer(typeof(ContactDataProvider));

            using (var sw = File.OpenWrite(xml))
            {
                serializer.Serialize(sw, this);
                sw.Close();
            }
            HttpContext.Current.Session["itemlist"] = this.ToByteArray();
        }
    }
}