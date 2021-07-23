using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryRepository.Masters;
using InventoryDal.DBOprations.Masters;
using Newtonsoft.Json;
namespace MetalInventory.Controllers.Masters
{

    public class BankController : Controller
    {
        Master_BankMaster_Repository repo = null; 

        public BankController()
        {
            repo = new Master_BankMaster_Repository();
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List(int currentPage = 1, int pageSize = 10)
        {
            var Bdata = repo.getAllBanks();
            var result1 = Bdata.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return Json(new { totalPage = Math.Ceiling(1.0 * Bdata.Count() / pageSize), Data = result1 }, JsonRequestBehavior.AllowGet);
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

        public JsonResult Delete(int ID)
        {
            return Json("Testing");
            //return Json(repo.Delete(ID), JsonRequestBehavior.AllowGet);
        }




    }
}