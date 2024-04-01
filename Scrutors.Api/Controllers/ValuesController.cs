using Microsoft.AspNetCore.Mvc;
using ShopMeneger.Contracts.Request;
using ShopMeneger.Contracts.Respons;
using ShopMeneger.Service;
using ShopMeneger.Service.Commands.UpsertModels;

namespace ShopMeneger.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetShop(int ShopId, [FromServices] IRequestHendler<int, ShopResponse> response)
        {
            var currentShop = await response.HendlerAsync(ShopId);

            if (currentShop == null) 
                return BadRequest("Object not found");

            return Ok(currentShop);
        }

        [HttpPost]
        public async Task<IActionResult> AddShop([FromServices] IRequestHendler<UpsertShopCommand> upsertShopCommand, 
            [FromBody] UpsertShopRequest request)
        {
            await upsertShopCommand.HendlerAsync(new UpsertShopCommand
            {
                ShopName = request.ShopName,
                ShopDescription = request.ShopDescription
            });

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> FullUpdateShop(int shopId, [FromServices] IRequestHendler<int, UpsertShopCommand, bool> upsertShopCommand,
            [FromBody] UpsertShopRequest request)
        {
            var check = await upsertShopCommand.HendlerAsync(shopId, new UpsertShopCommand
            {
                ShopName = request.ShopName,
                ShopDescription = request.ShopDescription
            });

            return check == true ? Ok("Exelent!") : BadRequest("Next time will better)");
        }

        [HttpPatch]
        public async Task<IActionResult> PartlyUpdateShop(int shopId, [FromServices] IRequestHendler<int, UpsertOptionalShopCommand, bool> upsertShopCommand,
            [FromBody] UpsertOptionalFildsShopRequest request)
        {
            var check = await upsertShopCommand.HendlerAsync(shopId, new UpsertOptionalShopCommand
            {
                ShopDescription = request.ShopDescription
            });

            return check == true ? Ok("Exelent!") : BadRequest("Next time will better)");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteShop(int shopId, [FromServices] IRequestHendler<int> upserShopCommand)
        {
            try
            {
                await upserShopCommand.HendlerAsync(shopId);
                return Ok("Evere ok!");
            }
            catch (Exception)
            {
                return BadRequest("Problrms!");
            }
        }
    }
}
