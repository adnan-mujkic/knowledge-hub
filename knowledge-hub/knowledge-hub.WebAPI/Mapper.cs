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

         CreateMap<BookInsertRequest, Book>()
            .ForMember(dest => dest.BookId, opt => opt.UseDestinationValue())
            .ForMember(dest => dest.Score, opt => opt.UseDestinationValue())
            .ReverseMap();
         CreateMap<Book, BookResponse>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.category.Name))
            .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.language.Name))
            .ReverseMap();
         CreateMap<BookResponse, BookUserWishlist>()
            .ForMember(dest => dest.User, opt => opt.Ignore())
            .ForMember(dest => dest.Book, opt => opt.Ignore())
            .ReverseMap();

         CreateMap<CardInfo, PaymentInfoResponse>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.CardDate))
            .ReverseMap();
         CreateMap<UserPaymentInfoRequest, CardInfo>()
            .ForMember(dest => dest.CardDate, opt => opt.MapFrom(src => src.Date))
            .ReverseMap();
         CreateMap<AddPaymentInfo, CardInfo>()
            .ForMember(dest => dest.CardDate, opt => opt.MapFrom(src => src.Date))
            .ReverseMap();

         CreateMap<OrderAddress, OrderResponse>()
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.Name))
            .ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Order.Book))
            .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.Order.BookId))
            .ForMember(dest => dest.OrderNumber, opt => opt.MapFrom(src => src.Order.OrderNumber))
            .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.Order.OrderStatus))
            .ForMember(dest => dest.ShippingDate, opt => opt.MapFrom(src => src.Order.ShippingDate))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Order.UserId))
            .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.Order.UserFullName))
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

         CreateMap<Order, OrderResponse>()
            .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate.ToShortDateString()))
            .ForMember(dest => dest.ShippingDate, opt => opt.MapFrom(src => src.ShippingDate.ToShortDateString()))
            .ReverseMap();
         CreateMap<OrderInsertRequest, Order>()
            .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => Convert.ToDateTime(src.OrderDate)))
            .ForMember(dest => dest.Digital, opt => opt.Ignore())
            .ForMember(dest => dest.Book, opt => opt.Ignore())
            .ForMember(dest => dest.BookId, opt => opt.Ignore())
            .ReverseMap();

         CreateMap<Category, CategoryResponse>().ReverseMap();
         CreateMap<CategoryInsertRequest, Category>().ReverseMap();

         CreateMap<Language, LanguageResponse>().ReverseMap();
         CreateMap<LanguageInsertRequest, Language>().ReverseMap();

         CreateMap<Transaction, TransactionResponse>()
            .ForMember(dest => dest.userFullName, opt => opt.MapFrom(src => src.Order.UserFullName))
            .ForMember(dest => dest.bookName, opt => opt.MapFrom(src => src.Order.Book.Name))
            .ForMember(dest => dest.cardLastDigits, opt => opt.MapFrom(src => "**** **** **** " + src.CardInfo.CardNumber))
            .ForMember(dest => dest.transactionDate, opt => opt.MapFrom(src => src.TransactionTime.ToShortDateString()))
            .ReverseMap();

      }
   }
}
