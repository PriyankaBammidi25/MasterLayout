using MasterLayout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterLayout.Controllers
{
    public class BindingExController : Controller
    {
        // GET: BindingEx
        [ActionName("Example")]
        public ActionResult Sample()
        {
            return View("Sample");
        }
        public ActionResult Index()
        {
            return View();
        }
        //Primitive binding-1
        public ActionResult Update(int id)
        {
            return View("Index", DBOperations.getEmp(id));
        }
        //Binding complex type-2
        //[HttpPost]
        //public ActionResult Update(EMPDATA E)
        //{
        //    return View();
        //}
        //Not preferred
        //[HttpPost]
        //public ActionResult Update(int EMPNO,string ENAME,string JOB,int MGR,DateTime HIREDATE,int SAL,int COMM,int DEPTNO)
        //{
        //    return View();
        //}
        //FormCollectiions-not preferred
        //[HttpPost]
        //public ActionResult Update(FormCollection F)
        //{
        //    //int eno = int.Parse(F["EMPNO"]);
        //    string ename = F["ENAME"];
        //    string job = F["JOB"];

        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Update([Bind(Include="ENAME,JOB")]EMPDATA E)
        //{
        //    return View();
        //}
        [HttpPost]
        public ActionResult Update([Bind(Exclude = "ENAME,JOB")]EMPDATA E)
        {
            return View();
        }
    }
}