using AutoMapper;
using MultiShop.Catatalog.Dtos.ProductDetailsDtos;
using MultiShop.Catatalog.Dtos.ProductDtos;
using MultiShop.Catatalog.Dtos.ProductImageDtos;
using MultiShop.Catatalog.Entities;

namespace MultiShop.Catatalog.Mapping {
    public class GeneralMapping : Profile {
        public GeneralMapping() {
            CreateMap<Category, Dtos.CategoryDtos.ResultCategoryDto>().ReverseMap();
            CreateMap<Category, Dtos.CategoryDtos.CreateCategoryDto>().ReverseMap();
            CreateMap<Category, Dtos.CategoryDtos.UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, Dtos.CategoryDtos.GetByIdCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();

            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();

            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductDetailDto>().ReverseMap();

        }
    }
}
