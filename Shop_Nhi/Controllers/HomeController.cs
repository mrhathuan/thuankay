using Shop_Nhi.Models;
using Shop_Nhi.Models.DAO;
using Shop_Nhi.Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_Nhi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var dao = new ProductDAO();
            ViewBag.ListByStatusFalse = dao.ListByStatusFalse();
            ViewBag.ListByStatusTrue = dao.ListByStatusTrue();
            ViewBag.ListNew = dao.ListNewPro(9);
            ViewBag.Hot = dao.ListViewcount(9);
            ViewBag.ListSale = dao.ListSale(9);
            return View();
        }

        //Set like
        [HttpPost]
        public JsonResult SetLike(long id)
        {
            var dao = new ProductDAO();
            dao.SetLike(id);
            return Json(new
            {
                status = true
            });
        }
        //Get id
        [HttpPost]
        public JsonResult GetProduct(long id)
        {
            try
            {
                var dao = new ProductDAO();
                var product = new Product();
                var category = new Category();
                var data = dao.GetById(id);
                decimal? price = 0;
                if (data.promotionPrice != null)
                {
                    price = data.promotionPrice;
                }
                else
                {
                    price = data.price;
                }
                product.ID = data.ID;
                product.metatTitle = data.metatTitle;
                product.productName = data.productName;                                
                product.price = price;
                product.quantity = data.quantity;
                product.description = data.description;
                product.image = data.image;

                category.name = data.Category.name;
                category.ID = data.Category.ID;
                category.metatTitle = data.Category.metatTitle;
                return Json(new
                {
                    status = true,
                    product,
                    category
                });
            }
            catch
            {
                return Json(new
                {
                    status = false
                });
            }
        }
        public ActionResult _Header()
        {
            var cart = Session["CartSession"];
            var cartItem = new List<CartItem>();
            if (cart != null)
            {
                cartItem = (List<CartItem>)cart;
            }
            return PartialView(cartItem);
        }

        public ActionResult _Menu()
        {
            var dao = new CategoryDAO();
            return PartialView(dao.ListByShowhome());
        }

        public ActionResult _Slide()
        {
            return PartialView();
        }

        public ActionResult _Suport()
        {
            return PartialView();
        }

        public ActionResult _LoginModel()
        {
            return PartialView();
        }


        public ActionResult _Category()
        {
            var dao = new CategoryDAO();
            ViewBag.CatePro = dao.ListByStatus();
            return PartialView();
        }

        
    }
}