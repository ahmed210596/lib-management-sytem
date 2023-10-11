using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestProject.Models;
using TestProject.Repository.Base;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace TestProject.Controllers
{ 
    [Authorize(Roles=ClsRoles.RoleAdmin)]
    public class CategoryController : Controller
    {
        public CategoryController( IunitOfwork myunit, IHostingEnvironment host)
        {
            this.myunit = myunit;
            _hostingEnvironment = host;

        }

        // private IRepository<Category> _repository;
        private readonly IHostingEnvironment _hostingEnvironment;
        private IunitOfwork myunit;
        //public IActionResult Index()
        //{
        //    return View(_repository.FindAll());
        //}

        public   IActionResult Index()
        {
            // var oneCat = myunit.categories.SelectOne(x => x.name == "Computers");
            // Console.WriteLine(oneCat);

            // var allCat = await myunit.categories.FindAllAsync("Items");
            var allCat =  myunit.categories.FindAll("Items");


            return View(allCat);
        }


        //GET
        public IActionResult New()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Category category)
        {
            if (ModelState.IsValid)

            {
                if (category.clientFile != null && category.clientFile.Length > 0)
                {
                  

                   
                    MemoryStream stream = new MemoryStream();
                    category.clientFile.CopyTo(stream);
                    category.dbImage = stream.ToArray();

                    // Set the item's image path to the saved file's path or store it in the database as needed.
                    //  category.imagepath = "/images/" + category.clientFile.FileName; // Assuming your Items model has a property for the image path.
                }
                myunit.categories.addone(category);

                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        //GET
        public IActionResult Edit(int? Id)
        {

            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var category = myunit.categories.FindById(Id.Value);
            if (category == null)
            {
                return NotFound();
            }
            
            return View(category);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                myunit.categories.updateone(category);
                TempData["successData"] = "item has been edited succesfull";
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        //GET
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var category = myunit.categories.FindById(Id.Value);
            if (category== null)
            {
                return NotFound();
            }
            
            return View(category);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {
            myunit.categories.deleteone(category);
            TempData["successData"] = "Item has been deleted successfully";
            return RedirectToAction("Index");
        }
    }
}