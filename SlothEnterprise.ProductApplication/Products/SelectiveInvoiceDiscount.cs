using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Services;

namespace SlothEnterprise.ProductApplication.Products
{
    public class SelectiveInvoiceDiscount : IProduct
    {
        public int Id { get; set; }
        
        public int VisitProduct(IProductApplicationVisitor visitor, ISellerApplication application)
        {
            return visitor.SubmitApplication(application, this);
        }

        /// <summary>
        /// Proposed networth of the Invoice
        /// </summary>
        public decimal InvoiceAmount { get; set; }
        /// <summary>
        /// Percentage of the networth agreed and advanced to seller
        /// </summary>
        public decimal AdvancePercentage { get; set; } = 0.80M;
    }
}