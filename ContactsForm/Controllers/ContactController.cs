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
            _db.Contacts.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            

        }


    }
}
