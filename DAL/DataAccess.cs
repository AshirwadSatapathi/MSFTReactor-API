using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class DataAccess
    {
        private static string connectionString = "connectionstring";
        public static int InsertData(Feedback feedback)
        {
            int recordsInserted;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = @"INSERT INTO [dbo].[CustomerFeedback]
                                       ([CustomerName]
                                       ,[CustomerEmail]
                                       ,[FeedbackOnProduct]
                                       ,[FeedbackCategory]
                                       ,[ProductId]
                                       ,[CreatedOn])
                                 VALUES(@name,@email,@feedback,@feedbackRating,@productId,@createdOn)";
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@name", feedback.Name);
                    command.Parameters.AddWithValue("@email", feedback.Email);
                    command.Parameters.AddWithValue("@feedback", feedback.FeedbackOnProduct);
                    command.Parameters.AddWithValue("@feedbackRating", feedback.FeedbackRating);
                    command.Parameters.AddWithValue("@productId", feedback.Product.ProductId);
                    command.Parameters.AddWithValue("@createdOn", feedback.CreatedOn);
                    connection.Open();
                    recordsInserted = command.ExecuteNonQuery();
                }

            }
            
            return recordsInserted;
        }
        
    }
}
