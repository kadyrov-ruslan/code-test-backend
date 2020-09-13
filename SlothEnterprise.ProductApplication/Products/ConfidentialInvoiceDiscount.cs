using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Services;

namespace SlothEnterprise.ProductApplication.Products
{
    public class ConfidentialInvoiceDiscount : IProduct
    {
        public int Id { get; set; }
        
        public ISubmitApplicationResult VisitProduct(
            IProductApplicationVisitor visitor, ISellerApplication application)
        {
            return visitor.SubmitApplication(application, this);
        }

        public decimal TotalLedgerNetworth { get; set; }
        public decimal AdvancePercentage { get; set; }
        public decimal VatRate { get; set; } = VatRates.UkVatRate;
    }
}