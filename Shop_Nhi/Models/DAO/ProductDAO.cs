using Shop_Nhi.Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_Nhi.Models.DAO
{
    public class ProductDAO
    {
        private DBConnect db = null;

        public ProductDAO()
        {
            db = new DBConnect();
        }

        //Thêm sản phẩm
        public void Create(Product pro)
        {
            db.Products.Add(pro);
            db.SaveChanges();
        }

        public List<Product> ListAll()
        {
            return db.Products.OrderByDescending(x => x.createDate).ToList();
        }

        //danh sách mới
        public List<Product> ListNewPro(int top)
        {

            return db.Products.Where(x => x.status == true).OrderByDescending(x => x.createDate).Take(top).ToList();
        }

        //ProductCategory
        public List<Product> ProductCategory(long cateId, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            var query = (from c in db.Categories where c.ID == cateId select c.ID).Union(
                     from c1 in db.Categories
                     join
                         c2 in db.Categories on c1.parentID.Value equals c2.ID
                     where c2.ID == cateId
                     select c1.ID
                 ).ToList();
            var listProduct = from p in db.Products where (query.Contains(p.categoryID.Value) && p.status == true) select p;
            totalRecord = listProduct.Count();
            return listProduct.OrderByDescending(x => x.createDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        //Search
        public List<Product> ListSearch(string keywords, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Products.Where(x => x.status == true && (x.code == keywords || x.productName == keywords)).Count();
            return db.Products.Where(x => x.status == true && (x.code == keywords || x.productName == keywords)).OrderByDescending(x => x.createDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        ////Danh mục cha
        //public List<Product> ListProductCategory(long cateId, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        //{
        //    //SELECT*
        //    //    FROM Product
        //    //    WHERE categoryID in (
        //    //      SELECT ID
        //    //      FROM Category
        //    //      WHERE ID = 12
        //    //      UNION
        //    //      SELECT c.ID
        //    //      FROM Category c
        //    //      JOIN Category c2 ON c2.ID = c.parentID
        //    //      WHERE c2.ID = 12
        //    //        )   
        //    var products = from p in db.Products
        //                   join c in db.Categories on p.categoryID equals c.ID into cateGroup
        //                   from cate in cateGroup.DefaultIfEmpty()
        //                   join
        //                    c1 in db.Categories on cate.parentID.Value equals c1.ID
        //                                               where
        //                    cate.ID == cateId || c1.ID == cateId
        //                                               select p;
        //                   ;   
        //    var query = (from c in db.Categories where c.ID == cateId select c.ID).Union(
        //            from c1 in db.Categories
        //            join
        //                c2 in db.Categories on c1.parentID.Value equals c2.ID
        //                                    where c2.ID == cateId
        //                                    select c1.ID
        //        ).ToList();
        //    var listProduct = from p in db.Products where (query.Contains(p.categoryID.Value) && p.status == true) select p;
        //    totalRecord = listProduct.Count();
        //    return listProduct.OrderByDescending(x => x.createDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        //}

        //List All status = true
        public List<Product> ListAllTrue(ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Products.Where(x => x.status == true).Count();
            return db.Products.Where(x => x.status == true).OrderByDescending(x => x.createDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        //Sale
        public List<Product> ListSale(int top)
        {
            return db.Products.Where(x => x.promotionPrice != null && x.status == true).OrderByDescending(x => x.createDate).Take(top).ToList();
        }

        //Sửa
        public bool Edit(Product pro)
        {
            var result = db.Products.Find(pro.ID);
            try
            {
                result.code = pro.code;
                result.productName = pro.productName;
                result.price = pro.price;
                result.image = pro.image;
                result.promotionPrice = pro.promotionPrice;
                result.quantity = pro.quantity;
                result.metatTitle = pro.metatTitle;
                result.metaKeywords = pro.metaKeywords;
                result.metaDescription = pro.metaDescription;
                result.chatlieu = pro.chatlieu;
                result.madeIn = pro.madeIn;
                result.detail = pro.detail;
                result.modifiedByID = pro.modifiedByID;
                result.modifiedByDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        //Xóa
        public bool Delete(long id)
        {
            try
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Find id
        public Product GetById(long id)
        {
            return db.Products.Find(id);
        }

        //Sản phẩm cùng loại
        public List<Product> ListRelateProduct(long productId, int show)
        {
            var product = db.Products.Find(productId);
            return db.Products.Where(x =>x.status == true && x.categoryID == product.categoryID && x.ID != productId).OrderByDescending(x=>x.modifiedByDate).Take(show).ToList();
        }

        //change status
        public bool ChangeStatus(long id)
        {
            var result = db.Products.Find(id);
            result.status = !result.status;
            db.SaveChanges();
            return result.status;
        }
        //Sản phẩm xem nhiều
        public List<Product> ListViewcount(int show)
        {
            return db.Products.Where(x=>x.status == true).OrderByDescending(x => x.viewCount).Take(show).ToList();
        }

        //Hàng sắp về
        public List<Product> ListByStatusFalse()
        {
            return db.Products.Where(x => x.status == false).OrderByDescending(x => x.createDate).ToList();
        }

        //Hàng đã về
        public List<Product> ListByStatusTrue()
        {
            return db.Products.Where(x => x.status == true).OrderByDescending(x => x.createDate).ToList();
        }

        //Set lượt xem
        public void SetViewcount(Product pro)
        {
            var result = db.Products.Find(pro.ID);
            result.viewCount = pro.viewCount + 1;
            db.SaveChanges();
        }

        //Set like
        public void SetLike(long id)
        {
            var result = db.Products.Find(id);
            result.viewCount = result.viewCount + 1;
            db.SaveChanges();
        }

        //Thêm ảnh
        public void UpdateImages(long id, string images)
        {
            var result = db.Products.Find(id);
            result.moreImages = images;
            db.SaveChanges();
        }
    }   
}