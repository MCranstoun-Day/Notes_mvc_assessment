using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Notes.Models;

namespace Notes.Controllers
{
    
    public class NotesController : Controller
    {

        private NoteModels db = new NoteModels();
        string CurrentUserName = System.Web.HttpContext.Current.User.Identity.GetUserName();
        string CurrentUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();

        // GET: Notes
        public ActionResult Index()
        {
            return View(db.ViewNotes.ToList());
        }

        // GET: Notes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewNote viewNote = db.ViewNotes.Find(id);
            if (viewNote == null)
            {
                return HttpNotFound();
            }
            return View(viewNote);
        }

        // GET: Notes/Create
        public ActionResult Create()
        {
            Note note = new Note();
            note.CategoryList = Repos.GetListController.GetCategoryList();

            return View(note);
        }

        // POST: Notes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Notes_ID,NoteDescription,NoteCategory_ID")] Note note)
        {
            if (ModelState.IsValid)
            {
                note.CreateBy = CurrentUserName;
                note.CreateDateTime = DateTime.Now;
                note.SaveBy = CurrentUserName;
                note.SaveDateTime = DateTime.Now;

                db.Notes.Add(note);
                db.SaveChanges();
                return RedirectToAction("Index", "Home",null);
            }

            return View(note);
        }

        // GET: Notes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewNote viewNote = (from x in db.ViewNotes where x.Notes_ID == id select x).FirstOrDefault();

            viewNote.CategoryList = Repos.GetListController.GetCategoryList();

            if (viewNote == null)
            {
                return HttpNotFound();
            }
            return View(viewNote);
        }

        // POST: Notes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewNote viewNote)
        {

            if (ModelState.IsValid)
            {
                Note note = db.Notes.Find(viewNote.Notes_ID);

                note.NoteDescription = viewNote.NoteDescription;
                note.NoteCategory_ID = viewNote.NoteCategory_ID;

                note.SaveBy = CurrentUserName;
                note.SaveDateTime = DateTime.Now;

                db.Entry(note).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "Home", null);

            }
            return View(viewNote);
        }

        // GET: Notes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewNote viewNote = db.ViewNotes.Find(id);

            if (viewNote == null)
            {
                return HttpNotFound();
            }
            return View(viewNote);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Note note = db.Notes.Find(id);
            db.Notes.Remove(note);
            db.SaveChanges();
            return RedirectToAction("Index", "Home", null);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
