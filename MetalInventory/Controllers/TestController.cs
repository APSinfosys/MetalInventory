using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryDal.DBOprations.Masters;
using InventoryRepository.Masters;

namespace MetalInventory.Controllers
{
    [AllowAnonymous]
    public class TestController : Controller
    {

        Master_BankMaster_Repository repo = null;

        public TestController()
        {
            repo = new Master_BankMaster_Repository();
        }

        public ActionResult Index()
        {
            var data = repo.getAllBanks();
            return View(data);
        }

        public ActionResult BankIndex()
        {
            return View();
        }

        public JsonResult List()
        {
            var data = repo.getAllBanks();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(BankAccMasterModel bnk)
        {
            return Json(repo.CreateBank(bnk), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var bank = repo.getBank(ID);// empDB.ListAll().Find(x => x.EmployeeID.Equals(ID));
            return Json(bank, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(BankAccMasterModel bnk)
        {
            return Json(repo.EditBank(bnk), JsonRequestBehavior.AllowGet);
        }
        //public JsonResult Delete(int ID)
        //{
        //    return Json(empDB.Delete(ID), JsonRequestBehavior.AllowGet);
        //}



    }
}