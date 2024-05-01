using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers {
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase {
        private readonly ICargoDetailService cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService) {
            this.cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailList() {
            var values = cargoDetailService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto) {
            CargoDetail cargoDetail = new CargoDetail() {
                Barcode = createCargoDetailDto.Barcode,
                CargoCompanyId = createCargoDetailDto.CargoCompanyId,
                ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
                SenderCustomer = createCargoDetailDto.SenderCustomer,
            };
            cargoDetailService.TInsert(cargoDetail);
            return Ok("CargoDetail created succesfully.");
        }
        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id) {
            cargoDetailService.TDelete(id);
            return Ok("CargoDetail deleted with success");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id) {
            var values = cargoDetailService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto  updateCargoDetailDto) {
            CargoDetail cargoDetail = new CargoDetail() {
                Barcode = updateCargoDetailDto.Barcode,
                SenderCustomer = updateCargoDetailDto.ReceiverCustomer,
                ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
                CargoDetailId = updateCargoDetailDto.CargoDetailId,
            };
            cargoDetailService.TUpdate(cargoDetail);
            return Ok("CargoDetail updated with success");
        }

    }
}
