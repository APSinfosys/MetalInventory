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
            var data = repo.getAllBanks(); 
            return View(data);
        }


        public PartialViewResult Add()
        {
            return PartialView("Add", new InventoryRepository.Masters.BankAccMasterModel());
        }

        [HttpPost]
        public ActionResult Create(BankAccMasterModel bnk)
        {
            int Result = repo.CreateBank(bnk);
            if(Result>0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public JsonResult Edit(int id)
        {
            var result = JsonConvert.SerializeObject( repo.getBank(id));

        
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(int id,string BankName)
        {
            int Id = id;
            string BN = BankName;

            BankAccMasterModel bnk = new BankAccMasterModel();
            bnk.BankName = BN;
            bool Result = repo.EditBank(Id, bnk);
            if (Result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
            //return View();
        }

    }
}