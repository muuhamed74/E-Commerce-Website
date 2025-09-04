using AutoMapper;
using Store.Domain.DTOs;
using Store.Domain.DTOs.Cart;
using Store.Domain.DTOs.Identity;
using Store.Domain.DTOs.Orders;
using Store.Domain.Models;
using Store.Domain.Models.Cart_Models;
using Store.Domain.Models.Identity;
using Store.Domain.Models.Order_Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Evolve_Store.Helpers.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>().ReverseMap()
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images));


            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Images, ImageDto>().ReverseMap();
            CreateMap<Adress, AddressDto>().ReverseMap();
            CreateMap<UserBasket, UserBasketDto>().ReverseMap();
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();

            CreateMap<Address, AddressDto>().ReverseMap();

            CreateMap<Order, OrderToReturnDto>()
                .ForMember(dest => dest.DeliveryMethod, opt => opt.MapFrom(src => src.DeliveryMethod.ShortName))
                .ForMember(dest => dest.DeleveryCost, opt => opt.MapFrom(src => src.DeliveryMethod.Cost));
           
            CreateMap<OrderItems, OrderItemsDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product.ProductId))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.ProductImages, opt => opt.MapFrom(src => src.Product.ProductImages));




            CreateMap<RegisterDto, Appuser>()
              .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
              .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone));


            CreateMap<RegisterDto, UserStoreTemporary>()
            .ForMember(dest => dest.Code, opt => opt.Ignore()) 
            .ForMember(dest => dest.ExpiresAt, opt => opt.Ignore());

            
            CreateMap<UserStoreTemporary, Appuser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email)) 
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Adress, opt => opt.Ignore()) 
                .ForMember(dest => dest.RefreshTokens, opt => opt.Ignore())
                .ForMember(dest => dest.RefreshTokenExpiration, opt => opt.Ignore());

            
            CreateMap<RegisterDto, Appuser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Adress, opt => opt.Ignore())
                .ForMember(dest => dest.RefreshTokens, opt => opt.Ignore())
                .ForMember(dest => dest.RefreshTokenExpiration, opt => opt.Ignore());
        }
    }
    
}

