using Lab2_DangThiAnhTuyet.Enums;
using Lab2_DangThiAnhTuyet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab2_DangThiAnhTuyet.Controllers
{
    public class DeviceController : Controller
    {
        private static List<Device> _devices = new List<Device>
            {
                new Device {
                    Id = 1,
                    DeviceCode = "D001",
                    DateOfEntry = new DateTime(2015, 12, 25),
                    DeviceName = "Dell XPS 13",
                    EquipmentStatus = Status.InUse,
                    DeviceImage = "/images/dell.jpg",
                    Category = new Category { Id = 1, CategoryName = "Laptop" },
                    Employee = new User { Id = 1, FullName = "Luci A" }
                },
                new Device {
                    Id = 2,
                    DeviceCode = "D002",
                    DateOfEntry = new DateTime(2020, 5, 15),
                    DeviceName = "Samsung 12 Pro",
                    EquipmentStatus = Status.InUse,
                    DeviceImage = "/images/samsung.jpg",
                    Category = new Category { Id = 2, CategoryName = "Smartphone" },
                    Employee = new User { Id = 2, FullName = "Luci B" }
                },
                new Device {
                    Id = 3,
                    DeviceCode = "D003",
                    DateOfEntry = new DateTime(2019, 9, 1),
                    DeviceName = "Canon EOS R5",
                    EquipmentStatus = Status.Broken,
                    DeviceImage = "/images/Camera.jpg",
                    Category = new Category { Id = 6, CategoryName = "Camera" },
                    Employee = new User { Id = 5, FullName = "Luci E" }
                }
             };



        //public IActionResult Index()
        //{
        //    Console.WriteLine(_devices == null ? "List devices is null" : "Device list is initialized");

        //    return View(_devices);
        //}
        public IActionResult Index(string searchTerm, Status? statusFilter, int? categoryID)
        {
            var filteredDevices = _devices.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                filteredDevices = filteredDevices.Where(d =>
                    d.DeviceName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    d.Id.ToString().Contains(searchTerm));
            }

            if (statusFilter.HasValue)
            {
                filteredDevices = filteredDevices.Where(d => d.EquipmentStatus == statusFilter.Value);
            }

            var category = CategoryController._categories;
            ViewBag.Categories = category;


            if (categoryID.HasValue)
            {
                filteredDevices = filteredDevices.Where(d => d.Category.Id == categoryID);
            }

            return View(filteredDevices.ToList());
        }



        [HttpGet]
        public IActionResult Create()
        {
            var users = UserController._users;
            ViewBag.Users = users;

            var category = CategoryController._categories;
            ViewBag.Categories = category;

            return View(new Device());
        }

        [HttpPost]
        public IActionResult Create(string DeviceName, string DeviceCode, Status EquipmentStatus, int CategoryId, int EmployeeId, IFormFile DeviceImage, DateTime DateOfEntry)
        {

            var device = new Device
            {
                Id = _devices.Count + 1,
                DeviceCode = DeviceCode,
                DeviceName = DeviceName,
                EquipmentStatus = EquipmentStatus,
                DateOfEntry = DateOfEntry,
                CategoryId = CategoryId,
                EmployeeId = EmployeeId,
                DeviceImage = "/images/default.jpg"
            };

            if (DeviceImage != null && DeviceImage.Length > 0)
            {
                var fileName = Path.GetFileName(DeviceImage.FileName);
                var filePath = Path.Combine("wwwroot", "images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    DeviceImage.CopyTo(stream);
                }
                device.DeviceImage = "/images/" + fileName;
            }

            _devices.Add(device);
            return RedirectToAction("Index", "Device");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var device = _devices.FirstOrDefault(d => d.Id == id);
            if (device == null)
            {
                return NotFound();
            }
            var users = UserController._users;
            ViewBag.Users = users;

            var category = CategoryController._categories;
            ViewBag.Categories = category;
            return View(device);
        }

        [HttpPost]
        public IActionResult Edit(int id, string DeviceCode, string DeviceName, Status EquipmentStatus, int CategoryId, int EmployeeId, IFormFile DeviceImage, DateTime DateOfEntry)
        {
            var existingDevice = _devices.FirstOrDefault(d => d.Id == id);

            if (existingDevice == null)
            {
                return NotFound();
            }

            existingDevice.DeviceName = DeviceName;
            existingDevice.DeviceCode = DeviceCode;
            existingDevice.EquipmentStatus = EquipmentStatus;
            existingDevice.DateOfEntry = DateOfEntry;
            existingDevice.Category = new Category { Id = CategoryId, CategoryName = "Category " + CategoryId }; // Dummy category
            existingDevice.Employee = new User { Id = EmployeeId, FullName = "Employee " + EmployeeId }; // Dummy employee

            if (DeviceImage != null && DeviceImage.Length > 0)
            {
                if (!string.IsNullOrEmpty(existingDevice.DeviceImage))
                {
                    var oldImagePath = Path.Combine("wwwroot", existingDevice.DeviceImage.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                var fileName = Path.GetFileName(DeviceImage.FileName);
                var filePath = Path.Combine("wwwroot", "images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    DeviceImage.CopyTo(stream);
                }
                existingDevice.DeviceImage = "/images/" + fileName;
            }

            return RedirectToAction("Index", "Device");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var device = _devices.FirstOrDefault(d => d.Id == id);
            if (device == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(device.DeviceImage))
            {
                var imagePath = Path.Combine("wwwroot", device.DeviceImage.TrimStart('/'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _devices.Remove(device);
            return RedirectToAction("Index", "Device");
        }
    }
}
