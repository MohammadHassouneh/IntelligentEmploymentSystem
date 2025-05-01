using IntelligentEmploymentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IntelligentEmploymentSystem.Controllers
{
    public class ResumeController : Controller
    {

        DBEntities.IntelligentEmploymentSystemContext context = new DBEntities.IntelligentEmploymentSystemContext();
        public IActionResult Create()

        {
            return View();
        }

        public IActionResult AddResume(Models.ResumeModel resumeModel)

        {

            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login","User");

            DBEntities.Resume resume = new DBEntities.Resume();

            if (resumeModel.PicPath != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files/profilePictures");

                if (!Directory.Exists(path))
                {

                    Directory.CreateDirectory(path);

                }

                string fileName = resumeModel.PicPath.FileName;
                string fileNameWithPath = Path.Combine(path, fileName);

                using (var steam = new FileStream(fileNameWithPath, FileMode.Create))
                {

                    resumeModel.PicPath.CopyTo(steam);



                }
                var host = HttpContext.Request.Host.Value;
                resume.PicPath = "http://" + host + "/files/profilePictures" + "/" + fileName;


            }

            resume.Name = resumeModel.Name;
            resume.Summary = resumeModel.Summary;
            resume.Education = resumeModel.Education;
            resume.Experience = resumeModel.Experience;
            resume.Skills = resumeModel.Skills;
            resume.Phone = resumeModel.Phone;
            resume.Email = resumeModel.Email;
            resume.Address = resumeModel.Address;
            resume.UserId = userId.Value;



            context.Resumes.Add(resume);
            context.SaveChanges();



            return RedirectToActionPermanent("Profile", "User");
        }

        [HttpGet]
        public IActionResult Update()
        {

            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "User");

            var resume = context.Resumes.FirstOrDefault(x => x.UserId == userId);

            Models.ResumeModel resumeModel = new ResumeModel();

            
            resumeModel.Name = resume.Name;
            resumeModel.Summary = resume.Summary;
            resumeModel.Experience = resume.Experience;
            resumeModel.Education = resume.Education;
            resumeModel.Skills = resume.Skills;
            resumeModel.Email = resume.Email;
            resumeModel.Phone = resume.Phone;
            resumeModel.Address = resume.Address;
            resumeModel.ImagePath = resume.PicPath;






            return View(resumeModel);
        }
        [HttpPost]
        public IActionResult Update(Models.ResumeModel resumeModel)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "User");

            DBEntities.Resume resume = new DBEntities.Resume();

            resume = context.Resumes.FirstOrDefault(x => x.UserId == userId);

            if (resume == null)
                return BadRequest("No resume found for the user.");

            if (resumeModel.PicPath != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files/profilePictures");

                if (!Directory.Exists(path))
                {

                    Directory.CreateDirectory(path);

                }

                string fileName = resumeModel.PicPath.FileName;
                string fileNameWithPath = Path.Combine(path, fileName);

                using (var steam = new FileStream(fileNameWithPath, FileMode.Create))
                {

                    resumeModel.PicPath.CopyTo(steam);



                }
                var host = HttpContext.Request.Host.Value;
                resume.PicPath = "http://" + host + "/files/profilePictures" + "/" + fileName;


            }

            resume.Name = resumeModel.Name;
            resume.Summary = resumeModel.Summary;
            resume.Education = resumeModel.Education;
            resume.Experience = resumeModel.Experience;
            resume.Skills = resumeModel.Skills;
            resume.Phone = resumeModel.Phone;
            resume.Email = resumeModel.Email;
            resume.Address = resumeModel.Address;
            


            
            context.SaveChanges();



            return RedirectToAction("Profile", "User");
        }
    }
}
