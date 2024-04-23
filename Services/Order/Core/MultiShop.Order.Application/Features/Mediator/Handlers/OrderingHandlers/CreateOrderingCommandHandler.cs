using MediatR;
using MultiShop.Order.Application.Features.Mediator.Command.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers {
    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand> {

        private readonly IRepository<Ordering> repository;

        public CreateOrderingCommandHandler(IRepository<Ordering> repository) {
            this.repository = repository;
        }

        public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken) {
            await repository.CreateAsync(new Ordering {
                OrderDate = request.OrderDate,
                TotalPrice = request.TotalPrice,
                UserId = request.UserId,
            });
        }
    }
}
