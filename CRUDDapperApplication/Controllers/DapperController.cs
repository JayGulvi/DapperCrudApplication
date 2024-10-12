using CRUDDapperApplication.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace CRUDDapperApplication.Controllers
{
    public class DapperController : Controller
    {
        private readonly SqlConnection conn; 
        public DapperController()
        {
            conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DapperApp;Integrated Security=True;Encrypt=True");
        }
        public IActionResult Index()
        {
            conn.Open();
            string query = "SELECT * FROM Product";
            var data = conn.Query<Products>(query).ToList();
            conn.Close();

            return View(data);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Products p)
        {
            if (ModelState.IsValid)
            {
                conn.Open();
                string query = "INSERT INTO Product (Pname, Description, Price, CreatedDate) VALUES (@Pname, @Description, @Price, @CreatedDate)";
                var result = conn.Execute(query, new { Pname = p.Pname, Description = p.Description, Price = p.Price, CreatedDate = DateTime.Now });
                conn.Close();

                if (result > 0)
                {
                    TempData["Message"] = "Product added successfully!";
                }
                else
                {
                    TempData["Message"] = "Error while adding the product!";
                }

                return RedirectToAction("Index");
            }
            return View(p);
        }

        public IActionResult EditProduct(int id)
        {
            conn.Open();
            string query = "SELECT * FROM Product WHERE PId = @PId";
            var product = conn.QuerySingleOrDefault<Products>(query, new { PId = id });
            conn.Close();

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Products p)
        {
            if (ModelState.IsValid)
            {
                conn.Open();
                string query = "UPDATE Product SET Pname = @Pname, Description = @Description, Price = @Price WHERE PId = @PId";
                var result = conn.Execute(query, new { PId = p.PId, Pname = p.Pname, Description = p.Description, Price = p.Price });
                conn.Close();

                if (result > 0)
                {
                    TempData["Message"] = "Product updated successfully!";
                }
                else
                {
                    TempData["Message"] = "Error while updating the product!";
                }

                return RedirectToAction("Index");
            }

            return View(p);
        }


        public IActionResult DeleteProduct(int id)
        {
            conn.Open();
            string query = "DELETE FROM Product WHERE PId = @PId";
            var result = conn.Execute(query, new { PId = id });
            conn.Close();

            if (result > 0)
            {
                TempData["DMessage"] = "Product deleted successfully!";
            }
            else
            {
                TempData["DMessage"] = "Error while deleting the product!";
            }

            return RedirectToAction("Index");
        }
    }
}
