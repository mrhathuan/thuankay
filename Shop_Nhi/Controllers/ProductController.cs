using Shop_Nhi.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Shop_Nhi.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        //ProductCategory
        public ActionResult ProductCategory(long cateId, int page = 1, int pageSize = 24)
        {
            var dao = new ProductDAO();
            int totalRecord = 0;
            var model = dao.ProductCategory(cateId, ref totalRecord, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)((double)totalRecord / (double)pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;


            ViewBag.Category = new CategoryDAO().GetByID(cateId);

            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }

        //by price
        public ActionResult SortByPrice(long cateId, int page = 1, int pageSize = 24)
        {
            var dao = new ProductDAO();
            int totalRecord = 0;
            var model = dao.SortByPrice(cateId, ref totalRecord, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)((double)totalRecord / (double)pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;


            ViewBag.Category = new CategoryDAO().GetByID(cateId);

            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }


        //ListAll
        public ActionResult ListAll(int page = 1, int pageSize = 50)
        {
            var dao = new ProductDAO();
            int totalRecord = 0;
            var model = dao.ListAllTrue(ref totalRecord, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)((double)totalRecord / (double)pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;



            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }

        //Search
        [HttpGet]
        public ActionResult Search(string keywords, int page = 1, int pageSize = 50)
        {
            var dao = new ProductDAO();
            int totalRecord = 0;
            var model = dao.ListSearch(keywords, ref totalRecord, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)((double)totalRecord / (double)pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;

            ViewBag.Search = keywords;

            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }

        // GET: Product/Details/5
        public ActionResult Details(long id)
        {
            try
            {
                var dao = new ProductDAO();
                var images = dao.GetById(id).moreImages;
                ViewBag.ListImages = null;
                if (!string.IsNullOrEmpty(images))
                {
                    XElement xImages = XElement.Parse(images);
                    List<string> listImages = new List<string>();
                    foreach (XElement element in xImages.Elements())
                    {
                        listImages.Add(element.Value);
                    }
                    ViewBag.ListImages = listImages;
                }
                ViewBag.RelateProduct = dao.ListRelateProduct(id, 20);
                return View(dao.GetById(id));
            }
            catch
            {
                return Redirect("/");
            }
        }

       
        //
    }
}
