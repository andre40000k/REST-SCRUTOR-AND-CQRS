using ShopMeneger.Contracts.Respons;
using ShopShopMeneger.Data.Context;

namespace ShopMeneger.Service.Commands
{
    public class DeleteShopCommand : IRequestHendler<int>
    {
        private readonly ShopContext _shopContext;
        private readonly IRequestHendler<int, ShopResponse> _currentShop;

        public DeleteShopCommand(ShopContext shopContext,
            IRequestHendler<int, ShopResponse> currentShop)
        {
            _shopContext = shopContext;
            _currentShop = currentShop;
        }

        public async Task HendlerAsync(int shopId, CancellationToken cancellationToken = default)
        {
            var shop = await _currentShop.HendlerAsync(shopId);

            if (shop != null)
            {
                _shopContext.Remove(shop.UpsertShop());
                await _shopContext.SaveChangesAsync(cancellationToken);
            }
            else
                throw new NullReferenceException();
        }
    }
}
