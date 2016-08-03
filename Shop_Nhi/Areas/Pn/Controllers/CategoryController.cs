using Shop_Nhi.Models.DAO;
using Shop_Nhi.Models.Framework;
using Shop_Nhi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_Nhi.Areas.Pn.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Thuankay/Category
        public ActionResult Index()
        {
            var dao = new CategoryDAO();
            return View(dao.ListAll());
        }

        // GET: Thuankay/Category/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: Thuankay/Category/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Thuankay/Category/Create
        [HttpPost]
        public ActionResult Create(Category cate)
        {
            try
            {
                var dao = new CategoryDAO();
                cate.createDate = DateTime.Now;
                cate.createByID = (string)Session["username"];
                cate.status = true;
                cate.showOnHome = false;
                string metaTitle = LocDau.convertToUnSign3(cate.name.Replace(" ", "-"));
                cate.metatTitle = XoaKyTu.RemoveSpecialChars(metaTitle);
                dao.Create(cate);
                SetAlert("Thông báo! Thêm danh mục thành công", "success");
                return RedirectToAction("Index");
            }
            catch
            {
                SetAlert("Thông báo! Thêm danh mục thất bại", "danger");
                return View();
            }
        }

        // GET: Thuankay/Category/Edit/5
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new CategoryDAO().GetByID(id);
            return View(dao);
        }

        // POST: Thuankay/Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category cate)
        {
            try
            {
                var dao = new CategoryDAO();
                string metaTitle = LocDau.convertToUnSign3(cate.name.Replace(" ", "-"));
                cate.metatTitle = XoaKyTu.RemoveSpecialChars(metaTitle);
                cate.modifiedByID = (string)Session["username"];
                var result = dao.Edit(cate);
                if (result)
                {
                    SetAlert("Thông báo! Sửa danh mục thành công", "success");
                    return RedirectToAction("Index");
                }
                else
                {
                    SetAlert("Thông báo! Sửa danh mục thất bại", "error");
                    return View();
                }

            }
            catch
            {
                SetAlert("Thông báo! Sửa danh mục thất bại", "error");
                return View();
            }
        }


        [HttpPost]
        public JsonResult Delete(long id)
        {
            var result = new CategoryDAO().Delete(id);
            return Json(new
            {
                status = result
            });
        }

        //Change Status
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new CategoryDAO().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }

        //Show Home
        [HttpPost]
        public JsonResult ShowHome(long id)
        {
            var result = new CategoryDAO().ChangeShowHome(id);
            return Json(new
            {
                status = result
            });
        }

        //set Parent
        public void setCategory(long? selectedId = null)
        {
            var dao = new CategoryDAO();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "name", selectedId);
        }
    }
}
