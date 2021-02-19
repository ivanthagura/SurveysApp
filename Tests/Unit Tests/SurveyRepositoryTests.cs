using Core.Dtos;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Unit_Tests
{
    public class SurveyRepositoryTests
    {
        [Fact]
        public async void GetSurvey_Returns_Survey()
        {
            var options = new DbContextOptionsBuilder<SurveyContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            await GenerateSurveys(options);

            using (var context = new SurveyContext(options))
            {
                var surveyRepository = new SurveyRepository(context);

                var survey = await surveyRepository.GetSurvey(1);

                Assert.NotNull(survey);
                Assert.Equal("Survey 1", survey.Name);
                Assert.Equal(3, survey.Questions.Count);
            }
        }

        [Fact]
        public async void GetSurveys_Returns_All_Surveys()
        {
            var options = new DbContextOptionsBuilder<SurveyContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            await GenerateSurveys(options);

            using (var context = new SurveyContext(options))
            {
                var surveyRepository = new SurveyRepository(context);

                var surveys = await surveyRepository.GetSurveys();

                Assert.NotNull(surveys);
                Assert.Equal(2, surveys.Count);
            }
        }

        [Fact]
        public async void AddSurveyResponse_Adds_Survey_Response()
        {
            var options = new DbContextOptionsBuilder<SurveyContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            await GenerateSurveys(options);

            using (var context = new SurveyContext(options))
            {
                var surveyRepository = new SurveyRepository(context);

                var survey = await surveyRepository.GetSurvey(1);
                var surveyResponse = new SurveyResponseDto
                {
                    Name = "Test User",
                    Email = "test@test.com",
                    SurveyId = survey.Id,
                    Answers = new List<SurveyResponseAnswerDto>
                    {
                        new SurveyResponseAnswerDto { QuestionId = 1, QuestionAnswer = "Answer 1"},
                        new SurveyResponseAnswerDto { QuestionId = 2, QuestionAnswer = "Answer 2"},
                        new SurveyResponseAnswerDto { QuestionId = 3, QuestionAnswer = "Answer 3"}
                    }
                };

                var success = await surveyRepository.AddSurveyResponse(survey, surveyResponse);
                var responseList = await context.SurveyResponses.ToListAsync();
                var response = responseList.First();

                Assert.True(success);
                Assert.NotNull(responseList);
                Assert.NotNull(response);
            }
        }

        private async Task GenerateSurveys(DbContextOptions<SurveyContext> options)
        {
            using( var context = new SurveyContext(options))
            {
                context.Surveys.Add(new Survey
                {
                    Id = 1,
                    Name = "Survey 1",
                    Questions = new List<Question> 
                    {
                        new Question { Id = 1, Title = "Question 1"},
                        new Question { Id = 2, Title = "Question 2"},
                        new Question { Id = 3, Title = "Question 3"}
                    }
                });

                context.Surveys.Add(new Survey
                {
                    Id = 2,
                    Name = "Survey 2",
                    Questions = new List<Question>
                    {
                        new Question { Id = 4, Title = "Question 4"},
                        new Question { Id = 5, Title = "Question 5"},
                        new Question { Id = 6, Title = "Question 6"}
                    }
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
