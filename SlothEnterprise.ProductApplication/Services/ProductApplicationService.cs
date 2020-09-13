using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.Services
{
    public class ProductApplicationService : IProductApplicationVisitor
    {
        private readonly ISelectInvoiceService _selectInvoiceService;
        private readonly IConfidentialInvoiceService _confidentialInvoiceWebService;
        private readonly IBusinessLoansService _businessLoansService;

        public ProductApplicationService(ISelectInvoiceService selectInvoiceService, IConfidentialInvoiceService confidentialInvoiceWebService, IBusinessLoansService businessLoansService)
        {
            _selectInvoiceService = selectInvoiceService;
            _confidentialInvoiceWebService = confidentialInvoiceWebService;
            _businessLoansService = businessLoansService;
        }

        /// <summary>
        /// Submits seller application
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public ISubmitApplicationResult SubmitApplicationFor(ISellerApplication application)
        {
            return application.Product.VisitProduct(this, application);
        }

        ///<inheritdoc/>
        public ISubmitApplicationResult SubmitApplication(
            ISellerApplication application,
            SelectiveInvoiceDiscount selectiveInvoiceDiscount)
        {
            // TODO args validation. Maybe locate validation inside models
            
            // TODO maybe _selectInvoiceService.SubmitApplicationFor signature
            // TODO must be similar to _confidentialInvoiceWebService.SubmitApplicationFor
            // TODO because all these methods return application result
            var result = _selectInvoiceService.SubmitApplicationFor(
                application.CompanyData.Number.ToString(),
                selectiveInvoiceDiscount.InvoiceAmount,
                selectiveInvoiceDiscount.AdvancePercentage);
            
            return new SubmitApplicationResult(result);
        }

        ///<inheritdoc/>
        public ISubmitApplicationResult SubmitApplication(
            ISellerApplication application,
            ConfidentialInvoiceDiscount confidentialInvoiceDiscount)
        {
            // TODO args validation. Maybe locate validation inside models
            var result = _confidentialInvoiceWebService.SubmitApplicationFor(
                new CompanyDataRequest
                {
                    CompanyFounded = application.CompanyData.Founded,
                    CompanyNumber = application.CompanyData.Number,
                    CompanyName = application.CompanyData.Name,
                    DirectorName = application.CompanyData.DirectorName
                }, 
                confidentialInvoiceDiscount.TotalLedgerNetworth, 
                confidentialInvoiceDiscount.AdvancePercentage, 
                confidentialInvoiceDiscount.VatRate);

            return new SubmitApplicationResult(result);
        }

        ///<inheritdoc/>
        public ISubmitApplicationResult SubmitApplication(
            ISellerApplication application,
            BusinessLoans businessLoans)
        {
            // TODO args validation. Maybe locate validation inside models
            var result = _businessLoansService.SubmitApplicationFor(new CompanyDataRequest
            {
                CompanyFounded = application.CompanyData.Founded,
                CompanyNumber = application.CompanyData.Number,
                CompanyName = application.CompanyData.Name,
                DirectorName = application.CompanyData.DirectorName
            }, new LoansRequest
            {
                InterestRatePerAnnum = businessLoans.InterestRatePerAnnum,
                LoanAmount = businessLoans.LoanAmount
            });
            
            return new SubmitApplicationResult(result);
        }
    }
}
