using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using TestProject.Data;
using TestProject.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace TestProject.Controllers
{
    [Authorize(Roles = ClsRoles.RoleAdmin)]
    public class ItemsController : Controller
    {
        private readonly AppDbContext _db;
        public ItemsController(AppDbContext db, IHostingEnvironment host)
        {
            _db = db;
            _hostingEnvironment= host;
        }
        private readonly IHostingEnvironment _hostingEnvironment;    
        public IActionResult Index()
        {
            IEnumerable<Items> items = _db.Items.Include(c => c.Category).ToList();
            return View(items);
        }
        public IActionResult New()
        {
            createSelectList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult New(Items item)
        {
            if (item.clientFile != null && item.clientFile.Length > 0)
            {
                // Check if a file was uploaded

                // You can process the image here, such as saving it to a file or storing it in the database.
                // For demonstration purposes, let's assume you save it to a file in a "wwwroot/images" folder.

                var fileName = Path.Combine(_hostingEnvironment.WebRootPath, "images", item.clientFile.FileName);

                using (var stream = new FileStream(fileName, FileMode.Create))
                {
                    item.clientFile.CopyTo(stream);
                }

                // Set the item's image path to the saved file's path or store it in the database as needed.
                item.imagepath = "/images/" + item.clientFile.FileName; // Assuming your Items model has a property for the image path.
            }

            // Add the rest of your code for saving the item to the database, setting TempData, and redirecting.

            _db.Items.Add(item);
            _db.SaveChanges();
            TempData["successData"] = "Item has been added successfully";
            return RedirectToAction("Index");
        }


        public void createSelectList(int selectId = 1)
        {
            List<Category> categories = _db.Categories.ToList();
            SelectList listItems = new SelectList(categories, "Id", "name", selectId);
            ViewBag.CategoryList = listItems;
            
        }
        public IActionResult Edit(int? Id)
        {
            if(Id==null||Id==0)
                    {
                return NotFound();
            }
            var item = _db.Items.Find(Id);
            if(item==null)
                {
                return NotFound();
            }
            createSelectList(item.CategoryId);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Items item)
        {
            if (item.clientFile != null && item.clientFile.Length > 0)
            {
                // Check if a file was uploaded

                // You can process the image here, such as saving it to a file or storing it in the database.
                // For demonstration purposes, let's assume you save it to a file in a "wwwroot/images" folder.

                var fileName = Path.Combine(_hostingEnvironment.WebRootPath, "images", item.clientFile.FileName);

                using (var stream = new FileStream(fileName, FileMode.Create))
                {
                    item.clientFile.CopyTo(stream);
                }

                // Set the item's image path to the saved file's path or store it in the database as needed.
                item.imagepath = "/images/" + item.clientFile.FileName; // Assuming your Items model has a property for the image path.
            }
            _db.Items.Update(item);
            _db.SaveChanges();
            TempData["successData"] = "item has been edited succesfull";
            return RedirectToAction("Index");
        }
        public IActionResult Delete (int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var item = _db.Items.Find(Id);
            if (item == null)
            {
                return NotFound();
            }
            createSelectList(item.CategoryId);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(int id)
        {
            var item = _db.Items.Find(id);
            if (item == null)
            {
                TempData["errorData"] = "error";
                return NotFound();
            }
            _db.Remove(item);
            _db.SaveChanges();
            TempData["successData"] = "item has been deleled succesfull";
            return RedirectToAction("Index");
        }

    }
}
