using Microsoft.EntityFrameworkCore;
using ShopMeneger.Contracts.Respons;
using ShopShopMeneger.Data.Context;

namespace ShopMeneger.Service.Queries
{
    public class GetShopByIdQuery : IRequestHendler<Guid, ShopResponse>
    {
        private readonly ShopContext _shopContext;

        public GetShopByIdQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public async Task<ShopResponse?> HendlerAsync(Guid shopId, CancellationToken cancellationToken = default)
        {
            return await _shopContext.Shops
                .AsNoTracking()
                .Where(id => id.ShopId == shopId)
                .Select(shop => new ShopResponse
                { 
                    ShopId = shopId,
                    ShopName = shop.ShopName,
                    ShopDescription = shop.ShopDescription  
                })
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
