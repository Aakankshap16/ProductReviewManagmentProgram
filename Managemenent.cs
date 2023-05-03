using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagmentWithLinq
{
    public class Managemenent
    {

        // top 3 records
        public void topRecords(List<ProductReview> ListOfProductReview)
        {
            var RecordData = (from products in ListOfProductReview
                              orderby products.Rating descending
                              select products).Take(3);
            foreach (var record in RecordData)
            {
                Console.Write("{0} {1} {2} {3} {4}\n", record.ProductID, record.UserID, record.Review, record.Rating, record.IsLike);
            }

        }

        //record according to condition
        public void SelectedRecords(List<ProductReview> ListOfProductReview)
        {
            var RecordData = from products in ListOfProductReview
                             where (products.ProductID == 1 && products.Rating > 3) ||
                                    (products.ProductID == 4 && products.Rating > 3) ||
                                    (products.ProductID == 9 && products.Rating > 3)
                             select products;


            foreach (var record in RecordData)
            {
                Console.Write("{0} {1} {2} {3} {4}\n", record.ProductID, record.UserID, record.Review, record.Rating, record.IsLike);

            }
        }

        //Count the record acc to productid
        public void RetrieveCountOfRecords(List<ProductReview> ListOfProductReview)
        {
            var RecordData = ListOfProductReview.GroupBy(x => x.ProductID).Select
                             (x => new { ProductID = x.Key, count = x.Count() });
            foreach (var record in RecordData)
            {
                Console.WriteLine(record.ProductID + "-" + record.count);
            }
        }

        // select only 2 records
        public void retrieveID(List<ProductReview> ListOfProductReview)
        {
            var RecordData = from products in ListOfProductReview
                             select
                             new { ProductID = products.ProductID, review = products.Review };
            foreach (var record in RecordData)
            {
                Console.WriteLine(record.ProductID + " " + record.review);
            }
        }

        // skip top 5 records
        public void SkipTop5Records(List<ProductReview> ListOfProductReview)
        {
            var RecordData = (from Products in ListOfProductReview
                              select Products).Skip(2);
            foreach (var record in RecordData)
            {
                Console.Write("{0} {1} {2} {3} {4}\n", record.ProductID, record.UserID, record.Review, record.Rating, record.IsLike);

            }
        }

        public void RetireveProductIDReview(List<ProductReview> ListOfProductReview)
        {
            var RecordData = from products in ListOfProductReview
                             select
                             new { ProductID = products.ProductID, review = products.Review };
            foreach (var record in RecordData)
            {
                Console.WriteLine(record.ProductID + " " + record.review);
            }
        }
        public void AddDefaultValuesToDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductID", typeof(int));
            dt.Columns.Add("UserID", typeof(int));
            dt.Columns.Add("Rating", typeof(double));
            dt.Columns.Add("Review", typeof(string));
            dt.Columns.Add("IsLike", typeof(bool));

            var defaultValues = Enumerable.Range(1, 25)
                .Select(i => new ProductReview()
                {
                    ProductID = i,
                    UserID = i * 10,
                    Rating = i % 5 + 1,
                    Review = $"Review {i}",
                    IsLike = i % 2 == 0
                });

            foreach (var productReview in defaultValues)
            {
                dt.Rows.Add(productReview.ProductID, productReview.UserID, productReview.Rating, productReview.Review, productReview.IsLike);
            }

            Console.WriteLine($"DataTable with {dt.Rows.Count} rows created:");
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"{row["ProductID"]} {row["UserID"]} {row["Rating"]} {row["Review"]} {row["IsLike"]}");
            }
        }

    }
}
