using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.Web.Controllers
{
    public class FlightController : Controller
    {

        IFlightMethods Sp;
        IServicePlane Pl;

        public FlightController(IFlightMethods sp, IServicePlane pl)
        {
            Sp = sp;
            Pl = pl;
        }





        // GET: FlightController
        public ActionResult Index()
        {
            return View(Sp.GetAll());
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            //afficher les capacity dans les relation entre les deuxtables (dans tables flight afficher liste des plane)
            ViewBag.Planeid=new SelectList(Pl.GetAll(), "PlaneId","Capacity");
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult Create(Flight flight, IFormFile PilotImage)

        {


            try

            {

                if (PilotImage != null)

                {

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", PilotImage.FileName);

                    Stream stream = new FileStream(path, FileMode.Create);

                    PilotImage.CopyTo(stream);

                    flight.AirlineLogo = PilotImage.FileName;

                }

                Sp.Add(flight);

                Sp.Commit();

                return RedirectToAction(nameof(Index));

            }

            catch

            {

                return View();

            }

        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Planeid = new SelectList(Pl.GetAll(), "PlaneId", "Capacity");
            var flight = Sp.GetById(id);
            return View(flight);
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Flight flight, IFormFile PilotImage)
        {
            try
            {
                if (PilotImage != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", PilotImage.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        PilotImage.CopyTo(stream);
                    }
                    flight.AirlineLogo = PilotImage.FileName;
                }

                Sp.Update(flight);
                Sp.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Planeid = new SelectList(Pl.GetAll(), "PlaneId", "Capacity");
            var flight = Sp.GetById(id);
            return View(flight);
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var flight = Sp.GetById(id);
                Sp.Delete(flight); 
                Sp.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        

    }
}
