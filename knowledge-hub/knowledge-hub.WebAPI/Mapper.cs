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
            .ForMember(dest => dest.UserRole, opt => opt.Ignore())
            .ReverseMap();

         CreateMap<LoginRegisterRequest, Login>().ReverseMap();
         CreateMap<Login, UserResponse>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username))
            .ForMember(dest => dest.UserRole, opt => opt.MapFrom(src => src.User.UserRole.RoleID))
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.User.ImagePath))
            .ForMember(dest => dest.Biography, opt => opt.MapFrom(src => src.User.Biography))
            .ReverseMap();

         CreateMap<BookInsertRequest, Book>().ReverseMap();
         CreateMap<Book, BookResponse>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.category.Name))
            .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.language.Name))
            .ReverseMap();

         CreateMap<CardInfo, PaymentInfoResponse>()
            .ForMember(dest => dest.Cvc, opt => opt.MapFrom(src => src.CVC))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.CardDate))
            .ReverseMap();
         CreateMap<UserPaymentInfoRequest, CardInfo>()
            .ForMember(dest => dest.CardDate, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.CVC, opt => opt.MapFrom(src => src.Cvc))
            .ReverseMap();

      }
   }
}
