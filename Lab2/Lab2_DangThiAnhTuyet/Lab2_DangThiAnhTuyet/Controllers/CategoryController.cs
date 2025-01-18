using Lab2_DangThiAnhTuyet.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab2_DangThiAnhTuyet.Controllers
{
    public class CategoryController : Controller
    {
        public static List<Category> _categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    CategoryName = "Laptop",
                    Description = "Laptop",
                    CategoryImage = "/images/laptop.jpg"

                },
                new Category
                {
                    Id = 2,
                    CategoryName = "Smartphone",
                    Description = "Smartphone",
                    CategoryImage = "/images/Smartphone.jpg"
                },
                new Category
                {
                    Id = 3,
                    CategoryName = "Tablet",
                    Description = "Tablet",
                    CategoryImage = "/images/Tablet.jpg"
                },
                new Category
                {
                    Id = 4,
                    CategoryName = "Smartwatch",
                    Description = "Smartwatch",
                    CategoryImage = "/images/Smartwatch.jpg"
                },
                new Category
                {
                    Id = 5,
                    CategoryName = "Desktop",
                    Description = "Desktop",
                    CategoryImage = "/images/Desktop.jpg"
                },
                new Category
                {
                    Id = 6,
                    CategoryName = "Camera",
                    Description = "Camera",
                    CategoryImage = "/images/Camera.jpg"
                }
            };
        public IActionResult Index()
        {
            Console.WriteLine(_categories == null ? "Categories is null" : "Categories is initialized");

            return View(_categories);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(int id, string CategoryName, string Description, IFormFile CategoryImage)
        {
            var existingCategory = _categories.FirstOrDefault(c => c.Id == id);

            if (existingCategory == null)
            {
                return NotFound();
            }

            existingCategory.CategoryName = CategoryName;
            existingCategory.Description = Description;

            if (CategoryImage != null && CategoryImage.Length > 0)
            {
                if (!string.IsNullOrEmpty(existingCategory.CategoryImage))
                {
                    var oldCoverPath = Path.Combine("wwwroot", existingCategory.CategoryImage.TrimStart('/'));
                    if (System.IO.File.Exists(oldCoverPath))
                    {
                        System.IO.File.Delete(oldCoverPath);
                    }
                }
                var fileName = Path.GetFileName(CategoryImage.FileName);
                var filePath = Path.Combine("wwwroot", "images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    CategoryImage.CopyTo(stream);
                }
                existingCategory.CategoryImage = "/images/" + fileName; 
            }

            return RedirectToAction("Index", "Category");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var selectedCategory = _categories.FirstOrDefault(b => b.Id == id);
            if (selectedCategory == null)
            {
                return NotFound(); 
            }

            if (!string.IsNullOrEmpty(selectedCategory.CategoryImage))
            {
                var coverPath = Path.Combine("wwwroot", selectedCategory.CategoryImage.TrimStart('/'));
                if (System.IO.File.Exists(coverPath))
                {
                    System.IO.File.Delete(coverPath);
                }
            }

            _categories.Remove(selectedCategory);

            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        public IActionResult Create()
        {
            var category = new Category();
            return View(category);
        }


        [HttpPost]
        public IActionResult Create(string CategoryName, string Description, IFormFile CategoryImage)
        {
            var category = new Category
            {
                Id = _categories.Count + 1,
                CategoryName = CategoryName,
                Description = Description
            };
            if (CategoryImage != null && CategoryImage.Length > 0)
            {
                var fileName = Path.GetFileName(CategoryImage.FileName);
                var filePath = Path.Combine("wwwroot", "images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    CategoryImage.CopyTo(stream);
                }
                category.CategoryImage = "/images/" + fileName;
            }
            _categories.Add(category);
            return RedirectToAction("Index", "Category");
        }

    }
}
