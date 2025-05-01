using IntelligentEmploymentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IntelligentEmploymentSystem.Controllers
{
    public class UserController : Controller
    {

        DBEntities.IntelligentEmploymentSystemContext context=new DBEntities.IntelligentEmploymentSystemContext();
        public IActionResult Create()
        {


            
            return View();


            
        }
        public IActionResult Registration(Models.UserModel userModel)
        {
            DBEntities.User user = new DBEntities.User();

            user.UserName=userModel.userName;
            user.Email=userModel.email;
            user.Password=userModel.password;

            context.Users.Add(user);
            context.SaveChanges();


                                            


            return RedirectToAction("Login");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Models.LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = context.Users
                    .FirstOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);

                if (user != null)
                {
                    HttpContext.Session.SetInt32("UserId", user.UserId);
                    return RedirectToAction("Profile");
                }
                ModelState.AddModelError("", "Invalid username or password");
            }

            return View(model);
        }

        public IActionResult Profile()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login");

            var user = context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null) return NotFound();


            var resume = context.Resumes.FirstOrDefault(u => u.UserId == userId);

            var profileModel = new ProfileModel
            {
                User = user,
                Resume=resume
            };

            return View(profileModel);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


    }
}
