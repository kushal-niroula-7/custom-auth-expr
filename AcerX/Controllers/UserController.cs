using Microsoft.AspNetCore.Mvc;

namespace AcerX.Controllers
{
    public class UserController : Controller
    {
        // Action
        public IActionResult Single()
        {
            // Get data from database
            var user = new User();
            user.Id = 45;
            user.Name = "Something";
            return View(user);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserCreateVm vm)
        {
            try
            {
                var data = vm;
                // Save to database
                return RedirectToAction("Single");
            }
            catch(Exception ex)
            {
                return Redirect("/");
            }
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class  UserCreateVm
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
