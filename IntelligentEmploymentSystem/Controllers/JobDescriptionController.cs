using IntelligentEmploymentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IntelligentEmploymentSystem.Controllers
{
    public class JobDescriptionController : Controller
    {
        DBEntities.IntelligentEmploymentSystemContext context=new DBEntities.IntelligentEmploymentSystemContext();
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult AddJobDescription(Models.JobDescriptionModel jobDescriptionModel)
        {

            int? companyId= HttpContext.Session.GetInt32("CompanyId");
            if (companyId == null)
                return RedirectToAction("Login","Company");

            jobDescriptionModel.CompanyId = companyId.Value;

            

                DBEntities.JobDescription jobDescription = new DBEntities.JobDescription();

                jobDescription.JobTitle = jobDescriptionModel.JobTitle;
                jobDescription.JobBrief = jobDescriptionModel.JobBrief;
                jobDescription.Responsibilities = jobDescriptionModel.Responsibilities;
                jobDescription.Requirements = jobDescriptionModel.Requirements;
                jobDescription.CompanyId = companyId.Value;


                context.JobDescriptions.Add(jobDescription);
                context.SaveChanges();

            

            return RedirectToAction("Profile", "Company");
        }

        public IActionResult GetAllJobDescription()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login");

            var resume = context.Resumes.FirstOrDefault(u => u.UserId == userId);
            if (resume == null) return RedirectToAction("Create","Resume");

            List<IntelligentEmploymentSystem.Models.JobDescriptionModel> jobDescriptions = new List<JobDescriptionModel>();

            jobDescriptions = (from company in context.Companies.ToList()
                               join job in context.JobDescriptions.ToList()
                               on company.CompanyId equals job.CompanyId
                               select new Models.JobDescriptionModel
                          {
                              
                                   JobDescriptionId=job.JobDescriptionId,
                                   JobTitle = job.JobTitle,
                                   JobBrief = job.JobBrief,
                                   Responsibilities = job.Responsibilities,
                                   Requirements = job.Requirements,
                                   CompanyName = company.CompanyName,
                                   Status = RetrunStatus(resume.ResumeId, job.JobDescriptionId),





                               }).ToList();

            

            return View(jobDescriptions);
        }


        public string RetrunStatus(int resumeId, int jobDescriptionId)
        {

            int count = context.Scores.Where(x => x.ResumeId == resumeId && x.JobDescriptionId == jobDescriptionId).Count();

            if (count == 0) { return "Apply Now"; }


            else { return "Applied for job"; }
           

        }


        public IActionResult Remove(int jobId)
        {

            var score = context.Scores.Where(s => s.JobDescriptionId == jobId).ToList();
            context.Scores.RemoveRange(score);
            context.SaveChanges();


            var job = context.JobDescriptions.FirstOrDefault(x => x.JobDescriptionId == jobId);

            context.JobDescriptions.Remove(job);
            context.SaveChanges();



            return RedirectToAction("JobReview", "Company");
        }

    }
}
