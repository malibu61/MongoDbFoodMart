using AutoMapper;
using MongoDbFoodMart.Dtos.CategoryDto;
using MongoDbFoodMart.Dtos.CustomerDto;
using MongoDbFoodMart.Dtos.DepartmentDto;
using MongoDbFoodMart.Dtos.DiscountDto;
using MongoDbFoodMart.Dtos.FeatureDto;
using MongoDbFoodMart.Dtos.ProductDto;
using MongoDbFoodMart.Dtos.SaleDto;
using MongoDbFoodMart.Entities;

namespace MongoDbFoodMart.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();
  



            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
            //CreateMap<Customer, ResultCustomerDto>().ReverseMap();
            CreateMap<Customer, GetByIdCustomerDto>().ReverseMap();

            CreateMap<Customer, ResultCustomerDto>().ForMember(x => x.DepartmentName, y => y.MapFrom(z => z.Department.DepartmentName));




            CreateMap<Department, CreateDepartmentDto>().ReverseMap();
            CreateMap<Department, UpdateDepartmentDto>().ReverseMap();
            CreateMap<Department, ResultDepartmentDto>().ReverseMap();
            CreateMap<Department, GetByIdDepartmentDto>().ReverseMap();



            CreateMap<Discount, CreateDiscountDto>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
            CreateMap<Discount, ResultDiscountDto>().ReverseMap();
            CreateMap<Discount, GetByIdDiscountDto>().ReverseMap();



            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();



            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            //CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Category.CategoryName));




            CreateMap<Sale, CreateSaleDto>().ReverseMap();
            CreateMap<Sale, UpdateSaleDto>().ReverseMap();
            CreateMap<Sale, ResultSaleDto>().ReverseMap();
            CreateMap<Sale, GetByIdSaleDto>().ReverseMap();
        }
    }
}
