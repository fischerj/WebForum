using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using WebForum.Context;
using WebForum.Models;

namespace WebForum.Controllers
{
    public class TopicController : Controller
    {
        readonly TopicContext db = new TopicContext();
        // GET: Topic
        public ActionResult Index()
        {
            //ViewData["Topical"] = db.Topics.ToList();
            return View(db.Topics.ToList());
        }

        // GET: Topic/Details/5
        public ActionResult Details(Guid? id)
        {
            if(id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Topic topic = db.Topics.Find(id);
            if (topic == null)
                return HttpNotFound();
            return View(topic);
        }

        // GET: Topic/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Topic/Create
        [HttpPost]
        public ActionResult Create(Topic topic)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Topics.Add(topic);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(topic);
            }
            catch
            {
                return View();
            }
        }

        // GET: Topic/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if(id==null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Topic topic = db.Topics.Find(id);
            if(topic==null)
                return HttpNotFound();
            return View(topic);
        }

        // POST: Topic/Edit/5
        [HttpPost]
        public ActionResult Edit(Topic topic)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(topic).State= EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(topic);
            }
            catch
            {
                return View();
            }
        }

        // GET: Topic/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if(id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Topic topic = db.Topics.Find(id);
            if (topic == null)
                return HttpNotFound();
            return View(topic);
        }

        // POST: Topic/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid? id, Topic top)
        {
            try
            {
                Topic topic = new Topic();
                if (ModelState.IsValid)
                {
                    if(id==null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    topic = db.Topics.Find(id);
                    if(topic==null)
                        return HttpNotFound();
                    db.Topics.Remove(topic);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(topic);
            }
            catch
            {
                return View();
            }
        }
    }
}
