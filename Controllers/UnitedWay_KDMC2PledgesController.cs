using PagedList;
using System;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using UWA.Models;

namespace UWA.Controllers
{
    public class UnitedWay_KDMC2PledgesController : Controller
    {
        private Pledge db = new Pledge();

        // GET: UnitedWay_KDMC2Pledges
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Fname_desc" : "";
            ViewBag.IDSortParm = String.IsNullOrEmpty(sortOrder) ? "EmpID_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var myPledges = from p in db.UnitedWay_KDMC2Pledges
                            where p.GotPrize == true &&
                            p.DonationYear.Equals("2017")
                            select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                myPledges = myPledges.Where(p => p.Lname.Contains(searchString)
                                       || p.Fname.Contains(searchString)
                                       || p.Fname.Equals(searchString)
                                       || p.Lname.Equals(searchString)
                                       || p.Lname.Contains(searchString)
                                       || p.EmpID.Contains(searchString)
                                       || p.EmpID.Equals(searchString));
            }

            switch (sortOrder)
            {
                case "Fname":
                    myPledges = myPledges.OrderByDescending(p => p.Fname);
                    break;
                case "Date":
                    myPledges = myPledges.OrderByDescending(p => p.DateEntered);
                    break;
                case "EmpID":
                    myPledges = myPledges.OrderByDescending(p => p.EmpID);
                    break;
                case "date_desc":
                    myPledges = myPledges.OrderByDescending(p => p.DateEntered);
                    break;
                default:
                    myPledges = myPledges.OrderBy(p => p.Fname);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(myPledges.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult AllPledges(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Lname_desc" : "";
            ViewBag.IDSortParm = String.IsNullOrEmpty(sortOrder) ? "EmpID_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var allPledges = from p in db.UnitedWay_KDMC2Pledges
                            where p.DonationYear.Equals("2017")
                                 select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                allPledges = allPledges.Where(p => p.Lname.Contains(searchString)
                                       || p.Fname.Contains(searchString)
                                       || p.Fname.Equals(searchString)
                                       || p.Lname.Equals(searchString)
                                       || p.Lname.Contains(searchString)
                                       || p.EmpID.Contains(searchString)
                                       || p.EmpID.Equals(searchString));
            }

            switch (sortOrder)
            {
                case "Lname":
                    allPledges = allPledges.OrderByDescending(p => p.Lname);
                    break;
                case "Date":
                    allPledges = allPledges.OrderByDescending(p => p.DateEntered);
                    break;
                case "EmpID":
                    allPledges = allPledges.OrderByDescending(p => p.EmpID);
                    break;
                case "date_desc":
                    allPledges = allPledges.OrderByDescending(p => p.DateEntered);
                    break;
                default:
                    allPledges = allPledges.OrderByDescending(p => p.Lname);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(allPledges.ToPagedList(pageNumber, pageSize));
        }

        // GET: UnitedWay_KDMC2Pledges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnitedWay_KDMC2Pledges unitedWay_KDMC2Pledges = db.UnitedWay_KDMC2Pledges.Find(id);
            if (unitedWay_KDMC2Pledges == null)
            {
                return HttpNotFound();
            }
            return View(unitedWay_KDMC2Pledges);
        }

        // GET: UnitedWay_KDMC2Pledges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnitedWay_KDMC2Pledges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,EmpID,Fname,Lname,Email,Position,Department,CostCenter,Manager,VP,DateEntered,FirstTime,ProcessLevel,PrizeCriteria,PayType,PerPay,PayPeriods,AnnualPayroll,GrandTotal,County,Agency,DonationYear,Logged,GotPrize")] UnitedWay_KDMC2Pledges unitedWay_KDMC2Pledges)
        {
            if (ModelState.IsValid)
            {
                db.UnitedWay_KDMC2Pledges.Add(unitedWay_KDMC2Pledges);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unitedWay_KDMC2Pledges);
        }

        // GET: UnitedWay_KDMC2Pledges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnitedWay_KDMC2Pledges unitedWay_KDMC2Pledges = db.UnitedWay_KDMC2Pledges.Find(id);
            if (unitedWay_KDMC2Pledges == null)
            {
                return HttpNotFound();
            }
            return View(unitedWay_KDMC2Pledges);
        }

        // POST: UnitedWay_KDMC2Pledges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,EmpID,Fname,Lname,Email,Position,Department,CostCenter,Manager,VP,DateEntered,FirstTime,ProcessLevel,PrizeCriteria,PayType,PerPay,PayPeriods,AnnualPayroll,GrandTotal,County,Agency,DonationYear,Logged,GotPrize")] UnitedWay_KDMC2Pledges unitedWay_KDMC2Pledges)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unitedWay_KDMC2Pledges).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unitedWay_KDMC2Pledges);
        }

        // GET: UnitedWay_KDMC2Pledges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnitedWay_KDMC2Pledges unitedWay_KDMC2Pledges = db.UnitedWay_KDMC2Pledges.Find(id);
            if (unitedWay_KDMC2Pledges == null)
            {
                return HttpNotFound();
            }
            return View(unitedWay_KDMC2Pledges);
        }

        // POST: UnitedWay_KDMC2Pledges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UnitedWay_KDMC2Pledges unitedWay_KDMC2Pledges = db.UnitedWay_KDMC2Pledges.Find(id);
            db.UnitedWay_KDMC2Pledges.Remove(unitedWay_KDMC2Pledges);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ExportToExcel()
        {
            // Step 1 - get the data from database
            var exp = from p in db.UnitedWay_KDMC2Pledges
                      where p.DonationYear.Equals("2017")
                      select p;

            var data = exp.ToList();

            // instantiate the GridView control from System.Web.UI.WebControls namespace
            // set the data source
            GridView gridview = new GridView();
            gridview.DataSource = data;
            gridview.DataBind();

            // Clear all the content from the current response
            Response.ClearContent();
            Response.Buffer = true;
            // set the header
            Response.AddHeader("content-disposition", "attachment;filename=UnitedWayExport.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            // create HtmlTextWriter object with StringWriter
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    // render the GridView to the HtmlTextWriter
                    gridview.RenderControl(htw);
                    // Output the GridView content saved into StringWriter
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
            return View();
        }

        public ActionResult Total()
        {
            var result = (from p in db.UnitedWay_KDMC2Pledges where "2017" == p.DonationYear select p).ToList();
            var model = (from p in result select decimal.Parse(p.GrandTotal)).Sum();

            ViewBag.data = model;

            var fFullModel = (from p in result where decimal.Parse(p.GrandTotal) > 259.00m 
                              select p.GrandTotal).Count() - 1;
            var fGivenModel = (from p in result where decimal.Parse(p.GrandTotal) > 259.00m && 
                                   p.GotPrize == false select p.GrandTotal).Count() - 1;
            ViewBag.fleeceOrdered = fFullModel;
            ViewBag.fleeceGiven = fGivenModel;

            var LSFullModel = (from p in result where decimal.Parse(p.GrandTotal) > 129.00m && 
                               decimal.Parse(p.GrandTotal) < 260.00m 
                               select p.GrandTotal).Count();
            var LSGivenModel = (from p in result where decimal.Parse(p.GrandTotal) > 129.00m && 
                                decimal.Parse(p.GrandTotal) < 260.00m && p.GotPrize == false 
                                select p.GrandTotal).Count();
            ViewBag.LSOrdered = LSFullModel;
            ViewBag.LSGiven = LSGivenModel;

            var SSFullModel = (from p in result where decimal.Parse(p.GrandTotal) > 24.00m && 
                               decimal.Parse(p.GrandTotal) < 130.00m 
                               select p.GrandTotal).Count();
            var SSGivenModel = (from p in result
                                where decimal.Parse(p.GrandTotal) > 24.00m && 
                                decimal.Parse(p.GrandTotal) < 130.00m && p.GotPrize == false
                                select p.GrandTotal).Count();
            ViewBag.SSOrdered = SSFullModel;
            ViewBag.SSGiven = SSGivenModel;

            var AltogetherModel = (from p in result
                               where decimal.Parse(p.GrandTotal) >= 1.00m select p.GrandTotal).Count();
            ViewBag.TotalDonations = AltogetherModel;

            return View();
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
