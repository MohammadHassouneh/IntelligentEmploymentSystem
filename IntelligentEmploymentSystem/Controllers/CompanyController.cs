using IntelligentEmploymentSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentEmploymentSystem.Controllers
{
    public class CompanyController : Controller
    {

        DBEntities.IntelligentEmploymentSystemContext context = new DBEntities.IntelligentEmploymentSystemContext();
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult registration(Models.CompanyModel companyModel) { 
          DBEntities.Company company = new DBEntities.Company();

            company.CompanyName = companyModel.CompanyName;
            company.Email = companyModel.Email;
            company.Password = companyModel.Password;
            company.Phone = companyModel.Phone; 
            company.WebSite = companyModel.WebSite;
            company.Address = companyModel.Address;
            company.AboutUs = companyModel.AboutUs;
            company.OurService = companyModel.OurService;
             
            context.Add(company);
            context.SaveChanges();
        
        return RedirectToAction("Login");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Models.CompanyLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var company = context.Companies
                    .FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                if (company != null)
                {
                    HttpContext.Session.SetInt32("CompanyId", company.CompanyId);
                    return RedirectToAction("Profile");
                }
                ModelState.AddModelError("", "Invalid username or password");
            }

            return View(model);
        }


        public IActionResult Profile()
        {
            int? companyId = HttpContext.Session.GetInt32("CompanyId");

            if (companyId == null)
                return RedirectToAction("Login");

            var company = context.Companies.FirstOrDefault(u => u.CompanyId == companyId);
            if (company == null) return NotFound();

            return View(company);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Update()
        {

            int? companyId = HttpContext.Session.GetInt32("CompanyId");

            if (companyId == null)
                return RedirectToAction("Login");

            var company = context.Companies.FirstOrDefault(x => x.CompanyId== companyId);

            Models.CompanyModel companyModel = new CompanyModel();


            companyModel.CompanyName = company.CompanyName ;
            companyModel.AboutUs = company.AboutUs ;
            companyModel.OurService = company.OurService ;
            companyModel.Email = company.Email ;
            companyModel.Phone = company.Phone ;
            companyModel.Address = company.Address ;
            companyModel.WebSite = company.WebSite ;
            





            return View(companyModel);
        }
        [HttpPost]
        public IActionResult Update(Models.CompanyModel companyModel)
        {
            int? companyId = HttpContext.Session.GetInt32("CompanyId");

            if (companyId == null)
                return RedirectToAction("Login");

            var company = context.Companies.FirstOrDefault(x => x.CompanyId == companyId);

            company.CompanyName= companyModel.CompanyName ;
            company.AboutUs = companyModel.AboutUs ;
            company.OurService = companyModel.OurService;
            company.Email = companyModel.Email ;
            company.Phone = companyModel.Phone ;
            company.Address = companyModel.Address ;
            company.WebSite = companyModel.WebSite ;
            
        


            context.SaveChanges();



            return RedirectToAction("Profile", "Company");
        }

        public IActionResult JobReview()
        {
            int? companyId = HttpContext.Session.GetInt32("CompanyId");

            if (companyId == null)
                return RedirectToAction("Login");

            List<Models.JobDescriptionModel> jobs = new List<Models.JobDescriptionModel>();

            jobs = (from JobDescription in context.JobDescriptions.ToList() where JobDescription.CompanyId == companyId
                    select new Models.JobDescriptionModel
                    {
                        JobTitle=JobDescription.JobTitle,
                        JobBrief=JobDescription.JobBrief,
                        Responsibilities=JobDescription.Responsibilities,
                        Requirements=JobDescription.Requirements,
                        JobDescriptionId=JobDescription.JobDescriptionId,



                    }).ToList();




            return View(jobs);
        }

        public IActionResult Applicants(int jobId)
        {
            List<IntelligentEmploymentSystem.Models.ResumeModel> Applicants = new List<ResumeModel>();

            Applicants= (from score in context.Scores.ToList()
                         where score.JobDescriptionId == jobId
                         join resume in context.Resumes.ToList()
                         on score.ResumeId equals resume.ResumeId
                         select new Models.ResumeModel
                         {
                             Name = resume.Name,
                             Summary = resume.Summary ,
                             Experience = resume.Experience,
                             Skills = resume.Skills,
                             Education=resume.Education,
                             Address=resume.Address,
                             Phone=resume.Phone,
                             Email=resume.Email,
                             Score=score.Score1,

                             




                         }).ToList();




            return View(Applicants);
        }



    }
}
