using Homework3._27.Data;
using Homework3._27.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Homework3._27.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _connection = @"data Source=.;Initial Catalog=MyFirstDatabase;Integrated Security=true;TrustServerCertificate=True";

        public IActionResult Index()
        {
            var db = new PeopleDatabase(_connection);
            var pvm = new PeopleViewModel()
            {
                People = db.GetPeople(),
            };
            if (TempData["message"] != null)
            {
                pvm.Message = (string)TempData["message"];
            }
            return View(pvm);
        }
        public IActionResult AddPeople()
        {
            PeopleViewModel pvm = new();
            return View(pvm);
        }
        [HttpPost]
        public IActionResult AddPeople(List<Person> people)
        {
            var pvm = new PeopleViewModel();
            var db = new PeopleDatabase(_connection);
            db.AddManyPeople(people);

            TempData["message"] = $"{people.Count} people have been added";

            return Redirect("/home/index");
        }

    }
}