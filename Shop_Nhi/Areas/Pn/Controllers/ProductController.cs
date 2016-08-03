using Shop_Nhi.Models.DAO;
using Shop_Nhi.Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop_Nhi.Common;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace Shop_Nhi.Areas.Pn.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Thuankay/Product
        public ActionResult Index()
        {
            var dao = new ProductDAO();
            return View(dao.ListAll());
        }

        //
        [HttpGet]
        public ActionResult Create()
        {
            setCategory();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product pro)
        {
            try
            {
                var dao = new ProductDAO();
                pro.status = true;
                pro.createDate = DateTime.Now;
                pro.createByID = (string)Session["username"];
                string metaTitle = LocDau.convertToUnSign3(pro.productName.Replace(" ", "-"));
                pro.metatTitle = XoaKyTu.RemoveSpecialChars(metaTitle);
                dao.Create(pro);
                SetAlert("Thông báo! Thêm sản phẩm thành công.", "success");
                return RedirectToAction("Index", "Product");
            }
            catch
            {
                SetAlert("Thông báo! Thêm sản phẩm thất bại.", "error");
                setCategory();
                return View();
            }
        }

        /// <summary>
        /// Sửa
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new ProductDAO();
            setCategory(dao.GetById(id).categoryID);
            return View(dao.GetById(id));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Product pro)
        {
            try
            {
                var dao = new ProductDAO();
                pro.modifiedByID = (string)Session["username"];
                string metaTitle = LocDau.convertToUnSign3(pro.productName.Replace(" ", "-"));
                pro.metatTitle = XoaKyTu.RemoveSpecialChars(metaTitle);
                var result = dao.Edit(pro);
                if (result)
                {
                    SetAlert("Thông báo! Sửa sản phẩm thành công.", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    SetAlert("Thông báo! Sửa sản phẩm thất bại.", "error");
                    return View();
                }
            }
            catch (Exception)
            {
                setCategory(pro.categoryID);
                return View();
            }
        }
        //Xóa
        [HttpPost]
        public JsonResult Delete(long id)
        {
            var result = new ProductDAO().Delete(id);
            return Json(new
            {
                status = result
            });
        }

        //Change status
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new ProductDAO().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }

        //Quản lý ảnh
        public JsonResult SaveImages(long id, string images)
        {
            JavaScriptSerializer seriaLizer = new JavaScriptSerializer();
            var listImages = seriaLizer.Deserialize<List<string>>(images);
            XElement xElement = new XElement("Images");
            foreach (var item in listImages)
            {
                //var subtringItem = item.Substring(22);
                //cho zuryshop.net
                var subtringItem = item.Substring(27);
                xElement.Add(new XElement("Image", subtringItem));
            }
            ProductDAO dao = new ProductDAO();
            try
            {
                dao.UpdateImages(id, xElement.ToString());
                return Json(new
                {
                    status = true
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    status = false
                });
            }

        }

        //Load ảnh
        public JsonResult LoadImages(long id)
        {
            ProductDAO dao = new ProductDAO();
            var images = dao.GetById(id).moreImages;
            try
            {
                XElement xImages = XElement.Parse(images);
                List<string> listImages = new List<string>();
                foreach (XElement element in xImages.Elements())
                {
                    listImages.Add(element.Value);
                }
                return Json(new
                {
                    status = true,
                    data = listImages
                }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new
                {
                    status = false
                }, JsonRequestBehavior.AllowGet);
            }
        }

        //Set danh muc
        public void setCategory(long? selectedId = null)
        {
            var dao = new CategoryDAO();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "name", selectedId);
        }
    }
}