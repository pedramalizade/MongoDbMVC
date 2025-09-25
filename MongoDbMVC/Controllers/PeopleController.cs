using MongoDB.Bson;
using MongoDbMVC.Models;
using System.Net;
using System.Web.Mvc;

namespace MongoDbMVC.Controllers
{
    public class PeopleController : Controller
    {
        DataManager db = new DataManager();

        public ActionResult Index()
        {
            return View(db.GetAllPerson());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.GetPersonById(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                db.InsertPerson(person);
                return RedirectToAction("Index");
            }

            return View(person);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.GetPersonById(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        [HttpPost]
        public ActionResult Edit(string id, Person person)
        {
            if (ModelState.IsValid)
            {
                person.Id = ObjectId.Parse(id);
                db.UpdatePerson(person);
                return RedirectToAction("Index");
            }

            return View(person);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.GetPersonById(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        public ActionResult DeleteConfirmed(string id)
        {
            db.DeletePerson(id);
            return RedirectToAction("Index");
        }
    }
}
