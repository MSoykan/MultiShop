using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers {
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase {
        private readonly ICargoOperationService cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService) {
            this.cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public IActionResult CargoOperationList() {
            var values = cargoOperationService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto) {
            CargoOperation cargoOperation = new CargoOperation() {
                Barcode = createCargoOperationDto.Barcode,
                Description = createCargoOperationDto.Description,
                OperationDate = createCargoOperationDto.OperationDate,
            };
            cargoOperationService.TInsert(cargoOperation);
            return Ok("CargoOperation created succesfully.");
        }
        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id) {
            cargoOperationService.TDelete(id);
            return Ok("CargoOperation deleted with success");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id) {
            var values = cargoOperationService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto) {
            CargoOperation cargoOperation = new CargoOperation() {
                Barcode = updateCargoOperationDto.Barcode,
                CargoOperationId = updateCargoOperationDto.CargoOperationId,
                OperationDate = updateCargoOperationDto.OperationDate,
                Description = updateCargoOperationDto.Description,
            };
            cargoOperationService.TUpdate(cargoOperation);
            return Ok("CargoOperation updated with success");
        }
    }
}
