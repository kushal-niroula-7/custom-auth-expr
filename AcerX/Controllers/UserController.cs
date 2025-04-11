using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
            var vm = new UserCreateVm();
            var userTypes = GetUserTypes();
            vm.userTypes = userTypes;
            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(UserCreateVm vm)
        {
            try
            {
                var userTypes = GetUserTypes();
                vm.userTypes = userTypes;
                if (!ModelState.IsValid)
                {
                    return View(vm);
                }
                if (vm.Username == "admin")
                {
                    ModelState.AddModelError("Username", "Cannot use admin as username");
                    return View(vm);
                }
                var data = vm;
                // Save to database
                return RedirectToAction("Single");
            }
            catch (Exception ex)
            {
                return Redirect("/");
            }
        }

        public IActionResult Edit(int id)
        {
            // Get data from database
            var model = "";
            var vm = new UserCreateVm();
            var userTypes = GetUserTypes();
            vm.userTypes = userTypes;
            // Copy data from model to view model
            vm.Username = "user_" + id;
            vm.SelectedUserType = 3;
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(int id, UserCreateVm vm)
        {
            try
            {
                var userTypes = GetUserTypes();
                vm.userTypes = userTypes;
                if (!ModelState.IsValid)
                {
                    return View(vm);
                }
                if (vm.Username == "admin")
                {
                    ModelState.AddModelError("Username", "Cannot use admin as username");
                    return View(vm);
                }
                var data = vm;
                // Save to database
                return RedirectToAction("Single");
            }
            catch (Exception ex)
            {
                return Redirect("/");
            }
        }

        public static List<UserType> GetUserTypes()
        {
            var userTypes = new List<UserType>();
            for(int i = 0; i < 10; i++)
            {
                var type = new UserType();
                type.Id = i;
                type.Name = "User_type_" + i;
                userTypes.Add(type);
            }
            return userTypes;
        }
    }



    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UserCreateVm
    {
        [Required]
        [DisplayName("✅✅ Anything")]
        public string Username { get; set; }
        public string Password { get; set; }
        public int SelectedUserType { get; set; }


        public List<UserType> userTypes;

        // Select List

        public SelectList UserTypeSelectItems()
               => new SelectList(userTypes, nameof(UserType.Id),
                   nameof(UserType.Name),
                   SelectedUserType
                   );
    }

    public class UserType
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
