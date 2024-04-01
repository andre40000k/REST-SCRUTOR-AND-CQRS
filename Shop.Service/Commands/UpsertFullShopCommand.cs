using ShopMeneger.Contracts.Respons;
using ShopMeneger.Service.Commands.UpsertModels;
using ShopShopMeneger.Data.Context;

namespace ShopMeneger.Service.Commands
{
    public class UpsertFullShopCommand : IRequestHendler<int, UpsertShopCommand, bool>
    {
        private readonly ShopContext _shopContext;
        private readonly IRequestHendler<int, ShopResponse> _currentShop;

        public UpsertFullShopCommand(ShopContext shopContext,
            IRequestHendler<int, ShopResponse> currentShop) 
        { 
            _shopContext = shopContext;
            _currentShop = currentShop;
        }

        public async Task<bool> HendlerAsync(int shopId, UpsertShopCommand chengData, CancellationToken cancellationToken = default)
        {
            var newShop = await _currentShop.HendlerAsync(shopId);

            if (newShop == null)
            {
                await _shopContext.AddAsync(chengData.UpsertShop(), cancellationToken);
                await _shopContext.SaveChangesAsync(cancellationToken);

                return true;
            }

            newShop.ShopName = chengData.ShopName;
            newShop.ShopDescription = chengData.ShopDescription;

            _shopContext.Update(newShop.UpsertShop());
            await _shopContext.SaveChangesAsync();

            return true;
        }
    }
}
