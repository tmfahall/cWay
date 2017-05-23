using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cWay.Models;

namespace cWay.Controllers
{
    public class TrucksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Trucks
        public ActionResult Index()
        {
            return View(db.Trucks.ToList());
        }

        // GET: Trucks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Truck truck = db.Trucks.Include(t => t.Images).SingleOrDefault(i => i.TruckID == id);
            if (truck == null)
            {
                return HttpNotFound();
            }
            return View(truck);
        }

        // GET: Trucks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trucks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TruckId,TruckColor,TruckEngineHours,TruckSuspensionType,TruckMileage,TruckVin,TruckPrice,TruckDescription,TruckIsSold,TruckHas2Tanks,TruckTank1Size,TruckTank2Size,TruckBrakeCondition,TruckTireCondition,TruckHasSleeper,TruckIsListed,TruckDealerNotes,CreatedDate,TruckDealerDateOfPurchase,TruckDealerFinalSalePrice,TruckDealerImprovementCost,TruckDealerDateOfSale,TruckDealerPurchaseCost,TruckCabStyle,TruckEngineModel,TruckMake,TruckModel,TruckYear,TruckTransmissionType,TruckVehicleType,TruckBrakeType,TruckTransmissionSpeeds,TruckWheelBaseInches,TruckWheelSizeFront,TruckWheelSizeRear,TruckTurbo,TruckAxleConfiguration,TruckEngineMake")] Truck truck, IEnumerable<HttpPostedFileBase> upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null)
                {
                    truck.Images = new List<Image>();
                    foreach (var file in upload)
                    {
                        if (file.ContentLength > 0)
                        {
                            var fileName = System.IO.Path.GetFileName(file.FileName);
                            var photo = new Image
                            {
                                ImageFileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(file.FileName)
                            };
                            var path = System.IO.Path.Combine(Server.MapPath("~/Uploads"), photo.ImageFileName);
                            file.SaveAs(path);
                        truck.Images.Add(photo);
                        }
                        else
                        {
                            throw new System.ArgumentException("File.ContentLength == 0");
                        }
                    }
                    ModelState.Clear();
                }
                else
                {
                    throw new System.ArgumentException("upload == null");
                }

                db.Trucks.Add(truck);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(truck);
        }

        // GET: Trucks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Truck truck = db.Trucks.Find(id);
            if (truck == null)
            {
                return HttpNotFound();
            }
            return View(truck);
        }

        // POST: Trucks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TruckId,TruckColor,TruckEngineHours,TruckSuspensionType,TruckMileage,TruckVin,TruckPrice,TruckDescription,TruckIsSold,TruckHas2Tanks,TruckTank1Size,TruckTank2Size,TruckBrakeCondition,TruckTireCondition,TruckHasSleeper,TruckIsListed,TruckDealerNotes,CreatedDate,TruckDealerDateOfPurchase,TruckDealerFinalSalePrice,TruckDealerImprovementCost,TruckDealerDateOfSale,TruckDealerPurchaseCost,TruckCabStyle,TruckEngineModel,TruckMake,TruckModel,TruckYear,TruckTransmissionType,TruckVehicleType,TruckBrakeType,TruckTransmissionSpeeds,TruckWheelBaseInches,TruckWheelSizeFront,TruckWheelSizeRear,TruckTurbo,TruckAxleConfiguration,TruckEngineMake")] Truck truck)
        {
            if (ModelState.IsValid)
            {
                db.Entry(truck).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(truck);
        }

        // GET: Trucks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Truck truck = db.Trucks.Find(id);
            if (truck == null)
            {
                return HttpNotFound();
            }
            return View(truck);
        }

        // POST: Trucks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Truck truck = db.Trucks.Find(id);
            db.Trucks.Remove(truck);
            db.SaveChanges();
            return RedirectToAction("Index");
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
