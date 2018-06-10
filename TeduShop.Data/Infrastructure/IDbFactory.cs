using System;

namespace TeduShop.Data.Infrastructure
{
    /// <summary>
    /// Khởi tạo hàm Init()
    /// </summary>
    public interface IDbFactory:IDisposable
    {
        TeduShopDbContext Init();
    }
}
