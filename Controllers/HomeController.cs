using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EAD_Assignment3.Models;

namespace EAD_Assignment3.Controllers
{
    public class HomeController : Controller
    {
        donorDataContext dc = new donorDataContext();

        public ActionResult Index()
        {
            return View(dc.donorInfos.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Add()
        {
            string name = Request["name"];
            int contact = int.Parse(Request["contact"]);
            string bloodGroup = Request["bloodGroup"];

            donorInfo obj = new donorInfo();
            obj.Name = name;
            obj.Contact = contact;
            obj.BloodGroup = bloodGroup;

            dc.donorInfos.InsertOnSubmit(obj);
            dc.SubmitChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(dc.donorInfos.First(c=>c.Id == id));
        }

        public ActionResult EditDone(int id)
        {
            var a = dc.donorInfos.First(x => x.Id == id);
            a.Contact = int.Parse(Request["contact"]);
            dc.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}