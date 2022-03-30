using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GardenManager.Models;

namespace GardenManager.Controllers
{
    public class ТериторииController : Controller
    {
        private GardenContext db = new GardenContext();

        // GET: Територия
        public ActionResult ПолучитьСписокУчастков()
        {
            return View(db.Територии.ToList());
        }

        // GET: Територии/ПросмотретьПодробности/5
        public ActionResult ПросмотретьПодробности(int? tid)
        {
            Територия територия = db.Територии.Find(tid);

            return View(територия);
        }

        // GET: Територии/ПодробностиРазметки/5
        public ActionResult ПодробностиРазметки(int? tid, int? rid)
        {
            Разметка разметка = db.Разметки.Find(rid);
            Територия територия = db.Територии.Find(tid);
            ViewBag.Length = територия.Length;
            ViewBag.Width = територия.Width;
            ViewBag.Tid = територия.Id;

            return View(разметка);
        }

        // GET: Територия/ДобавитьНовыйУчасток
        public ActionResult ДобавитьНовыйУчасток()
        {
            return View();
        }

        // POST: Територия/ДобавитьНовыйУчасток
        [HttpPost]
        public ActionResult ДобавитьНовыйУчасток(Територия територия)
        {
            try
            {
                // TODO: Add insert logic here
                db.Територии.Add(територия);
                db.SaveChanges();

                //return View("ПолучитьСписокУчастков", МоиТеритории);//
                return RedirectToAction("ПолучитьСписокУчастков");
            }
            catch
            {
                return View();
            }
        }

        // GET: Територии/СоздатьНовуюРазметку
        public ActionResult СоздатьНовуюРазметку(int tid)
        {
            return View();
        }

        // POST: Територии/СоздатьНовуюРазметку
        [HttpPost]
        public ActionResult СоздатьНовуюРазметку(int tid, Разметка разметка)
        {
            try
            {
                // TODO: Add insert logic here
                db.Разметки.Add(разметка);
                Територия територия = db.Територии.Find(tid);
                територия.Разметки.Add(разметка);
                db.SaveChanges();

                //return View("ПолучитьСписокУчастков", МоиТеритории);//
                return RedirectToAction("ПолучитьСписокУчастков");
            }
            catch
            {
                return View();
            }
        }

        // GET: Територии/СоздатьНовуюЗону
        public ActionResult СоздатьНовуюЗону(int tid, int rid)
        {
            Zone zone = new Zone();
            zone.Coordinates.AddRange(new List<Coordinates>() { new Coordinates(), new Coordinates()});
            return View(zone);
        }

        // POST: Територии/СоздатьНовуюЗону
        [HttpPost]
        public ActionResult СоздатьНовуюЗону(int tid, int rid, Zone zone)
        {
            try
            {
                // TODO: Add insert logic here
                zone.Рекомендации.AddRange(db.Plants.ToList());
                db.Zones.Add(zone);
                Разметка разметка = db.Разметки.Find(rid);
                разметка.Zones.Add(zone);
                db.SaveChanges();

                //return View("ПолучитьСписокУчастков", МоиТеритории);//
                return RedirectToAction("ДобавитьРастениеВЗону", new { tid = tid, rid = rid, zid = zone.Id});
            }
            catch
            {
                return View();
            }
        }

        // GET: Територии/СоздатьНовуюЗону
        public ActionResult ДобавитьРастениеВЗону(int tid, int rid, int zid)
        {
            Zone zone = db.Zones.Find(zid);

            return View(zone);
        }


        // POST: Територии/СоздатьНовуюЗону
        [HttpPost]
        public ActionResult ДобавитьРастениеВЗону(int tid, int rid, int zid, Zone zone)
        {
            try
            {
                // TODO: Add insert logic here
                Zone editedZone = db.Zones.Find(zid);
                editedZone.UsePlant_Id = zone.UsePlant_Id;
                editedZone.UsePlant = db.Plants.Find(zone.UsePlant);   
                db.SaveChanges();

                //return View("ПолучитьСписокУчастков", МоиТеритории);//
                return RedirectToAction("ПолучитьСписокУчастков");
            }
            catch
            {
                return View(zone);
            }
        }

        // GET: Територия/Edit/5
        public ActionResult Edit(string name)
        {
            return View();
        }

        // POST: Територия/Edit/5
        [HttpPost]
        public ActionResult Edit(string name, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Територия/Удалить/5
        public ActionResult Удалить(int tid)
        {
            Територия територия = db.Територии.Find(tid);
            return View(територия);
        }

        // POST: Територия/Удалить/5
        [HttpPost]
        public ActionResult Удалить(int tid, Територия удалить)
        {
            try
            {
                // TODO: Add delete logic here
                Територия територия = db.Територии.Find(tid);
                db.Територии.Remove(територия);
                db.SaveChanges();

                return RedirectToAction("ПолучитьСписокУчастков");
            }
            catch
            {
                return View();
            }
        }
    }
}
