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
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
