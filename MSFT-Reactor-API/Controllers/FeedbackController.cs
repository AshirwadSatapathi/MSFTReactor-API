using System.Collections.Generic;
using Business;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace MSFT_Reactor_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackBusiness business;
        public FeedbackController(IFeedbackBusiness feedbackBusiness)
        {
            this.business = feedbackBusiness;
        }
       
        [HttpGet]
        [Route("GetFeedbacks")]
        public ActionResult<List<Feedback>> GetFeedback()
        {
            return this.business.GetFeedbacks();
        }
        [HttpGet]
        [Route("GetFeedbackByRating")]
        public ActionResult<List<Feedback>> GetFeedbackByRating(Feedback feedback)
        {
            return this.business.GetFeedbacks();
        }

        [HttpPost]
        [Route("SubmitFeedback")]
        public ActionResult<Feedback> SubmitFeedback (Feedback feedback)
        {
            return this.business.SubmitFeedback(feedback);
        }


    }
}
