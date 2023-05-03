using System.Data;

namespace ProductReviewManagmentWithLinq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Product Review Managment Program!!!");

            List<ProductReview> ProductReviewList = new List<ProductReview>()
            {
                new ProductReview(){ProductID = 1,UserID = 10,Rating=5,Review="Good",IsLike=true},
                new ProductReview(){ProductID = 2,UserID = 11,Rating=4,Review="Nice",IsLike=true},
                new ProductReview(){ProductID = 3,UserID = 12,Rating=3,Review="Average",IsLike=true},
                new ProductReview(){ProductID = 4,UserID = 13,Rating=4,Review="Nice",IsLike=true},
                new ProductReview(){ProductID = 5 ,UserID = 14,Rating=5,Review="Good",IsLike=true}

            };

            Managemenent managemenent = new Managemenent();
            //managemenent.topRecords(ProductReviewList);
            //managemenent.SelectedRecords(ProductReviewList);
            //managemenent.RetrieveCountOfRecords(ProductReviewList);
            //managemenent.retrieveID(ProductReviewList);
            // managemenent.SkipTop5Records(ProductReviewList);
            // managemenent.RetireveProductIDReview(ProductReviewList);

            DataTable dt = new DataTable();
            dt.Columns.Add("ProductID", typeof(int));
            dt.Columns.Add("UserID", typeof(int));
            dt.Columns.Add("Rating", typeof(double));
            dt.Columns.Add("Review", typeof(string));
            dt.Columns.Add("IsLike", typeof(bool));

            for (int i = 1; i <= 25; i++)
            {
                dt.Rows.Add(i, i + 10, i % 5 + 1, "Review " + i, i % 2 == 0);
            }

            // Retrieve records from DataTable using LINQ
            var recordData = from row in dt.AsEnumerable()
                             select new ProductReview
                             {
                                 ProductID = row.Field<int>("ProductID"),
                                 UserID = row.Field<int>("UserID"),
                                 Rating = row.Field<double>("Rating"),
                                 Review = row.Field<string>("Review"),
                                 IsLike = row.Field<bool>("IsLike")
                             };

            foreach (var record in recordData)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", record.ProductID, record.UserID, record.Rating, record.Review, record.IsLike);
            }
        }
    }
}
  