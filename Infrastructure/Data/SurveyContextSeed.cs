using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class SurveyContextSeed
    {
        public static async Task SeedAsync(SurveyContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.SurveyTypes.Any())
                {
                    var surveyTypesData = File.ReadAllText("../Infrastructure/Data/SeedData/surveyTypes.json");
                    var surveyTypes = JsonSerializer.Deserialize<List<SurveyType>>(surveyTypesData);
                    foreach (var item in surveyTypes)
                    {
                        context.SurveyTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Surveys.Any())
                {
                    var surveysData = File.ReadAllText("../Infrastructure/Data/SeedData/surveys.json");
                    var surveys = JsonSerializer.Deserialize<List<Survey>>(surveysData);
                    foreach (var item in surveys)
                    {
                        context.Surveys.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Questions.Any())
                {
                    var questionsData = File.ReadAllText("../Infrastructure/Data/SeedData/questions.json");
                    var questions = JsonSerializer.Deserialize<List<Question>>(questionsData);
                    foreach (var item in questions)
                    {
                        context.Questions.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Options.Any())
                {
                    var optionsData = File.ReadAllText("../Infrastructure/Data/SeedData/options.json");
                    var options = JsonSerializer.Deserialize<List<Option>>(optionsData);
                    foreach (var item in options)
                    {
                        context.Options.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<SurveyContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}