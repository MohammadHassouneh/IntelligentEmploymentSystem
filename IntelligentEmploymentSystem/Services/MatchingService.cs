using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IntelligentEmploymentSystem.Services
{
    public class MatchingService
    {
        
        public List<string> ExtractKeywords(string text)
        {
            if (string.IsNullOrEmpty(text)) return new List<string>();

            
            var words = Regex.Split(text.ToLower(), @"\W+")
                             .Where(w => w.Length > 2) 
                             .GroupBy(w => w)
                             .Select(g => g.Key)
                             .ToList();

            return words;
        }

        
        public double ComputeMatchScore(IntelligentEmploymentSystem.Models.ResumeModel resume ,IntelligentEmploymentSystem.Models.JobDescriptionModel jobDescription)
        {
            var resumeSkills = ExtractKeywords(resume.Skills);
            var resumeEducation = ExtractKeywords(resume.Education);
            var resumeExperience = ExtractKeywords(resume.Experience);
            var resumeSummary = ExtractKeywords(resume.Summary);


            var jobRequirements = ExtractKeywords(jobDescription.Requirements);
            var jobResponsibilities = ExtractKeywords(jobDescription.Responsibilities);
            var jobJobBrief = ExtractKeywords(jobDescription.JobBrief);
            var jobTitle = ExtractKeywords(jobDescription.JobTitle);

            var jobKeywords = jobRequirements
                .Concat(jobResponsibilities)
                .Concat(jobJobBrief)
                .Concat(jobTitle)
                .Distinct()
                .ToList();

            double AverageLength = jobKeywords.Average(k => k.Length);

            int SkillsMatchCount = jobKeywords.Count(k => resumeSkills.Contains(k));
            int ExperienceMatchCount = jobKeywords.Count(k => resumeExperience.Contains(k));
            int EducationMatchCount = jobKeywords.Count(k => resumeEducation.Contains(k));
            int SummaryMatchCount = jobKeywords.Count(k => resumeSummary.Contains(k));

            int MatchCount = SkillsMatchCount + ExperienceMatchCount + EducationMatchCount  + SummaryMatchCount;

            if (MatchCount == 0)
            {
                return 0; 
            }

            double AvarageCount = (SkillsMatchCount *4 + ExperienceMatchCount*3 + EducationMatchCount*2 + SummaryMatchCount*1) / 10.0;


            double score= (AvarageCount / AverageLength) * 100;

            if (score > 100) score = 100;
            if (score < 0) score = 0;
            











            return Math.Round(score, 2);
        }
    }
}
