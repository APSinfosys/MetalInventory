using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MetalInventory.Controllers.Masters
{
    
    public class ProductCategoryController : Controller
    {
        // GET: ProductCatehory
        //To access using role thn use 
        //[Authorize(Roles = "ADMIN,EMPLOYEE,ACCOUNTANT,USER")]
        public ActionResult Index()
        {
            return View();
        }
    }
}