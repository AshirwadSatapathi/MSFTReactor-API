
using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Business
{
    public class FeedbackBusiness : IFeedbackBusiness
    {
        public FeedbackBusiness()
        {
        }
        public List<Feedback> GetFeedbacks()
        {
            return new List<Feedback>()
            {
                new Feedback()
                {
                    Id=1, Name="Ashirwad", Email="ashirwad@esspl.com", FeedbackOnProduct="It was a wonderful product", FeedbackRating = "Good"
                    , Product = new Product()
                    {
                        ProductId = 1, ProductName = "Microsoft"
                    }
                },
                new Feedback()
                {
                    Id=2, Name="Ashutosh", Email="ashutosh@esspl.com", FeedbackOnProduct="It was a amazing product", FeedbackRating = "Good"
                    , Product = new Product()
                    {
                        ProductId = 1, ProductName = "Microsoft"
                    },
                }
            };
        }

        public Feedback SubmitFeedback(Feedback feedback)
        {
            feedback.FeedbackRating = FeedbackAnalyzer.AnalyzeSentiment(feedback.FeedbackOnProduct);
            
            EmailHelper.SendEmail(feedback);
            var records = DataAccess.InsertData(feedback);
            return feedback;
        }

    }
}
