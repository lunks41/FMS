using AutoMapper;

namespace FMS.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<Users, User>()
            //    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            //    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            //    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            //    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            //    .ForMember(dest => dest.BirthYear, opt => opt.MapFrom(src => src.Birthday.Year))
            //    .ForMember(dest => dest.BirthMonth, opt => opt.MapFrom(src => src.Birthday.Month))
            //    .ForMember(dest => dest.BirthDay, opt => opt.MapFrom(src => src.Birthday.Day))
            //    .ForMember(dest => dest.OccupationName, opt => opt.Ignore())

            #region Master
            CreateMap<Boat, Boat>().ReverseMap();
            CreateMap<ExpenseType, ExpenseType>().ReverseMap();
            CreateMap<CommissionType, CommissionType>().ReverseMap();
            #endregion

            #region Transactions
            CreateMap<SaleHd, SaleHd>().ReverseMap();
            CreateMap<OwnerExpenseHd, OwnerExpenseHd>().ReverseMap();
            CreateMap<IncomeHd, IncomeHd>().ReverseMap();
            CreateMap<CreditHd, CreditHd>().ReverseMap();
            #endregion
        }
    }
}
