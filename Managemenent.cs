using System;
using System.Collections.Generic;
using System.Linq;
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

        //
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
    }
}
