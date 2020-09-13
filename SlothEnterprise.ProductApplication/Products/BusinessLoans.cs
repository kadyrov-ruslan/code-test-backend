using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Services;

namespace SlothEnterprise.ProductApplication.Products
{
    public class BusinessLoans : IProduct
    {
        public int Id { get; set; }

        public ISubmitApplicationResult VisitProduct(
            IProductApplicationVisitor visitor, ISellerApplication application)
        {
            return visitor.SubmitApplication(application, this);
        }

        /// <summary>
        /// Per annum interest rate
        /// </summary>
        public decimal InterestRatePerAnnum { get; set; }

        /// <summary>
        /// Total available amount to withdraw
        /// </summary>
        public decimal LoanAmount { get; set; }
    }
}