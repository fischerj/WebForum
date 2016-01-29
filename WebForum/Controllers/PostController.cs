﻿using System;
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
    public class PostController : Controller
    {
        readonly PostContext db = new PostContext();
        // GET: Post
        public ActionResult Index(Guid? TopicId)
        {
            try
            {
                if (TopicId != null)
                {


                    //List<Post> postList = db.Posts.ToList();
                    //foreach (var post in postList)
                    //    if (post.TopicId != TopicId)
                    //    {
                    //        postList.Remove(post);
                    //    }

                    var post = db.Posts.Where(p => p.TopicId == TopicId);

                    return View(post);
                }
            }
            catch (Exception)
            {

                return View(db.Posts.ToList());
            }
            return View();
        }

        // GET: Post/Details/5
        public ActionResult Details(Guid id)
        {
            Post post = db.Posts.Find(id);
            return View(post);
        }

        // GET: Post/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(Post post, Guid TopicId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Topic topic = Tdb.Topics.Find(name);
                    //Guid topicId = topic.Id;
                    //post.TopicId = topicId;

                    post.TopicId = TopicId;
                    db.Posts.Add(post);
                    
                    db.SaveChanges();
                    return RedirectToAction("Index", post.Id);
                }
                return View(post);
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(Guid? id)
        {
           if(id==null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Post post = db.Posts.Find(id);
            if(post==null)
                return HttpNotFound();
            return View(post);
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(Post post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(post).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(post);
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
