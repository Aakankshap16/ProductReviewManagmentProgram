using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagmentWithLinq
{
    public class Managemenent
    {
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
    }
}
