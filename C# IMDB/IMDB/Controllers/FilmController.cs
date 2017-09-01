﻿using System.Linq;
using System.Net;
using System.Web.Mvc;
using IMDB.Models;

namespace IMDB.Controllers
{
    [ValidateInput(false)]
    public class FilmController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var db = new IMDBDbContext())
            {
                var films = db.Films.ToList();

                return View(films);
            }
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            if (ModelState.IsValid)
            {
                using (var db = new IMDBDbContext())
                {
                    db.Films.Add(film);
                    db.SaveChanges();

                    return Redirect("/");
                }
            }
            return View();
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            using (var db = new IMDBDbContext())
            {
                var film = db.Films.Find(id);
                if (film != null)
                {
                    return View(film);
                }
            }
            return Redirect("/");
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Film filmModel)
        {
            if (!ModelState.IsValid)
            {
                return View(filmModel);
            }

            using (var db = new IMDBDbContext())
            {
                var filmEntity = db.Films.Find(id);
                if (filmEntity != null)
                {
                    filmEntity.Name = filmModel.Name;
                    filmEntity.Genre = filmModel.Genre;
                    filmEntity.Director = filmModel.Director;
                    filmEntity.Year = filmModel.Year;
                    db.SaveChanges();
                }
            }
            return Redirect("/");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {
            using (var db = new IMDBDbContext())
            {
                Film film = db.Films.Find(id);
               
                if (film == null)
                {
                    return Redirect("/");
                }
                return View(film);
            }
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id, Film filmModel)
        {
            if(id == null)
            {
                return HttpNotFound();
           
            }
            
                using (var db = new IMDBDbContext())
                {
                    Film film = db.Films.Find(id);
                    if (film == null)
                    {
                        return Redirect("/");
                    }
                    db.Films.Remove(film);
                    db.SaveChanges();
                }

            return Redirect("/");
        }
    }
}
