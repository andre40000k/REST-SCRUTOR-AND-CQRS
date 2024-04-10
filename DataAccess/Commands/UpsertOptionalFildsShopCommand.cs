using ShopMeneger.Contracts.Respons;
using ShopMeneger.Service.Commands.UpsertModels;
using ShopShopMeneger.Data.Context;

namespace ShopMeneger.Service.Commands
{
    public class UpsertOptionalFildsShopCommand : IRequestHendler<int, UpsertOptionalShopCommand, bool>
    {
        private readonly ShopContext _shopContext;
        private readonly IRequestHendler<int, ShopResponse> _currentShop;

        public UpsertOptionalFildsShopCommand(ShopContext shopContext,
            IRequestHendler<int, ShopResponse> currentShop) 
        { 
            _shopContext = shopContext;
            _currentShop = currentShop;
        }

        public async Task<bool> HendlerAsync(int shopId, UpsertOptionalShopCommand chengData, CancellationToken cancellationToken = default)
        {
            var newShop = await _currentShop.HendlerAsync(shopId);

            if (newShop == null)
            {
                return false;
            }

            newShop.ShopDescription = chengData.ShopDescription;

            _shopContext.Update(newShop.UpsertShop());
            await _shopContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
