using AutoMapper;
using knowledge_hub.WebAPI.Database;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;

namespace knowledge_hub.WebAPI
{
   public class Mapper:Profile
   {
      public Mapper() {
         CreateMap<User, UserRegisterRequest>().ReverseMap();
         CreateMap<User, UserResponse>()
            .ForMember(dest => dest.UserRole, opt => opt.MapFrom(src => src.UserRole.Role.Name))
            .ReverseMap();
         CreateMap<UserInsertRequest, User>().ReverseMap();

         CreateMap<LoginRegisterRequest, Login>().ReverseMap();
         CreateMap<Login, UserResponse>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username))
            .ForMember(dest => dest.UserRole, opt => opt.MapFrom(src => src.User.UserRole.Role.Name))
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.User.ImagePath))
            .ForMember(dest => dest.Biography, opt => opt.MapFrom(src => src.User.Biography))
            .ReverseMap();

         CreateMap<BookInsertRequest, Book>().ReverseMap();
         CreateMap<Book, BookResponse>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.category.Name))
            .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.language.Name))
            .ReverseMap();
         CreateMap<BookResponse, BookUserWishlist>()
            .ForMember(dest => dest.User, opt => opt.Ignore())
            .ForMember(dest => dest.Book, opt => opt.Ignore())
            .ReverseMap();

         CreateMap<CardInfo, PaymentInfoResponse>()
            .ForMember(dest => dest.Cvc, opt => opt.MapFrom(src => src.CVC))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.CardDate))
            .ReverseMap();
         CreateMap<UserPaymentInfoRequest, CardInfo>()
            .ForMember(dest => dest.CardDate, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.CVC, opt => opt.MapFrom(src => src.Cvc))
            .ReverseMap();
         CreateMap<AddPaymentInfo, CardInfo>()
            .ForMember(dest => dest.CardDate, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.CVC, opt => opt.MapFrom(src => src.Cvc))
            .ReverseMap();

         CreateMap<Order, OrderResponse>()
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.Name))
            .ReverseMap();

         CreateMap<City, CityResponse>().ReverseMap();
         CreateMap<CityInsertRequest, City>().ReverseMap();
         CreateMap<CitySearchRequest, City>().ReverseMap();

         CreateMap<BookUserWishlist, WishlistResponse>().ReverseMap();
         CreateMap<WishlistInsertRequest, BookUserWishlist>().ReverseMap();
         CreateMap<WishlistSearchRequest, BookUserWishlist>().ReverseMap();

         CreateMap<UserAddressUpdateRequest, Address>()
            .ForMember(dest => dest.City, opt => opt.Ignore())
            .ReverseMap();
         CreateMap<Address, AddressResponse>()
            .ForMember(dest => dest.city, opt => opt.MapFrom(src => src.City.Name))
            .ForMember(dest => dest.postcode, opt => opt.MapFrom(src => src.City.ZipCode))
            .ReverseMap();

         CreateMap<Review, ReviewResponse>()
            .ForMember(dest => dest.CommentText, opt => opt.MapFrom(src => src.Comment))
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Score))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.PostDate.ToShortDateString()))
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.user.Username))
            .ReverseMap();
         CreateMap<ReviewAddRequest, Review>()
            .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.CommentText))
            .ForMember(dest => dest.Score, opt => opt.MapFrom(src => Math.Round(src.Rating, 1)))
            .ForMember(dest => dest.PostDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ReverseMap();
         CreateMap<ReviewSearchRequest, Review>()
            .ReverseMap();
      }
   }
}
