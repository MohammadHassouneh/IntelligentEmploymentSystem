using IntelligentEmploymentSystem.DBEntities;
using IntelligentEmploymentSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentEmploymentSystem.Controllers
{
    public class ScoreController : Controller
    {
        DBEntities.IntelligentEmploymentSystemContext context = new DBEntities.IntelligentEmploymentSystemContext();

        private readonly MatchingService _matchingService;

        public ScoreController(MatchingService matchingService)
        {
            _matchingService = matchingService;
        }
        public IActionResult Apply(int jobId)

        {

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login","User");

            var user = context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null) return NotFound();

            var resume = context.Resumes.Where(x => x.UserId == user.UserId).FirstOrDefault();
            if (resume == null)
                return BadRequest("No resume found for the user.");

            var jobDescription = context.JobDescriptions.FirstOrDefault(x => x.JobDescriptionId == jobId);
            if (jobDescription == null)
                return BadRequest("No job description found for the given ID.");

            Models.ResumeModel resumeModel = new Models.ResumeModel();
            
            resumeModel.Summary = resume.Summary;
            resumeModel.Experience = resume.Experience;
            resumeModel.Education = resume.Education;
            resumeModel.Skills = resume.Skills;

            Models.JobDescriptionModel jobDescriptionModel = new Models.JobDescriptionModel();

            jobDescriptionModel.JobTitle = jobDescription.JobTitle;
            jobDescriptionModel.JobBrief = jobDescription.JobBrief;
            jobDescriptionModel.Requirements = jobDescription.Requirements;
            jobDescriptionModel.Responsibilities = jobDescription.Responsibilities;


            var MatchScore = _matchingService.ComputeMatchScore(resumeModel, jobDescriptionModel);
            


            DBEntities.Score score = new DBEntities.Score();

            score.JobDescriptionId = jobId;
            score.Score1 = (int)Math.Round(MatchScore);
            score.ResumeId = resume.ResumeId;

            context.Add(score);
            context.SaveChanges();




            



            return RedirectToAction("GetAllJobDescription", "JobDescription");
        }
    }
}
