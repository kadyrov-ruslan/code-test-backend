using System;
using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;
using SlothEnterprise.ProductApplication.Services;

namespace SlothEnterprise.ProductApplication
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
        public int SubmitApplicationFor(ISellerApplication application)
        {
            return application.Product.VisitProduct(this, application);
        }

        ///<inheritdoc/>
        public int SubmitApplication(
            ISellerApplication application,
            SelectiveInvoiceDiscount selectiveInvoiceDiscount)
        {
            return _selectInvoiceService.SubmitApplicationFor(
                application.CompanyData.Number.ToString(),
                selectiveInvoiceDiscount.InvoiceAmount,
                selectiveInvoiceDiscount.AdvancePercentage);
        }

        ///<inheritdoc/>
        public int SubmitApplication(
            ISellerApplication application,
            ConfidentialInvoiceDiscount confidentialInvoiceDiscount)
        {
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

            return (result.Success) ? result.ApplicationId ?? -1 : -1;
        }

        ///<inheritdoc/>
        public int SubmitApplication(
            ISellerApplication application,
            BusinessLoans businessLoans)
        {
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
            return (result.Success) ? result.ApplicationId ?? -1 : -1;
        }
    }
}
