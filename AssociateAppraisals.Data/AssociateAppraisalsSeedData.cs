using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AssociateAppraisals.Model;

namespace AssociateAppraisals.Data
{
    public class AssociateAppraisalsSeedData : DropCreateDatabaseIfModelChanges<AssociateAppraisalsEntities>
    {
        protected override void Seed(AssociateAppraisalsEntities context)
        {
            GetAppraisals().ForEach(a => context.Appraisals.Add(a));
            GetAppraisalQuestions().ForEach(q => context.AppraisalQuestions.Add(q));

            context.Commit();
        }

        private static List<Appraisal> GetAppraisals()
        {
            return new List<Appraisal>
            {
                new Appraisal {
                    ReviewYear = 2014,
                    StartDate = new DateTime(2014, 3, 1),
                    EndDate = new DateTime(2014, 4, 1)
                },
                new Appraisal {
                    ReviewYear = 2015,
                    StartDate = new DateTime(2015, 3, 1),
                    EndDate = new DateTime(2015, 4, 1)
                }
            };
        }

        private static List<AppraisalQuestion> GetAppraisalQuestions()
        {
            return new List<AppraisalQuestion>
            {
                new AppraisalQuestion {
                    AppraisalId = 0,
                    AppraisalQuestionGroupId = 0,
                    AppraisalQuestionTypeId = 0,
                    Question = "What is your favorite color?",
                    QuestionNumber = 1
                },
                new AppraisalQuestion {
                    AppraisalId = 0,
                    AppraisalQuestionGroupId = 0,
                    AppraisalQuestionTypeId = 0,
                    Question = "What is the meaning of life?",
                    QuestionNumber = 2
                },
                new AppraisalQuestion {
                    AppraisalId = 0,
                    AppraisalQuestionGroupId = 0,
                    AppraisalQuestionTypeId = 0,
                    Question = "What is the purpose of this question?",
                    QuestionNumber = 3
                },
                 new AppraisalQuestion {
                    AppraisalId = 1,
                    AppraisalQuestionGroupId = 0,
                    AppraisalQuestionTypeId = 0,
                    Question = "What is your favorite color?",
                    QuestionNumber = 1
                },
                new AppraisalQuestion {
                    AppraisalId = 1,
                    AppraisalQuestionGroupId = 0,
                    AppraisalQuestionTypeId = 0,
                    Question = "What is the meaning of life?",
                    QuestionNumber = 2
                },
                new AppraisalQuestion {
                    AppraisalId = 1,
                    AppraisalQuestionGroupId = 0,
                    AppraisalQuestionTypeId = 0,
                    Question = "What is the purpose of this question?",
                    QuestionNumber = 3
                }
            };
        }
    }
}
