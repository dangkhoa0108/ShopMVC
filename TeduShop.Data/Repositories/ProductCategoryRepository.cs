using System.Collections.Generic;
using System.Linq;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    /// <summary>
    /// Interface cuar riêng lớp ProductCategoryRepository
    /// </summary>
    public interface IProductCategoryRepository
    {
        IEnumerable<ProductCategory> GetCategoryByAlias(string alias);
    }

    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        /// <summary>
        /// Implement interface
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        public IEnumerable<ProductCategory> GetCategoryByAlias(string alias)
        {
            return DbContext.ProductCategories.Where(x => x.Alias == alias);
        }
    }
}