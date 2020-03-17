using MasterLayout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MasterLayout.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
        public ActionResult Index()
        {
            List<EMPDATA> L = DBOperations.GetAll();
            return View(L);
        }
        public ActionResult Create(EMPDATA E)
        {
            ViewBag.message = DBOperations.InsertEmp(E);
            return View();
        }
        public ActionResult Edit(int id)
        {
            EMPDATA E = DBOperations.getEmp(id);
            return View(E);
        }
        public ActionResult GetEmp(EMPDATA E1)
        {
            string E = DBOperations.GetUpdate(E1);
            ViewBag.S = E;
            return View();
        }
        //public ActionResult Delete(int? id)
        //{
        //    if(id==null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    string E = DBOperations.DelEmp(id);
        //    if(E==null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(E);
        //                //ViewBag.S = E;
        //    //return View();
        //}
        //[HttpPost,ActionName("DeleteEmp")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirm(int id)
        //{
        //    string E = DBOperations.DelEmp(id);
        //    DBOperations.
        //}
        public ActionResult Delete(int id)
        {
            string E = DBOperations.DelEmp(id);
            ViewBag.S = E;
            return View();
           
        }
       
    }
}