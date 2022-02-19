using Products.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Products.Controllers
{
    public class ProdController : Controller
    {
        // GET: Prod
        public ActionResult Index()
        {

            List<MyProductList> list = new List<MyProductList>();

            SqlConnection ab = new SqlConnection();

            ab.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True";
            ab.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ab;
            cmd.CommandType = System.Data.CommandType.Text;
           // cmd.CommandText = "select * from Products";

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new MyProductList
                    {
                        ProductId = (int)dr["ProductId"],
                        ProductName = (string)dr["ProductName"].ToString(),
                        Rate = (decimal)dr["Rate"],
                        Description = (string)dr["Description"],
                        CategoryName = (string)dr["CategoryName"]
                    });

                }

                dr.Close();
            }

            catch(Exception ex)
            {
                ViewBag.Error = ex;

            }

            finally
            {
                ab.Close();
            }

            return View(list);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Prod/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product obj)
        {
            SqlConnection ab = new SqlConnection();
            ab.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True";
            ab.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ab;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update Products set ProductName=@ProductName, Rate=@Rate, Description=@Description, CategoryName=@CategoryName where ProductId=@ProductId";

            cmd.Parameters.AddWithValue("ProductId", id);
            cmd.Parameters.AddWithValue("ProductName", obj.ProductName);
            cmd.Parameters.AddWithValue("Rate", obj.Rate);
            cmd.Parameters.AddWithValue("Description", obj.Description);
            cmd.Parameters.AddWithValue("CategoryName", obj.CategoryName);

            try
            {
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex;

            }

            finally
            {
                ab.Close();
            }
            return View();
        }

        // POST: Prod/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Prod/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Prod/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
