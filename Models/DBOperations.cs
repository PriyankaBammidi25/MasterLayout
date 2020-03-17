using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MasterLayout.Models
{
    public class DBOperations
    {
        static DemoEntities1 D = new DemoEntities1();
        public static bool Check(string username, string password)
        {
            var E = from E1 in D.tbl_Login
                    where E1.username == username && E1.password == password
                    select E1;
            if (E.ToList().Count == 1)
                return true;
            else
                return false;
        }
        public static List<EMPDATA> GetAll()
        {
            var E1 = from E2 in D.EMPDATAs
                     select E2;
            return E1.ToList();
        }
        public static EMPDATA getEmp(int id)
        {
            var E1 = from E in D.EMPDATAs
                     where E.EMPNO == id
                     select E;
            return E1.First();
        }
        public static string GetUpdate(EMPDATA emp)
        {
            var U = from L in D.EMPDATAs
                    where L.EMPNO == emp.EMPNO
                    select L;
            foreach (var i in U)
            {
                i.JOB = emp.JOB;
                i.MGR = emp.MGR;
                i.SAL = emp.SAL;
                i.COMM = emp.COMM;
                i.DEPTNO = emp.DEPTNO;
            }
            D.SaveChanges();
            return "1 Row updated";
        }
        public static string DelEmp(int Empno)
        {
            var empno1 = from E in D.EMPDATAs
                         where E.EMPNO == Empno
                         select E;
            D.EMPDATAs.Remove(empno1.First());
            D.SaveChanges();
            return Empno + " Deleted";
        }
        public static string InsertEmp(EMPDATA E1)
        {
            try
            {
                D.EMPDATAs.Add(E1);
                D.SaveChanges();

            }
            catch (DbUpdateException E)
            {
                SqlException ex = E.GetBaseException() as SqlException;
                if (ex.Message.Contains("FK__Deptno"))
                {
                    return "No proper deptno";
                }
                else if (ex.Message.Contains("EMP_PK"))
                {
                    return "Empno should be unique";
                }
                else
                    return "Error occurred";
            }
            return "1 row inserted";
        }
    }
}