using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Services;

namespace SlothEnterprise.ProductApplication.Products
{
    public interface IProduct
    {
        int Id { get; }
        
        /// <summary>
        /// Visits current product by IProductApplicationVisitor
        /// </summary>
        /// <param name="visitor">Product application visitor</param>
        /// <param name="application">Seller application</param>
        /// <returns></returns>
        int VisitProduct(IProductApplicationVisitor visitor, ISellerApplication application);
    }
}
