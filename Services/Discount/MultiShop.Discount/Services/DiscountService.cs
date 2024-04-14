using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services {
    public class DiscountService : IDiscountService {

        private readonly DapperContext context;

        public DiscountService(DapperContext context) {
            this.context = context;
        }

        public Task CreateCouponAsync(CreateCouponDto createCouponDto) {
            string query = "insert into Coupons (Code,Rate,IsActive, validDate)" +
                " values (@code,@rate,@isActive, @validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.validDate);
        }

        public Task DeleteCouponAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<List<ResultCouponDto>> GetAllCouponAsync() {
            throw new NotImplementedException();
        }

        public Task<GetByIdCouponDto> GetByIdCouponAsync(int id) {
            throw new NotImplementedException();
        }

        public Task UpdateCouponDto(UpdateCouponDto updateCouponDto) {
            throw new NotImplementedException();
        }
    }
}
