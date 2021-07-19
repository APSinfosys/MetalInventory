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

        public PartialViewResult Create()
        {
            return PartialView("Create", new InventoryRepository.Masters.BankAccMasterModel());
        }

        [HttpPost]
        public ActionResult Create(BankAccMasterModel bnk)
        {
            int result = repo.CreateBank(bnk);
            return View("Index");
        }

        public PartialViewResult Edit(int id)
        {
            var result = repo.getBank(id);
            return PartialView("Edit", result);
        }


    }
}