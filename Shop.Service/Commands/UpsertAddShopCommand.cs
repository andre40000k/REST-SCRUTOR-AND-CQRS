using ShopMeneger.Service.Commands.UpsertModels;
using ShopShopMeneger.Data.Context;

namespace ShopMeneger.Service.Commands
{
    public class UpsertAddShopCommand : IRequestHendler<UpsertShopCommand>
    {
        private readonly ShopContext _context;

        public UpsertAddShopCommand(ShopContext context)
        {
            _context = context;
        }

        public async Task HendlerAsync(UpsertShopCommand upsertShop, CancellationToken cancellationToken = default)
        {
            await _context.AddAsync(upsertShop.UpsertShop(), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
