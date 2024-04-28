using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Command.OrderingCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;

namespace MultiShop.Order.WebApi.Controllers {
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase {
        private readonly IMediator mediator;

        public OrderingsController(IMediator mediator) {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderingList() {
            var values = await mediator.Send(new GetOrderingQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingById(int id) {
            var values = await mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command) {
            await mediator.Send(command);
            return Ok("Ordering is added successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrdering(int id) {
            await mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Ordering deleted succesfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command) {
            await mediator.Send(command);
            return Ok("Ordering updated succesfully");
        }


    }
}
