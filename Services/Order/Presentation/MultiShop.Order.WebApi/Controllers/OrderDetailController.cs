using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace MultiShop.Order.WebApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase {
        private readonly GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler;
        private readonly GetOrderDetailQueryHandler getOrderDetailQueryHandler;
        private readonly CreateOrderDetailCommandHandler createOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler;
        private readonly RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler;

        public OrderDetailController(GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, GetOrderDetailQueryHandler getOrderDetailQueryHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler) {
            this.getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            this.getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            this.createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            this.updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
            this.removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailList() {
            var values = await getOrderDetailQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id) {
            var values = getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetial(CreateOrderDetailCommand command) {
            await createOrderDetailCommandHandler.Handle(command);
            return Ok("OrderDetial created succesfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOrderDetail(int id) {
            await removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(id));
            return Ok("OrderDetail removed succesfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command) {
            await updateOrderDetailCommandHandler.Handle(command);
            return Ok("OrderDetail updated succesfully");
        }

    }
}
