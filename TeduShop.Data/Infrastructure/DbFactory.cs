using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Data.Infrastructure
{
    public class DbFactory:Disposable, IDbFactory
    {
        /// <summary>
        /// Khai báo biến _dbContext
        /// </summary>
        private TeduShopDbContext _dbContext;

        /// <summary>
        /// Hàm khởi tạo _dbContext
        /// </summary>
        /// <returns></returns>
        public TeduShopDbContext Init()
        {
            return _dbContext ?? (_dbContext = new TeduShopDbContext());
        }

        protected override void DisposeCore()
        {
            _dbContext?.Dispose();
        }
    }
}
