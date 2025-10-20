using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebBanLapTop.Models;

namespace WebBanLapTop.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Admin/Products
        DatabaseDataContext db = new DatabaseDataContext();
        public ActionResult Index(int ?page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var items = db.tb_products.OrderByDescending(x => x.product_id)
                                      .Skip((pageNumber-1)*pageSize)
                                      .Take(pageSize)
                                      .ToList();
            ViewBag.PageSize = pageSize;
            ViewBag.Page = pageNumber;

            return View(items);
        }
    }
}