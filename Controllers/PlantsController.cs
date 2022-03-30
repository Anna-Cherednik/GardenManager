using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GardenManager.Models;

namespace GardenManager.Controllers
{
    public class PlantsController : Controller
    {
        private GardenContext db = new GardenContext();

        // GET: Plants
        public ActionResult ПолучитьСписокРастений()
        {
            return View(db.Plants.ToList());
        }

        // GET: Plants/Details/5
        public ActionResult ПросмотретьПодробности(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plant plant = db.Plants.Find(id);
            if (plant == null)
            {
                return HttpNotFound();
            }
            return View(plant);
        }

        // GET: Plants/Create
        public ActionResult ДобавитьРастение()
        {
            ViewBag.SelectPlants = new MultiSelectList(db.Plants, "Id", "Name");
            return View();
        }

        // POST: Plants/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ДобавитьРастение([Bind(Include = "Id,Name,selectedPositivePlants,selectedNegativePlants")] Plant plant)
        {
            if (ModelState.IsValid)
            {
                Plant editPlant = plant;
                if (plant.selectedPositivePlants != null)
                {
                    foreach (var selectedPoses in plant.selectedPositivePlants)
                    {
                        editPlant.PositivePlants.Add(db.Plants.Find(selectedPoses));
                    }
                }
                if (plant.selectedNegativePlants != null)
                {
                    foreach (var selectedNegs in plant.selectedNegativePlants)
                    {
                        editPlant.NegativePlants.Add(db.Plants.Find(selectedNegs));
                    }
                }

                db.Plants.Add(editPlant);
                db.SaveChanges();

                return RedirectToAction("ПолучитьСписокРастений");
            }

            return View(plant);
        }

        // GET: Plants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plant plant = db.Plants.Find(id);
            if (plant == null)
            {
                return HttpNotFound();
            }
            return View(plant);
        }

        // POST: Plants/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Plant plant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ПолучитьСписокРастений");
            }
            return View(plant);
        }

        // GET: Plants/Delete/5
        public ActionResult Удалить(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plant plant = db.Plants.Find(id);
            if (plant == null)
            {
                return HttpNotFound();
            }
            return View(plant);
        }

        // POST: Plants/Delete/5
        [HttpPost, ActionName("Удалить")]
        [ValidateAntiForgeryToken]
        public ActionResult ПодтвержденоУдалить(int id)
        {
            Plant plant = db.Plants.Find(id);
            db.Plants.Remove(plant);
            db.SaveChanges();
            return RedirectToAction("ПолучитьСписокРастений");
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
