using ContactsForm.Data;
using ContactsForm.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsForm.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDBContext _db;

        public ContactController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ContactModel> objList = _db.Contacts;
            return View(objList);
            
        }
        //Get-Create
        public IActionResult Create()
        {
            
            return View();

        }

        //Post-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ContactModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.Contacts.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");


            }
            return View(obj);


        }

        //Get-Delete
        
        public IActionResult Delete(int? id)
        {
           
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Contacts.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);


        }

        //Post-Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int ContactId)
        {
            var obj = _db.Contacts.Find(ContactId);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Contacts.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }

        //Update-Delete

        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Contacts.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);


        }

        //Post-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ContactModel obj)
        {
            _db.Contacts.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }


    }
}
