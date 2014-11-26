using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contacts.Models.Page;

namespace Contacts.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: metoder

        public ActionResult Index()
        {
            var provider = new ContactDataProvider();
            return View(provider.GetItems());
        }

        public ActionResult Create()
        {
            ViewBag.PhoneTypes = Enum.GetNames(typeof (PhoneType));
            return PartialView(ContactDataProvider.New());
        }

        public ActionResult Edit(Guid id)
        {
            var contact = new ContactDataProvider().GetById(id);
            return PartialView(contact);
        }

        public ActionResult PhoneList(Contact contactCard)
        {
            var provider = new ContactDataProvider();
            var card = provider.GetById(contactCard.Id);
            return PartialView(card.PhoneNumbers);
        }

        public ActionResult UploadPhoto(Guid id)
        {
            var contact = new ContactDataProvider().GetById(id);
            return View(contact);
        }

        [HttpPost]
        public ActionResult SavePhoto(Guid Id)
        {
            var provider = new ContactDataProvider();
            var card = provider.GetById(Id);
            var file = Request.Files[0];
            var imgSize = new byte[file.ContentLength];
            var extension = System.IO.Path.GetExtension(file.FileName);
            card.PhotoUrl = "/upload/" + Id.ToString() + extension;
            file.InputStream.Read(imgSize, 0, (int)file.ContentLength);
            var path = Server.MapPath("/upload");
            var filePath = Path.Combine(path, Id.ToString() + extension);

            using(var sw = new FileStream(filePath, FileMode.CreateNew))
            {
                sw.Write(imgSize, 0, (int)file.ContentLength);
                sw.Close();
            }

            provider.SaveItem(card);
            return RedirectToAction("Index");

        }

        // POST metoder

        [HttpPost]
        public JsonResult Save(Contact contact)
        {
            //if (!ModelState.IsValid)
            //    return View(contact);

            var provider = new ContactDataProvider();
            var card = provider.GetById(contact.Id);
            if (card != null)
            {
                card.Lastname = contact.Lastname;
                card.Firstname = contact.Firstname;
                card.Email = contact.Email;
                card.Age = contact.Age;
                card.PhotoUrl = contact.PhotoUrl;
                if (card.PhoneNumbers == null)
                    card.PhoneNumbers = new List<Phone>();
                provider.SaveItem(card);
            }
            else
            {
                provider.SaveItem(contact);
            }

            return Json(contact);
        }

        //[HttpPost]
        //public ActionResult Edit(Contact contacts)
        //{
        //    var provider = new ContactDataProvider();
        //    var card = provider.GetById(contacts.Id);
        //    card.Lastname = contacts.Lastname;
        //    card.Firstname = contacts.Firstname;
        //    card.Email = contacts.Email;
        //    card.Age = contacts.Age;
        //    provider.SaveItem(card);
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public JsonResult PhoneList(Phone phone)
        {
            var provider = new ContactDataProvider();
            var card = provider.GetById(phone.contactId);
            var phn = card.PhoneNumbers.SingleOrDefault(p => p.Number == phone.Number);
            if(phn == null)
                card.PhoneNumbers.Add(phn);
            else
            {
                phn.Number = phone.Number;
                phn.Type = phone.Type;
            }
            provider.SaveItem(card);

            return Json(new { Success = true });
        }

        [HttpPost]
        public JsonResult SavePhone(Phone editPhone)
        {
            var provider = new ContactDataProvider();
            var card = provider.GetById(editPhone.contactId);
            if(card.PhoneNumbers == null)
                card.PhoneNumbers = new List<Phone>();
            var phone = card.PhoneNumbers.SingleOrDefault(p => p.phoneId == editPhone.phoneId);
            if (phone == null)
            {
                phone = new Phone() {phoneId = Guid.NewGuid(), contactId = editPhone.contactId, Number = editPhone.Number, Type =  editPhone.Type };
                card.PhoneNumbers.Add(phone);
            }
            else
            {
                phone.Number = editPhone.Number;
                phone.Type = editPhone.Type;
            }
            provider.SaveItem(card);

            return Json(new { phoneId = phone.phoneId, contactId = phone.contactId, Number = phone.Number, Type = phone.Type.ToString() });
        }
    }
}
