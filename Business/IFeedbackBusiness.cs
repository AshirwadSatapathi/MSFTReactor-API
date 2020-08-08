
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface IFeedbackBusiness
    {
        List<Feedback> GetFeedbacks();

        Feedback SubmitFeedback(Feedback feedback);

    }
}
