using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.Services
{
    /// <summary>
    /// Provides methods for submit applications of visited products
    /// </summary>
    public interface IProductApplicationVisitor
    {
        /// <summary>
        /// Submits application for SelectiveInvoiceDiscount
        /// </summary>
        /// <param name="application">Seller application</param>
        /// <param name="selectiveInvoiceDiscount">Selective invoice discount product</param>
        /// <returns></returns>
        ISubmitApplicationResult SubmitApplication(
            ISellerApplication application, SelectiveInvoiceDiscount selectiveInvoiceDiscount);
        
        /// <summary>
        /// Submits application for ConfidentialInvoiceDiscount
        /// </summary>
        /// <param name="application">Seller application</param>
        /// <param name="confidentialInvoiceDiscount">Confidential invoice discount product</param>
        /// <returns></returns>
        ISubmitApplicationResult SubmitApplication(
            ISellerApplication application, ConfidentialInvoiceDiscount confidentialInvoiceDiscount);
        
        /// <summary>
        /// Submits application for BusinessLoans
        /// </summary>
        /// <param name="application">Seller application</param>
        /// <param name="businessLoans">Business loans product</param>
        /// <returns></returns>
        ISubmitApplicationResult SubmitApplication(
            ISellerApplication application, BusinessLoans businessLoans);
    }
}