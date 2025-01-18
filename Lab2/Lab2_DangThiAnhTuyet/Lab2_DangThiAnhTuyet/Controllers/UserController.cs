using Lab2_DangThiAnhTuyet.Enums;
using Lab2_DangThiAnhTuyet.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab2_DangThiAnhTuyet.Controllers
{
    public class UserController : Controller
    {
        public static List<User> _users = new List<User>
        {
            new User {
                Id = 1,
                UserName = "@user1",
                FullName = "Luci A",
                Password = "luciA",
                Email = "luci@gmail.com",
                PhoneNumber = "1234567890",
                Address = "ABD street, A city",
                Gender = Enums.Gender.Female,
                Avatar = "/images/user1.jpg"
            },
            new User {
                Id = 2,
                UserName = "@user2",
                FullName = "Luci B",
                Password = "luciB",
                Email = "luciB@gmail.com",
                PhoneNumber = "0987654321",
                Address = "XYZ street, B city",
                Gender = Enums.Gender.Male,
                Avatar = "/images/user2.jpg"
            },
            new User {
                Id = 3,
                UserName = "@user3",
                FullName = "Luci C",
                Password = "luciC",
                Email = "luciC@gmail.com",
                PhoneNumber = "1122334455",
                Address = "LMN street, C city",
                Gender = Enums.Gender.Female,
                Avatar = "/images/user5.jpg"
            },
            new User {
                Id = 4,
                UserName = "@user4",
                FullName = "Luci D",
                Password = "luciD",
                Email = "luciD@gmail.com",
                PhoneNumber = "2233445566",
                Address = "OPQ street, D city",
                Gender = Enums.Gender.Male,
                Avatar = "/images/user4.jpg"
            },
            new User {
                Id = 5,
                UserName = "@user5",
                FullName = "Luci E",
                Password = "luciE",
                Email = "luciE@gmail.com",
                PhoneNumber = "3344556677",
                Address = "RST street, E city",
                Gender = Enums.Gender.Female,
                Avatar = "/images/user5.jpg"
            }
        };

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Json(_users); 
        }

        public IActionResult Index()
        {
            Console.WriteLine(_users == null ? "User list is null" : "User list is initialized");

            return View(_users);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _users.FirstOrDefault(c => c.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(int id, string UserName, string Password, string FullName, string Email, string PhoneNumber, string Address, Gender Gender, IFormFile Avatar)
        {
            var existingUser = _users.FirstOrDefault(c => c.Id == id);

            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.UserName = UserName;
            existingUser.FullName = FullName;
            existingUser.Password = Password;
            existingUser.Email = Email;
            existingUser.PhoneNumber = PhoneNumber;
            existingUser.Address = Address;

            if (Avatar != null && Avatar.Length > 0)
            {
                if (!string.IsNullOrEmpty(existingUser.Avatar))
                {
                    var oldCoverPath = Path.Combine("wwwroot", existingUser.Avatar.TrimStart('/'));
                    if (System.IO.File.Exists(oldCoverPath))
                    {
                        System.IO.File.Delete(oldCoverPath);
                    }
                }
                var fileName = Path.GetFileName(Avatar.FileName);
                var filePath = Path.Combine("wwwroot", "images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Avatar.CopyTo(stream);
                }
                existingUser.Avatar = "/images/" + fileName;
            }

            return RedirectToAction("Index", "User");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var selectedUser = _users.FirstOrDefault(b => b.Id == id);
            if (selectedUser == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(selectedUser.Avatar))
            {
                var coverPath = Path.Combine("wwwroot", selectedUser.Avatar.TrimStart('/'));
                if (System.IO.File.Exists(coverPath))
                {
                    System.IO.File.Delete(coverPath);
                }
            }

            _users.Remove(selectedUser);

            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        public IActionResult Create()
        {
            var user = new User();
            return View(user);
        }


        [HttpPost]
        public IActionResult Create( string UserName, string Password, string FullName, string Email, string PhoneNumber, string Address, Gender Gender, IFormFile Avatar)
        {
            var user = new User
            {
                Id = _users.Count + 1,
                UserName = UserName,
                FullName = FullName,
                Password = Password,
                Email = Email,
                PhoneNumber = PhoneNumber,
                Address = Address,
                Gender = Gender,

            };
            if (Avatar != null && Avatar.Length > 0)
            {
                var fileName = Path.GetFileName(Avatar.FileName);
                var filePath = Path.Combine("wwwroot", "images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Avatar.CopyTo(stream);
                }
                user.Avatar = "/images/" + fileName;
            }
            _users.Add(user);
            return RedirectToAction("Index", "User");
        }
    }
}
